using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public static class ActivityLogss
    {
        private static string pth = "log.txt";

        public static void lgActv(User user)
        {
            bool noFileFound = false;
            string prevFile = "";

           

            try
            {
                FileStream x = new FileStream(pth, FileMode.Open, FileAccess.Read);
                StreamReader fileRdr = new StreamReader(x);
                prevFile = fileRdr.ReadToEnd().Trim();
                x.Close();

            }
            catch (IOException)
            {
                noFileFound = true;
            }
            finally
            {
                FileStream y = new FileStream(pth, FileMode.Create);
                StreamWriter fileWdr = new StreamWriter(y);
                string currLg = $"The user name \"{user.UserName}\" was logged in on {DateTime.Now.ToUniversalTime()} (UTC)";

                if (noFileFound)
                {
                    fileWdr.WriteLine(currLg);
                    fileWdr.Close();
                }
                else
                {
                    fileWdr.WriteLine(prevFile);
                    fileWdr.WriteLine(currLg);
                    fileWdr.Close();
                }
            }
                   
            
        
        }
    }
}
