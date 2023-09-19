using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTicket
{
    internal class Ticket
    {
        private readonly int ticketNumber;
        private readonly string ticketCreator;
        private readonly string stuffID;
        private readonly string eMailAddress;
        private readonly string description;
        private string response = "Not Yet Provided";
        private string ticketStatus = "Open";

        public Ticket(int ticketNumber, string name, string stuffID, string eMailAddress, string description)
        {
            this.ticketNumber = ticketNumber;
            ticketCreator = name;
            this.stuffID = stuffID;
            this.eMailAddress = eMailAddress;
            this.description = description; 
        }

        public Ticket(int ticketNumber, string name, string stuffID, string eMailAddress, string description, string response, bool ticketStatus)
        {
            this.ticketNumber = ticketNumber;
            ticketCreator = name;
            this.stuffID = stuffID;
            this.eMailAddress = eMailAddress;
            this.description = description;
            this.response = response;
            SetStatus(ticketStatus);
        }

        public void SetResponse(string s)
        {
            response = s;
        }

        public void SetStatus(bool b)
        {
            if (b)
            {
                ticketStatus = "Open";
            }
            else
            {
                ticketStatus = "Closed";
            }
        }

        public int GetId()
        {
            return ticketNumber;
        }

        public string GetInfo()
        {
            return "Ticket_Number: " + ticketNumber + "\\" + "Ticket_Creator: " + ticketCreator + "\\" + "StuffID: " + stuffID + "\\" + "Email_Address: " + eMailAddress + "\\" + "Description: " + description + "\\" + "Response: " + response + "\\" + "Ticket_Status: " + ticketStatus;
        }

    }
}
