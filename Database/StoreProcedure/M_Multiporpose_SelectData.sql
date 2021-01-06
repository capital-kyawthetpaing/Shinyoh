 BEGIN TRY 
 Drop Procedure dbo.[M_Multiporpose_SelectData]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020/11/18
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M_Multiporpose_SelectData]
	@ID		   as int,
	@Key	   as varchar(50),
    @BrandCD   as varchar(15),	
	@Type	   as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @Type=1	 
		begin
		select LEFT (Char1, 40) as Char1  from M_MultiPorpose where ID=103 AND [Key]=@BrandCD
		end

	if @Type=3	 
		begin
		select Char1,Char2 from M_MultiPorpose where ID=110 AND [Key]=1
		end

	else 
		begin
		select 
		ID,[Key],IDName,Char1,Char2,Char3,Char4,Char5,Num1,Num2,Num3,Num4,Num5,
		convert(varchar(10), Date1, 111)as Date1,convert(varchar(10), Date2, 111)as Date2,
		convert(varchar(10), Date3, 111)as Date3,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime
		from M_MultiPorpose where ID=@ID AND [Key]=@Key
		end
	
END

