using ModalApp.Command;
using ModalApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ModalApp.ViewModel
{
    public class movieViewModel : baseViewModel
    {
        private bool _openModal;
        private ObservableCollection<movie> _movieList;
        public movieViewModel()
        {
            movieList = new ObservableCollection<movie>();
            movieList.Add(new movie() { Title = "Jurassic Park", Media = "Blu-ray", Available = true } );
            movieList.Add(new movie() { Title = "Blade Runner", Media = "DVD", Available = true });
            movieList.Add(new movie() { Title = "Alita Battle Angel", Media = "UHD Blu-ray", Available = true });
        }
        public bool openModal
        {
            get { return _openModal; }
            set { _openModal = value; onPropertyChanged(nameof(openModal)); }
        }
        public ObservableCollection<movie> movieList
        {
            get { return _movieList; }
            set { _movieList = value; onPropertyChanged(nameof(movieList)); }
        }
        public ICommand addMovieCommand
        {
            get { return new generalCommand(executeAddMovie, canExecuteAlways); }
        }
        private void executeAddMovie(object parameter)
        {
            openModal = true;
        }
        private bool canExecuteAlways(object parameter)
        {
            return true;
        }
        public ICommand okMovieCommand
        {
            get { return new generalCommand(executeOkMovie, canExecuteAlways); }
        }
        private void executeOkMovie(object parameter)
        {
            openModal = false;
        }
        public ICommand cancelMovieCommand
        {
            get { return new generalCommand(executeCancelMovie, canExecuteAlways); }
        }
        private void executeCancelMovie(object parameter)
        {
            openModal = false;
        }
    }
}
