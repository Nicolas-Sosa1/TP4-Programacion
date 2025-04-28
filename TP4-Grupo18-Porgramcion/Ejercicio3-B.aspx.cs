using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo18_Porgramcion
{
    public partial class Ejercicio3_B : System.Web.UI.Page
    {
        private const string cadenaConexion = "Data Source=localhost\\sqlexpress;Initial Catalog=Libreria;Integrated Security=True";
        private string consultarLibros = "SELECT * FROM Libros WHERE IdTema = @IdTema";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdTema"] == null)
            {
                lblError.Text = "Debes ir a la página anterior para cargar los datos de la tabla";
                return;
            }

            try
            {
                // Obtener el valor de la sesión
                int idTema = Convert.ToInt32(Session["IdTema"].ToString());

                // Establecer la conexión a la base de datos
                SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(consultarLibros, sqlConnection);

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@IdTema", SqlDbType.Int);
                sqlParameter.Value = idTema;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                gvLibros.DataSource = sqlDataReader;
                gvLibros.DataBind();

                sqlConnection.Close();

            }
            catch (Exception Error)
            {
                lblError.Text = "Ocurrió un error al cargar los libros";
            }
        }

        protected void lbConsultar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}
