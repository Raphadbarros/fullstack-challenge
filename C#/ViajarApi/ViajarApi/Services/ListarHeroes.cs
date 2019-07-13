using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using ViajarApi.Models;

namespace ViajarApi.Services
{
    public class ListarHeroes : ListarHeroesInterface
    {
        public string BaseUrl
        {
            get
            {
                return "https://swapi.co/api/";
            }
        }

        public List<HeroesModels> getHeroes()
        {
            List<HeroesModels> heroeslists = new List<HeroesModels>();


            for (int cont = 1; cont < 10; cont++)
            {
                string pag = string.Format("people/?page=" + cont);

                HttpRequestMessage requests = new HttpRequestMessage(HttpMethod.Get, BaseUrl + pag);

                HttpResponseMessage responses = HttpInstance.GetHttpClientInstance().SendAsync(requests).Result;

                JsonConvert.SerializeObject(responses, new JsonSerializerSettings { Formatting = Formatting.None });

                JArray heroesJsonPeople = (JArray)JObject.Parse(responses.Content.ReadAsStringAsync().Result)["results"];

                if (cont < 11)
                {
                    foreach (var heroesJsons in heroesJsonPeople)
                    {
                        heroeslists.Add(new HeroesModels() { HeroName = heroesJsons["name"].ToString(), HeroWorld = heroesJsons["homeworld"].ToString(), Species = heroesJsons["species"].ToString() });
                    }                    
    
                }


            }

            // Ajusta url Heroes propriedade Species
            heroeslists.ForEach(c => c.Species = c.Species.Replace("[\r\n  \"", "").Replace("\r\n]", "").Replace("\"", ""));
            
                
            List<SpeciesModels> specieslists = new List<SpeciesModels>();
            List<PlanetsModels> planetslists = new List<PlanetsModels>();
            planetslists = getplanets().ToList();
            specieslists = getspecies().ToList();


            var HeroesporSpecies = from h in heroeslists
                                   join p in planetslists
                                   on h.HeroWorld equals p.WorldUrl
                                   join s in specieslists
                                   on h.Species equals s.SpecieUrl
                                   select new { h.HeroName, p.PlanetName, s.SpecieName };


            List< HeroesModels > returnList = new List<HeroesModels>();
            foreach (var item in HeroesporSpecies)
            {
                HeroesModels temp = new HeroesModels();
                temp.HeroName = item.HeroName;
                temp.NomePlaneta = item.PlanetName;
                temp.NomeSpecie = item.SpecieName;

                returnList.Add(temp);
            }

            return returnList;
            
        }

        
        public List<SpeciesModels> getspecies()
        {
            List<SpeciesModels> specieslists = new List<SpeciesModels>();

            for (int cont = 1; cont < 5; cont++)
            {
                string pag = string.Format("species/?page=" + cont);

                HttpRequestMessage requestspecies = new HttpRequestMessage(HttpMethod.Get, BaseUrl + pag);

                HttpResponseMessage responsespecies = HttpInstance.GetHttpClientInstance().SendAsync(requestspecies).Result;
                
                JArray heroesJsonspecies = (JArray)JObject.Parse(responsespecies.Content.ReadAsStringAsync().Result)["results"];
                if (cont < 5)
                {
                    foreach (var speciesJsons in heroesJsonspecies)
                    {
                        specieslists.Add(new SpeciesModels() { SpecieName = speciesJsons["name"].ToString(), SpecieWorldUrl = speciesJsons["homeworld"].ToString(), SpecieUrl = speciesJsons["url"].ToString() });
                    }
                }
            }
            return specieslists;
        }


        public List<PlanetsModels> getplanets()
        {

            List<PlanetsModels> planetslists = new List<PlanetsModels>();
            
            for (int cont = 1; cont < 8; cont++)
            {
                string pag = string.Format("planets/?page=" + cont);

                HttpRequestMessage requestplanets = new HttpRequestMessage(HttpMethod.Get, BaseUrl + pag);

                HttpResponseMessage responseplanets = HttpInstance.GetHttpClientInstance().SendAsync(requestplanets).Result;

               

                JArray heroesJsonPlanets = (JArray)JObject.Parse(responseplanets.Content.ReadAsStringAsync().Result)["results"];
                if (cont < 8)
                {
                    foreach (var planetsJsons in heroesJsonPlanets)
                    {
                        planetslists.Add(new PlanetsModels() { PlanetName = planetsJsons["name"].ToString(), WorldUrl = planetsJsons["url"].ToString() });
                    }
                }

                
            }

            return planetslists;
        }

    }
}