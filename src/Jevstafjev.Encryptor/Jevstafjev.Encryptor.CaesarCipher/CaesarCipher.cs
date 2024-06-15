using Jevstafjev.Encryptor.Contracts;
using System.Text;

namespace Jevstafjev.Encryptor.CaesarCipher
{
    /// <summary>
    /// Implements the Caesar cipher for encrypting and decrypting text using a specified shift.
    /// Only works with Latin letters (A-Z, a-z).
    /// </summary>
    public class CaesarCipher : ICipher
    {
        public const int Shift = 3;

        public string? Encrypt(string value)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in value)
            {
                var isLetter = item >= 'A' && item <= 'Z'|| item >= 'a' && item <= 'z';
                if (!isLetter)
                {
                    stringBuilder.Append(item);
                    continue;
                }

                var baseLetter = char.IsUpper(item) ? 'A' : 'a';
                var shifted = (char)(baseLetter + (item - baseLetter + Shift) % 26);

                stringBuilder.Append(shifted);
            }

            return stringBuilder.ToString();
        }

        public string? Decrypt(string value)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in value)
            {
                var isLetter = item >= 'A' && item <= 'Z' || item >= 'a' && item <= 'z';
                if (!isLetter)
                {
                    stringBuilder.Append(item);
                    continue;
                }

                var baseLetter = char.IsUpper(item) ? 'A' : 'a';
                var shifted = (char)(baseLetter + (item - baseLetter - Shift + 26) % 26);

                stringBuilder.Append(shifted);
            }

            return stringBuilder.ToString();
        }
        
        public string Name => "Caesar cipher";
    }
}
