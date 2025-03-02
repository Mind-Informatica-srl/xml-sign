using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace FirmaXml.Services
{
    public class XmlSignerService
    {

        public string SignXml(SignRequest request)
        {
            var cert = new X509Certificate2(Convert.FromBase64String(request.Certificate), request.Password, X509KeyStorageFlags.MachineKeySet);
            var xmlDoc = new XmlDocument { PreserveWhitespace = true };
            // decodifico request.XmlContent in base64
            var xml = Convert.FromBase64String(request.XmlContent);
            xmlDoc.LoadXml(System.Text.Encoding.UTF8.GetString(xml));

            CryptoConfig.AddAlgorithm(typeof(ECDsa256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256");

            var signedXml = new SignedXml(xmlDoc)
            {
                SigningKey = cert.GetECDsaPrivateKey(),
            };
            signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256";

            var reference = new Reference { Uri = "" };
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform { });
            signedXml.AddReference(reference);

            signedXml.ComputeSignature();
            signedXml.KeyInfo.AddClause(new KeyInfoX509Data(cert.RawData));
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            xmlDoc.DocumentElement?.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            // codifica il documento in base64
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml));
        }
    }
}