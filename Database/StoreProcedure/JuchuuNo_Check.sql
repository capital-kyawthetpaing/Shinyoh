 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNo_Check]
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
CREATE PROCEDURE [dbo].[JuchuuNo_Check]
	-- Add the parameters for the stored procedure here
@JuchuuNo as varchar(12),
@Errortype   as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @Errortype='E133'
	begin
		if not exists(select 1 from D_Juchuu where JuchuuNO=@JuchuuNo)
			begin
				select * from M_Message where MessageID = 'E133'
			end
		else
		begin
			--not exists
			select 2 as MessageID
		end
	end
END

