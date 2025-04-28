using System;
using System.Collections.Generic;
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

            }
        }
    }
}