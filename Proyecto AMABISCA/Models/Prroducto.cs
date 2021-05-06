using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_AMABISCA.Models
{
    public class Prroducto
    {
        [Key]
        public int COD_PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public int VENTAS { get; set; }
        public decimal PRECIO_UNITARIO { get; set; }
        public decimal TOTAL { get; set; }
    }
}