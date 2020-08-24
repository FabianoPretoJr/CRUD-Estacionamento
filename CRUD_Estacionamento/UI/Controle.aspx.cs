using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Estacionamento.UI
{
    public partial class Controle : System.Web.UI.Page
    {
        BLL.Veiculo ve = new BLL.Veiculo();
        DAL.VeiculoDAL veDAL = new DAL.VeiculoDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvListar.DataSource = veDAL.Listar();
                gvListar.DataBind();
                if (Request.QueryString["id"] != null)
                {
                    if (Request.QueryString["id"].ToString() != "")
                    {
                        int idRecebido;
                        int.TryParse(Request.QueryString["id"], out idRecebido);

                        ve.Id = idRecebido;
                        ve = veDAL.PreencherPeliID(ve);

                        if (ve.Id != 0)
                        {

                            lblId.Text = ve.Id.ToString();
                            txtPlaca.Text = ve.Placa;
                            txtFabricante.Text = ve.Fabricante;
                            txtModelo.Text = ve.Modelo;

                            Session.Add("ca", 1);
                        }
                        else
                        {
                            lblId.Text = "Id INVÁLIDO";
                        }
                    }
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Session["ca"]) != 1)
            {
                ve.Placa = txtPlaca.Text;
                ve.Fabricante = txtFabricante.Text;
                ve.Modelo = txtModelo.Text;

                veDAL.Cadastrar(ve);
                btnBusca_Click(null, null);

                Response.Write("<script>Alert('Cadastro efetuado!')</script>");

                txtPlaca.Text = "";
                txtFabricante.Text = "";
                txtModelo.Text = "";

                txtPlaca.Focus();
            }
            else
            {
                ve.Id = Convert.ToInt32(lblId.Text);
                ve.Placa = txtPlaca.Text;
                ve.Fabricante = txtFabricante.Text;
                ve.Modelo = txtModelo.Text;

                veDAL.Atualizar(ve);

                Response.Redirect("Controle.aspx");
            }

            Session.Remove("ca");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            ve.Placa = txtBusca.Text;
            gvListar.DataSource = veDAL.Listar(ve);
            gvListar.DataBind();
        }

        protected void gvListar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ve.Id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "cmdExcluir")
            {
                veDAL.Excluir(ve);
                Response.Write("<script>alert('Registro Excluido!')</script>");

                btnBusca_Click(null, null);
            }
            else if (e.CommandName == "cmdAtualizar")
            {
                Response.Redirect("Controle.aspx?id=" + ve.Id);
            }
        }
    }
}