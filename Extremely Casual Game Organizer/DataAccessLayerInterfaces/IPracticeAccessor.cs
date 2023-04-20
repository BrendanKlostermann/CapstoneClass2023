/// Nick Vroom
/// Created: 2023/04/11
/// 
/// This class is the interface for the PracticeAccessor class.
/// 
/// </summary>
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IPracticeAccessor
    {
        int CreatePracticeByTeamID(Practice practice);

        int deletePracticeByID(Practice practiceID);

        List<Practice> SelectAllPractices(int teamID);
    }
}
