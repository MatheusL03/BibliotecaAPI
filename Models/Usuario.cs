using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaApi.Models
{
    public class Usuario
    {
        public int Id { get; set; } // Atalho para propriedade (PROP + TAB)

        public string Username { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public byte[]? Foto { get; set; }

        public double? Latitude { get; set; }

        public double? longitude { get; set; }

        public DateTime? DataAcesso { get; set; } // using System;

        public string Perfil { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [NotMapped]
        public string PasswordString { get; set; } = string.Empty;


    }
}