/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\DefaultData\Users.sql
:r .\DefaultData\Posts.sql
:r .\DefaultData\Comments.sql
:r .\DefaultData\Conditions.sql
:r .\DefaultData\Orders.sql
:r .\DefaultData\OrderItems.sql
:r .\DefaultData\Books.sql
:r .\DefaultData\Authors.sql
:r .\DefaultData\Publishers.sql
:r .\DefaultData\Subjects.sql
:r .\DefaultData\Customers.sql