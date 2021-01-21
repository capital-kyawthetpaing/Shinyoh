 BEGIN TRY 
 Drop Procedure dbo.[D_Exclusive_Lock_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Swe Swe
-- Create date: < 2020-11-20>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[D_Exclusive_Lock_Check]
	-- Add the parameters for the stored procedure here
	@JuchuuNO varchar(20),
	@OperatorCD varchar(10),
	@Program varchar(100),
	@PC       varchar(30),
	@Type tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--Delete
if @Type=1
begin
declare @Count as int = 1

	DECLARE @TableA TABLE (idx int Primary Key IDENTITY(1,1), JuchuuNo varchar(20))
			INSERT @TableA SELECT JuchuuNO FROM D_Juchuu

			WHILE @Count <= (SELECT COUNT(*) FROM @TableA)
			BEGIN
			declare @Juchuu1 varchar(20)=(select JuchuuNo from @TableA WHERE idx =@Count)
			if exists( select * from D_Exclusive where DataKBN=1 and Number=@Juchuu1 and Operator=@OperatorCD and Program=@Program)
			begin
				DELETE  
				From D_Exclusive 
				where DataKBN=1
				and Number=(select JuchuuNo from @TableA WHERE idx =@Count)
			end					 
		SET @Count = @Count + 1
			END;

			
	DECLARE @TableB TABLE (idx int Primary Key IDENTITY(1,1), JuchuuNo varchar(20))
			INSERT @TableB SELECT JuchuuNO FROM D_ShukkaSiziMeisai where JuchuuNO is not null
			
		WHILE @Count <= (SELECT COUNT(*) FROM @TableB)
			BEGIN
			declare @Juchuu2 varchar(20)=(select JuchuuNo from @TableB WHERE idx =@Count)
			IF EXISTS( select * from D_Exclusive where DataKBN=1 and Number=@Juchuu2 and Operator=@OperatorCD and Program=@Program)
			begin
				DELETE  
				From D_Exclusive 
				where DataKBN=1
				and Number=(select JuchuuNo from @TableB WHERE idx =@Count)
			end					 
		SET @Count = @Count + 1
			END;
end
	--INSERT
if @Type=2
begin
	if not exists( select * from D_Exclusive where DataKBN=1 and Number=@JuchuuNO)
			begin
				EXEC D_Exclusive_Insert
				1,
				@JuchuuNO,
				@OperatorCD,
				@Program,
				@PC;
				select '1' as MessageID
			end
			else if not exists( select * from D_Exclusive where DataKBN=1 and Number=@JuchuuNO and Operator=@OperatorCD and Program=@Program)			
			begin
				select @JuchuuNO,* from M_Message where MessageID = 'S004'
			end
			else
			begin
			select '1' as MessageID
			end
end
END

