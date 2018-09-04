using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.AuthentionJWT
{
    public class Securities
    {
        private static UTF8Encoding encodeing = new UTF8Encoding();

        private static string SecurityKey = "SecurityKey";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_SecurityKey">Security Key Encode for Token</param>
        public Securities(string _SecurityKey) {
            SecurityKey = _SecurityKey;
        }
        public static string JWTEncode(object payload)
        {
            try
            {
                return JWT.Encode(payload, UTF8Encoding.ASCII.GetBytes(SecurityKey), JwsAlgorithm.HS256);
            }
            catch
            {
                return null;
            }
        }
        public static T JWTDecode<T>(string token)
        {
            try
            {
                return JWT.Decode<T>(token, UTF8Encoding.ASCII.GetBytes(SecurityKey), JwsAlgorithm.HS256);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
