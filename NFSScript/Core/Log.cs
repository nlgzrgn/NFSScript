﻿using System;
using System.Text;
using System.IO;

namespace NFSScript
{
    /// <summary>
    /// Class for sending log output
    /// </summary>
    public static class Log
    {
        private const string fileName = "NFSScriptLog";
        private const string fileExtension = "log";
        private const string dateFormat = "MM-dd-yyyy";

        /// <summary>
        /// Gets the log file name
        /// </summary>
        /// <returns></returns>
        public static string GetFileName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(fileName);
            sb.Append(" ");
            sb.Append(DateTime.Now.ToString(dateFormat));
            sb.Append(".");
            sb.Append(fileExtension);

            return sb.ToString();
        }

        /// <summary>
        /// Print a log message.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public static void Print(string tag, string message)
        {

            string output = string.Format("({0}) {1}: {2}", DateTime.Now.ToString("u").Replace("Z", string.Empty), tag, message);
            Console.WriteLine(output);

            using (StreamWriter file = new StreamWriter(GetFileName(), true))
            {
                file.WriteLine(output);
            }
        }

        /// <summary>
        /// Prints a debug message if <seealso cref="NFSScript.DEBUG"/> is set to true.
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            if (NFSScript.DEBUG)
            {
                string output = string.Format("({0}) DEBUG: {1}", DateTime.Now.ToString("u").Replace("Z", string.Empty), message);
                Console.WriteLine(output);

                using (StreamWriter file = new StreamWriter(GetFileName(), true))
                {
                    file.WriteLine(output);
                }
            }
        }
    }
}
