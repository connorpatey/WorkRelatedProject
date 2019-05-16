namespace WorkRelatedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        House = c.String(nullable: false, maxLength: 30),
                        StreetName = c.String(maxLength: 30),
                        TownName = c.String(nullable: false, maxLength: 30),
                        Postcode = c.String(nullable: false, maxLength: 10),
                        County = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        MaritalStatus = c.Int(nullable: false),
                        ContactNumber = c.String(maxLength: 16),
                        EmailAddress = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 35),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.Int(nullable: false),
                        AvailableDate = c.DateTime(nullable: false),
                        EstateAgent = c.Int(nullable: false),
                        Bedrooms = c.Int(nullable: false),
                        AddressID = c.String(),
                        PetsAllowed = c.Boolean(nullable: false),
                        IsShared = c.Boolean(nullable: false),
                        Address_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.PropertyID)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID)
                .Index(t => t.Address_AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "Address_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Properties", new[] { "Address_AddressID" });
            DropIndex("dbo.Customers", new[] { "AddressID" });
            DropTable("dbo.Properties");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
