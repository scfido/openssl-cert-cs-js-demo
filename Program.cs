// See https://aka.ms/new-console-template for more information
using Demo;

Console.WriteLine("Hello, World!");
// Test.SignFile();
Console.WriteLine(CertificateDemo.VerifyCertificateIssuer("./app.crt", "ca.crt"));
CertificateDemo.TestFileSignature();

