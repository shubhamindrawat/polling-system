using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling_System
{
    class candidate
    {
        static int candidates = -1;
        int id, totalVotes = 0;
        String name = "", usn = "";
        public candidate()
        {
            inputUsn:
            Console.Write("\tEnter USN Number : ");
            usn = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(usn.Trim()))
                goto inputUsn;

            inputName:
            Console.Write("\tEnter candidate name : ");
            name = Console.ReadLine();
            if (String.IsNullOrEmpty(name.Trim()))
                goto inputName;
            id = ++candidates;
        }
        public candidate(int dummy) { }
        public void display()
        {
            Console.WriteLine("\t" + (id + 1) + "\t" + usn + "\t" + name);
        }
        public int getCandidates()
        {
            return candidates;
        }
        public String getList()
        {
            return (id + 1) + "\t" + name;
        }
        public static candidate operator ++(candidate c)
        {
            c.totalVotes++;
            return c;
        }
        public int getID()
        {
            return id;
        }
        public int getTotalVotes()
        {
            return totalVotes;
        }
    }
    
}
