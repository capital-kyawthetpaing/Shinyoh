 BEGIN TRY 
 Drop Procedure dbo.[CSV_M_ShukkaTorikomi_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Thaw Thaw
-- Create date: 2020-12-24
-- Description:	Insert D_Shukka Table
-- =============================================
CREATE PROCEDURE [dbo].[CSV_M_ShukkaTorikomi_CUD]
	-- Add the parameters for the stored procedure here
	@xml as XML,
	@condition  varchar(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE  @hQuantityAdjust	AS INT 
	declare  @currentDate as datetime = getdate()

	begin

		CREATE TABLE #Temp
				(   
					TokuisakiCD					varchar(10) COLLATE DATABASE_DEFAULT,
					KouritenCD					varchar(10) COLLATE DATABASE_DEFAULT,
					TokuisakiRyakuName			varchar(40) COLLATE DATABASE_DEFAULT,
					KouritenRyakuName			varchar(40) COLLATE DATABASE_DEFAULT,
					DenpyouNO					varchar(12) COLLATE DATABASE_DEFAULT,
					DenpyouDate					date,
					ChangeDate					date,
					ShouhinCD					varchar(10) COLLATE DATABASE_DEFAULT,
					ColorNO						varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO						varchar(12) COLLATE DATABASE_DEFAULT,
					JANCD						varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaSuu					varchar(10) COLLATE DATABASE_DEFAULT,
					UnitPrice					varchar(10) COLLATE DATABASE_DEFAULT,
					SellingPrice				varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaSiziNO				smallint,
					InsertOperator				varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator				varchar(10) COLLATE DATABASE_DEFAULT,
					Error						varchar(10) 
				)
	   EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @xml

	    INSERT INTO #Temp
           (TokuisakiCD
			  ,KouritenCD          
			  ,TokuisakiRyakuName          
			  ,KouritenRyakuName       
			  ,DenpyouNO 
			  ,DenpyouDate           
			  ,ChangeDate    
			  ,ShouhinCD 
			  ,ColorNO
			  ,SizeNO           
			  ,JANCD           
			  ,ShukkaSuu             
			  ,UnitPrice             
			  ,SellingPrice               
			  ,ShukkaSiziNO                
			  ,InsertOperator                
			  ,UpdateOperator                
			  ,Error)
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					TokuisakiCD					varchar(10) 'TokuisakiCD',
					KouritenCD					varchar(10) 'KouritenCD',
					TokuisakiRyakuName			varchar(40) 'TokuisakiRyakuName',
					KouritenRyakuName			varchar(40) 'KouritenRyakuName',
					DenpyouNO					varchar(12) 'DenpyouNO',
					DenpyouDate					date 'DenpyouDate',
					ChangeDate					date 'ChangeDate', 
					ShouhinCD					varchar(10) 'ShouhinCD',
					ColorNO						varchar(13) 'ColorNO',
					SizeNO						varchar(12) 'SizeNO',
					JANCD						varchar(10) 'JANCD',
					ShukkaSuu					varchar(10) 'ShukkaSuu',
					UnitPrice					varchar(10) 'UnitPrice',
					SellingPrice				varchar(10) 'SellingPrice',
					ShukkaSiziNO				smallint 'ShukkaSiziNO',
					InsertOperator				varchar(10) 'InsertOperator',
					UpdateOperator				varchar(10) 'UpdateOperator',
					Error						varchar(10) 'Error'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp
		if @condition = 'create_update'
			begin
				INSERT INTO D_Shukka
           (TokuisakiCD
			  ,KouritenCD          
			  ,TokuisakiRyakuName          
			  ,KouritenRyakuName       
			  ,DenpyouNO 
			  ,DenpyouDate           
			  ,ChangeDate    
			  ,ShouhinCD 
			  ,ColorNO
			  ,SizeNO           
			  ,JANCD           
			  ,ShukkaSuu             
			  ,UnitPrice             
			  ,SellingPrice               
			  ,ShukkaSiziNO                
			  ,InsertOperator 
			  ,InsertDateTime
			  ,UpdateOperator
			  ,UpdateDateTime) 

			 select TokuisakiCD
			  ,KouritenCD          
			  ,TokuisakiRyakuName          
			  ,KouritenRyakuName       
			  ,DenpyouNO 
			  ,DenpyouDate           
			  ,ChangeDate    
			  ,ShouhinCD  
			  ,ColorNO
			  ,SizeNO           
			  ,JANCD           
			  ,ShukkaSuu             
			  ,UnitPrice             
			  ,SellingPrice               
			  ,ShukkaSiziNO                
			  ,InsertOperator
			  ,@currentDate
			  ,UpdateOperator
			  ,@currentDate
			 from #Temp 
			 WHERE  NOT EXISTS (SELECT TokuisakiCD,KouritenCD From D_Shukka WHERE TokuisakiCD = #Temp.TokuisakiCD and KouritenCD=#Temp.KouritenCD)
			 and #Temp.Error='false'

			update D_Shukka
		set         
						TokuisakiRyakuName = t.TokuisakiRyakuName,
						KouritenRyakuName = t.KouritenRyakuName,
						DenpyouNO = t.DenpyouNO,
						DenpyouDate = t.DenpyouDate,
						ChangeDate = t.ChangeDate, 
						ShouhinCD = t.ShouhinCD,
						ColorNO = t.ColorNO,
						SizeNO = t.SizeNO, 
						JANCD = t.JANCD, 
						ShukkaSuu = t.ShukkaSuu, 
						UnitPrice = t.UnitPrice,
						SellingPrice = t.SellingPrice,
						ShukkaSiziNO = t.ShukkaSiziNO,
						UpdateOperator = t.UpdateOperator,
						UpdateDateTime = @currentDate
			from D_Shukka ms inner join #Temp t on ms.TokuisakiCD=t.TokuisakiCD and ms.KouritenCD=t.KouritenCD
			where EXISTS (SELECT TokuisakiCD,KouritenCD From D_Shukka WHERE TokuisakiCD = t.TokuisakiCD and KouritenCD=t.KouritenCD) and t.Error='false'			
			end

		else if @condition= 'delete'
		 begin
		   delete mt from D_Shukka mt inner join #Temp t on mt.TokuisakiCD= t.TokuisakiCD and mt.KouritenCD=t.KouritenCD
		   where EXISTS (SELECT TokuisakiCD,KouritenCD From D_Shukka WHERE TokuisakiCD = t.TokuisakiCD and KouritenCD = t.KouritenCD ) and t.Error='false'		
		 end
		DROP TABLE #Temp
	end
END



