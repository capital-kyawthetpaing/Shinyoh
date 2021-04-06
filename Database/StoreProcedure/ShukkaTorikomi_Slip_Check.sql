 BEGIN TRY 
 Drop Procedure dbo.[ShukkaTorikomi_Slip_Check]
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
CREATE PROCEDURE [dbo].[ShukkaTorikomi_Slip_Check]
	@ShukkaSiziNO as varchar(12),
	@Errortype as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if @Errortype = 'Slip'
	begin
		if NOT exists (select * from D_ShukkaSizi where ShukkaSiziNO=@ShukkaSiziNO)
		begin
			select * from M_Message where MessageID = 'E276'
		end
		RETURN;
	end

	if @Errortype = 'Shipped'
	begin 
		if exists (select * from D_ShukkaSiziMeisai where ShukkaSiziNO=@ShukkaSiziNO and ShouhinCD=@ShouhinCD 
		and ShukkaKanryouKBN = (select min(ShukkaKanryouKBN) from D_ShukkaSiziMeisai where ShukkaKanryouKBN=1))
		begin
			select * from M_Message where MessageID = 'E276'
		end
		RETURN;
	end

	if @Errortype = 'Shippable'
	begin
		if exists (select * from D_ShukkaSiziMeisai where ShukkaSiziNO=@ShukkaSiziNO and ShouhinCD=@ShouhinCD
		and ShukkaSiziSuu - ShukkaZumiSuu < @ShukkaSiziNO and ShukkaKanryouKBN = 0 )
		begin
			select * from M_Message where MessageID = 'E276'
		end
		RETURN;
	end
END
