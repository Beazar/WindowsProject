using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    class PromotieImageViewModel: ViewModelBase
    {
        DownloadOperation downloadOperation;
        CancellationTokenSource cancellationToken;
        Windows.Networking.BackgroundTransfer.BackgroundDownloader backgroundDownloader = new Windows.Networking.BackgroundTransfer.BackgroundDownloader();

        //        private MainPageViewModel mp;

        private Promotie _promotie;

        public RelayCommand DownloadCommand { get; set; }

        public Promotie Promotie
        {
            get { return _promotie; }
            set { _promotie = value; RaisePropertyChanged(); }
        }

        public object LinkBox { get; private set; }

        public PromotieImageViewModel( Promotie promotie)
        {
//            this.mp = mp;
            this.Promotie = promotie;
            DownloadCommand = new RelayCommand((d) => Download());
            
        }
        /*
        private async void StartDownload()
        {
            try
            {
                Uri source = new Uri(Promotie.Kortingsbon);
                StorageFile destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                "Kortingsbon" + this.Promotie.Onderneming.Naam , CreationCollisionOption.GenerateUniqueName);

                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, destinationFile);

                // Attach progress and completion handlers.
                // HandleDownloadAsync(download, true);
                await download.StartAsync();
               
            }
            catch (Exception ex)
            {
               Debug.WriteLine("Download Error", ex);
            }
        }
        */

        public async void Download()
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Downloads;
            folderPicker.ViewMode = PickerViewMode.Thumbnail;
            folderPicker.FileTypeFilter.Add("*");
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            if (folder != null)
            {
                StorageFile file = await folder.CreateFileAsync("NewImage.jpg", CreationCollisionOption.GenerateUniqueName);
                Uri downloadUrl = new Uri(Promotie.Kortingsbon); 
                downloadOperation = backgroundDownloader.CreateDownload(downloadUrl, file);
                cancellationToken = new CancellationTokenSource();
                await downloadOperation.StartAsync().AsTask(cancellationToken.Token);
            }
        }



}
}
