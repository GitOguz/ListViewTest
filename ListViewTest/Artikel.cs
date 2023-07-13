using System.ComponentModel;

namespace ListViewTest
{
    public class Artikel : INotifyPropertyChanged
    {
        private string _ArtikelId;
        public string ArtikelId
        {
            get { return _ArtikelId; }
            set
            {
                _ArtikelId = value;
                NotifyPropertyChanged("ArtikelId");
            }
        }

        private int _Aantal;
        public int Aantal
        {
            get { return _Aantal; }
            set
            {
                _Aantal = value;
                NotifyPropertyChanged("Aantal");
            }
        }
        private string _ArtikelName;
        public string ArtikelName
        {
            get { return _ArtikelName; }
            set
            {
                _ArtikelName = value;
                NotifyPropertyChanged("ArtikelName");
            }
        }
        public string KastId { get; set; }
        public string Seperator { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}