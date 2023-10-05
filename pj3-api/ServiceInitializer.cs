﻿using Microsoft.Extensions.Configuration;
using pj3_api.Model;
using pj3_api.Repository.Feedback;
using pj3_api.Repository.Home;
using pj3_api.Repository.User;
using pj3_api.Service.Feedback;
using pj3_api.Service.Home;
using pj3_api.Service.Mail;
using pj3_api.Service.User;

namespace pj3_api
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterCustomDependencies(services, configuration);

            return services;
        }

        private static void RegisterCustomDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var _appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(_appSettings);

            services.AddSingleton(typeof(AppSettings), _appSettings);
            services.AddSingleton<IHomeService, HomeService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IFeedbackService, FeedbackService>();
            services.AddSingleton<IMailService, MailServiceApp>();
            //services.AddSingleton<IEmployeeManagerService, EmployeeManagerService>();
            //services.AddSingleton<ILoginService, LoginService>();


            services.AddTransient<IHomeRepository, HomeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            //services.AddTransient<IEmployeeManagerRepository, EmployeeManagerRepository>();
            //services.AddTransient<ILoginRepository, LoginRepository>();
        }
    }
}
