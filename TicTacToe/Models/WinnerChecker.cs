using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Data.Interfaces;
using TicTacToe.Models;


namespace TicTacToe
{
    public class WinnerChecker
    {
        private readonly ITicsTacsCollection _ticsTacsCollection;
        public WinnerChecker(ITicsTacsCollection ticsTacsCollection)
        {
            _ticsTacsCollection = ticsTacsCollection;
        }
        public async Task<string> CheckVinnerAsync()
        {
            IOrderedEnumerable<Symbol> symbols;

            {
                symbols = (await _ticsTacsCollection.GetListOfSymbolsAsync()).ToList().OrderByDescending(s => s.Y).ThenBy(s => s.X);
                #region Горизонтали

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 3 && (symbols.ElementAt(1).Y == 3 && symbols.ElementAt(3).Y == 3 && symbols.ElementAt(5).Y == 3
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(3).Text == "X" && symbols.ElementAt(5).Text == "X"))//Верхняя полоса
                {
                    return "Выиграли X";
                }

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 3 && (symbols.ElementAt(1).Y == 3 && symbols.ElementAt(3).Y == 3 && symbols.ElementAt(5).Y == 3
                    &&
                    symbols.ElementAt(1).Text == "Y" && symbols.ElementAt(3).Text == "Y" && symbols.ElementAt(5).Text == "Y"))//Верхняя полоса
                {
                    return "Выиграли Y";
                }

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 3 && (symbols.ElementAt(1).Y == 2 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 2
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(3).Text == "X" && symbols.ElementAt(5).Text == "X"))//Средняя полоса
                {
                    return "Выиграли X";
                }

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 3 && (symbols.ElementAt(1).Y == 2 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 2
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(3).Text == "X" && symbols.ElementAt(5).Text == "X"))//Средняя полоса
                {
                    return "Выиграли Y";
                }

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 3 && (symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 1 && symbols.ElementAt(5).Y == 1
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(3).Text == "X" && symbols.ElementAt(5).Text == "X"))//Нижняя полоса
                {
                    return "Выиграли X";
                }
                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 3 && (symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 1 && symbols.ElementAt(5).Y == 1
                    &&
                    symbols.ElementAt(1).Text == "Y" && symbols.ElementAt(3).Text == "Y" && symbols.ElementAt(5).Text == "Y"))//Нижняя полоса
                {
                    return "Выиграли Y";
                }
                #endregion

                #region Вертикали

                if (
                    symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 3 && (symbols.ElementAt(1).X == 3 && symbols.ElementAt(3).X == 3 && symbols.ElementAt(5).X == 3
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(3).Text == "X" && symbols.ElementAt(5).Text == "X"))//Правая полоса
                {
                    return "Выиграли X";
                }

                if (
                    symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 3 && (symbols.ElementAt(1).X == 3 && symbols.ElementAt(3).X == 3 && symbols.ElementAt(5).X == 3
                    &&
                    symbols.ElementAt(1).Text == "Y" && symbols.ElementAt(3).Text == "Y" && symbols.ElementAt(5).Text == "Y"))//Правая полоса
                {
                    return "Выиграли Y";
                }

                if (
                    symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 3 && (symbols.ElementAt(1).X == 2 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 2
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(3).Text == "X" && symbols.ElementAt(5).Text == "X"))//Средняя полоса
                {
                    return "Выиграли X";
                }

                if (
                    symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 3 && (symbols.ElementAt(1).X == 2 && symbols.ElementAt(3).X == 2 && symbols.ElementAt(5).X == 2
                    &&
                    symbols.ElementAt(1).Text == "Y" && symbols.ElementAt(3).Text == "Y" && symbols.ElementAt(5).Text == "Y"))//Средняя полоса
                {
                    return "Выиграли Y";
                }

                if (
                    symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 3 && (symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 1 && symbols.ElementAt(5).X == 1
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(3).Text == "X" && symbols.ElementAt(5).Text == "X"))//Левая полоса
                {
                    return "Выиграли X";
                }

                if (
                    symbols.ElementAt(1).Y == 1 && symbols.ElementAt(3).Y == 2 && symbols.ElementAt(5).Y == 3 && (symbols.ElementAt(1).X == 1 && symbols.ElementAt(3).X == 1 && symbols.ElementAt(5).X == 1
                    &&
                    symbols.ElementAt(1).Text == "Y" && symbols.ElementAt(3).Text == "Y" && symbols.ElementAt(5).Text == "Y"))//Левая полоса
                {
                    return "Выиграли Y";
                }

                #endregion

                #region Диагонали

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(5).X == 2 && symbols.ElementAt(9).X == 3 && (symbols.ElementAt(1).Y == 3 && symbols.ElementAt(5).Y == 2 && symbols.ElementAt(9).Y == 1
                    &&
                    symbols.ElementAt(1).Text == "Y" && symbols.ElementAt(5).Text == "Y" && symbols.ElementAt(9).Text == "Y"))//Диагональ слева сверху вправо вниз
                {
                    return "Выиграли Y";
                }

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(5).X == 2 && symbols.ElementAt(9).X == 3 && (symbols.ElementAt(1).Y == 3 && symbols.ElementAt(5).Y == 2 && symbols.ElementAt(9).Y == 1
                    &&
                    symbols.ElementAt(1).Text == "X" && symbols.ElementAt(5).Text == "X" && symbols.ElementAt(9).Text == "X"))//Диагональ слева сверху вправо вниз
                {
                    return "Выиграли X";
                }




                if (
                    symbols.ElementAt(7).X == 1 && symbols.ElementAt(5).X == 2 && symbols.ElementAt(3).X == 3 && (symbols.ElementAt(7).Y == 1 && symbols.ElementAt(5).Y == 2 && symbols.ElementAt(3).Y == 3
                    &&
                    symbols.ElementAt(7).Text == "X" && symbols.ElementAt(5).Text == "X" && symbols.ElementAt(3).Text == "X"))//Диагональ слева снизу право вверх
                {
                    return "Выиграли X";
                }

                if (
                    symbols.ElementAt(7).X == 1 && symbols.ElementAt(5).X == 2 && symbols.ElementAt(3).X == 3 && (symbols.ElementAt(7).Y == 1 && symbols.ElementAt(5).Y == 2 && symbols.ElementAt(3).Y == 3
                    &&
                    symbols.ElementAt(7).Text == "Y" && symbols.ElementAt(5).Text == "Y" && symbols.ElementAt(3).Text == "Y"))//Диагональ слева снизу право вверх
                {
                    return "Выиграли Y";
                }



                if (
                    symbols.ElementAt(7).X == 1 && symbols.ElementAt(5).X == 2 && symbols.ElementAt(3).X == 3 && (symbols.ElementAt(7).Y == 1 && symbols.ElementAt(5).Y == 2 && symbols.ElementAt(3).Y == 3
                    &&
                    symbols.ElementAt(7).Text == "X" && symbols.ElementAt(5).Text == "X" && symbols.ElementAt(3).Text == "X"))//Диагональ слева сверху право вниз
                {
                    return "Выиграли X";
                }

                if (
                    symbols.ElementAt(1).X == 1 && symbols.ElementAt(5).X == 2 && symbols.ElementAt(9).X == 3 && (symbols.ElementAt(7).Y == 1 && symbols.ElementAt(5).Y == 2 && symbols.ElementAt(3).Y == 3
                    &&
                    symbols.ElementAt(7).Text == "X" && symbols.ElementAt(5).Text == "X" && symbols.ElementAt(3).Text == "X"))//Диагональ слева сверху право вниз
                {
                    return "Выиграли X";
                }


                if (
                    symbols.ElementAt(7).X == 3 && symbols.ElementAt(5).X == 2 && symbols.ElementAt(3).X == 3 && (symbols.ElementAt(7).Y == 1 && symbols.ElementAt(5).Y == 2 && symbols.ElementAt(3).Y == 3
                    &&
                    symbols.ElementAt(7).Text == "Y" && symbols.ElementAt(5).Text == "Y" && symbols.ElementAt(3).Text == "Y"))//Диагональ справа сверху влево вниз
                {
                    return "Выиграли X";
                }

                #endregion

                return string.Empty;
            }
        }
    }
}