 BEGIN TRY 
 Drop Procedure dbo.[Souko_Search]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 10/26/2020
-- Description:	Souko_Search
-- =============================================
CREATE PROCEDURE [dbo].[Souko_Search]
	-- Add the parameters for the stored procedure here
	@SoukoCD1 as varchar(10),
	@SoukoCD2 as varchar(10),
	@SoukoName as varchar(25),
	@KanaName as varchar(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select ms.SoukoCD,ms.SoukoName from M_Souko ms
	where 
		(@SoukoCD1 is null or (SoukoCD  >= @SoukoCD1))
	and (@SoukoCD2 is null or (SoukoCD  <= @SoukoCD2))
	and (@SoukoName is null or (SoukoName like '%' + @SoukoName + '%'))
	and (@KanaName is null or (KanaName like '%' + @KanaName + '%'))
	order by 
		SoukoCD
END

