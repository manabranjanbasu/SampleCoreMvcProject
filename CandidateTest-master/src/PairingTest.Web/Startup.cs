using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PairingTest.Web.Configuration;
using PairingTest.WebCore.Configuration;
using PairingTest.WebCore.Interfaces;
using PairingTest.WebCore.Services;
using PairingTest.WebInfrastructure.Constants;
using PairingTest.WebInfrastructure.Services;
using Polly.Extensions.Http;
using Polly;
using System.Net.Http;
using System;

namespace PairingTest.Web
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
            services.AddControllersWithViews();
            services.AddSingleton<IConfiguration>(Configuration);

            var serviceProvider = services.BuildServiceProvider();
            var httpSettings = serviceProvider.GetService<IOptions<HttpSettingsOptions>>()?.Value;
            services.AddHttpClient(HttpClientConstants.HttpClientWithBackOff).AddPolicyHandler(GetRetryPolicy(httpSettings));

            services.Configure<ServiceURLOptions>(Configuration.GetSection(ServiceURLOptions.ServiceURLs));
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();
            services.AddScoped<IQuestionnaireQueryService, QuestionnaireQueryService>();

            services.AddAutoMapper(typeof(Startup));
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
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Questionnaire}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(HttpSettingsOptions options)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(options.RetryCount, retryAttempt =>
                {
                    return TimeSpan.FromSeconds(Math.Pow(options.InitialRetryDelay, retryAttempt));
                });
        }
    }
}
