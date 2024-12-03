using Process.NET;

namespace LordsMobileAPI
{
    public class Resources
    {
        private nint baseAddress = -1;

        private nint goldAddres = -1;
        private nint oreAddres = -1;
        private nint woodAddres = -1;
        private nint stoneAddres = -1;
        private nint foodAddres = -1;

        private ProcessSharp processSharp;
        public Resources(LordsMobile lordsMobile)
        {
            this.processSharp = lordsMobile.GetProcessSharp();

            try
            {
                baseAddress = processSharp.Memory.Read<nint>(Utils.ReadOffset(lordsMobile.modules.GameAssembly, lordsMobile.ofsetts.GetResourceInfo(), processSharp));
                this.goldAddres = Utils.ReadOffset(baseAddress, lordsMobile.ofsetts.GetGold(), processSharp);
                this.oreAddres = Utils.ReadOffset(baseAddress, lordsMobile.ofsetts.GetOre(), processSharp);
                this.woodAddres = Utils.ReadOffset(baseAddress, lordsMobile.ofsetts.GetWood(), processSharp);
                this.stoneAddres = Utils.ReadOffset(baseAddress, lordsMobile.ofsetts.GetStone(), processSharp);
                this.foodAddres = Utils.ReadOffset(baseAddress, lordsMobile.ofsetts.GetFood(), processSharp);
            }
            catch { }
        }
        public double gold
        {
            get
            {
                try { return processSharp.Memory.Read<double>(goldAddres); } catch { return 0; }
            }
            set
            {
                try { processSharp.Memory.Write<double>(goldAddres, value); } catch { } // Visual only
            }
        }
        public double ore
        {
            get
            {
                try { return processSharp.Memory.Read<double>(oreAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<double>(oreAddres, value); } catch { } // Visual only 
            }
        }
        public double wood
        {
            get
            {
                try { return processSharp.Memory.Read<double>(woodAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<double>(woodAddres, value); } catch { } // Visual only
            }
        }
        public double stone
        {
            get
            {
                try { return processSharp.Memory.Read<double>(stoneAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<double>(stoneAddres, value); } catch { } // Visual only
            }
        }
        public double food
        {
            get
            {
                try { return processSharp.Memory.Read<double>(foodAddres); } catch { return 0;  }
            }
            set
            {
                try { processSharp.Memory.Write<double>(foodAddres, value); } catch { } // Visual only
            }
        }
    }
}
