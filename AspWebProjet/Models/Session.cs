namespace AspWebProjet.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        public DateTime Date { get; set; }
        public int ParcoursId { get; set; }
        public Parcours? Parcours { get; set; }

        public Utilisateur Responsable { get; set; }


    }
}
