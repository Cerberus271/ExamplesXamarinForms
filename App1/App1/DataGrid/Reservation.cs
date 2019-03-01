using System;
using System.Collections.Generic;
using System.Text;

namespace App1.DataGrid
{
   public class Reservation
    {
        public string Name { get; set; }
        public int CantEntradas { get; set; }
        public int CantBebidas { get; set; }
        public int CantFondos{ get; set; }
        public int CantPostres { get; set; }
        public double TotalPayment { get; set; }
    }
}
