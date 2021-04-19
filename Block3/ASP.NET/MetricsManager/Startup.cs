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
            services.AddControllers();
            //            ConfigureSqlLiteConnection(services);
            //services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            //services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            //services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            //services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
            //services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();

            services.AddSingleton<AgentInfoStorage>();
            services.AddSingleton<IWorkWithAgentRepository, WorkWithAgentRepository>();
            services.AddSingleton<ICpuMetricsFromAgentRepository, CpuMetricsFromAgentRepository>();
            services.AddSingleton<IHddMetricsFromAgentRepository, HddMetricsFromAgentRepository>();
            services.AddSingleton<INetworkMetricsFromAgentRepository, NetworkMetricsFromAgentRepository>();
            services.AddSingleton<IDotNetMetricsFromAgentRepository, DotNetMetricsFromAgentRepository>();
            services.AddSingleton<IRamMetricsFromAgentRepository, RamMetricsFromAgentRepository>();


            services.AddSingleton<IMetricsAgentClient, MetricsAgentClient>();

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


            //services.AddSingleton<RamMetricJob>();
            //services.AddSingleton(new JobSchedule(
            //    jobType: typeof(RamMetricJob),
            //    cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            //services.AddSingleton<HddMetricJob>();
            //services.AddSingleton(new JobSchedule(
            //    jobType: typeof(HddMetricJob),
            //    cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            //services.AddSingleton<NetworkMetricJob>();
            //services.AddSingleton(new JobSchedule(
            //    jobType: typeof(NetworkMetricJob),
            //    cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            //services.AddSingleton<DotNetMetricJob>();
            //services.AddSingleton(new JobSchedule(
            //    jobType: typeof(DotNetMetricJob),
            //    cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            services.AddHostedService<QuartzHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
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