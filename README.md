# create-jwk-for-maskinporten
Console application to create a json web key for use with maskinporten instead of "Virksomhets sertifikat".

Sometimes its not desireable or practical to use a company's "Virksomhetssertifikat". Maskinporten supports uploading of your own certificate to the integration point to be used instead. Pleade note, at time of writing, these custom uploaded keys have a lifetime of one year. 
This small application will generate a new JsonWebKey and output the data to the console. This information can be copied and pasted into the self-service portal of maskinporten.

Usage:
```
dotnet run <name of kid>
```

A file named kid.json will be generated holding the new jwk (both public and private keys) so keep it safe. The console will output the parts you need to upload to maskinporten.
The kid given during creation must be the same you specify when uploading to maskinporten.

Note: The json uploaded is a jwks, an array of jwk, and can contain up to five keys.
Once uploaded, the key you created can be used to authenticate.
