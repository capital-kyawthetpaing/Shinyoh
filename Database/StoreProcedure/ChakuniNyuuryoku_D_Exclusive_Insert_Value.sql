BEGIN TRY 
 Drop Procedure dbo.[ChakuniNyuuryoku_D_Exclusive_Insert_Value]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_D_Exclusive_Insert_Value]
	-- Add the parameters for the stored procedure here
	@Display_XML as xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
declare  @idoc AS INT
CREATE TABLE  [dbo].[#Temp_Display]
				(	ChakuniYoteiNO varchar(12) COLLATE DATABASE_DEFAULT,
				    HacchuuNO varchar(12) COLLATE DATABASE_DEFAULT,
					OperatorCD varchar(10) COLLATE DATABASE_DEFAULT,
					Program varchar(100) COLLATE DATABASE_DEFAULT,
					PC       varchar(30) COLLATE DATABASE_DEFAULT
				)
				EXEC sp_xml_preparedocument @idoc OUTPUT, @Display_XML

INSERT INTO [#Temp_Display]
			SELECT *  FROM openxml(@idoc,'/NewDataSet/test',2)
			with(	
					ChakuniYoteiNO varchar(12),
					HacchuuNO varchar(12),
					OperatorCD  varchar(10) ,
					Program varchar(100),
					PC       varchar(30)
				)
				exec sp_xml_removedocument @idoc



declare @OperatorCD as varchar(10) =(select top 1 OperatorCD from #Temp_Display)
, @Program varchar(100) =(select top 1 Program from #Temp_Display)
,@PC       varchar(30)=(select top 1 PC from #Temp_Display)

Exec [dbo].[D_Exclusive_Remove_NO] 16,@OperatorCD,@Program,@PC

DECLARE @TableA TABLE (idx int Primary Key IDENTITY(1,1), ChakuniYoteiNO varchar(12))
			INSERT @TableA SELECT distinct ChakuniYoteiNO FROM #Temp_Display
			
			declare @Count as int = 1
			WHILE @Count <= (SELECT COUNT(*) FROM @TableA)
			BEGIN
			declare @ChakuniYoteiNO as varchar(12)=(select ChakuniYoteiNO from @TableA WHERE idx =@Count)
			if not exists( select * from D_Exclusive where DataKBN=1 and Number=@ChakuniYoteiNO)
			begin
				EXEC D_Exclusive_Insert
				16,
				@ChakuniYoteiNO,
				@OperatorCD,
				@Program,
				@PC;
				select '1' as MessageID
			end
			else
			begin
				select @ChakuniYoteiNO,* from M_Message where MessageID = 'S004'
			end
					 
		SET @Count = @Count + 1
			END;

Exec [dbo].[D_Exclusive_Remove_NO] 2,@OperatorCD,@Program,@PC

DECLARE @TableB TABLE (idx int Primary Key IDENTITY(1,1), HacchuuNO varchar(12))
			INSERT @TableB SELECT distinct HacchuuNO FROM #Temp_Display
			
			declare @Count1 as int = 1
			WHILE @Count1 <= (SELECT COUNT(*) FROM @TableB)
			BEGIN
			declare @HacchuuNO as varchar(12)=(select HacchuuNO from @TableB WHERE idx =@Count1)
			if not exists( select * from D_Exclusive where DataKBN=1 and Number=@ChakuniYoteiNO)
			begin
				EXEC D_Exclusive_Insert
				2,
				@HacchuuNO,
				@OperatorCD,
				@Program,
				@PC;
				select '1' as MessageID
			end
			else
			begin
				select @HacchuuNO,* from M_Message where MessageID = 'S004'
			end
					 
		SET @Count1 = @Count1 + 1
			END;

drop table #Temp_Display
END
