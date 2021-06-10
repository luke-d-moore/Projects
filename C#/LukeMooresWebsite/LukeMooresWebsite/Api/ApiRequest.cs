using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LukeMooresWebsite.Entities;

namespace LukeMooresWebsite.Api
{
    [Serializable]
    public class ApiRequest
    {
        public string RequestMessage { get; set; }
    }
}
