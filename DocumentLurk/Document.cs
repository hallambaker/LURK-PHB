// #using System.Text 
using  System.Text;
// #using PHB.Apps.Lurk 
using  PHB.Apps.Lurk;
// #using Goedel.Protocol 
using  Goedel.Protocol;
// #pclass DocumentLurk ExampleGenerator 
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace DocumentLurk {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {
		public ExampleGenerator () : base () {
			}
		public ExampleGenerator (TextWriter Output) : base (Output) {
			}

		//  
		// #method MakeVersion int Ignore 
		

		//
		// MakeVersion
		//
		public void MakeVersion (int Ignore) {
			//  
			_Output.Write ("\n{0}", _Indent);
			// namespace InternetDrafts { 
			_Output.Write ("namespace InternetDrafts {{\n{0}", _Indent);
			//     class Version { 
			_Output.Write ("    class Version {{\n{0}", _Indent);
			//         } 
			_Output.Write ("        }}\n{0}", _Indent);
			//     } 
			_Output.Write ("    }}\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		//  
		//  
		// #method LurkExamples CreateExamples Example 
		

		//
		// LurkExamples
		//
		public void LurkExamples (CreateExamples Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Service Connection 
			_Output.Write ("##Service Connection\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A client MAY use the Hello transaction to determine the protocol 
			_Output.Write ("A client MAY use the Hello transaction to determine the protocol\n{0}", _Indent);
			// version(s), encodings and other features that are supported. 
			_Output.Write ("version(s), encodings and other features that are supported.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To facilitate interoperability, a LURK service MUST support use of the 
			_Output.Write ("To facilitate interoperability, a LURK service MUST support use of the\n{0}", _Indent);
			// JSON encoding for the Hello transaction. 
			_Output.Write ("JSON encoding for the Hello transaction.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% var Point = Example.Traces.Get (Example.LabelHello); 
			 var Point = Example.Traces.Get (Example.LabelHello);
			// #% Example.Traces.Level = 0; 
			 Example.Traces.Level = 0;
			//  
			_Output.Write ("\n{0}", _Indent);
			// The request message takes no parameters: 
			_Output.Write ("The request message takes no parameters:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The response describes the protocol version  
			_Output.Write ("The response describes the protocol version \n{0}", _Indent);
			// (#{Example.HelloResponse.Version.Major}.#{Example.HelloResponse.Version.Minor})  
			_Output.Write ("({1}.{2}) \n{0}", _Indent, Example.HelloResponse.Version.Major, Example.HelloResponse.Version.Minor);
			// and the encodings  
			_Output.Write ("and the encodings \n{0}", _Indent);
			// its supports. 
			_Output.Write ("its supports.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The reference service supports four encodings: 
			_Output.Write ("The reference service supports four encodings:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * JSON, The text based encoding used for these examples. 
			_Output.Write ("* JSON, The text based encoding used for these examples.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * JSON-B, A superset of the JSON encoding that includes binary 
			_Output.Write ("* JSON-B, A superset of the JSON encoding that includes binary\n{0}", _Indent);
			// 	encoding of data items. 
			_Output.Write ("	encoding of data items.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * JSON-C, A superset of JSON-B that includes support for compression 
			_Output.Write ("* JSON-C, A superset of JSON-B that includes support for compression\n{0}", _Indent);
			//     of tags and data items. 
			_Output.Write ("    of tags and data items.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * TLS-Schema, An alternative binary encoding that is described by a 
			_Output.Write ("* TLS-Schema, An alternative binary encoding that is described by a\n{0}", _Indent);
			// 	schema in the notation introduced in the TLS specification.  
			_Output.Write ("	schema in the notation introduced in the TLS specification. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The JSON-C encoding provides an additional parameter 
			_Output.Write ("The JSON-C encoding provides an additional parameter\n{0}", _Indent);
			// 'Dictionary' that identifies the tag compression dictionaries that 
			_Output.Write ("'Dictionary' that identifies the tag compression dictionaries that\n{0}", _Indent);
			// the service knows. This allows the dictionary to be quoted by reference 
			_Output.Write ("the service knows. This allows the dictionary to be quoted by reference\n{0}", _Indent);
			// rather than being sent in channel. 
			_Output.Write ("rather than being sent in channel.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Services MAY provide additional encodings at their option. 
			_Output.Write ("Services MAY provide additional encodings at their option.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Creation of necessary key pairs 
			_Output.Write ("##Creation of necessary key pairs\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelCreateSign); 
			 Point = Example.Traces.Get (Example.LabelCreateSign);
			// #% Example.Traces.Level = 0; 
			 Example.Traces.Level = 0;
			//  
			_Output.Write ("\n{0}", _Indent);
			// Key pair creation is a function reserved for the administrator. To 
			_Output.Write ("Key pair creation is a function reserved for the administrator. To\n{0}", _Indent);
			// create a key pair, the administrator sends an authenticated request 
			_Output.Write ("create a key pair, the administrator sends an authenticated request\n{0}", _Indent);
			// to the service. Note that while message layer encryption MAY be used,  
			_Output.Write ("to the service. Note that while message layer encryption MAY be used, \n{0}", _Indent);
			// it is not actually required in this case. 
			_Output.Write ("it is not actually required in this case.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The request specifies the algorithm, key parameters and intended  
			_Output.Write ("The request specifies the algorithm, key parameters and intended \n{0}", _Indent);
			// cryptographic uses. The following shows the complete HTTP request for  
			_Output.Write ("cryptographic uses. The following shows the complete HTTP request for \n{0}", _Indent);
			// creation of an RSA signature key with 2048 bit length: 
			_Output.Write ("creation of an RSA signature key with 2048 bit length:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// [Yes, I know there are no authentication wrappers on the following  
			_Output.Write ("[Yes, I know there are no authentication wrappers on the following \n{0}", _Indent);
			// messages. Just pretend they are there, OK? I have had all of two 
			_Output.Write ("messages. Just pretend they are there, OK? I have had all of two\n{0}", _Indent);
			// days to work on this.] 
			_Output.Write ("days to work on this.]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The response is likewise authenticated and returns the private key: 
			_Output.Write ("The response is likewise authenticated and returns the private key:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The process id repeated to create keypairs for encryption and key agreement. 
			_Output.Write ("The process id repeated to create keypairs for encryption and key agreement.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Note that even though it is possible to use a key agreement algorithm 
			_Output.Write ("Note that even though it is possible to use a key agreement algorithm\n{0}", _Indent);
			// for encryption and vice versa, the use of these cryptographic primitives 
			_Output.Write ("for encryption and vice versa, the use of these cryptographic primitives\n{0}", _Indent);
			// in protocols is very different. Hence it is best to treat these as entirely 
			_Output.Write ("in protocols is very different. Hence it is best to treat these as entirely\n{0}", _Indent);
			// separate for the purposes of this protocol. 
			_Output.Write ("separate for the purposes of this protocol.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Key agreement key request (payload only) 
			_Output.Write ("Key agreement key request (payload only)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelCreateAgree); 
			 Point = Example.Traces.Get (Example.LabelCreateAgree);
			// #% Example.Traces.Level = 5; 
			 Example.Traces.Level = 5;
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Key agreement key response (payload only) 
			_Output.Write ("Key agreement key response (payload only)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Encryption key request (payload only) 
			_Output.Write ("Encryption key request (payload only)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelCreateAgree); 
			 Point = Example.Traces.Get (Example.LabelCreateAgree);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Encryption key response (payload only) 
			_Output.Write ("Encryption key response (payload only)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Private key decryption 
			_Output.Write ("##Private key decryption\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The message "#{Example.TestPlaintextEncrypt}" has been encrypted using 
			_Output.Write ("The message \"{1}\" has been encrypted using\n{0}", _Indent, Example.TestPlaintextEncrypt);
			// AES 128 in CBC mode and the session key encrypted under the encryption 
			_Output.Write ("AES 128 in CBC mode and the session key encrypted under the encryption\n{0}", _Indent);
			// key creates earlier. 
			_Output.Write ("key creates earlier.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To decrypt the message, the LurkClient sends an authenticated request 
			_Output.Write ("To decrypt the message, the LurkClient sends an authenticated request\n{0}", _Indent);
			// that specifies the key identifer, wrapped key and encrypted 
			_Output.Write ("that specifies the key identifer, wrapped key and encrypted\n{0}", _Indent);
			// data as follows: 
			_Output.Write ("data as follows:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelDecrypt); 
			 Point = Example.Traces.Get (Example.LabelDecrypt);
			// #% Example.Traces.Level = 0; 
			 Example.Traces.Level = 0;
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service returns the decrypted message as an encrypted payload: 
			_Output.Write ("The service returns the decrypted message as an encrypted payload:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// [Yes, it isn't encrypted yet, patience, patience. Was Rome built in a day?] 
			_Output.Write ("[Yes, it isn't encrypted yet, patience, patience. Was Rome built in a day?]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Example.Traces.Level = 5; 
			 Example.Traces.Level = 5;
			// The inner payload is: 
			_Output.Write ("The inner payload is:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alternatively, the client could send just the wrapped key for decryption 
			_Output.Write ("Alternatively, the client could send just the wrapped key for decryption\n{0}", _Indent);
			// and then apply the bulk cipher locally. 
			_Output.Write ("and then apply the bulk cipher locally.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Private key Agreement 
			_Output.Write ("##Private key Agreement\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// [This is not currently implemented due to lack of the necessary  
			_Output.Write ("[This is not currently implemented due to lack of the necessary \n{0}", _Indent);
			// library to implement the new CFRG algorithms.] 
			_Output.Write ("library to implement the new CFRG algorithms.]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To request a key agreement operation, the LurkClient specifies the  
			_Output.Write ("To request a key agreement operation, the LurkClient specifies the \n{0}", _Indent);
			// public key of the counter party and the identifier of the private 
			_Output.Write ("public key of the counter party and the identifier of the private\n{0}", _Indent);
			// key to use. A LurkClient MAY specify the digest algorithm and construction 
			_Output.Write ("key to use. A LurkClient MAY specify the digest algorithm and construction\n{0}", _Indent);
			// mechanism to be used to convert the result of the key agreement into 
			_Output.Write ("mechanism to be used to convert the result of the key agreement into\n{0}", _Indent);
			// a key. 
			_Output.Write ("a key.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Request: 
			_Output.Write ("Request:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #!% Point = Example.Traces.Get (Example.LabelAgree); 
			// #!{Point.Messages[0].String()} 
			//  
			_Output.Write ("\n{0}", _Indent);
			// Response: 
			_Output.Write ("Response:\n{0}", _Indent);
			// #!{Point.Messages[1].String()} 
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Private key signature 
			_Output.Write ("##Private key signature\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The LurkClient requires the message "#{Example.TestDataSign}" 
			_Output.Write ("The LurkClient requires the message \"{1}\"\n{0}", _Indent, Example.TestDataSign);
			// be signed under the signature key created earlier. 
			_Output.Write ("be signed under the signature key created earlier.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Request: 
			_Output.Write ("Request:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Example.Traces.Level = 5; 
			 Example.Traces.Level = 5;
			// #% Point = Example.Traces.Get (Example.LabelSign); 
			 Point = Example.Traces.Get (Example.LabelSign);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Response: 
			_Output.Write ("Response:\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Key Disposal 
			_Output.Write ("##Key Disposal\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// After a key pair is no longer required, it SHOULD be deleted. A HSM 
			_Output.Write ("After a key pair is no longer required, it SHOULD be deleted. A HSM\n{0}", _Indent);
			// supporting the LURK protocol SHOULD ensure that some form of secure 
			_Output.Write ("supporting the LURK protocol SHOULD ensure that some form of secure\n{0}", _Indent);
			// erase is used to assure destruction of the data. 
			_Output.Write ("erase is used to assure destruction of the data.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Request: 
			_Output.Write ("Request:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelDispose); 
			 Point = Example.Traces.Get (Example.LabelDispose);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Response: 
			_Output.Write ("Response:\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		//  
		// #end pclass 
		}
	}
// #end using 
