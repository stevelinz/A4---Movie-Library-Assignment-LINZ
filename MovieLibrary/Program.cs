using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks.Dataflow;
using System;
using System.IO;

namespace A4___Movie_Library_Assignment_LINZ
{
     class Program
    {
        
        static void Main(string[] args)
        {
            {
                ActionSelected action = new ActionSelected();
                action.selectAction();            
            }
        }
    }
}