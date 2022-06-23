using System;
using System.Collections.Generic;
using System.Text;

namespace DesctopKSMClient.Data
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Test(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
