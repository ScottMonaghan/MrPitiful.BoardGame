using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            //services.AddDbContext<GameObjectDbContext>(opt => opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;"));
            services.AddTransient<GameObject, GenericGameObject>();
            services.AddTransient<Game, GenericGame>();
            services.AddTransient<GameBoard, GenericGameBoard>();
            services.AddTransient<GameBoardSpace, GenericGameBoardSpace>();
            services.AddTransient<GamePiece, GenericGamePiece>();
            services.AddSingleton<IGameObjectRepository, GenericListGameObjectRepository>();
            services.AddSingleton<IGameRepository, GenericListGameRepository>();
            services.AddSingleton<IGameBoardRepository, GenericListGameBoardRepository>();
            services.AddSingleton<IGameBoardSpaceRepository, GenericListGameBoardSpaceRepository>();
            services.AddSingleton<IGamePieceRepository, GenericListGamePieceRepository>();
            
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
