namespace Inventory.Infrastructure.Utilities
{
    public class DefaultConstants
    {
        public const string DefaultDatabaseConnection = nameof(DefaultConstants.DefaultDatabaseConnection);
        public const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        public const string InitialSeedings = "InitialSeedings";
        public const string DbConnectionDirectory = "Inventory.Api";
        public const string AppSettingsJson = "appsettings.json";
        public const string ElasticUri = "ElasticConfiguration:Uri";
        public const string RefreshToken = "refreshToken";
        public const string RefreshTokenEndDate = "refreshTokenEndDate";

        public const string CustomTokenOptions = nameof(CustomTokenOptions);

        public const string ConnectionStrings = nameof(ConnectionStrings);

        public const string Header = "header";
        public const string ApiKey = "apiKey";
        public const string Authorization = "Authorization";

        public const string DefaultDatabase = "InventoryDb";

        public const string Logging = nameof(Logging);
        public const string ProduceJson = "application/json";
        public const string ProduceOdata = "application/prs.odatatestxx-odata";
        public const string Bearer = "Bearer";
        public const string AllowedUserNameCharacters = "abcdefghijklmnopqrsştuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
        public const string Version = "v1";
        public const string SwaggerDescription = "This project belongs to Inventory© Corp.";
        public const string SwaggerSecurityDescription = "Jwt Authorization header using the bearer scheme!";
        public const string SwaggerTitle = "Inventory's API";
        public const string SwaggerContactName = "Hakan Karabulut";
        public const string SwaggerLicenceName = "All rights reserved. © Inventory";
        public const string SwaggerContactEmail = "hakan@karabulut.com.tr";
        public const string SwaggerContactUrl = "https://www.karabuluthakan.com.tr/";
        public const string UploadPath = "Uploads/Images";
        public const string RequestPath = "/StaticFiles";
        public const string CorporateAuth = "/corporate-based-authorization";
        public const string InvalidImage = "Invalid image file";
    }
}