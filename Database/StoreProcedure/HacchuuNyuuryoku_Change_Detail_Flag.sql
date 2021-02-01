BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Change_Detail_Flag]
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
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_Change_Detail_Flag]

	 @ShouhinCD as varchar(50),
	 @SoukoCD as varchar(10),
	 @filter_date as date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	update M_Shouhin set UsedFlg=1 where 
	ChangeDate = (select ChangeDate from F_Shouhin(@filter_date) where ShouhinCD = @ShouhinCD) and ShouhinCD = @ShouhinCD

	update M_Souko set UsedFlg=1 where 
	SoukoCD = @SoukoCD and KensakuHyouziJun = 0
END
