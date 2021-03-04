using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;

namespace WebFrases
{
    public partial class Frases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
            
            if (!IsPostBack)
            {
                AtualizarCategoria();
                AtualizarAutor();
            }
            
        }

        public void AtualizarGrid()
        {
            DALFrase dal = new DALFrase();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }


        public void AtualizarCategoria()
        {
            DALCategoria dal = new DALCategoria();
            ddlCategoria.DataSource = dal.Localizar();
            ddlCategoria.DataTextField = "categoria";
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
        }

        public void AtualizarAutor()
        {
            DALAutor dal = new DALAutor();
            ddlAutor.DataSource = dal.Localizar();
            ddlAutor.DataTextField = "Nome";
            ddlAutor.DataValueField = "id";
            ddlAutor.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }


        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtFrase.Text = string.Empty;
            btnInserir.Text = "Inserir";
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                DALFrase dal = new DALFrase();
                WebFrases.MODELO.Frase obj = new MODELO.Frase();
                obj.Texto = txtFrase.Text;
                obj.Autor = Convert.ToInt32(ddlAutor.SelectedValue);
                obj.Categoria = Convert.ToInt32(ddlCategoria.SelectedValue);

                if (btnInserir.Text == "Inserir")
                {
                    dal.Inserir(obj);
                    msg = "<script> alert('O código gerado foi: " + obj.Id.ToString() + "');</script>";

                }
                else
                {
                    obj.Id = Convert.ToInt32(txtId.Text);
                    dal.Alterar(obj);
                    msg = "<script> alert(' Registro alterado');</script>";
                }
                Response.Write(msg);
                this.LimparCampos();
                AtualizarGrid();
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "');</script>");
            }
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvDados.SelectedIndex;
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALFrase dal = new DALFrase();
            MODELO.Frase f = dal.GetRegistro(cod);
            if (f.Id != 0)
            {
                txtId.Text = f.Id.ToString();
                txtFrase.Text = f.Texto;
                ddlAutor.SelectedValue = f.Autor.ToString();
                ddlCategoria.SelectedValue = f.Categoria.ToString();
                btnInserir.Text = "Alterar";
            }
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALFrase dal = new DALFrase();
            dal.Excluir(cod);
            AtualizarGrid();
        }
    }
}