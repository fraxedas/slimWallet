using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using slimWallet.Contracts;

namespace slimWallet.Model
{
    public class CardModel : ObservableObject
    {
        public static CardModel Current => _current ?? (_current = new CardModel());

        private static CardModel _current;

        ObservableCollection<Card> _list;

        public ObservableCollection<Card> List
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        Card _selected;

        public Card Selected
        {
            get
            {
                return _selected;
            }

            set
            {
                _selected = value;
                RaisePropertyChanged();
            }
        }

        private CardModel()
        {
            List = new ObservableCollection<Card>();
        }

        public void Save(Card card)
        {
            if(!List.Contains(card))
                List.Add(card);
        }

        public void Remove(Card card)
        {
            if (List.Contains(card)) 
                List.Remove(card);
        }
    }
}