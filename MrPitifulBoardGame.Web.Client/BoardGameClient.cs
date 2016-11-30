using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame
{
    public class BoardGameClient
    {
        private HttpClient _httpClient;

        public BoardGameClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }

            set
            {
                _httpClient = value;
            }
        }

    }
}