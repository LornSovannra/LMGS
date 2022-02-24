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
        private static string UserType;

        //Setter Methods
        public static void setLibrarianID(string id)
        {
            LibrarianID = id;
        }

        public static void setLibrarianName(string photo)
        {
            LibrarianName = photo;
        }

        public static void setUserType(string userType)
        {
            UserType = userType;
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

        public static string getUserType()
        {
            return UserType;
        }
    }
}

