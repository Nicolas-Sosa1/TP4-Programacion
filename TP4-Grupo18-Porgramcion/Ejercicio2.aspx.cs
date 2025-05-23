﻿using System;
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
        private const string conexionNeptuno = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";


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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            //ARMADO DE LA CONSULTA

            //Primera parte de la consulta
            string consulta = "SELECT * FROM Productos";
            string condicion = "";

            //se obtienen los operadores logicos en una funcion aparte
            string operadorProd = ObtenerOperador(ddlProducto.SelectedValue);
            string operadorCat = ObtenerOperador(ddlCategoria.SelectedValue);

            //se usa para verificar si hay filtros
            bool hayFiltro = false;

            if(!string.IsNullOrEmpty(txtProducto.Text) && operadorProd != "")
            {
                condicion += "IdProducto " + operadorProd + " " + txtProducto.Text;
                hayFiltro = true;
            }

            if (!string.IsNullOrEmpty(txtCategoria.Text) && operadorCat != "")
            {
                if (hayFiltro)
                    condicion += " AND ";

                condicion += "IdCategoría " + operadorCat + " " + txtCategoria.Text;
                hayFiltro = true;
            }

            if (hayFiltro)
            {
                consulta += " WHERE " + condicion;
            }

            try
            {
                // Ejecutar la consulta
                SqlConnection connection = new SqlConnection(conexionNeptuno);
                connection.Open();

                SqlCommand command = new SqlCommand(consulta, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                gvTabla.DataSource = dataReader;
                gvTabla.DataBind();

                connection.Close();
                lblMensaje.Text = "";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ha ocurrido un error en la consulta, verifique los campos.";
            }



        }
        private string ObtenerOperador(string seleccion)
        {
            switch (seleccion)
            {
                case "Igual a": return "=";
                case "Mayor a": return ">";
                case "Menor a": return "<";
                default: return "";
            }
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {

            CargarGridView();

            ddlCategoria.SelectedIndex = 0;
            ddlProducto.SelectedIndex = 0;

            txtCategoria.Text = string.Empty;
            txtProducto.Text = string.Empty;
        }
    }
}
