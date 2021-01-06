 BEGIN TRY 
 Drop Procedure dbo.[Souko_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Hnin Ei Thu
-- Create date: 2020-10-21
-- Description: if user exists return '' else return ''
-- =============================================
CREATE PROCEDURE [dbo].[Souko_Select]
	-- Add the parameters for the stored procedure here
	@SoukoCD		as varchar(10),
	@ErrorType		as varchar(10) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
if @ErrorType='E270'
	begin	
	if exists(select * from M_Souko
				where SoukoCD = @SoukoCD and UsedFlg=1)
		begin 
			--not exists
			select * from M_Message 
			where MessageID = 'E270'
			end
		else
		begin
			--exists
			select mm.*,ms.* from M_Message mm ,M_Souko ms
			where MessageID ='E132'
			and SoukoCD = @SoukoCD	
			
		end		
	end
else if @ErrorType='E101'
	if exists(select * from M_Souko	where SoukoCD = @SoukoCD)
		begin	
			--exists
			select mm.*,ms.* from M_Message mm ,M_Souko ms
			where MessageID ='E132'
			and SoukoCD = @SoukoCD	
		end
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E101'
		end
else if exists(select * from M_Souko where SoukoCD = @SoukoCD)
		begin	
			--exists
			select mm.*,ms.* from M_Message mm ,M_Souko ms
			where MessageID ='E132'
			and SoukoCD = @SoukoCD	
		end
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'			
		end	
END

