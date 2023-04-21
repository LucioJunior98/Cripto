using System.Security.Cryptography;

namespace CriptoRSA.RSA
{
    public class RSACripto
    {
        private static RSACryptoServiceProvider rsa = null;

        public RSACripto(out string publicKey, out string privateKey)
        {
            rsa = new RSACryptoServiceProvider();

            rsa.KeySize = 1024;

            publicKey = rsa.ToXmlString(false);
            privateKey = rsa.ToXmlString(true);
        }

        public static byte[] Encrypt(byte[] dataToEncrypt)
        {
            if(rsa == null)
            {
                rsa = new RSACryptoServiceProvider();
            }

            return rsa.Encrypt(dataToEncrypt, false);
        }

        public static byte[] Decrypt(byte[] dataToDecrypt)
        {
            byte[] dataDecrypt;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                dataDecrypt = rsa.Decrypt(dataToDecrypt, false);
            }

            return dataDecrypt;
        }
    }
}
