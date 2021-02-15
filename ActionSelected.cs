using System.Runtime.ConstrainedExecution;
using System.Dynamic;
using System;
using System.IO;

namespace A4___Movie_Library_Assignment_LINZ
{
    class ActionSelected : IMenus
    {


        public void selectAction()
        {
            NLogger nLogger = new NLogger();
            string select = "";
            System.Console.WriteLine("\n   ~~~~Movie Library Database~~~~ ");
        andAgain:
            System.Console.WriteLine("Enter: \n1 List the movies \n2 Add a new Movie \n3 Exit program\n");
            select = System.Console.ReadLine();  
            switch (select)
            {
                case "1":
                    nLogger.nLog("LIST at Select Action ");
                    ListMovie listMovie = new ListMovie();
                    listMovie.useFile();  
                    break;
                case "2":
                    nLogger.nLog("ADD at Select Action ");
                    AddMovie addMovie = new AddMovie();
                    addMovie.addTest();
                    break;
                case "3":
                    nLogger.nLog("EXIT at Select Action ");
                    Exit exit = new Exit();
                    exit.exitTest();
                    break;
                default:
                    System.Console.WriteLine("Not a valid input, Enter 1 2 or 3");
                    nLogger.nLog("Wrong input at Select Action ");
                    goto andAgain;

            }
            

        }

    }
}