using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran.Models;

namespace Restoran.ModelView
{
    public class Profil
    {
        [System.ComponentModel.DisplayName("Ime")]
        public string ime { get; set; }
        [System.ComponentModel.DisplayName("Prezime")]
        public string prezime { get; set; }
        [System.ComponentModel.DisplayName("Email")]
        public string email { get; set; }
        [System.ComponentModel.DisplayName("Adresa")]
        public string adresa { get; set; }

        public List<GOST> prijatelji;
    }
}