using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiRuleta.Core.Models
{
    [Table("roulette")]
    public class Roulette
    {
        [Key]
        [Column("id_roulette")]
        public long IDRoulette { get; set; }
        [Column("name")]
         public string Name { get; set; }
        [Column("status_roulette")]
        public bool StatusRoulette { get; set; }
        [Column("fhcreation")]
        public DateTime FHCreation { get; set; }
    }
}
