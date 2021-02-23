using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCRUD
{
    public partial class _Default : Page {


        Empleado empleado;


        protected void Page_Load(object sender, EventArgs e){

            if (!IsPostBack) {

                empleado = new Empleado();
                empleado.GetPuesto(drop_puesto);
                empleado.GridEmpleados(grid_empleado);

                
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e) {

            empleado = new Empleado();

            if (empleado.AddEmploye(txt_codigo.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text, Convert.ToInt32(drop_puesto.SelectedValue)) > 0) {

                lbl_mensaje.Text = "Datos Guardados Correctamente";
                empleado.GridEmpleados(grid_empleado);
            }
            
        }

        protected void grid_empleado_SelectedIndexChanged(object sender, EventArgs e){

            //txt_codigo.Text = grid_empleado.SelectedValue.ToString();

            

            txt_codigo.Text = grid_empleado.SelectedRow.Cells[0].Text;
            txt_nombres.Text = grid_empleado.SelectedRow.Cells[1].Text;
            txt_apellidos.Text = grid_empleado.SelectedRow.Cells[2].Text;
            txt_direccion.Text = grid_empleado.SelectedRow.Cells[3].Text;
            txt_telefono.Text = grid_empleado.SelectedRow.Cells[4].Text;

            DateTime fecha = Convert.ToDateTime(grid_empleado.SelectedRow.Cells[5].Text);

            txt_fn.Text = fecha.ToString("yyyy-MM-dd");

            //Extraer el id del drop
            int indice = grid_empleado.SelectedRow.RowIndex;
            drop_puesto.SelectedValue = grid_empleado.DataKeys[indice].Values["id_puesto"].ToString();

        }
    }
}