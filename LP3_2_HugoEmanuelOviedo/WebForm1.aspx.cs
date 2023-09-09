using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LP3_2_HugoEmanuelOviedo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<string> Contacto = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            actualizarLista();
        }
        public void actualizarLista()
        {
            if(File.Exists(Server.MapPath(".") + "/datos.txt")) // saber si existe datos.txt
            {
                StreamReader archivoRead = new StreamReader(this.Server.MapPath(".") + "/datos.txt"); // instancia del streamreader
                string linea; // variable que se agrega a la lista
                Contacto.Clear(); // limpio la lista por si el metodo se vuelve a llamar que no se sumen al grid y quede el doble de los datos
                while ((linea = archivoRead.ReadLine()) != null)
                {
                    Contacto.Add(linea);
                }
                archivoRead.Close();
                // --- Asigno la lista al grid
                GridView1.DataSource = Contacto;
                //--- aca la enlazo
                GridView1.DataBind();
            }

        } 
        protected void Button1_Click(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrEmpty(TextBox3.Text) && !string.IsNullOrEmpty(TextBox4.Text))
            {
                StreamWriter archivo = new StreamWriter(this.Server.MapPath(".") + "/datos.txt", true);
                archivo.WriteLine("Nombre: " + TextBox1.Text + " Apellido:" + TextBox2.Text + " Descripcion:" + TextBox3.Text + " Telefono:" + TextBox4.Text);
                archivo.Close();
                Label7.Text = "Se registro correctamente";
                actualizarLista();
            } else
            {
                Label7.Text = "Todos los campos tienen que estar completos";
            }
            
            //----
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}