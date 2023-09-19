using System.Text;
using System.IO;
using System.ComponentModel.Design;

namespace ClientTicket
{
    internal class Program
    {
        private static string settings = string.Empty;
        private static string stuffID = string.Empty;
        private static string name = string.Empty;
        private static string eMail = string.Empty;
        private static int index = 2000;


        static void Main()
        {
            Console.WriteLine("Checking info");
            Ticket t;
            if (File.Exists("cache.dat"))
            {
                try
                {
                    settings = File.ReadAllText("cache.dat");
                    Directory.SetCurrentDirectory(settings);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    try
                    {
                        File.Delete("cache.dat");
                    }
                    catch (Exception _e)
                    {
                        Console.WriteLine(_e.Message);
                    }
                    EmptyData();
                }
            }
            else
            {
                EmptyData();
            }
            FindTickets();
            Console.WriteLine("Log in");
            while (true)
            {
                Console.WriteLine("Please, enter your first name");
                name = Console.ReadLine() + "";
                if (name == "")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (!File.Exists(settings + "\\" + "Accounts" + "\\" + name + ".txt"))
            {
                Console.WriteLine("You don't have account yet. Please, place account's data into chosen folder to solve the problem");
                Console.WriteLine("Missing filee with path:");
                Console.WriteLine(settings + "\\" + "Accounts" + "\\" + name + ".txt");
                return;
            }
            string[] s;
            try
            {
                s = File.ReadAllLines(settings + "\\" + "Accounts" + "\\" + name + ".txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Access denied");
                return;
            }
            string p;
            while (true)
            {
                Console.WriteLine("Enter your password");
                p = Console.ReadLine() + "";
                if (p == s[0])
                {
                    break;
                }
                Console.WriteLine("Wrong password");
            }
            Console.Write("Welcome, " + name);
            stuffID = s[1];
            eMail = s[2];

            while (true)
            {
                if(File.Exists(settings + "\\" + "Created" + "\\" + index))
                {
                    index++;
                }
                else
                {
                    break;
                }
            }
            string s1, v;
            while (true)
            {
                Console.WriteLine("------Enter number to: ------");
                Console.WriteLine("0. Close program");
                Console.WriteLine("1. Show info");
                Console.WriteLine("2. Create task");
                Console.WriteLine("3. Close task");
                Console.WriteLine("4. Open task again");
                Console.WriteLine("5. Provide a response");
                s1 = Console.ReadLine() + "1";
                if (s1[0] == '0')
                {
                    return;
                }
                else if (s1[0] == '1')
                {
                    Console.WriteLine("Tickets created" + Directory.GetFiles(settings + "\\" + "Created").Length);
                    Console.WriteLine("Tickets resolved" + Directory.GetFiles(settings + "\\" + "Resolved").Length);
                    Console.WriteLine("Tickets to resolve" + Directory.GetFiles(settings + "\\" + "To solve").Length);
                }
                else if (s1[0] == '2')
                {
                    Console.WriteLine("Enter descriprion of a problem");
                    Console.WriteLine("or write 0 (zero) if you want to change a password");
                    v = Console.ReadLine() + "";
                    if (v == "0")
                    {
                        File.Delete(settings + "\\" + "Accounts" + "\\" + name + ".txt");
                        File.WriteAllLines(settings + "\\" + "Accounts" + "\\" + name + ".txt", new string[] { stuffID[0].ToString() + stuffID[1] + name[0] + name[1] + name[2], stuffID, eMail });
                        t = new Ticket(index, name, stuffID, eMail, "Password change", "New password generated: " + stuffID[0].ToString() + stuffID[1] + name[0] + name[1] + name[2], false);
                        SaveTicket("Created", t);
                        SaveTicket("Resolved", t);
                        index++;
                        continue;
                    }
                    t = new(index, name, stuffID, eMail, v);
                    SaveTicket("Created", t);
                    SaveTicket("To solve", t);
                    index++;
                }
                else if (s1[0] == '3' || s1[0] == '4' || s1[0] == '5')
                {
                    TicketController("Show list of all unclosed tickets", s1[0]);
                }

            }
        }

        private static string[] GetInfo(string path)
        {
            return Directory.GetFiles(settings + "\\" + path);
        }

        private static void TicketController(string text, char choice)
        {
            string keyword;

            if (choice == '3')
            {
                keyword = "Resolved";
            }
            else if (choice == '4')
            {
                keyword = "To solve";
            }
            else
            {
                keyword = "Created";
            }

            Console.WriteLine("0. " + text);
            Console.WriteLine("1. Skip and move to entering number of ticket that you want to close");
            string v = Console.ReadLine() + "0";
            if (v[0] == '0')
            {
                string[] names = GetInfo(keyword);
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine(i + ". " + names[i]);
                    try
                    {
                        Console.WriteLine(File.ReadAllText(settings + "\\" + keyword + "\\" + names[i].Split('.')[0]));
                    } catch (Exception e) { Console.WriteLine(e.Message); }
                }
            }
            Console.WriteLine("Choose ID of ticket");
            v = Console.ReadLine() + "";
            if(v == "")
            {
                return;
            }
            string[] data;
            try
            {
                data = File.ReadAllLines(settings + "\\" + keyword + "\\" + v + ".txt");
                for (int i = 0;i < data.Length;i++)
                {
                    data[i] = data[i].Split(" ", 1)[1];
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return; }
            try
            {
                bool b = false;
                if (data[6] == "Open")
                {
                    b = true;
                }
                Ticket t = new(Convert.ToInt32(data[0]), data[1], data[2], data[3], data[4], data[5], b);
                if(keyword == "Resolved")
                {
                    t.SetStatus(false);
                    File.Delete(settings + "\\" + keyword + "\\" + t.GetId().ToString() + ".txt");
                    File.WriteAllText(settings + "\\" + "To solve" + "\\" + t.GetId().ToString() + ".txt", t.GetInfo());
                }
                else if (keyword == "To solve")
                {
                    t.SetStatus(true);
                    File.Delete(settings + "\\" + keyword + "\\" + t.GetId().ToString() + ".txt");
                    File.WriteAllText(settings + "\\" + "Resolved" + "\\" + t.GetId().ToString() + ".txt", t.GetInfo());
                }
                else
                {
                    Console.WriteLine("Enter response");
                    var _sss = Console.ReadLine() + "";
                    t.SetResponse(_sss);
                    if(File.Exists(settings + "\\" + "Resolved" + "\\" + t.GetId().ToString() + ".txt"))
                    {
                        File.WriteAllText(settings + "\\" + "Resolved" + "\\" + t.GetId().ToString() + ".txt", t.GetInfo());
                    }
                    if (File.Exists(settings + "\\" + "To solve" + "\\" + t.GetId().ToString() + ".txt"))
                    {
                        File.WriteAllText(settings + "\\" + "To solve" + "\\" + t.GetId().ToString() + ".txt", t.GetInfo());
                    }
                }
                File.WriteAllText(settings + "\\" + "Created" + "\\" + t.GetId().ToString() + ".txt", t.GetInfo());
            } catch (Exception e) { Console.WriteLine(e.Message); return; }
        }

        private static void SaveTicket(string savePath, Ticket ticket)
        {
            File.WriteAllText(settings + "\\" + savePath + "\\" + index + ".txt", ticket.GetInfo());
        }

        private static void FindTickets()
        {
            try
            {
                if (!Directory.Exists(settings + "\\" + "Resolved"))
                {
                    Directory.CreateDirectory(settings + "\\" + "Resolved");
                }
                if (!Directory.Exists(settings + "\\" + "Created"))
                {
                    Directory.CreateDirectory(settings + "\\" + "Created");
                }
                if (!Directory.Exists(settings + "\\" + "To solve"))
                {
                    Directory.CreateDirectory(settings + "\\" + "To solve");
                }
                if (!Directory.Exists(settings + "\\" + "Accounts"))
                {
                    Directory.CreateDirectory(settings + "\\" + "Accounts");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); Console.WriteLine("Access denied"); throw; }


        }

        private static void EmptyData()
        {
            string choice, s;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("No data found. This is a first start of a program. Do you wish to change the path?");
                    Console.WriteLine("Enter number to choose variant");
                    Console.WriteLine("1. Use current path");
                    Console.WriteLine(Directory.GetCurrentDirectory());
                    Console.WriteLine("2. Choose your path");
                    choice = Console.ReadLine() + "_";
                    if (choice[0] == '1')
                    {
                        Console.WriteLine("Choosen current path");
                        break;
                    }
                    else if (choice[0] == '2')
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter 0 to return to main menu");
                            s = Console.ReadLine() + "";
                            if (s == "")
                            {
                                continue;
                            }

                            if (s[0] == '0')
                            {
                                break;
                            }
                            else
                            {
                                try
                                {
                                    Directory.SetCurrentDirectory(Console.ReadLine() + "");
                                    Console.WriteLine(Directory.GetCurrentDirectory());
                                    break;
                                }
                                catch
                                {
                                    Console.Write("Invalid path");
                                }
                            }
                        }

                    }
                }

                try
                {

                    settings = Directory.GetCurrentDirectory() + @"\settings";
                    if (!Directory.Exists(settings))
                    {
                        Directory.CreateDirectory(settings);
                    }

                    File.WriteAllText("cache.dat", settings);
                    Directory.SetCurrentDirectory(settings);

                    break;
                }
                catch { Console.WriteLine("Access denied. Choose another path"); }
            }
        }
    }
}