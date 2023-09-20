using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightServer.Physics
{
    internal abstract class Contact
    {
        internal float Hash { private set; get; }

        private readonly Dictionary<float, Contact> contacts = new();

        protected float mass;

        protected float radius;
        protected float dRadius;

        protected float locPosX;
        protected float locPosY;
        protected float locPosZ;

        protected float posX;
        protected float posY;
        protected float posZ;

        protected float locRotX;
        protected float locRotY;
        protected float locRotZ;

        protected float rotX;
        protected float rotY;
        protected float rotZ;

        protected float velX;
        protected float velY;
        protected float velZ;

        protected float velRotX;
        protected float velRotY;
        protected float velRotZ;

        private float[]? pos;

        internal void TryContact(Contact contact)
        {
            pos = contact.GetPos();
            if (dRadius + pos[3] >= (pos[0] - posX) * (pos[0] - posX) + (pos[1] - posY) * (pos[1] - posY) + (pos[2] - posZ) * (pos[2] - posZ))
            {
                Contact1(contact);
            }
        }

        internal abstract void Contact1(Contact contact);

        internal float[] GetPos()
        {
            return new float[] { posX, posY, posZ, dRadius };
        }
        
        internal float[] GetRot()
        {
            return new float[] { rotX, rotY, rotZ };
        }

        internal bool Contacted(float c)
        {
            return contacts.ContainsKey(c);
        }

        internal void AcceptResult(float velX, float velY, float velZ, float velRotX, float velRotY, float velRotZ)
        {
            this.velX = velX;
            this.velY = velY;
            this.velZ = velZ;
            this.velRotX = velRotX;
            this.velRotY = velRotY;
            this.velRotZ = velRotZ;
        }
    }
}
