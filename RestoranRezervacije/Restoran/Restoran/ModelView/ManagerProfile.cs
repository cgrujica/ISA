using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran.Models;

namespace Restoran.ModelView
{
    public class ManagerProfile
    {
        public MENADZER menadzer { get; set; }
        public RESTORAN restoran { get; set; }
        public List<JELOVNIK> jelovnici { get; set; }
    }
}