using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightEngine.Physics
{
    internal class ActionCO
    {
        private readonly Dictionary<string, ActiveObject> activeObjects = new();

        public void AddObject(ActiveObject activeObject)
        {
            activeObjects.Add(activeObject.GetName(), activeObject);
        }

        public void RemoveObject(string name)
        {
            activeObjects.Remove(name);
        }

        public void Action()
        {
            foreach (ActiveObject activeObject in activeObjects.Values) 
            {
                activeObject.Move();
            }
        }
    }
}
