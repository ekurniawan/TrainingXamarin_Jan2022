using System;
using System.Collections.Generic;
using System.Text;

namespace MyXamarinApps.Shared
{
    public class ViewCoffeeWithOrigin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roaster { get; set; }
        public string Image { get; set; }
        public int OriginId { get; set; }
        public string OriginName { get; set; }
    }
}
