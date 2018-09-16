using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DynamicColumnsVisibility.Helpers;
using DynamicColumnsVisibility.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace DynamicColumnsVisibility.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Record> _data;
        private ObservableCollection<Column> _columnsVisibility;
        
        public string Title { get; set; }

        public ObservableCollection<Record> Data
        {
            get => _data;
            set
            {
                _data = value;
                RaisePropertyChanged(() => Data);
            }
        }

        public ObservableCollection<Column> ColumnsVisibility
        {
            get => _columnsVisibility;
            set
            {
                _columnsVisibility = value;
                RaisePropertyChanged(() => ColumnsVisibility);
            }
        }
        
        public FilterViewModel FilterViewModel { get; set; } = SimpleIoc.Default.GetInstance<FilterViewModel>();
        
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Title = "Dynamic columns visibility - demo";

            Data = DummyDataProvider.GetData();
        }
    }
}