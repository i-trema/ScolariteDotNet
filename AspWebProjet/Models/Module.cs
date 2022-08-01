namespace AspWebProjet.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Logo { get; set; }
        public string Resume { get; set; }
        public string Infos { get; set; }

        public int ParcoursId { get; set; }
        public Parcours? Parcours { get; set; }

        public int UnitePedagogiqueId { get; set; }
        public UnitePedagogique? UnitePedagogique { get; set; }



    }
}
