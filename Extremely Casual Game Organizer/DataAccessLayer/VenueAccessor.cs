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
        /// Created: 2023/04/04
        /// 
        /// Inserts Venue into Venue Table
        /// </summary>
        public int InsertVenue(Venue venue)
        {
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_insert_venue";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            if (venue.VenueName == null || venue.VenueName == "")
            {
                cmd.Parameters.AddWithValue("@venue_name", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@venue_name", venue.VenueName);
            }

            if (venue.Parking == null || venue.Parking == "")
            {
                cmd.Parameters.AddWithValue("@parking", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parking", venue.Parking);
            }

            if (venue.Description == null || venue.Description == "")
            {
                cmd.Parameters.AddWithValue("@description", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@description", venue.Description);
            }

            if (venue.Location == null || venue.Location == "")
            {
                cmd.Parameters.AddWithValue("@location", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@location", venue.Location);
            }

            cmd.Parameters.AddWithValue("@zip_code", venue.ZipCode);

            try
            {
                conn.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

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
                        addVenue.VenueID = reader.GetInt32(0);
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

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/*15/04
        /// 
        /// Method takes a zipcode input and returns hash table of zipcode information
        /// 
        /// TKey:
        /// zip_code
        /// City
        /// State
        /// 
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public Dictionary<string, object> SelectZipCodeDetails(int zipcode)
        {
            Dictionary<string, object> zipcodeInfo = new Dictionary<string, object>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_zip_code_details";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@zipcode", zipcode);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        zipcodeInfo = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return zipcodeInfo;
        }
    }
}
