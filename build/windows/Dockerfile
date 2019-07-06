ARG tag=2.2
FROM mcr.microsoft.com/dotnet/core/runtime:${tag} AS base
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
WORKDIR /app
COPY fwatchdog.exe c:/fwatchdog.exe
USER ContainerUser

ENV fprocess="dotnet ./Sannel.House.OpenFaasRunner.dll"
ENV cgi_headers="true"
ENV mode="http"
ENV upstream_url="http://localhost:5000"
EXPOSE 8080

CMD ["c:/fwatchdog.exe"]