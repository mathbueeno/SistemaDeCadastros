using System.Security.Cryptography;
using System.Text;

namespace SistemaDeCadastros.Helper
{
    public static class Criptografia
    {
        // método de extensão - this
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var incode = new ASCIIEncoding();
            var array = incode.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            // laço de repetição
            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
