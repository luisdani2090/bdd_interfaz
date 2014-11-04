using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        //We will insert a test to server3
        // get the name of the test for server3
        string TestNameServer3 = TextBox1.Text;
        using (var context = new db_testsEntities_server3())
        {
            var test_row = new server3_table_tests { TestName = TestNameServer3 };
            try { 
                ///////////////////////////////////////////////////////////////////
                // This code allows you to insert a row in a table
                ///////////////////////////////////////////////////////////////////
                context.server3_table_tests.Add(test_row);
                context.SaveChanges();
                Label1.Text = "Succeded";
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
                Label1.Text = "Failed";
                Label5.Text = "Fail to insert: "+exep;
            }

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
    protected void Button3_Click(object sender, EventArgs e)
    {
        // insert test to server4
        // get the name of the test for server4
        string TestNameServer4 = TextBox2.Text;
        using (var context = new db_testsEntities_server4())
        {
            var test_row = new server4_table_tests { TestName = TestNameServer4 };
            try
            {
                ///////////////////////////////////////////////////////////////////
                // This code allows you to insert a row in a table
                ///////////////////////////////////////////////////////////////////
                context.server4_table_tests.Add(test_row);
                context.SaveChanges();
                Label3.Text = "Succeded";
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
                Label3.Text = "Failed";
                Label5.Text = "Fail to insert: " + exep;
            }

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