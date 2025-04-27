using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo18_Porgramcion
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //cargar opciones en los dropdownlist
                ddlProducto.Items.Add("--Seleccionar--");
                ddlProducto.Items.Add("Igual a");
                ddlProducto.Items.Add("Mayor a");
                ddlProducto.Items.Add("Menor a");

            }

        }
    }
}