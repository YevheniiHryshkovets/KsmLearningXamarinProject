using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using DesctopKSMClient.Data;

namespace DesctopKSMClient.Model
{
    public class AnswerRepository
    {
        SQLiteConnection database;

        public AnswerRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Answer>();
        }

        public IEnumerable<Answer> GetItems()
        {
            return database.Table<Answer>().ToList();
        }

        public int SaveItem(Answer item)
        {
            if(item.id != 0)
            {
                database.Update(item);
                return item.id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
