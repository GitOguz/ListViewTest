using System.Collections.ObjectModel;

namespace ListViewTest
{
    public class VoorraadKast
    {
        public string KastId { get; set; }
        public ObservableCollection<Artikel> Artikelen { get; set; }

    }
}