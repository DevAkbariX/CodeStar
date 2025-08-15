using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Application.Services;
using CodeStar.Infrastructure.Repository;
using CodeStar.Infrastructure.Utilities;

namespace CodeStar.API.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IinstructorRequestService, instructorRequestService>();
            services.AddScoped<IinstructorRequestRepository, InstructorRequestRepository>();
            services.AddScoped<IEmailSender, GmailEmailSender>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IInstructorServices, InstructorServices>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthorizationService, AuthorizationService>();
            return services;
        }
    }
}
