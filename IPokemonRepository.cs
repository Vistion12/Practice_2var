using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2var
{
    public interface IPokemonRepository
    {
        void Create(Pokemon pokemon);
        Pokemon Read(int id);
        IEnumerable<Pokemon> ReadAll();
        void Update(Pokemon pokemon);
        void Delete(int id);
    }
}
