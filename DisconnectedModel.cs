/*
A dataset provides us index-based access to data so we can get the data from any location.
Dataset is a collection of tables where each table is represented as a DataTable class and identified by the index position.
 
Methods of DataAdapter
Fill (DataSet ds,string TableName).
Update (DataSet ds,string TableName)
Fill is the method to load data from a DataSource into a DataSet.
 When we call the Fill() method of Adapter, the following action takes place internally.
Open a connection with the DataSource.
Execute the Select command under it on the DataSource and load data from the table to the DataSet.
Close the Connection.
Fill requires a select statement to get to know which data it is supposed to select from the database and fill in the inMemory objects.
 */
DataTable user = new DataTable();
string con = @"Data Source=(localdb)\ProjectsV13;Initial….";
SqlConnection conn = new SqlConnection(con);
string query = "SELECT * FROM user";
SqlCommand cmd = new SqlCommand(query, conn);
SqlDataAdapter da = new SqlDataAdapter();
da.SelectCommand = cmd;
da.Fill(user);
 
/*
Update is to transfer data from a DataSet to a DataSource.
Since a DataSet is updatable, changes can be made to data that is loaded into it, like adding, modifying and deleting records.
After making all the changes to the data in a dataset if we want to send those changes back to the DataSource then call the Update() method on the DataAdapter that performed the following:
Re-opened a connection with the DataSource.
Changes made in the dataset will be sent back to the table where in this process it will use the insert, update and delete commands of the DataAdapter.
Close the Connection.
Update requires a query to get to know which data it is supposed to put in the database.
 
DataAdapter is internally a collection of the following 4 methods:
Select Command.
Insert Command.
Update Command.
Delete Command.
*/

using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace disconnectedModel
{
    class program
    {
        static void Main()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter();
            //setting the commands
            da.UpdateCommand = new SqlCommand("UPDATE table1 SET name = @Name WHERE id = @ID", conn);
            da.DeleteCommand = new SqlCommand("delete from table1 WHERE id = @ID", conn);
            da.InsertCommand = new SqlCommand("insert into table1(name,password) values(@Name,@passworddd)", conn);
            da.SelectCommand = new SqlCommand("SELECT * FROM table1", conn);
            da.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "name");
            da.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "name");
            da.InsertCommand.Parameters.Add("@passworddd", SqlDbType.NVarChar, 50, "password");
            SqlParameter p0 = da.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int);
            SqlParameter p = da.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int);
            p.SourceColumn = "id";
            p0.SourceColumn = "id";
            p.SourceVersion = DataRowVersion.Original;
            p0.SourceVersion = DataRowVersion.Original;
            //filling the dataset
            DataSet set = new DataSet();
            da.Fill(set,"table1");
            DataTable t = set.Tables[0];
            Console.WriteLine("ID" + "\t|\t" + "NAME" + "\t\t|\t" + "PASSWORD");
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + "\t|\t" + row[1] + "\t\t|\t" + row[2]);
            }
            Console.WriteLine("CHOOSE AN OPERATION:\n1-INSERT\n2-DELETE\n3-UPDATE\n4-DISPLAY INMEMEORY VERSION\n5-DISPLAY DB VERSION\n6-UPDATE DATABASE\n7-Exit");
            string choice;
            do
            {
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("\t\tINSERT");
                    Console.Write("Enter name: ");
                    string nameInput = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string passwrd = Console.ReadLine();
                    DataRow newRow = set.Tables["table1"].NewRow();
                    newRow["name"] = nameInput;
                    newRow["password"] = passwrd;
                    set.Tables[0].Rows.Add(newRow);
                }
                else if(choice == "2")
                {
                    Console.WriteLine("\t\tDELETE");
                    Console.Write("Enter Rownumber to delete: ");
                    string iidd = Console.ReadLine();
                    DataRow last = set.Tables[0].Rows[Convert.ToInt32(iidd)-1];
                    last.Delete();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("\t\tUPDATE");
                    Console.Write("Enter id to update: ");
                    string iidd = Console.ReadLine();
                    DataRow la = set.Tables[0].Rows[Convert.ToInt32(iidd)-1];
                    Console.Write("Enter name: ");
                    string nameInput = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string passwrd = Console.ReadLine();
                    la[1] = nameInput;
                    la[2] = passwrd;
                }
                else if (choice == "4")
                {
                    Console.WriteLine("ID" + "\t|\t" + "NAME" + "\t\t|\t" + "PASSWORD");
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        Console.WriteLine(row[0] + "\t|\t" + row[1] + "\t\t|\t" + row[2]);
                    }
                }
                else if (choice == "5")
                {
                    conn.Open();
                    string query = $"Select * FROM table1";
                    SqlCommand com = new SqlCommand(query, conn);
                    SqlDataReader row = com.ExecuteReader();
                    int read = 0;
                    while (row.Read())
                    {
                        read = 1;
                        Console.WriteLine(row[0] + "\t|\t" + row[1] + "\t\t|\t" + row[2]);
                    }
                    if (read == 0)
                    {
                        Console.WriteLine("No RECORD FOUND");
                    }
                    conn.Close();
                }
                else if (choice == "6")
                {
                    ////updating in an order
                    da.Update(set.Tables[0].Select(null, null, DataViewRowState.Deleted));
                    da.Update(set.Tables[0].Select(null, null, DataViewRowState.ModifiedCurrent));
                    da.Update(set.Tables[0].Select(null, null, DataViewRowState.Added));
                    da.Update(set, "table1");
                }
                else if (choice == "7")
                {
                    break;
                }
            } while (choice != "7");
            
        }
    }
}

https://www.c-sharpcorner.com/UploadFile/8af593/ado-net-dis-connected-architecture/
https://www.c-sharpcorner.com/UploadFile/8a67c0/connected-vs-disconnected-architecture-in-C-Sharp/
