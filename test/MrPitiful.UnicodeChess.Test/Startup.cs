using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MrPitiful.BoardGame.Base;
using MrPitiful.UnicodeChess;


namespace MrPitiful.UnicodeChess.Test
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
            services.AddTransient<Game, ChessGame>();
            services.AddTransient<GameBoard, ChessGameBoard>();
            services.AddTransient<GameBoardSpace, ChessGameBoardSpace>();
            services.AddTransient<GamePiece, ChessGamePiece>();
            services.AddSingleton<IGameRepository, ChessListGameRepository>();
            services.AddTransient<IChessGameClient, ChessGameClient>();
            services.AddSingleton<IGameBoardRepository, ChessListGameBoardRepository>();
            services.AddTransient<IChessGameBoardClient, ChessGameBoardClient>();
            services.AddSingleton<IGameBoardSpaceRepository, ChessListGameBoardSpaceRepository>();
            services.AddTransient<IChessGameBoardSpaceClient, ChessGameBoardSpaceClient>();
            services.AddSingleton<IGamePieceRepository, ChessListGamePieceRepository>();
            services.AddTransient<IChessGamePieceClient, ChessGamePieceClient>();
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
