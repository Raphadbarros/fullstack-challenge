using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajarApi.Models;

namespace ViajarApi.Services
{
    interface ListarHeroesInterface
    {
        List<HeroesModels> getHeroes();
        List<SpeciesModels> getspecies();
        List<PlanetsModels> getplanets();
    }
}
