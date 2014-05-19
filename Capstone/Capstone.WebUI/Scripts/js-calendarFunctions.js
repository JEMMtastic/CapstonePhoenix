/*
   Function List:
   calendar(calendarDay)
      Creates the calendar table for the month specified in the
      calendarDay parameter. The current date is highlighted in 
      the table.

   writeCalTitle(calendarDay)
      Writes the title row in the calendar table

   writeDayTitle()
      Writes the weekday title rows in the calendar table

   daysInMonth(calendarDay)
      Returns the number of days in the month from calendarDay

   writeCalDays(calendarDay)
      Writes the daily rows in the calendar table, highlighting
      calendarDay

*/

function calendar(calendarDay) {
    if (calendarDay == null) calDate = new Date()
    else calDate = new Date(calendarDay);

    document.write("<table id='calendar_table'>");
    writeCalTitle(calDate);
    writeDayName();
    writeCalDays(calDate);
    document.write("</table>");
}

function writeCalTitle(calendarDay) {
    var monthName = new Array("January", "February", "March",
    "April", "May", "June", "July", "August", "September",
    "October", "November", "December")
    var thisMonth = calendarDay.getMonth();
    var thisYear = calendarDay.getFullYear();

    document.write("<tr>");
    document.write("<th id='calendar_head' colspan='7'>");
    document.write(monthName[thisMonth] + " " + thisYear);
    document.write("</th>");
    document.write("</tr>");
}

function daysInMonth(calendarDay) {
    var thisYear = calendarDay.getFullYear();
    var thisMonth = calendarDay.getMonth();
    var dayCount = new Array(31, 28, 31, 3, 31, 30, 31, 31, 30, 31, 30, 31);
    if (thisYear % 4 == 0) {
        if ((thisYear % 100 != 0) || (thisYear % 400 == 0)) {
            dayCount[1] = 29; //this is a leap year
        }
    }

    return dayCount[thisMonth]; //return the number of days in the month
}

function writeDayName() {
    var dayName = new Array("Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat");
    document.write("<tr>");
    for (var i = 0; i < dayName.length; i++) {
        document.write("<th class='calendar_weekdays'>" + dayName[i] + "</th>");
    }
    document.write("</tr>");
}


