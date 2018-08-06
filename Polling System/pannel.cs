using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Polling_System
{
    class pannel
    {
        static List<voter> voters = new List<voter>();
        static List<candidate> candidates = new List<candidate>();
        String adminPass = "", encryptPass = "";
        byte[] bs;

        public pannel() { }
        public Boolean validate(String choice)
        {
            Boolean flag = true;
            if (choice != "\n" && choice != "" && choice != null && choice != " ")
                flag = true;
            else
                return false;
            for (int i = 0; i < choice.Length; i++)
            {
                for (int j = 48; j <= 57; j++)
                {
                    if ((int)(Convert.ToChar(choice[i])) != j)
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                        goto correctChar;
                    }
                }
            correctChar:
                if (flag == false)
                    return false;
            }
            return flag;
        }
        public Boolean chkAdmin()
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            adminPass = "";
            Console.Write("\n\tEnter Password for admin module : ");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    adminPass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && adminPass.Length > 0)
                    {
                        adminPass = adminPass.Substring(0, (adminPass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            bs = System.Text.Encoding.UTF8.GetBytes(adminPass);
            bs = md5.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Clear();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            encryptPass = s.ToString();
            Console.WriteLine();
            if (encryptPass.Equals("21232f297a57a5a743894a0e4a801fc3"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void adminPannel()
        {
            int adminChoice = 0;
            Console.WriteLine();
            Console.WriteLine("\n\tPress any key to enter admin pannel.");
            Console.ReadKey();
            Console.Clear();
            do
            {
            input:
                Console.Clear();
                Console.WriteLine("Admin Pannel");
                Console.WriteLine();
                Console.WriteLine("\t1. Add Candidates");
                Console.WriteLine("\t2. Total Candidates");
                Console.WriteLine("\t3. Display Candidates");
                Console.WriteLine("\t4. Add Voters");
                Console.WriteLine("\t5. Total Voters");
                Console.WriteLine("\t6. Display Voters");
                Console.WriteLine("\t7. Check Poll Results");
                Console.WriteLine("\t8. Logout");
                Console.Write("\n\tEnter operation choice : ");
                String choice = Console.ReadLine();
                if (this.validate(choice))
                    adminChoice = Convert.ToInt32(choice);
                else
                    goto input;

                switch (adminChoice)
                {
                    case 1:
                        candidate tmpCandidate = new candidate();
                        candidates.Add(tmpCandidate);
                        break;
                    case 2:
                        Console.WriteLine("\tTotal Candidates : " + (new candidate(0).getCandidates() + 1));
                        break;
                    case 3:
                        if (candidates.Count > 0)
                        {
                            Console.WriteLine("\tList of candidates are as follows:-\n");
                            foreach (candidate c in candidates)
                            {
                                c.display();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tNo candidates found");
                        }
                        break;
                    case 4:
                        if (candidates.Count > 0)
                        {
                            voter tmpVoter = new voter();
                            voters.Add(tmpVoter);
                        }
                        else
                        {
                            Console.WriteLine("\tPlease add a candidate first before adding voters.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("\tTotal Voters : " + (new voter(0).getVoters() + 1));
                        break;
                    case 6:
                        if (voters.Count > 0)
                        {
                            Console.WriteLine("\n\tList of Voters is as follows:-\n");
                            foreach (voter v in voters)
                            {
                                v.display();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tNo voters registered");
                        }
                        break;
                    case 7:
                        if (candidates.Count > 0)
                        {
                            int winnerVotes = 0;
                            foreach (candidate c in candidates)
                            {
                                if (c.getTotalVotes() > winnerVotes)
                                    winnerVotes = c.getTotalVotes();
                            }
                            if (winnerVotes != 0)
                            {
                                Console.WriteLine("\tThe poll results are as follows:\n");
                                int countWinners = 0;
                                foreach (candidate c in candidates)
                                {
                                    if (c.getTotalVotes() == winnerVotes)
                                    {
                                        Console.Write("\t");
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(c.getList() + "\t" + c.getTotalVotes());
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.WriteLine();
                                        countWinners++;
                                    }
                                    else
                                    {
                                        Console.Write("\t");
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine(c.getList() + "\t" + c.getTotalVotes());
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.WriteLine();
                                    }
                                }
                                if (countWinners > 1)
                                    Console.WriteLine("\n\tThere is a tie between " + countWinners + " candidates.");
                                else
                                    Console.WriteLine("\n\tThe name of the winner is highlighted in Green colour.");
                            }
                            else
                            {
                                Console.WriteLine("\n\tNo votes casted till now");
                            }
                        }
                        else if(candidates.Count == 1)
                        {
                            Console.WriteLine("Poll cannot be conducted in only one candidate. Add some more candidates.");
                        }
                        else
                        {
                            Console.WriteLine("\n\tNo candidates registered from the poll.");
                        }
                        break;
                    case 8:
                        Console.Write("\tAre yout sure you want to logout(Y/N) : ");
                        if (((Console.ReadLine()).ToLower()).Equals("y"))
                        {
                            Console.WriteLine("\n\tYou would now be redirected to the main menu.");
                        }
                        else
                        {
                            adminChoice = 0;
                        }
                        break;
                    default:
                        Console.WriteLine("\tInvalid Choice");
                        break;
                }
                if (adminChoice != 8)
                    Console.ReadKey();
            } while (adminChoice != 8);
        }
        public void userPannel()
        {
            int userChoice = 0;
            String tmpUsn = "";
            Console.WriteLine();
            Console.WriteLine("\tPress any key to enter user pannel.");
            Console.ReadKey();
            Console.Clear();
            do
            {
            input:
                Console.Clear();
                Console.WriteLine("User Pannel");
                Console.WriteLine();
                Console.WriteLine("\t1. Add Vote");
                Console.WriteLine("\t2. Main Menu");
                Console.Write("\n\tEnter operation choice : ");
                String choice = Console.ReadLine();
                if (this.validate(choice))
                    userChoice = Convert.ToInt32(choice);
                else
                    goto input;
                switch (userChoice)
                {
                    case 1:
                        if (candidates.Count > 0)
                        {
                            Console.Write("\tEnter the usn number of the voter : ");
                            tmpUsn = (Console.ReadLine()).ToUpper();
                            Boolean chkUsn = false;
                            foreach (voter v in voters)
                            {
                                chkUsn = true;
                                if (tmpUsn.ToUpper().Equals(v.getUsn()))
                                {
                                    if (v.getStatus() == false)
                                    {
                                        foreach (candidate c in candidates)
                                        {
                                            Console.WriteLine("\t" + c.getList());
                                        }
                                        Console.Write("\tEnter the candidate number you want to vote for : ");
                                        int votedFor = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n\tThis cannot be redone again. Are you sure you want to vote for " + candidates[votedFor - 1] + " (Y/N)? ");
                                        if (((Console.ReadLine()).ToLower()).Equals("y"))
                                        {
                                            v.setVotedFor(votedFor);
                                            candidates[votedFor - 1] = candidates[votedFor - 1]++;
                                            v.setVoted();
                                            Console.WriteLine("\n\tThank you for voting. Now let the other person come to vote.");
                                        }
                                        else
                                        {
                                            goto case 1;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have already Voted. You cannot vote again.");
                                    }
                                }
                            }
                            if (chkUsn == false)
                                Console.WriteLine("\n\tNo voter with such USN Number found in the records.");
                        }
                        else if (candidates.Count == 1)
                        {
                            Console.WriteLine("Poll cannot be conducted for only 1 candidate. Please conatct your administrator for more details.");
                        }
                        else
                        {
                            Console.WriteLine("\n\tNo candidate is added currently. Please contact the admin for more details.");
                            userChoice = 2;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n\tPress any key to enter the main menu.");
                        break;
                    case 3:
                        Console.WriteLine("\t Invalid Choice.");
                        break;
                }
                if (userChoice != 2)
                    Console.ReadKey();
            } while (userChoice != 2);
        }
    }
    
}
