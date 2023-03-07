using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using TicTacToe.Models;
using TicTacToe.Data.Interfaces;
using System.Linq;

namespace TicTacToe.Data.Classes
{
    public class TicsTacsCollection : ITicsTacsCollection
    {
        public string Symbol { get; private set; } = "x";
        public readonly string _connectionString;
        private readonly IDbConnection dbConnection;

        public TicsTacsCollection(string connectionString)
        {
            _connectionString = connectionString;
            dbConnection = new NpgsqlConnection(_connectionString);
        }

        public async Task<IEnumerable<Symbol>> GetAllAsync()
        {
            IEnumerable<Symbol> symbols;
            symbols = await dbConnection.QueryAsync<Symbol>("SELECT id,  symbol as Text, x_coord as X,  y_coord as Y FROM Symbols ORDER BY Id DESC");
            return symbols;
        }
        public async Task<Symbol> GetAsync(long id)
        {
            Symbol symbol;
            symbol = await dbConnection.QueryFirstOrDefaultAsync<Symbol>("SELECT * FROM Symbols WHERE Id=@id", new { Id = id });
            return symbol;
        }

        public async Task CreateAsync(Symbol symbol)
        {
            await dbConnection.ExecuteAsync("INSERT INTO Symbols (Symbol, X_Coord, Y_Coord, Is_Placed) VALUES(@Symbol, @X_Coord, @Y_Coord, @Is_Placed);", new { Symbol = symbol.Text, X_Coord = symbol.X, Y_Coord = symbol.Y, Is_Placed = symbol.IsPlaced });
        }

        public async Task<Symbol> GetLastAsync()
        {
            Symbol symbol;
            symbol = await dbConnection.QueryFirstOrDefaultAsync<Symbol>("SELECT symbol as Text, x_coord as X,  y_coord as Y FROM Symbols ORDER BY Id DESC LIMIT 1;");
            return symbol;
        }

        public async Task<int> GetCountAsync()
        {
            int countOfSigns = await dbConnection.QueryFirstAsync<int>("SELECT COUNT(*) FROM Symbols");
            return countOfSigns;
        }

        public async Task<IEnumerable<Symbol>> GetListOfSymbolsAsync(int limit = 9)
        {
            return await dbConnection.QueryAsync<Symbol>($"SELECT symbol as Text, x_coord as X,  y_coord as Y, is_placed as IsPlaced FROM Symbols ORDER BY Id DESC LIMIT {limit}");
        }
    }
}