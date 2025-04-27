using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo18_Porgramcion
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        private const string conexionNeptuno = @"Data Source=localhost\\sqlexpress;InitialCatalog=Neptuno;Integrated Security=True";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //cargar opciones en los dropdownlist
                ddlProducto.Items.Add("--Seleccionar--");
                ddlProducto.Items.Add("Igual a");
                ddlProducto.Items.Add("Mayor a");
                ddlProducto.Items.Add("Menor a");

                ddlCategoria.Items.Add("--Seleccionar--");
                ddlCategoria.Items.Add("Igual a");
                ddlCategoria.Items.Add("Mayor a");
                ddlCategoria.Items.Add("Menor a");

                //cargar la tabla sin filtros
                CargarGridView();

            }

        }

        private void CargarGridView()
        {
            string consulta = "SELECT * FROM Productos";

            SqlConnection connection = new SqlConnection(conexionNeptuno);
            connection.Open();

            SqlCommand command = new SqlCommand(consulta, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            gvTabla.DataSource = dataReader;
            gvTabla.DataBind();

            connection.Close();
        }
    }
}