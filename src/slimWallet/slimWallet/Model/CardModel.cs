using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using slimWallet.Contracts;
using slimWallet.Data;

namespace slimWallet.Model
{
    public class CardModel : ObservableObject
    {
        public static CardModel Current => _current ?? (_current = new CardModel());

        private static CardModel _current;

        ObservableCollection<Card> _list;

        public ObservableCollection<Card> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private readonly Database _database;
        private readonly FileRepository _fileRepository;

        Card _selected;

        public Card Selected
        {
            get => _selected;            
            set
            {
                _selected = value;
                RaisePropertyChanged();
            }
        }

        private CardModel()
        {
            _database = new Database();
            _fileRepository = new FileRepository();
        }

        public async Task Init() {
            if (List == null) List = new ObservableCollection<Card>(await _database.GetItemsAsync());
        } 

        public async Task SaveAsync(Card card)
        {
            if(!List.Contains(card))
                List.Add(card);
            await _database.SaveItemAsync(card);
        }

        public async Task RemoveAsync(Card card)
        {
            if (Selected == card)
                Selected = null;
            if (List.Contains(card))
                List.Remove(card);
            await _database.DeleteItemAsync(card);
            if(card.FrontImage != null) await _fileRepository.DeleteAsync(card.FrontImage);
            if (card.BackImage != null) await _fileRepository.DeleteAsync(card.BackImage);
        }

        public async Task<Stream> ReadAsync(string fileName) => await _fileRepository.ReadAsync(fileName);

        public async Task SaveFileAsync(Card selected, Stream stream, bool front)
        {
            var path = await _fileRepository.SaveAsync(stream);
            stream.Dispose();

            if (front) {
                if(selected.FrontImage != null) await _fileRepository.DeleteAsync(selected.FrontImage);
                selected.FrontImage = path;
            }
            else {
                if (selected.BackImage != null) await _fileRepository.DeleteAsync(selected.FrontImage);
                selected.BackImage = path;
            }
        }
    }
}