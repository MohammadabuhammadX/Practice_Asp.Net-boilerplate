using System.ComponentModel.DataAnnotations;

namespace Practice.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}