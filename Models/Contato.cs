using System;
using System.ComponentModel.DataAnnotations;


namespace LojaVirtual.Models
{
    public class Contato
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email não válido")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "O campo Texto é obrigatório")]
        [MinLength(10, ErrorMessage = "O campo Texto deve ter no mínimo 10 caracteres")]
        [MaxLength(1000, ErrorMessage = "O campo Texto deve ter no máximo 1000 caracteres")]
        public string texto { get; set; }
    }
}