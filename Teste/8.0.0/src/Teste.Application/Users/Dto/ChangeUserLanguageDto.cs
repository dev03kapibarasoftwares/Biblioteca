using System.ComponentModel.DataAnnotations;

namespace Teste.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}