using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.AuthentionJWT
{
    /// <summary>
    /// สร้าง Authorization 
    /// </summary>
    /// <typeparam name="T">Object ที่ต้องการใช้ในการ Encode เป็น Token</typeparam>
    public class Authorization<T>
    {
        public Auth_user<T> auth_User;
        private static Securities securities_;
        private static int time_token = 60;
        /// <summary>
        /// Get Your Token
        /// </summary>
        public static string Token { get; set; }
        /// <summary>
        /// ใส่ข้อมูล Config ของการ Authorization เเละ tokenTime ค่าเริ่มต้นอยู่ที่ 60 นาที
        /// </summary>
        /// <param name="securities_key"></param>
        private static DateTimeOffset GetNow
        {
            get
            {
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                return TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, timeZoneInfo);
            }
        }
        public Authorization(string securities_key)
        {
            securities_ = new Securities(securities_key);
        }
        /// <summary>
        /// ใส่ข้อมูล Config ของการ Authorization
        /// </summary>
        /// <param name="securities_key">Key ที่ใช้เข้ารหัส Token</param>
        /// <param name="tokenTime">เวลาของ Token หน่วยเป็น นาที</param>
        public Authorization(string securities_key, int tokenTime)
        {
            securities_ = new Securities(securities_key);
            time_token = tokenTime;
        }
        /// <summary>
        /// Set Authorization
        /// </summary>
        /// <param name="_User">object ที่ต้องการทำเป็น Token</param>
        /// <returns>Token</returns>
        public string SetAuthenticated(T _User)
        {
            if (_User == null)
            {
                return null;
            }
            auth_User = new Auth_user<T>{User = _User,exp = GetNow.AddMinutes(time_token).ToUnixTimeSeconds()};
            Token = Securities.JWTEncode(auth_User);
            return Token;
        }
        /// <summary> 
        /// Get user ที่ login อยู่ในตอนนี้โดยใช้ Token
        /// </summary>
        /// <param name="Token">Token ของผู้ใช้งาน</param>
        /// <returns></returns>
        public Auth_user<T> GetAuthenticated(string Token)
        {
            var user = Securities.JWTDecode<Auth_user<T>>(Token);
            if (user != null)
            {
                if (HasToken(user))
                {
                    return user;
                }
            }
            return null;
        }
        /// <summary>
        /// Check ว่ามี Token นี้หรือป่าว
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public bool HasToken(Auth_user<T> auth)
        {
            if (auth != null)
            {
                bool check = auth.exp >= GetNow.ToUnixTimeSeconds();
                return check;
            }
            return false;
        }
    }
    public class Auth_user<T>
    {
        public T User { get; set; }
        public long exp { get; set; }
    }
}
