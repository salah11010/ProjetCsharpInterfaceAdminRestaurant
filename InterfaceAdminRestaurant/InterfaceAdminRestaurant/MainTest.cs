using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceAdminRestaurant;
    internal class MainTest
    {
        public static void Main() { 
            Nouriture N1 = new Nouriture("salah", 12, 'L', true, "./salah.txt");
            Console.WriteLine(N1.ToString());
        }
    }
