using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace WSTEST3
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSPersona : IWSPersona
    {
        public Persona ObtenerInformacion(string identificacion)
        {


            try
            {
                string condicion = "-5";
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server=2c493008-8b16-4b7c-a93b-a727002340a2.sqlserver.sequelizer.com;Database=db2c4930088b164b7ca93ba727002340a2;User ID=wgvbrufuitipenfo;Password=vy8Bcv33jQvdsPzaNucGWBSK5orR3x3gzeVS2feDu73aAjDNvt4WCLS3PvEVej8U;";
                SqlDataAdapter da = new SqlDataAdapter("select * from personas where edad > " + condicion, conn);
                SqlDataAdapter di = new SqlDataAdapter("insert into personas values('guillermo',52)", conn);

                DataSet ds = new DataSet();
                da.Fill(ds, "personas");


                foreach (DataRow dato in ds.Tables["personas"].Rows)
                {
                    Persona tipo = new Persona() { nombre = dato["nombre"].ToString(), edad = int.Parse(dato["edad"].ToString()) };


                }
                 
            }
            catch (Exception x)
            {
                string hola = x.InnerException.ToString();

            }

            if (identificacion == "0")
            {
                return new Persona() { nombre = "Roberto", edad = 45 };
            }
            else
            {
                return new Persona() { error = "golasfnlajsfhsoifs" };
            }
        }

        
    }
}
