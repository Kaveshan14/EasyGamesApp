using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGamesClientApp.Models
{
   public class ClientModel
    {

        public int ClientID { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        
        public decimal ClientBalance { get; set; }



    }

   public class TransactionModel
    {

        public int TransactionID { get; set; }

        public double Amount { get; set; }

        public int TransactionTypeID { get; set; }

        public int ClientID { get; set; }

        public String Comment { get; set; }

    }
}