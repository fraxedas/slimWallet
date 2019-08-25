using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
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

        private ObservableCollection<Card> _list;

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
        private readonly ApiClient _api;
        private Card _selected;

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
            _api = new ApiClient();
        }

        public async Task Init()
        {
            if (List == null) List = new ObservableCollection<Card>(await _database.GetItemsAsync());
        }

        public async Task SaveAsync(Card card)
        {
            if (!List.Contains(card))
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
            if (card.Image != null) _fileRepository.Delete(card.Image);
        }

        public Stream Read(string fileName) => _fileRepository.Read(fileName);

        public async Task SaveFileAsync(Card selected, Stream stream)
        {
            var path = await _fileRepository.SaveAsync(stream);
            if (selected.Image != null) _fileRepository.Delete(selected.Image);
            selected.Image = path;
            if (selected.Thumbnail != null) _fileRepository.Delete(selected.Thumbnail);
            selected.Thumbnail = path;

        }

        public async Task Predict()
        {
            var file = _fileRepository.Read(Selected.Image);
            var result = await _api.Command<IsBlurry>(HttpMethod.Post, url: "https://prod-lp-ml-staging.azurewebsites.net/api/IsBlurry?code=UnopfPz7SPsSi8ShKiQk19MMNvmTolMp9Ypv3bLcY64aJa6omqKK0Q==", stream: file, filename: Selected.Name);
            Selected.DocumentId = result.documentId;
            Selected.PredictedBlurry = result.isBlurry;
        }

        public async Task Verify()
        {
            var data = new IsBlurry
            {
                documentId = Selected.DocumentId,
                wasItBlurry = Selected.ActualBlurry
            };
            await _api.Command<object>(HttpMethod.Post, url: "https://prod-lp-ml-staging.azurewebsites.net/api/IsBlurryVerification?code=iJ9h5a0UEF6Tp99z2aidxBaTopmYHjhv6VhIkZOL9ENDjPkO76AGXw==", data: data);
        }
    }

    public class IsBlurry
    {
        public string documentId { get; set; }
        public bool isBlurry { get; set; }
        public bool wasItBlurry { get; set; }
    }
}