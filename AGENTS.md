# Repository Guidelines

## Project Structure & Module Organization

This repository contains the Memtly Community ASP.NET web host.

- `Memtly.Community.sln` is the solution entry point.
- `Memtly.Community/` contains the web application, including `Program.cs`, `Startup.cs`, `appsettings.json`, Dockerfile, service dependency metadata, and static files under `wwwroot/`.
- `Memtly.Core/` is a required git submodule. The app references core runtime and migration projects from this folder.
- `.github/workflows/docker-image.yml` and `.gitlab-ci.yml` define CI build, test, Docker image, and release behavior.

Initialize dependencies before building:

```bash
git submodule update --init --recursive --remote
```

## Build, Test, and Development Commands

Use the SDK pinned in `global.json` (`10.0.301`).

```bash
dotnet restore Memtly.Community.sln
```

Restores NuGet packages for the solution.

```bash
dotnet build Memtly.Community.sln --configuration Release
```

Builds the web host and referenced submodule projects.

```bash
dotnet run --project Memtly.Community/Memtly.Community.csproj
```

Runs the app locally on `http://localhost:5000`.

```bash
dotnet test Memtly.Community.sln --configuration Release --no-restore
```

Runs available tests; add test projects to the solution as they are introduced.

```bash
docker build -f Memtly.Community/Dockerfile -t memtly-community .
```

Builds the container image using the production Dockerfile.

## Coding Style & Naming Conventions

Follow the existing C# style: file-scoped imports, four-space indentation, braces on their own lines, nullable reference types enabled, and implicit usings enabled. Use PascalCase for public types and members, camelCase for locals and parameters, and clear descriptive names for configuration keys. Keep host-specific code in `Memtly.Community`; shared behavior belongs in `Memtly.Core`.

## Testing Guidelines

There are no dedicated test projects in this checkout. When adding tests, create clearly named projects such as `Memtly.Community.Tests` or add tests in the appropriate `Memtly.Core` test project, then include them in `Memtly.Community.sln`. Prefer tests named after the behavior under test, for example `GalleryUploadRejectsUnsupportedFileTypes`.

## Commit & Pull Request Guidelines

Recent history uses release branches and messages such as `Release/1.0.4.4`, with merge commits into `master`. For feature work, use concise imperative commit messages and branch names compatible with CI, such as `feature/gallery-upload-validation` or `release/1.0.5.0`.

Pull requests should include a short summary, testing performed, linked issues when applicable, and screenshots for UI changes. Note any submodule updates explicitly so reviewers can verify the referenced `Memtly.Core` revision.

## Security & Configuration Tips

Do not commit secrets or production connection strings. Prefer environment variables, user secrets, or deployment-specific configuration. Keep `sixlabors.lic` handling intact and avoid moving license files without updating the project file.
