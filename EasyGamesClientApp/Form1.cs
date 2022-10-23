using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyGamesClientApp.Models;





namespace EasyGamesClientApp
{
    public partial class Form1 : Form
    {
        List<ClientModel> mClientM; //member variable which populates the client table upon opening of program
        DatabaseAccessor mDb; //member variable to initialize the database accessor class
        String mRow; //member variable to store selected clientID
        public Form1()
        {
            mDb = new DatabaseAccessor();

            InitializeComponent();
            this.Text = "EasyGamesApp";
            

            InitializeColumns();
            LoadRows();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView2.BackgroundColor = Color.White;

        }

        private void LoadRows()
        {
            mClientM = mDb.LoadClientData();
            foreach (var client in mClientM)
            {
                dataGridView1.Rows.Add(client.ClientID, client.Name, client.Surname, client.ClientBalance);
               



            }
        }
        //Load selected transactions for selected client
        private void LoadRowsTransaction()
        {

            dataGridView2.Rows.Clear();
            var clientDatas = mDb.getClientData(mRow);

                foreach (var clientData in clientDatas)
                {
                    dataGridView2.Rows.Add(clientData.TransactionID, clientData.Amount, clientData.TransactionTypeID, clientData.ClientID, clientData.Comment);
                }
        }
            //Set the headers for each of the tables
            private void InitializeColumns()
        {
            DataGridViewTextBoxColumn ClientID = new DataGridViewTextBoxColumn();
            ClientID.HeaderText = "ClientID";
            DataGridViewTextBoxColumn ClientName = new DataGridViewTextBoxColumn();
            ClientName.HeaderText = "Client Name";
            DataGridViewTextBoxColumn ClientSurname = new DataGridViewTextBoxColumn();
            ClientSurname.HeaderText = "Client Surname";
            DataGridViewTextBoxColumn ClientBalance = new DataGridViewTextBoxColumn();
            ClientBalance.HeaderText = "Client Balance";




            dataGridView1.Columns.Insert(0, ClientID);
            dataGridView1.Columns.Insert(1, ClientName);
            dataGridView1.Columns.Insert(2, ClientSurname);
            dataGridView1.Columns.Insert(3, ClientBalance);

            DataGridViewTextBoxColumn TransactionID = new DataGridViewTextBoxColumn();
            TransactionID.HeaderText = "TransactionID";
            DataGridViewTextBoxColumn Amount = new DataGridViewTextBoxColumn();
            Amount.HeaderText = "Amount";
            DataGridViewTextBoxColumn TransactionTypeID = new DataGridViewTextBoxColumn();
            TransactionTypeID.HeaderText = "TransactionTypeID";
            DataGridViewTextBoxColumn TransactionClientID = new DataGridViewTextBoxColumn();
            TransactionClientID.HeaderText = "Client ID";
            DataGridViewTextBoxColumn Comment = new DataGridViewTextBoxColumn();
            Comment.HeaderText = "Comment";

            dataGridView2.Columns.Insert(0, TransactionID);
            dataGridView2.Columns.Insert(1, Amount);
            dataGridView2.Columns.Insert(2, TransactionTypeID);
            dataGridView2.Columns.Insert(3, TransactionClientID);
            dataGridView2.Columns.Insert(4, Comment);

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


       

    
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        //Populates the TransactionTable with the selected Client from the ClientTable
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows.Clear();
            if (e.RowIndex >= 0)
            {
                mRow = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Console.WriteLine(mRow);

                var clientDatas = mDb.getClientData(mRow);

                foreach (var clientData in clientDatas)
                {
                    dataGridView2.Rows.Add(clientData.TransactionID, clientData.Amount, clientData.TransactionTypeID, clientData.ClientID, clientData.Comment);
                }


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mDb.UpdateBalance(mRow, int.Parse(textBox1.Text), true);
            dataGridView1.Rows.Clear();
            LoadRows();
            LoadRowsTransaction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            mDb.UpdateBalance(mRow, int.Parse(textBox1.Text), false);
            dataGridView1.Rows.Clear();
            LoadRows();
            LoadRowsTransaction();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

         if(comboBox1.SelectedIndex==0)
            {
             var user= mDb.Search(textBox2.Text.ToString(), EasyGamesClientApp.choice.Name);
               
                dataGridView1.Rows.Clear();
                foreach (var client in user)
                {
                    dataGridView1.Rows.Add(client.ClientID, client.Name, client.Surname, client.ClientBalance);
                    



                }
            }
            if (comboBox1.SelectedIndex==1)
            {
               var user= mDb.Search(textBox2.Text.ToString(), EasyGamesClientApp.choice.Surname);

                dataGridView1.Rows.Clear();
                foreach (var client in user)
                {
                    dataGridView1.Rows.Add(client.ClientID, client.Name, client.Surname, client.ClientBalance);




                }
            }
            if (comboBox1.SelectedIndex==2)
            {
              var user=  mDb.Search(textBox2.Text.ToString(), EasyGamesClientApp.choice.Balance);
                dataGridView1.Rows.Clear();
                foreach (var client in user)
                {
                    dataGridView1.Rows.Add(client.ClientID, client.Name, client.Surname, client.ClientBalance);

                }
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadRows();
            dataGridView2.Rows.Clear();
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        //Update comment 
     

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           String TransactionId= dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
           String ClientID= dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
           String comment= dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            mDb.InsertComment(TransactionId, ClientID, comment);
            

        }
    }
    
}
