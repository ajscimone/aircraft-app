using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AircraftApi.Models.Domain
{
    public class AircraftManufacturer
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
