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
            baseAddress = processSharp.Memory.Read<nint>(Utils.ReadOffset(lordsMobile.modules.GameAssembly, Offsets.resourceinfo, processSharp));
            this.goldAddres = Utils.ReadOffset(baseAddress, Offsets.gold, processSharp);
            this.oreAddres = Utils.ReadOffset(baseAddress, Offsets.ore, processSharp);
            this.woodAddres = Utils.ReadOffset(baseAddress, Offsets.wood, processSharp);
            this.stoneAddres = Utils.ReadOffset(baseAddress, Offsets.stone, processSharp);
            this.foodAddres = Utils.ReadOffset(baseAddress, Offsets.food, processSharp);
        }
        public double gold
        {
            get
            {
                return processSharp.Memory.Read<double>(goldAddres);
            }
            set
            {
                processSharp.Memory.Write<double>(goldAddres, value); // Visual only
            }
        }
        public double ore
        {
            get
            {
                return processSharp.Memory.Read<double>(oreAddres);
            }
            set
            {
                processSharp.Memory.Write<double>(oreAddres, value); // Visual only
            }
        }
        public double wood
        {
            get
            {
                return processSharp.Memory.Read<double>(woodAddres);
            }
            set
            {
                processSharp.Memory.Write<double>(woodAddres, value); // Visual only
            }
        }
        public double stone
        {
            get
            {
                return processSharp.Memory.Read<double>(stoneAddres);
            }
            set
            {
                processSharp.Memory.Write<double>(stoneAddres, value); // Visual only
            }
        }
        public double food
        {
            get
            {
                return processSharp.Memory.Read<double>(foodAddres);
            }
            set
            {
                processSharp.Memory.Write<double>(foodAddres, value); // Visual only
            }
        }
    }
}
