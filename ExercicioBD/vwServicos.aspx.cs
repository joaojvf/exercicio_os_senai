using ExemploBD.Models;
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
    public partial class vwServicos : System.Web.UI.Page
    {
        OrdemServico os;
        Cliente cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            cliente = Session["cliente"] as Cliente;
            os = Session["OrdemDeServico"] as OrdemServico;

            if (!IsPostBack)
            {
                cliente = Session["cliente"] as Cliente;
                os = Session["OrdemDeServico"] as OrdemServico;
                PopularGridServicos();
            }

        }

        public OrdemServico GerarOrdemServico()
        {
            OrdemServico os = new OrdemServico()
            {
                DataSolicitacao = DateTime.Now.ToString("dd/MM/yyyy"),
                Cliente = cliente
            };
            OrdemServicoDAO osDao = new OrdemServicoDAO();
            return osDao.Inserir(os);
        }

        public void PopularGridServicos()
        {
            ServicoDAO osDao = new ServicoDAO();
            DataTable dTable = osDao.ListarTodos();

            gdvServico.DataSource = dTable;
            gdvServico.DataBind();
        }

        public void PopularGridCarrinho()
        {
            ServicoDAO osDao = new ServicoDAO();
            DataTable dTable = osDao.ListarCarrinho(os);

            gdvCarrinho.DataSource = dTable;
            gdvCarrinho.DataBind();
        }

        protected void gdvServico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string strQtde = (gdvServico.Rows[e.RowIndex].FindControl("TxtQuantidade") as TextBox).Text;
            int qtde;
            double valor = Convert.ToDouble((gdvServico.Rows[e.RowIndex].FindControl("LblValor") as Label).Text);
            int tempo = Convert.ToInt32((gdvServico.Rows[e.RowIndex].FindControl("LblTempo") as Label).Text);
            int cod_servico = Convert.ToInt32((gdvServico.Rows[e.RowIndex].FindControl("LblCodigo") as Label).Text);


            if (Int32.TryParse(strQtde, out qtde))
            {
                Servico servico = new Servico();

                servico.Nome = (gdvServico.Rows[e.RowIndex].FindControl("LblNome") as Label).Text;
                servico.Codigo = cod_servico;
                servico.Valor = valor;
                servico.TempoMedio = tempo;

                OS_ServicoDAO osDao = new OS_ServicoDAO();
                OS_Servico osServ = new OS_Servico()
                {
                    ordemServico = os,
                    servico = servico,
                    Quantidade = qtde,
                    Valor = valor,
                    Prazo = tempo
                };

                if (osDao.Inserir(osServ))
                {
                    LblResultado.Text = "Foi";
                    PopularGridCarrinho();
                }
                else
                {
                    LblResultado.Text = "Nao FOi";
                }


            }
            else
            {
                LblResultado.Text = "Erro na quantidade!";
            }
        }
    }
}
