using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bartender
{
    internal class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public Bartender(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider ?? throw new ArgumentNullException(nameof(inputProvider));
            _outputProvider = outputProvider ?? throw new ArgumentNullException(nameof(outputProvider));
        }
        public void AskForDrink()
        {
            _outputProvider("what drink you want to order? (beer or juice)");

            var drink = _inputProvider() ?? string.Empty;
            if(drink == "beer")
            {
                ServeBeer();

            }
            if (drink == "juice")
            {
                _outputProvider("here you go");
            }
            else
            {
                _outputProvider($"sorry we dont have {_inputProvider()}");
            }
        }

        private void ServeBeer()
        {
            _outputProvider("not so fast, what is your age?");
            if (!int.TryParse(_inputProvider(), out var age))
            {
                _outputProvider("could not verify age provided");
            }
            else
            {
                if (age < 18)
                {
                    _outputProvider("sorry your below legal age");
                }
                else
                {
                    _outputProvider("here you go champ");
                }
            }
        }
    }
}
