using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    // insert a register in a table based on a TextBox input
    protected bool insert_row( string server, string tabla, TextBox text_box)
    {
        // Final result of the function
        // true  => PASS
        // false => FAIL
        bool result = false;

        // Get the name of the test
        string TestName = text_box.Text;

        // Define the contexts and rows
        var context_server3 = new db_testsEntities_server3();
        var context_server4 = new db_testsEntities_server4();
        var server3_row = new server3_table_tests { TestName = TestName };
        var server4_row = new server4_table_tests { TestName = TestName };

        using (context_server3)
        {
            using (context_server4)
            {
                
                try
                {
                    ///////////////////////////////////////////////////////////////////
                    // This code allows you to insert a row in a table
                    ///////////////////////////////////////////////////////////////////
                    if ("server3" == server) 
                    {
                        context_server3.server3_table_tests.Add(server3_row);
                        context_server3.SaveChanges();
                    }
                    else if ("server4" == server)
                    {
                        context_server4.server4_table_tests.Add(server4_row);
                        context_server4.SaveChanges();
                    }

                    ///////////////////////////////////////////////////////////////////
                    // This code allows you to select a View from you DataBase
                    ///////////////////////////////////////////////////////////////////
                    GridView1.DataSource = context_server4.view_table_tests.ToList();
                    GridView1.DataBind();

                    // Set result as 
                    // true => PASS
                    result = true;
                }
                catch (Exception exep)
                {
                    //Do nothing
                    // Activate only for debug
                    //Label5.Text = "Fail to insert: "+exep;
                }            
            }
        }
        // Return a result
        // true  => PASS
        // false => FAIL
        return result;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        using ( var context = new db_testsEntities_server4() ) { 
            ///////////////////////////////////////////////////////////////////
            // This code allows you to select a View from you DataBase
            ///////////////////////////////////////////////////////////////////
            GridView1.DataSource = context.view_table_tests.ToList();
            GridView1.DataBind();
        }

    }
    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (var context = new db_testsEntities_server4())
        {
            ///////////////////////////////////////////////////////////////////
            // This code allows you to select a View from you DataBase
            ///////////////////////////////////////////////////////////////////
            GridView1.DataSource = context.view_table_tests.ToList();
            GridView1.DataBind();
        }
    }

    // Insert a test to Server3
    protected void Button2_Click(object sender, EventArgs e)
    {
        // The final result of the function
        bool result = false;

        // We will insert a test to server3
        result = insert_row("server3", "server3_table_tests", TextBox1);
        if (false == result)
        {
            // To start seed IDENTITY from 1 again.
            string string_connection = "Data Source=CCELIS-MOBL1\\SERVER3; Integrated Security=True";
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(string_connection);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader reader;
            cmd.CommandText = "DBCC CHECKIDENT('[db_tests].[dbo].[server3_table_tests]', RESEED, 0)";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            sqlConnection1.Close();

            // Try to insert 5 times to see if there is an available space.
            for (int x = 0; x < 5; x++)
            {
                // If result is true then test was inserted, and we stop inserting.
                if (true == result)
                {
                    //Do nothing
                }
                else
                {
                    result = insert_row("server3", "server3_table_tests", TextBox1);
                }
            }

            // If result is still false, then it means there is not enough sapce in this table.
            if (false == result)
            {
                Label1.Text = "Failed, delete a test";
            }
            else
            {
                Label1.Text = "Succeded";
            }
        }
        else
        {
            Label1.Text = "Succeded";
        }
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //Delete test on server3
        using (var context = new db_testsEntities_server3())
        {
            try
            {
                // get the name of the test to delete
                int TestNameServer3 = Convert.ToInt32(TextBox4.Text);
                //Get the row to delete
                var test_row = new server3_table_tests { TestID = TestNameServer3 };
                /////////////////////////////////////////////////////////////
                // This code allows us to delete a row
                /////////////////////////////////////////////////////////////
                //http://stackoverflow.com/questions/17723276/delete-a-single-record-from-entity-framework
                context.server3_table_tests.Attach(test_row);
                context.server3_table_tests.Remove(test_row);
                context.SaveChanges();
                Label2.Text = "Succeded";
                Label5.Text = "";
                using (var context_2 = new db_testsEntities_server4())
                {
                    ///////////////////////////////////////////////////////////////////
                    // This code allows you to select a View from you DataBase
                    ///////////////////////////////////////////////////////////////////
                    GridView1.DataSource = context_2.view_table_tests.ToList();
                    GridView1.DataBind();
                }
            }
            catch (Exception exep)
            {
                Label2.Text = "Failed";
                Label5.Text = "Fail to delete: "+exep;
            }
        }
    }

    // Insert test in server4
    protected void Button3_Click(object sender, EventArgs e)
    {
        // The final result of the function
        bool result = false;

        // We will insert a test to server4
        result = insert_row("server4", "server4_table_tests", TextBox2);
        if (false == result)
        {
            // To start seed IDENTITY from 1 again.
            string string_connection = "Data Source=CCELIS-MOBL1\\SERVER4; Integrated Security=True";
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(string_connection);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader reader;
            cmd.CommandText = "DBCC CHECKIDENT('[db_tests].[dbo].[server4_table_tests]', RESEED, 5)";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            sqlConnection1.Close();

            // Try to insert 5 times to see if there is an available space.
            for (int x = 0; x < 5; x++)
            {
                // If result is true then test was inserted, and we stop inserting.
                if (true == result)
                {
                    //Do nothing
                }
                else
                {
                    result = insert_row("server4", "server4_table_tests", TextBox2);
                }
            }

            // If result is still false, then it means there is not enough sapce in this table.
            if (false == result)
            {
                Label3.Text = "Failed, delete a test";
            }
            else
            {
                Label3.Text = "Succeded";
            }
        }
        else
        {
            Label3.Text = "Succeded";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //Delete test on server4
        using (var context = new db_testsEntities_server4())
        {
            try
            {
                // get the name of the test to delete
                int TestNameServer4 = Convert.ToInt32(TextBox3.Text);
                //Get the row to delete
                var test_row = new server4_table_tests { TestID = TestNameServer4 };
                /////////////////////////////////////////////////////////////
                // This code allows us to delete a row
                /////////////////////////////////////////////////////////////
                //http://stackoverflow.com/questions/17723276/delete-a-single-record-from-entity-framework
                context.server4_table_tests.Attach(test_row);
                context.server4_table_tests.Remove(test_row);
                context.SaveChanges();
                Label4.Text = "Succeded";
                Label5.Text = "";
                using (var context_2 = new db_testsEntities_server4())
                {
                    ///////////////////////////////////////////////////////////////////
                    // This code allows you to select a View from you DataBase
                    ///////////////////////////////////////////////////////////////////
                    GridView1.DataSource = context_2.view_table_tests.ToList();
                    GridView1.DataBind();
                }
            }
            catch (Exception exep)
            {
                Label4.Text = "Failed";
                Label5.Text = "Fail to delete: " + exep;
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {  
        GridView1.Rows[0].Cells[0].BackColor = System.Drawing.Color.Yellow;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GridView1.Rows[0].Cells[0].BackColor = System.Drawing.Color.Yellow;
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        //To color up the cells with a different color depending on the server
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            if (Convert.ToInt32(GridView1.Rows[i].Cells[0].Text) < 6)
            {
                var color_server3 = System.Drawing.Color.AntiqueWhite;
                GridView1.Rows[i].Cells[0].BackColor = color_server3;
                TextBox1.BackColor = color_server3;
                TextBox4.BackColor = color_server3;
            }
            else
            {
                var color_server4 = System.Drawing.Color.Coral;
                GridView1.Rows[i].Cells[0].BackColor = color_server4;
                TextBox2.BackColor = color_server4;
                TextBox3.BackColor = color_server4;
            }
        }
    }
}