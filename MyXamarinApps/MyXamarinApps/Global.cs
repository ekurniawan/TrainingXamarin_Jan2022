using MyXamarinApps.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyXamarinApps
{
    public class Global
    {
        private static Global _instance;
        public static Global Instance
        {
            get { 
                if(_instance == null)
                {
                    _instance = new Global();
                }
                return _instance; 
            }
        }
        public string username { get; set; }
        public Course myCourse { get; set; }
    }
}
