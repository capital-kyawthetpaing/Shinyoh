 BEGIN TRY 
 Drop Procedure dbo.[Fnc_Hikiate]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2020-11-24
-- Description:	引当Function																													
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate]																	
	-- Add the parameters for the stored procedure here
	@SerialKBN as smallint,--in連番区分
	@SlipNo as smallint,--in伝票番号
	@ProcessKBN as smallint--in処理区分
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @SerialKBN = 1 -- 受注
		begin
			--１処理対象データを抽出する(Extract the data to be processed)																								
			select 
				*
			from 
				D_JuchuuMeisai
			where
				JuchuuNO = @SlipNo
			and HacchuuNO is null
		end
END

