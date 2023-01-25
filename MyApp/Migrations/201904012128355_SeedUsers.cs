namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1fe20d8b-c360-497b-874f-70f1331af9d1', N'cserajueng@gmail.com', 0, N'AAavjlQT9tv5O28aiysivFZi1RQR0ZLtxKGnKyLH/AM3LIuMuNa2nrieECw2zUCFag==', N'bf40a412-6803-4f6e-89c4-65d0e9a43b16', NULL, 0, 0, NULL, 1, 0, N'cserajueng@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd95179eb-e17a-41a5-992c-095f9b794153', N'Admin@MyApp.com', 0, N'AGak5BkV87IFTFTvXja/WzabHKNV+qFEw206J9PRUhEMqcH2+AEDe+IoGzBCK/YmXg==', N'0af107ca-c511-4f5e-88bc-1bff0a21b00a', NULL, 0, 0, NULL, 1, 0, N'Admin@MyApp.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ed8086a4-2219-4fae-b256-8c683387f7b5', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd95179eb-e17a-41a5-992c-095f9b794153', N'ed8086a4-2219-4fae-b256-8c683387f7b5')

");
        }
        
        public override void Down()
        {
        }
    }
}
