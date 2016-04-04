using System;
using System.Collections.Generic;
using PHB.Apps.Lurk;
using PHB.Apps.Lurk.Server;
using PHB.Apps.Lurk.Client;
using Jose=Goedel.Cryptography.Jose;

namespace PHB.Apps.Lurk.Client {
    public class LurkClient {

        /// <summary>
        /// The MeshProtocol Service provider.
        /// </summary>
        protected LurkService LurkService;

        /// <summary>
        /// The portal address.
        /// </summary>
        public string Portal;

        /// <summary>
        /// Connect up to the specified Mesh Portal
        /// </summary>
        public LurkClient(string Portal) {
            this.Portal = Portal;
            LurkService = LurkPortal.Default.GetService(Portal);
            }

        public HelloResponse Hello() {
            var Request = new HelloRequest();
            return LurkService.Hello(Request);
            }


        /// <summary>
        /// Create a new RSA Key Pair
        /// </summary>
        /// <param name="KeySize">The size of the key in bits. Valid values are 2048, 4096 
        /// and other values as supported by the service.</param>
        /// <param name="KeyUses">The key uses. This should only be one use but 
        /// multiple uses may be specified.</param>
        /// <returns></returns>
        public CreateResponse CreateKeyRSA(int KeySize, KeyUses KeyUses) {

            var Request = new CreateRequest();
            Request.Parameters = new ParametersRSA(KeySize, KeyUses);

            return LurkService.Create(Request);
            }

        /// <summary>
        /// Create a new Elliptic Curve Diffie Hellman Key Pair.
        /// </summary>
        /// <param name="Curve">The curve to use</param>
        /// <returns></returns>
        public CreateResponse CreateKeyDH(Curve Curve, KeyUses KeyUses) {

            var Request = new CreateRequest();
            Request.Parameters = new ParametersECDH(Curve, KeyUses);

            return LurkService.Create(Request);
            }

        /// <summary>
        /// Dispose of a key pairwith the specified identifier.
        /// </summary>
        /// <param name="KeyId">The key to dispose</param>
        /// <returns>The response returned by the service.</returns>
        public DisposeResponse Dispose(string KeyId) {

            var Request = new DisposeRequest();
            Request.KeyId = KeyId;

            return LurkService.Dispose(Request);
            }


        /// <summary>
        /// Sign a data string. NB the service MAY set a limit 
        /// on the size of data item it will accept for signing.
        /// </summary>
        /// <param name="KeyId">The key to use</param>
        /// <param name="DigestAlg">The digest algorithm to process the data.</param>
        /// <param name="Data">The data to be signed.</param>
        /// <returns>The signature value</returns>
        public SignResponse SignData(string KeyId, Algorithm DigestAlg, byte[] Data) {

            var Request = new SignRequest();
            Request.KeyId = KeyId;
            Request.Data = Data;
            Request.DigestAlg = KeyParameters.AlgorithmIDs[(int)DigestAlg];

            return LurkService.Sign(Request);
            }

        /// <summary>
        /// Sign a digest value previously calculated over a data string. 
        /// </summary>
        /// <param name="KeyId">The key to use</param>
        /// <param name="DigestAlg">The digest algorithm used to process the data.</param>
        /// <param name="Digest">The data digest value to be signed.</param>
        /// <returns>The signature value</returns>
        public SignResponse SignDigest(string KeyId, Algorithm DigestAlg, byte[] Digest) {

            var Request = new SignRequest();
            Request.KeyId = KeyId;
            Request.Digest = Digest;
            Request.DigestAlg = KeyParameters.AlgorithmIDs[(int)DigestAlg];

            return LurkService.Sign(Request);
            }


        /// <summary>
        /// Decrypt data using private key.
        /// </summary>
        /// <param name="KeyId">The key to use</param>
        /// <param name="BulkAlg"></param>
        /// <param name="WrappedKey">The wrapped key to decrypt</param>
        /// <param name="Data"></param>
        /// <returns>The decrypted data</returns>
        public DecryptResponse DecryptData(string KeyId, Algorithm BulkAlg, 
                    byte[] WrappedKey, byte [] IV, byte[] Data) {

            var Request = new DecryptRequest();
            Request.KeyId = KeyId;
            Request.WrappedKey = WrappedKey;
            Request.Data = Data;
            Request.IV = IV;
            Request.BulkAlg = KeyParameters.AlgorithmIDs[(int)BulkAlg];

            return LurkService.Decrypt(Request);
            }

        /// <summary>
        /// Decrypt data using private key.
        /// </summary>
        /// <param name="KeyId">The key to use</param>
        /// <param name="BulkAlg"></param>
        /// <param name="WrappedKey">The wrapped key to decrypt</param>
        /// <returns>The decrypted data</returns>
        public DecryptResponse DecryptWrapped(string KeyId, Algorithm BulkAlg, byte[] WrappedKey) {

            var Request = new DecryptRequest();
            Request.KeyId = KeyId;
            Request.WrappedKey = WrappedKey;
            if (BulkAlg != Algorithm.NULL) {
                Request.BulkAlg = KeyParameters.AlgorithmIDs[(int)BulkAlg];
                }
            return LurkService.Decrypt(Request);
            }

        /// <summary>
        /// Perform key agreement
        /// </summary>
        /// <param name="KeyId">The key to use</param>
        /// <param name="Public">The counterpart public key (MUST have compatible
        /// curve, parameters, etc.)</param>
        /// <returns>The agreed value.</returns>
        public AgreeResponse Agree(string KeyId, Jose.Key Public) {

            var Request = new AgreeRequest();
            Request.KeyId = KeyId;
            Request.Public = Public;

            return LurkService.Agree(Request);
            }

        }
    }
