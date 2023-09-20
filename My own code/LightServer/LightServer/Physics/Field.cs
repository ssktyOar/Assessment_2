using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightServer.Physics
{
    internal class Field
    {
        internal readonly Dictionary<float, Contact> contacts = new(100);

        internal void Contact()
        {
            foreach (Contact contact in contacts.Values)
            {
                foreach(Contact contact1 in contacts.Values)
                {
                    if (contact.Contacted(contact1.Hash) || contact.Hash == contact1.Hash)
                    {
                        continue;
                    }
                    contact.TryContact(contact1);
                }
            }
        }
    }
}
