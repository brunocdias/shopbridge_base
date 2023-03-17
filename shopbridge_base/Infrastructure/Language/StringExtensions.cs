using System.Linq;

namespace Shopbridge_base.Infrastructure.Language
{
    public static class StringExtensions
    {
        public static string ToCode(this string mensagem)
        {
            return mensagem.Split('|').First();
        }

        public static string ToMessage(this string mensagem)
        {
            return string.Join("|", mensagem.Split('|').First());
        }
    }
}