using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightEngine.Physics
{
    public class ActiveObject
    {
        Area area;

        private string name = string.Empty;

        float posX;
        float posY;
        float posZ;

        float posSpeedX;
        float posSpeedY;
        float posSpeedZ;

        float mass;
        float radius;
        float radiusR;

        public ActiveObject(Area area, float pos, float mass, string name, float radius)
        {
            this.area = area;
            posX = pos;
            posY = pos;
            posZ = pos;
            this.mass = mass;
            this.name = name;
            this.radius = radius;
            radiusR = radius * radius;
        }

        public ActiveObject(Area area, float x, float y, float z, float mass, string name, float radius)
        {
            this.area = area;
            posX = x;
            posY = y;
            posZ = z;
            this.mass = mass;
            this.name = name;
            this.radius = radius;
            radiusR = radius*radius;
        }

        public ActiveObject(Area area, string name, float x, float y, float z, float speedX, float speedY, float speedZ, float mass, float radius)
        {
            this.area = area;
            posX = x;
            posY = y;
            posZ = z;
            posSpeedX = speedX;
            posSpeedY = speedY;
            posSpeedZ = speedZ;
            this.mass = mass;
            this.name = name;
            this.radius = radius;
            radiusR = radius * radius;
        }

        public void SetParameters(float x, float y, float z, float mass, string name)
        {
            posX = x;
            posY = y;
            posZ = z;
            this.mass = mass;
            this.name = name;
        }

        public (float, float, float, float, string) GetParameters()
        {
            return (posX, posY, posZ, mass, name);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetPosition(float x, float y, float z)
        {
            posX = x;
            posY = y;
            posZ = z;
        }

        public (float, float, float) GetPosition()
        {
            return (posX, posY, posZ);
        }

        public (float, float, float, float) GetContact()
        {
            return (posX, posY, posZ, radiusR);
        }

        public void Move()
        {

            posX += posSpeedX;
            posY += posSpeedY;
            posZ += posSpeedZ;
        }

        public void AddForce(float x, float y, float z)
        {
            posSpeedX += (x / mass);
            posSpeedY += (y / mass);
            posSpeedZ += (z / mass);
        }

        public (float, float, float) GetForce()
        {
            return (posSpeedX * mass, posSpeedY * mass, posSpeedZ * mass);
        }

        public void SetRadius(float radius)
        {
            this.radius = radius;
            radiusR = radius*radius;
        }

        public float GetRadius()
        {
            return radius;
        }

        public void Contact(ActiveObject activeObject)
        {
            if (activeObject.radiusR + radiusR <= (activeObject.posX - posX) * (activeObject.posX - posX) + (activeObject.posY - posY)*(activeObject.posY - posY) + (activeObject.posZ * posZ)*(activeObject.posZ * posZ) )
            {
                var (x, y, z) = activeObject.GetForce();
                posSpeedX += (x / mass);
                posSpeedY += (y / mass);
                posSpeedZ += (z / mass);
            }
        }

        public string[] Save()
        {
            return new string[9] { name, posX.ToString(), posY.ToString(), posZ.ToString(), posSpeedX.ToString(), posSpeedY.ToString(), posSpeedZ.ToString(), mass.ToString(), radius.ToString()};
        }
    }
}
