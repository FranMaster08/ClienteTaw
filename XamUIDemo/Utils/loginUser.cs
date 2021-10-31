using System;
using XamUIDemo.Responses;

namespace XamUIDemo.Utils
{
    public class loginUser
    {
        private static loginUser instance;
        public UserResponses UserLog { get; set; }

        public static loginUser getInstance()
        {
            if (instance == null)
            {
                instance = new loginUser();
            }
            return instance;
        }

        private  loginUser()
        {
        }
    }
}
