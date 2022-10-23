using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EasyGamesClientApp.Models;
using System.Data;
using Dapper;

namespace EasyGamesClientApp
{
    enum choice //To identify the type of filter query
    {
        Name,
        Surname,
        Balance

    }
    class DatabaseAccessor
    {
        SqlConnection mConnection;
        public DatabaseAccessor()
        {
            const string V = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ClientDBNew; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            var cs = V;
            mConnection = new SqlConnection(cs);
            mConnection.Open();
            
        }

        public List<ClientModel> LoadClientData()
        {

  
         var clients = mConnection.Query<ClientModel>("SELECT * FROM ClientTable").AsList();
         clients.ForEach(ClientModel => Console.WriteLine(ClientModel.ClientID));
            List<ClientModel> user = mConnection.Query<ClientModel>("sp_GetAllClients",
        commandType: CommandType.StoredProcedure).AsList();
            user.ForEach(ClientModel => Console.WriteLine(ClientModel.ClientBalance));
            return user;
            ;
        }

        public List <TransactionModel> getClientData(String ID)
        {
            
               List<TransactionModel> user = mConnection.Query<TransactionModel>("sp_GetSingleClient", param: new { ID=int.Parse(ID)},
                       commandType: CommandType.StoredProcedure).AsList();

            return user;
        }

        //Updates the balance for credit or debit transactions
        public void UpdateBalance(String ID,int amount,bool add)
        {
            //Add Transaction
           

            if (add==true)
            {
                mConnection.Query("sp_AddClientTransaction", param: new { ID = int.Parse(ID), Amount = amount, TransactionType = 2 },
                             commandType: CommandType.StoredProcedure);
                mConnection.Query("sp_UpdateClientBalance", param: new { ID = int.Parse(ID), Amount = amount},
                             commandType: CommandType.StoredProcedure);


            }
            if(add==false)
            {
                mConnection.Query("sp_AddClientTransaction", param: new { ID = int.Parse(ID), Amount = amount * -1, TransactionType = 1 },
                         commandType: CommandType.StoredProcedure);
                mConnection.Query("sp_UpdateClientBalance", param: new { ID = int.Parse(ID), Amount = amount * -1},
                            commandType: CommandType.StoredProcedure);

            }

            

        }

        public List<ClientModel> Search(string term,choice A)
        {

            

            if (A==choice.Name)
            {
               return  mConnection.Query<ClientModel>("sp_SearchName", param: new { Name = term },
                             commandType: CommandType.StoredProcedure).AsList(); ;
            }

            if (A == choice.Surname)
            {
               return mConnection.Query<ClientModel>("sp_SearchSurname", param: new { Surname = term },
                             commandType: CommandType.StoredProcedure).AsList(); 
            }

            if (A == choice.Balance)
            {
               return mConnection.Query<ClientModel>("sp_SearchBalance", param: new { Balance = int.Parse(term) },
                             commandType: CommandType.StoredProcedure).AsList();
            }
            return null;
        }

        //Update Database Comment
        public void InsertComment(String TransactionId,String ClientID,String Comment)
        {

            mConnection.Query("sp_EditComment", param: new { ID = int.Parse(TransactionId), ClientID = int.Parse(ClientID), Comment=Comment },
                             commandType: CommandType.StoredProcedure);
        }

    }
}
