using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesctopKSMClient.Data
{
    [Table("Answers")]
    public class Answer
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        public string studentName { get; set; }
        public string groupName { get; set; }
        public string testName { get; set; }
        public int result { get; set; }
        public DateTime dateTime { get; set; }
    }
}
