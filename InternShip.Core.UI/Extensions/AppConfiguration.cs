using InternShip.Core.Repository.DataAccess;
using InternShip.Core.Repository.Initialize;
using InternShip.Core.Repository.Interfaces;
using InternShip.Core.Service.Managers;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InternShip.Core.UI.Extensions
{
    public static class AppConfiguration
    {
        // Container Dependencies

        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            // Context Configuration

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Sql"));
            });

            services.AddTransient<DbInitializer>();

            // Default Mvc

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x => { x.LoginPath = "/Auth/ChooseUser"; });

            services.AddControllersWithViews();

            // Auto Mapper

            services.AddAutoMapper(typeof(Program));

            // Configure Interfaces Dependencies

            services.AddScoped<IInternPlaceRepository, InternPlaceRepository>();
            services.AddScoped<IInternPlaceService, InternPlaceManager>();

            services.AddScoped<IInternBookRepository, InternBookRepository>();
            services.AddScoped<IInternBookService, InternBookManager>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<ILecturerRepository, LecturerRepository>();
            services.AddScoped<ILecturerService, LecturerManager>();
        }
        public static WebApplication ConfigureApp(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var initialiser = services.GetRequiredService<DbInitializer>();
                initialiser.Run();
            }
            // Error Page Configuration

            app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/Main/Error", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Default Controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=ChooseUser}/{id?}");

            // Area Controllers
            app.MapControllerRoute(
               name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();

            return app;
        }
    }
}
