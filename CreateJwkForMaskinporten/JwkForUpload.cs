using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateJwkForMaskinporten
{
    public class JwksForUpload
    {
        public List<JwkForUpload> keys { get; set; } = new List<JwkForUpload>();
    }
    public class JwkForUpload
    {
        public string kty { get; set; } = string.Empty;
        public string e { get; set; } = string.Empty;
        public string use { get; set; } = string.Empty;
        public string kid { get; set; } = string.Empty;
        public string alg { get; set; } = string.Empty;
        public string n { get; set; } = string.Empty;
    }
}
