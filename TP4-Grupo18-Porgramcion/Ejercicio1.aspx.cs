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
        private const string cadenaConexion = "Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security = True";

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

                ddlProvinciaInicio.DataSource = readerPI;
                ddlProvinciaInicio.DataTextField = "NombreProvincia";
                ddlProvinciaInicio.DataValueField = "IdProvincia";
                ddlProvinciaInicio.DataBind();

                //Cerrar conexion
                readerPI.Close();
                sqlConnection.Close();

                ddlProvinciaInicio.Items.Insert(0, new ListItem("--Seleccionar--", ""));
            }
        }
        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ************** CARGA DE LOCALIDAD INICIO **************
            // Vaciar antes de cargar e insertar nuevamente Seleccionar
            ddlLocalidadInicio.Items.Clear();
            ddlLocalidadInicio.Items.Insert(0, new ListItem("--Seleccionar--", ""));

            // El ID(string) de la provincia se guarda en una variable para luego se concatenada
            // a la consulta SQL condicional
            string consultaLocalidad = "SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = ";
            idProvincia = ddlProvinciaInicio.SelectedValue;
            consultaLocalidad = consultaLocalidad + idProvincia;

            if (!string.IsNullOrEmpty(idProvincia))
            {
                // Abrir conexion (nueva)
                SqlConnection conexionLI = new SqlConnection(cadenaConexion);
                conexionLI.Open();

                // Consulta a ejecutar
                SqlCommand commandLI = new SqlCommand(consultaLocalidad, conexionLI);
                SqlDataReader readerLI = commandLI.ExecuteReader();

                // Carga de DDL
                ddlLocalidadInicio.DataSource = readerLI;
                ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                ddlLocalidadInicio.DataValueField = "IdLocalidad";
                ddlLocalidadInicio.DataBind();

                // Cerrar conexion
                readerLI.Close();
                conexionLI.Close();
            }

            ddlProvinciaFinal.Items.Clear();
            ddlProvinciaFinal.Items.Insert(0, new ListItem("--Seleccionar--"));

            string consultaProvinciaFin = "SELECT * FROM Provincias WHERE IdProvincia <> ";
            idProvincia = ddlProvinciaInicio.SelectedValue;
            consultaProvinciaFin = consultaProvinciaFin + idProvincia;

            if (!string.IsNullOrEmpty(idProvincia))
            { 
                SqlConnection conexionPF = new SqlConnection(cadenaConexion);
                conexionPF.Open();

                SqlCommand commandPF = new SqlCommand(consultaProvinciaFin, conexionPF);
                SqlDataReader readerPF = commandPF.ExecuteReader();

                ddlProvinciaFinal.DataSource = readerPF;
                ddlProvinciaFinal.DataTextField = "NombreProvincia";
                ddlProvinciaFinal.DataValueField = "IdProvincia";
                ddlProvinciaFinal.DataBind();

                readerPF.Close();
                conexionPF.Close();
            }

            CargarLocalidadFinal():
        }

        public void CargarLocalidadFinal() 
        {
            ddlProvinciaFinal.Items.Clear();
            ddlProvinciaFinal.Items.Insert(0, new ListItem("--Seleccionar--", ""));

            string consultaLocalidadFin = "SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = ";
            idProvinciaFin = ddlProvinciaFinal.SelectedValue;
            consultaLocalidadFin = consultaLocalidadFin + idProvinciaFin;
        }
    }
}