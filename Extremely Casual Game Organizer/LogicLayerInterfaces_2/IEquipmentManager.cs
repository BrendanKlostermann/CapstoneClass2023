/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// 
/// </summary>
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IEquipmentManager
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/04
        /// 
        /// Adding new equipment for a team
        /// </summary>
        int AddTeamEquipment(Equipment equipmentList);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/04
        /// 
        /// Update the name, the quantity and/or sport of the equipment
        /// </summary>
        int UpdateTeamEquipment(Equipment equipmentList);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove the equipment that is no more needed
        /// </summary
        int DeleteTeamEquipment(Equipment equipmentList);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/04
        /// 
        /// Get all equipments by team_id
        /// </summary>
        List<Equipment> RetrieveEquipmentListsByTeamID(int team_id, string name);
    }
}
