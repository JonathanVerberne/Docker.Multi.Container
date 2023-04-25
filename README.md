# Docker.Multi.Container 
Multiple docker containers for web and database.

This project demonstrates the use of multiple docker containers in a single network. The first container is used to run an asp.net website and the other container is used for a PostgreSQL database.

In this sample project I've added two options to run the website, one being without SSL and the other with SSL on HTTPS with a self signed certificate.

## Get Started
 1. Clone this repo.

Next pick option 1 or option 2.

## Option 1 - No SSL/HTTP

 2. Navigate and run the docker-compose.yml file located in Docker.Multi.Container/Docker/

## Option 2 - SSL/HTTPS

 2. Create self-signed SSL Certificate
```
.NET CLI
  dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p password
  dotnet dev-certs https --trust
```
Navigate and run the docker-compose.yml file located in Docker.Multi.Container/Docker/HTTPS

