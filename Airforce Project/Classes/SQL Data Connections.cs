using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Airforce_Project.Classes
{
    class SQL_Data_Connections
    {

        public List<Jet> getJetList()
        {
            List<Jet> jetList = new List<Jet>();
            string message = "SQL Database does not exist. Loading default values"; 
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = .; Initial Catalog = Airforce; Integrated Security = SSPI;"))
                {
                    DataTable dataTable = new DataTable();
                    new SqlDataAdapter("SELECT * FROM Aircraft", con).Fill(dataTable);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Jet jet = new Jet();
                        jet.JetID = Convert.ToInt32(dataTable.Rows[i]["JetID"]);
                        jet.JetName = dataTable.Rows[i]["JetName"].ToString();
                        jet.MaxSpeed = Convert.ToDouble(dataTable.Rows[i]["MaxSpeed"]);
                        jet.MaxWeight = Convert.ToDouble(dataTable.Rows[i]["MaxWeight"]);
                        jet.FuelTankSize = Convert.ToDouble(dataTable.Rows[i]["FuelTankSize"]);
                        jet.MaxAltitude = Convert.ToDouble(dataTable.Rows[i]["MaxAltitude"]);
                        jet.CargoCapacity = Convert.ToInt32(dataTable.Rows[i]["CargoCapacity"]);
                        jetList.Add(jet);
                    }
                }
                return jetList;
            }
            catch
            {
                try
                {
                    throw new SQL_Database_Not_Found_Exception(message);
                }
                catch
                {
                    var defaultValues = new Default_Jet_Values();
                    jetList = defaultValues.LoadDefaultJetValues();
                    return jetList;
                }
                
            }
            
        }

    }
}
