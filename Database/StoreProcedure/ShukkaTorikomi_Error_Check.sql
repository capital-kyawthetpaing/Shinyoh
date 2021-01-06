 BEGIN TRY 
 Drop Procedure dbo.[ShukkaTorikomi_Error_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Thaw Thaw
-- Create date: 12/15/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaTorikomi_Error_Check]
	@TorikomiDenpyouNO	as varchar(12),
	@Errortype			as varchar(10)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 if @Errortype='E165' 
		begin
			if exists(select * from D_Shukka Shu Inner Join D_ShukkaMeisai Skm  on Shu.ShukkaNO = Skm.ShukkaNO where Shu.TorikomiDenpyouNO = @TorikomiDenpyouNO and Skm.UriageKanryouKBN = 1 )
				begin
					--exists
					 --select 1 from M_Message where MessageID = 'E165'
					select * from D_Shukka Shu Inner Join D_ShukkaMeisai Skm  on Shu.ShukkaNO = Skm.ShukkaNO,M_Message m where Shu.TorikomiDenpyouNO = @TorikomiDenpyouNO and Skm.UriageKanryouKBN = 1
					and m.MessageID='E165'
				end
			
		end
	
END

