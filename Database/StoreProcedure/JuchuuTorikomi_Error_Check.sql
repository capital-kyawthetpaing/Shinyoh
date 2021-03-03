BEGIN TRY 
 Drop Procedure dbo.[JuchuuTorikomi_Error_Check]
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
CREATE PROCEDURE [dbo].[JuchuuTorikomi_Error_Check]
	@TorikomiDenpyouNO	as varchar(12),
	@Errortype			as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   if @Errortype='E160' 
		begin
			if exists(select * from D_Juchuu A Inner join D_JuchuuMeisai B On A.JuchuuNO=B.JuchuuNO where A.TorikomiDenpyouNO=@TorikomiDenpyouNO and B.ShukkaSiziKanryouKBN=1)
				begin
					Select * from M_Message where MessageID='E160'
				end
		    else
		        begin
		            select * From M_Message where MessageID='E132' 
		        end
		end
    
	
     if @Errortype='E265' 
		begin
			if exists(select * from D_HacchuuMeisai A Inner Join D_JuchuuMeisai B on A.JuchuuNO=B.JuchuuNO and A.JuchuuGyouNO=B.JuchuuGyouNO  inner join D_Juchuu C On B.JuchuuNO=C.JuchuuNO And C.TorikomiDenpyouNO=@TorikomiDenpyouNO 
                      And A.ChakuniYoteiKanryouKBN=1)
				begin
					Select * from M_Message where MessageID='E265'
				end
		   else
		        begin
		            select * From M_Message where MessageID='E132' 
		        end
		end

END
GO
