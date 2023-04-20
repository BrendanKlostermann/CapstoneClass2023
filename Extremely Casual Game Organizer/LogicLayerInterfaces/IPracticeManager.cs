using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IPracticeManager
    {
        int CreatePractice(Practice practice);

        int RemovePractice(Practice practice);

        List<Practice> SelectPractices(int teamID);
    }
}
