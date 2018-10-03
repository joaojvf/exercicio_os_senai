using ExercicioBD.Models;
using ExercicioBD.Models.DAO;
using ExercicioBD.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioBD
{
    public partial class vwEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empresa"] != null)
            {
                BtnAdd.Visible = false;
                BtnPopGrid.Visible = true;
            }
            else
            {
                BtnAdd.Visible = true;
                BtnPopGrid.Visible = false;

            }

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            EmpresaDAO empresaDao = new EmpresaDAO();
            
            string razao_social = TxtRazaoSocial.Text;
            string cnpj = TxtCnpj.Text;
            string senha = TxtSenha.Text;
            string email = TxtEmail.Text;

            if ((razao_social.Equals("") || cnpj.Length > 45 || senha.Equals("") || email.Equals("")))
            {
                LblResultado.Text = "Dados estão inseridos de forma incorreta!!";
            }
            else
            {
                senha = CriptografiaSenha.GerarHashMd5(senha);

                Empresa empresa = new Empresa()
                {
                    RazaoSocial = razao_social,
                    Cnpj = cnpj,
                    Email = email,
                    Senha = senha
                };
                    
                empresa = empresaDao.Inserir(empresa);
                if (empresa != null)
                {
                    Session["empresa"] = empresa;
                    TxtRazaoSocial.Text = "";
                    TxtCnpj.Text = "";
                    TxtEmail.Text = "";
                    TxtSenha.Text = "";
                    LblResultado.Text = "Empresa cadastrada e logada com sucesso!";
                    Response.Redirect("~/vwLogin.aspx");
                }
                else
                {
                    LblResultado.Text = "Falha no cadastro!";

                }
            }
        }


        public void PopularGrid()
        {
            EmpresaDAO empDao = new EmpresaDAO();
            DataTable dTable = empDao.ListarTodos();

            GdvEmpresa.DataSource = dTable;
            GdvEmpresa.DataBind();
        }

        protected void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtCnpj_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtRazaoSocial_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnAtualizar(object sender, EventArgs e)
        {
            PopularGrid();
        }
    }
}