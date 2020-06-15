using System;

namespace WebApplication.Resources
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }
    
    public class Address
    {
        public String street { get; set; }
        public String suite { get; set; }
        public String city { get; set; }
        public String zipcode { get; set; }
        public Coordinates geo { get; set; }
    }

    public class Coordinates
    {
        public String lat { get; set; }
        public String lng { get; set; }
    }
    
    public class Company
    {
        public String name { get; set; }
        public String catchPhrase { get; set; }
        public String bs { get; set; }
    }
}