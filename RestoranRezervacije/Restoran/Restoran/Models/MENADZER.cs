//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restoran.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MENADZER
    {
        [System.ComponentModel.DisplayName("E-mail menadzera")]
        public string IDMENADZERA { get; set; }
        [System.ComponentModel.DisplayName("Ime restorana")]
        public string ID_RESTORANA { get; set; }
        [System.ComponentModel.DisplayName("Lozinka")]
        public string ASD { get; set; }
    
        public virtual RESTORAN RESTORAN { get; set; }
    }
}
