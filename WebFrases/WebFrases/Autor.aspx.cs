using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;
using WebFrases.MODELO;

namespace WebFrases
{
    public partial class Autor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }
        public void AtualizaGrid()
        {
            DALAutor dal = new DALAutor();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }
        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            btSalvar.Text = "Inserir";
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                String msg = "";
                String caminho = Server.MapPath(@"IMAGENS\AUTORES\");
                DALAutor dal = new DALAutor();
                ModeloAutor obj = new ModeloAutor();
                obj.Nome = txtNome.Text;
                //faz o upload da foto e salva o nome no obj
                if (fuFoto.PostedFile.FileName != "")
                {
                    obj.Foto = DateTime.Now.Millisecond.ToString() + fuFoto.PostedFile.FileName;
                    String img = caminho + obj.Foto;
                    fuFoto.PostedFile.SaveAs(img);
                }

                if (btSalvar.Text == "Inserir")
                {
                    //inserir
                    dal.Inserir(obj);
                    msg = "<script> ShowMsg('Cadastro','O código gerado foi: " + obj.Id.ToString() + "'); </script>";
                }
                else
                {
                    //alterar
                    obj.Id = Convert.ToInt32(txtId.Text);
                    //verificar se existe foto existe e deletar
                    ModeloAutor uold = dal.GetRegistro(obj.Id);
                    if (uold.Foto != "")
                    {
                        File.Delete(caminho + uold.Foto);
                    }
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

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String caminho = Server.MapPath(@"IMAGENS\AUTORES\");
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALAutor dal = new DALAutor();
            //verificar se existe foto existe e deletar
            ModeloAutor uold = dal.GetRegistro(cod);
            if (uold.Foto != "")
            {
                File.Delete(caminho + uold.Foto);
            }
            dal.Excluir(cod);
            this.LimparCampos();
            AtualizaGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = gvDados.SelectedIndex;
                int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
                DALAutor dal = new DALAutor();
                ModeloAutor c = dal.GetRegistro(cod);
                if (c.Id != 0)
                {
                    txtId.Text = c.Id.ToString();
                    txtNome.Text = c.Nome;
                    btSalvar.Text = "Alterar";
                }
            }
            catch
            {

            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }
    }
}