using Jevstafjev.Encryptor.Contracts;
using System.Text;

namespace Jevstafjev.Encryptor.AtbashCipher
{
    public class AtbashCipher : ICipher
    {
        public string? Encrypt(string value)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in value)
            {
                if (item >= 'A' && item <= 'Z')
                {
                    var opposite = (char)('A' + ('Z' - item));
                    stringBuilder.Append(opposite);

                    continue;
                }

                if (item >= 'a' && item <= 'z')
                {
                    var opposite = (char)('a' + ('z' - item));
                    stringBuilder.Append(opposite);

                    continue;
                }

                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }

        public string? Decrypt(string value)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in value)
            {
                if (item >= 'A' && item <= 'Z')
                {
                    var opposite = (char)('A' + ('Z' - item));
                    stringBuilder.Append(opposite);

                    continue;
                }

                if (item >= 'a' && item <= 'z')
                {
                    var opposite = (char)('a' + ('z' - item));
                    stringBuilder.Append(opposite);

                    continue;
                }

                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }

        public string Name => "Atbash cipher";
    }
}
