using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MoviePlus.ViewModel
{
    public partial class movieViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool openEntryModal;

        [ObservableProperty]
        private bool openPostModal;

        [ObservableProperty]
        private int runMax;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RunStatus))]
        private int runPercent;

        [ObservableProperty]
        private bool runComplete;

        [ObservableProperty]
        private string movieTitle;

        [ObservableProperty]
        private string movieMedia;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteMovieCommand))]
        [NotifyCanExecuteChangedFor(nameof(RentMovieCommand))]
        [NotifyCanExecuteChangedFor(nameof(ReturnMovieCommand))]
        private bool movieAvailable;

        [ObservableProperty]
        private movie movieSelectedItem;

        [ObservableProperty]
        private string movieOption;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(PurgeMovieCommand))]
        private ObservableCollection<movie> movieList;

        private ICollectionView MovieCollectionView;
        public string RunStatus => $"{RunPercent} of {RunMax} processed";
        public int MovieCount => MovieList.Count;
        public movieViewModel()
        {
            MovieList = new ObservableCollection<movie>();
            MovieList.Add(new movie() { Title = "Jurassic Park", Media = "Blu-ray", Available = true });
            MovieList.Add(new movie() { Title = "Blade Runner", Media = "DVD", Available = true });
            MovieList.Add(new movie() { Title = "Alita Battle Angel", Media = "UHD/Blu-ray", Available = true });
            MovieCollectionView = CollectionViewSource.GetDefaultView(movieList);
            MovieCollectionView.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
            MovieCollectionView.MoveCurrentToFirst();
        }
        private void emptyMovie()
        {
            MovieTitle = string.Empty;
            MovieMedia = string.Empty;
            MovieAvailable = true;
        }
        private void mapMovie(movie currentMovie)
        {
            MovieTitle = currentMovie.Title;
            MovieMedia = currentMovie.Media;
            if (MovieMedia is null)
                MovieMedia = currentMovie.Media;
            MovieAvailable = currentMovie.Available;
        }
        [RelayCommand]
        public void SelectMovie(movie SelectedMovie)
        {
            if (SelectedMovie is null)
                emptyMovie();
            else
                mapMovie(SelectedMovie);
        }
        [RelayCommand]
        public void AddMovie()
        {
            emptyMovie();
            MovieOption = "Add";
            OpenEntryModal = true;
        }
        [RelayCommand]
        public void EditMovie()
        {
            MovieOption = "Edit";
            OpenEntryModal = true;
        }
        [RelayCommand(CanExecute = nameof(CanDeleteMovie))]
        public void DeleteMovie()
        {
            MovieList.Remove(MovieSelectedItem);
            MovieCollectionView.Refresh();
        }
        public bool CanDeleteMovie()
        {
            return MovieAvailable;
        }
        [RelayCommand(CanExecute = nameof(CanRentMovie))]
        public void RentMovie()
        {
            MovieAvailable = false;
            MovieSelectedItem.Available = false;
            MovieCollectionView.Refresh();
        }
        public bool CanRentMovie()
        {
            return MovieAvailable;
        }
        [RelayCommand(CanExecute = nameof(CanReturnMovie))]
        public void ReturnMovie()
        {
            MovieAvailable = true;
            MovieSelectedItem.Available = true;
            MovieCollectionView.Refresh();
        }
        public bool CanReturnMovie()
        {
            return !MovieAvailable;
        }
        [RelayCommand(CanExecute = nameof(CanPurgeMovie))]
        public void PurgeMovie()
        {
            MovieCollectionView.Refresh();
        }
        public bool CanPurgeMovie()
        {
            Debug.WriteLine(MovieList.Count);
            return MovieList.Count > 0;
        }
        [RelayCommand]
        public void OkMovie()
        {
            switch (MovieOption)
            {
                case "Add":
                    MovieList.Add(new movie() { Title = MovieTitle, Media = MovieMedia, Available = MovieAvailable });
                    MovieCollectionView.MoveCurrentTo(MovieList.FirstOrDefault(x => x.Title == MovieTitle));
                    break;
                case "Edit":
                    MovieSelectedItem.Title = MovieTitle;
                    MovieSelectedItem.Media = MovieMedia;
                    MovieSelectedItem.Available = MovieAvailable;
                    MovieCollectionView.Refresh();
                    break;
            }
            MovieOption = string.Empty;
            OpenEntryModal = false;
        }
        [RelayCommand]
        public void CancelMovie()
        {
            if (MovieSelectedItem != null)
                mapMovie(MovieSelectedItem);
            MovieOption = string.Empty;
            OpenEntryModal = false;
        }
        [RelayCommand]
        public void PostMovie()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
            void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                OpenPostModal = true;
                RunMax = 100;
                RunComplete = false;
                int i = 0;
                while (i < RunMax)
                {
                    i++;
                    RunPercent = i == RunMax ? RunMax : i % RunMax;
                    Thread.Sleep(50);
                }
                RunComplete = true;
            }
        }
        [RelayCommand]
        public void OkPost()
        {
            OpenPostModal = false;
        }
    }
}
