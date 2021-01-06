 BEGIN TRY 
 Drop Procedure dbo.[sp_DenpyouNO_Check]
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
CREATE PROCEDURE [dbo].[sp_DenpyouNO_Check]
	-- Add the parameters for the stored procedure here
	@RenbenKBN			int,
	@seqno				int,
	@prefix				varchar(4),
	@messageid			varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	
	if @messageid = 'E132'
		begin
		if exists (select 1 from M_DenpyouNO where RenbanKBN = @RenbenKBN and SEQNO = @seqno and Settouti = @prefix)
			begin
				select RenbanKBN, SEQNO, Settouti, Counter, MessageID
				from M_DenpyouNO, M_Message
				where RenbanKBN = @RenbenKBN and SEQNO = @seqno and Settouti = @prefix and MessageID = @messageid
			end	
		else
			begin
				select '0' as MessageID
			end
		end
	else 
		begin
		if not exists (select 1 from M_DenpyouNO where RenbanKBN = @RenbenKBN and SEQNO = @seqno and Settouti = @prefix)
			begin
				select MessageID
				from M_Message
				where MessageID = @messageid
			end
		else
			begin
				select RenbanKBN, SEQNO, Settouti, Counter, '0' as MessageID
				from M_DenpyouNO
				where RenbanKBN = @RenbenKBN and SEQNO = @seqno and Settouti = @prefix
			end
		end	

END

