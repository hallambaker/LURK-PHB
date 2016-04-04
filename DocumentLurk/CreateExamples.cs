using Goedel.Protocol.Debug;
using System.IO;
using System.Diagnostics;
using PHB.Apps.Lurk;
using PHB.Apps.Lurk.Server;
using PHB.Apps.Lurk.Client;
using Goedel.LibCrypto;
using Jose = Goedel.Cryptography.Jose;

namespace DocumentLurk {
    public class CreateExamples {
        static void Main(string[] args) {

            var Class = new CreateExamples();
            Class.Go(args[0]);
            }

        public TraceDictionary Traces;
        LurkClient LurkClient;
        LurkPortalTraced Portal;

        public static string NameService = "example.com";

        void Go(string Output) {
            StartService();
            Traces = Portal.Traces;

            // Perform the operations
            EstablishConnection();
            CreateKeys();
            Decrypt();
            Agree();
            Sign();
            CreatePartial();
            Dispose();

            // Create the examples
            using (var Writer = new StreamWriter(Output)) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.LurkExamples(this);
                }

            // Create the documentation
            MakeRFC(@"O:\Documents\IETF\", @"Publish\", "hallambaker-lurk");
            }

        void MakeRFC(string SourceDir, string DestinationDir, string File) {

            var Parameters = SourceDir + File + ".docx" +
                    " /html " + DestinationDir + File + ".html" +
                    " /xml " + DestinationDir + File + ".xml" +
                    " /txt " + DestinationDir + File + ".txt";

            var P = Process.Start("rfctool.exe", Parameters);
            P.WaitForExit();
            }




        void StartService() {
            // Create test Mesh

            Portal = new LurkPortalTraced(NameService);
            LurkPortal.Default = Portal;

            LurkClient = new LurkClient(NameService);
            }

        public string LabelHello = "Hello";
        public HelloResponse HelloResponse;
        void EstablishConnection() {

            Portal.Label(LabelHello);
            HelloResponse = LurkClient.Hello();
            }

        public Jose.Key KeySign, KeyEncrypt, KeyAgree;
        KeyPair KeyPairSign, KeyPairEncrypt, KeyPairAgree;

        public string IDSign, IDEncrypt, IDAgree;

        public string LabelCreateSign = "CreateSign";
        public string LabelCreateEncrypt = "CreateEncrypt";
        public string LabelCreateAgree = "CreateAgree";

        // In this set of code, we have two different representations of 
        // the public key:

        // Jose.Key  [KeySign, etc]
        //      This is the bits on the wire format
        // KeyPair [KeyPairSign, etc.]
        //      This is the representation used in Goedel.Libcrypto

        


        void CreateKeys() {
            Portal.Label(LabelCreateSign);
            var ResponseSign = LurkClient.CreateKeyRSA(2048, KeyUses.Signature);
            KeySign = ResponseSign.PublicKey;
            KeyPairSign = KeySign.GetKeyPair();
            IDSign = ResponseSign.KeyId;

            Portal.Label(LabelCreateEncrypt);
            var ResponseEncrypt = LurkClient.CreateKeyRSA(2048, KeyUses.Encrypt);
            KeyEncrypt = ResponseEncrypt.PublicKey;
            KeyPairEncrypt = KeyEncrypt.GetKeyPair();
            IDEncrypt = ResponseEncrypt.KeyId;

            Portal.Label(LabelCreateAgree);
            var ResponseAgree = LurkClient.CreateKeyDH(Curve.P256, KeyUses.Agreement);
            //KeyAgree = ResponseAgree.PublicKey;
            //KeyPairAgree = KeyAgree.GetKeyPair();
            //IDAgree = ResponseAgree.KeyId;
            }

        public string LabelDecrypt = "Decrypt";

        public string TestPlaintextEncrypt = "This information is very secret";
        public string TestDataSign = "Very important this is not changed";


        public byte[] EncryptCipherText;
        public byte[] EncryptIV;
        public byte[] EncryptSessionKey;
        public byte[] EncryptWrappedKey;

        /// <summary>
        /// Encrypt some data under KeyEncrypt
        /// </summary>
        void Decrypt() {
            // Prep the input string by converting to UTF8 bytes.
            var TextBytes = System.Text.Encoding.UTF8.GetBytes(TestPlaintextEncrypt);

            // Encrypt the bulk data
            var BulkEncryptor = new CryptoProviderEncryptAES(128);
            var CryptoData = BulkEncryptor.Encrypt(TextBytes);

            EncryptCipherText = CryptoData.Data;
            EncryptIV = CryptoData.IV;
            EncryptSessionKey = CryptoData.Key;

            // Add a decryption blob for the encryption key
            // Will probably need to fix up the library here

            var EncrytionProvider = KeyPairEncrypt.ExchangeProviderEncrypt;
            var CD2 = EncrytionProvider.Encrypt(CryptoData);

            EncryptWrappedKey = CD2.Data;

            // Make the request
            Portal.Label(LabelDecrypt);
            var ResponseDecrypt = LurkClient.DecryptData(IDEncrypt, Algorithm.AES_CBC_256,
                EncryptWrappedKey, EncryptIV, EncryptCipherText);
            }

        public string LabelAgree = "Agree";

        void Agree() {
            Portal.Label(LabelAgree);
            }

        public string LabelSign = "Sign";

        void Sign() {
            var TextBytes = System.Text.Encoding.UTF8.GetBytes(TestDataSign);

            Portal.Label(LabelSign);
            var ResponseSign = LurkClient.SignData(IDSign, Algorithm.SHA_2_256, TextBytes);

            }

        void CreatePartial() {
            }

        public string LabelDispose = "Dispose";
        void Dispose() {
            Portal.Label(LabelDispose);

            var ResponseDispose = LurkClient.Dispose(IDSign);
            }

        }
    }
