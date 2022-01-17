using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstoolTechRestFullAPI
{
    public class info
    {
        /*
        
        ////////////////////////هنا عملية التسجيل
        
        var client = new RestClient("http://localhost:11677/api/test/register");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("usernamee", "moseedv");
request.AddHeader("passwordd", "moseed123v");
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);
ثم يتم إرجاع رمز امان المستخدم
 ثم بعد ذالك يتم اخذ رمز الامان واسم المستخدم وجلب الاكسس توكن ورفرشن توكن للمستخدم

        
        
        ////
        
       
        
        
        /// هنا يتم استلام البيانات من الخطوة الاولى ومن ثم جلب الاكسس توكن////////////////
        
        var client = new RestClient("http://localhost:11677/token");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("Authorization", "Basic bW9zZWVkdjoyMHdUalAvbXlyd0RJTTRKeEoxOXFGVW1KblFJdlpEZUtES015bHVrZHlZPQ==")//هذا الرمز من فوق يتم جلبة;
request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
request.AddParameter("username", "moseedv");
request.AddParameter("password", "moseed123v");
request.AddParameter("grant_type", "password");
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content); 

        ثم يتم إرجاع البيانات علي هذه الشكل

        {
    "access_token": "0CuCXD49Zm6lUAoRyYXL1mrSnNSMWkjDWmRS6Y8ZTzUUvOMHze9rmZJsvyUMNJdOyQV5kXkbejFWL63XRKKw7EGVE5M6U3mi34sG9wc9OS_7HsiohKLw7_56qkjJNAWY8lCfU3ctRJOu6qtBCGCNuQRFBaxBcjk6356LQench9tK3UDAcOyG0PlS67LuG-KaNqGxPfuB2egrhEQzH4nPA6z48cRzHkVq4cpykmihIzAlzdVXSBWEL1CQdaxMJJ7jVtlKFIyklRZTy5bJ_xF5LtVlgPo30NTXIz1My6-NmTQYMEtiwaG6c2vO4OHAwly34VWa9g1YW-BEKPSJ1x_6HA",
    "token_type": "bearer",
    "expires_in": 499,
    "refresh_token": "970e0749434c42b5bc624408ad68ee96",
    "client_id": "moseedv",
    "userName": "moseedv",
    ".issued": "Fri, 14 Jan 2022 19:28:08 GMT",
    ".expires": "Fri, 14 Jan 2022 19:36:28 GMT"
}









        ////////وإذا نريد نحدث الاكسس توكن نستخدم هذه 



        var client = new RestClient("http://localhost:11677/token");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("Authorization", "Basic bW9zZWVkdjoyMHdUalAvbXlyd0RJTTRKeEoxOXFGVW1KblFJdlpEZUtES015bHVrZHlZPQ==");
request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

request.AddParameter("grant_type", "refresh_token");
request.AddParameter("refresh_token", "53ae86947ab14354857ca22f0158ce3c")//رقم الرفرش توكن من فوق نجلبة;
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);







        //وإذا نريد عرض البيات اي بيانات بعد الدخول نستخد هذه



        var client = new RestClient("http://localhost:11677/api/test/resource2");
client.Timeout = -1;
var request = new RestRequest(Method.GET);
request.AddHeader("usernamee", "moseedv");
request.AddHeader("Authorization", "Bearer RiO5hySrVj0VTAHhdBLFbDg1TxK81ddTu_BQzsEiFI7xIOisPaDBUslRzhbaMQtxMyAMlVXgTzbvowG2s6dfmrEYa8LEyNqtvHMoBGJJKCdpC1NLfntPIQ5G7wLMyw8rx6uqVPgMALEQuuZPL2AxjwCaAYUwAZ-1BaxRKKnCUxzD7eJiRJcSO4ByfTpGRtW5Qovq55kyGkRiXnfJFxG9F0-f2P2rFMmnYpOB-7qhQ39z2S1MApenURCOG5SWdld8HtQ1Sg9VXnvIUTUjc8hh7_JUh3SGyIDzkbV4zUVgI6UD1z6gAQmepSyLTFcy0ZRgH0HW0QdQALe2mI8VTEZd8OFr5dUlL4LlN_a7_Z1tSz0");

IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);
        
        















        ////////////هنا عملية الحذف

 bb معرف الصنف
var client = new RestClient("http://localhost:11677/api/test/prodactacouns?bb=4044");
client.Timeout = -1;
var request = new RestRequest(Method.DELETE);
request.AddHeader("Content-Type", "application/json");
request.AddHeader("usernamee", "moseedv");
request.AddHeader("Authorization", "Bearer DUKeqhQxECR1Ou2CsSyiAADkAMBch747gaDJNb7BGyxHSVn_RWKQprbDIbigVJCJJakDg8RhyvUu_CJAoAAXpdzYlkuK7FjsDMpzsVYzzk3Lv9vzumaYy8OqtmKsEkSjiHUhyohYSk6TtOp0xd3Qf576hTdIWx_Ki0YfV0-6Te-XlxRrNMdACPe-NfhUJx59lhnMamJx1gliMFibzl4-XBptOhSjIe1uhsJubQ2iznxePvllaqn6xvA5wOFHk23y6fLQvvJUlSiZO1gguuXqcT9xs85AGRsuqAziZ0JwK-gdxkfWASxrOM8Fo3qfD3Q4npe-Zgc6B9qsWPFWmbFcCg");
var body = @"";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);
        
      
        
        
        
        
        //هنا عملية التعديل 
        var client = new RestClient("http://localhost:11677/api/test/prodactacouns?bb=4043");
client.Timeout = -1;
var request = new RestRequest(Method.PUT);
request.AddHeader("Content-Type", "application/json");
request.AddHeader("usernamee", "moseedv");
request.AddHeader("Authorization", "Bearer IdQyHOaBzw0rGCFTtBrS62xAzyJWiSk8cvOJRfjTaR6PCdsL_3XUj1PbGtEA-mFMLFZLn2JWJRqmIrU68RQOVeUy6F8GbgpARPLezrsDcD3pKUfARKf9onvUUFxqMnfrU485tEdc8UB_FzvIZKBKyfJCbE6MDxMH0ThKRp7IYTfiGm03mCVXaXWNFU4LZugjrgmtSxVQjotVHfTZL8MxYoV_5hrmcwcFyiyZlHHkABA9hjpehD1kbQl6Gmj5MIQQl9Fa-C9e8VKrBC6kmtli9G6HAAloTRkprgLLVr3jeR7xEiFwyuDa0Gk4_E9ZTlXsniBKnGXMUtWjPdCw9rBHLQpElnX3yXFBTB8Wh6wiXK0");
var body = @" {
" + "\n" +
@"        ""ID"": 4043,
" + "\n" +
@"        ""namear"": ""lovelovelove"",
" + "\n" +
@"        ""nameen"": ""إكليزhhgghghghghgh قرطاس"",
" + "\n" +
@"        ""groupID"": 37,
" + "\n" +
@"        ""barcode"": ""6271028080921"",
" + "\n" +
@"        ""rabtwithmored"": false,
" + "\n" +
@"        ""IDformred"": 1,
" + "\n" +
@"        ""enable"": false,
" + "\n" +
@"        ""dateexpire"": true,
" + "\n" +
@"        ""cashonly"": false,
" + "\n" +
@"        ""notback"": false,
" + "\n" +
@"        ""backamount"": false,
" + "\n" +
@"        ""backday"": 1,
" + "\n" +
@"        ""manfacture"": ""manfacture"",
" + "\n" +
@"        ""hightt"": 0.0,
" + "\n" +
@"        ""wedthh"": 0.0,
" + "\n" +
@"        ""ertfah"": 0.0,
" + "\n" +
@"        ""wazen"": 0.0,
" + "\n" +
@"        ""reoreder"": 1,
" + "\n" +
@"        ""detalis"": ""no"",
" + "\n" +
@"        ""multiparcod"": false,
" + "\n" +
@"        ""notifiexpiredateday"": false,
" + "\n" +
@"        ""notifiexpiredate"": false,
" + "\n" +
@"        ""notexitinstock"": false
" + "\n" +
@"    }";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);
        
        
     
        
        
        
        
        
        //هنا عملية جلب صنف معين
        
        
 var client = new RestClient("http://localhost:11677/api/test/prodactacouns?bb=4043");
client.Timeout = -1;
var request = new RestRequest(Method.GET);
request.AddHeader("Content-Type", "application/json");
request.AddHeader("usernamee", "moseedv");
request.AddHeader("Authorization", "Bearer PH01uZ0AvusWNsu6Uxi9My_8lZihGOYluoUrcXnJ7XN23rfHC734fTKT04Ot4grnalWHQIT-agK7jZ-rHYdShmuDsLgBz3uH14xjmMOStgQ9JXK2sgZ-MRuLu67OD199m6DLVZK8zuLjDELL7HGYmV1_R2yV_P2LoCPVBa62Ym8sT8x9StMxVTLTzmVM7kfxYiD-bZS0U4N4E_iS63d3f5-xCTM_HuD1bGapNUfvwcj8a1NytRIjBB9W3I-FhsS6kHRS69VKFKnnCDrUb9BL1GBV4dsRso5Z75_A2-UlCEkGnozOZ8aoyNpYPk_O3fgqb26ZN59SB9zCVtPU5XjA80h50unGUPHmAYbQaC-rzFw");
var body = @" ";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);   
        
        
      
        
        
        
        
        
        
        
        //////////////////////////////////////////////////////////////  قاعدة البيانات

        USE [orderapi]
GO

        ALTER TABLE[dbo].[AspNetUserClaims]
        DROP CONSTRAINT[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetRoles](
	[Id]
        [nvarchar](128) NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
CONSTRAINT[PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE[dbo].[__MigrationHistory](
	[MigrationId]
        [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
CONSTRAINT[PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED
(
[MigrationId] ASC,
[ContextKey] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE[dbo].[UserMaster](
	[UserID]
        [int] NOT NULL,
    [UserName] [varchar](50) NULL,
	[UserPassword]
        [varchar](50) NULL,
	[UserRoles]
        [varchar](500) NULL,
	[UserEmailID]
        [varchar](100) NULL,
PRIMARY KEY CLUSTERED
(
    [UserID] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE[dbo].[RefreshTokenRf](
	[ID]
        [varchar](500) NOT NULL,
    [UserName] [varchar](500) NULL,
	[ClientID]
        [varchar](500) NULL,
	[IssuedTime]
        [datetime]
        NULL,
	[ExpiredTime]
        [datetime]
        NULL,
	[ProtectedTicket]
        [varchar](500) NULL,
PRIMARY KEY CLUSTERED
(
    [ID] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[prodactacoun](
	[ID]
        [int] IDENTITY(1,1) NOT NULL,
    [namear] [nvarchar](50) NULL,
	[nameen]
        [nvarchar](50) NULL,
	[groupID]
        [int] NULL,
	[barcode]
        [nvarchar](50) NULL,
	[rabtwithmored]
        [bit]
        NULL,
	[IDformred]
        [int] NULL,
	[enable]
        [bit]
        NULL,
	[dateexpire]
        [bit]
        NULL,
	[cashonly]
        [bit]
        NULL,
	[notback]
        [bit]
        NULL,
	[backamount]
        [bit]
        NULL,
	[backday]
        [int] NULL,
	[manfacture]
        [nvarchar](50) NULL,
	[hightt]
        [float] NULL,
	[wedthh]
        [float] NULL,
	[ertfah]
        [float] NULL,
	[wazen]
        [float] NULL,
	[reoreder]
        [int] NULL,
	[detalis]
        [nvarchar](50) NULL,
	[multiparcod]
        [bit]
        NULL,
	[notifiexpiredateday]
        [bit]
        NULL,
	[notifiexpiredate]
        [bit]
        NULL,
	[notexitinstock]
        [bit]
        NULL,
 CONSTRAINT[PK_prodactacoun] PRIMARY KEY CLUSTERED
(
   [ID] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE[dbo].[ClientMasterٌٌRf](
	[ClientKeyId]
        [int] IDENTITY(1,1) NOT NULL,
    [ClientID] [varchar](500) NOT NULL,
    [ClientSecret] [varchar](500) NOT NULL,
    [ClientName] [varchar](100) NOT NULL,
    [Active] [bit]
        NOT NULL,
    [RefreshTokenLifeTime] [int] NOT NULL,
    [AllowedOrigin] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED
(
[ClientKeyId] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUsers](
	[Id]
        [nvarchar](128) NOT NULL,
    [Email] [nvarchar](256) NULL,
	[EmailConfirmed]
        [bit]
        NOT NULL,
    [PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp]
        [nvarchar](max) NULL,
	[PhoneNumber]
        [nvarchar](max) NULL,
	[PhoneNumberConfirmed]
        [bit]
        NOT NULL,
    [TwoFactorEnabled] [bit]
        NOT NULL,
    [LockoutEndDateUtc] [datetime]
        NULL,
	[LockoutEnabled]
        [bit]
        NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    [FirstName] [nvarchar](max) NULL,
	[LastName]
        [nvarchar](max) NULL,
	[Address]
        [nvarchar](max) NULL,
	[City]
        [nvarchar](max) NULL,
	[State]
        [nvarchar](max) NULL,
	[PostalCode]
        [nvarchar](max) NULL,
	[Country]
        [nvarchar](max) NULL,
	[Phone]
        [nvarchar](max) NULL,
 CONSTRAINT[PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED
(
   [Id] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUserRoles](
	[UserId]
        [nvarchar](128) NOT NULL,
    [RoleId] [nvarchar](128) NOT NULL,
CONSTRAINT[PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED
(
[UserId] ASC,
[RoleId] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUserLogins](
	[LoginProvider]
        [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
CONSTRAINT[PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED
(
[LoginProvider] ASC,
[ProviderKey] ASC,
[UserId] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUserClaims](
	[Id]
        [int] IDENTITY(1,1) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    [ClaimType] [nvarchar](max) NULL,
	[ClaimValue]
        [nvarchar](max) NULL,
 CONSTRAINT[PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED
(
   [Id] ASC
)WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO

ALTER TABLE[dbo].[AspNetUserClaims]
        WITH CHECK ADD CONSTRAINT[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES[dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserClaims]
        CHECK CONSTRAINT[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO

ALTER TABLE[dbo].[AspNetUserLogins]
        WITH CHECK ADD CONSTRAINT[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES[dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserLogins]
        CHECK CONSTRAINT[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO

ALTER TABLE[dbo].[AspNetUserRoles]
        WITH CHECK ADD CONSTRAINT[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES[dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserRoles]
        CHECK CONSTRAINT[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]    Script Date: 01/17/2022 05:31:09 ******
ALTER TABLE[dbo].[AspNetUserRoles]
        WITH CHECK ADD CONSTRAINT[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES[dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserRoles]
        CHECK CONSTRAINT[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO






        //////////////////////////////////////////////


        */


    }
}