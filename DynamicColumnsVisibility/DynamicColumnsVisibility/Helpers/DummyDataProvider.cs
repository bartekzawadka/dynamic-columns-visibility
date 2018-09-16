using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicColumnsVisibility.Models;

namespace DynamicColumnsVisibility.Helpers
{
    public static class DummyDataProvider
    {
        public static ColumnFilterModel GetColumnFilterModel()
        {
            return new ColumnFilterModel
            {
                Date = new Column("Date", false),
                Name = new Column("Name", true),
                WhatEver = new Column("What ever", true),
                DynamicColumns = new List<Column>
                {
                    new Column("Generated column 1", false),
                    new Column("Generated column 2", true)
                }
            };
        }

        public static ObservableCollection<Record> GetData()
        {
            var data = new Record(
                new KeyValuePair<string, object>("Date", DateTime.Now),
                new KeyValuePair<string, object>("Name", "Hello world!"),
                new KeyValuePair<string, object>("What ever", "Dummy data"),
                new KeyValuePair<string, object>("Generated column 1", "Generated data 1"),
                new KeyValuePair<string, object>("Generated column 2", "Generated data 2"));

            return new ObservableCollection<Record>(new List<Record>
            {
                data
            });
        }
    }
}