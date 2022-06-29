namespace Services.Abstract;

public interface IAesEncryption
{
    string Encrypt(string plainText);
    string Decrypt(string ciphertext);
}