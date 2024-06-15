using Jevstafjev.Encryptor.Contracts;
using System.Text;

namespace Jevstafjev.Encryptor.BaconCipher
{
    public class BaconCipher : ICipher
    {
        private readonly Dictionary<char, string> _codes = new()
        {
            {'A', "AAAAA"}, {'B', "AAAAB"}, {'C', "AAABA"}, {'D', "AAABB"}, {'E', "AABAA"},
            {'F', "AABAB"}, {'G', "AABBA"}, {'H', "AABBB"}, {'I', "ABAAA"}, {'J', "ABAAB"},
            {'K', "ABABA"}, {'L', "ABABB"}, {'M', "ABBAA"}, {'N', "ABBAB"}, {'O', "ABBBA"},
            {'P', "ABBBB"}, {'Q', "BAAAA"}, {'R', "BAAAB"}, {'S', "BAABA"}, {'T', "BAABB"},
            {'U', "BABAA"}, {'V', "BABAB"}, {'W', "BABBA"}, {'X', "BABBB"}, {'Y', "BBAAA"},
            {'Z', "BBAAB"}
        };

        public string? Encrypt(string value)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in value)
            {
                var key = char.ToUpper(item);
                if (!_codes.ContainsKey(key))
                {
                    continue;
                }

                stringBuilder.Append(_codes[key]);
                stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }

        public string? Decrypt(string value)
        {
            var stringBuilder = new StringBuilder();

            var items = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                if (!_codes.ContainsValue(item))
                {
                    return null;
                }

                stringBuilder.Append(_codes.First(x => x.Value == item).Key);
            }

            return stringBuilder.ToString();
        }

        public string Name => "Bacon cipher";
    }
}
