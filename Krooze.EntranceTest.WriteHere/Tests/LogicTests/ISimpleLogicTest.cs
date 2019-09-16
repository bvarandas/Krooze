using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public interface ISimpleLogicTest
    {
        decimal? GetOtherTaxes(CruiseDTO cruise);

        bool? IsThereDiscount(CruiseDTO cruise);

        int? GetInstallments(decimal fullPrice);


    }
}
