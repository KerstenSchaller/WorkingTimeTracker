using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using IniParser;
//using IniParser.Model;
using System.IO;
using System.Globalization;

namespace WorkingTimeTracker
{
   class IniReader
   {

      public static double getStandartWorkingTime()
      {
         
         //works with Nuget: ini-parser
         // var parser = new FileIniDataParser();
         // string path = "workingTimeTracker.ini";
         // if (File.Exists(path))
         // {
         //    IniData data = parser.ReadFile(path);
         //    KeyDataCollection keyCol = data["Parameters"];
         //    string directValue = keyCol["StandartWorkingTime"];
         //    return Double.Parse(directValue);
         // }
         // else
         // {
         //    return 8;
         // }
     
         
         string path = "workingTimeTracker.ini";
         if (File.Exists(path))
         {

            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
               if (line.Contains("StandartWorkingTime"))
               {
                  string[] s = line.Split('=');
                  NumberStyles styles = NumberStyles.Float | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
                  var provider = NumberFormatInfo.InvariantInfo;
                  var stdwt = Double.Parse(s[1], styles, provider);
                  return stdwt;
               }
            }

         }


         return 8;
       
      }




   }
}
