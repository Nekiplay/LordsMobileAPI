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
            try
            {
                userAddres = processSharp.Memory.Read<nint>(Utils.ReadOffset(lordsMobile.modules.GameAssembly, lordsMobile.ofsetts.GetUserInfo(), processSharp));
                this.staminaAddres = Utils.ReadOffset(userAddres, lordsMobile.ofsetts.GetStamina(), processSharp);
                this.gemsAddres = Utils.ReadOffset(userAddres, lordsMobile.ofsetts.GetGems(), processSharp);
                this.powerAddres = Utils.ReadOffset(userAddres, lordsMobile.ofsetts.GetPower(), processSharp);
                this.energyAddres = Utils.ReadOffset(userAddres, lordsMobile.ofsetts.GetEnergy(), processSharp);
            }
            catch { }
        }
        public int power
        {
            get
            {
                try { return processSharp.Memory.Read<int>(powerAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<int>(powerAddres, value); } catch { } // Visual only
            }
        }
        public int energy
        {
            get
            {
                try { return processSharp.Memory.Read<int>(energyAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<int>(energyAddres, value); } catch { } // Visual only
            }
        }
        public int gems
        {
            get
            {
                try { return processSharp.Memory.Read<int>(gemsAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<int>(gemsAddres, value); } catch { } // Visual only
            }
        }
        public int stamina
        {
            get
            {
                try { return processSharp.Memory.Read<int>(staminaAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<int>(staminaAddres, value); } catch { } // Visual only
            }
        }
    }
}
