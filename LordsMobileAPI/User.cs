using Process.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobileAPI
{
    public class User
    {
        private nint userAddres = -1;

        private nint staminaAddres = -1;
        private nint gemsAddres = -1;
        private nint powerAddres = -1;
        private nint energyAddres = -1;

        private ProcessSharp processSharp;
        public User(LordsMobile lordsMobile)
        {
            this.processSharp = lordsMobile.GetProcessSharp();
            userAddres = processSharp.Memory.Read<nint>(Utils.ReadOffset(lordsMobile.modules.GameAssembly, Offsets.userinfo, processSharp));
            this.staminaAddres = Utils.ReadOffset(userAddres, Offsets.stamina, processSharp);
            this.gemsAddres = Utils.ReadOffset(userAddres, Offsets.gems, processSharp);
            this.powerAddres = Utils.ReadOffset(userAddres, Offsets.power, processSharp);
            this.energyAddres = Utils.ReadOffset(userAddres, Offsets.energy, processSharp);
        }
        public int power
        {
            get
            {
                return processSharp.Memory.Read<int>(powerAddres);
            }
            set
            {
                processSharp.Memory.Write<int>(powerAddres, value); // Visual only
            }
        }
        public int energy
        {
            get
            {
                return processSharp.Memory.Read<int>(energyAddres);
            }
            set
            {
                processSharp.Memory.Write<int>(energyAddres, value); // Visual only
            }
        }
        public int gems
        {
            get
            {
                return processSharp.Memory.Read<int>(gemsAddres);
            }
            set
            {
                processSharp.Memory.Write<int>(gemsAddres, value); // Visual only
            }
        }
        public int stamina
        {
            get
            {
                return processSharp.Memory.Read<int>(staminaAddres);
            }
            set
            {
                processSharp.Memory.Write<int>(staminaAddres, value); // Visual only
            }
        }
    }
}
