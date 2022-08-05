using System.ComponentModel.DataAnnotations;

namespace AspWebProjet.Models
{
    public class Panier
    {
        [Key]
        public string UtilisateurEmail { get; set; }

        public IList<Module>? Modules { get; set; }
    }
}
