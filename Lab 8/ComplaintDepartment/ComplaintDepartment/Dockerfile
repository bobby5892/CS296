FROM mcr.microsoft.com/dotnet/core/sdk:2.2
WORKDIR /app
COPY . /app
RUN dotnet restore
ENV ASPNETCORE_URLS="http://*.80"
EXPOSE 80/tcp
ENTRYPOINT ["dotnet","ComplaintDepartment.dll"]