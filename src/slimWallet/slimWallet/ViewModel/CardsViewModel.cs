using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace slimWallet
{
    public class CardsViewModel
    {
        CardModel _model;

        public CardsViewModel()
        {
            _model = new CardModel();
            _cards = _model.List();
        }

        List<Card> _cards;

        public List<Card> Cards
        {
            get
            {
                return _cards;
            }

            set
            {
                _cards = value;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                {
                    throw new NotImplementedException();
                });
            }
        }
    }
}