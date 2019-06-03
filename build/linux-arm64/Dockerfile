ARG tag=2.2
FROM openfaas/classic-watchdog:0.13.4-arm64 as watchdog

FROM mcr.microsoft.com/dotnet/core/runtime:${tag} AS base
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
WORKDIR /app
COPY qemu-aarch64-static /usr/bin/
COPY Sannel.House.OpenFaasRunner/ .
COPY --from=watchdog /fwatchdog /usr/bin/fwatchdog
RUN chmod +x /usr/bin/fwatchdog \
    && ln -s  /var/run/secrets/kubernetes.io/serviceaccount/ca.crt /etc/ssl/certs/kubernetes.pem \
    && groupadd -g 1200 house \
    && useradd -m house -g house -u 1100 \
    && chown -R house:house /app \
    && rm -f /usr/bin/qemu-aarch64-static
USER house
ENV fprocess="dotnet ./Sannel.House.OpenFaasRunner.dll"
EXPOSE 8080

HEALTHCHECK --interval=3s CMD [ -e /tmp/.lock ] || exit 1
CMD ["fwatchdog"]