using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoBusTestTask.Models
{
    [Index(nameof(ShortUrl), IsUnique = true)]
    public class Url
    {
        public Guid Id { get; set; }
        [Url, Required]
        public string OriginalUrl { get; set; }
        [Required]
        public string ShortUrl { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
        public int RedirectCount { get; set; }
    }
}
