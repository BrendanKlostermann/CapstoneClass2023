/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
using DataAccessLayer;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class EquipmentManager : IEquipmentManager
    {

        private IEquipmentAccessor _equipmentAccessor= null;

        public EquipmentManager()
        {
            _equipmentAccessor = new EquipmentAccessor();
        }
        public EquipmentManager(IEquipmentAccessor memberAccessor)
        {
            _equipmentAccessor = memberAccessor;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Add a team to a tournament
        /// </summary>
        public int AddTeamEquipment(Equipment equipmentList)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _equipmentAccessor.AddTeamEquipment(equipmentList);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot add a team");
            }
            return rowsAffected;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove a team from tournament
        /// </summary>
        public int DeleteTeamEquipment(Equipment equipmentList)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _equipmentAccessor.DeleteTeamEquipment(equipmentList);
            }
            catch (Exception)
            {
                throw new ApplicationException("Delete Failed");
            }
            return rowsAffected;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get the list of equipments by teamID
        /// </summary>
        public List<Equipment> RetrieveEquipmentListsByTeamID(int team_id, string name)
        {
            List<Equipment> equipmentLists = null;

            try
            {
                equipmentLists = _equipmentAccessor.SelectEquipmentListsByTeamID(team_id, name);
            }
            catch (Exception)
            {
                throw new ApplicationException("Equipment not found.");
            }
            return equipmentLists;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update a team equipment
        /// </summary>
        public int UpdateTeamEquipment(Equipment equipmentList)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _equipmentAccessor.UpdateTeamEquipment(equipmentList);
            }
            catch (Exception)
            {
                throw new ApplicationException("Update failed!");
            }
            return rowsAffected;
        }
    }
}
