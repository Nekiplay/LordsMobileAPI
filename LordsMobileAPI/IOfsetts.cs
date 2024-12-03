using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobileAPI
{
    public interface IOffsets
    {
        public int[] GetUserInfo();

        public int[] GetStamina();
        public int[] GetGems();
        public int[] GetPower();
        public int[] GetEnergy();
        public int[] GetArmyStats();

        public int[] GetResourceInfo();
        public int[] GetGold();
        public int[] GetOre();
        public int[] GetWood();
        public int[] GetStone();
        public int[] GetFood();
    }
}
