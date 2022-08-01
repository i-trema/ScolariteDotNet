namespace AspWebProjet.Models
{
    public class UnitePedagogique
    {
        public int Id { get; set; }
        public string Intitule { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }

    }
}