using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo18_Porgramcion
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string cadenaConexion = "Data Source=localhost\\sqlexpress;InitialCatalog=Viajes;Integrated Security = True";

        //Variables para concatenar con consultas condicionales
        string idProvincia;
        string idProvinciaFin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
                sqlConnection.Open();

            }
        }
    }
}