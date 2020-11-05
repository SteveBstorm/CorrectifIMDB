using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectifIMDB.Tools
{
    public static class Error
    {
        public static string Message { get; private set; }

        public static void SetMessage(string message)
        {
            Message = message;
        }

        public static void Release()
        {
            Message = "";
        }
    }
}
