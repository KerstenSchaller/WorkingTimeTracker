using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Management;


namespace WorkingTimeTracker
{
    public class User_Profile
    {

        List<string> last_use_times = new List<string>();
        



        public ManagementObject GetLocalUserAccount(string username)
        {

            SelectQuery query = new SelectQuery("Win32_UserProfile");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            

            foreach (ManagementObject sid in searcher.Get())
            {
                string user_string = new SecurityIdentifier(sid["SID"].ToString()).Translate(typeof(NTAccount)).ToString();
                if (user_string.Contains(username))
                {
                    string s = (string)sid["LastUseTime"];
                    return sid;

                }
                
            }
            return null;

        }



        public void GetLastUseTime()
        {

           

        }
    }
}
