using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Concrete;

namespace PasswordController;

public static class ConfigureController
{
    public static void AddEndpoints(this WebApplication? app)
    {
        if (app == default)
            throw new ArgumentNullException(nameof(app));

        app.MapGet("generate", (int length, bool specialChars) =>
        {
            return Results.Ok(PasswordGenerator.Generate(length, specialChars));
        })
        .WithName("Generate Password");

        app.MapPost("save", ([FromServices] IAesEncryption aesEncryption, string domain, string username, string password) =>
        {
            var encrypt = aesEncryption.Encrypt(password);
            var decrypt = aesEncryption.Decrypt(encrypt);

            return Results.Ok($"Encrypted: {encrypt}{Environment.NewLine}Decrypted: {decrypt}");
        })
        .WithName("Save Password");
    }
}