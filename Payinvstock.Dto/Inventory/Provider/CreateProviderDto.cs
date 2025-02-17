﻿using Payinvstock.Enums;

namespace Payinvstock.Dto.Inventory.Provider;

public class CreateProviderDto
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Identification { get; set; }
    public IdentificationType IdentificationType { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public string? Street { get; set; }
    public string? BuildingNumber { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? FormattedAddress { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
