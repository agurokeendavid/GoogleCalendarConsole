using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System;
using System.Linq;


// Download Google.Apis.Calendar.v3 Package.
namespace GoogleCalendarAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintGoogleCalendarEvent();   
        }

        private static void PrintGoogleCalendarEvent()
        {
            // Initialize Calendar Service Object from Google.Apis.Services namespace;
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                // Input the api key that Google generate.
                ApiKey = "YOUR_API_KEY",
                ApplicationName = "Google Calendar API .NET Quickstart",

            });
            // Input the id of the calendar that you want to display.
            var events = service.Events.List("CALENDAR_ID").Execute();

            // Printing each event FROM Current Year to 2 Years after.
            foreach (var myEvent in events.Items.OrderBy(o => o.Start.Date).ToList())
            {
                Console.WriteLine($"Event: {myEvent.Summary} Start: {myEvent.Start.Date}");
            }
        }
    }
}
