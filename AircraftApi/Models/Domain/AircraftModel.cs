using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AircraftApi.Models.Domain
{
    public class AircraftModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int AircraftManufacturerId { get; set; }

        public required AircraftManufacturer AircraftManufacturer { get; set; }
    }
}
