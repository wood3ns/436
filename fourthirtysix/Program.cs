using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Proprietary code argarg if you aren't dr.noodles, or wood3n leave and stop being dumb and or stupid

namespace fourthirtysix
{
    class Program
    {
        // shit code 0/10

        #region Flags
        static bool flag_hardmode = false;
        static bool flag_hardmode_caught = false;

        static bool flag_online = false;
        static bool flag_online_caught = false;
        #endregion

        static void Main(string[] args)
        {
            Locations.InitializeMap();
            Items.InitializeItems();
            // THIS IS ONLY FOR TESTING PURPOSES. REMOVE NEXT LINE / COMMENT IT OUT WHEN RELEASING
            goto startzork;

            #region Loading/Splash

            Console.Title = "awfully chaotic";
            int previous = 0;
            try { previous = int.Parse(File.ReadAllText("System.FallLibrary.dll")); } catch { }
            File.WriteAllText("System.FallLibrary.dll", (previous + 1).ToString());
            if(File.Exists("System.FallLibrary.HardwareMode.dll")) { flag_hardmode = true; flag_hardmode_caught = true; }
            if(File.Exists("System.FallLibrary.OnlineServices.dll")) { flag_online_caught = true; }

            int superkey = new Random(Guid.NewGuid().GetHashCode()).Next(0, 10);
            for(int x = 0; x < superkey; x++)
            {
                Console.Beep();
                Thread.Sleep(500);
            }

            Console.WriteLine("progress does not save. do not exit.");
            Console.WriteLine("this is a game like zork except if you lose your computer will be unwillingly stress tested");
            Console.Write("press any key to agree: ");
            KeyCont();
            Console.Clear();
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("are u sure? (yes/no): ");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            if(input != "no")
            {
                Console.WriteLine("the only purpose of this failtrap is to teach you what happens if you fail.");
                Console.WriteLine("type no next time.");
                Fail();
            }

            #endregion

            #region Introduction

            #region Memorization Stage
            Console.WriteLine("good, then you're playing the game right.");
            Thread.Sleep(2000);
            Console.WriteLine("write everything down, or you will fail.");
            Thread.Sleep(2000);
            Console.WriteLine("you already missed one thing, i promise. don't miss this.");
            Thread.Sleep(2000);
            int superkeytwo = Rdm(2000);
            Console.WriteLine(superkeytwo);
            Thread.Sleep(500);
            Console.Clear();
            Console.Write("hope you didnt miss that: ");
            input = Console.ReadLine();
            if(input != superkeytwo.ToString())
            {
                Fail();
            }
            Console.Clear();
            Console.WriteLine("impressive, have you done this before? let's check");
            Thread.Sleep(2000);
            if(previous == 0) 
            { 
                Console.WriteLine("no? good job then. but i am gonna make ur life hell. hard mode enabled.");
                flag_hardmode = true;
                File.WriteAllText("System.FallLibrary.HardwareMode.dll","!dll");
            }
            else if(previous == 1) { Console.WriteLine("just once. well done."); }
            else { Console.WriteLine("hmm, shows you've done this " + previous + " times before. that is incredibly sad."); }
            if(flag_hardmode_caught)
            {
                Thread.Sleep(2000);
                Console.WriteLine("wait a second, did you die after hard mode? that's really sad. sorry, but it IS still enabled.");
            }
            Console.WriteLine("press a key.");
            KeyCont();
            Console.Clear();
            Console.WindowWidth = Console.WindowWidth + 3;
            Console.WriteLine("little more roomy. press a key.");
            KeyCont();

            #endregion

            #region Online Check (get name)
            Console.Clear();
            Console.WriteLine("i know everything about you. you live on your computer, and i know everything about your computer, and by extension, you");
            Thread.Sleep(2000);
            if (!flag_online_caught)
            {
                try
                {
                    WebClient c = new WebClient(); c.DownloadString("https://google.com/");
                    Console.WriteLine("you're playing online i see. hopefully with friends.");
                    File.WriteAllText("System.FallLibrary.OnlineServices.dll", "1");
                    Thread.Sleep(2000);
                    Console.WriteLine("unfortunately, you missed a critical step. will bite you in ass later, not now.");
                }
                catch
                {
                    Console.Title = "436";
                    Console.WriteLine("you're offline. just you and me i guess. my name is 436");
                }
            }
            else
            {
                try
                {
                    WebClient c = new WebClient(); c.DownloadString("https://google.com/");
                    Console.WriteLine("you're still playing online i see. hopefully with friends.");
                    File.WriteAllText("System.FallLibrary.OnlineServices.dll", "1");
                    Thread.Sleep(2000);
                    Console.WriteLine("you still messed up, go back.");
                }
                catch
                {
                    Console.WriteLine("i know what you did. you're offline because you missed that step and want to reconcile.");
                    Console.WriteLine("i remember. here's what i would've said:");
                    Console.Title = "436";
                    Console.WriteLine("you're offline. just you and me i guess. my name is 436");
                }
            }
            #endregion

            #region Who are you Stage
            Thread.Sleep(2000);
            Console.WriteLine("who are you?: ");
            input = Console.ReadLine();
            if(input == "436") { Fail(); }
            if(input == "-DUMP")
            {
                Console.Clear();
                Console.WriteLine("FLAG DUMP:");
                Console.WriteLine("hard mode: " + flag_hardmode);
                Console.WriteLine("hard mode caught: " + flag_hardmode_caught);
                Console.WriteLine("online mode: " + flag_online);
                Console.WriteLine("online mode caught: " + flag_online_caught);
                Console.ReadLine();
                input = "debugger";
            }
            Console.Write("hmmm. let me think about that.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(". hmmm...");
            Thread.Sleep(5000);
            Console.WriteLine("okay.");
            Thread.Sleep(3000);
            Console.WriteLine("after careful deliberation, i've decided.");
            Thread.Sleep(3000);
            Console.Write("i've decided that ");
            Thread.Sleep(3000);
            if (input == "436") { Console.WriteLine("YOU ARE NOT ME. DO NOT LIE NEXT TIME."); Thread.Sleep(1000); Fail(); }
            else if (input == "-DUMP")
            {
                Console.Clear();
                Console.WriteLine("FLAG DUMP:");
                Console.WriteLine("hard mode: " + flag_hardmode);
                Console.WriteLine("hard mode caught: " + flag_hardmode_caught);
                Console.WriteLine("online mode: " + flag_online);
                Console.WriteLine("online mode caught: " + flag_online_caught);
                Console.ReadLine();
                input = "debugger";
            }
            else if (input == Environment.UserName)
            {
                Console.WriteLine("i like you.");
                Thread.Sleep(2000);
                Console.Title = "436 & " + input + "'s Adventures; COPYRIGHT DO NOT REDISTRIBUTE 2106";
                Console.WriteLine("this can be our adventure.");
                Thread.Sleep(2000);
                Console.WriteLine("where are we going?");
                Thread.Sleep(2000);
                Console.WriteLine("i dont know, dont ask questions, just go with it, this whole adventure.");
                Thread.Sleep(2000);
                Console.WriteLine("so let's get going.");
                Thread.Sleep(3000);
                Console.Clear();
            }
            else { Console.WriteLine("YOU ARE NOT THEM. DO NOT LIE NEXT TIME."); Thread.Sleep(1000); Fail(); }
            #endregion

            // chapter 1 beginning
            Console.WriteLine("just walk through that door right there and we can get going.");
            goto startzork;

            #endregion

            #region Chapter I

            // literally zork murder your computer edition
            startzork:
            Locations.Set(Locations.CoolHouse);
            Items.Current.Add(Items.BagOfSprite,3);
            demo:
            Console.WriteLine(Locations.Get().FriendlyName);
            Console.WriteLine(Locations.Get().ID);
            Console.WriteLine(Locations.Get().Description);
            Console.WriteLine("where to?: ");
            input = Console.ReadLine();
            if(Locations.TryTravel(input))
            {
                goto demo;
            }
            else if(input.ToUpper() == "CHECK INVENTORY" || input.ToUpper() == "INVENTORY")
            {
                foreach(Item i in Items.Current.Collection.Keys)
                {
                    Console.WriteLine("ITEM: " + i.FriendlyName);
                    Console.WriteLine("DESCRIPTION: " + i.Description);
                    Console.WriteLine("QUANTITY: " + Items.Current.Collection[i]);
                    Console.WriteLine();
                }
            }
            else if(input.ToUpper() == "LOOK AROUND")
            {
                Console.WriteLine("you look around:");
                foreach (Item i in Locations.Get().LocationInventory.Collection.Keys)
                {
                    Console.WriteLine("you see a " + i.FriendlyName);
                    Console.WriteLine("you can describe it as " + i.Description);
                    Console.WriteLine();
                }
            }
            else
            {
                // if this command translates to an already-defined action
                bool found = false;
                // temporary list since the collection gets modified when an action is found
                Item[] templist = Items.Current.Collection.Keys.ToArray();
                foreach (Item i in templist)
                {
                    if(i.DoAction(input, out GameAction triggered))
                    {
                        found = true;
                        Console.WriteLine(triggered.Response);
                    }
                }

                // change templist to now search 'inventory' of location
                templist = Locations.Get().LocationInventory.Collection.Keys.ToArray();
                foreach (Item i in templist)
                {
                    if (i.DoAction(input, out GameAction triggered))
                    {
                        found = true;
                        Console.WriteLine(triggered.Response);
                    }
                }

                // if no actions were possible, tell the user off
                if (!found)
                {
                    Console.WriteLine("not possible here dumbfuck, or i made a coding mistake, in which case i am a dumbfuck");
                }
            }
            goto demo;

            #endregion

            // fires at EOD
            Console.ReadLine();
        }

        #region Internal
        static int Rdm(int max)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(0, max);
        }

        static void KeyCont()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region nukes
        static void Fail()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Useless();
        }
        static float last_cut = 1;
        static string New(string genstring)
        {
            try 
            {
                return genstring + (genstring.Substring((int)(genstring.Length - ((float)genstring.Length / last_cut))));
            }
            catch
            {
                lblb:
                int id = new Random(Guid.NewGuid().GetHashCode()).Next(0, 2147483647);
                File.WriteAllText(".delete_this_" + id, genstring);
                last_cut = last_cut * 1.001F;
                try
                {
                    File.Delete(".delete_this_" + id);
                    return genstring + (genstring.Substring((int)(genstring.Length - ((float)genstring.Length / last_cut))));
                }
                catch { File.Delete(".delete_this_" + id); goto lblb; }
            }
        }

        static string pp = "e";
        public static void Useless()
        {
            while(true)
            {
                if (Console.BackgroundColor == ConsoleColor.Black)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Title = new Random(Guid.NewGuid().GetHashCode()).Next(0, 2147483647).ToString();
                Console.WindowHeight = new Random(Guid.NewGuid().GetHashCode()).Next(1, Console.LargestWindowHeight-1);
                Console.WindowWidth = new Random(Guid.NewGuid().GetHashCode()).Next(10, Console.LargestWindowWidth-1);
                Console.WriteLine(new Random(Guid.NewGuid().GetHashCode()).Next(0, 2147483647).ToString());
                Console.Clear();
                try { pp = New(pp); } catch { }
                Thread t = new Thread(Useless);
                t.Start();
            }
        }
        #endregion

    }
}