using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_youtube_tabelas_query_bruta.Models
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(15)]
        public string CPF { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        public string Endereco { get; set; }
    }
}
