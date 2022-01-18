using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AareonTechnicalTest.Models
{
    public class Note
    {
        [Key]
        public int Id { get; }

        public string Description { get; set; }

        public int TicketId { get; set; }

        // Removed
        //[JsonIgnore]
        public bool isPassive { get; set; }

    }
}
