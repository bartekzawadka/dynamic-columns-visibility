using System.Collections.Generic;

namespace DynamicColumnsVisibility.Models
{
    public class ColumnFilterModel
    {
        public Column Date { get; set; }
        public Column Name { get; set; }
        public Column WhatEver { get; set; }

        public IEnumerable<Column> DynamicColumns { get; set; }
    }
}