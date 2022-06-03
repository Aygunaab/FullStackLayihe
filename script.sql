USE [MiocaDb]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[ProfilImage] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banners]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[SubTitle] [nvarchar](100) NOT NULL,
	[ActionText] [nvarchar](50) NULL,
	[EndPoint] [nvarchar](200) NULL,
	[Image] [nvarchar](100) NOT NULL,
	[CardWidth] [int] NOT NULL,
 CONSTRAINT [PK_Banners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Baskets]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Baskets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Token] [nvarchar](max) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Baskets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Logo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labels]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Text] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Labels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDiscounts]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDiscounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
 CONSTRAINT [PK_ProductDiscounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPhotos]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPhotos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[OrderBy] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Image] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProductPhotos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReviews]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Ratings] [tinyint] NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Mesage] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_ProductReviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Categoryid] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Text] [ntext] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DiscountPrice] [decimal](18, 2) NULL,
	[Avability] [nvarchar](max) NOT NULL,
	[LabelId] [int] NULL,
	[IsPopularCategory] [bit] NOT NULL,
	[IsBestSeellers] [bit] NOT NULL,
	[StarCount] [tinyint] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSocials]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSocials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SocialId] [int] NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ProductSocials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSpecsifications]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSpecsifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[OrderBy] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Key] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](500) NOT NULL,
	[IsFilter] [bit] NOT NULL,
 CONSTRAINT [PK_ProductSpecsifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Logo] [nvarchar](100) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[Adress] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[BannerCoverImage] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[OrderBy] [int] NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[Subtitle] [nvarchar](20) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DiscountPrice] [decimal](18, 2) NULL,
	[ActionText] [nvarchar](50) NULL,
	[Endpoint] [nvarchar](200) NULL,
	[Image] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socials]    Script Date: 6/3/2022 10:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[AddedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](100) NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Socials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[ProductSpecsifications] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsFilter]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Baskets]  WITH CHECK ADD  CONSTRAINT [FK_Baskets_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Baskets] CHECK CONSTRAINT [FK_Baskets_Products_ProductId]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductDiscounts]  WITH CHECK ADD  CONSTRAINT [FK_ProductDiscounts_Discounts_DiscountId] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDiscounts] CHECK CONSTRAINT [FK_ProductDiscounts_Discounts_DiscountId]
GO
ALTER TABLE [dbo].[ProductDiscounts]  WITH CHECK ADD  CONSTRAINT [FK_ProductDiscounts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDiscounts] CHECK CONSTRAINT [FK_ProductDiscounts_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductPhotos]  WITH CHECK ADD  CONSTRAINT [FK_ProductPhotos_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductPhotos] CHECK CONSTRAINT [FK_ProductPhotos_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK_ProductReviews_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ProductReviews] CHECK CONSTRAINT [FK_ProductReviews_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK_ProductReviews_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReviews] CHECK CONSTRAINT [FK_ProductReviews_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_Categoryid] FOREIGN KEY([Categoryid])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_Categoryid]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Labels_LabelId] FOREIGN KEY([LabelId])
REFERENCES [dbo].[Labels] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Labels_LabelId]
GO
ALTER TABLE [dbo].[ProductSocials]  WITH CHECK ADD  CONSTRAINT [FK_ProductSocials_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSocials] CHECK CONSTRAINT [FK_ProductSocials_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductSocials]  WITH CHECK ADD  CONSTRAINT [FK_ProductSocials_Socials_SocialId] FOREIGN KEY([SocialId])
REFERENCES [dbo].[Socials] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSocials] CHECK CONSTRAINT [FK_ProductSocials_Socials_SocialId]
GO
ALTER TABLE [dbo].[ProductSpecsifications]  WITH CHECK ADD  CONSTRAINT [FK_ProductSpecsifications_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSpecsifications] CHECK CONSTRAINT [FK_ProductSpecsifications_Products_ProductId]
GO
