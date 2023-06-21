
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Meu_Treino.Helper
{
    public static class Cript
    {
        public static string Cripritografia(this string valor)
        {
            var hash = SHA1.Create();
            var enconding = new ASCIIEncoding();
            var array = enconding.GetBytes(valor);
            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();
            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();

        }
    }
}
