using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krooze.EntranceTest.WriteHere.Structure.Implementations
{
    public  class Company
    {
        private readonly IGetCruise _cruise;

        public int CruiseCompanyCode { get; set; }

        public Company(IGetCruise cruise)
        {
            _cruise = cruise;
        }

        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            return _cruise.GetCruises(request);
        }
    }
}
