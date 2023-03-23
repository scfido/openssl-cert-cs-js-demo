using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Demo;

public class Test
{

    public static void SignFile()
    {
        string publicKey = "app.crt";
        string data = "Hello world";
        X509Certificate2 privateKey = new X509Certificate2("./app.pfx");

        var rsa = privateKey.GetRSAPrivateKey();
        var signatureBytes = rsa.SignData(Encoding.UTF8.GetBytes(data), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        // Convert the signature bytes to a base64 string
        var signatureString = Convert.ToBase64String(signatureBytes);

        // Output the signature string
        Console.WriteLine(signatureString);
    }
}