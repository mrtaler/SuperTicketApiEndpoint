#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY src/SuperTicketApi.ApiEndpoint/SuperTicketApi.ApiEndpoint.csproj src/SuperTicketApi.ApiEndpoint/
COPY src/SuperTicketApi.Domain.MainContext.Mssql/SuperTicketApi.Domain.MainContext.Mssql.csproj src/SuperTicketApi.Domain.MainContext.Mssql/
COPY src/SuperTicketApi.Domain.MainContext.DTO/SuperTicketApi.Domain.MainContext.DTO.csproj src/SuperTicketApi.Domain.MainContext.DTO/
COPY src/SuperTicketApi.Domain.Seedwork/SuperTicketApi.Domain.Seedwork.csproj src/SuperTicketApi.Domain.Seedwork/
COPY src/SuperTicketApi.Domain.MainContext.Queries/SuperTicketApi.Domain.MainContext.Queries.csproj src/SuperTicketApi.Domain.MainContext.Queries/
COPY src/SuperTicketApi.ApiSettings/SuperTicketApi.ApiSettings.csproj src/SuperTicketApi.ApiSettings/
COPY src/SuperTicketApi.Domain.MainContext.Command/SuperTicketApi.Domain.MainContext.Command.csproj src/SuperTicketApi.Domain.MainContext.Command/
COPY src/SuperTicketApi.Infrastructure.Crosscutting/SuperTicketApi.Infrastructure.Crosscutting.csproj src/SuperTicketApi.Infrastructure.Crosscutting/
COPY src/SuperTicketApi.Infrastructure.Crosscutting.Implementation/SuperTicketApi.Infrastructure.Crosscutting.Implementation.csproj src/SuperTicketApi.Infrastructure.Crosscutting.Implementation/
COPY src/SuperTicketApi.Application.MainContext/SuperTicketApi.Application.MainContext.csproj src/SuperTicketApi.Application.MainContext/
COPY src/SuperTicketApi.Application.BoundedContext.DTO/SuperTicketApi.Application.BoundedContext.DTO.csproj src/SuperTicketApi.Application.BoundedContext.DTO/
COPY src/SuperTicketApi.Application.Seedwork/SuperTicketApi.Application.Seedwork.csproj src/SuperTicketApi.Application.Seedwork/
RUN dotnet restore src/SuperTicketApi.ApiEndpoint/SuperTicketApi.ApiEndpoint.csproj
COPY . .
WORKDIR /src/src/SuperTicketApi.ApiEndpoint
RUN dotnet build SuperTicketApi.ApiEndpoint.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SuperTicketApi.ApiEndpoint.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SuperTicketApi.ApiEndpoint.dll"]
