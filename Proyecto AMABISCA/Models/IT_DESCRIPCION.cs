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
    
    public partial class IT_DESCRIPCION
    {
        public int PRC_PRODUCTO { get; set; }
        public System.DateTime PF_ESTADO { get; set; }
        public int EXISTENCIA { get; set; }
        public int CANTIDAD_BAJA { get; set; }
        public int CANTIDAD_ALTA { get; set; }
    
        public virtual PT_DESCRIPCION PT_DESCRIPCION { get; set; }
    }
}