using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo18_Porgramcion
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        private const string cadenaConexion = "Data Source=localhost\\sqlexpress;Initial Catalog=Libreria;Integrated Security=True";
        private string consultaTemas = "SELECT * FROM Temas";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTemas();
            }
        }

        private void CargarTemas()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaTemas, connection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Asignar la tabla de datos como origen de datos del dropdownlist
            ddlTemas.DataSource = sqlDataReader;
            ddlTemas.DataTextField = "Tema";
            ddlTemas.DataValueField = "IdTema";//value

            //enlazar los datos con el dropdownlist
            ddlTemas.DataBind();

            connection.Close();
        }

        protected void lbVerLibros_Click(object sender, EventArgs e)
        {
            Session["IdTema"] = ddlTemas.SelectedValue;
            Server.Transfer("Ejercicio3-B.aspx");
        }
    }
}