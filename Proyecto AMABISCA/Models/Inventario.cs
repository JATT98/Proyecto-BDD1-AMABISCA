using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_AMABISCA.Models
{
    public class Inventario
    {
        [Key]
        public int COD_PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public int EXISTENCIAS { get; set; }
        public int BAJAS { get; set; }
        public int ALTAS { get; set; }
    }
}