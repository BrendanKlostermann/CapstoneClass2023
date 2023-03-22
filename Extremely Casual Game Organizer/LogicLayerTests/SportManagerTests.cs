using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;

namespace LogicLayerTests
{
    [TestClass]
    public class SportManagerTests
    {
        private SportManager _sportManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _sportManager = new SportManager(new SportAccessorFakes());
        }
    }
}
