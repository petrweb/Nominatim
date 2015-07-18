namespace OpenStreetMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStreetNumberType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "StreetNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "StreetNumber", c => c.Int(nullable: false));
        }
    }
}
