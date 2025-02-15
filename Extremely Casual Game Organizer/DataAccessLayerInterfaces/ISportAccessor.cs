﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface ISportAccessor
    {
        List<Sport> SelectAllSports();

        string SelectSportBySportID(int SportID);
    }
}
