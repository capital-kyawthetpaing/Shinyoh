 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Change_Detail_Flag]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Change_Detail_Flag]
	
	 @SiiresakiCD as varchar(20),
	 @ShouhinCD as varchar(20),
	 @SoukoCD as varchar(20),
	 @filter_date as date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update M_Siiresaki set UsedFlg=1 where 
	ChangeDate = (select ChangeDate from F_Siiresaki(@filter_date) where SiiresakiCD = @SiiresakiCD)

	update M_Shouhin set UsedFlg=1 where 
	ChangeDate = (select ChangeDate from F_Shouhin(@filter_date) where ShouhinCD = @ShouhinCD)

	update M_Souko set UsedFlg=1 where 
	SoukoCD = @SoukoCD and KensakuHyouziJun = 0
END

