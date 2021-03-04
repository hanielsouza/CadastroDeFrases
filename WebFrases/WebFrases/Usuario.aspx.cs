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
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AtualizaGrid();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }
        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";
            txtEmail.Text = "";
            btSalvar.Text = "Inserir";
        }
        public void AtualizaGrid()
        {
            DALUsuario dal = new DALUsuario();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }
        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                String msg = "";
                DALUsuario dal = new DALUsuario();
                ModeloUsuario obj = new ModeloUsuario();
                obj.Nome = txtNome.Text;
                obj.Email = txtEmail.Text;
                obj.Senha = txtSenha.Text;
                ModeloUsuario validaEmail = dal.GetRegistro(txtEmail.Text);
                if (btSalvar.Text == "Inserir")
                {
                    //inserir
                    //implementar validação do email
                    if (validaEmail.Id == 0)
                    {
                        dal.Inserir(obj);
                        msg = "<script> alert('O código gerado foi: " + obj.Id.ToString() + "'); </script>";
                        this.LimparCampos();
                    }
                    else
                    {
                        msg = "<script> alert('Não é possível cadastrar o usuário, pois já existe um usuário cadastrado com esse e-mail.'); </script>";
                    }
                }
                else
                {
                    obj.Id = Convert.ToInt32(txtId.Text);
                    //Boolean flag = true; // pode alterar
                    if ((validaEmail.Id != 0) && (validaEmail.Id != obj.Id)){
                        //flag = false;
                        msg = "<script> alert('Não é possível alterar o usuário, pois já existe um usuário cadastrado com esse e-mail.'); </script>";
                    }else
                    {                    
                        dal.Alterar(obj);
                        msg = "<script> alert('Registro alterado corretamente!!!!'); </script>";
                        this.LimparCampos();
                    }
                   
                }
                Response.Write(msg);
                
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }
            AtualizaGrid();
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALUsuario dal = new DALUsuario();
            dal.Excluir(cod);
            AtualizaGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = gvDados.SelectedIndex;
                int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
                DALUsuario dal = new DALUsuario();
                ModeloUsuario c = dal.GetRegistro(cod);
                if (c.Id != 0)
                {
                    txtId.Text = c.Id.ToString();
                    txtNome.Text = c.Nome;
                    txtEmail.Text = c.Email;
                    btSalvar.Text = "Alterar";
                }
            }
            catch
            {

            }
           
        }
    }
}