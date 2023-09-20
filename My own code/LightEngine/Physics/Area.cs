using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightEngine.Core;

namespace LightEngine.Physics
{
    public class Area
    {

        public readonly int xPosition;
        public readonly int yPosition;
        public readonly int zPosition;

        public readonly List<ActiveObject> activeObjects = new();

        public Area(List<ActiveObject> activeObjects, int x, int y, int z)
        {
            this.activeObjects = activeObjects;
            xPosition = x;
            yPosition = y;
            zPosition = z;
        }

        public List<string> SaveObjects()
        {
            List<string> s = new()
            {
                xPosition.ToString() + " " + yPosition.ToString() + " " + zPosition.ToString(),
                "START_SAVE_OBJECTS"
            };
            foreach (var activeObject in activeObjects)
            {
                s.AddRange(activeObject.Save());
            }
            s.Add("END_SAVE_OBJECTS");

            return s;
        }
    }
}
