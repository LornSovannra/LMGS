using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MGS.Classes
{
    class UserLogin
    {
        //Static Fields
        private static string LibrarianID;
        private static string LibrarianName;

        //Setter Methods
        public static void setLibrarianID(string id)
        {
            LibrarianID = id;
        }

        public static void setLibrarianName(string photo)
        {
            LibrarianName = photo;
        }

        //Getter Methods
        public static string getLibrarianID()
        {
            return LibrarianID;
        }

        public static string getLibrarianName()
        {
            return LibrarianName;
        }
    }
}
