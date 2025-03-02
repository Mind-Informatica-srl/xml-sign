using System.Security.Cryptography;

public class ECDsa256SignatureDescription : SignatureDescription {
    public ECDsa256SignatureDescription() {
        KeyAlgorithm = typeof(ECDsa).AssemblyQualifiedName;
    }
    public override HashAlgorithm CreateDigest() => SHA256.Create();
    public override AsymmetricSignatureFormatter CreateFormatter(AsymmetricAlgorithm key) => new EcdsaSignatureFormatter(key as ECDsa);
}

public class EcdsaSignatureFormatter : AsymmetricSignatureFormatter {
    private ECDsa key;
    public EcdsaSignatureFormatter(ECDsa key) => this.key = key;
    public override void SetKey(AsymmetricAlgorithm key) => this.key = key as ECDsa;
    public override void SetHashAlgorithm(string strName) { }
    public override byte[] CreateSignature(byte[] rgbHash) => key.SignHash(rgbHash);
}