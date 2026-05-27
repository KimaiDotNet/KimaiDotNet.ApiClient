# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0-beta1] - 2025-05-27

### Breaking Changes

- Replaced AutoRest v2 generated client (`Kimai2APIDocs`) with Microsoft Kiota generated client (`KimaiClient`)
- Updated API specification from Swagger 2.0 to OpenAPI 3.0.0 — adds new endpoints (Kiosk, Absences), removes `/api/config/i18n`
- Models now use object-initializer syntax instead of parameterized constructors
- Methods return model types directly and throw `Microsoft.Kiota.Abstractions.ApiException` on errors (previously returned `HttpOperationResponse<T>`)
- `VersionObject` properties changed: `Name`/`Semver`/`VersionProperty` → `Version`/`VersionId`/`Copyright`
- Client initialisation changed: `new Kimai2APIDocs(httpClient, false)` → `new KimaiClient(adapter)` with `HttpClientRequestAdapter` and `AnonymousAuthenticationProvider`

### Changed

- Replaced `Microsoft.Rest.ClientRuntime`, `Newtonsoft.Json`, and `Polly` dependencies with `Microsoft.Kiota.Bundle 1.22.1`
- Dropped Nuke build system in favour of direct `dotnet` CLI in GitHub Actions
- CI workflow updated: runs on `ubuntu-latest`, publishes to NuGet.org automatically on `v*` tags
- NuGet package now includes `README.md`
- Target framework remains `netstandard2.0`

## [0.2.0] - 2021-01-18
- Retarget to .netstandard2.0

## [0.1.0] - 2020-12-15
- Initial commit of autorest generated client