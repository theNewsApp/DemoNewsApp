using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoNewsApp
{
    public class User
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
