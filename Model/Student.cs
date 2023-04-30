using System;
using System.Collections.Generic;
using System.Text;

namespace DbExample.Model
{
    public class Student
    {
        public int ?Roll { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public string Course { get; set; }
    }
}
