#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /src
COPY . ./
RUN dotnet publish ./ClockMqtt/ClockMqtt.sln -c Release -o /app/Clock -r linux-x64 --self-contained

FROM ubuntu:focal as clock
WORKDIR /app
COPY --from=publish /app/Clock/ .
ENTRYPOINT ["/app/ClockMqtt"]
