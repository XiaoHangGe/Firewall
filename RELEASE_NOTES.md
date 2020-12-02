Release Notes
=============

## 3.0.0

- Upgraded to .NET 5 and removed support for all other target frameworks.

.NET 5 is the progression of .NET Core as well as .NET Framework and Firewall will not support outdated frameworks after this version anymore. Please upgrade projects to .NET 5 in order to use Firewall. If this is not immediately possible then you can keep using Firewall 2.2.1 until the migration has happened.

## 2.2.1

#### Bug fixes

- Fixed a bug where `UseFirewall` crashed when no value has been provided for `accessDeniedDelegate`.

## 2.2.0

#### New features

- A custom `RequestDelegate` object can be configured for blocked requests.
- Fixed a typos in log messages.

## 2.1.1

#### Bug fixes

- Fixed a minor issue where some log information was missing when debug logging was enabled.

## 2.1.0

#### New features

- Added more detailed debug logging to rules engine.

#### Bug fixes

- `CountryRule` now properly handles an `AddressNotFoundException` exception.

## 2.0.0

Changed the Firewall middleware to allow request filtering beyond simple IP address and IP address range checks and significantly simplified how Firewall rules are configured.

See the updated README for more detailed information.

#### Breaking changes

- Removed the `ICloudflareHelper` interface as it served no purpose.
- Removed the `AddFirewall` extension method to register dependencies which are not required any more.
- Removed the `UseCloudflareFirewall` extension method. This has been replaced by a new rules engine.

#### New features

- Added request filtering by countries using the GeoIP2 database.
- Added custom request filtering features.

## 1.1.0

First stable and fully functional version of IP address filtering for ASP.NET Core.

## 1.0.0-alpha-001

First alpha test version.

## 1.0.0

Non functional placeholder to register the NuGet package name.