using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
    }
}