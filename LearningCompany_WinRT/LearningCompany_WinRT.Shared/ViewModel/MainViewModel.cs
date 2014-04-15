using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            {
                Set(() => Title, ref _title, value);
            }
        }

        private string _subTitle;
        public string SubTitle
        {
            get { return _subTitle; }
            set
            {
                Set(() => SubTitle, ref _subTitle, value);
            }
        }

        public MainViewModel()
        {
            Title = IsInDesignMode ? "Runs in design mode" : "Runs in runtime mode";
        }
        
    }
}
