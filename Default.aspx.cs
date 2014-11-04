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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
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
                Label1.Text = "Fail to insert: "+exep;
            }

        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //Delete on server3
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
                Label2.Text = "Fail to delete: "+exep;
            }
        }
    }
}