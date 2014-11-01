using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

namespace bdd
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new bdd_ejemploEntities())
            {
                //var custQuery =
                //from cust in context.Customers
                //select cust;
                //GridView1.DataSource = context.Customers.ToList();
                //int i = 0;
                
                //context.Customers_33.Add(new Customers_33 { Name = "Luis" });
                //context.SaveChanges();
                GridView1.DataSource = context.Customers.ToList();
                GridView1.DataBind();
                GridView3.DataSource = context.Customers_33.ToList();
                GridView3.DataBind();                
            }
            using (var context2 = new bdd_ejemploEntities2())
            {
                GridView2.DataSource = context2.Customers_66.ToList();
                GridView2.DataBind();
            }
            GridView1.Visible = true;
        }
    }
}