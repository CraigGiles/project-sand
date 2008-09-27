using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SandTileEngine
{
    /// <summary>
    /// Creates a text file of any error messages that may
    /// be encountered at run-time.
    /// </summary>
    public class ErrorLog
    {

        /// <summary>
        /// Writes an error message to the Project/Logs/ErrorMessage.txt file
        /// </summary>
        /// <param name="error"></param>
        public static void WriteErrorMessage(string error)
        {    
            //if ErrorMessages.txt exists
            //append the file with a new error message
            try
            {                
                StreamWriter writer = new StreamWriter("Logs//ErrorMessages.txt", true);
                writer.WriteLine("Time Stamp: " + DateTime.Now);
                writer.WriteLine(error);
                writer.WriteLine();
                writer.Close();
            }
            //if ErrorMessages.txt does not exist, create
            //the file and write the error message.
            catch 
            {
                System.IO.Directory.CreateDirectory("Logs//");
                FileStream stream = new FileStream("Logs//ErrorMessages.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("Time Stamp: " + DateTime.Now);
                writer.WriteLine(error);
                writer.WriteLine();
                writer.Close();
                stream.Close();
            }

            
        }
    }
}
