using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModioSnowrunner
{

    public class TokenStruct
    {
        public int code
        {
            get; set;
        }
        public string access_token
        {
            get; set;
        }
        public int date_expires
        {
            get; set;
        }
    }


    public class ErrorResponse
    {
        public int code
        {
            get; set;
        }
        public string message
        {
            get; set;
        }
    }


}
