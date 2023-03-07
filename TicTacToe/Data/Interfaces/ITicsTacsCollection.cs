using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Data.Interfaces
{
    public interface ITicsTacsCollection
    {
        public Task<IEnumerable<Symbol>> GetAllAsync();
        public Task<Symbol> GetAsync(long id);
        public Task CreateAsync(Symbol symbol);
        public Task<Symbol> GetLastAsync();
        public Task<int> GetCountAsync();
        public Task<IEnumerable<Symbol>> GetListOfSymbolsAsync(int limit = 9);

    }
}