

#Lurk Key Service Reference

SRV Prefix:

:_lurk._tcp

HTTP Well Known Service Prefix:

:/.well-known/lurk

The LURK key service provides access to a remote key
service. The remote service performs private key related
operations in response to authenticated requests.

##Request Messages

A LURK request payload consists of a payload object
that inherits from the LurkRequest class.

Note that the request payload is the subject of
the presentation layer authentication wrapper. Thus
the authantication wrapper is not part of the request payload.

###Message: LurkRequest

Base class for all request messages.

[None]

###Message: LurkKeyRequest

Base class for all key request messages.

* Inherits: LurkRequest

[None]

###Message: LurkResponse

Base class for all responses. Contains only the
status code and status description fields.

A service MAY return either the response message specified
for that transaction or any parent of that message. 
Thus the LurkResponse message MAY be returned in response 
to any request.


Status: Integer (Optional)

:Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

StatusDescription: String (Optional)

:Text description of the status return code for debugging 
and log file use.

###Successful Response Codes

The following response codes are returned when a
transaction has completed successfully.

201 SuccessOK
:Operation completed successfully

###Warning Response Codes

The following response codes are returned when a
transaction did not complete because the target
service has been redirected.

In the case that a redirect code is returned, the 
StatusDescription field contains the URI of the 
new service. Note however that the redirect location 
indicated in a status response might be incorrect
or even malicious and cannot be considered 
trustworthy without appropriate authentication.

303 RedirectPermanent
:Service has been permanently moved

307 RedirectTemporary
:Service has been temporarily moved

###Error Response Codes

A response code in the range 400-499 is
returned when the service was able to process the
transaction but the transaction resulted in an error.

401 ClientUnauthorized
:Client is not authorized to perform specified request

404 NotFound
:The requested object could not be found.

406 NotAcceptable
:The request asked for an operation that cannot
be supported because the server does not support 
certain parameters in the request. For example,
specific key sizes, algorithms, etc.

###Structure: Version

Describes a protocol version.


Major: Integer (Optional)

:Major version number of the service protocol. A higher

Minor: Integer (Optional)

:Minor version number of the service protocol.

Encodings: Encoding [0..Many]

:Enumerates alternative encodings (e.g. ASN.1, XML, JSON-B)
supported by the service. If no encodings are specified, the
JSON encoding is assumed.

URI: String [0..Many]

:The preferred URI for this service. This MAY be used to effect
a redirect in the case that a service moves.

###Structure: Encoding

Describes a message content encoding.


ID: String (Optional)

:The IANA encoding name

Dictionary: String [0..Many]

:For encodings that employ a named dictionary for tag or data
compression, the name of the dictionary as defined by that 
encoding scheme. 	

###Structure: KeyParameters

Specifies a cryptographic algorithm and related parameters. Note
that while the parameters structures allows a key to be specified
that supports multiple operations each key SHOULD only specify 
exactly one operation.


Encrypt: Boolean (Optional)

:Key supports encryption and decryption operations.

Agreement: Boolean (Optional)

:Key supports key agreement operations.

Signature: Boolean (Optional)

:Key Supports signature operations.

Uses: String (Optional)

:Specifies the permitted uses for the key. All the listed
uses are permitted. If present non-empty, the LURK Service 
MUST NOT permit any use not specified.

###Structure: ParametersRSA

* Inherits: KeyParameters

Describes parameters for the RSA algorithm


KeySize: Integer (Optional)

:The Key Size. Services MUST support key sizes of 2048 and 4096 bits.
Services MAY support other key sizes greater than 2048 bits.
Services MUST NOT support key sizes less than 2048 bits.

Padding: String [0..Many]

:If present, specifies the padding modes that are to be supported
by the key. 

###Structure: ParametersDH

* Inherits: KeyParameters

Specifies parameters for the Diffie Hellman algorithm. These are the 
prime and the generator which may be specified by name (for known IETF
defined curves) or by the parameters.


Curve: String (Optional)

:Specify the curve to generate a key on by name

Prime: Binary (Optional)

:Prime to use

Generator: Binary (Optional)

:Generator to use

###Structure: ParametersECDH

* Inherits: KeyParameters

Specifies parameters for Elliptic Curve Diffie Hellman algorithm


Curve: String (Optional)

:The curve name. Valid values are "Curve255" and "Curve448"

Algorithm: String (Optional)

:Specify the precise algorithm and version.

##Transaction: Hello

Request: HelloRequest

Response:HelloResponse

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

###Message: HelloRequest

* Inherits: LurkRequest

[None]

###Message: HelloResponse

Always reports success. Describes the configuration of the Mesh
portal service.

* Inherits: LurkResponse


Version: Version (Optional)

:Enumerates the protocol versions supported

Alternates: Version [0..Many]

:Enumerates alternate protocol version(s) supported

##Transaction: Create

Request: CreateRequest

Response:CreateResponse

Create a new public key pair for the specified algorithm and 
cryptographic parameters.

###Message: CreateRequest

* Inherits: LurkKeyRequest

Request creation of a new key pair

[None]

###Message: CreateResponse

* Inherits: LurkResponse

Returns the identifier of a key pair


KeyId: String (Optional)

:Unique identifier for the public key pair created
if the operation succeeded.

##Transaction: Dispose

Request: DisposeRequest

Response:DisposeResponse

Dispose of the specified key pair.

###Message: DisposeRequest

* Inherits: LurkKeyRequest

Request creation of a new key pair


KeyId: String (Optional)

:The Key to dispose.

###Message: DisposeResponse

* Inherits: LurkResponse

Reports result of an attempt to dispose of a key pair.

[None]

##Transaction: Sign

Request: SignRequest

Response:SignResponse

Request signature of a data value or digest

###Message: SignRequest

* Inherits: LurkKeyRequest

Describe the data to be signed


KeyId: String (Optional)

:The key to be used for the operation.

DigestAlg: String (Optional)

:The digest algorithm to be used.

Data: Binary (Optional)

:Data to be digested and signed.

Digest: Binary (Optional)

:Digest calculated on the data to be signed.

:This field is ignored if the Data field is present.

###Message: SignResponse

* Inherits: LurkResponse

Returns the signature response.


Value: Binary (Optional)

:The signature response value.

##Transaction: Agree

Request: AgreeRequest

Response:AgreeResponse

Perform a key agreement operation.

###Message: AgreeRequest

* Inherits: LurkKeyRequest

Specify the key agreement parameters.


KeyId: String (Optional)

:The key to be used for the operation.

###Message: AgreeResponse

* Inherits: LurkResponse

Returns the result of the key agreement


Value: Binary (Optional)

:The key agreement result

##Transaction: Decrypt

Request: DecryptRequest

Response:DecryptResponse

Perform a decryption operation.

###Message: DecryptRequest

* Inherits: LurkKeyRequest

Request a decryption operation.


KeyId: String (Optional)

:The key to be used for the operation.

BulkAlg: String (Optional)

:The bulk decryption algorithm to be used

Data: Binary (Optional)

:Data to be decrypted

IV: Binary (Optional)

:Initialization Vector. This field is ignored
unless the Data field is also specified. If
an algorithm that requires an initialization
vector is specified and this field is empty,
the leading bytes of the Data field are used.

WrappedKey: Binary (Optional)

:Wrapped key data to decrypt

###Message: DecryptResponse

* Inherits: LurkResponse

Returns the result of the decryption request


Value: Binary (Optional)

:The decrypted data

