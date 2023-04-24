using System.Security.Cryptography;

namespace CriptoRSA.RSA
{
    public class RSACripto : IDisposable
    {
        private RSACryptoServiceProvider rsa = null;
        public string PublicKey = string.Empty;
        public string PrivateKey = string.Empty;

        public RSACripto()
        {
            rsa = new RSACryptoServiceProvider();

            rsa.KeySize = 512;

            PublicKey = rsa.ToXmlString(false);
            PrivateKey = rsa.ToXmlString(true);
        }

        public byte[] Encrypt(byte[] dataToEncrypt)
        {
            try
            {
                byte[] dataEncrypt;

                if (rsa == null)
                {
                    rsa = new RSACryptoServiceProvider();
                    rsa.KeySize = 1024;

                    PublicKey = rsa.ToXmlString(true);
                    PrivateKey = rsa.ToXmlString(false);

                    dataEncrypt = rsa.Encrypt(dataToEncrypt, false);
                }
                else
                {
                    rsa.FromXmlString(PublicKey);
                    rsa.PersistKeyInCsp = true;

                    dataEncrypt = rsa.Encrypt(dataToEncrypt, false);
                }

                return dataEncrypt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt)
        {
            byte[] dataDecrypt;

            rsa.FromXmlString(PrivateKey);
            rsa.PersistKeyInCsp = true;

            dataDecrypt = rsa.Decrypt(dataToDecrypt, false);

            return dataDecrypt;
        }

        public void Dispose()
        {
            rsa.Dispose();
        }
    }
}
