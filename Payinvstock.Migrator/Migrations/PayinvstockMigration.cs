using FluentMigrator;
using Payinvstock.Common.Constants;
using Payinvstock.Entity.General;
using Payinvstock.Entity.Inventory;
using Payinvstock.Entity.Invoicing;
using Payinvstock.Enums.Invoicing;

namespace Payinvstock.Migrator.Migrations
{
    [Migration(20200927)]
    public class PayinvstockMigration : Migration
    {
        public override void Down()
        {
            //Invoicing
            Delete.Table(nameof(PurchaseDetail));
            Delete.Table(nameof(AccountsReceivableDetail));
            Delete.Table(nameof(InvoiceDetailProductAdjustment));
            Delete.Table(nameof(InvoiceDetail));
            Delete.Table(nameof(InvoiceDelivery));
            Delete.Table(nameof(ClientCredit));
            Delete.Table(nameof(ProductInStore));
            Delete.Table(nameof(AccountsReceivable));
            Delete.Table(nameof(Delivery));
            Delete.Table(nameof(ProductAdjustment));
            Delete.Table(nameof(Purchase));
            Delete.Table(nameof(Invoice));
            Delete.Table(nameof(Client));
            Delete.Table(nameof(ProductLocation));
            Delete.Table(nameof(Category));

            //Inventory
            Delete.Table(nameof(StockDetail));
            Delete.Table(nameof(StockCycleDetail));
            Delete.Table(nameof(ProductMaterials));
            Delete.Table(nameof(Stock));
            Delete.Table(nameof(StockCycle));
            Delete.Table(nameof(StockReason));
            Delete.Table(nameof(Provider));
            Delete.Table(nameof(Product));

            //General
            Delete.Table(nameof(Unit));
            Delete.Table(nameof(Store));
            Delete.Table(nameof(Checkout));

        }
        public override void Up()
        {
            Create.Schema(Schemas.General);
            Create.Schema(Schemas.Inventory);
            Create.Schema(Schemas.Invoicing);

            //General
            Create.Table(nameof(Unit)).InSchema(Schemas.General)
               .WithColumn(nameof(Unit.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(Unit.Name)).AsAnsiString(100).NotNullable()
               .WithColumn(nameof(Unit.Code)).AsAnsiString(50).NotNullable()
               .WithColumn(nameof(Unit.Description)).AsAnsiString(200)
               .WithColumn(nameof(Unit.IsDeleted)).AsBoolean().WithDefaultValue(false)
               .WithColumn(nameof(Unit.CreatedAt)).AsDateTime().Nullable()
               .WithColumn(nameof(Unit.UpdatedAt)).AsDateTime().Nullable()
               .WithColumn(nameof(Unit.CreatedBy)).AsGuid().Nullable()
               .WithColumn(nameof(Unit.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(Store)).InSchema(Schemas.General)
                .WithColumn(nameof(Store.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Store.Code)).AsAnsiString(50).NotNullable()
                .WithColumn(nameof(Store.Name)).AsAnsiString(200).NotNullable()
                .WithColumn(nameof(Store.Photo)).AsAnsiString()
                .WithColumn(nameof(Store.Description)).AsAnsiString(500).Nullable()
                .WithColumn(nameof(Store.Address)).AsAnsiString(500).Nullable()
                .WithColumn(nameof(Store.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(Store.Latitude)).AsDouble().Nullable()
                .WithColumn(nameof(Store.Longitude)).AsDouble().Nullable()
                .WithColumn(nameof(Store.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Store.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Store.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(Store.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(Checkout)).InSchema(Schemas.General)
                .WithColumn(nameof(Checkout.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Checkout.Name)).AsAnsiString(200).NotNullable()
                .WithColumn(nameof(Checkout.Description)).AsAnsiString(500).Nullable()
                .WithColumn(nameof(Checkout.Latitude)).AsDouble().Nullable()
                .WithColumn(nameof(Checkout.Longitude)).AsDouble().Nullable()
                .WithColumn(nameof(Checkout.StoreId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.General, primaryTableName: nameof(Store), primaryColumnName: nameof(Store.Id))
                .WithColumn(nameof(Checkout.AssignedTo)).AsGuid().Nullable()
                .WithColumn(nameof(Checkout.AssignedAt)).AsDateTime().NotNullable()
                .WithColumn(nameof(Checkout.AssignedBy)).AsGuid();

            ////Inventory
            Create.Table(nameof(Category)).InSchema(Schemas.Inventory)
                .WithColumn(nameof(Category.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Category.Name)).AsAnsiString(100).NotNullable()
                .WithColumn(nameof(Category.Description)).AsAnsiString(200)
                .WithColumn(nameof(Category.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(Category.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Category.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Category.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(Category.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(ProductLocation)).InSchema(Schemas.Inventory)
                .WithColumn(nameof(ProductLocation.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(ProductLocation.Name)).AsAnsiString(100).NotNullable()
                .WithColumn(nameof(ProductLocation.Description)).AsAnsiString(200)
                .WithColumn(nameof(ProductLocation.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(ProductLocation.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ProductLocation.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ProductLocation.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(ProductLocation.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(StockReason)).InSchema(Schemas.Inventory)
                .WithColumn(nameof(StockReason.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(StockReason.Name)).AsAnsiString().NotNullable()
                .WithColumn(nameof(StockReason.Description)).AsAnsiString().NotNullable()
                .WithColumn(nameof(StockReason.InputOrOutput)).AsInt16().NotNullable()
                .WithColumn(nameof(StockReason.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(StockReason.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(StockReason.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(StockReason.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(StockReason.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(Product)).InSchema(Schemas.Inventory)
               .WithColumn(nameof(Product.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(Product.Code)).AsAnsiString(100).NotNullable()
               .WithColumn(nameof(Product.Name)).AsAnsiString(200).NotNullable()
               .WithColumn(nameof(Product.Description)).AsAnsiString(500)
               .WithColumn(nameof(Product.Photo)).AsAnsiString()
               .WithColumn(nameof(Product.Price)).AsDecimal(18, 2).NotNullable()
               .WithColumn(nameof(Product.IsDeleted)).AsBoolean().NotNullable().WithDefaultValue(false)
               .WithColumn(nameof(Product.ByUnitOrWeight)).AsInt16().NotNullable()
               .WithColumn(nameof(Product.UnitValue)).AsDouble().NotNullable()
               .WithColumn(nameof(Product.Type)).AsInt16().NotNullable()
               .WithColumn(nameof(Product.UnitId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.General, primaryTableName: nameof(Unit), primaryColumnName: nameof(Unit.Id))
               .WithColumn(nameof(Product.CategoryId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Category), primaryColumnName: nameof(Category.Id))
               .WithColumn(nameof(Product.CreatedAt)).AsDateTime().Nullable()
               .WithColumn(nameof(Product.UpdatedAt)).AsDateTime().Nullable()
               .WithColumn(nameof(Product.CreatedBy)).AsGuid().Nullable()
               .WithColumn(nameof(Product.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(Provider)).InSchema(Schemas.Inventory)
                .WithColumn(nameof(Provider.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Provider.FirstName)).AsAnsiString(200).NotNullable()
                .WithColumn(nameof(Provider.LastName)).AsAnsiString(200).Nullable()
                .WithColumn(nameof(Provider.Identification)).AsAnsiString(30)
                .WithColumn(nameof(Provider.IdentificationType)).AsInt16()
                .WithColumn(nameof(Provider.Phone)).AsAnsiString(30).Nullable()
                .WithColumn(nameof(Provider.Email)).AsAnsiString(254).Nullable()
                .WithColumn(nameof(Provider.Street)).AsAnsiString(300).Nullable()
                .WithColumn(nameof(Provider.BuildingNumber)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Provider.City)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Provider.State)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Provider.Country)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Provider.PostalCode)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Provider.FormattedAddress)).AsAnsiString().Nullable()
                .WithColumn(nameof(Provider.Latitude)).AsDouble().Nullable()
                .WithColumn(nameof(Provider.Longitude)).AsDouble().Nullable()
                .WithColumn(nameof(Provider.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(Provider.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Provider.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Provider.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(Provider.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(ProductInStore)).InSchema(Schemas.Inventory)
                .WithColumn(nameof(ProductInStore.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(ProductInStore.LocationId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(ProductLocation), primaryColumnName: nameof(ProductLocation.Id))
                .WithColumn(nameof(ProductInStore.ProductId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Product), primaryColumnName: nameof(Product.Id))
                .WithColumn(nameof(ProductInStore.StoreId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.General, primaryTableName: nameof(Store), primaryColumnName: nameof(Store.Id));

            Create.Table(nameof(ProductMaterials)).InSchema(Schemas.Inventory)
                .WithColumn(nameof(ProductMaterials.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(ProductMaterials.QuantityNeeded)).AsDouble().NotNullable()
                .WithColumn(nameof(ProductMaterials.ProductId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Product), primaryColumnName: nameof(Product.Id))
                .WithColumn(nameof(ProductMaterials.MaterialId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Product), primaryColumnName: nameof(Product.Id))
                .WithColumn(nameof(ProductMaterials.UnitId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.General, primaryTableName: nameof(Unit), primaryColumnName: nameof(Unit.Id))
                .WithColumn(nameof(ProductMaterials.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ProductMaterials.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ProductMaterials.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(ProductMaterials.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(StockCycle)).InSchema(Schemas.Inventory)
                .WithColumn(nameof(StockCycle.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(StockCycle.Note)).AsAnsiString().Nullable()
                .WithColumn(nameof(StockCycle.StartDate)).AsDateTime().NotNullable()
                .WithColumn(nameof(StockCycle.EndDate)).AsDateTime().NotNullable()
                .WithColumn(nameof(StockCycle.IsClose)).AsBoolean().NotNullable()
                .WithColumn(nameof(StockCycle.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(StockCycle.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(StockCycle.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(StockCycle.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(StockCycle.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(StockCycleDetail)).InSchema(Schemas.Inventory)
               .WithColumn(nameof(StockCycleDetail.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(StockCycleDetail.ProductPrice)).AsDecimal(18, 2).NotNullable()
               .WithColumn(nameof(StockCycleDetail.ProductName)).AsAnsiString().NotNullable()
               .WithColumn(nameof(StockCycleDetail.ProductType)).AsInt16().NotNullable()
               .WithColumn(nameof(StockCycleDetail.Stock)).AsInt32().NotNullable()
               .WithColumn(nameof(StockCycleDetail.Input)).AsInt32().NotNullable()
               .WithColumn(nameof(StockCycleDetail.Output)).AsInt32().NotNullable()
               .WithColumn(nameof(StockCycleDetail.Type)).AsInt16().NotNullable()
               .WithColumn(nameof(StockCycleDetail.ProductId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Product), primaryColumnName: nameof(Product.Id))
               .WithColumn(nameof(StockCycleDetail.StockCycleId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(StockCycle), primaryColumnName: nameof(StockCycle.Id));

            Create.Table(nameof(Stock)).InSchema(Schemas.Inventory)
               .WithColumn(nameof(Stock.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(Stock.Date)).AsDateTime().NotNullable()
               .WithColumn(nameof(Stock.Status)).AsInt16().NotNullable()
               .WithColumn(nameof(Stock.Note)).AsAnsiString().Nullable()
               .WithColumn(nameof(Stock.ProviderId)).AsGuid().Nullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Provider), primaryColumnName: nameof(Provider.Id))
               .WithColumn(nameof(Stock.StoreId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.General, primaryTableName: nameof(Store), primaryColumnName: nameof(Store.Id))
               .WithColumn(nameof(Stock.ReasonId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(StockReason), primaryColumnName: nameof(StockReason.Id))
               .WithColumn(nameof(Stock.IsDeleted)).AsBoolean().WithDefaultValue(false)
               .WithColumn(nameof(Stock.CreatedAt)).AsDateTime().Nullable()
               .WithColumn(nameof(Stock.UpdatedAt)).AsDateTime().Nullable()
               .WithColumn(nameof(Stock.CreatedBy)).AsGuid().Nullable()
               .WithColumn(nameof(Stock.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(StockDetail)).InSchema(Schemas.Inventory)
               .WithColumn(nameof(StockDetail.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(StockDetail.Quantity)).AsDouble().NotNullable()
               .WithColumn(nameof(StockDetail.PurchasePrice)).AsDecimal(18, 2).Nullable()
               .WithColumn(nameof(StockDetail.ProductId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Product), primaryColumnName: nameof(Product.Id))
               .WithColumn(nameof(StockDetail.StockId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Stock), primaryColumnName: nameof(Stock.Id));

            //Invoicing
            Create.Table(nameof(Client)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(Client.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Client.FirstName)).AsAnsiString(200).NotNullable()
                .WithColumn(nameof(Client.LastName)).AsAnsiString(200).Nullable()
                .WithColumn(nameof(Client.Identification)).AsAnsiString(30)
                .WithColumn(nameof(Client.IdentificationType)).AsInt16()
                .WithColumn(nameof(Client.Phone)).AsAnsiString(30).Nullable()
                .WithColumn(nameof(Client.Email)).AsAnsiString(254).Nullable()
                .WithColumn(nameof(Client.Street)).AsAnsiString(300).Nullable()
                .WithColumn(nameof(Client.BuildingNumber)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Client.City)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Client.State)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Client.Country)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Client.PostalCode)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(Client.FormattedAddress)).AsAnsiString().Nullable()
                .WithColumn(nameof(Client.Latitude)).AsDouble().Nullable()
                .WithColumn(nameof(Client.Longitude)).AsDouble().Nullable()
                .WithColumn(nameof(Client.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(Client.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Client.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(Client.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(Client.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(ClientCredit)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(ClientCredit.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(ClientCredit.Credit)).AsDecimal(18, 2).NotNullable()
                .WithColumn(nameof(ClientCredit.Concept)).AsAnsiString(200).NotNullable()
                .WithColumn(nameof(ClientCredit.ClientId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Client), primaryColumnName: nameof(Client.Id))
                .WithColumn(nameof(ClientCredit.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ClientCredit.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ClientCredit.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(ClientCredit.UpdatedBy)).AsGuid().Nullable();

            Create.Table(nameof(Invoice)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(Invoice.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Invoice.Code)).AsAnsiString(50).NotNullable()
                .WithColumn(nameof(Invoice.Type)).AsInt16().NotNullable()
                .WithColumn(nameof(Invoice.Status)).AsInt16().NotNullable()
                .WithColumn(nameof(Invoice.Payment)).AsDecimal(18, 2).NotNullable()
                .WithColumn(nameof(Invoice.ToPay)).AsDecimal(18, 2).NotNullable()
                .WithColumn(nameof(Invoice.PaymentMethod)).AsInt16().NotNullable()
                .WithColumn(nameof(Invoice.Paid)).AsBoolean().NotNullable()
                .WithColumn(nameof(Invoice.Date)).AsDateTime().NotNullable()
                .WithColumn(nameof(Invoice.Note)).AsAnsiString(200).Nullable()
                .WithColumn(nameof(Invoice.ClientId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Client), primaryColumnName: nameof(Client.Id))
                .WithColumn(nameof(Invoice.CreatedAt)).AsDateTime().Nullable().Nullable()
                .WithColumn(nameof(Invoice.UpdatedAt)).AsDateTime().Nullable().Nullable()
                .WithColumn(nameof(Invoice.CreatedBy)).AsGuid().Nullable().Nullable()
                .WithColumn(nameof(Invoice.UpdatedBy)).AsGuid().Nullable().Nullable();

            Create.Table(nameof(Adjustment)).InSchema(Schemas.Invoicing)
               .WithColumn(nameof(Adjustment.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(Adjustment.Concept)).AsAnsiString(100).NotNullable()
               .WithColumn(nameof(Adjustment.Value)).AsDecimal(18, 2).NotNullable()
               .WithColumn(nameof(Adjustment.IsDiscount)).AsBoolean().NotNullable()
               .WithColumn(nameof(Adjustment.Type)).AsAnsiString(50).NotNullable()
               .WithColumn(nameof(Adjustment.StartDate)).AsDateTime().Nullable()
               .WithColumn(nameof(Adjustment.EndDate)).AsDateTime().Nullable()
               .WithColumn(nameof(Adjustment.IsDeleted)).AsBoolean().WithDefaultValue(false);

            Create.Table(nameof(AccountsReceivable)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(AccountsReceivable.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(AccountsReceivable.Payment)).AsDecimal(18, 2).NotNullable()
                .WithColumn(nameof(AccountsReceivable.Paid)).AsBoolean().NotNullable()
                .WithColumn(nameof(AccountsReceivable.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(AccountsReceivable.InvoiceId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Invoice), primaryColumnName: nameof(Invoice.Id))
                .WithColumn(nameof(AccountsReceivable.ClientId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Client), primaryColumnName: nameof(Client.Id));

            Create.Table(nameof(AccountsReceivableDetail)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(AccountsReceivableDetail.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(AccountsReceivableDetail.PendingPayment)).AsDecimal(18, 2).NotNullable()
                .WithColumn(nameof(AccountsReceivableDetail.Payment)).AsDecimal(18, 2).NotNullable()
                .WithColumn(nameof(AccountsReceivableDetail.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(AccountsReceivableDetail.AccountsReceivableId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(AccountsReceivable), primaryColumnName: nameof(AccountsReceivable.Id));

            Create.Table(nameof(InvoiceDetail)).InSchema(Schemas.Invoicing)
               .WithColumn(nameof(InvoiceDetail.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(InvoiceDetail.Price)).AsDecimal(18, 2).NotNullable()
               .WithColumn(nameof(InvoiceDetail.Quantity)).AsDouble().NotNullable()
               .WithColumn(nameof(InvoiceDetail.ProductId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Product), primaryColumnName: nameof(Product.Id))
               .WithColumn(nameof(InvoiceDetail.InvoiceId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Invoice), primaryColumnName: nameof(Invoice.Id));

            Create.Table(nameof(InvoiceDetailProductAdjustment)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(InvoiceDetailProductAdjustment.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(InvoiceDetailProductAdjustment.Concept)).AsAnsiString(100).NotNullable()
                .WithColumn(nameof(InvoiceDetailProductAdjustment.IsDiscount)).AsBoolean().NotNullable()
                .WithColumn(nameof(InvoiceDetailProductAdjustment.Type)).AsAnsiString(50).NotNullable()
                .WithColumn(nameof(InvoiceDetailProductAdjustment.Value)).AsDecimal(18, 2).NotNullable()
                .WithColumn(nameof(InvoiceDetailProductAdjustment.InvoiceDetailId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(InvoiceDetail), primaryColumnName: nameof(InvoiceDetail.Id));

            Create.Table(nameof(Delivery)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(Delivery.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Delivery.VehicleDescription)).AsAnsiString(300).NotNullable()
                .WithColumn(nameof(Delivery.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(Delivery.UserId)).AsGuid().NotNullable();

            Create.Table(nameof(InvoiceDelivery)).InSchema(Schemas.Invoicing)
               .WithColumn(nameof(InvoiceDelivery.Id)).AsGuid().PrimaryKey().NotNullable()
               .WithColumn(nameof(InvoiceDelivery.IsDeleted)).AsBoolean().WithDefaultValue(false)
               .WithColumn(nameof(InvoiceDelivery.InvoiceId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Invoice), primaryColumnName: nameof(Invoice.Id))
               .WithColumn(nameof(InvoiceDelivery.DeliveryId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Delivery), primaryColumnName: nameof(Delivery.Id));

            Create.Table(nameof(Purchase)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(Purchase.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(Purchase.IsDeleted)).AsBoolean().WithDefaultValue(false);

            Create.Table(nameof(PurchaseDetail)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(PurchaseDetail.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(PurchaseDetail.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(PurchaseDetail.PurchaseId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Purchase), primaryColumnName: nameof(Purchase.Id));

            Create.Table(nameof(ProductAdjustment)).InSchema(Schemas.Invoicing)
                .WithColumn(nameof(ProductAdjustment.Id)).AsGuid().PrimaryKey().NotNullable()
                .WithColumn(nameof(ProductAdjustment.ProductId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Inventory, primaryTableName: nameof(Product), primaryColumnName: nameof(Product.Id))
                .WithColumn(nameof(ProductAdjustment.AdjustmentId)).AsGuid().NotNullable().ForeignKey(null, primaryTableSchema: Schemas.Invoicing, primaryTableName: nameof(Adjustment), primaryColumnName: nameof(Adjustment.Id))
                .WithColumn(nameof(ProductAdjustment.IsDeleted)).AsBoolean().WithDefaultValue(false)
                .WithColumn(nameof(ProductAdjustment.CreatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ProductAdjustment.UpdatedAt)).AsDateTime().Nullable()
                .WithColumn(nameof(ProductAdjustment.CreatedBy)).AsGuid().Nullable()
                .WithColumn(nameof(ProductAdjustment.UpdatedBy)).AsGuid().Nullable();
        }
    }
}
