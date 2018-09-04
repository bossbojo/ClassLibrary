using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Security
{
    public class App_Securities
    {
        private RSACryptoServiceProvider rsa;
        public SecurityKeyPair keypair;
        private const int PROVIDER_RSA_FULL = 1;
        private const int KEY_SIZE = 1024;
        public App_Securities()
        {
            CspParameters cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            rsa = new RSACryptoServiceProvider(KEY_SIZE, cspParams);

            keypair = ImportKeys();

        }
        public SecurityKeyPair ImportKeys()
        {
            try
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.PathPrivate) && File.Exists(Properties.Settings.Default.PathPrivate) && !string.IsNullOrEmpty(Properties.Settings.Default.PathPublic) && File.Exists(Properties.Settings.Default.PathPublic))
                {
                    return keypair = new SecurityKeyPair
                    {
                        publicKey = System.IO.File.ReadAllText(Properties.Settings.Default.PathPublic).ToString(),
                        privateKey = System.IO.File.ReadAllText(Properties.Settings.Default.PathPrivate).ToString()
                    };
                }
                else
                {
                    return keypair = null;
                }
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }

        public string ExportKeys()
        {
            try
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(Properties.Settings.Default.PathPrivate, privateKey, Encoding.UTF8);
                File.WriteAllText(Properties.Settings.Default.PathPublic, publicKey, Encoding.UTF8);
                return "export success";
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return "export error";
            }
        }

        public SecurityKeyPair GenerateKeyPair()
        {
            return new SecurityKeyPair() { publicKey = rsa.ToXmlString(false), privateKey = rsa.ToXmlString(true) };
        }

        public class SecurityKeyPair
        {
            public string publicKey { get; set; }
            public string privateKey { get; set; }
        }
    }
}
