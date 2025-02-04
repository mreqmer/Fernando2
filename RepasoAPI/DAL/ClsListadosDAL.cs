using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL
{
    public class ClsListadosDAL
    {

        private static List<ClsPokemon> ListadoPokemon = CargaPokemon();

        private static List<ClsGrupoHuevo> ListadoGrupoHuevo = CargaGrupoHuevo();

        private static List<ClsPokemon> CargaPokemon()
        {
            return new List<ClsPokemon>
            {
                new ClsPokemon(1, "Bulbasaur", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png", "Grass/Poison type starter", 1),
                new ClsPokemon(2, "Ivysaur", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/2.png", "Evolves from Bulbasaur", 1),
                new ClsPokemon(3, "Venusaur", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/3.png", "Evolves from Ivysaur", 1),
                new ClsPokemon(4, "Charmander", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png", "Fire type starter", 2),
                new ClsPokemon(5, "Charmeleon", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/5.png", "Evolves from Charmander", 2),
                new ClsPokemon(6, "Charizard", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/6.png", "Evolves from Charmeleon", 2),
                new ClsPokemon(7, "Squirtle", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png", "Water type starter", 3),
                new ClsPokemon(8, "Wartortle", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/8.png", "Evolves from Squirtle", 3),
                new ClsPokemon(9, "Blastoise", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/9.png", "Evolves from Wartortle", 3),
                new ClsPokemon(10, "Pikachu", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png", "Electric type mascot", 4),
                new ClsPokemon(11, "Raichu", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/26.png", "Evolves from Pikachu", 4),
                new ClsPokemon(12, "Jigglypuff", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/39.png", "Fairy/Normal type", 5),
                new ClsPokemon(13, "Wigglytuff", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/40.png", "Evolves from Jigglypuff", 5),
                new ClsPokemon(14, "Meowth", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/52.png", "Normal type cat", 6),
                new ClsPokemon(15, "Persian", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/53.png", "Evolves from Meowth", 6),
                new ClsPokemon(16, "Psyduck", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/54.png", "Water type duck", 7),
                new ClsPokemon(17, "Golduck", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/55.png", "Evolves from Psyduck", 7),
                new ClsPokemon(18, "Machop", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/66.png", "Fighting type", 8),
                new ClsPokemon(19, "Machoke", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/67.png", "Evolves from Machop", 8),
                new ClsPokemon(20, "Machamp", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/68.png", "Evolves from Machoke", 8)
            };
        }

        private static List<ClsGrupoHuevo> CargaGrupoHuevo()
        {
            return new List<ClsGrupoHuevo>
            {
                new ClsGrupoHuevo(1, "Monstruo"),
                new ClsGrupoHuevo(2, "Bicho"),
                new ClsGrupoHuevo(3, "Volador"),
                new ClsGrupoHuevo(4, "Campo"),
                new ClsGrupoHuevo(5, "Hada"),
                new ClsGrupoHuevo(6, "Planta"),
                new ClsGrupoHuevo(7, "Humanoide"),
                new ClsGrupoHuevo(8, "Mineral"),
                new ClsGrupoHuevo(9, "Amorfo"),
                new ClsGrupoHuevo(10, "Ditto"),
                new ClsGrupoHuevo(11, "Dragón"),
                new ClsGrupoHuevo(12, "Agua 1"),
                new ClsGrupoHuevo(13, "Agua 2"),
                new ClsGrupoHuevo(14, "Agua 3"),
                new ClsGrupoHuevo(15, "No descubierto")
            };
        }

        public static List<ClsPokemon> ObtieneListadoPokemon()
        {
            return ListadoPokemon;
        }
        public static List<ClsGrupoHuevo> ObtieneListadoGrupoHuevo()
        {
            return ListadoGrupoHuevo;
        }

        public static ClsPokemon ObtienePokemonDex(int numDex)
        {
            return ListadoPokemon.FirstOrDefault(p => p.Dex == numDex);
        }

        public static ClsPokemon ObtienePokemonNombre(string nombre)
        {
            return ListadoPokemon.FirstOrDefault(p => p.Nombre == nombre);
        }

        public static ClsGrupoHuevo ObtieneGrupoHuevoID(int idHuevo)
        {
            return ListadoGrupoHuevo.FirstOrDefault(h => h.IdHuevo == idHuevo);
        }

        public static ClsGrupoHuevo ObtieneGrupoHuevoNombre(string nombre)
        {
            return ListadoGrupoHuevo.FirstOrDefault(h => h.NombreHuevo == nombre);
        }
    
        public static bool addPokemon(ClsPokemon pokemon)
        {
            bool added = false;

            if(!ListadoPokemon.Any(p => p.Dex == pokemon.Dex)&&(!ListadoPokemon.Any(p => p.Nombre == pokemon.Nombre))){
                added = true;
                ListadoPokemon.Add(pokemon);
            }
            return added;
        }

        public static bool AddGrupoHuevo(ClsGrupoHuevo grupoHuevo)
        {
            bool added = false;

            if (!ListadoGrupoHuevo.Any(g => g.IdHuevo == grupoHuevo.IdHuevo) &&
                !ListadoGrupoHuevo.Any(g => g.NombreHuevo == grupoHuevo.NombreHuevo))
            {
                added = true;
                ListadoGrupoHuevo.Add(grupoHuevo);
            }
            return added;
        }


        public static ClsPokemon ModificaPokemon(ClsPokemon pokemon)
        {

            ClsPokemon p = new ClsPokemon();

            p = ListadoPokemon.FirstOrDefault(p => p.Dex == pokemon.Dex);

            p.Nombre = pokemon.Nombre;
            p.Foto = pokemon.Foto;
            p.Description = pokemon.Description;
            p.GrupoHuevo = pokemon.GrupoHuevo;

            return null;
        }
    }
}

