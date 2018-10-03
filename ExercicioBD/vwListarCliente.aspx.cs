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
    public partial class vwListarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateGrid("");
            }
        }

        public void PopulateGrid(string nome)
        {
            ClienteDAO cDao = new ClienteDAO();
            DataTable dTable = cDao.ListarTodos(nome);

            
                gdvCliente.DataSource = dTable;
                gdvCliente.DataBind();
            
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            PopulateGrid(TxtNome.Text);
        }

        protected void gdvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}