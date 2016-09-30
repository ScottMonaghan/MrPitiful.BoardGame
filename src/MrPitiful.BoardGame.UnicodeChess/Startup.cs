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
using System.Net.Http;


namespace MrPitiful.UnicodeChess
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
               // builder.AddApplicationInsightsSettings(developerMode: true);
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
            services.AddSingleton<IGameRepository, ChessListGameRepository>();
            services.AddTransient<IGame, ChessGame>();
            services.AddTransient<IChessGame, ChessGame>();
            services.AddSingleton<IGameBoardRepository, ChessListGameBoardRepository>();
            services.AddTransient<IGameBoard, ChessGameBoard>();
            services.AddTransient<IChessGameBoard, ChessGameBoard>();
            services.AddSingleton<IGameBoardSpaceRepository, ChessListGameBoardSpaceRepository>();
            services.AddTransient<IGameBoardSpace, ChessGameBoardSpace>();
            services.AddSingleton<IGamePieceRepository, ChessListGamePieceRepository>();
            services.AddTransient<IGamePiece, ChessGamePiece>();
            services.AddTransient<IChessGamePiece, ChessGamePiece>();
            services.AddTransient<IChessGameClient, ChessGameClient>(x => {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Configuration.GetSection("ChessApiUris").GetValue<string>("ChessGameApiUri"));
                return new ChessGameClient(httpClient);
            });
            services.AddTransient<IChessGameBoardClient, ChessGameBoardClient>(x => {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Configuration.GetSection("ChessApiUris").GetValue<string>("ChessGameBoardApiUri"));
                return new ChessGameBoardClient(httpClient);
            });
            services.AddTransient<IChessGameBoardSpaceClient, ChessGameBoardSpaceClient>(x => {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Configuration.GetSection("ChessApiUris").GetValue<string>("ChessGameBoardSpaceApiUri"));
                return new ChessGameBoardSpaceClient(httpClient);
            });
            services.AddTransient<IChessGamePieceClient, ChessGamePieceClient>(x => {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Configuration.GetSection("ChessApiUris").GetValue<string>("ChessGamePieceApiUri"));
                return new ChessGamePieceClient(httpClient);
            });
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
