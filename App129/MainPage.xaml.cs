using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App129
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MyViewModel();
        }


    }

    public class MyViewModel : INotifyPropertyChanged
    {
        private bool _isViewFlippedg = false;
        public bool IsViewFlipped
        {
            get { return _isViewFlippedg; }
            set
            {
                _isViewFlippedg = value;

                IsShowText =! _isViewFlippedg;

                OnPropertyChanged(nameof(IsViewFlipped));
            }
        }


        private bool _isShowText = true;
        public bool IsShowText
        {
            get { return _isShowText; }
            set
            {
                _isShowText = value;
                OnPropertyChanged(nameof(IsShowText));
            }
        }



        private bool _isDareShow = false;
        public bool IsDareShow
        {
            get { return _isDareShow; }
            set
            {
                _isDareShow = value;
                OnPropertyChanged(nameof(IsDareShow));
            }
        }
        private bool _isTruthShow = false;
        public bool IsTruthShow
        {
            get { return _isTruthShow; }
            set
            {
                _isTruthShow = value;
                OnPropertyChanged(nameof(IsTruthShow));
            }
        }

        public ICommand TruthCommand { protected set; get; }

        public ICommand DareCommand { protected set; get; }

        public ICommand BackCommand { protected set; get; }

        public MyViewModel(){

            TruthCommand = new Command(() =>
            {
                IsViewFlipped = !IsViewFlipped;
                IsDareShow = false;
                IsTruthShow = true;
               

            });

            DareCommand = new Command(() =>
            {
                IsViewFlipped = !IsViewFlipped;
                IsTruthShow = false;
                IsDareShow = true;

            });

            BackCommand = new Command(() =>
            {
                IsViewFlipped = !IsViewFlipped;
               
            });
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
