using System;
using CoderBash.Net.Vies.Clients;
using CoderBash.Net.Vies.Enums;
using CoderBash.Net.Vies.Exceptions;
using CoderBash.Net.Vies.Models;

namespace CoderBash.Net.Vies.Tests
{
	[TestFixture(
		Author = "NicolasDemarbaix",
		Category = "CoderBash.Net.Vat",
		Description = "Vat Client tests",
		TestOf = typeof(VatClient))]
	public class VatClientTests
	{
		[Test(
			Author = "NicolasDemarbaix",
			Description = "Check invalid rate value.")]
		public void Test_Vat_InvalidRateValue()
		{
			Assert.Throws<VatRateException>(() => new VatRate(EUCountryCodes.BE, VatRateType.Standard, 21));
		}

		[Test(
			Author = "NicolasDemarbaix",
			Description = "Get valid rates for country")]
		public void Test_Vat_FetchValidRates()
		{
			var client = new VatClient();

			Assert.DoesNotThrow(() =>
			{
				var rates = client.GetRatesForCountry("BE");

				Assert.Multiple(() =>
				{
					Assert.That(rates, Is.Not.Null);
					Assert.That(rates, Has.Count.EqualTo(4));
					Assert.That(rates.Count(rate => rate.Type == VatRateType.Standard), Is.EqualTo(1));
				});
			});
		}

		[Test(
			Author = "NicolasDemarbaix",
			Description = "Get Valid Standard Rate")]
		public void Test_Vat_FetchValidStandardRate()
		{
			var client = new VatClient();

			var standardRate = client.GetStandardRateForCountry("BE");

			Assert.Multiple(() =>
			{
				Assert.That(standardRate, Is.Not.Null);
				Assert.That(standardRate.Type, Is.EqualTo(VatRateType.Standard));
				Assert.That(standardRate.Code, Is.EqualTo("21"));
			});
		}

		[Test(
			Author = "NicolasDemarbaix",
			Description = "Get Valid Reduced Rates")]
		public void Test_Vat_FetchValidReducedRates()
		{
			var reducedRates = new VatClient().GetReducedRatesForCountry("BE");

			Assert.Multiple(() =>
			{
				Assert.That(reducedRates, Is.Not.Null);
				Assert.That(reducedRates, Has.Count.EqualTo(2));
				Assert.That(reducedRates.Any(rate => rate.Type != VatRateType.Reduced), Is.False);
			});
		}

		[Test(Author = "NicolasDemarbaix",
			Description = "Get Valid Parking Rate")]
		public void Test_Vat_FetchValidParkingRate()
		{
			var parkingRate = new VatClient().GetParkingRateForCountry("BE");

			Assert.Multiple(() =>
			{
				Assert.That(parkingRate, Is.Not.Null);
				Assert.That(parkingRate!.Type, Is.EqualTo(VatRateType.Parking));
			});
		}

        [Test(Author = "NicolasDemarbaix",
            Description = "Get Invalid Parking Rate")]
        public void Test_Vat_FetchInvalidParkingRate()
        {
            var parkingRate = new VatClient().GetParkingRateForCountry("BG");

			Assert.That(parkingRate, Is.Null);
        }

        [Test(Author = "NicolasDemarbaix",
            Description = "Get Valid Super Reduced Rate")]
        public void Test_Vat_FetchValidSuperReducedRate()
        {
            var superReducedRate = new VatClient().GetSuperReducedRateForCountry("FR");

			Assert.Multiple(() =>
			{
                Assert.That(superReducedRate, Is.Not.Null);
				Assert.That(superReducedRate!.Type, Is.EqualTo(VatRateType.SuperReduced));
            });
        }


        [Test(Author = "NicolasDemarbaix",
            Description = "Get Invalid Super Reduced Rate")]
        public void Test_Vat_FetchInvalidSuperReducedRate()
        {
            var superReducedRate = new VatClient().GetSuperReducedRateForCountry("BG");

            Assert.That(superReducedRate, Is.Null);
        }

		[Test(Author = "NicolasDemarbaix",
			Description = "Get Data for invalid country")]
		public void Test_Vat_GetDataForInvalidCountry()
		{
			Assert.Throws<ArgumentException>(() => new VatClient().GetRatesForCountry("GB"));
		}
    }
}

