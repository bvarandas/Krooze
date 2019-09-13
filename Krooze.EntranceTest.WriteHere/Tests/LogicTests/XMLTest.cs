using Krooze.EntranceTest.WriteHere.Structure.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects
            
            string filename = "../../../../Krooze.EntranceTest.WriteHere/Resources/Cruises.xml";

            CruiseDTO retornoCruise = null;

            XDocument doc = XDocument.Load(filename);

            var list = from c in doc.Descendants("Cruises") select new CruiseDTO()
            {
                CruiseCode = (string)c.Element("CruiseId"),
                CabinValue = (decimal)c.Element("CabinPrice"),
                PortCharge = (decimal)c.Element("PortChargesAmt"),
                ShipName = (string)c.Element("ShipName"),
                TotalValue = (decimal)c.Element("TotalCabinPrice"),
                PassengerCruise = (from f in c.Descendants("Pax")
                                   select new PassengerCruiseDTO
                                   {
                                       PassengerCode = (string)f.Attribute("PaxID"),
                                       Cruise = (from e in f.Descendants("Charge") select new CruiseDTO()
                                       {
                                           //CabinValue = (string)e.Parent.Attribute("ChargeType") == "CAB" ? (decimal)e.Element("GrossAmount"): 0,
                                           //PortCharge = (string)e.Parent.Attribute("ChargeType") == "PCH" ? (decimal)e.Element("GrossAmount") : 0,
                                           CabinValue = (decimal)f.Elements("Charge").Single(j => (string)j.Attribute("ChargeType") == "CAB").Element("GrossAmount"),
                                           PortCharge = (decimal)f.Elements("Charge").Single(j=> (string) j.Attribute("ChargeType") == "PCH").Element("GrossAmount"),
                                           TotalValue = (decimal)f.Element("AllInclusivePerPax")

                                       }).FirstOrDefault()
                                    
                                }).ToList<PassengerCruiseDTO>()

                            };
            retornoCruise = list.FirstOrDefault();

            return retornoCruise;
        }
    }
}
