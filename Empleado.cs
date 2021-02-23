using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebCRUD
{
    public class Empleado{

        Conexion connect;




        /*
         * Metodo para obtener el puesto de cada empleado
         */
        private DataTable GetPuesto() {

            DataTable table = new DataTable();
            connect = new Conexion();

            try
            {

                connect.AbrirConexion();

                String query = String.Format(" select id_puesto as id, puesto from puestos;");

                MySqlDataAdapter consulta = new MySqlDataAdapter(query, connect.conectar);

                consulta.Fill(table);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally {
                connect.CerrarConexion();
            }
           
            return table;
        }


        /*
         * metodo para llenar el dropdown dinamicamente con un datatable
         */
        public void GetPuesto(DropDownList drop) {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;

            drop.Items.Add("<<Seleccione un puesto>>");
            drop.Items[0].Value = "0";

            //Llenar dinamicamente el drop
            drop.DataSource = GetPuesto();
            drop.DataValueField = "id";
            drop.DataTextField = "puesto";

            drop.DataBind();

        }


        /*
         * Metodo para ingresar empleados
         */
        public int AddEmploye(String codigo, String nombre, String apellido, String direccion, String telefono, String fecha, int idPuesto) {

            int count = 0;
            connect = new Conexion();

            
            try{

                connect.AbrirConexion();
                String strInsert = String.Format("insert into empleados(Codigo, nombres, apellidos, direccion, telefono, fecha_nacimiento, id_puesto) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6})", codigo, nombre, apellido, direccion, telefono, fecha, idPuesto);
                MySqlCommand insert = new MySqlCommand(strInsert, connect.conectar);

                insert.Connection = connect.conectar;

                count = insert.ExecuteNonQuery();


            }
            catch(Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally {
                connect.CerrarConexion();
            }

            return count;

        }


        private DataTable GridEmpleados() {

            DataTable table = new DataTable();

            connect = new Conexion();

           String strConsulta = String.Format("select e.id_empleado id, e.codigo, e.nombres, e.apellidos, e.direccion, e.telefono, e.fecha_nacimiento, p.puesto, p.id_puesto from empleados e, puestos p where e.id_puesto = p.id_puesto;");

            try{

                connect.AbrirConexion();

                MySqlDataAdapter query = new MySqlDataAdapter(strConsulta, connect.conectar);

                query.Fill(table);

            }
            catch(Exception ex){
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            finally {
                connect.CerrarConexion();
            }
            
            return table;
        }


        public void GridEmpleados(GridView grid) {

            grid.DataSource = GridEmpleados();

            grid.DataBind();

        }




    }
}