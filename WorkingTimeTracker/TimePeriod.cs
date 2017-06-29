using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTimeTracker
{
    class TimePeriod
    {
        private DateTime starttime = new DateTime();
        private DateTime endtime = new DateTime();
        private int number_of_activitys = 1;

        public DateTime getStartTime() { return starttime; }

        public void setStartTime(DateTime time) { starttime = time; }

        public DateTime getEndTime() { return endtime; }

        public void setEndTime(DateTime time)
        {
            endtime = time;
            number_of_activitys++;
        }

        public int getNumberofActivities()
        {
            return number_of_activitys;
        }
    }
}
