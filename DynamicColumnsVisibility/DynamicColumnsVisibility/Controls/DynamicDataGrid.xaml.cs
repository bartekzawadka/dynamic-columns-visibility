using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DynamicColumnsVisibility.Controls
{
    public partial class DynamicDataGrid : DataGrid
    {
        public static DependencyProperty VisibleColumnsProperty = DependencyProperty.Register("VisibleColumns",
            typeof(ObservableCollection<string>), typeof(DynamicDataGrid));

        public ObservableCollection<string> VisibleColumns
        {
            get => (ObservableCollection<string>) GetValue(VisibleColumnsProperty);
            set => SetValue(VisibleColumnsProperty, value);
        }

        public DynamicDataGrid()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == VisibleColumnsProperty || e.Property == ItemsSourceProperty)
            {
                LoadData();
            }

            base.OnPropertyChanged(e);
        }

        private void LoadData()
        {
            CurrentGrid.Columns.Clear();

            if (VisibleColumns == null)
            {
                return;
            }

            foreach (var column in VisibleColumns)
            {
                var dataGridColumn = new DataGridTextColumn
                {
                    Header = column,
                    Binding = new Binding($"Properties[{column}]")
                };

                CurrentGrid.Columns.Add(dataGridColumn);
            }
        }
    }
}