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
    
    public partial class STO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STO()
        {
            this.REZERVACIJAs = new HashSet<REZERVACIJA>();
        }
    
        public string ID_RESTORANA { get; set; }
        public string ID_STOLA { get; set; }
        public int BR_STOLICA { get; set; }
    
        public virtual RESTORAN RESTORAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REZERVACIJA> REZERVACIJAs { get; set; }
    }
}
