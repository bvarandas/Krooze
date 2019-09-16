using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;

namespace Krooze.EntranceTest.WriteHere.Structure.DI
{
    public class Container : IGetCruise
    {

        public IGetCruise _cruise;

        public Container(IGetCruise cruise)
        {
            _cruise = cruise;
            
        }

        public int CruiseCompanyCode => 4;

        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
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
