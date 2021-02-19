using System;
using System.Collections;
using System.IO;

namespace A4___Movie_Library_Assignment_LINZ
{

 
   public class ListMovie
    {
        StreamReader sr = new StreamReader("movies.csv");
        NLogger nLogger = new NLogger();
        private const int V = 30;
        int currentStart = 0;
        int nextStart = 31;

        string start = "";

        string line = "";

       
        public void useFile()
        {

            string listReverseOrder = "";

            System.Console.Write("Would you like to view the list from the end to the beginning? [Y]es [N]o?    ");

            listReverseOrder = Console.ReadLine();

            if (listReverseOrder == "Y" || listReverseOrder == "y" || listReverseOrder == "yes" || listReverseOrder == "Yes")
            {
                reverseList();
            }

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                fewAtaTime();
            }
            sr.Close();
        }

        void reverseList()
        {
            ArrayList arrText = new ArrayList();
            string sLine = "";
            nLogger.nLog("Movies viewed in reserve order.");
            while (sLine != null)
            {
                sLine = sr.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }

            arrText.Reverse();

            foreach (string sOutput in arrText)
            {
                fewAtaTime();
                System.Console.Write(sOutput);
            }
        }
        void fewAtaTime()
        {
            if (currentStart == nextStart)
            {
                System.Console.WriteLine("\nPress Enter for the next 30 movies or Q to quit");
                start = Console.ReadLine();
                if (start == "q" || start == "Q" || start == "quit" || start == "Quit")
                {
                    nLogger.nLog("Quit the movie viewing.");
                    sr.Close();
                    ActionSelected action = new ActionSelected();
                    action.selectAction();
                }
                currentStart = 0;
                nextStart = V;
            }
            currentStart++;
            System.Console.WriteLine(line);

        }

        
    }


}

