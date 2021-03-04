using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;
using WebFrases.MODELO;

namespace WebFrases
{
    public partial class PaginaMestre : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                //Response.Redirect("~/Login.aspx");
            }
            else
            {
                //DALUsuario du = new DALUsuario();
                //ModeloUsuario u = du.GetRegistro(Session["email"].ToString());
            }
        }
    }
}