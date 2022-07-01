// See https://aka.ms/new-console-template for more information

using CreateJwkForMaskinporten;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

//Will create a new file named <kid>.json, containing the JsonWebKey. The <kid> should be supplied as parameter
//The key will have a size of 2048
//The console will output the necessary structure to copy and paste the key for upload to maskinporten integration

string kid = string.Empty;

if (args.Count() == 0)
{
    Console.WriteLine("The key id (kid) must be specified as parameter");
    return;
}

kid = args[0];

//Generate a public/private key pair.  
var provider = new RSACryptoServiceProvider(2048);
var key = new RsaSecurityKey(provider.ExportParameters(true));
var jwk = JsonWebKeyConverter.ConvertFromRSASecurityKey(key);
jwk.Kid = kid;
jwk.Use = "sig";
jwk.Alg = "RS256";

var options = new JsonSerializerOptions();
options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
options.PropertyNamingPolicy = new LowerCaseNamingPolicy();
options.WriteIndented = true;

var json = JsonSerializer.Serialize(jwk, options);

//var filename = $"{jwk.Kid}_{DateTime.Now:yyyy-MM-dd_s}.json";
var filename = $"{jwk.Kid}.json";
File.WriteAllText(filename, json);

Console.WriteLine($"RSA key created : {filename}");

var jwks = new JwksForUpload();
jwks.keys.Add(new JwkForUpload() { alg = jwk.Alg, e = jwk.E, kid = jwk.Kid, kty = jwk.Kty, n = jwk.N, use = jwk.Use });
var jsonPublicKey = JsonSerializer.Serialize<JwksForUpload>(jwks, options);

Console.WriteLine(Environment.NewLine + "Public key to upload");
Console.WriteLine(jsonPublicKey);