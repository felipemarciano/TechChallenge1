
# Publicar

## Azure ARM
	az login
	az group create --name rg-techchallenge1-dev --location eastus2
	az group deployment create --name Techchallenge1Deployment --resource-group rg-techchallenge1-dev --template-file ./template.json --parameters storageAccountName=sttechchallenge1dev sqlServerName=sqldb-techchallenge1-dev sqlDatabaseName=dbTechChallenge1 webAppName=app-techchallenge1 apiAppName=app-techchallenge1

## Configuração AzureSql
	- https://learn.microsoft.com/en-us/azure/azure-sql/database/network-access-controls-overview?view=azuresql#allow-azure-services

## Metodo Usado de publicação
	- Download do publish profile e realizado publish via visual studio

## StorageAccount
	### Alterar AzureBlobStorage.StorageConnectionString:
		az storage account show-connection-string --name sttechchallenge1dev --resource-group rg-techchallenge1-dev --output tsv
	### Criar um container e alterar no appsettings AzureBlobStorage.BlobContainerName do projeto TechChallenge1.Web 

# Editar Projeto

## Criar Migrations
	dotnet ef migrations add {Name} -c AppIdentityDbContext --project .\TechChallenge1.Infrastructure\TechChallenge1.Infrastructure.csproj --startup-project .\TechChallenge1.Api\TechChallenge1.Api.csproj --output-dir .\Identity\Migrations
	dotnet ef migrations add {Name} -c TechDbContext --project .\TechChallenge1.Infrastructure\TechChallenge1.Infrastructure.csproj --startup-project .\TechChallenge1.Api\TechChallenge1.Api.csproj --output-dir .\Data\Migrations\TechDb

# Prints

	## Api
	![Api](https://raw.githubusercontent.com/felipemarciano/TechChallenge1/blob/master/Screenshot_api.png)

	## Register
	![Register](https://raw.githubusercontent.com/felipemarciano/TechChallenge1/blob/master/Screenshot_register.png)

	## Login
	![Login](https://raw.githubusercontent.com/felipemarciano/TechChallenge1/blob/master/Screenshot_login.png)

	## Index
	![Index](https://raw.githubusercontent.com/felipemarciano/TechChallenge1/blob/master/Screenshot_index.png)

	## Profile
	![Profile](https://raw.githubusercontent.com/felipemarciano/TechChallenge1/blob/master/Screenshot_index.png)

# Referências

- https://learn.microsoft.com/en-us/cli/azure/
- https://github.com/dotnet-architecture/eShopOnWeb
- https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio
- https://github.com/ardalis/CleanArchitecture
- https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-7.0#blazor-server
- https://www.mudblazor.com/docs/overview
- https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming
