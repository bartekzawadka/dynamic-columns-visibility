namespace DynamicColumnsVisibility.Models
{
    public class Column
    {
        public string Name { get; set; }
        
        public bool IsVisible { get; set; }

        public Column(string name, bool isVisible)
        {
            Name = name;
            IsVisible = isVisible;
        }
    }
}