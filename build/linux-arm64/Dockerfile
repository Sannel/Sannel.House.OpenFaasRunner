ARG tag=2.2

FROM mcr.microsoft.com/dotnet/core/runtime:${tag} AS base
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
WORKDIR /app
COPY qemu-aarch64-static /usr/bin/
COPY Sannel.House.OpenFaasRunner/ .
RUN curl -sSL https://github.com/openfaas-incubator/of-watchdog/releases/download/0.5.1/of-watchdog-arm64 > /usr/bin/fwatchdog \
    && chmod +x /usr/bin/fwatchdog \
    && ln -s  /var/run/secrets/kubernetes.io/serviceaccount/ca.crt /etc/ssl/certs/kubernetes.pem \
    && groupadd -g 1200 house \
    && useradd -m house -g house -u 1100 \
    && chown -R house:house /app \
    && rm -f /usr/bin/qemu-aarch64-static
USER house
ENV fprocess="dotnet ./Sannel.House.OpenFaasRunner.dll"
ENV cgi_headers="true"
ENV mode="http"
ENV upstream_url="http://localhost:5000"
EXPOSE 8080

HEALTHCHECK --interval=3s CMD [ -e /tmp/.lock ] || exit 1
CMD ["fwatchdog"]