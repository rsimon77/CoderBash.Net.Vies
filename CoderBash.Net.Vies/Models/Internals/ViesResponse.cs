using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Vies.Models.Internals
{
	internal class ViesResponse
	{
		[JsonProperty("isValid")]
		public bool IsValid { get; set; }

		[JsonProperty("requestDate")]
		public DateTime RequestDate { get; set; }

		[JsonProperty("userError")]
		public string UserError { get; set; } = null!;

		[JsonProperty("name")]
		public string Name { get; set; } = null!;

		[JsonProperty("address")]
		public string Address { get; set; } = null!;

		[JsonProperty("requestIdentifier")]
		public string RequestIdentifier { get; set; } = null!;

		[JsonProperty("vatNumber")]
		public string VatNumber { get; set; } = null!;
	}
}

