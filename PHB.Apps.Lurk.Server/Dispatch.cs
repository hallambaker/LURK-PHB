using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.LibCrypto;
using Jose=Goedel.Cryptography.Jose;
using System.Security.Cryptography;
using PHB.Apps.Lurk;

namespace PHB.Apps.Lurk.Server {
    /// <summary>
    /// The host class. Receives a stream from the HTTP server caller and 
    /// dispatches the specified server.
    /// </summary>
    public class PublicLurkServiceProvider : LurkServiceProvider {

        /// <summary>
        /// Initialize a Lurk Service Provider.
        /// </summary>
        public PublicLurkServiceProvider(string Domain, string MeshStore, string PortalStore) {
            }


        }


    /// <summary>
    /// The session class implements the Mesh session.
    /// </summary>
    public class PublicLurkService : LurkService {
        PublicLurkServiceProvider Provider;

        Dictionary<string, CryptoProviderAsymmetric> ProviderDictionary;


        /// <summary>
        /// The mesh service dispatcher.
        /// </summary>
        /// <param name="Host">The service provider.</param>
        /// <param name="Session">The authentication context.</param>
        public PublicLurkService(PublicLurkServiceProvider Host, JPCSession Session) {
            this.Provider = Host;
            Host.Interfaces.Add(this);
            Host.Service = this;


            ProviderDictionary = new Dictionary<string, CryptoProviderAsymmetric> ();
            //this.JPCSession = Session;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public override HelloResponse Hello(
                HelloRequest Request) {
            var Response = new HelloResponse();

            var Version = new Version();
            Response.Version = Version;
            Version.Major = 0;
            Version.Minor = 1;
            Version.Encodings = new List<Encoding>();
            Version.Encodings.Add(new Encoding("application/json", null));
            Version.Encodings.Add(new Encoding("application/json-b", null));
            Version.Encodings.Add(new Encoding("application/json-c", 
                "MAK5Z-PEEEQ-PWT53-GRR55-MTBSF-UDVGM"));
            Version.Encodings.Add(new Encoding("application/tls-schema", null));

            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public override CreateResponse Create(
                CreateRequest Request) {
            var Response = new CreateResponse();

            CryptoAlgorithmID CryptoAlgorithmID = CryptoAlgorithmID.NULL;
            var ParametersRSA = Request.Parameters as ParametersRSA;
            var ParametersECDH = Request.Parameters as ParametersECDH;

            if (ParametersRSA != null) {
                if (ParametersRSA.KeySize == 2048) {
                    if (ParametersRSA.Encrypt) {
                        CryptoAlgorithmID = CryptoAlgorithmID.RSAExch2048;
                        }
                    else if (ParametersRSA.Signature) {
                        CryptoAlgorithmID = CryptoAlgorithmID.RSASign2048;
                        }
                    }
                else if (ParametersRSA.KeySize == 4096) {
                    if (ParametersRSA.Encrypt) {
                        CryptoAlgorithmID = CryptoAlgorithmID.RSAExch4096;
                        }
                    else if (ParametersRSA.Signature) {
                        CryptoAlgorithmID = CryptoAlgorithmID.RSASign4096;
                        }
                    }
                }
            else if (false & ParametersECDH != null) {
                if (ParametersECDH.Curve == ParametersECDH.CurveIDs[(int)Curve.P256]) {
                    if (ParametersECDH.Agreement) {
                        CryptoAlgorithmID = CryptoAlgorithmID.ECDH_P256;
                        }
                    else if (ParametersECDH.Signature) {
                        CryptoAlgorithmID = CryptoAlgorithmID.ECDSA_P256;
                        }
                    }
                else if (ParametersECDH.Curve == ParametersECDH.CurveIDs[(int)Curve.P384]) {
                    if (ParametersECDH.Agreement) {
                        CryptoAlgorithmID = CryptoAlgorithmID.ECDH_P384;
                        }
                    else if (ParametersECDH.Signature) {
                        CryptoAlgorithmID = CryptoAlgorithmID.ECDSA_P384;
                        }
                    }
                else if (ParametersECDH.Curve == ParametersECDH.CurveIDs[(int)Curve.P521]) {
                    if (ParametersECDH.Agreement) {
                        CryptoAlgorithmID = CryptoAlgorithmID.ECDH_P521;
                        }
                    else if (ParametersECDH.Signature) {
                        CryptoAlgorithmID = CryptoAlgorithmID.ECDSA_P521;
                        }
                    }
                }


            if (CryptoAlgorithmID == CryptoAlgorithmID.NULL)  {
                Response.Status = 406;
                Response.StatusDescription = "Unsupported key parameter";
                return Response;
                }


            var CryptoProvider = CryptoCatalog.Default.GetAsymmetric
                        (CryptoAlgorithmID);

            // For the purposes of demonstration, only generate ephemeral keys.
            // This is of course something to change in a production service !!!
            CryptoProvider.Generate(KeySecurity.Ephemeral);
            Add(CryptoProvider);

            Response.PublicKey = Jose.Key.GetPublic(CryptoProvider.KeyPair);
            Response.KeyId = CryptoProvider.UDF;

            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public override DisposeResponse Dispose(
                DisposeRequest Request) {
            var Response = new DisposeResponse();

            // Ignore for now, all keys are ephemeral

            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public override SignResponse Sign(
                SignRequest Request) {
            var Response = new SignResponse();

            var Provider = Find(Request.KeyId) as CryptoProviderSignature;

            CryptoAlgorithmID CryptoAlgorithmID = CryptoAlgorithmID.NULL;
            string OID = null;
            if (Request.DigestAlg == KeyParameters.AlgorithmIDs[
                        (int)Algorithm.SHA_2_256]) {
                CryptoAlgorithmID = CryptoAlgorithmID.SHA_2_256;
                OID = CryptoConfig.MapNameToOID("SHA256");
                }
            else if (Request.DigestAlg == KeyParameters.AlgorithmIDs[
                        (int)Algorithm.SHA_2_512]) {
                CryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512;
                OID = CryptoConfig.MapNameToOID("SHA512");
                }

            if (Request.Data != null) {
                var CryptoData = Provider.Sign(Request.Data);
                Response.Value = CryptoData.Integrity;

                return Response;
                }

            var CryptoInput = new CryptoData(CryptoAlgorithmID, OID, Request.Digest);


            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public override AgreeResponse Agree(
                AgreeRequest Request) {
            var Response = new AgreeResponse();
            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public override DecryptResponse Decrypt(
                DecryptRequest Request) {
            var Response = new DecryptResponse();

            var Provider = Find(Request.KeyId) as CryptoProviderExchange;

            var SymmetricKey = Provider.Decrypt(Request.WrappedKey);

            if (Request.Data == null) {
                Response.Value = SymmetricKey;
                return Response;
                }

            var BulkEncryptor = new CryptoProviderEncryptAES(128);
            var CryptoData = new CryptoData();
            CryptoData.IV = Request.IV;
            CryptoData.Key = SymmetricKey;

            var BulkData = BulkEncryptor.Decrypt(CryptoData, Request.Data);
            Response.Value = BulkData.Data;

            return Response;
            }


        /// <summary>
        /// Enroll a key in the key dictionary. This is simply
        /// an ephemeral dictionary at present.
        /// </summary>
        /// <param name="Provider">Key to enroll.</param>
        void Add(CryptoProviderAsymmetric Provider) {
            ProviderDictionary.Add(Provider.UDF, Provider);
            }

        /// <summary>
        /// Retrieve a key from the key dictionary.
        /// </summary>
        /// <param name="KeyId">UDF identifier of the key to find</param>
        /// <returns>Key if found, otherwise, null.</returns>
        CryptoProviderAsymmetric Find(string KeyId) {
            CryptoProviderAsymmetric Result;

            ProviderDictionary.TryGetValue(KeyId, out Result);
            return Result;
            }


        }
    }
