using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicColumnsVisibility.Helpers;
using DynamicColumnsVisibility.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DynamicColumnsVisibility.ViewModel
{
    public class FilterViewModel : ViewModelBase
    {
        private ObservableCollection<Column> _columnsVisibility = new ObservableCollection<Column>();
        private ObservableCollection<string> _visibleColumns = new ObservableCollection<string>();

        public ObservableCollection<Column> ColumnsVisibility
        {
            get => _columnsVisibility;
            set
            {
                _columnsVisibility = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> VisibleColumns
        {
            get => _visibleColumns;
            set
            {
                _visibleColumns = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand VisibleColumnsChangedCommand { get; set; }

        public FilterViewModel()
        {
            LoadColumnFilters(DummyDataProvider.GetColumnFilterModel());
            VisibleColumnsChangedCommand = new RelayCommand(UpdateVisibleColumns);
            UpdateVisibleColumns();
        }

        private void LoadColumnFilters(ColumnFilterModel columnFilterModel)
        {
            var props = columnFilterModel.GetType().GetProperties().Where(x =>
                x.PropertyType == typeof(Column) || x.PropertyType.IsAssignableFrom(typeof(IList<Column>))).ToList();

            foreach (var propertyInfo in props)
            {
                if (propertyInfo.PropertyType == typeof(Column))
                {
                    var value = propertyInfo.GetValue(columnFilterModel);

                    ColumnsVisibility.Add((Column) value);
                }
                else if (propertyInfo.PropertyType.IsAssignableFrom(typeof(IList<Column>)))
                {
                    var dynamicColumns = (IList<Column>) propertyInfo.GetValue(columnFilterModel);
                    foreach (var dynamicColumn in dynamicColumns)
                    {
                        ColumnsVisibility.Add(dynamicColumn);
                    }
                }
            }
        }

        private void UpdateVisibleColumns()
        {
            VisibleColumns = new ObservableCollection<string>(ColumnsVisibility
                .Where(x => x.IsVisible)
                .Select(x => x.Name)
            );
        }
    }
}