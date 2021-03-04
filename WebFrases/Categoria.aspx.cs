using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;

namespace WebFrases
{
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            btnInserir.Text = "Inserir";
        }

        public void AtualizarGrid()
        {
            DALCategoria dal = new DALCategoria();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }



        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
               

                try
                {
                    string msg = string.Empty;
                    DALCategoria dal = new DALCategoria();
                    WebFrases.MODELO.Categoria obj = new MODELO.Categoria();
                    obj.Nome = txtNome.Text;

                    if (btnInserir.Text == "Inserir")
                    {
                        dal.Inserir(obj);
                        msg = "<script> ShowMsg('Cadastro','O código gerado foi: " + obj.Id.ToString() + "');</script>";

                    }
                    else
                    {
                        obj.Id = Convert.ToInt32(txtId.Text);
                        dal.Alterar(obj);
                        msg = "<script> alert(' Registro alterado');</script>";
                    }
                    //Response.Write(msg);
                    PlaceHolder1.Controls.Add(new LiteralControl(msg));
                    this.LimparCampos();
                    AtualizarGrid();
                }
                catch (Exception erro)
                {
                    string msg1 = "<script> alert('" + erro.Message + "');</script>";
                    
                    PlaceHolder1.Controls.Add(new LiteralControl(msg1));
                }
            }
            else
            {
                Response.Write("<script> alert('É necessário prencher o nome da categoria !!!!');</script>");
            }
            




        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALCategoria dal = new DALCategoria();
            dal.Excluir(cod);
            AtualizarGrid();
            

        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = gvDados.SelectedIndex;
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALCategoria dal = new DALCategoria();
            MODELO.Categoria c = dal.GetRegistro(cod);
            if (c.Id != 0)
            {
                txtId.Text = c.Id.ToString();
                txtNome.Text = c.Nome;
                btnInserir.Text = "Alterar";
            }



        }
    }
}