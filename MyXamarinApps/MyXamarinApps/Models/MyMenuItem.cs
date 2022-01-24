using System;
using System.Collections.Generic;
using System.Text;

namespace MyXamarinApps.Models
{
    public class MyMenuItem
    {
        public MyMenuItem()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string ImageIcon { get; set; }
    }
}
