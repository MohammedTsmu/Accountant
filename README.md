# Accountant Purchases AP

**Database name:** AccPurchasesDB
----------------------------------------------------------------------------------------------------------------------

**Server Name:** .\SQLEXPRESS
----------------------------------------------------------------------------------------------------------------------
**SQL FOR ADVANCED INSTALLER:**

USE [AccPurchasesDB]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 3/24/2025 5:31:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[DateAndTime] [datetime] NOT NULL,
	[Purchases] [nvarchar](100) NOT NULL,
	[AmountReceived] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
