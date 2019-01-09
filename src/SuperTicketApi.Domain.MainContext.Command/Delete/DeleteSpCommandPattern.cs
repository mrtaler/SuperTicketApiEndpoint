using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTicketApi.Domain.MainContext.Command.Delete
{
    public static class DeleteSpCommandPattern
    { 
        public static string DeleteArea => "[dbo].[DeleteByIdArea]";
        public static string DeleteEvent => "[dbo].[DeleteByIdEvent]";
        public static string DeleteEventArea => "[dbo].[DeleteByIdEventArea]";
        public static string DeleteEventSeat => "[dbo].[CreateEventSeat]";
        public static string DeleteLayout => "[dbo].[DeleteByIdLayout]";
        public static string DeleteSeat => "[dbo].[DeleteByIdSeat]";
        public static string DeleteVenue => "[dbo].[DeleteByIdVenue]";
    }
}


