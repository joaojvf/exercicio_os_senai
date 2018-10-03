using ExemploBD.Models;
using ExemploBD.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemploBD
{
    public partial class vwEndereco : System.Web.UI.Page
    {
        Cliente c;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cliente"] != null)
            {
                c = Session["cliente"] as Cliente;
                LblCliente.Text = "Continue o cadastro " + c.Nome;


                PopularGrid();
            }

        }

        public void PopulaEnderecos(int cod)
        {
            EnderecoDAO endDao = new EnderecoDAO();
            Endereco end = endDao.BuscarPorCod(cod);

            if (end != null)
            {
                HiddenCod.Value = end.Cod.ToString();
                TxtRua.Text = end.Rua;
                TxtBairro.Text = end.Bairro;
                TxtCep.Text = end.CEP;
                TxtComp.Text = end.Complemento;
                TxtNumero.Text = end.Numero.ToString();
            }
        }

        public void PopularGrid()
        {
            EnderecoDAO endDao = new EnderecoDAO();
            DataTable dTable = endDao.ListarTodos();

            gdvEndereco.DataSource = dTable;
            gdvEndereco.DataBind();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {

            string rua = TxtRua.Text;
            string bairro = TxtBairro.Text;
            string cep = TxtCep.Text;
            string complemento = TxtComp.Text;
            int numero = Convert.ToInt32(TxtNumero.Text);

            ClienteDAO cDao = new ClienteDAO();

            if (rua.Equals("") || rua.Length > 45 || bairro.Equals("") || bairro.Length > 45 || cep.Equals("") || cep.Length > 9 || TxtNumero.Text.Equals("") || TxtNumero.Text.Length > 45)
            {
                LblResultado.Text = "Dados estão inseridos de forma incorreta!!";
            }
            else
            {
                EnderecoDAO endDao = new EnderecoDAO();
                endDao.Inserir(new Endereco()
                {
                    Rua = rua,
                    Bairro = bairro,
                    CEP = cep,
                    Complemento = complemento,
                    Numero = numero,
                    Cliente = c
                });


                LblResultado.Text = "Novo endereço salvo!";
                PopularGrid();


            }
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            EnderecoDAO endDao = new EnderecoDAO();

            if (TxtRua.Text.Equals("") || TxtRua.Text.Length > 45 || TxtBairro.Text.Equals("") || TxtBairro.Text.Length > 45 || TxtCep.Text.Equals("") || TxtCep.Text.Length > 9 || TxtNumero.Text.Equals("") || TxtNumero.Text.Length > 45)
            {
                LblResultado.Text = "Dados não foram inseridos ou estão inseridos de forma incorreta!!";
               
            }
            else
            {
                if (endDao.Deletar(Convert.ToInt32(HiddenCod.Value)))
                {
                    LblResultado.Text = "Endereço Deletado com Sucesso";
                    TxtRua.Text = "";
                    TxtBairro.Text = "";
                    TxtCep.Text = "";
                    TxtComp.Text = "";
                    TxtNumero.Text = "";
                }
                PopularGrid();
            }

        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            EnderecoDAO endDao = new EnderecoDAO();

            int cod;
            string rua = TxtRua.Text;
            string bairro = TxtBairro.Text;
            string cep = TxtCep.Text;
            string complemento = TxtComp.Text;
            int numero;
            Int32.TryParse(TxtNumero.Text, out numero);

            if (!Int32.TryParse(HiddenCod.Value, out cod) || rua.Equals("") || rua.Length > 45 || bairro.Equals("") || bairro.Length > 45 || cep.Equals("") || cep.Length > 9 || numero < 1 || TxtNumero.Text.Length > 45)
            {
                LblResultado.Text = "Dados não foram inseridos ou estão inseridos de forma incorreta!!";
            }
            else
            {

                Endereco endereco = new Endereco()
                {
                    Cod = cod,
                    Rua = rua,
                    Bairro = bairro,
                    CEP = cep,
                    Complemento = complemento,
                    Numero = numero,
                    Cliente = c
                };

                Endereco end = endDao.Alterar(endereco);

                if (end != null)
                {
                    LblResultado.Text = "Endereco Alterado com Sucesso";
                    PopularGrid();

                }
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {


            Response.Redirect("~/vwCliente.aspx");

        }

        protected void gdvEndereco_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Editar"))
                    PopulaEnderecos(Convert.ToInt32(e.CommandArgument.ToString()));
            }
            catch (Exception ee)
            {

            }
        }

        protected void gdvEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}