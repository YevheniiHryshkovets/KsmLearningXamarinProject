using System;
using System.Collections.Generic;
using System.Text;

namespace DesctopKSMClient.Data
{
    public class Lesson
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Lesson(int number, string name)
        {
            ID = number;
            Name = name;
        }
    }
}
