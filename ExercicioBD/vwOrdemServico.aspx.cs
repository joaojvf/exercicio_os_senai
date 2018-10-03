using ExercicioBD.Models;
using ExercicioBD.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioBD
{
    public partial class vwOrdemServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGrid();
        }

        public void PopularGrid()
        {
            OrdemServicoDAO osDao = new OrdemServicoDAO();
            DataTable dTable = osDao.ListarTodos();

            gdvOrdemServico.DataSource = dTable;
            gdvOrdemServico.DataBind();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            OrdemServicoDAO osDao = new OrdemServicoDAO();

            string Data = txtDataSolicitacao.Text;
            int Prazo;
            int.TryParse(txtPrazoEntrega.Text, out Prazo);
            double Total;
            double.TryParse(txtTotal.Text, out Total);
            string Status = DropDownStatus.SelectedValue;

            if ((Data.Equals("") || Prazo.Equals("") || Total.Equals("") || Status.Equals("")))
            {
                LblResultado.Text = "Dados estão inseridos de forma incorreta!!";
            }
            else
            {
                OrdemServico os = osDao.Inserir(new OrdemServico()
                {
                    DataSolicitacao = Data,
                    PrazoEntrega = Prazo,
                    Total = Total,
                    Status = Status
                });

                if (os != null)
                {
                    LblResultado.Text = "Inserido";
                    //Session["cliente"] = cliente;
                    //Response.Redirect("~/vwEndereco.aspx");
                }
            }
        }


    }
}