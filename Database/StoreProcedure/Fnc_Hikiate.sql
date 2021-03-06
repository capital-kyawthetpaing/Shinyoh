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
-- Description:	Function_引当																													
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate]																	
	-- Add the parameters for the stored procedure here
	@SerialKBN as smallint,--in連番区分
	@SlipNo as varchar(12),--in伝票番号
	@ProcessKBN as smallint,--in処理区分
	@OperatorCD as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @CurrentDateTime datetime = getdate()

	if @SerialKBN = 1
		begin
			if @ProcessKBN = 10 or @ProcessKBN = 21
				begin
					exec dbo.Fnc_Hikiate_11021 @SlipNo,@OperatorCD,@CurrentDateTime
				end	
			else if @ProcessKBN = 20 or @ProcessKBN = 30
				begin	
					exec dbo.Fnc_Hikiate_12030 @SlipNo,@OperatorCD,@CurrentDateTime
				end
		end
	else if @SerialKBN = 12 -- 出荷指示
		begin
			if @ProcessKBN = 10 or @ProcessKBN = 21
				begin
					exec dbo.Fnc_Hikiate_121021 @SlipNo,@OperatorCD,@CurrentDateTime
				end	
			else if @ProcessKBN = 20 or @ProcessKBN = 30
				begin	
					exec dbo.Fnc_Hikiate_122030 @SlipNo,@OperatorCD,@CurrentDateTime
				end
		end
	else if @SerialKBN = 5
		begin
			exec dbo.Fnc_Hikiate_5 @SlipNo,@ProcessKBN,@OperatorCD,@CurrentDateTime
		end
	else if @SerialKBN = 16
		begin
			if @ProcessKBN = 10 or @ProcessKBN = 21
				begin
					exec dbo.Fnc_Hikiate_161021 @SlipNo,@OperatorCD,@CurrentDateTime
				end
			else if @ProcessKBN = 20 or @ProcessKBN = 30
				begin	
					exec dbo.Fnc_Hikiate_162030 @SlipNo,@OperatorCD,@CurrentDateTime
				end
		end
	else if @SerialKBN = 99
		begin
			exec dbo.Fnc_Hikiate_99 @OperatorCD,@CurrentDateTime
		end
END

