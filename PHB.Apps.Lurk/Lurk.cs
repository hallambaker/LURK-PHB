
//  Copyright (c) 2014 by .
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  //Header
// With all fields as properties

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;




using Goedel.Cryptography.Jose;


namespace PHB.Apps.Lurk {


    /// <summary>
    /// 
    /// </summary>
	public abstract partial class Lurk : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "Lurk";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public Lurk () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public Lurk (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public Lurk (string _String) {
			Deserialize (_String);
			_Initialize () ;
			}

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "LurkRequest" : {
					var Result = new LurkRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "LurkKeyRequest" : {
					var Result = new LurkKeyRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "LurkResponse" : {
					var Result = new LurkResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Version" : {
					var Result = new Version ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Encoding" : {
					var Result = new Encoding ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "KeyParameters" : {
					var Result = new KeyParameters ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ParametersRSA" : {
					var Result = new ParametersRSA ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ParametersDH" : {
					var Result = new ParametersDH ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ParametersECDH" : {
					var Result = new ParametersECDH ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "HelloRequest" : {
					var Result = new HelloRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "HelloResponse" : {
					var Result = new HelloResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "CreateRequest" : {
					var Result = new CreateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "CreateResponse" : {
					var Result = new CreateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DisposeRequest" : {
					var Result = new DisposeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DisposeResponse" : {
					var Result = new DisposeResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignRequest" : {
					var Result = new SignRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignResponse" : {
					var Result = new SignResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "AgreeRequest" : {
					var Result = new AgreeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "AgreeResponse" : {
					var Result = new AgreeResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DecryptRequest" : {
					var Result = new DecryptRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DecryptResponse" : {
					var Result = new DecryptResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}	
			JSONReader.EndObject ();
            }
		}



		// Service Dispatch Classes


    /// <summary>
	/// The new base class for the client and service side APIs.
    /// </summary>		
    public abstract partial class LurkService : Goedel.Protocol.JPCInterface {
		
        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "lurk";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown {
			get {return WellKnown;}
			}

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_lurk._tcp";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetDiscovery {
			get {return Discovery;}
			}

		JPCSession _JPCSession;

        /// <summary>
        /// The active JPCSession.
        /// </summary>		
		public virtual JPCSession JPCSession {
			get {return _JPCSession;}
			set {_JPCSession = value;}
			}


        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual HelloResponse Hello (
                HelloRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual CreateResponse Create (
                CreateRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual DisposeResponse Dispose (
                DisposeRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual SignResponse Sign (
                SignRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual AgreeResponse Agree (
                AgreeRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual DecryptResponse Decrypt (
                DecryptRequest Request) {
            return null;
            }

        }

    /// <summary>
	/// Client class for LurkService.
    /// </summary>		
    public partial class LurkServiceClient : LurkService {
 		
		JPCRemoteSession JPCRemoteSession;
        /// <summary>
        /// The active JPCSession.
        /// </summary>		
		public override JPCSession JPCSession {
			get {return JPCRemoteSession;}
			set {JPCRemoteSession = value as JPCRemoteSession; }
			}


        /// <summary>
		/// Create a client connection to the specified service.
        /// </summary>	
		public LurkServiceClient (JPCRemoteSession JPCRemoteSession) {
			this.JPCRemoteSession = JPCRemoteSession;
			}


        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override HelloResponse Hello (
                HelloRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Hello", Request);
            var Response = HelloResponse.FromTagged(ResponseData);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override CreateResponse Create (
                CreateRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Create", Request);
            var Response = CreateResponse.FromTagged(ResponseData);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override DisposeResponse Dispose (
                DisposeRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Dispose", Request);
            var Response = DisposeResponse.FromTagged(ResponseData);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override SignResponse Sign (
                SignRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Sign", Request);
            var Response = SignResponse.FromTagged(ResponseData);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override AgreeResponse Agree (
                AgreeRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Agree", Request);
            var Response = AgreeResponse.FromTagged(ResponseData);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override DecryptResponse Decrypt (
                DecryptRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Decrypt", Request);
            var Response = DecryptResponse.FromTagged(ResponseData);

            return Response;
            }

		}


    /// <summary>
	/// Client class for LurkService.
    /// </summary>		
    public partial class LurkServiceProvider : Goedel.Protocol.JPCProvider {

		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public LurkService Service;


		/// <summary>
		/// Dispatch object request in specified authentication context.
		/// </summary>			
        /// <param name="Session">The client context.</param>
        /// <param name="JSONReader">Reader for data object.</param>
        /// <returns>The response object returned by the corresponding dispatch.</returns>
		public override Goedel.Protocol.JSONObject Dispatch(JPCSession  Session,  
								Goedel.Protocol.JSONReader JSONReader) {

			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			JSONObject Response = null;

			switch (token) {
				case "Hello" : {
					var Request = HelloRequest.FromTagged (JSONReader);
					Response = Service.Hello (Request);
					break;
					}
				case "Create" : {
					var Request = CreateRequest.FromTagged (JSONReader);
					Response = Service.Create (Request);
					break;
					}
				case "Dispose" : {
					var Request = DisposeRequest.FromTagged (JSONReader);
					Response = Service.Dispose (Request);
					break;
					}
				case "Sign" : {
					var Request = SignRequest.FromTagged (JSONReader);
					Response = Service.Sign (Request);
					break;
					}
				case "Agree" : {
					var Request = AgreeRequest.FromTagged (JSONReader);
					Response = Service.Agree (Request);
					break;
					}
				case "Decrypt" : {
					var Request = DecryptRequest.FromTagged (JSONReader);
					Response = Service.Decrypt (Request);
					break;
					}
				default : {
					throw new Goedel.Protocol.UnknownOperation ();
					}
				}
			JSONReader.EndObject ();
			return Response;
			}

		}





		// Transaction Classes
	/// <summary>
	///
	/// Base class for all request messages.
	/// </summary>
	public partial class LurkRequest : Goedel.Protocol.Request {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "LurkRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public LurkRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public LurkRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public LurkRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Goedel.Protocol.Request)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new LurkRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new LurkRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new LurkRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "LurkRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new LurkRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "LurkRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new LurkRequest FromTagged (string _Input) {
			//LurkRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new LurkRequest  FromTagged (JSONReader JSONReader) {
			LurkRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "LurkRequest" : {
					var Result = new LurkRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "LurkKeyRequest" : {
					var Result = new LurkKeyRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CreateRequest" : {
					var Result = new CreateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DisposeRequest" : {
					var Result = new DisposeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignRequest" : {
					var Result = new SignRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AgreeRequest" : {
					var Result = new AgreeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DecryptRequest" : {
					var Result = new DecryptRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "HelloRequest" : {
					var Result = new HelloRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Base class for all key request messages.
	/// </summary>
	public partial class LurkKeyRequest : LurkRequest {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "LurkKeyRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public LurkKeyRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public LurkKeyRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public LurkKeyRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new LurkKeyRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new LurkKeyRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new LurkKeyRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "LurkKeyRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new LurkKeyRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "LurkKeyRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new LurkKeyRequest FromTagged (string _Input) {
			//LurkKeyRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new LurkKeyRequest  FromTagged (JSONReader JSONReader) {
			LurkKeyRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "LurkKeyRequest" : {
					var Result = new LurkKeyRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CreateRequest" : {
					var Result = new CreateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DisposeRequest" : {
					var Result = new DisposeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignRequest" : {
					var Result = new SignRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AgreeRequest" : {
					var Result = new AgreeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DecryptRequest" : {
					var Result = new DecryptRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Base class for all responses. Contains only the
	/// status code and status description fields.
	/// A service MAY return either the response message specified
	/// for that transaction or any parent of that message. 
	/// Thus the LurkResponse message MAY be returned in response 
	/// to any request.
	/// </summary>
	public partial class LurkResponse : Goedel.Protocol.Response {
		bool								__Status = false;
		private int						_Status;
        /// <summary>
        /// 
        /// </summary>
		public virtual int						Status {
			get {return _Status;}
			set {_Status = value; __Status = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public virtual string						StatusDescription {
			get {return _StatusDescription;}			
			set {_StatusDescription = value;}
			}
		string						_StatusDescription ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "LurkResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public LurkResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public LurkResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public LurkResponse (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Goedel.Protocol.Response)this).SerializeX(_Writer, false, ref _first);
			if (__Status){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Status", 1);
					_Writer.WriteInteger32 (Status);
				}
			if (StatusDescription != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("StatusDescription", 1);
					_Writer.WriteString (StatusDescription);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new LurkResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new LurkResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new LurkResponse (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "LurkResponse" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new LurkResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "LurkResponse" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new LurkResponse FromTagged (string _Input) {
			//LurkResponse _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new LurkResponse  FromTagged (JSONReader JSONReader) {
			LurkResponse Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "LurkResponse" : {
					var Result = new LurkResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "HelloResponse" : {
					var Result = new HelloResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CreateResponse" : {
					var Result = new CreateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DisposeResponse" : {
					var Result = new DisposeResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignResponse" : {
					var Result = new SignResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AgreeResponse" : {
					var Result = new AgreeResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DecryptResponse" : {
					var Result = new DecryptResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Status" : {
					Status = JSONReader.ReadInteger32 ();
					break;
					}
				case "StatusDescription" : {
					StatusDescription = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes a protocol version.
	/// </summary>
	public partial class Version : Lurk {
		bool								__Major = false;
		private int						_Major;
        /// <summary>
        /// 
        /// </summary>
		public virtual int						Major {
			get {return _Major;}
			set {_Major = value; __Major = true; }
			}
		bool								__Minor = false;
		private int						_Minor;
        /// <summary>
        /// 
        /// </summary>
		public virtual int						Minor {
			get {return _Minor;}
			set {_Minor = value; __Minor = true; }
			}
		/// <summary>
        /// 
        /// </summary>
		public virtual List<Encoding>				Encodings {
			get {return _Encodings;}			
			set {_Encodings = value;}
			}
		List<Encoding>				_Encodings;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				URI {
			get {return _URI;}			
			set {_URI = value;}
			}
		List<string>				_URI;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Version";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Version () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Version (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (__Major){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Major", 1);
					_Writer.WriteInteger32 (Major);
				}
			if (__Minor){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Minor", 1);
					_Writer.WriteInteger32 (Minor);
				}
			if (Encodings != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Encodings", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Encodings) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (URI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("URI", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in URI) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Version From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Version From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Version (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Version" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Version FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Version" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Version FromTagged (string _Input) {
			//Version _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Version  FromTagged (JSONReader JSONReader) {
			Version Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Version" : {
					var Result = new Version ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Major" : {
					Major = JSONReader.ReadInteger32 ();
					break;
					}
				case "Minor" : {
					Minor = JSONReader.ReadInteger32 ();
					break;
					}
				case "Encodings" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Encodings = new List <Encoding> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new Encoding (JSONReader);
						Encodings.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "URI" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					URI = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						URI.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes a message content encoding.
	/// </summary>
	public partial class Encoding : Lurk {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						ID {
			get {return _ID;}			
			set {_ID = value;}
			}
		string						_ID ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				Dictionary {
			get {return _Dictionary;}			
			set {_Dictionary = value;}
			}
		List<string>				_Dictionary;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Encoding";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Encoding () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Encoding (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (ID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ID", 1);
					_Writer.WriteString (ID);
				}
			if (Dictionary != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Dictionary", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Dictionary) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Encoding From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Encoding From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Encoding (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Encoding" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Encoding FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Encoding" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Encoding FromTagged (string _Input) {
			//Encoding _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Encoding  FromTagged (JSONReader JSONReader) {
			Encoding Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Encoding" : {
					var Result = new Encoding ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ID" : {
					ID = JSONReader.ReadString ();
					break;
					}
				case "Dictionary" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Dictionary = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Dictionary.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Specifies a cryptographic algorithm and related parameters. Note
	/// that while the parameters structures allows a key to be specified
	/// that supports multiple operations each key SHOULD only specify 
	/// exactly one operation.
	/// </summary>
	public partial class KeyParameters : Lurk {
		bool								__Encrypt = false;
		private bool						_Encrypt;
        /// <summary>
        /// 
        /// </summary>
		public virtual bool						Encrypt {
			get {return _Encrypt;}
			set {_Encrypt = value; __Encrypt = true; }
			}
		bool								__Agreement = false;
		private bool						_Agreement;
        /// <summary>
        /// 
        /// </summary>
		public virtual bool						Agreement {
			get {return _Agreement;}
			set {_Agreement = value; __Agreement = true; }
			}
		bool								__Signature = false;
		private bool						_Signature;
        /// <summary>
        /// 
        /// </summary>
		public virtual bool						Signature {
			get {return _Signature;}
			set {_Signature = value; __Signature = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Uses {
			get {return _Uses;}			
			set {_Uses = value;}
			}
		string						_Uses ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "KeyParameters";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public KeyParameters () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public KeyParameters (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (__Encrypt){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Encrypt", 1);
					_Writer.WriteBoolean (Encrypt);
				}
			if (__Agreement){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Agreement", 1);
					_Writer.WriteBoolean (Agreement);
				}
			if (__Signature){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Signature", 1);
					_Writer.WriteBoolean (Signature);
				}
			if (Uses != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Uses", 1);
					_Writer.WriteString (Uses);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new KeyParameters From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new KeyParameters From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new KeyParameters (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "KeyParameters" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new KeyParameters FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "KeyParameters" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new KeyParameters FromTagged (string _Input) {
			//KeyParameters _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new KeyParameters  FromTagged (JSONReader JSONReader) {
			KeyParameters Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "KeyParameters" : {
					var Result = new KeyParameters ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ParametersRSA" : {
					var Result = new ParametersRSA ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ParametersDH" : {
					var Result = new ParametersDH ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ParametersECDH" : {
					var Result = new ParametersECDH ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Encrypt" : {
					Encrypt = JSONReader.ReadBoolean ();
					break;
					}
				case "Agreement" : {
					Agreement = JSONReader.ReadBoolean ();
					break;
					}
				case "Signature" : {
					Signature = JSONReader.ReadBoolean ();
					break;
					}
				case "Uses" : {
					Uses = JSONReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes parameters for the RSA algorithm
	/// </summary>
	public partial class ParametersRSA : KeyParameters {
		bool								__KeySize = false;
		private int						_KeySize;
        /// <summary>
        /// 
        /// </summary>
		public virtual int						KeySize {
			get {return _KeySize;}
			set {_KeySize = value; __KeySize = true; }
			}
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				Padding {
			get {return _Padding;}			
			set {_Padding = value;}
			}
		List<string>				_Padding;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ParametersRSA";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ParametersRSA () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ParametersRSA (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((KeyParameters)this).SerializeX(_Writer, false, ref _first);
			if (__KeySize){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeySize", 1);
					_Writer.WriteInteger32 (KeySize);
				}
			if (Padding != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Padding", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Padding) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ParametersRSA From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ParametersRSA From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ParametersRSA (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ParametersRSA" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ParametersRSA FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ParametersRSA" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ParametersRSA FromTagged (string _Input) {
			//ParametersRSA _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new ParametersRSA  FromTagged (JSONReader JSONReader) {
			ParametersRSA Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ParametersRSA" : {
					var Result = new ParametersRSA ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeySize" : {
					KeySize = JSONReader.ReadInteger32 ();
					break;
					}
				case "Padding" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Padding = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Padding.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Specifies parameters for the Diffie Hellman algorithm. These are the 
	/// prime and the generator which may be specified by name (for known IETF
	/// defined curves) or by the parameters.
	/// </summary>
	public partial class ParametersDH : KeyParameters {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Curve {
			get {return _Curve;}			
			set {_Curve = value;}
			}
		string						_Curve ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Prime {
			get {return _Prime;}			
			set {_Prime = value;}
			}
		byte[]						_Prime ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Generator {
			get {return _Generator;}			
			set {_Generator = value;}
			}
		byte[]						_Generator ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ParametersDH";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ParametersDH () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ParametersDH (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((KeyParameters)this).SerializeX(_Writer, false, ref _first);
			if (Curve != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Curve", 1);
					_Writer.WriteString (Curve);
				}
			if (Prime != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Prime", 1);
					_Writer.WriteBinary (Prime);
				}
			if (Generator != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Generator", 1);
					_Writer.WriteBinary (Generator);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ParametersDH From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ParametersDH From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ParametersDH (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ParametersDH" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ParametersDH FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ParametersDH" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ParametersDH FromTagged (string _Input) {
			//ParametersDH _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new ParametersDH  FromTagged (JSONReader JSONReader) {
			ParametersDH Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ParametersDH" : {
					var Result = new ParametersDH ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Curve" : {
					Curve = JSONReader.ReadString ();
					break;
					}
				case "Prime" : {
					Prime = JSONReader.ReadBinary ();
					break;
					}
				case "Generator" : {
					Generator = JSONReader.ReadBinary ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Specifies parameters for Elliptic Curve Diffie Hellman algorithm
	/// </summary>
	public partial class ParametersECDH : KeyParameters {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Curve {
			get {return _Curve;}			
			set {_Curve = value;}
			}
		string						_Curve ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Algorithm {
			get {return _Algorithm;}			
			set {_Algorithm = value;}
			}
		string						_Algorithm ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ParametersECDH";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ParametersECDH () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ParametersECDH (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((KeyParameters)this).SerializeX(_Writer, false, ref _first);
			if (Curve != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Curve", 1);
					_Writer.WriteString (Curve);
				}
			if (Algorithm != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Algorithm", 1);
					_Writer.WriteString (Algorithm);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ParametersECDH From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ParametersECDH From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ParametersECDH (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ParametersECDH" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ParametersECDH FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ParametersECDH" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ParametersECDH FromTagged (string _Input) {
			//ParametersECDH _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new ParametersECDH  FromTagged (JSONReader JSONReader) {
			ParametersECDH Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ParametersECDH" : {
					var Result = new ParametersECDH ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Curve" : {
					Curve = JSONReader.ReadString ();
					break;
					}
				case "Algorithm" : {
					Algorithm = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class HelloRequest : LurkRequest {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "HelloRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public HelloRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public HelloRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public HelloRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new HelloRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new HelloRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new HelloRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "HelloRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new HelloRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "HelloRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new HelloRequest FromTagged (string _Input) {
			//HelloRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new HelloRequest  FromTagged (JSONReader JSONReader) {
			HelloRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "HelloRequest" : {
					var Result = new HelloRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Always reports success. Describes the configuration of the Mesh
	/// portal service.
	/// </summary>
	public partial class HelloResponse : LurkResponse {
        /// <summary>
        /// 
        /// </summary>
		public virtual Version						Version {
			get {return _Version;}			
			set {_Version = value;}
			}
		Version						_Version ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<Version>				Alternates {
			get {return _Alternates;}			
			set {_Alternates = value;}
			}
		List<Version>				_Alternates;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "HelloResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public HelloResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public HelloResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public HelloResponse (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkResponse)this).SerializeX(_Writer, false, ref _first);
			if (Version != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Version", 1);
					Version.Serialize (_Writer, false);
				}
			if (Alternates != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Alternates", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Alternates) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new HelloResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new HelloResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new HelloResponse (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "HelloResponse" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new HelloResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "HelloResponse" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new HelloResponse FromTagged (string _Input) {
			//HelloResponse _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new HelloResponse  FromTagged (JSONReader JSONReader) {
			HelloResponse Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "HelloResponse" : {
					var Result = new HelloResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Version" : {
					// An untagged structure
					Version = new Version (JSONReader);
 
					break;
					}
				case "Alternates" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Alternates = new List <Version> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new Version (JSONReader);
						Alternates.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Request creation of a new key pair
	/// </summary>
	public partial class CreateRequest : LurkKeyRequest {
        /// <summary>
        /// 
        /// </summary>
		public virtual KeyParameters						Parameters {
			get {return _Parameters;}			
			set {_Parameters = value;}
			}
		KeyParameters						_Parameters ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "CreateRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public CreateRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public CreateRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public CreateRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkKeyRequest)this).SerializeX(_Writer, false, ref _first);
			if (Parameters != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Parameters", 1);
					// expand this to a tagged structure
					//Parameters.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Parameters.Tag(), 1);
						bool firstinner = true;
						Parameters.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new CreateRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new CreateRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new CreateRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "CreateRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new CreateRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "CreateRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new CreateRequest FromTagged (string _Input) {
			//CreateRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new CreateRequest  FromTagged (JSONReader JSONReader) {
			CreateRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "CreateRequest" : {
					var Result = new CreateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Parameters" : {
					Parameters = KeyParameters.FromTagged (JSONReader) ;  // A tagged structure
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Returns the identifier of a key pair
	/// </summary>
	public partial class CreateResponse : LurkResponse {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						KeyId {
			get {return _KeyId;}			
			set {_KeyId = value;}
			}
		string						_KeyId ;
        /// <summary>
        /// 
        /// </summary>
		public virtual Key						PublicKey {
			get {return _PublicKey;}			
			set {_PublicKey = value;}
			}
		Key						_PublicKey ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "CreateResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public CreateResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public CreateResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public CreateResponse (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkResponse)this).SerializeX(_Writer, false, ref _first);
			if (KeyId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyId", 1);
					_Writer.WriteString (KeyId);
				}
			if (PublicKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PublicKey", 1);
					// expand this to a tagged structure
					//PublicKey.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(PublicKey.Tag(), 1);
						bool firstinner = true;
						PublicKey.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new CreateResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new CreateResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new CreateResponse (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "CreateResponse" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new CreateResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "CreateResponse" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new CreateResponse FromTagged (string _Input) {
			//CreateResponse _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new CreateResponse  FromTagged (JSONReader JSONReader) {
			CreateResponse Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "CreateResponse" : {
					var Result = new CreateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyId" : {
					KeyId = JSONReader.ReadString ();
					break;
					}
				case "PublicKey" : {
					PublicKey = Key.FromTagged (JSONReader) ;  // A tagged structure
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Request creation of a new key pair
	/// </summary>
	public partial class DisposeRequest : LurkKeyRequest {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						KeyId {
			get {return _KeyId;}			
			set {_KeyId = value;}
			}
		string						_KeyId ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DisposeRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DisposeRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public DisposeRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public DisposeRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkKeyRequest)this).SerializeX(_Writer, false, ref _first);
			if (KeyId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyId", 1);
					_Writer.WriteString (KeyId);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DisposeRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DisposeRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DisposeRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DisposeRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DisposeRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DisposeRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DisposeRequest FromTagged (string _Input) {
			//DisposeRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new DisposeRequest  FromTagged (JSONReader JSONReader) {
			DisposeRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "DisposeRequest" : {
					var Result = new DisposeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyId" : {
					KeyId = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports result of an attempt to dispose of a key pair.
	/// </summary>
	public partial class DisposeResponse : LurkResponse {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DisposeResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DisposeResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public DisposeResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public DisposeResponse (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkResponse)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DisposeResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DisposeResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DisposeResponse (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DisposeResponse" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DisposeResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DisposeResponse" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DisposeResponse FromTagged (string _Input) {
			//DisposeResponse _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new DisposeResponse  FromTagged (JSONReader JSONReader) {
			DisposeResponse Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "DisposeResponse" : {
					var Result = new DisposeResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describe the data to be signed
	/// </summary>
	public partial class SignRequest : LurkKeyRequest {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						KeyId {
			get {return _KeyId;}			
			set {_KeyId = value;}
			}
		string						_KeyId ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						DigestAlg {
			get {return _DigestAlg;}			
			set {_DigestAlg = value;}
			}
		string						_DigestAlg ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Data {
			get {return _Data;}			
			set {_Data = value;}
			}
		byte[]						_Data ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Digest {
			get {return _Digest;}			
			set {_Digest = value;}
			}
		byte[]						_Digest ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public SignRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public SignRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkKeyRequest)this).SerializeX(_Writer, false, ref _first);
			if (KeyId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyId", 1);
					_Writer.WriteString (KeyId);
				}
			if (DigestAlg != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DigestAlg", 1);
					_Writer.WriteString (DigestAlg);
				}
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
				}
			if (Digest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Digest", 1);
					_Writer.WriteBinary (Digest);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignRequest FromTagged (string _Input) {
			//SignRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignRequest  FromTagged (JSONReader JSONReader) {
			SignRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignRequest" : {
					var Result = new SignRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyId" : {
					KeyId = JSONReader.ReadString ();
					break;
					}
				case "DigestAlg" : {
					DigestAlg = JSONReader.ReadString ();
					break;
					}
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				case "Digest" : {
					Digest = JSONReader.ReadBinary ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Returns the signature response.
	/// </summary>
	public partial class SignResponse : LurkResponse {
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Value {
			get {return _Value;}			
			set {_Value = value;}
			}
		byte[]						_Value ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public SignResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public SignResponse (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkResponse)this).SerializeX(_Writer, false, ref _first);
			if (Value != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Value", 1);
					_Writer.WriteBinary (Value);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignResponse (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignResponse" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignResponse" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignResponse FromTagged (string _Input) {
			//SignResponse _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignResponse  FromTagged (JSONReader JSONReader) {
			SignResponse Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignResponse" : {
					var Result = new SignResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Value" : {
					Value = JSONReader.ReadBinary ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Specify the key agreement parameters.
	/// </summary>
	public partial class AgreeRequest : LurkKeyRequest {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						KeyId {
			get {return _KeyId;}			
			set {_KeyId = value;}
			}
		string						_KeyId ;
        /// <summary>
        /// 
        /// </summary>
		public virtual Key						Public {
			get {return _Public;}			
			set {_Public = value;}
			}
		Key						_Public ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "AgreeRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public AgreeRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public AgreeRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public AgreeRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkKeyRequest)this).SerializeX(_Writer, false, ref _first);
			if (KeyId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyId", 1);
					_Writer.WriteString (KeyId);
				}
			if (Public != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Public", 1);
					// expand this to a tagged structure
					//Public.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Public.Tag(), 1);
						bool firstinner = true;
						Public.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new AgreeRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new AgreeRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new AgreeRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "AgreeRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new AgreeRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "AgreeRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new AgreeRequest FromTagged (string _Input) {
			//AgreeRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new AgreeRequest  FromTagged (JSONReader JSONReader) {
			AgreeRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "AgreeRequest" : {
					var Result = new AgreeRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyId" : {
					KeyId = JSONReader.ReadString ();
					break;
					}
				case "Public" : {
					Public = Key.FromTagged (JSONReader) ;  // A tagged structure
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Returns the result of the key agreement
	/// </summary>
	public partial class AgreeResponse : LurkResponse {
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Value {
			get {return _Value;}			
			set {_Value = value;}
			}
		byte[]						_Value ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "AgreeResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public AgreeResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public AgreeResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public AgreeResponse (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkResponse)this).SerializeX(_Writer, false, ref _first);
			if (Value != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Value", 1);
					_Writer.WriteBinary (Value);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new AgreeResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new AgreeResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new AgreeResponse (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "AgreeResponse" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new AgreeResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "AgreeResponse" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new AgreeResponse FromTagged (string _Input) {
			//AgreeResponse _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new AgreeResponse  FromTagged (JSONReader JSONReader) {
			AgreeResponse Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "AgreeResponse" : {
					var Result = new AgreeResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Value" : {
					Value = JSONReader.ReadBinary ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Request a decryption operation.
	/// </summary>
	public partial class DecryptRequest : LurkKeyRequest {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						KeyId {
			get {return _KeyId;}			
			set {_KeyId = value;}
			}
		string						_KeyId ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						BulkAlg {
			get {return _BulkAlg;}			
			set {_BulkAlg = value;}
			}
		string						_BulkAlg ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Data {
			get {return _Data;}			
			set {_Data = value;}
			}
		byte[]						_Data ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						IV {
			get {return _IV;}			
			set {_IV = value;}
			}
		byte[]						_IV ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						WrappedKey {
			get {return _WrappedKey;}			
			set {_WrappedKey = value;}
			}
		byte[]						_WrappedKey ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DecryptRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DecryptRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public DecryptRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public DecryptRequest (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkKeyRequest)this).SerializeX(_Writer, false, ref _first);
			if (KeyId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyId", 1);
					_Writer.WriteString (KeyId);
				}
			if (BulkAlg != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("BulkAlg", 1);
					_Writer.WriteString (BulkAlg);
				}
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
				}
			if (IV != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("IV", 1);
					_Writer.WriteBinary (IV);
				}
			if (WrappedKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("WrappedKey", 1);
					_Writer.WriteBinary (WrappedKey);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DecryptRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DecryptRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DecryptRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DecryptRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DecryptRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DecryptRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DecryptRequest FromTagged (string _Input) {
			//DecryptRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new DecryptRequest  FromTagged (JSONReader JSONReader) {
			DecryptRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "DecryptRequest" : {
					var Result = new DecryptRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyId" : {
					KeyId = JSONReader.ReadString ();
					break;
					}
				case "BulkAlg" : {
					BulkAlg = JSONReader.ReadString ();
					break;
					}
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				case "IV" : {
					IV = JSONReader.ReadBinary ();
					break;
					}
				case "WrappedKey" : {
					WrappedKey = JSONReader.ReadBinary ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Returns the result of the decryption request
	/// </summary>
	public partial class DecryptResponse : LurkResponse {
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Value {
			get {return _Value;}			
			set {_Value = value;}
			}
		byte[]						_Value ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DecryptResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DecryptResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public DecryptResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public DecryptResponse (string _String) {
			Deserialize (_String);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((LurkResponse)this).SerializeX(_Writer, false, ref _first);
			if (Value != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Value", 1);
					_Writer.WriteBinary (Value);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DecryptResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DecryptResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DecryptResponse (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DecryptResponse" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DecryptResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DecryptResponse" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DecryptResponse FromTagged (string _Input) {
			//DecryptResponse _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new DecryptResponse  FromTagged (JSONReader JSONReader) {
			DecryptResponse Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "DecryptResponse" : {
					var Result = new DecryptResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Value" : {
					Value = JSONReader.ReadBinary ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

