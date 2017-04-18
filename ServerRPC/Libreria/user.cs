using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class user
    {
        public string nickname;
        public string ip;
        public string port;
       
        public  user(string nickname,string ip, string port)
        {
            this.ip = ip;
            this.nickname = nickname;
            this.port = port;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            user p = (user)obj;
            return (nickname==p.nickname) && (ip==p.ip) && (port==p.port);
        }


    }
}
