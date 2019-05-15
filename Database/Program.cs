using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new Msql();
            //db.M1sql(); // save to json data from server localhost
            db.InsertDB(); // save to servar local host data from file json
            Console.ReadLine();
        }
    }
}
