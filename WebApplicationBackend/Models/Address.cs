using System;

namespace WebApplication.Resources
{
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
}