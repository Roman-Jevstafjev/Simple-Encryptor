namespace Jevstafjev.Encryptor.Contracts
{
    public interface ICipher
    {
        string? Encrypt(string value);

        string? Decrypt(string value);

        string Name { get; }
    }
}
