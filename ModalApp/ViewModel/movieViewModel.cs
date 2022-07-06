using ModalApp.Command;
using ModalApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ModalApp.ViewModel
{
    public class movieViewModel : baseViewModel
    {
        private bool _openEntryModal;
        private bool _openPostModal;
        private int _runMax;
        private int _runPercent;
        private bool _runComplete;
        private string _movieTitle;
        private string _movieMedia;
        private bool _movieAvailable;
        private movie _movieSelectedItem;
        private ObservableCollection<movie> _movieList;
        private ICollectionView movieCollectionView;
        public movieViewModel()
        {
            movieList = new ObservableCollection<movie>();
            movieList.Add(new movie() { Title = "Jurassic Park", Media = "Blu-ray", Available = true } );
            movieList.Add(new movie() { Title = "Blade Runner", Media = "DVD", Available = true });
            movieList.Add(new movie() { Title = "Alita Battle Angel", Media = "UHD/Blu-ray", Available = true });
            movieCollectionView = CollectionViewSource.GetDefaultView(movieList);
            movieCollectionView.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
            movieCollectionView.MoveCurrentToFirst();
        }
        public bool openEntryModal
        {
            get { return _openEntryModal; }
            set { _openEntryModal = value; onPropertyChanged(nameof(openEntryModal)); }
        }
        public bool openPostModal
        {
            get { return _openPostModal; }
            set { _openPostModal = value; onPropertyChanged(nameof(openPostModal)); }
        }
        public int runMax
        {
            get { return _runMax; }
            set { _runMax = value; onPropertyChanged(nameof(runMax)); }
        }
        public int runPercent
        {
            get { return _runPercent; }
            set { _runPercent = value; onPropertyChanged(nameof(runPercent)); onPropertyChanged(nameof(runStatus)); }
        }
        public string runStatus
        {
            get { return $"Posting {runPercent} of {runMax} movie(s) ... "; }
        }
        public bool runComplete
        {
            get { return _runComplete; }
            set { _runComplete = value; onPropertyChanged(nameof(runComplete)); }
        }
        public string movieTitle
        {
            get { return _movieTitle; }
            set { _movieTitle = value; onPropertyChanged(nameof(movieTitle)); }
        }
        public string movieMedia
        {
            get { return _movieMedia; }
            set { _movieMedia = value; onPropertyChanged(nameof(movieMedia)); }
        }
        public bool movieAvailable
        {
            get { return _movieAvailable; }
            set { _movieAvailable = value; onPropertyChanged(nameof(movieAvailable)); }
        }
        public movie movieSelectedItem
        {
            get { return _movieSelectedItem; }
            set { _movieSelectedItem = value; onPropertyChanged(nameof(movieSelectedItem)); }
        }
        public ObservableCollection<movie> movieList
        {
            get { return _movieList; }
            set { _movieList = value; onPropertyChanged(nameof(movieList)); }
        }
        private void emptyMovie()
        {
            movieTitle = string.Empty;
            movieMedia = string.Empty;
            movieAvailable = true;
        }
        private void mapMovie(movie currentMovie)
        {
            movieTitle = currentMovie.Title;
            movieMedia = currentMovie.Media;
            movieAvailable = currentMovie.Available;
        }
        public ICommand movieSelectCommand
        {
            get { return new generalCommand(executeSelectMovie, canExecuteAlways); }
        }
        private void executeSelectMovie(object parameter)
        {
            movie currentMovie = parameter as movie;
            if (currentMovie is null)
                emptyMovie();
            else
                mapMovie(currentMovie);
        }
        private bool canExecuteAlways(object parameter)
        {
            return true;
        }
        public ICommand addMovieCommand
        {
            get { return new generalCommand(executeAddMovie, canExecuteAlways); }
        }
        private void executeAddMovie(object parameter)
        {
            emptyMovie();
            openEntryModal = true;
        }
        public ICommand okMovieCommand
        {
            get { return new generalCommand(executeOkMovie, canExecuteAlways); }
        }
        private void executeOkMovie(object parameter)
        {
            movieList.Add(new movie() { Title = movieTitle, Media = movieMedia, Available = movieAvailable });
            movieCollectionView.MoveCurrentTo(movieList.FirstOrDefault(t => t.Title.Equals(movieTitle)));
            openEntryModal = false;
        }
        public ICommand cancelMovieCommand
        {
            get { return new generalCommand(executeCancelMovie, canExecuteAlways); }
        }
        private void executeCancelMovie(object parameter)
        {
            openEntryModal = false;
        }
        public ICommand postMovieCommand
        {
            get { return new generalCommand(executePostMovie, canExecuteAlways); }
        }
        private void executePostMovie(object parameter)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
            void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                openPostModal = true;
                runMax = 100;
                runComplete = false;
                int i = 0;
                while (i < runMax)
                {
                    i++;
                    runPercent = i == runMax ? runMax : i % runMax;
                    Thread.Sleep(50);
                }
                runComplete = true;
            }
        }
        public ICommand okPostCommand
        {
            get { return new generalCommand(executeOkPost, canExecuteAlways); }
        }
        private void executeOkPost(object parameter)
        {
            openPostModal = false;
        }
        public ICommand mediaToggleCommand
        {
            get { return new generalCommand(executeToggleMedia, canExecuteAlways); }
        }
        private void executeToggleMedia(object parameter)
        {
            movieMedia = parameter as string;
        }
    }
}
