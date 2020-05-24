using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Infrastructure.SQLite.Reservation
{
    public class Reservation
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string RoomName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Note { get; set; }
    }
}