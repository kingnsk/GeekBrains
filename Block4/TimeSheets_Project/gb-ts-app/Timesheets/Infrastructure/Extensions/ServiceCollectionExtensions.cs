﻿using System;
using System.IO;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Timesheets.Data.Ef;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Implementation;
using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Validation;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TimesheetDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Postgres"),
                    b => b.MigrationsAssembly("Timesheets"));
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));

            var jwtSettings = new JwtOptions();
            configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

            services.AddTransient<ILoginManager, LoginManager>();

            services
                .AddAuthentication(
                    x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
                });
        }

        public static void ConfigureDomainManagers(this IServiceCollection services)
        {
            services.AddScoped<ISheetManager, SheetManager>();
            services.AddScoped<IContractManager, ContractManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IInvoiceManager, InvoiceManager>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISheetRepo, SheetRepo>();
            services.AddScoped<IContractRepo, ContractRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            //services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            //services.AddScoped<IServiceRepo, ServiceRepo>();
        }

        public static void ConfigureBackendSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Timesheets web application",
                    Description = "",
                });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference(){Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SheetRequest>, SheetRequestValidator>();
        }

    }
}