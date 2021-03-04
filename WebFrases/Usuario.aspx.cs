using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;

namespace WebFrases
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AtualizarGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            TxtSenha.Text = string.Empty;
            TxtEmail.Text = string.Empty;
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                DALUsuario dal = new DALUsuario();
                WebFrases.MODELO.Usuario obj = new MODELO.Usuario();
                obj.Nome = txtNome.Text;
                obj.Email = TxtEmail.Text;
                obj.Senha = TxtSenha.Text;
                WebFrases.MODELO.Usuario validaEmail = dal.GetRegistro(TxtEmail.Text);

                if (btnInserir.Text == "Inserir")
                {
                    //implementar validação de email.
                    if (validaEmail.Id == 0)
                    {
                        dal.Inserir(obj);
                        msg = "<script> alert('O código gerado foi: " + obj.Id.ToString() + "');</script>";
                        this.LimparCampos();
                    }
                    else
                    {
                        msg = "<script> alert('Não é possível cadastrar o usuário, pois Já existe um usuário cadastrado com esse e-mail.');</script>";
                    }


                }
                else
                {
                    obj.Id = Convert.ToInt32(txtId.Text);
                    bool flag = true;
                    if ((validaEmail.Id != 0) && (validaEmail.Id != obj.Id))
                    {
                        flag = false;
                        msg = "<script> alert('Não é possível cadastrar o usuário, pois Já existe um usuário cadastrado com esse e-mail.');</script>";
                    }

                    if (flag)
                    {
                        //implemenbtar validação de email
                        
                        dal.Alterar(obj);
                        msg = "<script> alert(' Registro alterado');</script>";
                        this.LimparCampos();
                    }

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


        public void AtualizarGrid()
        {
            DALUsuario dal = new DALUsuario();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALUsuario dal = new DALUsuario();
            dal.Excluir(cod);
            AtualizarGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = gvDados.SelectedIndex;
                int cod = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
                DALUsuario dal = new DALUsuario();
                MODELO.Usuario c = dal.GetRegistro(cod);
                if (c.Id != 0)
                {
                    txtId.Text = c.Id.ToString();
                    txtNome.Text = c.Nome;
                    TxtEmail.Text = c.Email;
                    btnInserir.Text = "Alterar";
                }
            }
            catch { }
        }
    }
}