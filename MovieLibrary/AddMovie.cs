using System;
using System.IO;

namespace A4___Movie_Library_Assignment_LINZ
{
   public  class AddMovie
    {
        ActionSelected action = new ActionSelected();
        NLogger nLogger = new NLogger();
        string movieName = "";

        string file = "movies.csv";
        StreamReader sr = new StreamReader("movies.csv");
        public void addTest()
        {

            {

                //   StreamReader sr = new StreamReader(file);
                int movieIdNew = 0;
                string movieId = "", line = "";

                try
                {
                    {
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                        }
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine($"The file was not found: '{e}'");
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine($"The directory was not found: '{e}'");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"The file could not be opened: '{e}'");
                }

                if (sr.Peek() == -1) Console.WriteLine("\nThis is the most recent movie added:  " + line);

                string lastLine = line;
                movieId = lastLine.Substring(0, lastLine.IndexOf(","));
                // increment movieId
                movieIdNew = int.Parse(movieId);
                movieIdNew++;


                Console.Write("Enter the name of the movie you want to add, date in form (yyyy)\n");
                System.Console.WriteLine("\t(You will have the opportunity to abort if needed)");

                movieName = Console.ReadLine();

                abortProcess();

                if (movieName.Contains(","))
                {
                    movieName = "\"" + movieName.Trim() + "\"";
                }

                sr = new StreamReader(file);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();


                    string duplicate = line;

                    int first = duplicate.IndexOf(",") + ",".Length;
                    int last = duplicate.LastIndexOf(",");
                    string dupFound = duplicate.Substring(first, last - first);

                    if (movieName.Contains(dupFound))
                    {
                        nLogger.nLog("Tried to add an existing movie");
                        System.Console.WriteLine(" This movie is already on the list");
                        sr.Close();

                        action.selectAction();

                    }

                }

                string movieString = "";

                movieString = movieIdNew + "," + movieName.Trim() + "," + genreAdd();

                System.Console.WriteLine(movieString);

                StreamWriter sw = new StreamWriter(file, true);

                sw.WriteLine(movieString);
                sw.Close();
                sr.Close();
                action.selectAction();

            }

            string genreAdd()
            {
                int genreSelect = 0;
                int count = 0;
                string genreString = "";
                string[] genreArray = {"Empty","Action", "Adventure", "Animation", "Children's",
                "Comedy", "Crime", "Documentary", "Drama", "Fantasy", "Film-Noir", "Horror",
                "Musical", "Mystery", "Romance", "Sci-Fi", "Thriller", "War", "Western", "(no genres listed)"};

                GenreDisplay genreDisplay = new GenreDisplay();
                genreDisplay.showGenres();

                System.Console.WriteLine("Enter number for a genre to add 1 through 19 you will add them one at a time.");
                System.Console.WriteLine("When your input is complete, then 0 for done, and then the movie is added.\n\n");

                genreSelect = Convert.ToInt32(Console.ReadLine());

                while (genreSelect > 0 || genreSelect < 20)
                {
                    if (count == 0)
                    {
                        genreString = genreString + genreArray[genreSelect];
                        count++;
                    }
                    System.Console.Write(genreArray[genreSelect] + " \n\n");
                    System.Console.WriteLine("Enter number for a genre to add 1 through 19, ");
                    System.Console.WriteLine("or 0 when  done and then the movie is added.");

                    genreSelect = Convert.ToInt32(Console.ReadLine());


                    if (genreSelect < 1 || genreSelect > 20)
                    {
                        return genreString;
                    }
                    else
                    {
                        nLogger.nLog("Added another genre to the movie");
                        genreString = genreString + "|" + genreArray[genreSelect];
                    }

                }

                return genreString;
            }

        }
        void abortProcess()
        {
            Console.WriteLine("\n Press Enter to continue or Escape (Esc) to abort the movie adding process. \n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                nLogger.nLog("Aborted the new movie add");
                sr.Close();
                action.selectAction();
            }
        }


    }

   
}

