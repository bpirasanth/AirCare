using AirCare.Model.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCare.Model.Entities
{
    [Table("Path")]
    public class Path : IIdentifier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AirportOutId { get; set; }
        public int AirportInId { get; set; }

        [ForeignKey("AirportOutId")]
        public virtual Airport AirportOut { get; set; }

        [ForeignKey("AirportInId")]
        public virtual Airport AirportIn { get; set; }


    }
}
