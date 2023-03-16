
/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{

    /// <summary>
    /// Heritier Otiom
    /// Created: 2023/01/31
    /// </summary>
    public class FakeEquipmentAccessor : IEquipmentAccessor
    {
        List<Equipment> _equipmentLists = new List<Equipment>();


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Constructor
        /// </summary>
        public FakeEquipmentAccessor()
        {
            _equipmentLists.Add(new Equipment()
            {
                EquipmentID = 100,
                Description = "Ball",
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball",
                Quantity = 10
            });
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Add a Team equipment
        /// </summary>
        public int AddTeamEquipment(Equipment equipmentList)
        {
            if(equipmentList.Description!=null && equipmentList.Description!=""
                && equipmentList.Quantity >= 0)
            {
                _equipmentLists.Add(equipmentList);
            }

            return _equipmentLists.Count;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove team Equipment
        /// </summary>
        public int DeleteTeamEquipment(Equipment equipmentList)
        {
            var equipments = _equipmentLists.Where(b => b.EquipmentID == equipmentList.EquipmentID).ToList();

            if (equipments == null || equipments.Count <= 0)
            {
                return 0;
            }

            int num = _equipmentLists.FindIndex(b => b.EquipmentID == equipmentList.EquipmentID);
            _equipmentLists.Remove(_equipmentLists[num]);
            return 1;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Selects all equipments by team_ID
        /// </summary>
        public List<Equipment> SelectEquipmentListsByTeamID(int team_id, string name)
        {
            var equipments = _equipmentLists.Where(b => b.TeamID == team_id && b.Description == name).ToList();

            if (equipments == null)
            {
                throw new ApplicationException("Equipment not found.");
            }

            return equipments;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update team equipment
        /// </summary>
        public int UpdateTeamEquipment(Equipment equipmentList)
        {
            var equipments = _equipmentLists.Where(b => b.EquipmentID == equipmentList.EquipmentID).ToList();

            if (equipments == null || equipments.Count<=0)
            {
                return 0;
            }

            if (equipmentList.Description != null && equipmentList.Description != ""
                && equipmentList.Quantity >= 0)
            {
                int num = _equipmentLists.FindIndex(b => b.EquipmentID == equipmentList.EquipmentID);
                _equipmentLists[num].Description = equipmentList.Description;
                _equipmentLists[num].SportName = equipmentList.SportName;
                _equipmentLists[num].Quantity = equipmentList.Quantity;
                _equipmentLists[num].SportID = equipmentList.SportID;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
