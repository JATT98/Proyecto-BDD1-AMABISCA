//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_AMABISCA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PT_CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PT_CATEGORIA()
        {
            this.PT_CATEGORIA1 = new HashSet<PT_CATEGORIA>();
            this.PT_DESCRIPCION = new HashSet<PT_DESCRIPCION>();
        }
    
        public string PC_CATEGORIA { get; set; }
        public string RC_CATEGORIA_PADRE { get; set; }
        public string NOMBRE { get; set; }
        public byte[] IMAGEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PT_CATEGORIA> PT_CATEGORIA1 { get; set; }
        public virtual PT_CATEGORIA PT_CATEGORIA2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PT_DESCRIPCION> PT_DESCRIPCION { get; set; }
    }
}
