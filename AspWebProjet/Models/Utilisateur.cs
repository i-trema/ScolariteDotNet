using System.ComponentModel.DataAnnotations;

namespace AspWebProjet.Models
{
    public class Utilisateur
    {
        [Key]
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string? Adresse { get; set; }
        public DateTime? DateDeNaissance { get; set; }

        public string? CV { get; set; }
        public Role Role { get; set; }
    }
}
