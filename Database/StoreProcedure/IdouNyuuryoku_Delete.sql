/****** Object:  StoredProcedure [dbo].[IdouNyuuryoku_Delete]    Script Date: 2021/04/26 10:53:28 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%IdouNyuuryoku_Delete%' and type like '%P%')
DROP PROCEDURE [dbo].[IdouNyuuryoku_Delete]
GO

/****** Object:  StoredProcedure [dbo].[IdouNyuuryoku_Delete]    Script Date: 2021/04/26 10:53:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/04/26 Y.Nishikawa έΙXVͺs³
--              2021/04/26 Y.Nishikawa ³ΚΘSELECTν
-- =============================================
CREATE PROCEDURE [dbo].[IdouNyuuryoku_Delete]
	-- Add the parameters for the stored procedure here
	@XML_Header as xml,
	@XML_Detail as xml
AS
BEGIN
	begin
		DECLARE  @hQuantityAdjust AS INT 
	   
	   declare @Unique as uniqueidentifier = NewID()
	   declare @currentDate as datetime = getdate()

		CREATE TABLE #Temp_Header
				(   
					IdouNO				varchar(12) COLLATE DATABASE_DEFAULT,
					StaffCD					varchar(10) COLLATE DATABASE_DEFAULT,
					IdouKBN				smallint,
					IdouDate				date,
					ShukkoSoukoCD		varchar(10) COLLATE DATABASE_DEFAULT,
					NyuukoSoukoCD      varchar(10) COLLATE DATABASE_DEFAULT,
					IdouDenpyouTekiyou      varchar(80) COLLATE DATABASE_DEFAULT,
					InsertOperator						varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator				    varchar(10) COLLATE DATABASE_DEFAULT,
					PC			    varchar(20) COLLATE DATABASE_DEFAULT,
					ProgramID						varchar(100)
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Header

		
	    INSERT INTO #Temp_Header
           (IdouNO,StaffCD,IdouKBN,IdouDate,ShukkoSoukoCD ,NyuukoSoukoCD,IdouDenpyouTekiyou,InsertOperator,UpdateOperator,PC,ProgramID)
			 
			    SELECT IdouNO,StaffCD,IdouKBN,IdouDate,ShukkoSoukoCD,NyuukoSoukoCD,NULLIf(IdouDenpyouTekiyou,''),InsertOperator,UpdateOperator,PC,ProgramID
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					IdouNO				varchar(12) 'IdouNO',
					StaffCD					varchar(10) 'StaffCD',
					IdouKBN				smallint 'IdouKBN',
					IdouDate				date 'IdouDate',
					ShukkoSoukoCD			varchar(10) 'ShukkoSoukoCD',
					NyuukoSoukoCD		varchar(10) 'NyuukoSoukoCD',
					IdouDenpyouTekiyou      varchar(80) 'IdouDenpyouTekiyou',
					InsertOperator						varchar(10) 'InsertOperator',
					UpdateOperator				    varchar(10) 'UpdateOperator',
					PC			    varchar(20) 'PC',
					ProgramID						varchar(100) 'ProgramID'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		--2021/04/26 Y.Nishikawa DEL ³ΚΘSELECTν««
	    --SELECT * FROM #Temp_Header
		--2021/04/26 Y.Nishikawa DEL ³ΚΘSELECTνͺͺ

		CREATE TABLE #Temp_Detail
				(   
					ShouhinCD				     varchar(50) COLLATE DATABASE_DEFAULT,
					ShouhinName			    varchar(100) COLLATE DATABASE_DEFAULT,
					ColorRyakuName					    varchar(100) COLLATE DATABASE_DEFAULT,
					ColorNO			    varchar(50) COLLATE DATABASE_DEFAULT,
					SizeNO               varchar(13) COLLATE DATABASE_DEFAULT,
					KanriNO         varchar(10) COLLATE DATABASE_DEFAULT,	
					IdouSuu                decimal(21,6),
					GenkaTanka			    decimal(21,6),
					GenkaKingaku         decimal(21,6),	
					IdouMeisaiTekiyou				 varchar(80) COLLATE DATABASE_DEFAULT,
					IdouNO			    varchar(12) COLLATE DATABASE_DEFAULT,
					IdouGyouNO       smallint 
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Detail

		
	    INSERT INTO #Temp_Detail
           (ShouhinCD,ShouhinName,ColorRyakuName,ColorNO    
			,SizeNO,KanriNO,IdouSuu,GenkaTanka,GenkaKingaku,IdouMeisaiTekiyou,IdouNO,IdouGyouNO)
			 
			   SELECT ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,KanriNO,IdouSuu,GenkaTanka,GenkaKingaku,NULLIF(IdouMeisaiTekiyou,''),IdouNO,IdouGyouNO
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShouhinCD				     varchar(50) 'ShouhinCD',
					ShouhinName			    varchar(100) 'ShouhinName',
					ColorRyakuName					    varchar(100) 'ColorRyakuName',
					ColorNO			    varchar(50) 'ColorNO',
					SizeNO               varchar(13) 'SizeNO',
					KanriNO         varchar(10) 'KanriNO',
					IdouSuu                 decimal(21,6) 'IdouSuu',
					GenkaTanka			     decimal(21,6) 'GenkaTanka',
					GenkaKingaku          decimal(21,6) 'GenkaKingaku',	
					IdouMeisaiTekiyou				 varchar(80) 'IdouMeisaiTekiyou',
					IdouNO		    varchar(12) 'IdouNO',
					IdouGyouNO       smallint 'IdouGyouNO')

		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		 --2021/04/26 Y.Nishikawa DEL ³ΚΘSELECTν««
		 --SELECT * FROM #Temp_Detail		
		 --2021/04/26 Y.Nishikawa DEL ³ΚΘSELECTνͺͺ

		  declare @filter_date as date = (select IdouDate from #Temp_Header)


		   --D_IdouHistory C
			 INSERT INTO D_IdouHistory 
			 (HistoryGuid,IdouNO,ShoriKBN,StaffCD,IdouKBN,IdouDate,KaikeiYYMM,ShukkoSoukoCD,NyuukoSoukoCD,IdouDenpyouTekiyou,InsertOperator,
			    InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			 select @Unique,DI.IdouNO,30,DI.StaffCD,DI.IdouKBN,DI.IdouDate,DI.KaikeiYYMM,DI.ShukkoSoukoCD,DI.NyuukoSoukoCD,DI.IdouDenpyouTekiyou,DI.InsertOperator,
				DI.InsertDateTime,DI.UpdateOperator,DI.UpdateDateTime,TH.InsertOperator,@currentDate
				from D_Idou DI inner join #Temp_Header TH on DI.IdouNO=TH.IdouNO

			 --D_IdouMeisaiHistory D
			 INSERT INTO D_IdouMeisaiHistory
			 (HistoryGuid,IdouNO,IdouGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,IdouSuu,
			  TaniCD,GenkaTanka,GenkaKingaku,IdouMeisaiTekiyou,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			 select @Unique,DIM.IdouNO,DIM.IdouGyouNO,DIM.GyouHyouziJun,30,DIM.KanriNO,DIM.BrandCD,DIM.ShouhinCD,DIM.ShouhinName,DIM.JANCD,DIM.ColorRyakuName,DIM.ColorNO,DIM.SizeNO,DIM.IdouSuu,
				DIM.TaniCD,DIM.GenkaTanka,DIM.GenkaKingaku,DIM.IdouMeisaiTekiyou,DIM.InsertOperator,DIM.InsertDateTime,DIM.UpdateOperator,DIM.UpdateDateTime,h.InsertOperator,@currentDate
				from D_IdouMeisai DIM inner join #Temp_Detail TD on DIM.IdouNO = TD.IdouNO and DIM.IdouGyouNO=TD.IdouGyouNO,#Temp_Header h 

			  --D_Iodu A
				Delete from D_Idou  
				where IdouNO IN (select IdouNO From #Temp_Header) 

			  --D_IdouMeisai B
			    Delete From D_IdouMeisai 
				where IdouNO IN (select IdouNO From #Temp_Detail) and IdouGyouNO IN (select IdouGyouNO From #Temp_Detail)

				declare @ShukkoSoukoCD as varchar(10)= (select ShukkoSoukoCD from #Temp_Header)
				declare @NyuukoSoukoCD as varchar(10)= (select NyuukoSoukoCD from #Temp_Header)
				declare @IdouKBN as smallint = (select IdouKBN from #Temp_Header)

				declare @ShouhinCD varchar(50)
				
				if @IdouKBN = 1 or @IdouKBN = 3
					begin 
					update D_GenZaiko set 
					--2021/04/26 Y.Nishikawa CHG έΙXVͺs³««
					--GenZaikoSuu = GenZaikoSuu + TD.IdouSuu
					GenZaikoSuu = GenZaikoSuu - TD.IdouSuu
					--2021/04/26 Y.Nishikawa CHG έΙXVͺs³ͺͺ
					from #Temp_Detail TD
					inner join D_GenZaiko DGZ on DGZ.SoukoCD=@NyuukoSoukoCD and DGZ.ShouhinCD=TD.ShouhinCD and DGZ.KanriNO=TD.KanriNO and DGZ.NyuukoDate= (select MAX(NyuukoDate) from D_GenZaiko DGZ
					inner join #Temp_Detail TD on DGZ.SoukoCD=@NyuukoSoukoCD and DGZ.ShouhinCD=TD.ShouhinCD and DGZ.KanriNO=TD.KanriNO)

					
					--exec dbo.IdouNyuuryoku_Change_Main_Flag @filter_date,NULL,@NyuukoSoukoCD,'Souko'
					end

			   if @IdouKBN = 2 or @IdouKBN = 3
					begin 
						DECLARE @Detail_table TABLE (idx int Primary Key IDENTITY(1,1), IdouSuu decimal(21,6),SoukoCD varchar(10),ShouhinCD varchar(50),KanriNO varchar(10))
						INSERT @Detail_table SELECT IdouSuu,@ShukkoSoukoCD,ShouhinCD,KanriNO FROM #Temp_Detail
						declare @Detail_Count as int =(SELECT COUNT(*) FROM @Detail_table)
						declare @i_Count as int = 1
						declare @IdouSuu as decimal(21,6)
						
						WHILE @i_Count <= @Detail_Count
						BEGIN
						
						   set @IdouSuu = (SELECT IdouSuu FROM @Detail_table WHERE idx = @i_Count)	
							
									DECLARE @DGZ_table TABLE (idx int, DGZ_IdouSuu decimal(21,6),SoukoCD varchar(10),ShouhinCD varchar(50),KanriNO varchar(10),NyuukoDate Date)

									INSERT @DGZ_table SELECT Row_Number() OVER (ORDER BY idx),DGZ.GenZaikoSuu,DGZ.SoukoCD,DGZ.ShouhinCD,DGZ.KanriNO,DGZ.NyuukoDate FROM @Detail_Table TD
									inner join D_GenZaiko DGZ on DGZ.SoukoCD=@ShukkoSoukoCD and DGZ.ShouhinCD=TD.ShouhinCD and DGZ.KanriNO=TD.KanriNO
									where idx = @i_Count
									ORDER BY DGZ.NyuukoDate desc

									--2021/04/26 Y.Nishikawa DEL ³ΚΘSELECTν««
									--select * from @DGZ_table
									--2021/04/26 Y.Nishikawa DEL ³ΚΘSELECTνͺͺ

									declare @DGZ_Count  int =(SELECT COUNT(*) FROM @DGZ_table)
									
									declare @j_Count int = 1
										WHILE @j_Count <=  @DGZ_Count and @IdouSuu <> 0
											Begin
													declare @DGZ_IdouSuu decimal(21,6) = (SELECT DGZ_IdouSuu FROM @DGZ_table WHERE idx = @j_Count)													
													select @IdouSuu,@DGZ_IdouSuu 
													 if @IdouSuu > @DGZ_IdouSuu 
														begin
															update D_GenZaiko set GenZaikoSuu = 0 
															from D_GenZaiko DGZ inner join @DGZ_Table tDGZ on tDGZ.SoukoCD=DGZ.SoukoCD and tDGZ.ShouhinCD= DGZ.ShouhinCD and tDGZ.KanriNO=DGZ.KanriNO and tDGZ.NyuukoDate= DGZ.NyuukoDate
														    where tDGZ.idx= @j_Count
														  
															
															set @IdouSuu = @IdouSuu- @DGZ_IdouSuu
														end
													 else 
														begin
															update D_GenZaiko set GenZaikoSuu = GenZaikoSuu - @IdouSuu
															from D_GenZaiko DGZ inner join @DGZ_Table tDGZ on  tDGZ.SoukoCD=DGZ.SoukoCD and tDGZ.ShouhinCD= DGZ.ShouhinCD and tDGZ.KanriNO=DGZ.KanriNO and tDGZ.NyuukoDate= DGZ.NyuukoDate
															where tDGZ.idx= @j_Count
														
														set @IdouSuu = 0
														end
										
												SET @j_Count = @j_Count + 1
											End
							SET @i_Count = @i_Count + 1
							delete from  @DGZ_table
						END
						
						--exec dbo.IdouNyuuryoku_Change_Main_Flag @filter_date,NULL,@ShukkoSoukoCD,'Souko'
				End
				--L_Log Z
			declare	@InsertOperator  varchar(10) = (select h.InsertOperator from #Temp_Header h)
			declare @Program         varchar(100) = (select h.ProgramID from #Temp_Header h)
			declare @PC              varchar(30) = (select h.PC from #Temp_Header h)
		   declare @OperateMode     varchar(50) = 'Delete' 
		   declare @KeyItem         varchar(100)= (select h.IdouNO from #Temp_Header h)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

			--D_Exclusive Y
			Delete from D_Exclusive where DataKBN = 15 and Number = (select IdouNO from #Temp_Header)
	end   
	
END
GO
