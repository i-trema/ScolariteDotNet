﻿namespace AspWebProjet.Models
{
    public class Parcours
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Resume { get; set; }
        public string? Logo { get; set; }

        public ICollection<Module>? Modules { get; set; }
    }
}
