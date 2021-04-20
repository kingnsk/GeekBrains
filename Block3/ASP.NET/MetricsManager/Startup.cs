using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.SQLite;
using System;
using AutoMapper;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using MetricsManager.Jobs;
using MetricsManager.DAL;
using FluentMigrator.Runner;
using System.Net.Http;
using Polly;
using NLog.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;


namespace MetricsManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen();

            services.AddControllers();

            services.AddSingleton<AgentInfoStorage>();
            services.AddSingleton<IWorkWithAgentRepository, WorkWithAgentRepository>();
            services.AddSingleton<ICpuMetricsFromAgentRepository, CpuMetricsFromAgentRepository>();
            services.AddSingleton<IHddMetricsFromAgentRepository, HddMetricsFromAgentRepository>();
            services.AddSingleton<INetworkMetricsFromAgentRepository, NetworkMetricsFromAgentRepository>();
            services.AddSingleton<IDotNetMetricsFromAgentRepository, DotNetMetricsFromAgentRepository>();
            services.AddSingleton<IRamMetricsFromAgentRepository, RamMetricsFromAgentRepository>();

            services.AddSingleton<IMetricsAgentClient, MetricsAgentClient>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API ��������� ��� ������� ����� ������",
                    Description = "api ����� ������� ���",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "XXX",
                        Email = string.Empty,
                        Url = new Uri("https://kremlin.ru"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "GPLv10.10",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                // ��������� ���� �� �������� ����� ����������� ��� Swagger UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services.AddHttpClient<IMetricsAgentClient, MetricsAgentClient>().AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ =>
TimeSpan.FromMilliseconds(1000)));


            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // ��������� ��������� SQLite
                    .AddSQLite()
                    // ������������� ������ �����������
                    .WithGlobalConnectionString(SQLConnectionSettings.ConnectionString)
                    // ������������ ��� ������ ������ � ����������
                    .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());

            // ��������� �������
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // ��������� ���� ������
            services.AddSingleton<GetAllCpuMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllCpuMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddSingleton<GetAllHddMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllHddMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddSingleton<GetAllNetworkMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllNetworkMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddSingleton<GetAllDotNetMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllDotNetMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddSingleton<GetAllRamMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllRamMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddHostedService<QuartzHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            // ��������� middleware � �������� ��� ��������� Swagger ��������.
            app.UseSwagger();
            // ��������� middleware ��� ��������� swagger-ui
            // ��������� Swagger JSON �������� (���� ���������� �� ��������������� �������������
            // �� ������� ����� �������� UI).
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ������� ��������� ������� ����� ������");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // ��������� ��������
            migrationRunner.MigrateUp();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}