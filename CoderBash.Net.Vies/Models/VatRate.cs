using System;
using CoderBash.Net.Vies.Enums;
using CoderBash.Net.Vies.Exceptions;

namespace CoderBash.Net.Vies.Models
{
	/// <summary>
	/// Model representing a specific country's VAT rate
	/// </summary>
	public class VatRate
	{
		/// <summary>
		/// The <see cref="EUCountryCodes">country</see> to which the <see cref="VatRate"/> applies.
		/// </summary>
		public EUCountryCodes Country { get; }

		/// <summary>
		/// The <see cref="VatRateType">type</see> of the <see cref="VatRate"/>. 
		/// </summary>
		public VatRateType Type { get; }

		/// <summary>
		/// Auto generator textual code for the <see cref="VatRate"/>.
		/// </summary>
		public string Code { get; }

		/// <summary>
		/// The rate (= percentage) of the <see cref="VatRate"/> represented as a double between 0 and 1.
		/// </summary>
		public double Rate { get; }

        /// <summary>
        /// Initiliazes a new instance of the <see cref="VatRate"/> class.
        /// </summary>
        /// <param name="country">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <param name="type"><see cref="VatRateType"/> option.</param>
        /// <param name="rate">The rate of the VAT regime (number between 0 and 1).</param>
        public VatRate(EUCountryCodes country, VatRateType type, double rate)
		{
			if (rate < 0 || rate > 1)
			{
				throw new VatRateException($"{nameof(rate)} contained an invalid value of {rate}. Specify a value between 0 and 1");
			}

			Country = country;
			Type = type;
			Rate = rate;

			Code = (rate * 100).ToString();
		}
	}
}

