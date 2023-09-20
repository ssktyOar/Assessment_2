using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightEngine.Physics;

namespace LightEngine.Core
{
    public abstract class Creature
    {
        public readonly Area world;

        public int positionX { get; private set; }
        public int positionY { get; private set; }
        public int positionZ { get; private set; }

        public int energy { get; private set; }

        public int currentHealth { get; private set; }
        public int materials { get; private set; }
        public float coefficient { get; private set; }

        public byte[,,] eyes = new byte[3, 3, 3];

        readonly List<int> intellect = new();

        public Creature(Area world, int x, int y, int z, int energy, float coefficient)
        {
            this.world = world;
            positionX = x;
            positionY = y;
            positionZ = z;
            this.energy = energy;
            this.coefficient = coefficient;
        }

        public abstract void Work();

        public abstract void See();

        public abstract void Replicate();

        public abstract void Regenerate();

        public abstract void Move();

        public abstract string Save();
    }
}
