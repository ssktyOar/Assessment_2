using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightEngine.Core
{
    public class CORE
    {
        public readonly string path;



        public CORE(string path)
        {
            this.path = path;
        }

        public void Start()
        {

        }
    }
    class ActiveMemory
    {
        public byte[] memory;
        public ActiveMemory(byte[] M)
        {
            memory = M;
        }
    }

}
