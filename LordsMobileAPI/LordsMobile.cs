using Process.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobileAPI
{
    public class LordsMobile
    {
        private System.Diagnostics.Process _process;
        private ProcessSharp _processSharp;
        public readonly IOffsets ofsetts;
        public Modules modules;

        public User user;
        public Resources resources;
        public LordsMobile(System.Diagnostics.Process process, IOffsets ofsetts)
        {
            this.ofsetts = ofsetts;
            this._process = process;
            this._processSharp = new ProcessSharp(_process, Process.NET.Memory.MemoryType.Remote);

            this.modules = new Modules(_processSharp);
            this.user = new User(this);
            this.resources = new Resources(this);
        }

        public System.Diagnostics.Process GetProcess()
        {
            return _process;
        }
        public ProcessSharp GetProcessSharp()
        {
            return _processSharp;
        }
    }
}
