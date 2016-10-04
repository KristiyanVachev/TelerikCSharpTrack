using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.Mocks
{
    public class MockedTeleportStation : TeleportStation
    {
        public MockedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) 
            : base(owner, galacticMap, location)
        {
        }
        public IResources Resources
        {
            get { return base.resources; }
        }

        public IBusinessOwner Owner
        {
            get { return base.owner; }
        }
        public ILocation Location
        {
            get { return base.location; }
        }
        public IEnumerable<IPath> GalacticMap
        {
            get { return base.galacticMap; }
        }
    }
}
