
using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace DB
{
    class MainP
    {
        public static void DisplayPostWithUserName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter();


            con.Open();
            string query = "select blog.title, blog.content, Username.name from Username INNER JOIN blog on blog.uid =username.id";
            SqlCommand cmd = new SqlCommand(query, con);
            da.SelectCommand = cmd;
            SqlDataReader sq = da.SelectCommand.ExecuteReader();
            string data = string.Format(format: "\nName:\tTitle:\t\tContent:\n");
            Console.WriteLine(data);
            while (sq.Read())
            {
                string dat = string.Format(
                    format: "{0}\t{1}\t{2}\n",
                    arg0: sq[2],
                    arg1: sq[0],
                    arg2: sq[1]
                    );
                Console.WriteLine(dat);
            }
            con.Close();
        }

        public static void DisplayAllUserWithPostName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter();


            con.Open();
            string query = "select Username.name, Username.email, blog.title from Username LEFT OUTER JOIN blog on blog.uid =username.id";
            SqlCommand cmd = new SqlCommand(query, con);
            da.SelectCommand = cmd;
            SqlDataReader sq = da.SelectCommand.ExecuteReader();
            string data = string.Format(format: "\nName:\tEmail:\t\t\tPostTitle:\n");
            Console.WriteLine(data);
            while (sq.Read())
            {
                string dat = string.Format(
                    format: "{0}\t{1}\t\t{2}\n",
                    arg0: sq[0],
                    arg1: sq[1],
                    arg2: sq[2]
                    );
                Console.WriteLine(dat);
            }
            con.Close();
        }

        public static void DisplayUserWithPost()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter();


            con.Open();
            string query = "select Username.name, blog.title from Username RIGHT OUTER JOIN blog on blog.uid =username.id";
            SqlCommand cmd = new SqlCommand(query, con);
            da.SelectCommand = cmd;
            SqlDataReader sq = da.SelectCommand.ExecuteReader();
            string data = string.Format(format: "\nName:\tPostTitle:\n");
            Console.WriteLine(data);
            while (sq.Read())
            {
                string dat = string.Format(
                    format: "{0}\t{1}\t\n",
                    arg0: sq[0],
                    arg1: sq[1]
                    );
                Console.WriteLine(dat);
            }
            con.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("POST WITH USERNAME\n");
            DisplayPostWithUserName();
            Console.WriteLine("ALL USERS\n");
            DisplayAllUserWithPostName();
            Console.WriteLine("USER WITH POST\n");
            DisplayUserWithPost();
        }
    }
}
