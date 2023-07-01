terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.2"
    }
  }

  required_version = ">= 1.1.0"
}

provider "azurerm" {
  features {}
}

# Set the variable value in the terraform.tfvars file
variable "location" {
  default = "westus2"
}

# Configure the Azure Resource Group
resource "azurerm_resource_group" "rg" {
  name     = "example-resources"
  location = var.location
}

# Configure the Azure Storage Account
resource "azurerm_storage_account" "sa" {
  name                     = "examplestorageacct"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "GRS"
}

# Configure the Azure SQL Server
resource "azurerm_sql_server" "sqlserver" {
  name                         = "examplesqlserver"
  resource_group_name          = azurerm_resource_group.rg.name
  location                     = azurerm_resource_group.rg.location
  version                      = "12.0"
  administrator_login          = "4dm1n157r470r"
  administrator_login_password = "4-v3ry-53cr37-p455w0rd"
}

# Configure the Azure App Service Plan
resource "azurerm_app_service_plan" "plan" {
  name                = "example-app-service-plan"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "Windows"
  sku {
    tier = "Standard"
    size = "S1"
  }
}

# Configure the Azure App Service
resource "azurerm_app_service" "app" {
  name                = "example-app-service"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.plan.id
  site_config {
    dotnet_framework_version = "v7.0"
  }
  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = "1"
  }
}
