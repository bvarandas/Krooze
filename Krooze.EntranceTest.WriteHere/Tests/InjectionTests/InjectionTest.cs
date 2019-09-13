using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.Implementations;
using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest
    {
        private readonly IServiceCollection _services;

        private readonly IGetCruise _cruise;
        public InjectionTest()
        {
            _services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            this.RegisterServices();
            var provider =_services.BuildServiceProvider();
            _cruise =(IGetCruise)provider.GetRequiredService(typeof(Company1));
        }

        public void RegisterServices() 
        {
            _services.AddScoped<IGetCruise, Company1>();
            _services.AddScoped<IGetCruise, Company2>();
            _services.AddScoped<IGetCruise, Company3>();

        }

        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //without directly referencing the 3 classes and the method GetCruises of the chosen implementation is called
            List<CruiseDTO> listCruise = null;

            try
            {
                listCruise = _cruise.GetCruises(request);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            

            return listCruise;
        }
    }
}
