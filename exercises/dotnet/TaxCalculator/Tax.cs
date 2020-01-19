using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;

namespace TaxCalculator
{
    public class Tax : TaxCalculator
    {

        public override int CalculateTax(Vehicle vehicle)
        {

            //Test
            if (IsOver40k(vehicle)) return CalculatePriceOver40k(vehicle);

            if (IsOver1YearOld(vehicle)) return CalculatePriceAfterYearOne(vehicle);


            return CalculatePriceCO2(vehicle);
        }

        private int CalculatePriceCO2(Vehicle vehicle)
        {
            switch (vehicle.FuelType)
            {
                case FuelType.Petrol:
                    return CalculatePetrol(vehicle.Co2Emissions);

                case FuelType.Diesel:
                    return CalculateDiesel(vehicle.Co2Emissions);

                case FuelType.Electric:
                    return 0;

                case FuelType.AlternativeFuel:
                    return CalculateAlternate(vehicle.Co2Emissions);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private int CalculatePriceOver40k(Vehicle vehicle) =>
            Costs.Over40kCosts.Where(x => x.Key == vehicle.FuelType.ToString()).Select(xx => xx.Value).FirstOrDefault();

        private int CalculatePriceAfterYearOne(Vehicle vehicle) =>
            Costs.FirstYearAgeCosts.Where(x => x.Key == vehicle.FuelType.ToString()).Select(xx => xx.Value).FirstOrDefault();

        private int CalculatePetrol(int vehicleEmissions) =>
                vehicleEmissions > Costs.Petrol.LastOrDefault().Key
                    ? 2070
                    : Costs.Petrol.Where(x => vehicleEmissions == x.Key).Select(xx => xx.Value).FirstOrDefault();

        private int CalculateDiesel(int vehicleEmissions) =>
                vehicleEmissions > Costs.Diesel.LastOrDefault().Key
                    ? 2070
                    : Costs.Diesel.Where(x => vehicleEmissions == x.Key).Select(xx => xx.Value).FirstOrDefault();

        private int CalculateAlternate(int vehicleEmissions) =>
                vehicleEmissions > Costs.AlternateFuel.LastOrDefault().Key
                    ? 2060
                    : Costs.AlternateFuel.Where(x => vehicleEmissions == x.Key).Select(xx => xx.Value).FirstOrDefault();

        private bool IsOver1YearOld(Vehicle vehicle) => this.Year > vehicle.DateOfFirstRegistration.AddYears(1).Year;

        private bool IsOver40k(Vehicle vehicle) => vehicle.ListPrice > 40000;
    }
}

