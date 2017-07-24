using System;

namespace Structura.GuiTests.Obects
{
    public class UserObjects
    {
        private String firstName { get; set; }
        private String lastName { get; set; }
        private Enum maritalStatus { get; set; }
        private Enum hobby { get; set; }
        private String phoneNumber { get; set; }

        public UserObjects(string fName, string lName, string pNumber)
        {
            firstName = fName;
            lastName = lName;
            phoneNumber = pNumber;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }


    }
}
