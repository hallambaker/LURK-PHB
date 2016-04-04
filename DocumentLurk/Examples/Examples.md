
##Service Connection

A client MAY use the Hello transaction to determine the protocol
version(s), encodings and other features that are supported.

To facilitate interoperability, a ACME service MUST support use of the
JSON encoding for the Hello transaction.


The request message takes no parameters:


~~~~
POST /.well-known/acme/HTTP/1.1
Host: example.com
Content-Length: 23

{
  "HelloRequest": {}}
~~~~


The response describes the protocol version 
(0.1) 
and the encodings 
its supports.


~~~~
HTTP/1.1 200 OK
Date: Tue 22 Mar 2016 02:02:33
Content-Length: 403

{
  "HelloResponse": {
    "Status": 200,
    "StatusDescription": "OK",
    "Version": {
      "Major": 0,
      "Minor": 1,
      "Encodings": [{
          "ID": "application/json"},
        {
          "ID": "application/json-b"},
        {
          "ID": "application/json-c",
          "Dictionary": ["MAK5Z-PEEEQ-PWT53-GRR55-MTBSF-UDVGM"]},
        {
          "ID": "application/tls-schema"}]}}}
~~~~


The reference service supports four encodings:

* JSON, The text based encoding used for these examples.

* JSON-B, A superset of the JSON encoding that includes binary
	encoding of data items.

* JSON-C, A superset of JSON-B that includes support for compression
    of tags and data items.

* TLS-Schema, An alternative binary encoding that is described by a
	schema in the notation introduced in the TLS specification. 

The JSON-C encoding provides an additional parameter
'Dictionary' that identifies the tag compression dictionaries that
the service knows. This allows the dictionary to be quoted by reference
rather than being sent in channel.

Services MAY provide additional encodings at their option.

##Creation of necessary key pairs

Key pair creation is a function reserved for the administrator. To
create a key pair, the administrator sends an authenticated request
to the service. Note that while message layer encryption MAY be used, 
it is not actually required in this case.

The request specifies the algorithm, key parameters and intended 
cryptographic uses. The following shows the complete HTTP request for 
creation of an RSA signature key with 2048 bit length:

[Yes, I know there are no authentication wrappers on the following 
messages. Just pretend they are there, OK? I have had all of two
days to work on this.]


~~~~
POST /.well-known/acme/HTTP/1.1
Host: example.com
Content-Length: 122

{
  "CreateRequest": {
    "Parameters": {
      "ParametersRSA": {
        "Signature": true,
        "KeySize": 2048}}}}
~~~~


The response is likewise authenticated and returns the private key:


~~~~
HTTP/1.1 200 OK
Date: Tue 22 Mar 2016 02:02:34
Content-Length: 612

{
  "CreateResponse": {
    "Status": 200,
    "StatusDescription": "OK",
    "KeyId": "MDZA3-4FYXN-IQPSJ-IO4RP-JTHXO-JSI66",
    "PublicKey": {
      "PublicKeyRSA": {
        "kid": "MDZA3-4FYXN-IQPSJ-IO4RP-JTHXO-JSI66",
        "n": "
qvwwCO9yIYQ7ujSCQKqd-1A-PB-cnG98Q5Qnm1DTU6pn-QdzxENyhhcCV2fFp9ZR
m27NtBCBFv_0-F8nvEhow4fQZ_ixZpHBZsoxbEV_p2cVW8aeuHZrOL917o710vct
XcRGb5u_t7rvTOciuhWVQxdBdaafgZdDEIlQ3Nzniv4KZvVP69gnTwygICWqRXgP
nK_-y12ViWApNtRq9M03czvRKk104rHN4AJirgPIBFO9lsG9Hbeb3EIOCvgSIIm2
Qhoh0Sow-HDtaf_j305yF84P9QbxPAYZvWjpkB3Um31iLEqh0s3ZqGpo8iBbmC9q
bxzzOOGKqB7WkR8kASbWAw",
        "e": "
AQAB"}}}}
~~~~


The process id repeated to create keypairs for encryption and key agreement.

Note that even though it is possible to use a key agreement algorithm
for encryption and vice versa, the use of these cryptographic primitives
in protocols is very different. Hence it is best to treat these as entirely
separate for the purposes of this protocol.

Key agreement key request (payload only)


~~~~
{
  "CreateRequest": {
    "Parameters": {
      "ParametersECDH": {
        "Agreement": true,
        "Curve": "p256",
        "Algorithm": "cfrg"}}}}
~~~~


Key agreement key response (payload only)


~~~~
{
  "CreateResponse": {
    "Status": 406,
    "StatusDescription": "Unsupported key parameter"}}
~~~~


Encryption key request (payload only)


~~~~
{
  "CreateRequest": {
    "Parameters": {
      "ParametersECDH": {
        "Agreement": true,
        "Curve": "p256",
        "Algorithm": "cfrg"}}}}
~~~~


Encryption key response (payload only)


~~~~
{
  "CreateResponse": {
    "Status": 406,
    "StatusDescription": "Unsupported key parameter"}}
~~~~


##Private key decryption

The message "This information is very secret" has been encrypted using
AES 128 in CBC mode and the session key encrypted under the encryption
key creates earlier.

To decrypt the message, the AcmeClient sends an authenticated request
that specifies the key identifer, wrapped key and encrypted
data as follows:




~~~~
POST /.well-known/acme/HTTP/1.1
Host: example.com
Content-Length: 571

{
  "DecryptRequest": {
    "KeyId": "MDM4H-5EU23-UDIGL-UL2JE-5TW43-CBSR2",
    "BulkAlg": "aescbc256",
    "Data": "
KvRaMIZEGriT9mw4VYzd683yLdbfvlpZg7L5IFXZM1c",
    "IV": "
2hToimOGS6cs_pecRHvk5Q",
    "WrappedKey": "
c9xf_ZtQ2MQZFk3KJK601a5o58w9Bk7txMaEyjp7JfG3VjtMKL1zh82k-1kAxFsy
qk7Gw-zyjcRwsvRIaqHmjybxZkvG0D1ZbqXOjOzBbixjEfpEer1GHd6koh8eoeEP
yUVHqOgEdtWbpkaoDZhV1ZvuPBZlnfOo8JEt3_YfZpQ4ZgMyvREe23m4pmBkCHGR
8ag0QVUFoSdBoV7McrhxRDfn6zzQkJblVxYcusJ-LU1tTmenfufg7RSVjtXT5DyZ
75Bgt-wiiPMwKXRaOsckXoZz2mIBISJMJrK9suQ9JfzPnfUS7lufmLw7Pq7y3mYp
7Q8BmpwiASeJlTLbadPH7Q"}}
~~~~


The service returns the decrypted message as an encrypted payload:


~~~~
HTTP/1.1 200 OK
Date: Tue 22 Mar 2016 02:02:34
Content-Length: 135

{
  "DecryptResponse": {
    "Status": 200,
    "StatusDescription": "OK",
    "Value": "
VGhpcyBpbmZvcm1hdGlvbiBpcyB2ZXJ5IHNlY3JldA"}}
~~~~


[Yes, it isn't encrypted yet, patience, patience. Was Rome built in a day?]

The inner payload is:


~~~~
{
  "DecryptResponse": {
    "Status": 200,
    "StatusDescription": "OK",
    "Value": "
VGhpcyBpbmZvcm1hdGlvbiBpcyB2ZXJ5IHNlY3JldA"}}
~~~~


Alternatively, the client could send just the wrapped key for decryption
and then apply the bulk cipher locally.

##Private key Agreement

[This is not currently implemented due to lack of the necessary 
library to implement the new CFRG algorithms.]

To request a key agreement operation, the AcmeClient specifies the 
public key of the counter party and the identifier of the private
key to use. A AcmeClient MAY specify the digest algorithm and construction
mechanism to be used to convert the result of the key agreement into
a key.

Request:


Response:

##Private key signature

The AcmeClient requires the message "Very important this is not changed"
be signed under the signature key created earlier.

Request:


~~~~
{
  "SignRequest": {
    "KeyId": "MDZA3-4FYXN-IQPSJ-IO4RP-JTHXO-JSI66",
    "DigestAlg": "sha256",
    "Data": "
VmVyeSBpbXBvcnRhbnQgdGhpcyBpcyBub3QgY2hhbmdlZA"}}
~~~~


Response:

~~~~
{
  "SignResponse": {
    "Status": 200,
    "StatusDescription": "OK",
    "Value": "
LDcTcNKpoP0REbwhBiUFh3evuO-Ml5tQb1tzk_u-DNU43wbNJGAbctWpPqy913o-
VgWUNHh2rbSUey839V6Snoq75ZqIabw1wZFiosdH5GRqy7C-gyR7wpZgiLLLx0qz
5uWj80TsyOVqMUQhNknoWb9KLgLazdJlBGPQwYwYV8NEtdoj24ZYhFjViQ7ZR40r
0j1kuHJE25QaOKlzvmbVJEytz4MC-Adc24EHyiKHZpVkvT6UdZI9ELZsj7kB5CBi
0J5n2NfLheffsBFpRjptjYngI2ccNgm9ktKhEDAUux7tqZyah9xlqt6V1J9IYh3f
c_g-5vHaU-dG72Gz7Awj9Q"}}
~~~~


##Key Disposal

After a key pair is no longer required, it SHOULD be deleted. A HSM
supporting the ACME protocol SHOULD ensure that some form of secure
erase is used to assure destruction of the data.

Request:


~~~~
{
  "DisposeRequest": {
    "KeyId": "MDZA3-4FYXN-IQPSJ-IO4RP-JTHXO-JSI66"}}
~~~~


Response:

~~~~
{
  "DisposeResponse": {
    "Status": 200,
    "StatusDescription": "OK"}}
~~~~



