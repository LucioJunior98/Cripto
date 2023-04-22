using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using CriptoRSA.RSA;

namespace CriptoRSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cripto = new RSACripto();
                string messageCripto = string.Empty;
                string op = string.Empty;
                List<string> multiCriptografia = new List<string>();
                List<byte[]> encondes = new List<byte[]>();
                byte[] encode;

                Console.WriteLine("Digite valor a ser criptografado: ");
                messageCripto = Console.ReadLine();

                if (string.IsNullOrEmpty(messageCripto))
                    throw new Exception("Digite a menssage");

                encode = Encoding.UTF8.GetBytes(messageCripto);

                encondes.Add(cripto.Encrypt(encode));
                multiCriptografia.Add(Encoding.UTF8.GetString(encondes[0]));

                Console.WriteLine("Menssagem criptografada: 0 - " + multiCriptografia[0]);

                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("Deseja gerar outra Criptogafia ou Descriptografar Mensagem ?");
                    Console.WriteLine("Opções: Criptografar / Descriptografar / Sair");
                    op = Console.ReadLine();

                    switch (op)
                    {
                        case "Criptografar":

                            if (multiCriptografia.Count > 5)
                                Console.WriteLine("Limite maximo de Criptografia atigido");
                            else
                            {
                                encondes.Add(cripto.Encrypt(encode));

                                encondes.ForEach(x =>
                                {
                                    multiCriptografia.Add(Encoding.UTF8.GetString(x));
                                });

                                int count = 0;

                                multiCriptografia.ForEach(x => {

                                    Console.WriteLine("Menssagem criptografada: " + count + " - " + x);
                                    count++;
                                });
                            }                         

                            break;
                        case "Descriptografar":
                            Console.WriteLine("Quais das Criptografia? - Escolha por Indice");
                            string opIndex = Console.ReadLine();

                            int index = Convert.ToInt32(opIndex);

                            string decode = Encoding.UTF8.GetString(cripto.Decrypt(encondes[index]));

                            Console.WriteLine("Descriptografia: " + decode);

                            break;
                        case "Sair":
                            loop = false;
                            break;
                        default:
                            throw new Exception("Opcao invalida");
                    }
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Main(args);
            }
        }
    }
}