using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Krooze.EntranceTest.WriteHere;
using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Microsoft.AspNetCore.Authorization;
using Krooze.EntranceTest.WriteHere.Structure.Model;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/cruise")]
    [ApiController]
    public class CruiseController : BaseController
    {
        public IInjectionTest _injectionTest;
        public ISimpleLogicTest _simpleLogicTest;
        public IXMLTest _xmlTest;
        public IWebTest _webTest;

        public CruiseController(IInjectionTest injectionTest, ISimpleLogicTest simpleLogicTest, IXMLTest xmlTest, IWebTest webTest )
        {
            _injectionTest = injectionTest;
            _simpleLogicTest = simpleLogicTest;
            _xmlTest = xmlTest;
            _webTest = webTest;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("logicTest/taxes")]
        public IActionResult GetOtherTaxes(CruiseDTO cruiseDTO )
        {
            return Response(_simpleLogicTest.GetOtherTaxes(cruiseDTO));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("logicTest/discount")]
        public IActionResult IsThereDiscount(CruiseDTO cruiseDTO)
        {
            return Response(_simpleLogicTest.GetOtherTaxes(cruiseDTO));
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("logicTest/Installments")]
        public IActionResult GetInstallments(decimal fullPrice)
        {
            return Response(_simpleLogicTest.GetInstallments(fullPrice));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("xmltest/")]
        public IActionResult TranslateXML()
        {
            return Response(_xmlTest.TranslateXML());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("webtest/director/")]
        public IActionResult GetDirector()
        {
            return Response(_webTest.GetDirector());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("webtest/movies")]
        public IActionResult GetAllMovies()
        {
            return Response(_webTest.GetAllMovies());
        }
    }
}