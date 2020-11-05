using LocalModel.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectifIMDB.Tools
{
    public static class SessionHelper
    {
        public static User User { get; private set; }

        public static void SetUser(this ISession session, User Value)
        {
            session.SetString("User", JsonConvert.SerializeObject(Value));
            User = Value;
        }

        public static User GetUser(this ISession session)
        {
            return JsonConvert.DeserializeObject<User>(session.GetString("User"));
        }

        public static void Disconnect(this ISession session)
        {
            session.Clear();
            User = null;
        }
    }
}
