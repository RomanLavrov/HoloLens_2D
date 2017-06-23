using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<StorageFile> Pictograms = new List<StorageFile>();
       
        public MainPage()
        {
            this.InitializeComponent();

            
        }

        private async void ButtonPictogram_Click(object sender, RoutedEventArgs e)
        {
            await GetImages("Piktogram");
        }

        private async void ButtonNoticht_Click(object sender, RoutedEventArgs e)
        {
            await GetImages("Noticht");
        }
        
        private void ButtonKonzept_PointerEntered(object sender, PointerRoutedEventArgs e)
        {            
            KonzeptText.Visibility = Visibility.Visible;
        }

        private void Konzept_PointerExited(object sender, PointerRoutedEventArgs e)
        {           
            KonzeptText.Visibility = Visibility.Collapsed;
        }

        private void ButtonSchnitstelle_PointerEntered(object sender, PointerRoutedEventArgs e)
        {            
            TextBoxSchnitstelle.Visibility = Visibility.Visible;
        }

        private void ButtonSchnitstelle_PointerExited(object sender, PointerRoutedEventArgs e)
        {           
            TextBoxSchnitstelle.Visibility = Visibility.Collapsed;
        }

        private void ButtonSchraffuren_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            TextBoxSchraffuren.Visibility = Visibility.Visible;
        }

        private void ButtonSchraffuren_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            TextBoxSchraffuren.Visibility = Visibility.Collapsed;
        }

        private void ButtonFotografien_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            TextBoxFotografien.Visibility = Visibility.Visible;
        }

        private void ButtonFotografien_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            TextBoxFotografien.Visibility = Visibility.Collapsed;
        }

        private void ButtonSave_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            TextBoxSave.Visibility = Visibility.Visible;
        }

        private void ButtonSave_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            TextBoxSave.Visibility = Visibility.Collapsed;
        }

        private void ButtonNotfall_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            TextBoxNotfall.Visibility = Visibility.Visible;
        }

        private void ButtonNotfall_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            TextBoxNotfall.Visibility = Visibility.Collapsed;
        }

        private void ButtonInfo_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            TextBoxInfo.Visibility = Visibility.Visible;
        }

        private void ButtonInfo_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            TextBoxInfo.Visibility = Visibility.Collapsed;
        }

        private async void ButtonHFM_Click(object sender, RoutedEventArgs e)
        {
            await GetImages("HFM");
        }

        private async Task GetImages(string targetFolder)
        {
            StorageFolder appFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await appFolder.GetFolderAsync("Assets");
            StorageFolder pictogram = await assets.GetFolderAsync(targetFolder);
            var files = await pictogram.GetFilesAsync();
            List<ImageItem> imageList = new List<ImageItem>();
            foreach (var item in files)
            {
                using (var stream = await item.OpenAsync(FileAccessMode.Read))
                {
                    imageList.Add(new ImageItem(stream, item.Name));
                }
            }
            GridViewImages.ItemsSource = imageList;
        }

        private async void Konzept_Click(object sender, RoutedEventArgs e)
        {
            int imgWidth = 800;
            int imgHeigth = 440;
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/plan1.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/plan2.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/plan3.png", imgWidth, imgHeigth);

        }

        private static async Task ShowImageInNewWindow(string imageUri, int gridWidth, int gridHeight)
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var uri = new System.Uri(imageUri);
                Grid grd = new Grid();
                grd.Background = new ImageBrush {ImageSource = new BitmapImage(new Uri(uri.ToString()))};

                grd.Height = gridHeight;
                grd.Width = gridWidth;
                grd.VerticalAlignment = VerticalAlignment.Center;
                grd.HorizontalAlignment = HorizontalAlignment.Center;

                Window.Current.Content = grd;
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        private async void ButtonNotfall_Click(object sender, RoutedEventArgs e)
        {
            int imgWidth = 500;
            int imgHeigth = 440;
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Leg-1.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Leg-2.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Leg-3.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Leg-4.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Leg-5.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Leg-6.png", imgWidth, imgHeigth);
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Leg-7.png", imgWidth, imgHeigth);
        }

        private async void ButtonSchnitstelle_Click(object sender, RoutedEventArgs e)
        {
            int imgWidth = 670;
            int imgHeigth = 440;
            await ShowImageInNewWindow("ms-appx:///Assets/LeftMenuPosters/Schnitt_AB.png", imgWidth, imgHeigth);
        }
    }
}
