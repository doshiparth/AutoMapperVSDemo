using AutoMapper;
using System;

namespace MapperDemoProject
{
    class Program
    {
        static int Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Model1, Model2>()
                .ForMember(destinationOld => destinationOld.ContactDetails, 
                opts => opts.MapFrom(sourceOld => sourceOld.ContactNumber))
                .ForMember(destinationOld => destinationOld.CityName,
                map => map.MapFrom(sourceOld => sourceOld.Address.CityName))
                .ForMember(destinationOld => destinationOld.StateName,
                map => map.MapFrom(sourceOld => sourceOld.Address.StateName))
                .ForMember(destinationOld => destinationOld.StreetName,
                map => map.MapFrom(sourceOld => sourceOld.Address.StreetName))
                .ForMember(destinationOld => destinationOld.CountryName,
                map => map.MapFrom(sourceOld => sourceOld.Address.CountryName)));

            IMapper iMapper = config.CreateMapper();

            Model1 source = new Model1()
            {
                FirstName = "Parth",
                LastName = "Doshi",
                Address = (new Address()
                {
                    CityName = "Ahmedabad",
                    StateName = "Gujarat",
                    CountryName = "India",
                    StreetName = "Gota"
                }),
                ContactNumber = "1234567890"
            };

            //Automapper handles null reference exception on its own
            Model2 destination = iMapper.Map<Model1, Model2>(source);

            Console.WriteLine("\nFirs tName is {0} \n", destination.FirstName);
            Console.WriteLine("Last Name is {0} \n", destination.LastName);
            Console.WriteLine("Address:-");
            Console.WriteLine("Street Name is {0}\nCity Name is {1}\nState Name is {2}\nThe Country Name is {3} \n", destination.StreetName, destination.CityName, destination.StateName, destination.CountryName);
            Console.WriteLine("Contact number is {0} \n", destination.ContactDetails);

            Console.ReadKey();
            return 5;
        }
    }
}
