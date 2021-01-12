 BEGIN TRY 
 Drop Procedure dbo.[SKSZ_D_Exclusive_Insert_Value]
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
CREATE PROCEDURE [dbo].[SKSZ_D_Exclusive_Insert_Value]
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
				(	JuchuuNO varchar(20) COLLATE DATABASE_DEFAULT,
					OperatorCD varchar(10) COLLATE DATABASE_DEFAULT,
					Program varchar(100) COLLATE DATABASE_DEFAULT,
					PC       varchar(30) COLLATE DATABASE_DEFAULT
				)
				EXEC sp_xml_preparedocument @idoc OUTPUT, @Display_XML

INSERT INTO [#Temp_Display]
			SELECT *  FROM openxml(@idoc,'/NewDataSet/test',2)
			with(	
					JuchuuNO varchar(20),
					OperatorCD  varchar(10) ,
					Program varchar(100),
					PC       varchar(30)
				)
				exec sp_xml_removedocument @idoc

declare @OperatorCD as varchar(10) =(select top 1 OperatorCD from #Temp_Display)
, @Program varchar(100) =(select top 1 Program from #Temp_Display)
,@PC       varchar(30)=(select top 1 PC from #Temp_Display)


DECLARE @JuchuuNo_table TABLE (idx int Primary Key IDENTITY(1,1), JuchuuNo varchar(20))
			INSERT @JuchuuNo_table SELECT distinct LEFT((JuchuuNo), CHARINDEX('-', (JuchuuNo)) - 1) FROM #Temp_Display
			
			declare @Count as int = 1
			WHILE @Count <= (SELECT COUNT(*) FROM @JuchuuNo_table)
			BEGIN
			declare @JuchuuNO as varchar(20)=(select JuchuuNo from @JuchuuNo_table WHERE idx =@Count)
			if not exists( select * from D_Exclusive where DataKBN=1 and Number=@JuchuuNO and Program=@Program)
			begin
				EXEC D_Exclusive_Insert
				1,
				@JuchuuNO,
				@OperatorCD,
				@Program,
				@PC;
			end
			else
			begin
				delete  from D_Exclusive where DataKBN=1 and Program=@Program
				EXEC D_Exclusive_Insert
				1,
				@JuchuuNO,
				@OperatorCD,
				@Program,
				@PC;
			end
					 
		SET @Count = @Count + 1
			END;

drop table #Temp_Display
END
