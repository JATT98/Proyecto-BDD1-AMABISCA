using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_AMABISCA.Models
{
    public class ViewClientes
    {
        [Key]
        public int PRC_USUARIO { get; set; }
        public string CLIENTE { get; set; }
        public int NUM_ORDENES { get; set; }
    }
}