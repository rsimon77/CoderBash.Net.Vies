# CoderBash.Net.Vies

[![.NET](https://github.com/CoderBash/CoderBash.Net.Vies/actions/workflows/main.yml/badge.svg)](https://github.com/CoderBash/CoderBash.Net.Vies/actions/workflows/main.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=coderbash-net-vies&metric=alert_status&token=01c5786f7f875cc2c668c0f599a45b10580ae1af)](https://sonarcloud.io/summary/new_code?id=coderbash-net-vies)

Integrate the [VIES Service](https://ec.europa.eu/taxation_customs/vies/#/vat-validation) API into your .NET project!

The CoderBash VIES .NET Library targets .NET 8.0 and includes both a library and a Blazor Server UI.

## Projects in this Solution

- **CoderBash.Net.Vies** - Core library for VAT validation and rate lookup
- **CoderBash.Net.Vies.BlazorUI** - Blazor Server web application with interactive UI
- **CoderBash.Net.Vies.Tests** - Unit tests for the library

## Installation with Nuget
To install the library via NuGet:
* Search for `CoderBash.Net.Vies` in the NuGet Library, or
* Type `Install-Package CoderBash.Net.Vies` in the NuGet Package Manager, or
* Install using the dotnet CLI with `dotnet add package CoderBash.Net.Vies`

## Usage

### Using the Blazor UI
Run the Blazor Server application for an interactive web interface:

```bash
cd CoderBash.Net.Vies.BlazorUI
dotnet run
```

The web application provides:
- **VAT Number Validation** - Interactive form to validate EU VAT numbers
- **VAT Rates Lookup** - Browse and filter VAT rates for all EU member states

### Using the Library Programmatically

#### 1. Validating VAT numbers
To validate VAT numbers you can use the `ViesClient` class:

```C#
var client = new ViesClient();

var vatResult = await client.ValidateVatNumberAsync(EUCountryCodes.BE, "someVatNumber");

if (vatResult.isValid) {
  Console.WriteLine("Valid VAT number:");
  Console.WriteLine(" - Company = " + vatResult.Name);
  Console.WriteLine(" - Address = " + vatResult.Address);
} else {
  Console.WriteLine("Invalid VAT number.");
}
```

#### 2. Get VAT Rate information
With the VatClient you can retrieve specific VAT rate information for a country. 

```C#
var client = new VatClient();

var rates = client.GetRatesForCountry("BE");
```
