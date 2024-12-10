namespace Payinvstock.Enums.Invoicing;

public enum PaymentMethod : byte
{
    Cash = 1,
    BankTransfer = 2,
    CreditCard = 3,
    Check = 4,
    Other = 5
}