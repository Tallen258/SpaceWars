using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars.Logic
{
    public interface IPurchaseable
    {
        int Cost { get; init; }
        string Name { get; }
        IEnumerable<string> PurchasePrerequisites { get; init; }
    }
}
