using System.Security.Cryptography;
using System.Text;

namespace CriptoRSA
{
    internal class Program
    {
        public static string publicKey = string.Empty;
        public static string privateKey = string.Empty;

        static void Main(string[] args)
        {
            string message = "Tem que criptografar isso daqui";
            Console.WriteLine("Mensage para criptografar: " + message);
            byte[] messageEncrypt = null;
            byte[] messageEncrypt2 = null;
            string messageDecrypt = string.Empty;
            string messageDecrypt2 = string.Empty;
            byte[] encode = Encoding.UTF8.GetBytes(message);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.KeySize = 1024;

                publicKey = rsa.ToXmlString(true);
                privateKey = rsa.ToXmlString(false);

                messageEncrypt = rsa.Encrypt(encode, false);

                rsa.Clear();
            }

            Console.WriteLine("MessageCripto: " + Encoding.UTF8.GetString(messageEncrypt));

            Console.WriteLine("Criptografar de novo?");

            bool isCripto = Convert.ToBoolean(Console.ReadLine());

            if (isCripto)
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);
                    rsa.PersistKeyInCsp = true;

                    rsa.KeySize = 1024;

                    messageEncrypt2 = rsa.Encrypt(encode, false);

                    rsa.Clear();
                }

            }

            Console.WriteLine("MessageCripto2: " + Encoding.UTF8.GetString(messageEncrypt2));

            Console.WriteLine("Descriptografar?");

            bool isDescripto = Convert.ToBoolean(Console.ReadLine());

            if (isDescripto)
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    rsa.PersistKeyInCsp = true;

                    rsa.KeySize = 1024;

                    messageDecrypt = Encoding.UTF8.GetString(rsa.Decrypt(messageEncrypt, false));

                    rsa.Clear();
                }

                Console.WriteLine("Descripto: " + messageDecrypt);

                Console.ReadLine();
            } 
            
            Console.WriteLine("Descriptografar?");

            bool isDescripto2 = Convert.ToBoolean(Console.ReadLine());

            if (isDescripto2)
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    rsa.PersistKeyInCsp = true;

                    rsa.KeySize = 1024;

                    messageDecrypt2 = Encoding.UTF8.GetString(rsa.Decrypt(messageEncrypt2, false));

                    rsa.Clear();
                }

                Console.WriteLine("Descripto: " + messageDecrypt2);

                Console.ReadLine();
            }

        }
    }
}