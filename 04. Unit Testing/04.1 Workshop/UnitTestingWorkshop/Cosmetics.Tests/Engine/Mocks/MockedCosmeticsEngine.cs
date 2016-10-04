using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Engine;

namespace Cosmetics.Tests.Engine.Mocks
{
    internal class MockedCosmeticsEngine : CosmeticsEngine
    {
        public MockedCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser) 
            : base(factory, shoppingCart, commandParser)
        {
            
        }

        public IDictionary<string, ICategory> Categories => base.categories;
        public IDictionary<string, IProduct> Products => base.products;
    }
}
