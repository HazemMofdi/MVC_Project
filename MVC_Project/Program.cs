using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;

namespace MVC_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(); // Enable session support

            // Configure Cookie Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "UserLoginCookie"; // <-- add this line
                options.LoginPath = "/SignUp_Login/Login";
                options.LogoutPath = "/SignUp_Login/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/SignUp_Login/Login";
            });

            // Add DB context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Needed to serve static content (like images, CSS, etc.)

            app.UseRouting();

            app.UseSession(); // ⚠️ Must come **before** authentication if you use session during login

            app.UseAuthentication(); // Add authentication middleware
            app.UseAuthorization();  // Add authorization middleware

            // Define the default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=SignUp_Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
