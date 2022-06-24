using System.Security.Cryptography;
namespace StorePass.DataServer.Services;

public static class PasswordGenerator
{
    const string alphanumericCharacters =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
        "abcdefghijklmnopqrstuvwxyz" +
        "0123456789";

    const string specialCharacters = @"`~!@#$%^&*()-_=+[]{}\|;:'"",.<>/?";

    public static string Generate(int length)
    {
        var indexPositions = new int[length];

        indexPositions = indexPositions
            .Select(x => x = RandomNumberGenerator.GetInt32(0, alphanumericCharacters.Length))
            .ToArray();

        var passwordChars = indexPositions
            .Select(x => alphanumericCharacters[x])
            .ToArray();

        return new string(passwordChars);
    }
}