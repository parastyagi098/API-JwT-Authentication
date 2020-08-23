using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandAuthenticateDto
    {
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}