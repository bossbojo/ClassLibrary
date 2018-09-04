using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public static class GenerateCode
    {
        /// <summary>
        /// Generate code เเบบที่มี ตัวเลขอย่างเดียว
        /// </summary>
        /// <param name="length">ขนาดของความยาวของ code</param>
        /// <returns>string</returns>
        public static string GenerateCodeAllNumber(int length)
        {
            var chars1 = "1234567890";
            var stringChars1 = new char[length];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            return str;
        }
        /// <summary>
        /// Generate code เเบบที่มี ตัวเลข เเละ ตัว A-Z , a-z
        /// </summary>
        /// <param name="length">ขนาดของความยาวของ code</param>
        /// <returns>string</returns>
        public static string GenerateCodeAllNumberAndChar(int length)
        {
            var chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890";
            var stringChars1 = new char[length];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            return str;
        }
        /// <summary>
        /// Generate code เเบบที่มี ตัวเลข เเละ ตัว A-Z , a-z เเละอักษรพิเศษ !@#$%^&*_+=-|
        /// </summary>
        /// <param name="length">ขนาดของความยาวของ code</param>
        /// <returns>string</returns>
        public static string GenerateCodeAllNumberAndCharSpecial(int length)
        {
            var chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890!@#$%^&*_+=-|";
            var stringChars1 = new char[length];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            return str;
        }
    }
}
