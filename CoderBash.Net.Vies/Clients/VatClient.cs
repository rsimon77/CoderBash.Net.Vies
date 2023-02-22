using System;
using CoderBash.Net.Vies.Data;
using CoderBash.Net.Vies.Enums;
using CoderBash.Net.Vies.Models;

namespace CoderBash.Net.Vies.Clients
{
	public class VatClient
	{
		private readonly EUVatRates _rates;

		public VatClient()
		{
			_rates = new EUVatRates();
		}

		public List<VatRate> GetRatesForCountry(string countryCode)
		{
			return GetRatesForCountry(Enum.Parse<EUCountryCodes>(countryCode));
		}

		public List<VatRate> GetRatesForCountry(EUCountryCodes country)
		{
			return GetRates(country);
		}

		public VatRate GetStandardRateForCountry(string countryCode)
		{
			return GetStandardRateForCountry(Enum.Parse<EUCountryCodes>(countryCode));
		}

		public VatRate GetStandardRateForCountry(EUCountryCodes country)
		{
			return GetRates(country, VatRateType.Standard).First();
		}

		public List<VatRate> GetReducedRatesForCountry(string countryCode)
		{
			return GetReducedRatesForCountry(Enum.Parse<EUCountryCodes>(countryCode));
		}

		public List<VatRate> GetReducedRatesForCountry(EUCountryCodes country)
		{
			return GetRates(country, VatRateType.Reduced);
		}

		public VatRate? GetSuperReducedRateForCountry(string countryCode)
		{
			return GetSuperReducedRateForCountry(Enum.Parse<EUCountryCodes>(countryCode));
		}

		public VatRate? GetSuperReducedRateForCountry(EUCountryCodes country)
		{
			return GetRates(country, VatRateType.SuperReduced).FirstOrDefault();
		}

		public VatRate? GetParkingRateForCountry(string countryCode)
		{
			return GetParkingRateForCountry(Enum.Parse<EUCountryCodes>(countryCode));
		}

		public VatRate? GetParkingRateForCountry(EUCountryCodes country)
		{
			return GetRates(country, VatRateType.Parking).FirstOrDefault();
		}

		private List<VatRate> GetRates(EUCountryCodes forCountry, VatRateType? forType = null)
		{
			var query = _rates.Where(rate => rate.Country == forCountry);

			if (forType != null)
			{
				query = query.Where(rate => rate.Type == forType);
			}

			return query.ToList();
		}
	}
}

