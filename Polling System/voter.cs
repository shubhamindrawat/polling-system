using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling_System
{
    class voter
    {
        static int voters = -1;
        int votedFor = -1;
        String usn = "", name = "";
        Boolean hasVoted;
        public voter()
        {
            inputUsn:
            Console.Write("\tEnter USN Number : ");
            usn = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(usn.Trim()))
                goto inputUsn;

            inputName:
            Console.Write("\tEnter Name : ");
            name = Console.ReadLine();
            if (String.IsNullOrEmpty(name.Trim()))
                goto inputName;
            hasVoted = false;
            voters++;
        }
        public voter(int dummy) { }
        public void display()
        {
            Console.Write("\t" + usn + "\t\t" + name + "\t\t");
            if (hasVoted)
                Console.Write("Voted");
            else
                Console.Write("Not Voted");
            Console.WriteLine();
        }
        public int getVoters()
        {
            return voters;
        }
        public Boolean getStatus()
        {
            return hasVoted;
        }
        public void setVotedFor(int id)
        {
            votedFor = id;
        }
        public String getUsn()
        {
            return usn;
        }
        public void setVoted()
        {
            hasVoted = true;
        }
    }
    
}
