using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Joker.IdentityServer4.Client.WebUI.Models
{
    public class Model
    {
        public string TokenResponse { get; set; }
        public string ApiErrorStatusCode { get; set; }
        public string DiscoveryError { get; set; }
        public string RequestTokenError { get; internal set; }
        public string ApiResponseContent { get; internal set; }
    }
}
