using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Model;

namespace View
{
    public partial class ListaLivros : System.Web.UI.Page
    {

        private GerenciadorLivro GerLivros = new GerenciadorLivro();

        protected void Page_Load(object sender, EventArgs e)
        {

            lblMsg.Text = string.Empty;
            lblMsg.Visible = false;

            if (!Page.IsPostBack)
            {
                Listar();
            }
        }

        private void Listar()
        {
            List<Livro> lstLivros = GerLivros.Listar();
            GdvLivros.DataSource = lstLivros;
            GdvLivros.DataBind();
        }

        protected void GdvLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "alterar")
            {
                Response.Redirect("CadastroLivro.aspx?Id=" + e.CommandArgument);
            }
            else if (e.CommandName == "excluir")
            {
                try
                {
                    Livro l = new Livro();
                    l.id = (int)e.CommandArgument;
                    GerLivros.Excluir(l);
                    Listar();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "ERRO: " + ex.Message;
                    lblMsg.Visible = true;
                }
            }
        }
    }
}