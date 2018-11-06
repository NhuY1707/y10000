using Db4objects.Db4o;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double sal = 500;
            string FileName = "ne6.txt";
           
            IObjectContainer db = Databasehelper.OpenDb(FileName);
           
      Databasehelper.InputEmployees(db);
       Databasehelper.RetrieveAll(db);
          Databasehelper.RetrieveCompany(db,sal);
        }
    }
}
