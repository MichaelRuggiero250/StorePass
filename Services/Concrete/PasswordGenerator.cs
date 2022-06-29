using Contracts.Exceptions;
using System.Security.Cryptography;
namespace Services.Concrete;

public static class PasswordGenerator
{
    const string alphanumericCharacters =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
        "abcdefghijklmnopqrstuvwxyz" +
        "0123456789";

    const string specialCharacters =
        @"`~!@#$%^&*()-_=+[]{}\|;:'"",.<>/? ";

    public static string Generate(int length, bool specialChars)
    {
        if (length == default)
            throw new BadRequestException($"Length of password cannot be {length}");

        var adjustedLength = length;

        // If the password will contain special characters
        // up to 50% of the password can be made up of special characters
        if (specialChars)
            adjustedLength = (int)Math.Round(length * (RandomNumberGenerator.GetInt32(50, 90) / 100.00m));

        var alphanumericIndexPositions = new int[adjustedLength];

        alphanumericIndexPositions = alphanumericIndexPositions
            .Select(x => x = RandomNumberGenerator.GetInt32(0, alphanumericCharacters.Length))
            .ToArray();

        var passwordChars = alphanumericIndexPositions
            .Select(x => alphanumericCharacters[x])
            .ToArray();

        var password = new string(passwordChars);

        if (specialChars)
        {
            var numOfSpecialChars = length - adjustedLength;

            for (int i = 0; i <= numOfSpecialChars; i++)
            {
                var index = RandomNumberGenerator.GetInt32(0, password.Length);
                var charIndex = RandomNumberGenerator.GetInt32(0, specialCharacters.Length);

                password = password.Insert(index, specialCharacters[charIndex].ToString());
            }
        }

        return password;
    }
}