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
    public partial class Frase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            if (!IsPostBack)
            {
                AtualizaCategoria();
                AtualizaAutor();  
            }
        }
        public void AtualizaGrid()
        {
            DALFrase dal = new DALFrase();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }

        public void AtualizaAutor()
        {
            DALAutor dal = new DALAutor();
            ddlAutor.DataSource = dal.Localizar();
            ddlAutor.DataTextField = "nome";
            ddlAutor.DataValueField = "id";
            ddlAutor.DataBind();
        }

        public void AtualizaCategoria()
        {
            DALCategoria dal = new DALCategoria();
            ddlCategoria.DataSource = dal.Localizar();
            ddlCategoria.DataTextField = "categoria";
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtId.Text = "";
            txtFrase.Text = "";
            btSalvar.Text = "Inserir";
            AtualizaCategoria();
            AtualizaAutor();
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                String msg = "";
                DALFrase dal = new DALFrase();
                ModeloFrase obj = new ModeloFrase();
                obj.Texto = txtFrase.Text;
                obj.Autor = Convert.ToInt32(ddlAutor.SelectedValue);
                obj.Categoria = Convert.ToInt32(ddlCategoria.SelectedValue);

                if (btSalvar.Text == "Inserir")
                {
                    //inserir
                    dal.Inserir(obj);
                    msg = "<script> alert('O código gerado foi: " + obj.Id.ToString() + "'); </script>";
                }
                else
                {
                    //alterar
                    obj.Id = Convert.ToInt32(txtId.Text);
                    dal.Alterar(obj);
                    msg = "<script> alert('Registro alterado corretamente!!!!'); </script>";
                }
                Response.Write(msg);
                this.LimparCampos();
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }
            AtualizaGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = gvDados.SelectedIndex;
                int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
                DALFrase dal = new DALFrase();
                ModeloFrase f = dal.GetRegistro(cod);
                if (f.Id != 0)
                {
                    txtId.Text = f.Id.ToString();
                    txtFrase.Text = f.Texto;
                    ddlAutor.SelectedValue = f.Autor.ToString();
                    ddlCategoria.SelectedValue = f.Categoria.ToString();
                    btSalvar.Text = "Alterar";
                }
            }
            catch
            {

            }
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALFrase dal = new DALFrase();
            dal.Excluir(cod);
            AtualizaGrid();
        }
    }
}