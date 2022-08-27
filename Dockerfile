#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /src
COPY . ./
RUN dotnet publish ./ClockMqtt/ClockMqtt.sln -c Release -o /app/Clock -r linux-x64 --self-contained
RUN dotnet publish ./DisplayMqtt/DisplayMqtt.sln -c Release -o /app/Display -r linux-x64 --self-contained
RUN dotnet publish ./TimerMqtt/TimerMqtt.sln -c Release -o /app/Timer -r linux-x64 --self-contained

FROM ubuntu:focal AS clock
WORKDIR /app
COPY --from=publish /app/Clock/ .

FROM ubuntu:focal AS display
WORKDIR /app
COPY --from=publish /app/Display/ .

FROM ubuntu:focal AS timer
WORKDIR /app
COPY --from=publish /app/Timer/ .

