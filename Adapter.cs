
DataTable user = new DataTable();
            string query = "SELECT * FROM Username";
            SqlCommand cmd = new SqlCommand(query, con);
            da.SelectCommand = cmd;
            da.Fill(user);
            //foreach (DataRow r in user.Rows)
            //{
            //    Console.WriteLine(r[1]);
            //}

            DataTable blog = new DataTable();
            query = "SELECT * FROM blog";
            cmd = new SqlCommand(query, con);
            da.SelectCommand = cmd;
            da.Fill(blog);
            //foreach (DataRow r in blog.Rows)
            //{
            //    Console.WriteLine(r[1]);
            //}
            string u = "laibs";
            string p = "12340";
            query = $"insert into usern(name,password) values(@u,@p)";
            SqlCommand com1 = new SqlCommand(query, con);
            SqlParameter p0 = new SqlParameter("u", u);
            SqlParameter p1 = new SqlParameter("p", p);
            com1.Parameters.Add(p0);
            com1.Parameters.Add(p1);
            da.InsertCommand = com1;
            da.InsertCommand.ExecuteNonQuery();
            query = $"update usern set password = @p where name = @u";
            com1 = new SqlCommand(query, con);
            p = "345";
            u = "nim";
            p0 = new SqlParameter("u", u);
            p1 = new SqlParameter("p", p);
            com1.Parameters.Add(p0);
            com1.Parameters.Add(p1);
            da.UpdateCommand = com1;
            da.UpdateCommand.ExecuteNonQuery();
            query = $"delete from usern where password = @p";
            com1 = new SqlCommand(query, con);
            p = "pass";
            p1 = new SqlParameter("p", p);
            com1.Parameters.Add(p1);
            da.DeleteCommand = com1;
            da.DeleteCommand.ExecuteNonQuery();
