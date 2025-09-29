using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHotel
{
    public static class Constants
    {
        public static string Calculated = "Calculated";

        public static class TableRoom
        {
            public static string Name = "room";
            public static string Id = "id";
            public static string RoomNumber = "room_number";
            public static string RoomTypeId = "room_type_id";
            public static string StatusId = "status_id";
            public static string ResponsibleStaffId = "responsible_staff_id";
        }

        public static class TableRoomType
        {
            public static string Name = "room_type";
            public static string Id = "id";
        }

        public static class TableRoomStatus
        {
            public static string Name = "room_status";
            public static string Id = "id";
            public static string NameColumn = "name";
        }

        public static class TableClient
        {
            public static string Name = "client";
            public static string Id = "id";
            public static string RoomId = "room_id";
            public static string FirstName = "first_name";
            public static string LastName = "last_name";
        }

        public static class TableStaff
        {
            public static string Name = "staff";
            public static string Id = "id";
            public static string FirstName = "first_name";
            public static string LastName = "last_name";
            public static string MiddleName = "middle_name";
            public static string HireDate = "hire_date";
            public static string DismissalDate = "dismissal_date";
            public static string Passport = "passport";
            public static string Phone = "phone";
            public static string StatusId = "status_id";
        }

        public static class TableStaffStatus
        {
            public static string Name = "staff_status";
            public static string Id = "id";
            public static string NameColumn = "name";
        }


        public static class TableBooking
        {
            public static string Name = "booking";
            public static string Id = "id";
            public static string RoomId = "room_id";
            public static string ClientId = "client_id";
            public static string StartDate = "start_date";
            public static string EndDate = "end_date";
        }

        public static class TableInvoice
        {
            public static string Name = "invoice";
            public static string Id = "id";
            public static string StayId = "stay_id";
            public static string TotalAmount = "total_amount";
            public static string PaymentDate = "payment_date";
            public static string PaymentMethod = "payment_method";
        }

        public static class TableStay
        {
            public static string Name = "stay";
            public static string Id = "id";
            public static string BookingId = "booking_id";
            public static string ActualCheckIn = "actual_check_in";
            public static string TotalCost = "total_cost";
        }

        public static class TableReport
        {
            public static string Name = "report";
            public static string Id = "id";
        }


        // public static string TableGroup = "AcademicGroup";
        public static class TableStudent
        {
            public static string Name = "Student";
            public static string Id = "StudentId";
        }

        public static class TableGroup
        {
            public static string Name = "AcademicGroup";
            public static string Id = "GroupId";

            public static class Columns
            {
                public static string Name = "Name";
                public static string Year = "Year";

                public static Dictionary<string, string> Tranlation
                {
                    get
                    {
                        return new Dictionary<string, string>
                        {
                            { Name, "Наименование" },
                            { Year, "Год" }
                        };
                    }
                }
            }
        }
    }
}
