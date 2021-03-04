using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;

namespace WebFrases
{
    public partial class Autor : System.Web.UI.Page
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
            DALAutor dal = new DALAutor();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string caminho = Server.MapPath(@"IMAGENS\AUTORES\");
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALAutor dal = new DALAutor();
            MODELO.Autor uold = dal.GetRegistro(cod);
            if(uold.Foto != string.Empty)
            {
                File.Delete(caminho + uold.Foto);
            }
            dal.Excluir(cod);
            AtualizarGrid();
            this.LimparCampos();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvDados.SelectedIndex;
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALAutor dal = new DALAutor();
            MODELO.Autor c = dal.GetRegistro(cod);
            if (c.Id != 0)
            {
                txtId.Text = c.Id.ToString();
                txtNome.Text = c.Nome;
                btnInserir.Text = "Alterar";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                string msg = string.Empty;
                string caminho = Server.MapPath(@"IMAGENS\AUTORES\");
                DALAutor dal = new DALAutor();
                WebFrases.MODELO.Autor obj = new MODELO.Autor();
                obj.Nome = txtNome.Text;
                if (FuFoto.PostedFile.FileName != string.Empty)
                {
                    obj.Foto = DateTime.Now.Millisecond.ToString() + FuFoto.PostedFile.FileName;
                    string img = caminho + obj.Foto;
                    FuFoto.PostedFile.SaveAs(img);
                }
                

                try
                {
                    if (btnInserir.Text == "Inserir")
                    {
                        dal.Inserir(obj);
                        msg = "<script> alert('O código gerado foi: " + obj.Id.ToString() + "');</script>";

                    }
                    else
                    {

                        obj.Id = Convert.ToInt32(txtId.Text);
                        MODELO.Autor uold = dal.GetRegistro(obj.Id);
                        if(uold.Foto != string.Empty)
                        {
                            File.Delete(caminho + uold.Foto);
                        }

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
            else
            {
                Response.Write("<script> alert('É necessário prencher o nome da categoria !!!!');</script>");
            }
        }
    }
}