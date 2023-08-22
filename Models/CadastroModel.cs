using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using CadastroUsuarios.Data;
using CadastroUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarios.Models
{
    public class CadastroModel
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        [Required]
        public int CPF { get; set; }

        [Required]
        [Display(Name ="Data de nascimento")]
        [DateOfBirthAttribute(MinAge = 18, MaxAge = 99)]
        public DateTime DataNascimento { get; set; }

        [Required]
        public int Celular { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int CEP { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }
    }

    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var val = (DateTime)value ;

            if (val.AddYears(MinAge) > DateTime.Now)
                return false;

            return (val.AddYears(MaxAge) > DateTime.Now);
        }
    }
}
