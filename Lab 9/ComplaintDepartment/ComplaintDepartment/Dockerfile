# download a base image from the repository
FROM mcr.microsoft.com/dotnet/core/sdk:2.2
# set the working directory for the Docker image
WORKDIR /app

# copy the project file into the image and restore dependencies
COPY ComplaintDepartment.csproj ./
RUN dotnet restore

# copy the source code and build it
COPY . ./
RUN dotnet publish -c Release -o out

# run the web app

ENTRYPOINT ["dotnet","out/ComplaintDepartment.dll"]