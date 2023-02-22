using System;
using CoderBash.Net.Vies.Enums;
using CoderBash.Net.Vies.Exceptions;
using CoderBash.Net.Vies.Models;
using CoderBash.Net.Vies.Models.Internals;
using Newtonsoft.Json;

namespace CoderBash.Net.Vies.Clients
{
	public sealed class ViesClient : IDisposable
	{
		private readonly HttpClient _client;

		public ViesClient()
		{
			_client = SetupClient();
		}

		public async Task<VatValidationResponse> ValidateVatNumberAsync(string countryCode, string vatNumber, CancellationToken cancellationToken = default)
		{
			var country = (EUCountryCodes)Enum.Parse(typeof(EUCountryCodes), countryCode);

			return await ValidateVatNumberAsync(country, vatNumber, cancellationToken);
		}

		public async Task<VatValidationResponse> ValidateVatNumberAsync(EUCountryCodes country, string vatNumber, CancellationToken cancellationToken = default)
		{
			var response = await _client.GetAsync($"{country}/vat/{vatNumber}", cancellationToken);

			if (!response.IsSuccessStatusCode)
			{
				throw new ViesRequestException($"An error occured fetching VAT information from VIES: {response.ReasonPhrase}");
			}

			var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

			if (responseContent == null)
			{
				throw new ViesRequestException("Unable to read response content from VAT information request.");
			}

			var viesResponse = JsonConvert.DeserializeObject<ViesResponse>(responseContent);

			if (viesResponse == null)
			{
				throw new ViesModelException("Could not deserialize expected VIES model from response content of the VAT information request.");
			}

			return new VatValidationResponse
			{
				Address = viesResponse.Address,
				Country = country,
				IsValid = viesResponse.IsValid,
				Name = viesResponse.Name,
				RequestDate = viesResponse.RequestDate,
				VatNumber = viesResponse.VatNumber
			};
		}

        #region IDisposable implementation
		public void Dispose()
		{
			GC.SuppressFinalize(this);

			_client.Dispose();
		}
        #endregion

        #region Setup
		private static HttpClient SetupClient()
		{
			var client = new HttpClient()
			{
				BaseAddress = new Uri("https://ec.europa.eu/taxation_customs/vies/rest-api/ms/")
			};

			return client;
		}
        #endregion
    }
}

