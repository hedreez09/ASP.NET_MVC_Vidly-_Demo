namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO MembershipTypes (Id, Name,SigUpFee, DurationInMonth, DiscountRate) VALUES(1,'Pay As you Go', 0, 0, 0)");
			Sql("INSERT INTO MembershipTypes (Id,Name, SigUpFee, DurationInMonth, DiscountRate) VALUES(2, 'Monthly', 30, 1, 10)");
			Sql("INSERT INTO MembershipTypes (Id, Name, SigUpFee, DurationInMonth, DiscountRate) VALUES(3, 'Quarterly',  90, 3, 15)");
			Sql("INSERT INTO MembershipTypes (Id, Name, SigUpFee, DurationInMonth, DiscountRate) VALUES(4, 'Annually', 300, 12, 20)");
		}
        
        public override void Down()
        {
        }
    }
}
