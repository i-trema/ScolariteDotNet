namespace AspWebProjet.Models
{
    public class UnitePedagogique
    {
        public int Id { get; set; }
        public string Intitule { get; set; }

        public ICollection<Module>? Modules { get; set; }

    }
}