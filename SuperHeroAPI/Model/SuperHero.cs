using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Model
{
    public class SuperHero
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = string.Empty;
        [Required]
        public string? FirstName { get; set; } = string.Empty ;
        [Required]
        public string? LastName { get; set; } = string.Empty;
        [Required]
        public string? Place { get; set; } = string.Empty;


    }
}
