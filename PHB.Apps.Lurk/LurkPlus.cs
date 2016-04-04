using System.Collections.Generic;
using Goedel.Protocol;


namespace PHB.Apps.Lurk {

    public partial class KeyParameters {

        public static string[] AlgorithmIDs = {
            "NULL",
            "rsa",
            "ecdh",
            "sha256",
            "sha512",
            "aescbc128",
            "aesgcm128",
            "aescbc256",
            "aesgcm256"
            };

        public static string[] CurveIDs = {
            "p256",
            "p384",
            "p521",
            "curve25519",
            "curve448"
            };

        protected void SetKeyUses(KeyUses KeyUses) {
            if ((KeyUses & KeyUses.Encrypt) > 0) {
                Encrypt = true;
                }
            if ((KeyUses & KeyUses.Agreement) > 0) {
                Agreement = true;
                }
            if ((KeyUses & KeyUses.Signature) > 0) {
                Signature = true;
                }
            }
        }


    public enum Algorithm {
        NULL = 0,

        RSA = 1,
        ECDH = 2,

        SHA_2_256 = 3,
        SHA_2_512 = 4,

        AES_CBC_128 = 5,
        AES_GCM_128 = 6,
        AES_CBC_256 = 7,
        AES_GCM_256 = 8
        }




    public enum Curve {
        P256 = 0,
        P384 = 1,
        P521 = 2,
        Curve25519 = 3,
        Curve448 = 4
        }

    public enum KeyUses {
        Encrypt = 1,
        Agreement = 2,
        Signature = 4
        }


    partial class LurkRequest {
        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy() {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = LurkRequest.FromTagged(Text);

            return Result;
            }
        }

    partial class LurkResponse {
        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy() {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = LurkResponse.FromTagged(Text);

            return Result;
            }


        protected override void _Initialize() {
            Status = 200;
            StatusDescription = "OK";
            }
        }


    partial class ParametersRSA {

        public ParametersRSA(int KeySize, KeyUses KeyUses) {
            this.KeySize = KeySize;
            SetKeyUses(KeyUses);


            }

        }


    partial class ParametersECDH {

        public ParametersECDH(Curve Curve, KeyUses KeyUses) {
            this.Curve = KeyParameters.CurveIDs[(int) Curve];
            this.Algorithm = "cfrg";
            SetKeyUses(KeyUses);
            }

        }


    partial class Encoding {
        public Encoding(string ID, string Dictionary) {
            this.ID = ID;
            if (Dictionary != null) {
                this.Dictionary = new List<string> { Dictionary };
                }
            }
        }
    }
