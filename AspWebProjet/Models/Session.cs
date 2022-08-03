using System.ComponentModel.DataAnnotations;

namespace AspWebProjet.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateFin { get; set; }
        public int ParcoursId { get; set; }
        public Parcours? Parcours { get; set; }

        public Utilisateur? Responsable { get; set; }

        public ICollection<Utilisateur>? Etudiants { get; set; }
    }
}
