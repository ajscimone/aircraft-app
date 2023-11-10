using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AircraftApi.Models.Domain
{
    public class Aircraft
    {
        public int Id { get; set; }
        public required string SerialNumber { get; set; }
        public required string TailNumber { get; set; }
        public int AircraftModelId { get; set; }

        public required AircraftModel AircraftModel { get; set; }
    }
}
