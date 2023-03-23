using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Demo;

public class CertificateDemo
{

    // 我有两个文件，ca.crt是私有CA证书，app.crt是使用ca.crt签发的应用证书。生成一个方法验证app.crt签发者是有效的。
    public static bool VerifyCertificateIssuer(string appCrtPath, string caCrtPath)
    {
        X509Certificate2 appCrt = new X509Certificate2(appCrtPath);
        X509Certificate2 caCrt = new X509Certificate2(caCrtPath);

        X509Chain chain = new X509Chain();
        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        chain.ChainPolicy.ExtraStore.Add(caCrt);
        chain.Build(appCrt);

        foreach (X509ChainElement element in chain.ChainElements)
        {
            if (element.Certificate.Thumbprint == caCrt.Thumbprint)
            {
                return true;
            }
        }

        return false;
    }

    // 我有三个文件，ca.crt是私有CA证书，app.crt是使用ca.crt签发的应用证书，logo.png是数据文件。
    // 生成两个方法，一是生成logo.png的文件签名，二是验证logo.png的签名。并生成这两个方法的测试代码
    // 生成logo.png的文件签名
    public static byte[] GenerateFileSignature(string filePath, string privateKeyPath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        X509Certificate2 privateKey = new X509Certificate2(privateKeyPath);

        var rsa = privateKey.GetRSAPrivateKey();
        var signatureBytes = rsa.SignData(fileData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
      
        // Convert the signature bytes to a base64 string
        var signatureString = Convert.ToBase64String(signatureBytes);

        // Output the signature string
        Console.WriteLine("The signature for {0} is:", filePath);
        Console.WriteLine(signatureString);
        return signatureBytes;
    }

    // 验证logo.png的签名
    public static bool VerifyFileSignature(string filePath, byte[] signature, string publicKeyPath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        var publicKey = new X509Certificate2(publicKeyPath);
        var rsa = publicKey.GetRSAPublicKey();
        return rsa.VerifyData(fileData, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    // 生成两个方法的测试代码
    public static void TestFileSignature()
    {
        string logoPath = "./logo.png";
        string privateKeyPath = "./app.pfx";
        string publicKeyPath = "./app.crt";

        byte[] signature = GenerateFileSignature(logoPath, privateKeyPath);
        bool result = VerifyFileSignature(logoPath, signature, publicKeyPath);

        Console.WriteLine("File signature verification result: " + result);
    }

}
