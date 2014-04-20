using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;
using LearningCompany_WinRT.WebService;

namespace LearningCompany_WinRT.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<FormateurViewModel>();
        }

        public FormateurViewModel Formateur
        {
            get { return ServiceLocator.Current.GetInstance<FormateurViewModel>(); }
        }
    }

}
