using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PairingTest.API.Infrastructure.Data;
using PairingTest.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using PairingTest.API.Core.Interfaces;
using PairingTest.API.Core.Services;
using PairingTest.API.Middleware;

namespace PairingTest.WebApi
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
            services.AddTransient<IQuestionRepository, QuestionRepository>();

            services.AddSingleton(this.Configuration);
            string connectionString = this.Configuration.GetConnectionString("TESTDB");
            services.AddDbContext<PairingTestDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, PairingTestRepository>();

            services.AddTransient<IQuestionnaireService, QuestionnaireService>();
            services.AddTransient<IScoreCalculation, ScoreCalculationService>();
            services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            //app.UseMvc();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAppAuthentication();
            app.UseAppExceptionHandling();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}