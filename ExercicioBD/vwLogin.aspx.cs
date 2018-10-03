using ExemploBD.Models;
using ExemploBD.Models.DAO;
using ExercicioBD.Models;
using ExercicioBD.Models.DAO;
using ExercicioBD.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioBD
{
    public partial class vwLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnLogar_Click(object sender, EventArgs e)
        {
            TxtSenha.Text = CriptografiaSenha.GerarHashMd5(TxtSenha.Text);
            ClienteDAO clienteDao = new ClienteDAO();
            Cliente c = clienteDao.ValidarLogin(TxtEmail.Text,TxtSenha.Text);

            if (c != null)
            {
                Session["cliente"] = c;
                Session["OrdemDeServico"] = GerarOrdemServico(c);
                Response.Redirect("~/vwServicos.aspx");
            }
            else
            {
                EmpresaDAO empresaDao = new EmpresaDAO();
                Empresa emp = empresaDao.ValidarLogin(TxtEmail.Text, TxtSenha.Text);

                if (e != null)
                {
                    Session["empresa"] = emp;
                    Response.Redirect("~/vwEmpresa.aspx");
                }
                else
                {
                    LblResultado.Text = "Acesso invalido";
                }
            }
           
        }

        protected void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        public OrdemServico GerarOrdemServico(Cliente c)
        {
            OrdemServico os = new OrdemServico()
            {
                DataSolicitacao = DateTime.Now.ToString("dd/MM/yyyy"),
                Status = "Aberto",
                Cliente = c
            };
            OrdemServicoDAO osDao = new OrdemServicoDAO();
            return osDao.Inserir(os);
        }
    }
}