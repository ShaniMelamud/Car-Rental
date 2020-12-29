using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRental
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
            services.AddCors(setup => setup.AddPolicy("EntireWorld", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddCors(setup => setup.AddPolicy("LocalHostDevelopment", policy => policy.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:5000").AllowAnyMethod().AllowAnyHeader()));
            services.AddDbContext<CarRentalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CarRental")));
            services.AddTransient<CarsTypeLogic>();
            services.AddTransient<CarDataLogic>();
            services.AddTransient<RentalsLogic>();
            services.AddTransient<BranchesLogic>();
            services.AddTransient<UsersLogic>();
            services.AddTransient<CarsLogic>();

            JwtHelper jwtHelper = new JwtHelper(Configuration.GetValue<string>("JWT:Key"));
            services.AddSingleton(jwtHelper);

            services.AddAuthentication(options => jwtHelper.SetAuthenticationOptions(options))
                .AddJwtBearer(options => jwtHelper.SetBearerOptions(options));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();



            app.UseCors("EntireWorld");

            app.UseCors("LocalHostDevelopment");


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
        }
    }
}
