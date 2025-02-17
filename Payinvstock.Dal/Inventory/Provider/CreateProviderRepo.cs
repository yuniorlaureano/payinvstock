using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Provider;

namespace Payinvstock.Dal.Inventory.Provider;

public class CreateProviderRepo : ICreateProviderRepo
{
    private readonly IDapperContext _dapperContext;

    public CreateProviderRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateProviderAsync(Entity.Inventory.Provider model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @$"INSERT INTO ""Inventory"".""Provider"" (""FirstName"", ""LastName"", ""Identification"", ""IdentificationType"", ""Phone"", ""Email"", ""Street"", ""BuildingNumber"", ""City"", ""State"", ""Country"", ""PostalCode"", ""FormattedAddress"", ""Latitude"", ""Longitude"", ""CreatedAt"", ""CreatedBy"") 
                                              VALUES  (@FirstName, @LastName, @Identification, @IdentificationType, @Phone, @Email, @Street, @BuildingNumber, @City, @State, @Country, @PostalCode, @FormattedAddress, @Latitude, @Longitude, @CreatedAt, @CreatedBy)",
            model
        );
    }
}