using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class VenueAccessor : IVenueAccessor
    {
        /// <summary>
        /// Jacob Lindauer
        /// Created: 2023/04/09
        /// 
        /// Retrieves Venue List from Venue Table
        /// </summary>
        public List<Venue> SelectAllVenues()
        {
            List<Venue> venueList = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_venues";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                venueList = new List<Venue>();

                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venue addVenue = new Venue();
                        addVenue.VenueID = Convert.ToInt32(0);
                        if (reader.IsDBNull(1))
                        {
                            addVenue.VenueName = "";
                        }
                        else
                        {
                            addVenue.VenueName = reader.GetString(1);

                        }
                        if (reader.IsDBNull(2))
                        {
                            addVenue.Parking = "";
                        }
                        else
                        {
                            addVenue.Parking = reader.GetString(2);

                        }
                        if (reader.IsDBNull(3))
                        {
                            addVenue.Description = "";
                        }
                        else
                        {
                            addVenue.Description = reader.GetString(3);

                        }
                        if (reader.IsDBNull(4))
                        {
                            addVenue.Location = "";
                        }
                        else
                        {
                            addVenue.Location = reader.GetString(4);

                        }
                        if (reader.IsDBNull(5))
                        {
                            addVenue.ZipCode = null;
                        }
                        else
                        {
                            addVenue.ZipCode = reader.GetInt32(5);

                        }
                        if (reader.IsDBNull(6))
                        {
                            addVenue.City = "";
                        }
                        else
                        {
                            addVenue.City = reader.GetString(6);

                        }
                        addVenue.State = reader.GetString(7);
                        venueList.Add(addVenue);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return venueList;
        }
    }
}
