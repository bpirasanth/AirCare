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
    [Table("Schedule")]
    public class Schedule : IIdentifier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PathId { get; set; }
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public int SeatCount { get; set; }

        [ForeignKey("PathId")]
        public virtual Path Path { get; set; }

        [ForeignKey("FlightId")]
        public virtual Flight Flight { get; set; }
    }
}
