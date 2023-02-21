/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the interface for the league accessor class.
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface ILeagueAccessor
    {
        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method creates a database connection and selects a list of all leagues in the database.
        /// </summary>
        ///
        /// <exception cref="SQLException">Select fails </exception>
        /// <returns>List of League objects</returns>
        List<League> SelectListOfLeagues();
    }
}
