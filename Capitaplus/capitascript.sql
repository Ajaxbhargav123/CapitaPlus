USE [Capitaplus]
GO
/****** Object:  Table [dbo].[BillOfMats]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillOfMats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RmCode] [nvarchar](50) NOT NULL,
	[MatName] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Capacity] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[MasterProCode] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_BillOfMats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrandMaster]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](25) NOT NULL,
	[ShortBrandName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_BrandMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellTypeMaster]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellTypeMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CellType] [nchar](10) NOT NULL,
 CONSTRAINT [PK_CellTypeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckMatToDisplay]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckMatToDisplay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobNo] [nvarchar](50) NOT NULL,
	[BomNo] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[MatName] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Capacity] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CheckMatToDisplay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorMaster]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nchar](10) NULL,
	[code] [nchar](10) NULL,
 CONSTRAINT [PK_ColorMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMasters]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMasters](
	[S.No] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nvarchar](50) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](50) NOT NULL,
	[CustomerAddress] [nvarchar](200) NOT NULL,
	[DeliveryFrom] [nvarchar](50) NOT NULL,
	[SuplierTypeId] [int] NOT NULL,
	[SuplierGstNo] [nvarchar](20) NOT NULL,
	[ContactNo] [nvarchar](12) NULL,
	[CustTypeId] [int] NULL,
 CONSTRAINT [PK_CustomerMasters] PRIMARY KEY CLUSTERED 
(
	[S.No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerTypes]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Types] [nchar](10) NOT NULL,
 CONSTRAINT [PK_CustomerTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliverySchedule]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliverySchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[CellType] [nvarchar](50) NOT NULL,
	[Capacity] [nvarchar](50) NOT NULL,
	[Color] [nchar](10) NOT NULL,
	[Model] [nchar](10) NOT NULL,
	[DeliveryDate] [nvarchar](50) NOT NULL,
	[AddressDelivery] [nvarchar](50) NOT NULL,
	[DeliveryQty] [int] NOT NULL,
	[Cid] [int] NULL,
	[SalesOrderNo] [nvarchar](50) NULL,
	[JobNo] [nvarchar](15) NULL,
 CONSTRAINT [PK_DeliverySchedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FGstocks]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FGstocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [nvarchar](50) NOT NULL,
	[PaymentTerm] [nvarchar](50) NOT NULL,
	[CreditPeriod] [nvarchar](50) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ContactNo] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](500) NOT NULL,
	[ProductName] [nvarchar](500) NOT NULL,
	[Celltype] [nvarchar](500) NOT NULL,
	[Capacity] [nvarchar](500) NOT NULL,
	[Color] [nvarchar](500) NOT NULL,
	[Model] [nvarchar](500) NOT NULL,
	[Brand] [nvarchar](500) NOT NULL,
	[Quantity] [int] NOT NULL,
	[FgInStock] [int] NOT NULL,
	[isFreez] [bit] NOT NULL,
	[QtyToFreez] [int] NOT NULL,
	[QtyToProduce] [int] NOT NULL,
	[Cid] [int] NOT NULL,
	[Rate] [nvarchar](50) NULL,
	[TQtyProduce] [int] NULL,
 CONSTRAINT [PK_FGstocks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinishedGood]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinishedGood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nchar](50) NOT NULL,
	[ProductName] [nchar](50) NOT NULL,
	[ShortProductName] [nchar](10) NOT NULL,
	[ModelNo] [nchar](20) NOT NULL,
	[CellType] [nchar](30) NOT NULL,
	[Capacity] [nchar](20) NOT NULL,
	[Color] [nchar](20) NOT NULL,
	[ShortColorCode] [nchar](10) NOT NULL,
	[Brand] [nchar](30) NOT NULL,
	[ShortBrandCode] [nchar](10) NOT NULL,
	[SAC] [nchar](20) NOT NULL,
	[GST] [int] NOT NULL,
	[UOM] [nchar](10) NULL,
	[MIN] [int] NULL,
	[Max] [int] NULL,
	[Stock] [int] NULL,
	[StockFreez] [int] NULL,
	[SelfStock] [int] NULL,
	[TRfSelf] [nvarchar](50) NULL,
	[Rate] [int] NULL,
	[StockType] [nchar](10) NULL,
	[CustomerName] [nvarchar](40) NULL,
	[IsMinMax] [nchar](10) NULL,
	[Cid] [int] NULL,
 CONSTRAINT [PK_FinishedGood] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grn]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](40) NULL,
	[MaterialName] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Capacity] [nvarchar](30) NULL,
	[Color] [nvarchar](20) NULL,
	[Model] [nvarchar](20) NULL,
	[Qty] [int] NULL,
	[Uom] [nvarchar](50) NULL,
	[Receive] [int] NULL,
	[Amount] [int] NULL,
	[VendorName] [nvarchar](50) NULL,
	[VendorId] [int] NULL,
	[GrnId] [nvarchar](20) NULL,
	[PurId] [nchar](10) NULL,
	[EntryDate] [datetime] NULL,
	[RecieveDate] [datetime] NULL,
	[EntryGateNo] [nvarchar](15) NULL,
 CONSTRAINT [PK_Grn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobSheets]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSheets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobNo] [nvarchar](50) NOT NULL,
	[SalesOrderNo] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[CellType] [nvarchar](50) NOT NULL,
	[Capacity] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[QtyToPro] [int] NOT NULL,
	[BomNo] [nvarchar](50) NOT NULL,
	[QtyInPieace] [int] NOT NULL,
	[TotalQty] [int] NULL,
 CONSTRAINT [PK_JobSheets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterPackingType]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterPackingType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackingType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MasterPackingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialRequsitionSlip]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialRequsitionSlip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobNo] [nvarchar](50) NOT NULL,
	[BomNo] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[MatName] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Capacity] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[ActualQty] [int] NOT NULL,
	[mrsNo] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[wastage] [int] NULL,
	[ReqWasteqty] [int] NULL,
	[SalesNo] [nvarchar](50) NULL,
	[ReqQty] [int] NULL,
	[BalQtyReq] [int] NULL,
	[Misytd] [int] NULL,
	[MisQtyIssued] [int] NULL,
	[MisBalQty] [int] NULL,
 CONSTRAINT [PK_MaterialRequsitionSlip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatIssueSlip]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatIssueSlip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MrsNo] [nvarchar](10) NULL,
	[Job] [nvarchar](10) NULL,
	[Code] [nvarchar](40) NULL,
	[ProductName] [nvarchar](40) NULL,
	[Type] [nvarchar](20) NULL,
	[Capacity] [nchar](10) NULL,
	[Color] [nchar](10) NULL,
	[Model] [nvarchar](30) NULL,
	[QtyInPiece] [int] NULL,
	[BalanceQty] [int] NULL,
	[DateCreated] [nvarchar](50) NULL,
	[BomNo] [nvarchar](30) NULL,
	[IssueQty] [int] NULL,
	[ytd] [int] NULL,
 CONSTRAINT [PK_MatIssueSlip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatPlanning]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatPlanning](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobNo] [nvarchar](50) NOT NULL,
	[BomNo] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[MatName] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Capacity] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[QtyReq] [int] NOT NULL,
	[QtyInStock] [int] NULL,
	[MrsNo] [nvarchar](20) NULL,
	[MrsWastQty] [int] NULL,
	[MrsReqWastQty] [int] NULL,
	[MrsReqQty] [int] NULL,
	[MrsBalanceQtyRequired] [int] NULL,
	[SalesNo] [nvarchar](50) NULL,
	[QtyToPurchase] [int] NULL,
	[IsPoCreated] [int] NULL,
	[WasteQty] [int] NULL,
	[QtyAfterWast] [int] NULL,
 CONSTRAINT [PK_MatPlanning] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModelMaster]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model] [nchar](20) NULL,
 CONSTRAINT [PK_ModelMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POTypes]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_POTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMaster]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ShortCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProductColorMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrderSummary]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderSummary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](30) NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
	[MaterialGroup] [nvarchar](50) NOT NULL,
	[UOM-1] [nvarchar](10) NOT NULL,
	[Type] [nchar](10) NOT NULL,
	[Capacity_AMH] [nchar](10) NOT NULL,
	[Color] [nchar](10) NOT NULL,
	[Model] [nchar](10) NOT NULL,
	[QtyStock] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[GrossAmount] [nvarchar](50) NOT NULL,
	[GrossTotal] [nvarchar](50) NOT NULL,
	[Fright] [nvarchar](50) NULL,
	[NetAmount] [nvarchar](50) NULL,
	[PurchaseId] [nchar](10) NULL,
	[VendorName] [nchar](30) NULL,
	[VendorId] [int] NULL,
	[Sac] [nchar](20) NULL,
	[Rate] [int] NULL,
	[GstAmount] [nchar](20) NULL,
	[GstTotal] [nvarchar](50) NULL,
	[QuantityPurchase] [int] NULL,
	[EntryDate] [datetime] NULL,
	[PoType] [int] NULL,
	[RequiredQty] [int] NULL,
 CONSTRAINT [PK_PurchaseOrderSummary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QualityChecks]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityChecks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BomNo] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[Mat1] [int] NULL,
	[Mat2] [int] NULL,
	[Mat3] [int] NULL,
	[Mat4] [int] NULL,
	[Mat5] [int] NULL,
	[Mat6] [int] NULL,
	[Mat7] [int] NULL,
	[Mat8] [int] NULL,
	[Mat9] [int] NULL,
	[Mat10] [int] NULL,
	[ReworkPass] [nchar](10) NULL,
	[QcPass] [nvarchar](50) NULL,
	[QcNo] [nvarchar](50) NULL,
	[WipNo] [nvarchar](20) NULL,
 CONSTRAINT [PK_QualityChecks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMaterialCreation]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMaterialCreation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](30) NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
	[MaterialGroup] [nvarchar](50) NOT NULL,
	[UOM-1] [nvarchar](10) NOT NULL,
	[QUOM] [nchar](10) NOT NULL,
	[UOM-2] [nchar](10) NOT NULL,
	[Type] [nchar](10) NOT NULL,
	[Capacity_AMH] [nchar](10) NOT NULL,
	[Color] [nchar](10) NOT NULL,
	[Model] [nchar](10) NOT NULL,
	[SAC CODE] [nvarchar](50) NULL,
	[Rate] [int] NULL,
	[Stock] [int] NULL,
	[UpdatedStock] [int] NULL,
	[IsMinMax] [nchar](10) NULL,
	[Max] [int] NULL,
	[Min] [int] NULL,
 CONSTRAINT [PK_RoleMaterialCreation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [nvarchar](50) NULL,
	[PaymentTerm] [nvarchar](50) NULL,
	[CreditP] [int] NULL,
	[CustomerName] [nvarchar](50) NULL,
	[Address] [nvarchar](300) NULL,
	[CPerson] [nvarchar](50) NULL,
	[CNumber] [nchar](10) NULL,
	[ProductCode] [nvarchar](50) NULL,
	[ProductName] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Capacity] [nvarchar](50) NULL,
	[Color] [nchar](10) NULL,
	[Model] [nvarchar](20) NULL,
	[Brand] [nvarchar](50) NULL,
	[Rate] [int] NULL,
	[Stock] [int] NULL,
	[SoQty] [int] NULL,
	[Amount] [int] NULL,
	[GrossAmt] [int] NULL,
	[TotalAmt] [int] NULL,
	[TotalGrossAmt] [int] NULL,
	[Cid] [int] NULL,
	[SalesOrderNo] [nvarchar](50) NULL,
	[QtyToFreez] [int] NULL,
	[QtyTopProduce] [int] NULL,
	[IsCreated] [bit] NULL,
	[BomNo] [nvarchar](50) NULL,
	[JobNo] [nvarchar](50) NULL,
	[IsPlanned] [bit] NULL,
	[IsMatIssue] [bit] NULL,
	[IsMatRequsite] [bit] NULL,
	[UpdatedQtyToProduce] [int] NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrdersPacking]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrdersPacking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[ProductName] [nvarchar](50) NULL,
	[CellType] [nchar](10) NULL,
	[Model] [nchar](10) NULL,
	[Color] [nchar](10) NULL,
	[Capacity] [nvarchar](10) NULL,
	[IndivisualPacking] [nvarchar](50) NULL,
	[QtyIndivisual] [int] NULL,
	[BoxPacking] [nvarchar](10) NULL,
	[QtyBox] [int] NULL,
	[ReqBox] [int] NULL,
	[QtyToProduce] [int] NULL,
	[Remark] [nvarchar](50) NULL,
	[SalesOrderNo] [nvarchar](50) NULL,
	[JobNo] [nchar](10) NULL,
	[PackingTypeId] [int] NULL,
	[PackingTypeQty] [int] NULL,
 CONSTRAINT [PK_SalesOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusYesNo]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusYesNo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nchar](10) NOT NULL,
 CONSTRAINT [PK_StatusYesNo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockTable]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [int] NOT NULL,
	[WipNo] [nvarchar](50) NOT NULL,
	[JobNo] [nvarchar](50) NOT NULL,
	[BomNo] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[Mat1] [int] NOT NULL,
	[Mat2] [int] NOT NULL,
	[Mat3] [int] NOT NULL,
	[Mat4] [int] NOT NULL,
	[Mat5] [int] NOT NULL,
	[Mat6] [int] NOT NULL,
	[Mat7] [int] NOT NULL,
	[Mat8] [int] NOT NULL,
	[Mat9] [int] NOT NULL,
	[Mat10] [int] NOT NULL,
	[QcNo] [nvarchar](50) NOT NULL,
	[QcPass] [nvarchar](50) NOT NULL,
	[Rework] [nvarchar](50) NOT NULL,
	[QcRework] [nchar](10) NOT NULL,
	[IndivisualPacking] [nchar](10) NULL,
	[BoxPacking] [nchar](10) NULL,
	[PGI] [nvarchar](50) NULL,
	[ChallanNo] [nvarchar](50) NULL,
	[challanDate] [nvarchar](50) NULL,
	[CustomerCode] [nvarchar](50) NULL,
	[SalesOrderId] [nchar](10) NULL,
	[ProdSerialNo] [nvarchar](200) NULL,
 CONSTRAINT [PK_StockTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuplierTypes]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuplierTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SuplierType] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_SuplierTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorMaster]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorMaster](
	[S.No] [int] IDENTITY(1,1) NOT NULL,
	[VendorCode] [nchar](30) NOT NULL,
	[VendorName] [nchar](30) NOT NULL,
	[ContactPerson] [nchar](30) NOT NULL,
	[VendorAddress] [nchar](100) NOT NULL,
	[SuplierTypeId] [int] NOT NULL,
	[SuplierGstNo] [nchar](20) NOT NULL,
	[ContactNo] [nvarchar](12) NULL,
 CONSTRAINT [PK_VendorMaster] PRIMARY KEY CLUSTERED 
(
	[S.No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WIP]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WIP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[MatName] [nchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Capacity] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[StanderdConsuption] [int] NOT NULL,
	[ActualConsuption] [int] NOT NULL,
	[WastQty] [int] NOT NULL,
	[WipNo] [nvarchar](50) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[BomNo] [nvarchar](50) NULL,
	[jobNo] [nvarchar](50) NULL,
	[QtyAtLocation] [int] NULL,
 CONSTRAINT [PK_WIP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BrandMaster] ON 

INSERT [dbo].[BrandMaster] ([Id], [BrandName], [ShortBrandName]) VALUES (1, N'ROCK_SPACE', N'RS        ')
INSERT [dbo].[BrandMaster] ([Id], [BrandName], [ShortBrandName]) VALUES (2, N'ROCK', N'RO        ')
INSERT [dbo].[BrandMaster] ([Id], [BrandName], [ShortBrandName]) VALUES (1001, N'-', N'-         ')
SET IDENTITY_INSERT [dbo].[BrandMaster] OFF
SET IDENTITY_INSERT [dbo].[CellTypeMaster] ON 

INSERT [dbo].[CellTypeMaster] ([Id], [CellType]) VALUES (1, N'POLY      ')
INSERT [dbo].[CellTypeMaster] ([Id], [CellType]) VALUES (2, N'ION       ')
INSERT [dbo].[CellTypeMaster] ([Id], [CellType]) VALUES (1001, N'-         ')
SET IDENTITY_INSERT [dbo].[CellTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[CheckMatToDisplay] ON 

INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (1, N'SO0002', N'CHRBLROCK_SPACE4000IONROUND000', N'CHRBLROCK_SPACE4000IONROUND', N'CHARGERS', N'ION-POLY', N'4000-3000', N'BLUE--', N'ROUND--', 480, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (2, N'SO0003', N'CHRBLROCK_SPACE4000IONROUND000', N'CHRBLROCK_SPACE4000IONROUND', N'CHARGERS', N'ION-POLY', N'4000-3000', N'BLUE--', N'ROUND--', 790, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (3, N'SO0003', N'CHRBLROCK_SPACE4000IONROUND000', N'CHRBLROCK_SPACE4000IONROUND', N'CHARGERS', N'IONPOLY-', N'40003000-', N'BLUE--', N'ROUND--', 790, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (4, N'SO0003', N'CHRBLROCK_SPACE4000IONROUND000', N'CHRBLROCK_SPACE4000IONROUND', N'CHARGERS', N'IONPOLY-', N'40003000-', N'BLUE--', N'ROUND--', 790, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (5, N'SO0003', N'CHRBLROCK_SPACE4000IONROUND000', N'CHRBLROCK_SPACE4000IONROUND', N'CHARGERS', N'ION-POLY', N'4000-3000', N'BLUE--', N'ROUND--', 790, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (6, N'SO0003', N'CHRBLROCK_SPACE4000IONROUND000', N'CHRBLROCK_SPACE4000IONROUND', N'CHARGERS', N'ION-POLY', N'4000-3000', N'BLUE--', N'ROUND--', 800, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (7, N'SO0001', N'CHRBKROCK_SPACE5000-ROUND0001C', N'CHRBKROCK_SPACE5000-ROUND', N'CHARGERS', N'-POLY', N'50002000', N'BLACK-', N'ROUND-', 300, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (8, N'SO0002', N'PBREDROCK_SPACE6000IONY5V0001P', N'PBREDROCK_SPACE6000IONY5V', N'POWER BANK', N'IONPOLY', N'60002000', N'RED-', N'Y5V-', 750, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (9, N'SO0003', N'CHRBKROCK_SPACE5000-ROUND0001C', N'CHRBKROCK_SPACE5000-ROUND', N'CHARGERS', N'-POLY', N'50002000', N'BLACK-', N'ROUND-', 900, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (10, N'SO0001', N'PBREDROCK_SPACE5000IONY5V0001P', N'PBREDROCK_SPACE5000IONY5V', N'POWER BANK', N'ION-ION', N'5000-1500', N'RED--', N'Y5V--', 800, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (11, N'SO0001', N'PBBKROCK_SPACE2000IONY5V0001PB', N'PBBKROCK_SPACE2000IONY5V', N'POWER BANK', N'IONION', N'20001500', N'BLACK-', N'Y5V-', 480, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (12, N'SO0002', N'PBBKROCK_SPACE2000IONY5V0001PB', N'PBBKROCK_SPACE2000IONY5V', N'POWER BANK', N'IONION', N'20001500', N'BLACK-', N'Y5V-', 800, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (13, N'SO0001', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 700, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (14, N'SO0002', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 800, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (15, N'SO0004', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 600, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (16, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (17, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (18, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (19, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (20, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (21, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (22, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (23, N'SO0005', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
INSERT [dbo].[CheckMatToDisplay] ([Id], [JobNo], [BomNo], [Code], [MatName], [Type], [Capacity], [Color], [Model], [Qty], [Brand]) VALUES (24, N'SO0009', N'PBREDROCK_SPACE8000IONITCJ2403', N'PBREDROCK_SPACE8000IONITCJ2403', N'POWER BANK', N'ION-', N'8000-', N'REDWHITE', N'ITCJ2403N-', 200, N'ROCK_SPACE')
SET IDENTITY_INSERT [dbo].[CheckMatToDisplay] OFF
SET IDENTITY_INSERT [dbo].[ColorMaster] ON 

INSERT [dbo].[ColorMaster] ([Id], [Color], [code]) VALUES (1, N'BLACK     ', N'BK        ')
INSERT [dbo].[ColorMaster] ([Id], [Color], [code]) VALUES (2, N'BLUE      ', N'BL        ')
INSERT [dbo].[ColorMaster] ([Id], [Color], [code]) VALUES (3, N'YELLOW    ', N' YELL     ')
INSERT [dbo].[ColorMaster] ([Id], [Color], [code]) VALUES (4, N'RED       ', N'RED       ')
INSERT [dbo].[ColorMaster] ([Id], [Color], [code]) VALUES (5, N'WHITE     ', N'WH        ')
INSERT [dbo].[ColorMaster] ([Id], [Color], [code]) VALUES (1001, N'-         ', N'-         ')
SET IDENTITY_INSERT [dbo].[ColorMaster] OFF
SET IDENTITY_INSERT [dbo].[CustomerMasters] ON 

INSERT [dbo].[CustomerMasters] ([S.No], [CustomerCode], [CustomerName], [ContactPerson], [CustomerAddress], [DeliveryFrom], [SuplierTypeId], [SuplierGstNo], [ContactNo], [CustTypeId]) VALUES (1, N'Vick00254', N'Vicky Kumar', N'N/A', N'Noida Sector-63', N'Noida sector-77', 1, N'25478', N'9304622361', 1)
INSERT [dbo].[CustomerMasters] ([S.No], [CustomerCode], [CustomerName], [ContactPerson], [CustomerAddress], [DeliveryFrom], [SuplierTypeId], [SuplierGstNo], [ContactNo], [CustTypeId]) VALUES (2, N'Arch00258', N'Archit Kumar', N'N/A', N'Chennai', N'NOIDA', 3, N'25874', N'2569854740', 2)
INSERT [dbo].[CustomerMasters] ([S.No], [CustomerCode], [CustomerName], [ContactPerson], [CustomerAddress], [DeliveryFrom], [SuplierTypeId], [SuplierGstNo], [ContactNo], [CustTypeId]) VALUES (3, N'CAPI00ABC', N'CAPITAPLUS', N'DEEPAK KUMAR GUPTA', N'ABC SECTOR-49, NOIDA', N'NOIDA', 2, N'ABCCCC1234567', N'8765456789', 1)
INSERT [dbo].[CustomerMasters] ([S.No], [CustomerCode], [CustomerName], [ContactPerson], [CustomerAddress], [DeliveryFrom], [SuplierTypeId], [SuplierGstNo], [ContactNo], [CustTypeId]) VALUES (4, N'ABCN00AVB', N'ABCNOIDA', N'AJAY VERMA', N'SECTOR-50 NOIDA', N'NOIGA', 3, N'AVBBBSS', N'876456511', 1)
INSERT [dbo].[CustomerMasters] ([S.No], [CustomerCode], [CustomerName], [ContactPerson], [CustomerAddress], [DeliveryFrom], [SuplierTypeId], [SuplierGstNo], [ContactNo], [CustTypeId]) VALUES (5, N'SELF00255', N'SELF STOCK', N'HRITIK', N'JFJF', N'BIHIYA', 3, N'255KJU', N'9632589654', 2)
SET IDENTITY_INSERT [dbo].[CustomerMasters] OFF
SET IDENTITY_INSERT [dbo].[CustomerTypes] ON 

INSERT [dbo].[CustomerTypes] ([Id], [Types]) VALUES (1, N'Self      ')
INSERT [dbo].[CustomerTypes] ([Id], [Types]) VALUES (2, N'Customer  ')
SET IDENTITY_INSERT [dbo].[CustomerTypes] OFF
SET IDENTITY_INSERT [dbo].[FinishedGood] ON 

INSERT [dbo].[FinishedGood] ([Id], [ProductCode], [ProductName], [ShortProductName], [ModelNo], [CellType], [Capacity], [Color], [ShortColorCode], [Brand], [ShortBrandCode], [SAC], [GST], [UOM], [MIN], [Max], [Stock], [StockFreez], [SelfStock], [TRfSelf], [Rate], [StockType], [CustomerName], [IsMinMax], [Cid]) VALUES (1, N'PBBKROCK_SPACE8000IONROUND                        ', N'POWER BANK                                        ', N'PB        ', N'ROUND               ', N'ION                           ', N'8000                ', N'BLACK               ', N'BK        ', N'ROCK_SPACE                    ', N'RS        ', N'10001               ', 18, N'NOS       ', 600, 900, 500, 0, 500, N'Self', 600, N'Self      ', N'Select Customer', N'Yes       ', 0)
INSERT [dbo].[FinishedGood] ([Id], [ProductCode], [ProductName], [ShortProductName], [ModelNo], [CellType], [Capacity], [Color], [ShortColorCode], [Brand], [ShortBrandCode], [SAC], [GST], [UOM], [MIN], [Max], [Stock], [StockFreez], [SelfStock], [TRfSelf], [Rate], [StockType], [CustomerName], [IsMinMax], [Cid]) VALUES (2, N'CHRBKROCK_SPACE6000IONITCJ2403                    ', N'CHARGERS                                          ', N'CHR       ', N'ITCJ2403N           ', N'ION                           ', N'6000                ', N'BLACK               ', N'BK        ', N'ROCK_SPACE                    ', N'RS        ', N'50008               ', 18, N'NOS       ', 200, 600, 500, 0, 500, N'Self', 200, N'Self      ', N'CAPITAPLUS', N'Yes       ', 0)
SET IDENTITY_INSERT [dbo].[FinishedGood] OFF
SET IDENTITY_INSERT [dbo].[MasterPackingType] ON 

INSERT [dbo].[MasterPackingType] ([Id], [PackingType]) VALUES (1, N'Normal Packing')
INSERT [dbo].[MasterPackingType] ([Id], [PackingType]) VALUES (2, N'Gift Packing')
INSERT [dbo].[MasterPackingType] ([Id], [PackingType]) VALUES (3, N'Special Packing')
SET IDENTITY_INSERT [dbo].[MasterPackingType] OFF
SET IDENTITY_INSERT [dbo].[ModelMaster] ON 

INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (1, N'ROUND               ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (2, N'RWC0233             ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (3, N'MUFREE              ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (4, N'MULLA               ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (5, N'ITCJ2403N           ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (6, N'ITCJF90M            ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (7, N'ITCJF90M_GJ         ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (8, N'ITCJ2403N_GJ        ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (9, N'FLAT                ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (10, N'Y5V                 ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (11, N'Y4N                 ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (12, N'Y6M                 ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (13, N'Y405                ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (14, N'P05                 ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (15, N'P07                 ')
INSERT [dbo].[ModelMaster] ([Id], [Model]) VALUES (1001, N'-                   ')
SET IDENTITY_INSERT [dbo].[ModelMaster] OFF
SET IDENTITY_INSERT [dbo].[POTypes] ON 

INSERT [dbo].[POTypes] ([Id], [Type]) VALUES (1, N'MPN')
INSERT [dbo].[POTypes] ([Id], [Type]) VALUES (2, N'ReOrderLable')
INSERT [dbo].[POTypes] ([Id], [Type]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[POTypes] OFF
SET IDENTITY_INSERT [dbo].[ProductMaster] ON 

INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (1, N'POWER BANK', N'PB')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (2, N'EAR PHONE', N'EP')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (3, N'TWO_IN_ONE', N'TWO_IN_ONE')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (4, N'CHARGERS', N'CHR')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (5, N'DATA_CABLE_CTYPE', N'DCTY_P')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (6, N'JIO', N'JIO_P')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (7, N'LIGHTING', N'LRC_P')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (8, N'MICRO_CABLE', N'MRC_P')
INSERT [dbo].[ProductMaster] ([Id], [ProductName], [ShortCode]) VALUES (9, N'Temper Glass', N'TG')
SET IDENTITY_INSERT [dbo].[ProductMaster] OFF
SET IDENTITY_INSERT [dbo].[StatusYesNo] ON 

INSERT [dbo].[StatusYesNo] ([Id], [Type]) VALUES (1, N'Yes       ')
INSERT [dbo].[StatusYesNo] ([Id], [Type]) VALUES (2, N'No        ')
SET IDENTITY_INSERT [dbo].[StatusYesNo] OFF
SET IDENTITY_INSERT [dbo].[SuplierTypes] ON 

INSERT [dbo].[SuplierTypes] ([Id], [SuplierType]) VALUES (1, N'All Raw material')
INSERT [dbo].[SuplierTypes] ([Id], [SuplierType]) VALUES (2, N'Packing Mat')
INSERT [dbo].[SuplierTypes] ([Id], [SuplierType]) VALUES (3, N'Lable')
SET IDENTITY_INSERT [dbo].[SuplierTypes] OFF
SET IDENTITY_INSERT [dbo].[VendorMaster] ON 

INSERT [dbo].[VendorMaster] ([S.No], [VendorCode], [VendorName], [ContactPerson], [VendorAddress], [SuplierTypeId], [SuplierGstNo], [ContactNo]) VALUES (1, N'Vikk00785                     ', N'Vikku Kumar                   ', N'NA                            ', N'estgrsdtg                                                                                           ', 1, N'78547               ', N'87458996541')
INSERT [dbo].[VendorMaster] ([S.No], [VendorCode], [VendorName], [ContactPerson], [VendorAddress], [SuplierTypeId], [SuplierGstNo], [ContactNo]) VALUES (2, N'ABC 00ABC                     ', N'ABC Enterprises               ', N'Sanjay Verma                  ', N'Sector-49 noida                                                                                     ', 1, N'ABC0000001          ', N'9304622361')
INSERT [dbo].[VendorMaster] ([S.No], [VendorCode], [VendorName], [ContactPerson], [VendorAddress], [SuplierTypeId], [SuplierGstNo], [ContactNo]) VALUES (3, N'John00854                     ', N'John                          ', N'Fio                           ', N'Near Ashok Nagar!                                                                                   ', 2, N'8542                ', N'7854589632')
SET IDENTITY_INSERT [dbo].[VendorMaster] OFF
ALTER TABLE [dbo].[CustomerMasters]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMasters_CustomerTypes] FOREIGN KEY([CustTypeId])
REFERENCES [dbo].[CustomerTypes] ([Id])
GO
ALTER TABLE [dbo].[CustomerMasters] CHECK CONSTRAINT [FK_CustomerMasters_CustomerTypes]
GO
ALTER TABLE [dbo].[CustomerMasters]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMasters_SuplierTypesIsd] FOREIGN KEY([SuplierTypeId])
REFERENCES [dbo].[SuplierTypes] ([Id])
GO
ALTER TABLE [dbo].[CustomerMasters] CHECK CONSTRAINT [FK_CustomerMasters_SuplierTypesIsd]
GO
ALTER TABLE [dbo].[VendorMaster]  WITH CHECK ADD  CONSTRAINT [FK_VendorMaster_VendorMasterSuplierTypes] FOREIGN KEY([SuplierTypeId])
REFERENCES [dbo].[SuplierTypes] ([Id])
GO
ALTER TABLE [dbo].[VendorMaster] CHECK CONSTRAINT [FK_VendorMaster_VendorMasterSuplierTypes]
GO
/****** Object:  StoredProcedure [dbo].[GetAllFromFg]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[GetAllFromFg]
  as
  begin
  select * from FGstocks
  end
GO
/****** Object:  StoredProcedure [dbo].[getAllTypeQtyFromMatPlanning]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getAllTypeQtyFromMatPlanning]
  @code nvarchar(30)
  as
  begin
  select QtyAfterWast,QtyToPurchase,QtyInStock from MatPlanning where Code=@code
  end
GO
/****** Object:  StoredProcedure [dbo].[getjobsheet]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   CREATE proc [dbo].[getjobsheet]
   as
   begin
 SELECT t1.JobNo,t1.BomNo,t1.ProductCode,t1.ProductName,t1.Model,t1.CellType,t1.Capacity,t1.Color,t1.Brand,t1.QtyToPro
FROM JobSheets t1
LEFT JOIN CheckMatToDisplay t2 ON t2.Code = t1.ProductCode
WHERE t2.Code IS NULL
end
GO
/****** Object:  StoredProcedure [dbo].[sp_AddBom]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddBom]
@Id int,
@Code nvarchar(30),
@MaterialName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30),
@masterCode nvarchar(100),
@Qty int
 
as
if @Id=0 begin
insert into BillOfMats (RmCode,MatName,Type,Capacity,Color,Model,Qty,MasterProCode)
                         values(@Code,@MaterialName,@Type,@Capacity_AMH,@Color,@Model,@Qty,@masterCode)
	
				
end 
    
     
GO
/****** Object:  StoredProcedure [dbo].[sp_AddCheckMat]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_AddCheckMat]
@Id int, 
@jonno  nvarchar(30) ,
@bomno  nvarchar(30) , 
@Code nvarchar(30),
@productName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@TQty int,  
@brand nvarchar(30)
as
if @Id=0 begin
insert into CheckMatToDisplay (JobNo,BomNo,Code,MatName,Type,Capacity,Color,Model,Qty,Brand)
  values(@jonno,@bomno,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@TQty,@brand)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddCustomerSalesOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddCustomerSalesOrder]
@Id int, 
@orderType  nvarchar(30) ,
@PaymentTerm  nvarchar(30) ,
@CreditPeriod  int ,
@custId	int,
@customerName  nvarchar(30) ,
@Address  nvarchar(30) ,
@contactNo nvarchar(30) ,
@contactPer nvarchar(30) ,
@brand nvarchar(35),
@soQty int,
@stock int,
@Amount int,
@totalAmt int,
@grossAmt int,
@totalGrossAmt int,
@rate int,
@updatedProduceQty int,
@Code nvarchar(30),
@productName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@salesOrderNo nvarchar(50),
@qtytofreez int,
@qtytoproduce int
  
as
if @Id=0 begin
insert into SalesOrder (UpdatedQtyToProduce,Rate,QtyToFreez,QtyTopProduce,SalesOrderNo,OrderType,PaymentTerm,CreditP,Cid,CustomerName,Address,CPerson,CNumber,ProductCode,ProductName,Type,Capacity,Color,Model,Brand,Stock,SoQty,Amount,GrossAmt,TotalAmt,TotalGrossAmt)
  values(@updatedProduceQty,@rate,@qtytofreez,@qtytoproduce, @salesOrderNo,@orderType,@PaymentTerm,@CreditPeriod,@custId,@customerName,@Address,@contactPer,@contactNo,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@brand,@stock,@soQty,@Amount,@grossAmt,@totalAmt,@totalGrossAmt)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddDeliverySchedule]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddDeliverySchedule]
@Id int, 
@custId	int,
 
@Code nvarchar(30),
@productName nvarchar(30),
 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30),  
@DeliveryDate nvarchar(300),
@AddressDelivery nvarchar(300),
@QtyDelivery int,
@salesOrderNo nvarchar(50)
  
as
if @Id=0 begin
insert into DeliverySchedule (SalesOrderNo,Cid,Code,ProductName,Celltype,Capacity,Color,Model,DeliveryDate,AddressDelivery,DeliveryQty)
  values(@salesOrderNo,@custId,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@DeliveryDate,@AddressDelivery,@QtyDelivery)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddFgGoods]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddFgGoods]
@Id int,  
@customerName  nvarchar(30) , 
@brand nvarchar(35), 
@stock int, 
@selfstock nvarchar(35),  
@stockfrezz int, 
@stockType nvarchar(35),
@trfselg nvarchar(35),  
@rate int, 
@max int, 
@min int, 
@gst int, 
@cid int, 
@Code nvarchar(30),
@productName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@shortProCode nvarchar(30), 
@shortColorCode nvarchar(30), 
@shortBrandCode nvarchar(30), 
@sac nvarchar(30), 
@uom nvarchar(30),
@IsMinMax nvarchar(10)
  
as
if @Id=0 begin
insert into FinishedGood (Cid,ProductCode,ProductName,ShortProductName,ModelNo,CellType,Capacity,Color,ShortColorCode,Brand,ShortBrandCode,SAC,GST,UOM,MIN,Max,Stock,StockFreez,SelfStock,TRfSelf,Rate,StockType,CustomerName,IsMinMax)
  values(@cid,@Code,@productName,@shortProCode,@Model,@Type,@Capacity_AMH,@Color,@shortColorCode,@brand,@shortBrandCode,@sac,@gst,@uom,@min,@max,@stock,@stockfrezz,@selfstock,@trfselg,@rate,@stockType,@customerName,@IsMinMax)
 
end 
  
   
GO
/****** Object:  StoredProcedure [dbo].[sp_AddFGStocks]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddFGStocks]
@Id int,

@orderType  nvarchar(30) ,
@PaymentTerm  nvarchar(30) ,
@CreditPeriod  nvarchar(30) ,
@Cid int,
@customerName  nvarchar(30),
@Address  nvarchar(30) ,
@contactNo nvarchar(30) , 
@Code nvarchar(50),
@productName nvarchar(50), 
@Type nvarchar(50),
@Capacity_AMH nvarchar(50),
@Color nvarchar(50),
@Model nvarchar(50),
@Qty int, 
@brand nvarchar(50) ,
 @rate nvarchar(50),
 @TQtyProduce int,
@fgInStockt int ,
@qtytopro int ,
@qtyToFreez int ,
@IsFreez bit 
 
as
if @Id=0 begin
insert into FGstocks (OrderType,PaymentTerm,CreditPeriod,CustomerName,Address,ContactNo,Code,ProductName,Celltype,Capacity,Color,Model,Brand,Rate,TQtyProduce,Quantity,FgInStock,isFreez,QtyToFreez,QtyToProduce,Cid)
  values(@orderType,@PaymentTerm,@CreditPeriod,@customerName,@contactNo,@Address,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@brand,@rate, @TQtyProduce,@Qty,@fgInStockt,@IsFreez,@qtyToFreez,@qtytopro,@Cid)
 
end 
ELSE BEGIN
Update FGstocks
SET 
Code=@Code,
ProductName=@productName,
Celltype=@Type,
Capacity=@Capacity_AMH,
Color=@Color,
Model=@Model,  
Quantity=@Qty ,
Rate=@rate,
TQtyProduce=@TQtyProduce,
Cid=@Cid
 where Id=@Id

 select @Id;
 END
    
     
GO
/****** Object:  StoredProcedure [dbo].[sp_AddGrnOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
CREATE proc [dbo].[sp_AddGrnOrder]
@Id int,
@Code nvarchar(30),
@MaterialName nvarchar(30), 
@UOM1 nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30),
@Qty int, 
@recive int,
@Amount int, 
@vendorN nvarchar(40),
@vendorId int,
@PurchaseId nvarchar(200),
@grnId nvarchar(20),
@entryDate datetime,
@recieveDate datetime,
@gateno nvarchar(35)
as
if @Id=0 begin
insert into Grn(EntryDate,RecieveDate,EntryGateNo,Code,MaterialName,Uom,Type,Capacity,Color,Model,Qty,Amount,Receive,VendorName,VendorId,GrnId,PurId)
                         values(@entryDate,@recieveDate,@gateno, @Code,@MaterialName,@UOM1,@Type,@Capacity_AMH,@Color,@Model,@Qty,@Amount,@recive,@vendorN,@vendorId,@PurchaseId,@grnId)
	
				
end 
    
     
GO
/****** Object:  StoredProcedure [dbo].[sp_AddJobSheet]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddJobSheet]
@Id int,
@Code nvarchar(30),
@MaterialName nvarchar(30),
@jobno nvarchar(30),
@bomno nvarchar(30), 
@salesNo nvarchar(30), 
@Type nvarchar(30),
@brand  nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30),
@Qtytopro int, 
@qtyinpic nvarchar(200),
@totalQty int
 
as
if @Id=0 begin
insert into JobSheets (TotalQty,ProductCode,ProductName,JobNo,SalesOrderNo,CellType,Capacity,Color,Model,QtyToPro,QtyInPieace,BomNo,Brand)
                         values(@totalQty, @Code,@MaterialName,@jobno,@salesNo,@Type,@Capacity_AMH,@Color,@Model,@Qtytopro,@qtyinpic,@bomno,@brand)
	
				
end 
    
     
GO
/****** Object:  StoredProcedure [dbo].[sp_AddMatIssueSlip]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddMatIssueSlip]
@Id int, 
@jonno  nvarchar(30) ,
@bomno  nvarchar(30) ,
@mrsno  nvarchar(30) ,  
@Code nvarchar(30),
@productName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@QtyinPiece int, 
@ytd  int,
@balQty int,
@issueQty int,
@date nvarchar(35)
as
if @Id=0 begin
insert into MatIssueSlip (IssueQty,MrsNo,Job,Code,ProductName,Type,Capacity,Color,Model,QtyInPiece,ytd,BalanceQty,DateCreated,BomNo)
  values(@issueQty,@mrsno,@jonno,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@QtyinPiece,@ytd,@balQty,@date,@bomno)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddMis]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddMis]
@Id int, 
@jonno  nvarchar(30) ,
@bomno  nvarchar(30) , 
@Code nvarchar(30),
@productName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@TQty int, 
@Qtyreq  int,
@qtyinstock int,
@qtytopro int,
@mrsno nvarchar(30),
@waste int,
@qtyAfterWsste int,
@salesno nvarchar(45)
as
if @Id=0 begin
insert into MatPlanning (WasteQty,QtyAfterWast,SalesNo,JobNo,BomNo,Code,MatName,Type,Capacity,Color,Model,Qty,QtyReq,QtyInStock,QtyToPurchase,MrsNo)
  values(@waste,@qtyAfterWsste,@salesno,@jonno,@bomno,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@TQty,@Qtyreq,@qtyinstock,@qtytopro,@mrsno)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddMislip]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddMislip]
@Id int, 
@sales nvarchar(30) ,
@jonno  nvarchar(30) ,
@bomno  nvarchar(30) , 
@Code nvarchar(30),
@productName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@TQty int, 
@ActualQty int,
@wastage int,
@ReqWasteqty int,
@ReqQty int,
@BalQtyReq int,
@mrsno nvarchar(30),
@dates nvarchar(30)
as
if @Id=0 begin
insert into MaterialRequsitionSlip (SalesNo,ActualQty,wastage,ReqWasteqty,ReqQty,BalQtyReq,JobNo,BomNo,Code,MatName,Type,Capacity,Color,Model,Qty,mrsNo,CreatedDate)
  values(@sales,@ActualQty,@wastage,@ReqWasteqty,@ReqQty,@BalQtyReq,@jonno,@bomno,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@TQty,@mrsno,@dates)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddPurchaseOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddPurchaseOrder]
@Id int,
@Code nvarchar(30),
@MaterialName nvarchar(30),
@MaterialGroup nvarchar(30),
@UOM1 nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30),
@StockQty int, 
@sac nvarchar(20),
@Amount int,
@fridge int=null,
@GrossAmount nvarchar(30),
@GrossTotal nvarchar(30),
@NetAmount nvarchar(30),
@gstAmt int,
@gstTotal int,
@vendorN nvarchar(40),
@vendorId int,
@PurchaseId nvarchar(200),
@rate int,
@Purquantity int,
@Reqquantity int,
@potype int,
@entyDate datetime
as
if @Id=0 begin
insert into PurchaseOrderSummary (RequiredQty,PoType,EntryDate,QuantityPurchase,Code,MaterialName,MaterialGroup,[UOM-1],Type,Capacity_AMH,Color,Model,QtyStock,Amount,Fright,GrossAmount,GrossTotal,NetAmount,Sac,VendorName,VendorId,PurchaseId,Rate,GstAmount,GstTotal)
                         values(@Reqquantity,@potype,@entyDate, @purquantity, @Code,@MaterialName,@MaterialGroup,@UOM1,@Type,@Capacity_AMH,@Color,@Model,@StockQty,@Amount,@fridge,@GrossAmount,@GrossTotal,@NetAmount,@sac,@vendorN,@vendorId,@PurchaseId,@rate,@gstAmt,@gstTotal)
	
				
end 
    
     
GO
/****** Object:  StoredProcedure [dbo].[sp_AddQualityCheck]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddQualityCheck]
@Id int, 
@BomNo  nvarchar(30) ,
@ProductCode  nvarchar(30) ,
@ReworkPass  nvarchar(30) ,
@mat1 int, 
@mat2 int,
@mat3 int ,
@mat4 int ,
@mat5 int ,
@mat6 int,
@mat7 int,
@mat8 int,
@mat9 int,
@mat10 int ,
@qcpass nvarchar(30),
@qcNo nvarchar(30),
@wip nvarchar(20)
as
if @Id=0 begin
insert into QualityChecks (BomNo,ProductCode,ReworkPass,Mat1,Mat2,Mat3,Mat4,Mat5,Mat6,Mat7,Mat8,Mat9,Mat10,QcPass,QcNo,WipNo )
  values(@BomNo,@ProductCode,@ReworkPass,@mat1,@mat2,@mat3,@mat4,@mat5,@mat6,@mat7,@mat8,@mat9,@mat10,@qcpass,@qcNo,@wip)
 
end 
ELSE BEGIN
Update QualityChecks
SET 
BomNo=@BomNo,
ProductCode=@ProductCode,
ReworkPass=@ReworkPass,
Mat1=@mat1,
Mat2=@mat2,
Mat3=@mat3,
Mat4=@mat4,
Mat5=@mat5,
Mat6=@mat6,
Mat7=@mat7,
Mat8=@mat8,
Mat9=@mat9,
Mat10=@mat10,
QcPass=@qcpass,
WipNo=@wip
 where Id=@Id

 select @Id;
 END
    
     
GO
/****** Object:  StoredProcedure [dbo].[sp_AddSalesOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddSalesOrder]
@Id int,  
@custId	int, 
@Code nvarchar(30),
@productName nvarchar(30),
@remark nvarchar(30),
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@TQtyPro int,  
@IndivisualPacking nvarchar(30)=null,
@QtyIndivisual int=null,
@BoxPacking  nvarchar(30),
@QtyBox  int,
@ReqBox int,
@pacTypeId int, 
@salesOrderNo nvarchar(50) ,
@pacTypeQty int
as
if @Id=0 begin
insert into SalesOrdersPacking (PackingTypeQty,PackingTypeId,CustomerId,Code,ProductName,Celltype,Capacity,Color,Model,QtyToProduce,IndivisualPacking,QtyIndivisual,BoxPacking,QtyBox,ReqBox,Remark,SalesOrderNo)
  values(@pacTypeQty, @pacTypeId,@custId,@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@TQtyPro,@IndivisualPacking,@QtyIndivisual,@BoxPacking,@QtyBox,@ReqBox,@remark,@salesOrderNo)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddStockTable]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddStockTable]
@Id int, 
@wipno nvarchar(30),
@jobno nvarchar(30), 
@bomno nvarchar(40),
@location nvarchar(30),
@procode nvarchar(50),
@mat1 nvarchar(30),
@mat2 nvarchar(30), 
@mat3 nvarchar(30), 
@mat4 nvarchar(30), 
@mat5 nvarchar(30), 
@mat6 nvarchar(30), 
@mat7 nvarchar(30), 
@mat8 nvarchar(30), 
@mat9 nvarchar(30), 
@mat10 nvarchar(30),  
@qcno nvarchar(30),
@qcpass nvarchar(30),
@rework nvarchar(30),
@qcrework nvarchar(30),
@custNo nvarchar(34),
@salesId nvarchar(20)=null,
@prodSerialNo nvarchar(50)
as
if @Id=0 begin
insert into StockTable (SalesOrderId,Location,WipNo,JobNo,BomNo,ProductCode,Mat1,Mat2,Mat3,Mat4,Mat5,Mat6,Mat7,Mat8,Mat9,Mat10,QcNo,QcPass,Rework,QcRework,ProdSerialNo,CustomerCode)
  values(@salesId,@location,@wipno,@jobno,@bomno,@procode,@mat1,@mat2,@mat3,@mat4,@mat5,@mat6,@mat7,@mat8,@mat9,@mat10,@qcno,@qcpass,@rework,@qcrework,@prodSerialNo,@custNo)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AddWIP]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddWIP]
@Id int, 
@Code nvarchar(30),
@productName nvarchar(30), 
@Type nvarchar(30),
@Capacity_AMH nvarchar(30),
@Color nvarchar(30),
@Model nvarchar(30), 
@TQty int, 
@sc  int,
@ac int,
@wastQty int,
@wipno nvarchar(30),
@date nvarchar(30),
@bom nvarchar(30),
@jobno nvarchar(30),
@QtyAtLocation int
as
if @Id=0 begin
insert into WIP (Code,MatName,Type,Capacity,Color,Model,Qty,StanderdConsuption,ActualConsuption,WastQty,WipNo,Date,BomNo,jobNo,QtyAtLocation)
  values(@Code,@productName,@Type,@Capacity_AMH,@Color,@Model,@TQty,@sc,@ac,@wastQty,@wipno,@date,@bom,@jobno,@QtyAtLocation)
 
end 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_AgaintReorderTypwRM]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_AgaintReorderTypwRM]
  as
  begin
  select * from RoleMaterialCreation where  Stock<Min and Stock>0
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckLocationfromStockTable]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CheckLocationfromStockTable] 
   @jobno nvarchar(35),
   @bom nvarchar(35),
  @wip nvarchar(35)
  as
  begin
   select Location from StockTable
WHERE JobNo=@jobno and WipNo=@wip and BomNo=@bom
 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_geMatIssueSlip]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_geMatIssueSlip] 
as
begin
select JobNo, mrsNo,CreatedDate ,row_number() over (partition by mrsNo order by mrsNo) as RowsNo from MaterialRequsitionSlip
where MisBalQty is null or MisBalQty not in(0)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllBomOnMasterProCode]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getAllBomOnMasterProCode]  
@code nvarchar(45)
as
begin
select * from BillOfMats where SUBSTRING(MasterProCode,1,LEN(MasterProCode)-4)=@code
end


GO
/****** Object:  StoredProcedure [dbo].[sp_getAllBomOnMasterProCodeNoId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_getAllBomOnMasterProCodeNoId] 
@code nvarchar(45)
as
begin 
select distinct(MasterProCode) from BillOfMats where SUBSTRING(MasterProCode,1,LEN(MasterProCode)-4)=@code
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllFromMatRequsitionBymrsNo]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getAllFromMatRequsitionBymrsNo]
  @mrsId nvarchar(45),
  @date nvarchar(45)
  as
  begin
   select * from MaterialRequsitionSlip where mrsNo=@mrsId and CreatedDate=@date
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getAppCode]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_getAppCode]
  as
  begin
  select Id, Code from PurchaseOrderSummary where Qty>0
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getBomDetails]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_getBomDetails]
  @bomcode nvarchar(45)
  as
  begin
  select MatName from BillOfMats where MasterProCode=@bomcode
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getBOMId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getBOMId]   
 @code nvarchar(45)
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(MasterProCode,4) as int)),0) from BillOfMats where SUBSTRING(MasterProCode,1,LEN(MasterProCode)-4)=@code
end
 
 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_getBomOfLastGenerated]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[sp_getBomOfLastGenerated]
  as
  begin
  SELECT top 1 Id, MasterProCode FROM BillOfMats ORDER BY ID DESC 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCodeByMatPlanningNo]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_GetCodeByMatPlanningNo]
  @mpn nvarchar(10)
  as
  begin
  select Id , Code from MatPlanning where MrsNo=@mpn and QtyInStock>0 AND IsPoCreated=0
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDataInMatRequsition]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_GetDataInMatRequsition]
  as  
  begin 
  SELECT SalesOrder.SalesOrderNo,SalesOrder.JobNo,SalesOrder.BomNo,SalesOrder.ProductCode,SalesOrder.ProductName,SalesOrder.Model
  ,SalesOrder.Type,SalesOrder.Capacity,SalesOrder.Color,SalesOrder.QtyTopProduce,
  row_number() over (partition by MrsNo order by MrsNo) as RowsNo
FROM SalesOrder
 JOIN MatPlanning ON SalesOrder.JobNo = MatPlanning.JobNo
WHERE SalesOrder.IsPlanned = 1 and MatPlanning.MrsBalanceQtyRequired Is null or MatPlanning.MrsBalanceQtyRequired not in(0)
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getDataOfPakingType]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_getDataOfPakingType] 
  @jobNo nvarchar(15)
  as
  begin
  SELECT StockTable.ProdSerialNo, SalesOrdersPacking.PackingTypeQty,SalesOrdersPacking.QtyIndivisual
FROM SalesOrdersPacking
 JOIN StockTable ON SalesOrdersPacking.JobNo=StockTable.JobNo
WHERE SalesOrdersPacking.JobNo=@jobNo and SalesOrdersPacking.IndivisualPacking='Yes'
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getDataOfPakingTypeBox]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_getDataOfPakingTypeBox]
  @jobNo nvarchar(15)
  as
  begin
  SELECT StockTable.ProdSerialNo, SalesOrdersPacking.PackingTypeQty,SalesOrdersPacking.QtyIndivisual
FROM SalesOrdersPacking
 JOIN StockTable ON SalesOrdersPacking.JobNo=StockTable.JobNo
WHERE SalesOrdersPacking.JobNo=@jobNo and SalesOrdersPacking.BoxPacking='Yes'
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getFGBYCode]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_getFGBYCode] 
  @json NVARCHAR(MAX) OUTPUT,
  @code nvarchar(30)
  as
  begin
  set @json=(select * from FinishedGood where ProductCode=@code for json PATH,WITHOUT_ARRAY_WRAPPER)
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getFGBYFGstocks]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getFGBYFGstocks]  
  @json NVARCHAR(MAX) OUTPUT,
  @code nvarchar(30)
  as
  begin
  set @json=(select * from FGstocks where Code=@code for json PATH,WITHOUT_ARRAY_WRAPPER)
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getGRNIdByVendorId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_getGRNIdByVendorId] 
 
as
begin
select top 1 ISNULL(MAX(CAST(purId as int)),0) from Grn
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getIssuedQty]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getIssuedQty]
  @jobno nvarchar(15),
  @code nvarchar(45)
  as
  begin
    select Sum(IssueQty) from MatIssueSlip where Job=@jobno And Code=@code
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getJff]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_getJff]
  as
  begin
  select   ProductCode from JobSheets Code  EXCEPT select Code  from CheckMatToDisplay
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getjobId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getjobId]  
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(JobNo,4) as int)),0) from JobSheets
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getJobSheetInMatPlan]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_getJobSheetInMatPlan]
  as
  begin
  select   ProductCode from JobSheets Code  EXCEPT select Code  from CheckMatToDisplay
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getLastJobId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getLastJobId] 
 
as
begin
select top 1 ISNULL(MAX(CAST(JobNo as int)),0) from JobSheets
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getMislipId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_getMislipId]  
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(MrsNo,4) as int)),0) from MatIssueSlip
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getMrsId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getMrsId]  
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(MrsNo,4) as int)),0) from MatPlanning
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getMrslipId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_getMrslipId]  
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(mrsNo,4) as int)),0) from MaterialRequsitionSlip
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getPackingMaterialIfBoxPacYes]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_getPackingMaterialIfBoxPacYes]
 @jobno nvarchar(10)
 as
 begin
   SELECT  StockTable.JobNo,StockTable.ProdSerialNo from StockTable
INNER JOIN SalesOrdersPacking
ON StockTable.JobNo = SalesOrdersPacking.JobNo
where  SalesOrdersPacking.BoxPacking='Yes'
and StockTable.Location=4 and StockTable.JobNo=@jobno
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_getPackingMaterialIfIndiPacYes]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_getPackingMaterialIfIndiPacYes]
 @jobno nvarchar(10)
 as
 begin
   SELECT  StockTable.JobNo,StockTable.ProdSerialNo from StockTable
INNER JOIN SalesOrdersPacking
ON StockTable.JobNo = SalesOrdersPacking.JobNo
where SalesOrdersPacking.IndivisualPacking='Yes'
and StockTable.Location=4 and StockTable.JobNo=@jobno
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_getPobyCode]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_getPobyCode]
  @code nvarchar(20)
  as
  begin
  select * from RoleMaterialCreation where Code=@code 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getPOIdByVendorId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_getPOIdByVendorId]  
as
begin
select top 1 ISNULL(MAX(CAST(PurchaseId as int)),0) from PurchaseOrderSummary  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getProcode]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_getProcode]   
  @jobno nvarchar(35),
  @wipno nvarchar(40),
  @bomno nvarchar(40)
  as
  begin
  select JobNo,BomNo,WipNo,ProductCode,Mat1,Mat2,Mat3,Mat4,Mat5,Mat6,Mat7,Mat8,Mat9,Mat10,QcPass from StockTable
  where JobNo=@jobno and BomNo=@bomno and WipNo=@wipno  
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getQtyByCodeId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getQtyByCodeId]  
  
  @code nvarchar(35),
  @id int 
  as
  begin
  select Quantity from FGstocks where Code=@code and Cid=@id  
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getQualityId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getQualityId]  
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(QcNo,5) as int)),0) from QualityChecks
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getRmCodeFromBom]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE Proc [dbo].[sp_getRmCodeFromBom]   
  @masterCode nvarchar(40)
  as
  begin
    select MatName from BillOfMats where MasterProCode =@masterCode  
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getSalesOrderId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getSalesOrderId]  
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(SalesOrderNo,4) as int)),0) from SalesOrdersPacking
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getStockFromFg]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[sp_getStockFromFg]
  @procode nvarchar(45)
  as
  begin
  select Stock from FinishedGood where ProductCode=@procode and Cid=0
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getStockFromRawMat]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

   CREATE proc [dbo].[sp_getStockFromRawMat]
  @procode nvarchar(45)
  as
  begin
  select UpdatedStock from RoleMaterialCreation where Code=@procode  
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getStockId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_getStockId]
@code nvarchar(30),
@Cid int
as
begin
select top 1 Id from FGstocks where Code=@code and Cid=@Cid order by Id desc
end
     
GO
/****** Object:  StoredProcedure [dbo].[sp_getStockMasterProcodeId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getStockMasterProcodeId]  
as
begin
select top 1 Id from StockTable order by Id DESC
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getStockProductCodeId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getStockProductCodeId]   
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(ProdSerialNo,4) as int)),0) from StockTable
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getStockQtyFromRawMatCreation]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_getStockQtyFromRawMatCreation]
  @code nvarchar(45)
  as
  begin
  select Stock from RoleMaterialCreation where Code=@code
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getStockQtyFromRMByCode]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_getStockQtyFromRMByCode]
  @code nvarchar(45)
  as
  begin
    select UpdatedStock from RoleMaterialCreation where Code =@code
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getWasteFromMatPlanningInRequsition]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_getWasteFromMatPlanningInRequsition]
  @job nvarchar(10)
  as
  begin
  select * from MatPlanning where JobNo=@job
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_getWipId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_getWipId]  
as
begin
select top 1 ISNULL(MAX(CAST(RIGHT(WipNo,4) as int)),0) from WIP
end
GO
/****** Object:  StoredProcedure [dbo].[sp_IsdataAddedInMatReq]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_IsdataAddedInMatReq]  
  @jonno nvarchar(45) 
  as
  begin
  select * from  MatPlanning where JobNo=@jonno   and MrsBalanceQtyRequired<>0
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_IsdataAddedInMatRequsition]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_IsdataAddedInMatRequsition] 
  @mrs nvarchar(45) 
  as
  begin
  select * from  MaterialRequsitionSlip where mrsNo=@mrs and MisBalQty<>0 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_IsdataAddedInMatRequsitionAll]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_IsdataAddedInMatRequsitionAll]  
  @mrs nvarchar(45) 
  as
  begin
  select * from  MaterialRequsitionSlip where mrsNo=@mrs
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_IsQtyOver]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_IsQtyOver]
 as
 begin
 select sum(Quantity) from FGstocks
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_lASTiNSERTEDfG]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   CREATE proc [dbo].[sp_lASTiNSERTEDfG]
   as
begin
select top 1 * from FinishedGood order by Id desc
end
GO
/****** Object:  StoredProcedure [dbo].[sp_truncateFg]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_truncateFg]
  as
  begin
  truncate table FGstocks
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_TruncateZeroQty]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[sp_TruncateZeroQty]
  as
  begin
  delete  from  PurchaseOrderSummary where Qty =0
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UniqueBOM]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_UniqueBOM]
  as
  begin
  select Id, MasterProCode ,row_number() over (partition by MasterProCode order by MasterProCode) as RowsNo from BillOfMats 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UniqueMatPlanningForAgainstPO]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_UniqueMatPlanningForAgainstPO]
  as
  begin
  select Id,MrsNo,JobNo,SalesNo,QtyToPurchase,IsPoCreated,row_number() over (partition by MrsNo order by MrsNo) as RowsNo from MatPlanning
  where QtyToPurchase>0  
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UniquePurId]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UniquePurId] 
@venId int
as
begin
select  distinct(PurchaseId) 
 from PurchaseOrderSummary where VendorId=@venId and Qty>0
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UniqueWipFromStocktable]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_UniqueWipFromStocktable]
  as
  begin
  select Id,WipNo,JobNo,BomNo,ProductCode,ProdSerialNo ,row_number() over (partition by WipNo order by WipNo) as RowsNo from StockTable
  where Location='2'
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UniqueWipFromStocktableForRework]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_UniqueWipFromStocktableForRework]
  as
  begin
  select Id,WipNo,JobNo,BomNo,ProductCode,ProdSerialNo,QcPass, Rework,row_number() over (partition by WipNo order by WipNo) as RowsNo from StockTable
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateBalQty]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_updateBalQty] 
  @jobsno nvarchar(45),
  @matname nvarchar(45),
  @code nvarchar(45),  
  @mrswastqty int,
  @mrsreqwastqty int,
  @mrsreqqty int,
  @mrsbalqtyreq int
  as
  begin
  update MatPlanning
  set MrsWastQty=@mrswastqty,MrsReqWastQty=@mrsreqwastqty,MrsReqQty=@mrsreqqty,MrsBalanceQtyRequired=@mrsbalqtyreq
  where MatName=@matname and JobNo=@jobsno and Code=@code
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateBalQtyInMRSFromMis]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_updateBalQtyInMRSFromMis]
  @jobsno nvarchar(45),
  @matname nvarchar(45),
  @code nvarchar(45), 
  @bomNon nvarchar(45),
  @mrsno nvarchar(45),
  @misYtd int,
  @misQtyIssue int,
  @misbalQty int 
  as
  begin
  update MaterialRequsitionSlip
  set Misytd=@misYtd,MisQtyIssued=@misQtyIssue,MisBalQty=@misbalQty
  where MatName=@matname and JobNo=@jobsno and BomNo=@bomNon and Code=@code and mrsNo=@mrsno
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDSJobNoFromJobSheet]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   create proc [dbo].[sp_UpdateDSJobNoFromJobSheet]  
  @productcode nvarchar(35), 
  @salesNo nvarchar(30),
  @jobno nvarchar(20)
  as
  begin
   update DeliverySchedule
   set JobNo=  @jobno
WHERE  Code=@productcode and SalesOrderNo =@salesNo
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateIssuedQty]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_UpdateIssuedQty]
  @jobno nvarchar(15),
  @code nvarchar(45),
  @qty int
  as
  begin
   update MatIssueSlip set IssueQty=@qty where Job=@jobno And Code=@code
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePackingJobNoFromJobSheet]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_UpdatePackingJobNoFromJobSheet]  
  @productcode nvarchar(35), 
  @salesNo nvarchar(30),
  @jobno nvarchar(20)
  as
  begin
   update SalesOrdersPacking
   set JobNo=  @jobno
WHERE  Code=@productcode and SalesOrderNo =@salesNo
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePoFlagInMatPlanning]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UpdatePoFlagInMatPlanning]
@mpno nvarchar(10),
@code nvarchar(20)
as
begin
update MatPlanning
set IsPoCreated=1 where MrsNo=@mpno and Code=@code
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateQtyInFgStock]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_UpdateQtyInFgStock] 
   @code nvarchar(35), 
   @qty int
  as
  begin
   update  FGstocks
   set Quantity=@qty
WHERE  Code=@code
 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateQtyInFinishedFoods]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_UpdateQtyInFinishedFoods]
   @code nvarchar(35), 
   @qty int
  as
  begin
   update  FinishedGood
   set Stock=@qty
WHERE  ProductCode=@code
 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockInRawMat]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_UpdateStockInRawMat]
  @code nvarchar(35),
  @updatedQty nvarchar(35)
  as
  begin
  update RoleMaterialCreation set UpdatedStock=@updatedQty where Code=@code
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockInStockTableFromSalesOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_UpdateStockInStockTableFromSalesOrder]  
  @productcode nvarchar(45), 
  @salesNo nvarchar(30),
  @qtyToUpdate int,
  @proSerialCode nvarchar(200),
  @cid int
  as
  begin  
   update top (@qtyToUpdate) StockTable 
   set SalesOrderId= @salesNo ,ProdSerialNo=@proSerialCode+CONVERT(nvarchar(100), NEWID()),CustomerCode=@cid
WHERE  ProductCode=@productcode and SalesOrderId is null and CustomerCode=0
  end

 
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockTable]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_UpdateStockTable]
   @jobno nvarchar(35),
   @location int,
   @fromloc int, 
   @serialno nvarchar(100)
  as
  begin
   UPDATE StockTable
SET Location = @location
WHERE JobNo=@jobno and Location=@fromloc and ProdSerialNo=@serialno
 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockTableAfterQCRework]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UpdateStockTableAfterQCRework] 
    @wipno nvarchar(35),
    @procodeSerialNo nvarchar(45),
	@qcrework nvarchar(20)
   
  as
  begin
   UPDATE StockTable
SET QcRework =  @qcrework 
WHERE  WipNo=@wipno and ProdSerialNo=@procodeSerialNo
 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockTableAfterQualitycheck]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_UpdateStockTableAfterQualitycheck]  
   @jobno nvarchar(35),
   @wipno nvarchar(35),
   @procodeSerialNo nvarchar(45), 
   @qCNo nvarchar(55),
   @qcpass nvarchar(10),
   @mat1 int,
   @mat2 int,
   @mat3 int,
   @mat4 int,
   @mat5 int,
   @mat6 int,
   @mat7 int,
    @mat8 int,
   @mat9 int,
   @mat10 int
  as
  begin
   UPDATE StockTable
SET QcNo =  @qCNo, QcPass= @qcpass,Mat1=@mat1,Mat2=@mat2,Mat3=@mat3,Mat4=@mat4,Mat5=@mat5,Mat6=@mat6,Mat7=@mat7,Mat8=@mat8,Mat9=@mat9,Mat10=@mat10
WHERE JobNo=@jobno and WipNo=@wipno and ProdSerialNo=@procodeSerialNo  
 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockTableAfterRework]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UpdateStockTableAfterRework] 
    @wipno nvarchar(35),
    @procodeSerialNo nvarchar(50),
	@rework nvarchar(20) 
  as
  begin
   UPDATE StockTable
SET Rework =  @rework 
WHERE  WipNo=@wipno and ProdSerialNo=@procodeSerialNo
 
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockTableFromJobSheet]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   CREATE proc [dbo].[sp_UpdateStockTableFromJobSheet]  
  @productcode nvarchar(35), 
  @salesNo nvarchar(30),
  @jobno nvarchar(20)
  as
  begin
   update StockTable 
   set JobNo=  @jobno
WHERE  ProductCode=@productcode and SalesOrderId =@salesNo
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStockTablePacking]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UpdateStockTablePacking]
	 
    @jobno nvarchar(35),
    @procodeSerialNo nvarchar(35),
	@indPac nvarchar(20),
	@boxPac nvarchar(20),
	@location int
   
  as
  begin
   UPDATE StockTable
SET IndivisualPacking =  @indPac,BoxPacking=@boxPac ,Location=@location
WHERE  JobNo=@jobno and ProdSerialNo=@procodeSerialNo
 
  end
GO
/****** Object:  StoredProcedure [dbo].[UpdateBomJobInSO]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateBomJobInSO]  
  @jobno nvarchar(35),
    @bomno nvarchar(35),
	@salesno nvarchar(35),
	@code nvarchar(45)
  as
  begin
 
   UPDATE SalesOrder
SET BomNo = @bomno, JobNo=@jobno
WHERE SalesOrderNo=@salesno and ProductCode=@code
 
  end


GO
/****** Object:  StoredProcedure [dbo].[UpdateQtyInJobSheet]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateQtyInJobSheet] 
  @jonno nvarchar(35),
  @code nvarchar(35),
 @remQty int
  as
  begin
 
   UPDATE JobSheets
SET QtyToPro = @RemQty
WHERE JobNo=@jonno and ProductCode=@code
 
  end


GO
/****** Object:  StoredProcedure [dbo].[UpdateQtyInJobSheets]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[UpdateQtyInJobSheets] 
  @jobno nvarchar(20),
  @salesId nvarchar(35),
  @RemQty int,
  @procode nvarchar(40),
  @bomno nvarchar(40)
  as
  begin
   UPDATE   JobSheets
SET JobSheets.QtyToPro = @RemQty
    
FROM JobSheets JOIN Grn
   ON JobSheets.JobNo = @jobno
   and JobSheets.SalesOrderNo = @salesId
   and JobSheets.ProductCode = @procode
    and JobSheets.BomNo = @bomno
  end
GO
/****** Object:  StoredProcedure [dbo].[UpdateQtyInPo]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[UpdateQtyInPo] 
  @vendorId int,
  @code nvarchar(35),
  @RemQty int,
  @purId nvarchar(20)
  as
  begin
   UPDATE   PurchaseOrderSummary
SET PurchaseOrderSummary.Qty = @RemQty
    
FROM PurchaseOrderSummary JOIN Grn
   ON PurchaseOrderSummary.VendorId = @vendorId
   and PurchaseOrderSummary.Code = @code
   and PurchaseOrderSummary.PurchaseId = @purId
  end
 
GO
/****** Object:  StoredProcedure [dbo].[UpdateQtyInSOPacking]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateQtyInSOPacking]  
  @code nvarchar(35),
  @remQty int
  as
  begin
 
   UPDATE SalesOrdersPacking
SET QtyToProduce = @RemQty
WHERE Code=@code
 
  end


GO
/****** Object:  StoredProcedure [dbo].[UpdateQtyToProduceInSalesOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

   CREATE proc [dbo].[UpdateQtyToProduceInSalesOrder]  
   @salesOrder nvarchar(20),
   @ProductCode nvarchar(35),
   @qty int
  as
  begin 
   UPDATE SalesOrder
SET UpdatedQtyToProduce = @qty
WHERE ProductCode=@ProductCode and  SalesOrderNo=@salesOrder
  end
GO
/****** Object:  StoredProcedure [dbo].[UpdateStatusInSalesOrder]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateStatusInSalesOrder] 
  @sono nvarchar(35),
  @code nvarchar(35),
  @cid int,
 @status bit
  as
  begin
 
   UPDATE SalesOrder
SET IsCreated = @status
WHERE Id=@sono and ProductCode=@code and Cid=@cid
 
  end


GO
/****** Object:  StoredProcedure [dbo].[UpdateStatusInSalesOrderFromMatIssueSlip]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateStatusInSalesOrderFromMatIssueSlip] 
  
  @jonno nvarchar(35),
  @bom nvarchar(45),
 @status bit
  as
  begin 
   UPDATE SalesOrder
SET IsMatIssue = @status
WHERE JobNo=@jonno and BomNo=@bom
 
  end


GO
/****** Object:  StoredProcedure [dbo].[UpdateStatusInSalesOrderFromMatPlanning]    Script Date: 26-07-2019 14:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateStatusInSalesOrderFromMatPlanning] 
  @sono nvarchar(35),
  @code nvarchar(35), 
  @jonno nvarchar(35),
  @bom nvarchar(35),
 @status bit
  as
  begin 
   UPDATE SalesOrder
SET IsPlanned = @status
WHERE SalesOrderNo=@sono and ProductCode=@code and JobNo=@jonno and BomNo=@bom
 
  end


GO
