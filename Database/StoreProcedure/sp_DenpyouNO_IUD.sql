 BEGIN TRY 
 Drop Procedure dbo.[sp_DenpyouNO_IUD]
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
CREATE PROCEDURE [dbo].[sp_DenpyouNO_IUD]
	-- Add the parameters for the stored procedure here
	@RenbenKBN			tinyint,
	@seqno				tinyint,
	@prefix				varchar(4),
	@counter			int,
	@InsertOperator     varchar(10),
	@UpdateOperator     varchar(10),
	@Mode               varchar(10),
	@Program            varchar(100),
	@PC                 varchar(30),
	@KeyItem            varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	
	begin try
		begin tran

			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem
	
			if @Mode = 'New'
			begin
				insert into M_DenpyouNO (RenbanKBN, SEQNO, Settouti, [Counter], InsertOperator, InsertDateTime, UpdateOperator, UpdateDateTime)
				values (@RenbenKBN, @seqno, @prefix, @counter, @InsertOperator, getdate(), @UpdateOperator, getdate())
			end

			else if @Mode = 'Update'
			begin
				update M_DenpyouNO 
				set [Counter] = @counter,UpdateOperator=@UpdateOperator,UpdateDateTime=getdate()
				where RenbanKBN = @RenbenKBN and SEQNO = @seqno and Settouti = @prefix
			end

			else if @Mode = 'Delete'
			begin
				delete from M_DenpyouNO
				where RenbanKBN = @RenbenKBN and SEQNO = @seqno and Settouti = @prefix
			end

		commit tran
	end try
	begin catch
		rollback tran
		throw
	end catch
END

