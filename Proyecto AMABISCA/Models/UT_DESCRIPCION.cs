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
    
    public partial class UT_DESCRIPCION
    {
        public int PRC_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DNI { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public System.DateTime F_NACIMIENTO { get; set; }
        public string SEXO { get; set; }
    
        public virtual UT_CUENTA UT_CUENTA { get; set; }
    }
}
