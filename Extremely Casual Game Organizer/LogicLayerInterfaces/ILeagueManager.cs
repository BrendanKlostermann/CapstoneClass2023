/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This is the interface class for the LeagueManager
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface ILeagueManager
    {
        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method calls the LeagueAccessor method SelectListOfLeagues and returns it to the 
        /// presentation layer. 
        /// </summary>
        /// 
        /// <returns>List of League objects</returns>
        List<League> RetrieveListOfLeagues();
	}
}
