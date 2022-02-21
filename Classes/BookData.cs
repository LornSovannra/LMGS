using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MGS.Classes
{
    class BookData
    {
        //    txtBookTitle.Text = dt.Rows[0]["BookTitle"].ToString();
        //    dtpPublishDate.Text = dt.Rows[0]["PublishDate"].ToString();
        //    txtNumOfPages.Text = dt.Rows[0]["NumOfPages"].ToString();
        //    txtNumCopies.Text = dt.Rows[0]["NumCopies"].ToString();
        //    cbEdition.Text = dt.Rows[0]["Edition"].ToString();
        //    cbPublisher.Text = dt.Rows[0]["Publisher"].ToString();
        //    txtBookSource.Text = dt.Rows[0]["BookSource"].ToString();
        //    cbBookTypeID.Text = dt.Rows[0]["BookTypeID"].ToString();
        //    rtbRemark.Text = dt.Rows[0]["Remark"].ToString();

        private static string BookID;
        private static string BookTitle;
        private static string PublishDate;
        private static string NumOfPages;
        private static string NumCopies;
        private static string Edition;
        private static string Publisher;
        private static string BookSource;
        private static string BookTypeID;
        private static string Remark;

        //Setter Methods
        public static void setBookID(string id)
        {
            BookID = id;
        }

        public static void setBookTitle(string bookTitle)
        {
            BookTitle = bookTitle;
        }

        public static void setPublishDate(string publishDate)
        {
            PublishDate = publishDate;
        }

        public static void setNumOfPages(string numOfPages)
        {
            NumOfPages = numOfPages;
        }

        public static void setNumCopies(string numCopies)
        {
            NumCopies = numCopies;
        }

        public static void setEdition(string edition)
        {
            Edition = edition;
        }

        public static void setPublisher(string publisher)
        {
            Publisher = publisher;
        }

        public static void setBookSource(string bookSource)
        {
            BookSource = bookSource;
        }

        public static void setBookTypeID(string bookTypeID)
        {
            BookTypeID = bookTypeID;
        }

        public static void setRemark(string remark)
        {
            Remark = remark;
        }

        //Getter Methods
        public static string getBookID()
        {
            return BookID;
        }

        public static string getBookTitle()
        {
            return BookTitle;
        }

        public static string getPublishDate()
        {
            return PublishDate;
        }

        public static string getNumOfPages()
        {
            return NumOfPages;
        }

        public static string getNumCopies()
        {
            return NumCopies;
        }

        public static string getEdition()
        {
            return Edition;
        }

        public static string getPublisher()
        {
            return Publisher;
        }

        public static string getBookSource()
        {
            return BookSource;
        }

        public static string getBookTypeID()
        {
            return BookTypeID;
        }

        public static string getRemark()
        {
            return Remark;
        }
    }
}
