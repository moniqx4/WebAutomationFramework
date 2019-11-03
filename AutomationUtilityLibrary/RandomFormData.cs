using AutomationUtilityLibrary.Models;
using System;
using System.Collections.Generic;

namespace AutomationUtilityLibrary
{
    public class RandomFormData
    {

        private static Random _random;

        public RandomFormData(Random random)
        {
            _random = random;
        }

        public static int GetRandomNumber(int min, int max) => _random.Next(min, max);

        public static string GetRandomStringIn(string[] array) => array[GetRandomNumber(0, array.Length - 1)];

        private string RandomFname
        {
            get
            {
                var firstnames = new List<string> {"Mike", "Lisa", "Barry", "Paul", "Steve", "Monica","Tracy","Andre",
                    "Kelly","John", "Stacy", "Michelle", "Brian", "Jason", "Jess","Jose","Larry","Craig","Tim","Sally","Graham",
                    "Nick","Johnny","Jacob","Justine","RuPaul","Kimsy","Amarea"};
                var firstnameRand = new Random();
                var index = firstnameRand.Next(0, 27);
                var fname = firstnames[index];

                // _logger.Log("FirstName: " + fname); TODO: Add back in when logger is put in
                return fname;
            }
        }

        private string RandomLname
        {
            get
            {
                var lastnames = new List<string> {"Dixon", "Johnson", "Woods", "White", "Black", "Ivory","Taylor","Jones",
                    "Gayton","Oden", "Washington", "Fitzgerald", "Dawson", "Jackson", "Tiller","Tipmen","Rodmen","Gonzalez","Murray","Peterson",
                     "Studdley","Newman","Jolson","Parker","Linden","Jensen", "Knowley"};
                var lastnameRand = new Random();
                var index = lastnameRand.Next(0, 26);
                var lastname = lastnames[index];

                // _logger.Log("Last Name: " + lname); TODO: Add back in when logger is put in
                return lastname;
            }
        }

        private string RandomDomain
        {
            get
            {
                var domains = new List<string> {"googletest", "gmailtest", "yahootest", "tesstest", "aoltest", "livetest",
                                                        "nomail", "testme", "nowhere","moniwhere","moniplace","placita","nosuchemail"};
                var domainRand = new Random();
                var index = domainRand.Next(0, 12);
                var domain = domains[index];

                // _logger.Log("Domain: " + domain); TODO: Add back in when logger is put in
                return domain;
            }
        }

        private string RandomDomainType
        {
            get
            {
                var domainTypes = new List<string> {".com", ".org", ".net", ".biz", ".test", ".club",
                                                        ".space", ".collage"};
                var domainTypeRand = new Random();
                var index = domainTypeRand.Next(0, 7);
                var domainType = domainTypes[index];

                // _logger.Log("Domain Type: " + domainType); TODO: Add back in when logger is put in
                return domainType;
            }
        }

        public User GenerateUser()
        {
            var result = new User { FirstName = RandomFname, LastName = RandomLname };
            var randomnumber = RandomNum.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var domain = RandomDomain;
            var domainType = RandomDomainType;

            result.Email = CreateAcctEmail(result.FirstName, result.LastName, randomnumber, domain, domainType);
            return result;
        }

        public User GenerateFormValidationUser(FormTestData formdata, string fieldtype)
        {
            var randomnumber = RandomNum.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var domain = RandomDomain;
            var domainType = RandomDomainType;


            User result;
            switch (fieldtype)
            {
                case "FirstName":
                    {
                        result = new User { FirstName = formdata.FieldTestData, LastName = RandomLname };
                        break;
                    }
                case "LastName":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = formdata.FieldTestData };
                        break;
                    }

                case "MiddleName":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = formdata.FieldTestData };
                        break;
                    }
                case "Email":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, Email = formdata.FieldTestData };
                        break;
                    }

                case "Phone":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, PhoneNumber = formdata.FieldTestData };
                        break;
                    }
                case "Address1":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, Address1 = formdata.FieldTestData };
                        break;
                    }

                case "Address2":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, Address2 = formdata.FieldTestData };
                        break;
                    }
                case "City":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, City = formdata.FieldTestData };
                        break;
                    }
                case "PostalCode":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, ZipCode = formdata.FieldTestData };
                        break;
                    }

                case "MismatchPassword":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, ConfPassword = formdata.FieldTestData };
                        break;
                    }

                case "Password":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, Password = formdata.FieldTestData, ConfPassword = formdata.FieldTestData };
                        break;
                    }
                case "NotStrongPassword":
                    {
                        result = new User
                        { FirstName = RandomFname, LastName = RandomLname, Password = formdata.FieldTestData, ConfPassword = formdata.FieldTestData };
                        break;
                    }

                default:
                    {
                        result = new User { FirstName = RandomFname, LastName = RandomLname };
                        break;
                    }

            }


            result.Email = CreateAcctEmail(result.FirstName, result.LastName, randomnumber, domain, domainType);
            return result;
        }

        private int RandomNum
        {
            get
            {
                var seedNum = new Random();
                var newNumber = seedNum.Next();
                return newNumber;
            }
        }


        /// <summary>
        /// Create an email address, from randomly generated values
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="randomnumber"></param>
        /// <param name="domain"></param>
        /// <param name="domainType"></param>
        /// <returns></returns>
        private string CreateAcctEmail(string firstname, string lastname, string randomnumber, string domain, string domainType)
        {

            var email = firstname + lastname + randomnumber + "@" + domain + domainType;
            // _logger.Log("EmailAddress: " + emailaddr);  TODO: When Logger is completed
            return email;
        }


        /// <summary>
        /// Constructs an email address, using hardcoded mailinator.com as domain, which is free service email can be checked
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="randomnumber"></param>
        /// <returns></returns>
        private string CreateAcctEmail(string firstname, string lastname, string randomnumber)
        {

            var email = firstname + lastname + randomnumber + "@mailinator.com";
            // _logger.Log("EmailAddress: " + emailaddr);  TODO: When Logger is completed
            return email;
        }


    }

}

