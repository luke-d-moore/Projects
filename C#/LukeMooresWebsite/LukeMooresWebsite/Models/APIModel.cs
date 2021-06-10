using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LukeMooresWebsite.Entities;

namespace LukeMooresWebsite.Models
{
    public class APIModel
    {
        public int MaxRequestMessageCharacters 
        { 
            get { return Settings.MaxRequestCharacters(); }
        }
    }
}
