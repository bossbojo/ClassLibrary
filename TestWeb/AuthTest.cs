using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary.AuthentionJWT;
namespace TestWeb.Authen
{
    public static class AuthTest
    {
        public static Authorization<User> Auth = new Authorization<User>("SSEKEY",60);
    }
    public class User
    {
        public string fisrtname { get; set; }
        public string lastname { get; set; }
    }
}