using MediCareNetworksDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicareNetworksCommon.Models;

namespace MediCareNetworksBLL
{
    public class ClientBLL
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataAccess DAL = new DataAccess();

        public int AddClient(Client.Clients obj)
        {
            string[] parameters = {"@ID", "@Name", "@PersonName", "@MobileNo", "@ContactNo",
                                   "@Rating", "@RatingID", "@Address", "@Comments", "@CreationbyID", "@CreationbyIP"};

            object[] parameterValues = {obj.ID, obj.Name, obj.PersonName, obj.MobileNo, obj.ContactNo,
                                        obj.Rating, obj.RatingID, obj.Address, obj.Comments, obj.CreationID, obj.CreationIP};

            int result = DAL.ExecuteNonQuery("AddClient", parameters, parameterValues);
            return result;
        }

        public List<Client.Clients> GetAllClients()
        {
            ds = DAL.GetDataset("GetAllClients");

            List<Client.Clients> list = new List<Client.Clients>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Client.Clients obj = new Client.Clients();
                obj.ID = Convert.ToInt32(dr["ID"].ToString());
                obj.Name = dr["NAME"].ToString();
                obj.PersonName = dr["PERSONNAME"].ToString();
                obj.MobileNo = dr["MOBILENUMBER"].ToString();
                obj.ContactNo = dr["CONTACTNUMBER"].ToString();
                obj.Address = dr["ADDRESS"].ToString();
                obj.Rating = dr["RATING"].ToString();
                obj.Comments = dr["COMMENTS"].ToString();
                list.Add(obj);
            }
            return list;
        }

        public Client.Clients GetSingleClients(int ClientID)
        {
            string[] parameters = { "@ClientID" };
            object[] paramValues = { ClientID };
            dt = DAL.GetDatatable("GetAllClients", parameters, paramValues);

            Client.Clients obj = new Client.Clients();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];                
                obj.ID = Convert.ToInt32(dr["ID"].ToString());
                obj.Name = dr["NAME"].ToString();
                obj.PersonName = dr["PERSONNAME"].ToString();
                obj.MobileNo = dr["MOBILENUMBER"].ToString();
                obj.ContactNo = dr["CONTACTNUMBER"].ToString();
                obj.Address = dr["ADDRESS"].ToString();
                obj.Rating = dr["RATING"].ToString();
                obj.Comments = dr["COMMENTS"].ToString();
            }
            return obj;
        }

        public void RemoveClient(int ClientID, int UpdatedID, string UpdatedIP)
        {
            string[] parameters = { "@ClientID", "@updatedByID", "@UpdatedByIP" };
            object[] parameterValues = { ClientID, UpdatedID, UpdatedIP };
            DAL.ExecuteNonQuery("RemoveClient", parameters, parameterValues);
        }
    }
}
