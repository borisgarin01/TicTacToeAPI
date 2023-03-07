using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Data.Interfaces
{
    public record TicTacToUserModel
    {
        public short X { get; init; }
        public short Y { get; init; }
        public string Symbol { get; set; }
    }
}