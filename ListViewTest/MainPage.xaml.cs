using System.Collections.ObjectModel;

namespace ListViewTest;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    public ObservableCollection<VoorraadKast> voorraadkasten = new();

    private async void RemoveButton_Clicked(object sender, EventArgs e)
    {
        if (gescandItems.SelectedItem == null || gescandItems.SelectedItem.GetType() != typeof(Artikel))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "You didnt select anything to remove!", "OK");
            return;
        }

        RemoveArtikel(((Artikel)gescandItems.SelectedItem));
        gescandItems.SelectedItem = null;
    }
    private void gescandItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        voorraadkasten = new ObservableCollection<VoorraadKast>();        

        VoorraadKast voorraadKast = new VoorraadKast();
        voorraadKast.KastId = "ABC12345";
        voorraadKast.Artikelen = new ObservableCollection<Artikel>();

        voorraadkasten.Add(voorraadKast);

        var r = voorraadkasten.FirstOrDefault(k => k.KastId == "ABC12345");

        gescandItems.ItemsSource = r.Artikelen;

        for (int i = 0; i < 60; i++)
        {
            voorraadKast.Artikelen.Add(new Artikel { KastId = "ABC12345", Aantal = i, ArtikelId = "1234556789", ArtikelName = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", Seperator = "O" });
        }
    }

    public void RemoveArtikel(Artikel artikel) 
    {
        var art = voorraadkasten.FirstOrDefault(k => k.KastId == artikel.KastId);

        if (art != null)
        {
            art.Artikelen.Remove(artikel);

            if (art.Artikelen.Count == 0)
            {
                voorraadkasten.Remove(art);
            }
        }
    }
}

