using System;
using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.DI;
using Krooze.EntranceTest.WriteHere.Structure.Implementations;
using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest : IInjectionTest
    {
        private readonly IServiceCollection _services;
        private  Company _cruiser;
        public InjectionTest()
        {
            _services = new ServiceCollectionOther();
        }

        

        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //without directly referencing the 3 classes and the method GetCruises of the chosen implementation is called
            List<CruiseDTO> listCruise = null;
            
            switch (request.CruiseCompanyCode)
            {
                case 1:
                _services.AddTransient<IGetCruise, Company1>();
                    break;
                case 2:
                    _services.AddTransient<IGetCruise, Company2>();
                    break;
                case 3:
                    _services.AddTransient<IGetCruise, Company3>();
                    break;
                default:
                    throw new Exception();
                    //break;
            }
            
            _services.AddTransient(prov => new Company(prov.GetService<IGetCruise>()));

            var serviceProvider = _services.BuildServiceProvider(); 

            _cruiser = serviceProvider.GetService<Company>();

            try
            { 
                listCruise = _cruiser.GetCruises(request);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            

            return listCruise;
        }
    }
}
