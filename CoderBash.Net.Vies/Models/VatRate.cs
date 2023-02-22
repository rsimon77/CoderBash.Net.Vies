using System;
using CoderBash.Net.Vies.Enums;

namespace CoderBash.Net.Vies.Models
{
	public class VatRate
	{
		public EUCountryCodes Country { get; set; }
		public VatRateType Type { get; set; }

		public string Code { get; set; }
		public double Rate { get; }

		public VatRate(EUCountryCodes country, VatRateType type, double rate)
		{
			Country = country;
			Type = type;
			Rate = rate;

			Code = (rate * 100).ToString();
		}
	}
}

