using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajarApi.Models
{
    public class HeroesModels
    {
        public String HeroName { get; set; }
        public String HeroWorld { get; set; }
        public String Species { get; set; }

        public String NomeSpecie { get; set; }
        public String NomePlaneta { get; set; }

        

        public HeroesModels() { }

        public HeroesModels(string heroName, string heroWorld, string species, string nomeSpecie, string nomePlaneta)
        {
            this.HeroName = heroName;
            this.HeroWorld = heroWorld;
            this.NomeSpecie = nomeSpecie;
            this.Species = species;
            this.NomePlaneta = nomePlaneta;
           
        }

        public void ajustarUrlSpecie()
        {
            if(Species != null)
            {
                HeroesModels h = new HeroesModels();
                h.Species = Species.Replace("\\r\\n", "");
            }
            Species = null;
        }

    }
}