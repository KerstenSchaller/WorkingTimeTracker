# WorkingTimeTracker
A little application which is able to track your working hours automatically.


Purpose:
This C# application is meant to support office workers. Unless they have automatical worktime tracking in their jobs everyone needs to take care about his time management himself. I tried to use excel sheets to achieve that but occasionally forgott to write down start and end time. Thats why i came up with the idea of tracking my worktime automatically.

Notice: Be aware that this programm creates a human readable activity protocoll on your computer which might expose sensitive data to non authorized persons. At this point everyone is sesponsible himself to keep that data save.


Features:
  - tracks mouse or keyboard activity once every minute and writes information about it to an XML File(human readable)
  - analyses the activity information in order to create worktime information  
  - runs as a notify icon in the system tray which shows, information summary about current day in a baloon tip when right-clicked
  - left clicked notify icon opens a GUI which shows a colorcoded list of days including all related working time information
  - GUI enables user to edit the calculated working time information while original activity information is kept(usecases: vacatation, sickness, individual work which cant be tracked, etc )
  
Stability: Not guaranteed. All features are just hand tested and might be buggy.


Planned steps:
  - Refactor code 
  - output to excel files
  - output to matlab, *.mat files as well as complete scripts to display worktime information
  
