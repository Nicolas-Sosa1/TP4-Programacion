using System;
using System.CodeDom;
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

                //insertar por defecto en todos los ddl "seleccionar"
                ddlProvinciaInicio.Items.Insert(0, new ListItem("--Seleccionar--", ""));
                ddlLocalidadInicio.Items.Insert(0, new ListItem("--Seleccionar--", ""));
                ddlProvinciaFinal.Items.Insert(0, new ListItem("--Seleccionar--", ""));
                ddlLocalidadFinal.Items.Insert(0, new ListItem("--Seleccionar--", ""));

                //consulta a ejecutar
                string consultaProvincia = "SELECT * FROM Provincias";
                SqlCommand commandPI = new SqlCommand(consultaProvincia, sqlConnection);
                SqlDataReader readerPI = commandPI.ExecuteReader();
            }
        }
    }
}