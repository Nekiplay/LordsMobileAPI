﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobileAPI
{
    public class OffsetsPC : IOffsets
    {
        private static int[] userinfo = new int[] { 0x03E32808, 0x50, 0x80, 0xBD0, 0xB8, 0x18 };
        private static int[] stamina = new int[] { 0x420 };
        private static int[] gems = new int[] { 0x464 };
        private static int[] power = new int[] { 0x4D8 };
        private static int[] energy = new int[] { 0x570 };
        private static int[] armyStatus = new int[] { 0xE44 };

        private static int[] resourceinfo = new int[] { 0x03E68790, 0xC0, 0xA8, 0xB8, 0x20, 0xD0 };
        private static int[] gold = new int[] { 0xDE0 };
        private static int[] ore = new int[] { 0xE30 };
        private static int[] wood = new int[] { 0xE80 };
        private static int[] stone = new int[] { 0xED0 };
        private static int[] food = new int[] { 0xF20 };

        #region User Info
        public int[] GetUserInfo()
        {
            return userinfo;
        }
        public int[] GetStamina()
        {
            return stamina;
        }
        public int[] GetGems()
        {
            return gems;
        }
        public int[] GetPower()
        {
            return power;
        }
        public int[] GetEnergy()
        {
            return energy;
        }
        public int[] GetArmyStats()
        {
            return armyStatus;
        }
        #endregion
        #region Resource Info
        public int[] GetResourceInfo()
        {
            return resourceinfo;
        }
        public int[] GetGold()
        {
            return gold;
        }
        public int[] GetOre()
        {
            return ore;
        }
        public int[] GetWood()
        {
            return wood;
        }
        public int[] GetStone()
        {
            return stone;
        }
        public int[] GetFood()
        {
            return food;
        }
        #endregion
    }
}
