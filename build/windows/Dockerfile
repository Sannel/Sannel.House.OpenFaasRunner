ARG tag=2.2
FROM openfaas/classic-watchdog:0.13.4-windows as watchdog

FROM mcr.microsoft.com/dotnet/core/runtime:${tag} AS base
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
WORKDIR /app
COPY Sannel.House.OpenFaasRunner/ .
COPY --from=watchdog /fwatchdog.exe /windows/fwatchdog.exe
USER ContainerUser
ENV fprocess="dotnet ./Sannel.House.OpenFaasRunner.dll"
EXPOSE 8080

CMD ["fwatchdog"]