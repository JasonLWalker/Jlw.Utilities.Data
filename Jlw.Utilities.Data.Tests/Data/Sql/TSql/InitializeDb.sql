SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTable](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[LastUpdated] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
SET ANSI_PADDING ON
GO


SET IDENTITY_INSERT TestTable ON
GO
INSERT INTO TestTable (Id, Name, Description, LastUpdated) VALUES (1, 'Test User', 'This is a test user', GETDATE());
INSERT INTO TestTable (Id, Name, Description, LastUpdated) VALUES (2, 'Test User 2', 'This is another test user', GETDATE());
GO
SET IDENTITY_INSERT TestTable OFF
GO



/****** Object:  StoredProcedure [dbo].[sp_GetWebPageData]    Script Date: 10/29/2019 8:52:21 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetRecordData]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetWebPageData]    Script Date: 10/29/2019 8:52:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jason L Walker
-- Create date: 08/01/2016
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetRecordData]
	-- Add the parameters for the stored procedure here
	@Id bigint 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	    -- Insert statements for procedure here
	SELECT * FROM TestTable
	WHERE Id=@Id
END
GO
