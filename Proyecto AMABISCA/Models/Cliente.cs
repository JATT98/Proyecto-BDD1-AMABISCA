using System.ComponentModel.DataAnnotations;

namespace Proyecto_AMABISCA.Models
{
    public class Cliente
    {
        [Key]
        public int PRC_USUARIO { get; set; }
        public string CLIENTE { get; set; }
        public int NUM_ORDENES { get; set; }
    }
}