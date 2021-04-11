using MetricsAgent.DAL;
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
using MetricsAgent.Jobs;

namespace MetricsAgent
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
            ConfigureSqlLiteConnection(services);
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            // ��������� �������
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // ��������� ���� ������
            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddSingleton<RamMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddSingleton<HddMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: "0/5 * * * * ?")); // ��������� ������ 5 ������

            services.AddHostedService<QuartzHostedService>();
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            string connectionString = "Data Source=metrics.db";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
            services.AddSingleton(connection);
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                // ������ ����� ����� ������� ��� ����������
                // ������� ������� � ��������� ���� ��� ���������� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(connection))
            {
                // ������ ����� ����� ������� ��� ����������
                // ������� ������� � ��������� ���� ��� ���������� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();

                DateTimeOffset testDay = new DateTimeOffset();
                testDay = DateTime.Now;
                

                // ��������� � ������� Fake-data
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(200,{testDay.Millisecond-1000})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(500,{testDay.Millisecond-5000})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(750,{testDay.Minute-10})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(900,{testDay.Minute-50})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(100,{testDay.Hour-1})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(500,{testDay.Hour-7})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(750,{testDay.Year-101})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO hddmetrics(value, time) VALUES(900,{testDay.Year-121})";
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(connection))
            {
                // ������ ����� ����� ������� ��� ����������
                // ������� ������� � ��������� ���� ��� ���������� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS dotnetmetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE dotnetmetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();

                // ��������� � ������� Fake-data
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(0,10)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(10,20)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(20,40)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(19,50)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(11,110)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(5,120)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(7,140)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(9,150)";
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(connection))
            {
                // ������ ����� ����� ������� ��� ����������
                // ������� ������� � ��������� ���� ��� ���������� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS networkmetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE networkmetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();

                // ��������� � ������� Fake-data
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(200,1)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(300,2)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(350,4)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(440,5)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(510,11)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(630,12)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(710,14)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(900,15)";
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(connection))
            {
                // ������ ����� ����� ������� ��� ����������
                // ������� ������� � ��������� ���� ��� ���������� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS rammetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE rammetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        }
    }
}