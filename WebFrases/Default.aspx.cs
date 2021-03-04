using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFrases
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["email"]!= null)
            {
                lbEmail.Text = Session["email"].ToString();
                lbNome.Text = Session["nome"].ToString();
            }
            
        }
    }
}