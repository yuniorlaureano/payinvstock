using Dapper;
using Payinvstock.Contract.Dal;
using Payinvstock.Contract.Dal.Inventory.Provider;

namespace Payinvstock.Dal.Inventory.Provider;

public class UpdateProviderRepo : IUpdateProviderRepo
{
    private readonly IDapperContext _dapperContext;

    public UpdateProviderRepo(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext; ;
    }

    public async Task UpdateProviderAsync(Entity.Inventory.Provider model)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE ""Inventory"".""Provider""
                SET 
                    ""FirstName"" = @FirstName,
                    ""LastName"" = @LastName,
                    ""Identification"" = @Identification,
                    ""IdentificationType"" = @IdentificationType,
                    ""Phone"" = @Phone,
                    ""Email"" = @Email,
                    ""Street"" = @Street,
                    ""BuildingNumber"" = @BuildingNumber,
                    ""City"" = @City,
                    ""State"" = @State,
                    ""Country"" = @Country,
                    ""PostalCode"" = @PostalCode,
                    ""FormattedAddress"" = @FormattedAddress,
                    ""Latitude"" = @Latitude,
                    ""Longitude"" = @Longitude,
                    ""UpdatedAt"" = @UpdatedAt,
                    ""UpdatedBy"" = @UpdatedBy 
               WHERE ""Id"" = @Id",
            model
        );
    }
}