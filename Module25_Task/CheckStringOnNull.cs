using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_Task
{
    public static class CheckStringOnNull
    {

        public static string Check()
        {
            string myString = "";
            while (true)
            {
                myString = Console.ReadLine();
                if(myString == "")
                {
                    Console.Write("Не может быть пустым!");
                }
                else
                {
                    break;
                }
            }

            return myString;
        }
    }
}
