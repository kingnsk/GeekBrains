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
                    Title = "API Менеджера для агентов сбора метрик",
                    Description = "api нашго сервиса тут",
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
                // Указываем файл из которого брать комментарии для Swagger UI
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
                    // добавляем поддержку SQLite
                    .AddSQLite()
                    // устанавливаем строку подключения
                    .WithGlobalConnectionString(SQLConnectionSettings.ConnectionString)
                    // подсказываем где искать классы с миграциями
                    .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());

            // ДОбавляем сервисы
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // добавляем нашу задачу
            services.AddSingleton<GetAllCpuMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllCpuMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            services.AddSingleton<GetAllHddMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllHddMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            services.AddSingleton<GetAllNetworkMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllNetworkMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            services.AddSingleton<GetAllDotNetMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllDotNetMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            services.AddSingleton<GetAllRamMetricFromAgentsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllRamMetricFromAgentsJob),
                cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            services.AddHostedService<QuartzHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            // Включение middleware в пайплайн для обработки Swagger запросов.
            app.UseSwagger();
            // включение middleware для генерации swagger-ui
            // указываем Swagger JSON эндпоинт (куда обращаться за сгенерированной спецификацией
            // по которой будет построен UI).
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервиса менеджера агентов сбора метрик");
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
            // запускаем миграции
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