using System.Globalization;
using System.Text.Json;
using HomeLibraryApp.Data;
using HomeLibraryApp.Models;
using HomeLibraryApp.Repositories.Abstractions;
using HomeLibraryApp.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

namespace HomeLibraryApp
{
	public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionStrings:AzureDatabaseConnectionString"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
				.AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddTransient<ILibraryItemsRepository, LibraryItemsRepository>();
            services.AddTransient<IPublishersRepository, PublishersRepository>();
            services.AddTransient<IAuthorsRepository, AuthorsRepository>();
            services.AddTransient<IKeywordsRepository, KeywordsRepository>();
            services.AddTransient<IAttributesRepository, AttributesRepository>();
			services.AddScoped<UserManager<User>>();
            services.AddScoped<SignInManager<User>>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
	            options.IdleTimeout = TimeSpan.FromMinutes(60);
	            options.Cookie.IsEssential = true;
			});
        }

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            var supportedCultures = new[] { new CultureInfo("pl") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
	            DefaultRequestCulture = new RequestCulture("pl"),
	            SupportedCultures = supportedCultures,
	            SupportedUICultures = supportedCultures
            });
		}
    }
}
