using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;

namespace WebCRUD
{
    public class Conexion{

        private String cadena = "server=localhost; database=db_empresa; user=usr_empresa; password=Empres@123";

        public MySqlConnection conectar;
        public MySqlDataAdapter adapter = new MySqlDataAdapter();


        public void AbrirConexion() {


            try
            {

                conectar = new MySqlConnection();
                conectar.ConnectionString = cadena;
                conectar.Open();

                //System.Diagnostics.Debug.WriteLine("Conexion exitosa");
            }
            catch (Exception ex) {

                //System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }



        public void CerrarConexion() {


            try{
                if (conectar.State == System.Data.ConnectionState.Open)
                {

                    conectar.Close();
                    //System.Diagnostics.Debug.WriteLine("Conexion Cerrada");
                }

            }catch(Exception ex) {
                    //System.Diagnostics.Debug.WriteLine(ex.Message);
            }

           


        }


    }
}