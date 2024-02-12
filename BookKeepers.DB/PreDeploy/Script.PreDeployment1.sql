/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS tblUser
DROP TABLE IF EXISTS tblPost
DROP TABLE IF EXISTS tblComment
DROP TABLE IF EXISTS tblCondition
DROP TABLE IF EXISTS tblOrder
DROP TABLE IF EXISTS tblOrderItem
DROP TABLE IF EXISTS tblBook
DROP TABLE IF EXISTS tblAuthor
DROP TABLE IF EXISTS tblPublisher
DROP TABLE IF EXISTS tblShoppingCart
DROP TABLE IF EXISTS tblSubject
DROP TABLE IF EXISTS tblCustomer