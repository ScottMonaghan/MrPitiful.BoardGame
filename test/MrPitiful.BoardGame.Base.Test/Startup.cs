using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MrPitiful.BoardGame.Base.Test
{
    public class Startup 
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();
            services.AddSingleton<IGameObjectRepository, GenericListGameObjectRepository>();
            services.AddTransient<IGameObject, GenericGameObject>();
            services.AddSingleton<IGameRepository, GenericListGameRepository>();
            services.AddTransient<IGame, GenericGame>();
            services.AddSingleton<IGameBoardRepository, GenericListGameBoardRepository>();
            services.AddTransient<IGameBoard, GenericGameBoard>();
            services.AddSingleton<IGameBoardSpaceRepository, GenericListGameBoardSpaceRepository>();
            services.AddTransient<IGameBoardSpace, GenericGameBoardSpace>();
            services.AddSingleton<IGamePieceRepository, GenericListGamePieceRepository>();
            services.AddTransient<IGamePiece, GenericGamePiece>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseApplicationInsightsRequestTelemetry();

            //app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
