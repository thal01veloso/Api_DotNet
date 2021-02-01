using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControle.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("Nome")]
        public string Nome { get; set; }
        [Required]
        [Column("Email")]
        public string Email { get; set; }

        public Cliente(long id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
