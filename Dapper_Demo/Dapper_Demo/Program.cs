using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dapper_Demo
{
    class Program
    {
        static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbLocal"].ConnectionString);

        static void Main(string[] args)
        {
            
            //SelectData();
            //InsertData();
            SelectItem();
        }

        private static void SelectItem()
        {
            string query = "SELECT OBJECTID,idOfertaVi,nombreFren,latitud,longitud FROM CAPA_OFERTAS_1 where OBJECTID = @OBJECTID";
            int OBJECTID = 137550;
            CAPA_OFERTAS_1 oferta = (CAPA_OFERTAS_1)db.Query<CAPA_OFERTAS_1>(query, new { OBJECTID = OBJECTID }).SingleOrDefault();
        }

        private static void SelectData()
        {
            string query = "SELECT OBJECTID,idOfertaVi,nombreFren,latitud,longitud FROM CAPA_OFERTAS_1";
            List<CAPA_OFERTAS_1> result = (List<CAPA_OFERTAS_1>)db.Query<CAPA_OFERTAS_1>(query);

        }

        private static void InsertData()
        {
            string query = "INSERT INTO CAPA_OFERTAS_1 (idOfertaVi,nombreFren,latitud,longitud) VALUES (@idOfertaVi,@nombreFren,@latitud,@longitud); SELECT Cast(Scope_Identity() as Int)";
            CAPA_OFERTAS_1 oferta = new CAPA_OFERTAS_1();
            oferta.idOfertaVi = "50190498";
            oferta.nombreFren = "TORRES DEMET SAN JUAN 1B FRACCION I";
            oferta.latitud = "32.45083";
            oferta.longitud = "-114.7186";

            int id = db.Query<int>(query, oferta).Single();
            
        }
    }
}
