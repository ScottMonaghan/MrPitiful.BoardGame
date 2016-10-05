using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public class SlackResponse : ISlackResponse
    {
        private string _response_type = "";
        private string _text = "";
        public SlackResponse() { }
        public string response_type
        {
            get
            {
                return _response_type;
            }

            set
            {
                _response_type = value;
            }
        }

        public string text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }
    }
}
