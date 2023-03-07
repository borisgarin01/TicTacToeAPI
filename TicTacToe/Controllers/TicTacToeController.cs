using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Data.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicTacToeController : ControllerBase
    {
        private readonly ITicsTacsCollection _ticsTacsCollection;
        private readonly WinnerChecker _winnerChecker;

        public string SymbolToInsert { get; set; }

        public TicTacToeController(ITicsTacsCollection ticsTacsCollection)
        {
            _ticsTacsCollection = ticsTacsCollection;
            _winnerChecker = new(_ticsTacsCollection);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ticsTacsCollection.GetAllAsync());
        }

        //2) TODO: CHECK WINNER

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            Symbol symbol = null;
            try
            {
                symbol = await _ticsTacsCollection.GetAsync(id);
                if (symbol == null)
                {
                    throw new NullReferenceException("Symbol at given id cannot be null");
                }
                else if (ModelState.IsValid)
                {
                    return Ok(new TicTacToUserModel { X = symbol.X, Y = symbol.Y, Symbol = SymbolToInsert });
                }
                return BadRequest();
            }
            catch
            {
                ModelState.AddModelError("Symbol with this id not found", "Symbol with this id not found");
                return BadRequest(symbol);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicTacToUserModel ticTacToUserModel)
        {
            int lowerLimit = 1, upperLimit = 3, leftLimit = 1, rightLimit = 3;

            if ((ticTacToUserModel.X > rightLimit ^ ticTacToUserModel.X < leftLimit) || (ticTacToUserModel.Y > upperLimit ^ ticTacToUserModel.Y < lowerLimit))
            {
                ModelState.AddModelError("Symbol isn't valid", "Symbol isn't valid");
            }

            Symbol symbol = new Symbol();
            symbol.X = ticTacToUserModel.X;
            symbol.Y = ticTacToUserModel.Y;

            if (ModelState.IsValid)
            {
                try
                {
                    Symbol ticTacToe = await _ticsTacsCollection.GetLastAsync();

                    // Console.WriteLine(ticTacToe.Text);
                    if (ticTacToe == null)
                        symbol.Text = "X";
                    else
                    {
                        if (!ticTacToe.IsPlaced)
                        {
                            if (ticTacToe.Text == "X")
                                symbol.Text = "Y";
                            else
                                symbol.Text = "X";
                            symbol.IsPlaced = true;
                            await _ticsTacsCollection.CreateAsync(symbol);
                        }
                    }



                    if (await _ticsTacsCollection.GetCountAsync() % 9 == 0)
                        await _winnerChecker.CheckVinnerAsync();

                    return Ok(symbol);
                }
                catch
                {
                    ModelState.AddModelError("Symbol with this id not found", "Symbol with this id not found");
                    return BadRequest(symbol);
                }
            }
            else
                return BadRequest();
        }
    }
}