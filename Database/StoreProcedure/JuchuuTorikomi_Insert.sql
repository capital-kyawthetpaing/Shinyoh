/****** Object:  StoredProcedure [dbo].[JuchuuTorikomi_Insert]    Script Date: 2021/04/13 13:05:34 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%JuchuuTorikomi_Insert%' and type like '%P%')
DROP PROCEDURE [dbo].[JuchuuTorikomi_Insert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History:     2021/07/07 Y.Nishikawa Remake
--              2021/07/12 Y.Nishikawa Add
-- =============================================
CREATE PROCEDURE [dbo].[JuchuuTorikomi_Insert]
@XML_Hacchuu as xml,
@XML_Jucchuu as xml,
@type	varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE  @hQuantityAdjust AS INT 
			declare @currentDate as datetime = getdate()
			declare @Unique as uniqueidentifier = NewID()

			CREATE TABLE #Temp_Hacchuu
							(  
							  HacchuuNO varchar(200) COLLATE DATABASE_DEFAULT,
							  --2021/07/07 Y.Nishikawa ADD Remake↓↓
						      HacchuuGyouNO smallint,
						      --2021/07/07 Y.Nishikawa ADD Remake↑↑
							  HacchuuDate varchar(200) COLLATE DATABASE_DEFAULT,
							  StaffCD varchar(200) COLLATE DATABASE_DEFAULT,
							  HacchuuDenpyouTekiyou varchar(200) COLLATE DATABASE_DEFAULT,
							  ShouhinCD varchar(200) COLLATE DATABASE_DEFAULT,
							  ColorRyakuName varchar(200)COLLATE DATABASE_DEFAULT,
							  SizeNO varchar(200) COLLATE DATABASE_DEFAULT,
							  --JANCD varchar(200) COLLATE DATABASE_DEFAULT,
							  HacchuuTanka varchar(200) COLLATE DATABASE_DEFAULT,
							  HacchuuSuu varchar(200) COLLATE DATABASE_DEFAULT,
							  SiiresakiCD varchar(200) COLLATE DATABASE_DEFAULT,
							  SiiresakiRyakuName varchar(200) COLLATE DATABASE_DEFAULT,
							  ChakuniYoteiDate varchar(200) COLLATE DATABASE_DEFAULT,
							  SoukoCD varchar(200) COLLATE DATABASE_DEFAULT,
							  SoukoName varchar(200) COLLATE DATABASE_DEFAULT,
							  SiiresakiName varchar(200) COLLATE DATABASE_DEFAULT,
							  SiiresakiYuubinNO1 varchar(200)COLLATE DATABASE_DEFAULT,
							  SiiresakiYuubinNO2 varchar(200) COLLATE DATABASE_DEFAULT,
							  SiiresakiJuusho1 varchar(200) COLLATE DATABASE_DEFAULT,
							  SiiresakiJuusho2 varchar(200) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO1-1] varchar(200) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO1-2] varchar(200) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO1-3] varchar(200) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO2-1]  varchar(200) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO2-2] varchar(200) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO2-3] varchar(200) COLLATE DATABASE_DEFAULT,
							  HacchuuMeisaiTekiyou  varchar(200) COLLATE DATABASE_DEFAULT,
							  Operator varchar(200) COLLATE DATABASE_DEFAULT,
							  ProgramID	 varchar(200) COLLATE DATABASE_DEFAULT,
							  PC varchar(200) COLLATE DATABASE_DEFAULT,
							  Error	varchar(200),
							  JuchuuNO varchar(200),
							  --2021/07/07 Y.Nishikawa ADD Remake↓↓
						      JuchuuGyouNO smallint,
						      --2021/07/07 Y.Nishikawa ADD Remake↑↑
							)
			--2021/07/07 Y.Nishikawa DEL Remake↓↓
							--EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Hacchuu

			--INSERT INTO #Temp_Hacchuu
   --          (
			--   HacchuuNO
			--  ,HacchuuDate  
			--  ,StaffCD
			--  ,HacchuuDenpyouTekiyou          
			--  ,ShouhinCD
			--  ,ColorRyakuName
			--  ,SizeNO 
			--  --,JANCD           
			--  ,HacchuuTanka    
			--  ,HacchuuSuu
			--  ,SiiresakiCD 
			--  ,SiiresakiRyakuName
			--  ,ChakuniYoteiDate       
			--  ,SoukoCD       
			--  ,SoukoName           
			--  ,SiiresakiName
			--  ,SiiresakiYuubinNO1      
			--  ,SiiresakiYuubinNO2               
			--  ,SiiresakiJuusho1             
			--  ,SiiresakiJuusho2             
			--  ,[SiiresakiTelNO1-1]                
			--  ,[SiiresakiTelNO1-2]               
			--  ,[SiiresakiTelNO1-3]         
			--  ,[SiiresakiTelNO2-1]      
			--  ,[SiiresakiTelNO2-2]       
			--  ,[SiiresakiTelNO2-3]  
			--  ,HacchuuMeisaiTekiyou
			--  ,Operator
			--  ,ProgramID
			--  ,PC
			--  ,Error
			--  ,JuchuuNO
			--  )

			--  SELECT *
			--		FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
			--		WITH
			--		(
			--	  HacchuuNO varchar(200) 'HacchuuNO',
			--	  HacchuuDate  varchar(200) 'JuchuuDate',
			--	  StaffCD varchar(200) 'StaffCD',
			--	  HacchuuDenpyouTekiyou varchar(200)  'HacchuuDenpyouTekiyou',
			--	  ShouhinCD varchar(200) 'ShouhinCD',
			--	  ColorRyakuName varchar(200) 'ColorRyakuName',
			--	  SizeNO varchar(200) 'SizeNO',
			--	  --JANCD	varchar(200) 'JANCD',
			--	  HacchuuTanka varchar(200) 'HacchuuTanka',
			--	  HacchuuSuu varchar(200) 'HacchuuSuu',
			--	  SiiresakiCD varchar(200) 'SiiresakiCD',
			--	  SiiresakiRyakuName varchar(200) 'SiiresakiRyakuName',
			--	  ChakuniYoteiDate  varchar(200) 'ChakuniYoteiDate',
			--	  SoukoCD varchar(200)  'SoukoCD',
			--	  SoukoName varchar(200) 'SoukoName',
			--	  SiiresakiName varchar(200) 'SiiresakiName',
			--	  SiiresakiYuubinNO1 varchar(200) 'SiiresakiYuubinNO1',
			--	  SiiresakiYuubinNO2 varchar(200) 'SiiresakiYuubinNO2',
			--	  SiiresakiJuusho1 varchar(200) 'SiiresakiJuusho1',
			--	  SiiresakiJuusho2 varchar(200) 'SiiresakiJuusho2',
			--	  [SiiresakiTelNO1-1] varchar(200) 'SiiresakiTelNO11',
			--	  [SiiresakiTelNO1-2] varchar(200) 'SiiresakiTelNO12',
			--	  [SiiresakiTelNO1-3] varchar(200) 'SiiresakiTelNO13',
			--	  [SiiresakiTelNO2-1]  varchar(200) 'SiiresakiTelNO21',
			--	  [SiiresakiTelNO2-2] varchar(200) 'SiiresakiTelNO22',
			--	  [SiiresakiTelNO2-3] varchar(200) 'SiiresakiTelNO23',
			--	  HacchuuMeisaiTekiyou varchar(200) 'JuchuuMeisaiTekiyou',
			--	  Operator varchar(200) 'Operator',
			--	  ProgramID	 varchar(200) 'ProgramID',
			--	  PC varchar(200) 'PC',
			--	  Error	varchar(200) 'Error',
			--	  JuchuuNO varchar(200) 'JuchuuNO'
			--	)
			--EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust
			--2021/07/07 Y.Nishikawa DEL Remake↑↑
				CREATE TABLE #Temp_Juchuu
						(  
						  SEQ	int IDENTITY(1,1),
						  JuchuuNO  varchar(200) COLLATE DATABASE_DEFAULT,
						  --2021/07/07 Y.Nishikawa ADD Remake↓↓
						  JuchuuGyouNO smallint,
						  HacchuuNO  varchar(200) COLLATE DATABASE_DEFAULT,
						  HacchuuGyouNO smallint,
						  --2021/07/07 Y.Nishikawa ADD Remake↑↑
						  JuchuuDate varchar(200) COLLATE DATABASE_DEFAULT,
						  TokuisakiCD varchar(200) COLLATE DATABASE_DEFAULT,
						  TokuisakiRyakuName varchar(200) COLLATE DATABASE_DEFAULT,
						  KouritenCD varchar(200) COLLATE DATABASE_DEFAULT,
						  KouritenRyakuName varchar(200) COLLATE DATABASE_DEFAULT,
						  StaffCD varchar(200) COLLATE DATABASE_DEFAULT,
						  SenpouHacchuuNO varchar(200) COLLATE DATABASE_DEFAULT,
						  SenpouBusho varchar(200) COLLATE DATABASE_DEFAULT,
						  KibouNouki varchar(200)COLLATE DATABASE_DEFAULT,--date
						  HacchuuDenpyouTekiyou varchar(200) COLLATE DATABASE_DEFAULT,
						  ShouhinCD varchar(200) COLLATE DATABASE_DEFAULT,
						  ColorRyakuName varchar(200)COLLATE DATABASE_DEFAULT,
						  SizeNO varchar(200) COLLATE DATABASE_DEFAULT,
						  --JANCD varchar(200) COLLATE DATABASE_DEFAULT,
						  HacchuuSuu varchar(200) COLLATE DATABASE_DEFAULT, 
						  HacchuuTanka varchar(200) COLLATE DATABASE_DEFAULT,
						  UriageTanka varchar(200) COLLATE DATABASE_DEFAULT,
						  JuchuuDenpyouTekiyou varchar(200) COLLATE DATABASE_DEFAULT,
						  --2021/07/07 Y.Nishikawa ADD Remake↓↓
						  JuchuuMeisaiTekiyou varchar(200) COLLATE DATABASE_DEFAULT,
						  --2021/07/07 Y.Nishikawa ADD Remake↑↑
						  SiiresakiCD varchar(200) COLLATE DATABASE_DEFAULT,
						  SiiresakiRyakuName varchar(200) COLLATE DATABASE_DEFAULT,
						  ChakuniYoteiDate varchar(200) COLLATE DATABASE_DEFAULT,
						  SoukoCD varchar(200) COLLATE DATABASE_DEFAULT,
						  SoukoName varchar(200) COLLATE DATABASE_DEFAULT,
						  TokuisakiName varchar(200) COLLATE DATABASE_DEFAULT,
						  TokuisakiYuubinNO1 varchar(200)COLLATE DATABASE_DEFAULT,
						  TokuisakiYuubinNO2 varchar(200) COLLATE DATABASE_DEFAULT,
						  TokuisakiJuusho1 varchar(200) COLLATE DATABASE_DEFAULT,
						  TokuisakiJuusho2 varchar(200) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-1] varchar(200) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-2] varchar(200) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-3] varchar(200) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-1]  varchar(200) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-2] varchar(200) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-3] varchar(200) COLLATE DATABASE_DEFAULT,
						  KouritenName varchar(200) COLLATE DATABASE_DEFAULT,
						  KouritenYuubinNO1 varchar(200)COLLATE DATABASE_DEFAULT,
						  KouritenYuubinNO2 varchar(200) COLLATE DATABASE_DEFAULT,
						  KouritenJuusho1 varchar(200) COLLATE DATABASE_DEFAULT,
						  KouritenJuusho2 varchar(200) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-1] varchar(200) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-2] varchar(200) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-3] varchar(200) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-1]  varchar(200) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-2] varchar(200) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-3] varchar(200) COLLATE DATABASE_DEFAULT,
						  SiiresakiName varchar(200) COLLATE DATABASE_DEFAULT,
						  SiiresakiYuubinNO1 varchar(200)COLLATE DATABASE_DEFAULT,
						  SiiresakiYuubinNO2 varchar(200) COLLATE DATABASE_DEFAULT,
						  SiiresakiJuusho1 varchar(200) COLLATE DATABASE_DEFAULT,
						  SiiresakiJuusho2 varchar(200) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO1-1] varchar(200) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO1-2] varchar(200) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO1-3] varchar(200) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO2-1]  varchar(200) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO2-2] varchar(200) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO2-3] varchar(200) COLLATE DATABASE_DEFAULT,
						  HacchuuMeisaiTekiyou  varchar(200) COLLATE DATABASE_DEFAULT,
						  Operator varchar(200) COLLATE DATABASE_DEFAULT,
						  ProgramID	 varchar(200) COLLATE DATABASE_DEFAULT,
						  PC varchar(200) COLLATE DATABASE_DEFAULT,
						  Error1	varchar(200),
						  Error2 varchar(200),
						  ErrorFlg	BIT default 'FALSE'
						)
						EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Jucchuu

						INSERT INTO #Temp_Juchuu
				        (
					      JuchuuNO,
						  JuchuuDate,
						  TokuisakiCD,
						  TokuisakiRyakuName,
						  KouritenCD,
						  KouritenRyakuName,
						  StaffCD,
						  SenpouHacchuuNO,
						  SenpouBusho,
						  KibouNouki,
						  HacchuuDenpyouTekiyou,
						  ShouhinCD,
						  ColorRyakuName,
						  SizeNO,
						  --JANCD,
						  HacchuuSuu,
						  HacchuuTanka,
						  UriageTanka,
						  JuchuuDenpyouTekiyou,
						  --2021/07/07 Y.Nishikawa ADD Remake↓↓
						  JuchuuMeisaiTekiyou,
						  --2021/07/07 Y.Nishikawa ADD Remake↑↑
						  SiiresakiCD,
						  SiiresakiRyakuName,
						  ChakuniYoteiDate,
						  SoukoCD,
						  SoukoName,
						  TokuisakiName,
						  TokuisakiYuubinNO1,
						  TokuisakiYuubinNO2,
						  TokuisakiJuusho1,
						  TokuisakiJuusho2,
						  [TokuisakiTelNO1-1],
						  [TokuisakiTelNO1-2],
						  [TokuisakiTelNO1-3],
						  [TokuisakiTelNO2-1],
						  [TokuisakiTelNO2-2],
						  [TokuisakiTelNO2-3],
						  KouritenName,
						  KouritenYuubinNO1,
						  KouritenYuubinNO2,
						  KouritenJuusho1,
						  KouritenJuusho2,
						  [KouritenTelNO1-1],
						  [KouritenTelNO1-2],
						  [KouritenTelNO1-3],
						  [KouritenTelNO2-1],
						  [KouritenTelNO2-2],
						  [KouritenTelNO2-3],
						  SiiresakiName,
						  SiiresakiYuubinNO1,
						  SiiresakiYuubinNO2,
						  SiiresakiJuusho1,
						  SiiresakiJuusho2,
						  [SiiresakiTelNO1-1],
						  [SiiresakiTelNO1-2],
						  [SiiresakiTelNO1-3],
						  [SiiresakiTelNO2-1],
						  [SiiresakiTelNO2-2],
						  [SiiresakiTelNO2-3],
						  HacchuuMeisaiTekiyou,
						  Operator,
						  ProgramID,
						  PC
						  --,
						  --Error1
					  )

					    SELECT *
							FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
							WITH
							(
						  JuchuuNO  varchar(200) 'JuchuuNO',
						  JuchuuDate varchar(200) 'JuchuuDate',
						  TokuisakiCD varchar(200) 'TokuisakiCD',
						  TokuisakiRyakuName varchar(200) 'TokuisakiRyakuName',
						  KouritenCD varchar(200) 'KouritenCD',
						  KouritenRyakuName varchar(200) 'KouritenRyakuName',
						  StaffCD varchar(200) 'StaffCD',
						  SenpouHacchuuNO varchar(200) 'SenpouHacchuuNO',
						  SenpouBusho varchar(200) 'SenpouBusho',
						  KibouNouki varchar(200) 'KibouNouki',
						  HacchuuDenpyouTekiyou varchar(200) 'HacchuuDenpyouTekiyou',
						  ShouhinCD varchar(200) 'ShouhinCD',
						  ColorRyakuName varchar(200) 'ColorRyakuName',
						  SizeNO varchar(200) 'SizeNO',
						  --JANCD varchar(200) 'JANCD',
						  HacchuuSuu varchar(200) 'HacchuuSuu',
						  HacchuuTanka varchar(200) 'HacchuuTanka',
						  UriageTanka varchar(200) 'UriageTanka',
						  JuchuuDenpyouTekiyou varchar(200) 'HacchuuDenpyouTekiyou',
						  --2021/07/07 Y.Nishikawa ADD Remake↓↓
						  JuchuuMeisaiTekiyou varchar(200) 'JuchuuMeisaiTekiyou',
						  --2021/07/07 Y.Nishikawa ADD Remake↑↑
						  SiiresakiCD varchar(200) 'SiiresakiCD',
						  SiiresakiRyakuName varchar(200) 'SiiresakiRyakuName',
						  ChakuniYoteiDate varchar(200) 'ChakuniYoteiDate',
						  SoukoCD varchar(200) 'SoukoCD',
						  SoukoName varchar(200) 'SoukoName',
						  TokuisakiName varchar(200) 'TokuisakiuName',
						  TokuisakiYuubinNO1 varchar(200) 'TokuisakiYuubinNO1',
						  TokuisakiYuubinNO2 varchar(200) 'TokuisakiYuubinNO2',
						  TokuisakiJuusho1 varchar(200) 'TokuisakiJuusho1',
						  TokuisakiJuusho2 varchar(200) 'TokuisakiJuusho2',
						  [TokuisakiTelNO1-1] varchar(200) 'TokuisakiTelNO1-1',
						  [TokuisakiTelNO1-2] varchar(200) 'TokuisakiTelNO1-2',
						  [TokuisakiTelNO1-3] varchar(200) 'TokuisakiTelNO1-3',
						  [TokuisakiTelNO2-1]  varchar(200) 'TokuisakiTelNO2-1',
						  [TokuisakiTelNO2-2] varchar(200) 'TokuisakiTelNO2-2',
						  [TokuisakiTelNO2-3] varchar(200) 'TokuisakiTelNO2-3',
						  KouritenName varchar(200) 'KouritenName',
						  KouritenYuubinNO1 varchar(200) 'KouritenYuubinNO1',
						  KouritenYuubinNO2 varchar(200) 'KouritenYuubinNO2',
						  KouritenJuusho1 varchar(200) 'KouritenJuusho1',
						  KouritenJuusho2 varchar(200) 'KouritenJuusho2',
						  [KouritenTelNO1-1] varchar(200) 'KouritenTelNO1-1',
						  [KouritenTelNO1-2] varchar(200) 'KouritenTelNO1-2',
						  [KouritenTelNO1-3] varchar(200) 'KouritenTelNO1-3',
						  [KouritenTelNO2-1]  varchar(200) 'KouritenTelNO2-1',
						  [KouritenTelNO2-2] varchar(200) 'KouritenTelNO2-2',
						  [KouritenTelNO2-3] varchar(200) 'KouritenTelNO2-3',
						  SiiresakiName varchar(200) 'SiiresakiName',
						  SiiresakiYuubinNO1 varchar(200) 'SiiresakiYuubinNO1',
						  SiiresakiYuubinNO2 varchar(200) 'SiiresakiYuubinNO2',
						  SiiresakiJuusho1 varchar(200) 'SiiresakiJuusho1',
						  SiiresakiJuusho2 varchar(200) 'SiiresakiJuusho2',
						  [SiiresakiTelNO1-1] varchar(200) 'SiiresakiTelNO1-1',
						  [SiiresakiTelNO1-2] varchar(200) 'SiiresakiTelNO1-2',
						  [SiiresakiTelNO1-3] varchar(200) 'SiiresakiTelNO1-3',
						  [SiiresakiTelNO2-1]  varchar(200) 'SiiresakiTelNO2-1',
						  [SiiresakiTelNO2-2] varchar(200) 'SiiresakiTelNO2-2',
						  [SiiresakiTelNO2-3] varchar(200) 'SiiresakiTelNO2-3',
						  HacchuuMeisaiTekiyou  varchar(200) 'JuchuuMeisaiTekiyou',
						  Operator varchar(200) 'Operator',
						  ProgramID	 varchar(200) 'ProgramID',
						  PC varchar(200) 'PC'
						  --,
						  --Error1	varchar(100) 'Error'
						)
				EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

			    --2021/07/07 Y.Nishikawa DEL Remake↓↓
				--DECLARE @fun_table TABLE (idx int Primary Key IDENTITY(1,1), HacchuuDate date,StaffCD varchar(10),ShouhinCD varchar(50),SoukoCD varchar(10),SiiresakiCD varchar(13),TokuisakiCD varchar(10),KouritenCD varchar(10),JuchuuNO  varchar(12))
				--INSERT @fun_table SELECT distinct TH.HacchuuDate,TH.StaffCD,TH.ShouhinCD,TH.SoukoCD,TH.SiiresakiCD,TJ.TokuisakiCD,TJ.KouritenCD,TJ.JuchuuNO FROM #Temp_Hacchuu TH inner join #Temp_Juchuu TJ on TH.JuchuuNO=TJ.JuchuuNO
				--declare @s_Count as int =(SELECT COUNT(*) FROM @fun_table)
				--declare @i_Count as int = 0
				--declare @JuchuuNO as varchar(12)
				--declare @StaffCD as varchar(10)
				--declare @ShouhinCD as varchar(50)
				--declare @SoukoCD as varchar(10)
				--declare @SiiresakiCD as varchar(13)
				--declare @ToukisakiCD as varchar(10)
				--declare @KouritenCD as varchar(10)
				----Declare @Operator as varchar(10)
				----declare @ProgramID as varchar(100)
				----declare @PC as varchar(30)
				--declare @slip_Date as date
				
				--WHILE @i_Count < @s_Count
				--BEGIN
				--   set @StaffCD = (SELECT StaffCD FROM @fun_table WHERE idx = (@i_Count+1))
				--   set @ShouhinCD = (SELECT ShouhinCD FROM @fun_table WHERE idx = (@i_Count+1))
				--   set @SoukoCD=(SELECT SoukoCD FROM @fun_table WHERE idx = (@i_Count+1))
				--   set @SiiresakiCD=(SELECT SiiresakiCD FROM @fun_table WHERE idx = (@i_Count+1))
				--   set @ToukisakiCD=(SELECT TokuisakiCD FROM @fun_table WHERE idx = (@i_Count+1))
				--   set @KouritenCD=(SELECT KouritenCD FROM @fun_table WHERE idx = (@i_Count+1))
				--   --set @Operator=(SELECT Operator FROM @fun_table WHERE idx = (@i_Count+1))
				--   --set @ProgramID=(SELECT ProgramID FROM @fun_table WHERE idx = (@i_Count+1))
				--   --set @PC =(SELECT PC FROM @fun_table WHERE idx = (@i_Count+1))
				--   set @JuchuuNO =(SELECT JuchuuNO FROM @fun_table WHERE idx = (@i_Count+1))
				--   set @slip_Date=(Select HacchuuDate from @fun_table WHERE idx = (@i_Count+1))
				--   SET @i_Count = @i_Count + 1
				--END;
				--2021/07/07 Y.Nishikawa DEL Remake↑↑

		--2021/07/07 Y.Nishikawa CHG Remake↓↓
		--Declare @Operator as varchar(10)=(select top 1 Operator from #Temp_Hacchuu)
		--Declare @ProgramID as varchar(100)=(select top 1 ProgramID from #Temp_Hacchuu)
		--Declare @PC as varchar(30)=(select top 1 PC from  #Temp_Hacchuu)
		Declare @Operator as varchar(10)=(select top 1 Operator from #Temp_Juchuu)
		Declare @ProgramID as varchar(100)=(select top 1 ProgramID from #Temp_Juchuu)
		Declare @PC as varchar(30)=(select top 1 PC from  #Temp_Juchuu)
		--2021/07/07 Y.Nishikawa CHG Remake↑↑
		IF @type = 'ErrorCheck'
		BEGIN
			--Null error check
			update #Temp_Juchuu
			set ErrorFlg = 1,
				Error1 = case when isnull(ltrim(rtrim(JuchuuDate)),'') = '' then '受注日未入力エラー'
							when isnull(ltrim(rtrim(TokuisakiCD)),'') = '' then '得意先CD未入力エラー' 
							when isnull(ltrim(rtrim(KouritenCD)),'') = '' then '小売店CD未入力エラー' 
							when isnull(ltrim(rtrim(StaffCD)),'') = '' then '担当スタッフCD未入力エラー' 
							when isnull(ltrim(rtrim(ShouhinCD)),'') = '' then '商品CD未入力エラー' 
							when isnull(ltrim(rtrim(ColorRyakuName)),'') = '' then 'カラー未入力エラー' 
							when isnull(ltrim(rtrim(SizeNO)),'') = '' then 'サイズ未入力エラー' 
							--when isnull(ltrim(rtrim(JANCD)),'') = '' then 'JANCD未入力エラー' 
							when isnull(ltrim(rtrim(HacchuuSuu)),'') = '' then '数量未入力エラー' 
							when isnull(ltrim(rtrim(SoukoCD)),'') = '' then '倉庫CD未入力エラー' 
							end
			where isnull(ltrim(rtrim(JuchuuDate)),'') = ''
			or isnull(ltrim(rtrim(TokuisakiCD)),'') = ''
			or isnull(ltrim(rtrim(KouritenCD)),'') = ''
			or isnull(ltrim(rtrim(StaffCD)),'') = ''
			or isnull(ltrim(rtrim(ShouhinCD)),'') = ''
			or isnull(ltrim(rtrim(ColorRyakuName)),'') = ''
			or isnull(ltrim(rtrim(SizeNO)),'') = ''
			--or isnull(ltrim(rtrim(JANCD)),'') = ''
			or isnull(ltrim(rtrim(HacchuuSuu)),'') = ''
			or isnull(ltrim(rtrim(SoukoCD)),'') = ''
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--if exists(select * from #Temp_Juchuu  where SiiresakiCD is not null)
			--begin
			--	update #Temp_Juchuu
			--	set ErrorFlg = 1,
			--	Error1 =case 						
			--			when  isnull(ltrim(rtrim(ChakuniYoteiDate)),'') = '' then '着荷予定日未入力エラー' 
			--			end
			--	where isnull(ltrim(rtrim(ChakuniYoteiDate)),'') = ''
			--	and SiiresakiCD is not null
			--end

			--Task NO 493 chg 2021-06-16
            update #Temp_Juchuu
                set ErrorFlg = 1,
                Error1 =case                        
                        when  isnull(ltrim(rtrim(ChakuniYoteiDate)),'') = '' then '着荷予定日未入力エラー' 
                        end
                where SiiresakiCD is not null
                and isnull(ltrim(rtrim(ChakuniYoteiDate)),'') = ''

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--Length Check
			update #Temp_Juchuu
			set ErrorFlg = 1,
				Error1 = case when datalength(TokuisakiCD) > 10 then '得意先CD桁数エラー'
							  when datalength(KouritenCD) > 10 then '小売店CD桁数エラー'
							  when datalength(StaffCD) > 10 then '担当スタッフCD桁数エラー'
							  when datalength(ShouhinCD) > 20 then '商品CD桁数エラー'
							  --when datalength(JANCD) > 13 then 'JANCD桁数エラー'
							  when datalength(ColorRyakuName) > 20 then 'カラー桁数エラー'--for task no 485
							  when datalength(SizeNO) > 20 then 'サイズ桁数エラー'--for task no 485
							  when datalength(SenpouHacchuuNO)> 20 then '先方発注番号桁数エラー'
							  when datalength(SoukoCD) > 10 then '倉庫CD桁数エラー'
							end
			from #Temp_Juchuu
			where datalength(TokuisakiCD) > 10
			or datalength(KouritenCD) > 10
			or datalength(StaffCD) > 10
			or datalength(ShouhinCD) > 20
			--or datalength(JANCD) > 13
			or datalength(ColorRyakuName) > 20--for task no 485
			or datalength(SizeNO) > 20--for task no 485
			or datalength(SenpouHacchuuNO) > 20
			or datalength(SoukoCD) > 10

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			if exists(select * from #Temp_Juchuu   where SiiresakiCD is not null)
			begin
				update #Temp_Juchuu
				set ErrorFlg = 1,
				Error1 =case 						
						when   datalength(SiiresakiCD) > 10 then '仕入先CD桁数エラー' 
						end
				where  datalength(SiiresakiCD) > 10
				and SiiresakiCD is not null
			end

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end
				
			----Input Value Check	
			update #Temp_Juchuu	
			set ErrorFlg = 1,	
				Error1 = '入力可能値外エラー',	
				Error2 = case 	
				            when isdate(JuchuuDate) = 0 then '項目:受注日'	
							  when isdate(isnull(nullif(ltrim(rtrim(KibouNouki)),''),'2100-01-01')) = 0 then '項目:希望納期'	
							  when isdate(isnull(nullif(ltrim(rtrim(ChakuniYoteiDate)),''),'2100-01-01')) = 0 then '項目:着荷予定日'	
							  when isnumeric(HacchuuSuu) = 0 then '項目:数量'	
							  when isnumeric(HacchuuTanka) = 0 then '項目:発注単価'--2021/05/26 ssa CHG TaskNO 499	
							  when isnumeric(UriageTanka) = 0 then '項目:受注単価'	
						end 	
			where 	
			isdate(JuchuuDate) = 0	
			or isdate(isnull(nullif(ltrim(rtrim(KibouNouki)),''),'2100-01-01')) = 0	
			or isdate(isnull(nullif(ltrim(rtrim(ChakuniYoteiDate)),''),'2100-01-01')) = 0	
			or isnumeric(HacchuuSuu) = 0	
			or isnumeric(HacchuuTanka) = 0--2021/05/26 ssa CHG TaskNO 499	
			or isnumeric(UriageTanka) = 0
		
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--Master Check
			update tmp
			set ErrorFlg = 1, Error1 = '得意先CD未登録エラー'
			from #Temp_Juchuu tmp
			where not exists (select t.TokuisakiCD from F_Tokuisaki(getdate()) t where t.TokuisakiCD = tmp.TokuisakiCD)
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--ShokutiFLG for M_Tokuisaki
			if exists(select * from F_Tokuisaki(getdate()) f inner join #Temp_Juchuu tj on tj.TokuisakiCD=f.TokuisakiCD where f.ShokutiFLG=1)
				begin
				--Null error check
				update #Temp_Juchuu
				set ErrorFlg = 1,
				Error1 =case 
						when isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = '' then '得意先略名未入力エラー' 	
						when isnull(ltrim(rtrim(TokuisakiName)),'') = '' then '得意先名未入力エラー' 	
						end

						where (isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = ''
						or isnull(ltrim(rtrim(TokuisakiName)),'') = '')
						and exists(select * from F_Tokuisaki(getdate()) f where #Temp_Juchuu.TokuisakiCD=f.TokuisakiCD and f.ShokutiFLG=1)

				--Length Check
				update #Temp_Juchuu
				set ErrorFlg = 1,
					Error1 = case when datalength(TokuisakiRyakuName) > 40 then '得意先略名桁数エラー'
								  when datalength(TokuisakiName) > 80 then '得意先名桁数エラー'
								end
				from #Temp_Juchuu
				where datalength(TokuisakiRyakuName) > 40
				or datalength(TokuisakiName) > 80				
				end

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
				begin
					goto error
				end

				
			update tmp
			set ErrorFlg = 1, Error1 = '小売店CD未登録エラー'			
			from #Temp_Juchuu tmp
			where not exists (select k.KouritenCD from F_Kouriten(getdate()) k where k.KouritenCD = tmp.KouritenCD)
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--Task NO-455 chg 2021_06_16
			--ShokutiFLG for M_Kouriten
			if exists(select * from F_Kouriten(getdate()) f inner join #Temp_Juchuu tj on tj.KouritenCD=f.KouritenCD where f.ShokutiFLG=1)
				begin

				--Null error check
				update #Temp_Juchuu
				set ErrorFlg = 1,
				Error1 =case 
						when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '小売店略名未入力エラー' 	
						when isnull(ltrim(rtrim(KouritenName)),'') = '' then '小売店名未入力エラー' 	
						end

						where (isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''
						or isnull(ltrim(rtrim(KouritenName)),'') = '')
						and exists(select * from F_Kouriten(getdate()) f where #Temp_Juchuu.KouritenCD=f.KouritenCD and f.ShokutiFLG=1)

				--Length Check
				update #Temp_Juchuu
				set ErrorFlg = 1,
					Error1 = case when datalength(KouritenRyakuName) > 40 then '小売店略名桁数エラー'
								  when datalength(KouritenName) > 80 then '小売店名桁数エラー'
								end
				from #Temp_Juchuu
				where datalength(KouritenRyakuName) > 40
				or datalength(KouritenName) > 80				
				end

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
				begin
					goto error
				end

			
			update tmp
			set ErrorFlg = 1, Error1 = '担当スタッフCD未登録エラー'			
			from #Temp_Juchuu tmp
			where not exists (select k.StaffCD from F_Staff(getdate()) k where k.StaffCD = tmp.StaffCD)
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--for task 486
			update tmp
			set ErrorFlg=1,Error1='カラー未登録エラー'
			from #Temp_Juchuu tmp
			where not exists(select * from M_MultiPorpose mp where mp.ID='104' and mp.[KEY]=tmp.ColorRyakuName)

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			update tmp
			set ErrorFlg=1,Error1='サイズ未登録エラー'
			from #Temp_Juchuu tmp
			where not exists(select * from M_MultiPorpose mp where mp.ID='105' and mp.[KEY]=tmp.SizeNO)

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			----task no 486,tmp.ShouhinCD+tmp.ColorRyakuName+tmp.SizeNO condition added
			update tmp
			set ErrorFlg = 1, Error1 = '商品CD未登録エラー'
			from #Temp_Juchuu tmp
			where not exists (select h.ShouhinCD from F_Shouhin(getdate()) h where h.ShouhinCD = tmp.ShouhinCD+tmp.ColorRyakuName+tmp.SizeNO)
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

--			update tmp
--			set ErrorFlg = 1, Error1= 'JANCD未登録エラー'
--			from #Temp_Juchuu tmp
--			where not exists (select j.JANCD from F_Shouhin(getdate()) j where j.JANCD = tmp.JANCD)
--			
--			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
--			begin
--				goto error
--			end

			
			update tmp
			set ErrorFlg = 1, Error1= '仕入先CD未登録エラー'
			from #Temp_Juchuu tmp
			where not exists (select j.SiiresakiCD from F_Siiresaki(getdate()) j where j.SiiresakiCD = tmp.SiiresakiCD)
			and SiiresakiCD is not null
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--ShokutiFLG for M_Siiresaki
			if exists(select * from F_Siiresaki(getdate()) f inner join #Temp_Juchuu tj on tj.SiiresakiCD=f.SiiresakiCD where f.ShokutiFLG=1)
				begin

				--Null error check
				update #Temp_Juchuu
				set ErrorFlg = 1,
				Error1 =case 
						when isnull(ltrim(rtrim(SiiresakiRyakuName)),'') = '' then '仕入先略名未入力エラー' 	
						when isnull(ltrim(rtrim(SiiresakiName)),'') = '' then '仕入先名未入力エラー' 	
						end

						where (isnull(ltrim(rtrim(SiiresakiRyakuName)),'') = ''
						or isnull(ltrim(rtrim(SiiresakiName)),'') = '')
						and SiiresakiCD is not null
						and exists(select * from F_Siiresaki(getdate()) f where #Temp_Juchuu.SiiresakiCD=f.SiiresakiCD and f.ShokutiFLG=1)

				--Length Check
				update #Temp_Juchuu
				set ErrorFlg = 1,
					Error1 = case when datalength(SiiresakiRyakuName) > 40 then '仕入先略名桁数エラー'
								  when datalength(SiiresakiName) > 80 then '仕入先名桁数エラー'
								end
				from #Temp_Juchuu
				where datalength(SiiresakiRyakuName) > 40
				or datalength(SiiresakiName) > 80				
				end

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
				begin
					goto error
				end

			--2021/07/12 Y.Nishikawa Add↓↓
			--同一伝票内で商品重複チェック
			update tmp
			set ErrorFlg = 1, Error1 = '商品CD重複エラー'
			from #Temp_Juchuu tmp
			INNER JOIN (
			SELECT JuchuuDate 
		          ,TokuisakiCD
		 	      ,TokuisakiRyakuName
				  ,TokuisakiName
				  ,KouritenCD
				  ,KouritenRyakuName
				  ,KouritenName
				  ,StaffCD
				  ,SenpouHacchuuNO
				  ,SenpouBusho
				  ,KibouNouki
				  ,JuchuuDenpyouTekiyou
				  ,SiiresakiCD
				  ,ShouhinCD
				  ,ColorRyakuName
				  ,SizeNO
            FROM #Temp_Juchuu
			GROUP BY JuchuuDate 
		            ,TokuisakiCD
		 	        ,TokuisakiRyakuName
				    ,TokuisakiName
				    ,KouritenCD
				    ,KouritenRyakuName
				    ,KouritenName
				    ,StaffCD
				    ,SenpouHacchuuNO
				    ,SenpouBusho
				    ,KibouNouki
				    ,JuchuuDenpyouTekiyou
				    ,SiiresakiCD
					,ShouhinCD
					,ColorRyakuName
					,SizeNO
			Having COUNT(ShouhinCD+ColorRyakuName+SizeNO) > 1
			) sub
            on 	ISNULL(tmp.JuchuuDate , '')	 = 	ISNULL(sub.JuchuuDate , '')
            and ISNULL(tmp.TokuisakiCD, '')	 = 	ISNULL(sub.TokuisakiCD, '')
            and ISNULL(tmp.TokuisakiRyakuName, '')	 = 	ISNULL(sub.TokuisakiRyakuName, '')
            and ISNULL(tmp.TokuisakiName, '')	 = 	ISNULL(sub.TokuisakiName, '')
            and ISNULL(tmp.KouritenCD, '')	 = 	ISNULL(sub.KouritenCD, '')
            and ISNULL(tmp.KouritenRyakuName, '')	 = 	ISNULL(sub.KouritenRyakuName, '')
            and ISNULL(tmp.KouritenName, '')	 = 	ISNULL(sub.KouritenName, '')
            and ISNULL(tmp.StaffCD, '')	 = 	ISNULL(sub.StaffCD, '')
            and ISNULL(tmp.SenpouHacchuuNO, '')	 = 	ISNULL(sub.SenpouHacchuuNO, '')
            and ISNULL(tmp.SenpouBusho, '')	 = 	ISNULL(sub.SenpouBusho, '')
            and ISNULL(tmp.KibouNouki, '')	 = 	ISNULL(sub.KibouNouki, '')
            and ISNULL(tmp.JuchuuDenpyouTekiyou, '')	 = 	ISNULL(sub.JuchuuDenpyouTekiyou, '')
            and ISNULL(tmp.SiiresakiCD, '')	 = 	ISNULL(sub.SiiresakiCD, '')
            and ISNULL(tmp.ShouhinCD, '')	 = 	ISNULL(sub.ShouhinCD, '')
            and ISNULL(tmp.ColorRyakuName, '')	 = 	ISNULL(sub.ColorRyakuName, '')
            and ISNULL(tmp.SizeNO, '')	 = 	ISNULL(sub.SizeNO, '')

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end
			--2021/07/12 Y.Nishikawa Add↑↑

			update tmp
			set ErrorFlg = 1, Error1= '倉庫CD未登録エラー'
			from #Temp_Juchuu tmp
			where not exists (select ms.SoukoCD from M_Souko ms  where ms.SoukoCD = tmp.SoukoCD)

            if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end
			else
			begin
				goto process
			end
						
			error:
			begin
				select top 1 '0' as Result,SEQ,Error1,Error2 from #Temp_Juchuu where ErrorFlg = 1
				--DROP TABLE #Temp_Hacchuu
				--DROP TABLE #Temp_Juchuu
				return
			end

			Goto process

			process:
			begin			
				select '1' as Result
				--Drop table #Temp_Hacchuu
				--Drop table #Temp_Juchuu
			END
		END

		ELSE
		BEGIN
		    --2021/07/07 Y.Nishikawa ADD Remake↓↓
			UPDATE #Temp_Juchuu
			SET JuchuuNO = NULL
			   ,JuchuuGyouNO = 0
			   ,HacchuuNO = NULL
			   ,HacchuuGyouNO = 0

			DECLARE @JuchuuNO varchar(12),
		    @JuchuuGyouNO smallint = 0,
			@HacchuuNO varchar(12),
			@HacchuuGyouNO smallint = 0,
		    @JuchuuDate varchar(10),
			@TokuisakiCD varchar(10),
			@TokuisakiRyakuName varchar(40),
			@TokuisakiName varchar(80),
			@KouritenCD varchar(10),
			@KouritenRyakuName varchar(40),
			@KouritenName varchar(80),
		    @StaffCD varchar(10),
			@SenpouHacchuuNO varchar(20),
			@SenpouBusho varchar(20),
			@KibouNouki varchar(10),
			@JuchuuDenpyouTekiyou varchar(80),
			@SiiresakiCD varchar(10),

			@Before_JuchuuNO varchar(12),
		    @Before_JuchuuGyouNO smallint = 0,
			@Before_HacchuuNO varchar(12),
			@Before_HacchuuGyouNO smallint = 0,
		    @Before_JuchuuDate varchar(10),
			@Before_TokuisakiCD varchar(10),
			@Before_TokuisakiRyakuName varchar(40),
			@Before_TokuisakiName varchar(80),
			@Before_KouritenCD varchar(10),
			@Before_KouritenRyakuName varchar(40),
			@Before_KouritenName varchar(80),
		    @Before_StaffCD varchar(10),
			@Before_SenpouHacchuuNO varchar(20),
			@Before_SenpouBusho varchar(20),
			@Before_KibouNouki varchar(10),
			@Before_JuchuuDenpyouTekiyou varchar(80),
			@Before_SiiresakiCD varchar(10)

			declare @Prefix1 as varchar(4)
	        declare @Prefix2 as varchar(4) 
	        declare @Counter as int
			declare @tempCounter as varchar(100)
	        declare @outNO as varchar(100)

                  
            DECLARE cursorJuchuu CURSOR READ_ONLY
            FOR
            SELECT JuchuuDate 
		          ,TokuisakiCD
		 	      ,TokuisakiRyakuName
				  ,TokuisakiName
				  ,KouritenCD
				  ,KouritenRyakuName
				  ,KouritenName
				  ,StaffCD
				  ,SenpouHacchuuNO
				  ,SenpouBusho
				  ,KibouNouki
				  ,JuchuuDenpyouTekiyou
				  ,SiiresakiCD
            FROM #Temp_Juchuu
			GROUP BY JuchuuDate 
		            ,TokuisakiCD
		 	        ,TokuisakiRyakuName
				    ,TokuisakiName
				    ,KouritenCD
				    ,KouritenRyakuName
				    ,KouritenName
				    ,StaffCD
				    ,SenpouHacchuuNO
				    ,SenpouBusho
				    ,KibouNouki
				    ,JuchuuDenpyouTekiyou
				    ,SiiresakiCD
		    ORDER BY 
			       JuchuuDate ASC
		          ,TokuisakiCD ASC
		 	      ,TokuisakiRyakuName ASC
				  ,TokuisakiName ASC
				  ,KouritenCD ASC
				  ,KouritenRyakuName ASC
				  ,KouritenName ASC
				  ,StaffCD ASC
				  ,SenpouHacchuuNO ASC
				  ,SenpouBusho ASC
				  ,KibouNouki ASC
				  ,JuchuuDenpyouTekiyou ASC
				  ,SiiresakiCD ASC

            OPEN cursorJuchuu
                   
            FETCH NEXT FROM cursorJuchuu INTO @JuchuuDate, @TokuisakiCD, @TokuisakiRyakuName, @TokuisakiName, @KouritenCD, @KouritenRyakuName, @KouritenName, @StaffCD, @SenpouHacchuuNO, @SenpouBusho, @KibouNouki, @JuchuuDenpyouTekiyou, @SiiresakiCD
            WHILE @@FETCH_STATUS = 0
            BEGIN
			    IF(
				   ISNULL(@Before_JuchuuDate, '') != ISNULL(@JuchuuDate, '')
                OR ISNULL(@Before_TokuisakiCD, '') != ISNULL(@TokuisakiCD, '')
                OR ISNULL(@Before_TokuisakiRyakuName, '') != ISNULL(@TokuisakiRyakuName, '')
                OR ISNULL(@Before_TokuisakiName, '') != ISNULL(@TokuisakiName, '')
                OR ISNULL(@Before_KouritenCD, '') != ISNULL(@KouritenCD, '')
                OR ISNULL(@Before_KouritenRyakuName, '') != ISNULL(@KouritenRyakuName, '')
                OR ISNULL(@Before_KouritenName, '') != ISNULL(@KouritenName, '')
                OR ISNULL(@Before_StaffCD, '') != ISNULL(@StaffCD, '')
                OR ISNULL(@Before_SenpouHacchuuNO, '') != ISNULL(@SenpouHacchuuNO, '')
                OR ISNULL(@Before_SenpouBusho, '') != ISNULL(@SenpouBusho, '')
                OR ISNULL(@Before_KibouNouki, '') != ISNULL(@KibouNouki, '')
                OR ISNULL(@Before_JuchuuDenpyouTekiyou, '') != ISNULL(@JuchuuDenpyouTekiyou, '')
				  )
				BEGIN
	               
	               set @Prefix1 = (select Settouti from M_DenpyouNO where RenbanKBN = 1 and SEQNO=0)
	               set @Prefix2 = (select CASE WHEN SeqUnit = 1 THEN '' WHEN SeqUnit = 2 THEN CONVERT(varchar(10), FORMAT(Cast(@JuchuuDate as Date), 'yyyy'))  ElSE CONVERT(varchar(10), FORMAT(Cast(@JuchuuDate as Date), 'yyMM')) END as SeqUni from M_Control where MainKey=1)
	               
	               if NOT exists(select * from M_DenpyouNO where RenbanKBN=1 and SEQNO=0)
	               	 begin
	               		---- not exists
	               		INSERT INTO M_DenpyouNO(RenbanKBN,SEQNO,Settouti,[Counter],InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
	               		values(1,0,ISNULL(@Prefix1,'')+ISNULL(@Prefix2,''),0,'Program',GetDate(),NULL,NULL)
	               	 end
	               
	               Update M_DenpyouNO set [Counter]=[Counter]+1,UpdateOperator='Program', UpdateDateTime=GETDATE()
	               where RenbanKBN=1 and SEQNO=0
	               
	               SET @tempCounter = (select [Counter] from M_DenpyouNO where RenbanKBN=1 and SEQNO=0)
	               SET @outNO = ISNULL(@Prefix1,'')+ISNULL(@Prefix2,'')+'000000000000'+@tempCounter   
	               SET @JuchuuNO = LEFT(@outNO,8)+RIGHT(@outNO,4);


				   UPDATE MAIN
				   SET JuchuuNO = @JuchuuNO
				   FROM #Temp_Juchuu MAIN
                   where ISNULL(JuchuuDate, '') = ISNULL(@JuchuuDate, '')
                   AND ISNULL(TokuisakiCD, '') = ISNULL(@TokuisakiCD, '')
                   AND ISNULL(TokuisakiRyakuName, '') = ISNULL(@TokuisakiRyakuName, '')
                   AND ISNULL(TokuisakiName, '') = ISNULL(@TokuisakiName, '')
                   AND ISNULL(KouritenCD, '') = ISNULL(@KouritenCD, '')
                   AND ISNULL(KouritenRyakuName, '') = ISNULL(@KouritenRyakuName, '')
                   AND ISNULL(KouritenName, '') = ISNULL(@KouritenName, '')
                   AND ISNULL(StaffCD, '') = ISNULL(@StaffCD, '')
                   AND ISNULL(SenpouHacchuuNO, '') = ISNULL(@SenpouHacchuuNO, '')
                   AND ISNULL(SenpouBusho, '') = ISNULL(@SenpouBusho, '')
                   AND ISNULL(KibouNouki, '') = ISNULL(@KibouNouki, '')
                   AND ISNULL(JuchuuDenpyouTekiyou, '') = ISNULL(@JuchuuDenpyouTekiyou, '')

				END

				IF(
				      (ISNULL(@Before_JuchuuDate, '') != ISNULL(@JuchuuDate, '')
                    OR ISNULL(@Before_TokuisakiCD, '') != ISNULL(@TokuisakiCD, '')
                    OR ISNULL(@Before_TokuisakiRyakuName, '') != ISNULL(@TokuisakiRyakuName, '')
                    OR ISNULL(@Before_TokuisakiName, '') != ISNULL(@TokuisakiName, '')
                    OR ISNULL(@Before_KouritenCD, '') != ISNULL(@KouritenCD, '')
                    OR ISNULL(@Before_KouritenRyakuName, '') != ISNULL(@KouritenRyakuName, '')
                    OR ISNULL(@Before_KouritenName, '') != ISNULL(@KouritenName, '')
                    OR ISNULL(@Before_StaffCD, '') != ISNULL(@StaffCD, '')
                    OR ISNULL(@Before_SenpouHacchuuNO, '') != ISNULL(@SenpouHacchuuNO, '')
                    OR ISNULL(@Before_SenpouBusho, '') != ISNULL(@SenpouBusho, '')
                    OR ISNULL(@Before_KibouNouki, '') != ISNULL(@KibouNouki, '')
                    OR ISNULL(@Before_JuchuuDenpyouTekiyou, '') != ISNULL(@JuchuuDenpyouTekiyou, '')
				    OR ISNULL(@Before_SiiresakiCD, '') != ISNULL(@SiiresakiCD, ''))
				   AND ISNULL(@SiiresakiCD, '') != ''
				  )
				BEGIN

				   set @Prefix1 = (select Settouti from M_DenpyouNO where RenbanKBN = 2 and SEQNO=0)
	               set @Prefix2 = (select CASE WHEN SeqUnit = 1 THEN '' WHEN SeqUnit = 2 THEN CONVERT(varchar(10), FORMAT(Cast(@JuchuuDate as Date), 'yyyy'))  ElSE CONVERT(varchar(10), FORMAT(Cast(@JuchuuDate as Date), 'yyMM')) END as SeqUni from M_Control where MainKey=1)
	               
	               if NOT exists(select * from M_DenpyouNO where RenbanKBN=2 and SEQNO=0)
	               	 begin
	               		---- not exists
	               		INSERT INTO M_DenpyouNO(RenbanKBN,SEQNO,Settouti,[Counter],InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
	               		values(2,0,ISNULL(@Prefix1,'')+ISNULL(@Prefix2,''),0,'Program',GetDate(),NULL,NULL)
	               	 end
	               
	               Update M_DenpyouNO set [Counter]=[Counter]+1,UpdateOperator='Program', UpdateDateTime=GETDATE()
	               where RenbanKBN=2 and SEQNO=0
	               
	               SET @tempCounter = (select [Counter] from M_DenpyouNO where RenbanKBN=2 and SEQNO=0)
	               SET @outNO = ISNULL(@Prefix1,'')+ISNULL(@Prefix2,'')+'000000000000'+@tempCounter   
	               SET @HacchuuNO= LEFT(@outNO,8)+RIGHT(@outNO,4);


				   UPDATE MAIN
				   SET HacchuuNO = @HacchuuNO
				   FROM #Temp_Juchuu MAIN
                   where ISNULL(JuchuuDate, '') = ISNULL(@JuchuuDate, '')
                   AND ISNULL(TokuisakiCD, '') = ISNULL(@TokuisakiCD, '')
                   AND ISNULL(TokuisakiRyakuName, '') = ISNULL(@TokuisakiRyakuName, '')
                   AND ISNULL(TokuisakiName, '') = ISNULL(@TokuisakiName, '')
                   AND ISNULL(KouritenCD, '') = ISNULL(@KouritenCD, '')
                   AND ISNULL(KouritenRyakuName, '') = ISNULL(@KouritenRyakuName, '')
                   AND ISNULL(KouritenName, '') = ISNULL(@KouritenName, '')
                   AND ISNULL(StaffCD, '') = ISNULL(@StaffCD, '')
                   AND ISNULL(SenpouHacchuuNO, '') = ISNULL(@SenpouHacchuuNO, '')
                   AND ISNULL(SenpouBusho, '') = ISNULL(@SenpouBusho, '')
                   AND ISNULL(KibouNouki, '') = ISNULL(@KibouNouki, '')
                   AND ISNULL(JuchuuDenpyouTekiyou, '') = ISNULL(@JuchuuDenpyouTekiyou, '')
				   AND ISNULL(SiiresakiCD, '') = ISNULL(@SiiresakiCD, '')

				END
		        
                SET @Before_JuchuuNO = @JuchuuNO
                SET @Before_JuchuuGyouNO = @JuchuuGyouNO
                SET @Before_HacchuuNO = @HacchuuNO
                SET @Before_HacchuuGyouNO = @HacchuuGyouNO
                SET @Before_JuchuuDate = @JuchuuDate
                SET @Before_TokuisakiCD = @TokuisakiCD
                SET @Before_TokuisakiRyakuName = @TokuisakiRyakuName
                SET @Before_TokuisakiName = @TokuisakiName
                SET @Before_KouritenCD = @KouritenCD
                SET @Before_KouritenRyakuName = @KouritenRyakuName
                SET @Before_KouritenName = @KouritenName
                SET @Before_StaffCD = @StaffCD
                SET @Before_SenpouHacchuuNO = @SenpouHacchuuNO
                SET @Before_SenpouBusho = @SenpouBusho
                SET @Before_KibouNouki = @KibouNouki
                SET @Before_JuchuuDenpyouTekiyou = @JuchuuDenpyouTekiyou
                SET @Before_SiiresakiCD = @SiiresakiCD

			    FETCH NEXT FROM cursorJuchuu INTO @JuchuuDate, @TokuisakiCD, @TokuisakiRyakuName, @TokuisakiName, @KouritenCD, @KouritenRyakuName, @KouritenName, @StaffCD, @SenpouHacchuuNO, @SenpouBusho, @KibouNouki, @JuchuuDenpyouTekiyou, @SiiresakiCD
		    END
	        CLOSE cursorJuchuu
	        DEALLOCATE cursorJuchuu


			UPDATE MAIN
			SET JuchuuGyouNO = SUB.GyouNO
			FROM #Temp_Juchuu MAIN
			INNER JOIN (
			             SELECT JuchuuNO
						       ,SEQ
						       ,ROW_NUMBER() OVER(PARTITION BY JuchuuNO ORDER BY JuchuuNO, ShouhinCD) GyouNO
						 FROM #Temp_Juchuu
					   ) SUB
		    ON MAIN.JuchuuNO = SUB.JuchuuNO
			and MAIN.SEQ = SUB.SEQ

			UPDATE MAIN
			SET HacchuuGyouNO = SUB.GyouNO
			FROM #Temp_Juchuu MAIN
			INNER JOIN (
			             SELECT HacchuuNO
						       ,SEQ
						       ,ROW_NUMBER() OVER(PARTITION BY HacchuuNO ORDER BY HacchuuNO, ShouhinCD) GyouNO
						 FROM #Temp_Juchuu
						 WHERE HacchuuNO IS NOT NULL
					   ) SUB
		    ON MAIN.HacchuuNO = SUB.HacchuuNO
			and MAIN.SEQ = SUB.SEQ


			INSERT INTO #Temp_Hacchuu
            (
			    HacchuuNO
			   ,HacchuuGyouNO
			   ,HacchuuDate  
			   ,StaffCD
			   ,HacchuuDenpyouTekiyou          
			   ,ShouhinCD
			   ,ColorRyakuName
			   ,SizeNO 
			   --,JANCD           
			   ,HacchuuTanka    
			   ,HacchuuSuu
			   ,SiiresakiCD 
			   ,SiiresakiRyakuName
			   ,ChakuniYoteiDate       
			   ,SoukoCD       
			   ,SoukoName           
			   ,SiiresakiName
			   ,SiiresakiYuubinNO1      
			   ,SiiresakiYuubinNO2               
			   ,SiiresakiJuusho1             
			   ,SiiresakiJuusho2             
			   ,[SiiresakiTelNO1-1]                
			   ,[SiiresakiTelNO1-2]               
			   ,[SiiresakiTelNO1-3]         
			   ,[SiiresakiTelNO2-1]      
			   ,[SiiresakiTelNO2-2]       
			   ,[SiiresakiTelNO2-3]  
			   ,HacchuuMeisaiTekiyou
			   ,Operator
			   ,ProgramID
			   ,PC
			   ,JuchuuNO
			   ,JuchuuGyouNO
			)
			SELECT
			    HacchuuNO
			   ,HacchuuGyouNO
			   ,JuchuuDate  
			   ,StaffCD
			   ,HacchuuDenpyouTekiyou          
			   ,ShouhinCD
			   ,ColorRyakuName
			   ,SizeNO 
			   --,JANCD           
			   ,HacchuuTanka    
			   ,HacchuuSuu
			   ,SiiresakiCD 
			   ,SiiresakiRyakuName
			   ,ChakuniYoteiDate       
			   ,SoukoCD       
			   ,SoukoName           
			   ,SiiresakiName
			   ,SiiresakiYuubinNO1      
			   ,SiiresakiYuubinNO2               
			   ,SiiresakiJuusho1             
			   ,SiiresakiJuusho2             
			   ,[SiiresakiTelNO1-1]                
			   ,[SiiresakiTelNO1-2]               
			   ,[SiiresakiTelNO1-3]         
			   ,[SiiresakiTelNO2-1]      
			   ,[SiiresakiTelNO2-2]       
			   ,[SiiresakiTelNO2-3]  
			   ,JuchuuMeisaiTekiyou
			   ,Operator
			   ,ProgramID
			   ,PC
			   ,JuchuuNO
			   ,JuchuuGyouNO
			FROM #Temp_Juchuu
			WHERE HacchuuNO IS NOT NULL
			--2021/07/07 Y.Nishikawa ADD Remake↑↑
		    
			--Sheet A
			Insert Into D_Hacchuu
				
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--Select 
				--TH.HacchuuNO,
				--TH.StaffCD,
				--TH.HacchuuDate,
				--CONVERT(INT, FORMAT(Cast(TH.HacchuuDate as Date), 'yyyyMM')),
				--TH.SiiresakiCD,
				--CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE TH.SiiresakiRyakuName End,
				--FS.SiharaisakiCD,
				--FS.SiiresakiRyakuName,
				--0,
				--1,
				--1,
				--TH.HacchuuDenpyouTekiyou,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--NULL,
				--NULL,
				--NULL,
				--0,
				--0,
				--NULL,
				--TH.JuchuuNO,
				--0,
				--0,
				--0,
				--NULL,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE TH.SiiresakiName END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE TH.SiiresakiYuubinNO1 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE TH.SiiresakiYuubinNO2 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE TH.SiiresakiJuusho1 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE TH.SiiresakiJuusho2 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE TH.[SiiresakiTelNO1-1] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE TH.[SiiresakiTelNO1-2] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE TH.[SiiresakiTelNO1-3] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE TH.[SiiresakiTelNO2-1] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE TH.[SiiresakiTelNO2-2] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE TH.[SiiresakiTelNO2-3] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE TH.SiiresakiName END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE TH.SiiresakiYuubinNO1 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE TH.SiiresakiYuubinNO2 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE TH.SiiresakiJuusho1 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE TH.SiiresakiJuusho2 END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE TH.[SiiresakiTelNO1-1] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE TH.[SiiresakiTelNO1-2] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE TH.[SiiresakiTelNO1-3] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE TH.[SiiresakiTelNO2-1] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE TH.[SiiresakiTelNO2-2] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE TH.[SiiresakiTelNO2-3] END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
				--CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
				--@Operator,
				--@currentDate,
				--@Operator,
				--@currentDate
				--from #Temp_Hacchuu TH
				--Left Outer Join F_Siiresaki(@slip_Date) FS on FS.SiiresakiCD=TH.SiiresakiCD
				--where TH.SiiresakiCD Is Not Null
				
				Select 
				TH.HacchuuNO,
				MAX(TH.StaffCD),
				MAX(TH.HacchuuDate),
				CONVERT(INT, FORMAT(Cast(MAX(TH.HacchuuDate) as Date), 'yyyyMM')),
				MAX(TH.SiiresakiCD),
				MAX(CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE TH.SiiresakiRyakuName End),
				MAX(FS.SiharaisakiCD),
				MAX(FS.SiiresakiRyakuName),
				0,
				1,
				1,
				MAX(TH.HacchuuDenpyouTekiyou),
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				NULL,
				NULL,
				NULL,
				0,
				0,
				NULL,
				MAX(TH.JuchuuNO),
				0,
				0,
				0,
				NULL,
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE TH.SiiresakiName END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE TH.SiiresakiYuubinNO1 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE TH.SiiresakiYuubinNO2 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE TH.SiiresakiJuusho1 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE TH.SiiresakiJuusho2 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE TH.[SiiresakiTelNO1-1] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE TH.[SiiresakiTelNO1-2] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE TH.[SiiresakiTelNO1-3] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE TH.[SiiresakiTelNO2-1] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE TH.[SiiresakiTelNO2-2] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE TH.[SiiresakiTelNO2-3] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE TH.SiiresakiName END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE TH.SiiresakiYuubinNO1 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE TH.SiiresakiYuubinNO2 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE TH.SiiresakiJuusho1 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE TH.SiiresakiJuusho2 END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE TH.[SiiresakiTelNO1-1] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE TH.[SiiresakiTelNO1-2] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE TH.[SiiresakiTelNO1-3] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE TH.[SiiresakiTelNO2-1] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE TH.[SiiresakiTelNO2-2] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE TH.[SiiresakiTelNO2-3] END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END),
				MAX(CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END),
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				from #Temp_Hacchuu TH
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--Left Outer Join F_Siiresaki(@slip_Date) FS on FS.SiiresakiCD=TH.SiiresakiCD
                OUTER APPLY (SELECT * FROM F_Siiresaki(TH.HacchuuDate) FS WHERE FS.SiiresakiCD = TH.SiiresakiCD) FS
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				where TH.SiiresakiCD Is Not Null
				--2021/07/07 Y.Nishikawa ADD Remake↓↓
				GROUP BY TH.HacchuuNO
				--2021/07/07 Y.Nishikawa ADD Remake↑↑


				--Insert Sheet B
				Insert Into D_HacchuuMeisai
				
				Select 
				TH.HacchuuNO,
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				--ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				HacchuuGyouNO,
				HacchuuGyouNO,
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				FS.BrandCD,
				--TH.ShouhinCD,
				TH.ShouhinCD+TH.ColorRyakuName+TH.SizeNO,
				FS.ShouhinName,
				FS.JANCD,
				--TH.ColorRyakuName,
				M_MultiPorpose_Color.Char2,
				TH.ColorRyakuName,
				TH.SizeNO,
				--FS.ColorNO,
				--FS.SizeNO,
				1,
				TH.HacchuuSuu,
				FS.TaniCD,
				--TH.HacchuuTanka,
                CASE CAST(TH.HacchuuTanka AS decimal) WHEN 0 THEN  FS.GedaiTanka ELSE CAST(TH.HacchuuTanka AS decimal) END,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				--TH.HacchuuTanka,
                CASE CAST(TH.HacchuuTanka AS decimal) WHEN 0 THEN  FS.GedaiTanka ELSE CAST(TH.HacchuuTanka AS decimal) END,
				0,
				0,
				0,
				0,
				0,
				0,
				FS.ZeirituKBN,
				0,
				TH.HacchuuMeisaiTekiyou,
				--CONVERT(varchar(10), TH.ChakuniYoteiDate, 23),
				FORMAT(CONVERT(Date,TH.ChakuniYoteiDate), 'yyyy-MM-dd') as ChakuniYoteiDate,
				TH.SoukoCD,
				0,
				0,
				0,
				0,
				0,
				0,
				TH.JuchuuNO,
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				TH.JuchuuGyouNO,
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				Null,
				0,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				from #Temp_Hacchuu TH
				
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--Left outer join F_Shouhin(@slip_Date) FS on FS.ShouhinCD=(TH.ShouhinCD+TH.ColorRyakuName+TH.SizeNO)
                OUTER APPLY (SELECT * FROM F_Shouhin(TH.HacchuuDate) FS WHERE FS.ShouhinCD = (TH.ShouhinCD+TH.ColorRyakuName+TH.SizeNO)) FS
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = FS.ColorNO----2021/05/24 ses Change Task no-487
				where TH.SiiresakiCD Is Not Null


				--Insert Sheet C
				Insert Into D_HacchuuHistory
				
				Select 
				@Unique,
				DH.HacchuuNO,
				10,
				DH.StaffCD,
				DH.HacchuuDate,
				DH.KaikeiYYMM,
				DH.SiiresakiCD,
				DH.SiiresakiRyakuName,
				DH.SiharaisakiCD,
				DH.SiharaisakiRyakuName,
				DH.TuukaCD,
				DH.RateKBN,
				DH.SiireRate,
				DH.HacchuuDenpyouTekiyou,
				DH.DenpyouSiireHontaiKingaku,
				DH.DenpyouSiireHenpinHontaiKingaku,
				DH.DenpyouSiireNebikiHontaiKingaku,
				DH.DenpyouSiireShouhizeiGaku,
				DH.DenpyouSiireShouhizeiGakuTuujou,
				DH.DenpyouSiireShouhizeiGakuKeigen,
				DH.DenpyouJoudaiHontaiKingaku,
				DH.DenpyouJoudaiShouhizeiGaku,
				DH.DenpyouGaikaSiireHontaiKingaku,
				DH.DenpyouGaikaSiireHenpinHontaiKingaku,
				DH.DenpyouGaikaSiireNebikiHontaiKingaku,
				DH.DenpyouGaikaSiireShouhizeiGaku,
				DH.DenpyouGaikaJoudaiHontaiKingaku,
				DH.DenpyouGaikaJoudaiShouhizeiGaku,
				DH.SiharaiKBN,
				DH.SiharaiChouhaKBN,
				DH.SiharaiHouhouCD,
				DH.SiharaiYoteiDate,
				DH.HacchuushoTekiyou,
				DH.HacchuushoHuyouFLG,
				DH.HacchuushoHakkouFLG,
				DH.HacchuushoHakkouDatetime,
				DH.JuchuuNO,
				DH.ChakuniYoteiKanryouKBN,
				DH.ChakuniKanryouKBN,
				DH.SiireKanryouKBN,
				DH.TorikomiDenpyouNO,
				DH.SiiresakiName,
				DH.SiiresakiYuubinNO1,
				DH.SiiresakiYuubinNO2,
				DH.SiiresakiJuusho1,
				DH.SiiresakiJuusho2,
				DH.[SiiresakiTelNO1-1],
				DH.[SiiresakiTelNO1-2],
				DH.[SiiresakiTelNO1-3],
				DH.[SiiresakiTelNO2-1],
				DH.[SiiresakiTelNO2-2],
				DH.[SiiresakiTelNO2-3],
				DH.SiiresakiTantouBushoName,
				DH.SiiresakiTantoushaYakushoku,
				DH.SiiresakiTantoushaName,
				DH.SiharaisakiName,
				DH.SiharaisakiYuubinNO1,
				DH.SiharaisakiYuubinNO2,
				DH.SiharaisakiJuusho1,
				DH.SiharaisakiJuusho2,
				DH.[SiharaisakiTelNO1-1],
				DH.[SiharaisakiTelNO1-2],
				DH.[SiharaisakiTelNO1-3],
				DH.[SiharaisakiTelNO2-1],
				DH.[SiharaisakiTelNO2-2],
				DH.[SiharaisakiTelNO2-3],
				DH.SiharaisakiTantouBushoName,
				DH.SiharaisakiTantoushaYakushoku,
				DH.SiharaisakiTantoushaName,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--from D_Hacchuu DH inner join #Temp_Hacchuu TH on DH.HacchuuNO=TH.HacchuuNO
				--where TH.SiiresakiCD Is Not Null
				FROM D_Hacchuu DH
				WHERE EXISTS(SELECT * FROM #Temp_Hacchuu where HacchuuNO = DH.HacchuuNO)
                --2021/07/07 Y.Nishikawa CHG Remake↑↑


				--Insert Sheet D
				Insert into D_HacchuuMeisaiHistory
				
				Select 
				@Unique,
				DHM.HacchuuNO,
				DHM.HacchuuGyouNO,
				DHM.GyouHyouziJun,
				10,
				DHM.BrandCD,
				DHM.ShouhinCD,
				DHM.ShouhinName,
				--DHM.JANCD,
				DHM.ColorRyakuName,
				DHM.ColorNO,
				DHM.SizeNO,
				DHM.Kakeritu,
				DHM.HacchuuSuu,
				DHM.TaniCD,
				DHM.HacchuuTanka,
				DHM.HacchuuTankaShouhizei,
				DHM.HacchuuTankaShouhizeiTuujou,
				DHM.HacchuuTankaShouhizeiKeigen,
				DHM.HacchuuHontaiTanka,
				DHM.HacchuuKingaku,
				DHM.HacchuuHontaiKingaku,
				DHM.HacchuuShouhizeiGaku,
				DHM.HacchuuShouhizeiGakuTuujou,
				DHM.HacchuuShouhizeiGakuKeigen,
				DHM.HacchuuShouhizeiChouseiGaku,
				DHM.GaikaHacchuuTanka,
				DHM.GaikaHacchuuTankaShouhizei,
				DHM.GaikaHacchuuHontaiTanka,
				DHM.GaikaHacchuuKingaku,
				DHM.GaikaHacchuuHontaiKingaku,
				DHM.GaikaHacchuuShouhizeiGaku,
				DHM.GaikaHacchuuShouhizeiChouseiGaku,
				DHM.ShouhizeirituKBN,
				DHM.ShouhizeiNaigaiKBN,
				DHM.HacchuuMeisaiTekiyou,
				DHM.ChakuniYoteiDate,
				DHM.SoukoCD,
				DHM.ChakuniYoteiKanryouKBN,
				DHM.ChakuniKanryouKBN,
				DHM.SiireKanryouKBN,
				DHM.ChakuniYoteiZumiSuu,
				DHM.ChakuniZumiSuu,
				DHM.SiireZumiSuu,
				DHM.JuchuuNO,
				DHM.JuchuuGyouNO,
				DHM.TorikomiDenpyouNO,
				DHM.TorikomiDenpyouGyouNO,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				From D_HacchuuMeisai DHM Inner Join  #Temp_Hacchuu TH on DHM.HacchuuNO=TH.HacchuuNO
				--2021/07/07 Y.Nishikawa ADD Remake↓↓
				and DHM.HacchuuGyouNO=TH.HacchuuGyouNO
				--2021/07/07 Y.Nishikawa ADD Remake↑↑
				where TH.SiiresakiCD Is Not Null

				--Declare @TorikomiDenpyouNO as varchar(12)=(Select MAX(TorikomiDenpyouNO)+1 from D_Juchuu)
				--comment by HET
				--Declare @TorikomiDenyouNO as varchar(12)=(Select isnull(ltrim(rtrim(MAX(TorikomiDenpyouNO))),'')+1  from D_Juchuu)
				--TaskNo685 HET
				Declare @TorikomiDenyouNO as bigint=(Select max(Cast(ISNULL(TorikomiDenpyouNO, 0) as bigint))+1  from D_Juchuu)


				--Insert into D_Juchuu
				Insert Into D_Juchuu
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--Select 
				--TJ.JuchuuNO,
				--TJ.StaffCD,
				--TJ.JuchuuDate,
				--CONVERT(INT, FORMAT(Cast(TJ.JuchuuDate as Date), 'yyyyMM')) as KaikeiYYMM,
				--TJ.TokuisakiCD,
				--CASE WHEN FT.ShokutiFLG=0 THEN FT.TokuisakiRyakuName ELSE TJ.TokuisakiRyakuName End,
				--TJ.KouritenCD,
				--CASE WHEN FK.ShokutiFLG=0 THEN FK.KouritenRyakuName ELSE TJ.KouritenRyakuName End,
				--FT.TokuisakiCD,
				--FT.TokuisakiRyakuName,
				--TJ.SenpouHacchuuNO,
				--TJ.SenpouBusho,
				--TJ.KibouNouki,
				--TJ.HacchuuDenpyouTekiyou,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--0,
				--NULL,
				--0,
				--0,
				--0,
				--@TorikomiDenyouNO,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE TJ.TokuisakiName END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE TJ.TokuisakiYuubinNO1 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE TJ.TokuisakiYuubinNO2 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE TJ.TokuisakiJuusho1 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE TJ.TokuisakiJuusho2 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE TJ.[TokuisakiTelNO1-1] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE TJ.[TokuisakiTelNO1-2] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE TJ.[TokuisakiTelNO1-3] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE TJ.[TokuisakiTelNO2-1] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE TJ.[TokuisakiTelNO2-2] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE TJ.[TokuisakiTelNO2-3] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE TJ.TokuisakiName END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE TJ.TokuisakiYuubinNO1 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE TJ.TokuisakiYuubinNO2 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE TJ.TokuisakiJuusho1 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE TJ.TokuisakiJuusho2 END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE TJ.[TokuisakiTelNO1-1] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE TJ.[TokuisakiTelNO1-2] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE TJ.[TokuisakiTelNO1-3] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE TJ.[TokuisakiTelNO2-1] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE TJ.[TokuisakiTelNO2-2] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE TJ.[TokuisakiTelNO2-3] END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
				--CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE TJ.KouritenName END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE TJ.KouritenYuubinNO1 END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE TJ.KouritenYuubinNO2 END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE TJ.KouritenJuusho1 END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE TJ.KouritenJuusho2 END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE TJ.[KouritenTelNO1-1] END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE TJ.[KouritenTelNO1-2] END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE TJ.[KouritenTelNO1-3] END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE TJ.[KouritenTelNO2-1] END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE TJ.[KouritenTelNO2-2] END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE TJ.[KouritenTelNO2-3] END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
				--CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END,
				--@currentDate,
				--@Operator,
				--@currentDate,
				--@Operator,
				--@currentDate
				--From #Temp_Juchuu TJ
				--Left outer Join F_Tokuisaki(@slip_Date) FT on FT.TokuisakiCD=TJ.TokuisakiCD
				--Left Outer Join F_Kouriten(@slip_Date) FK on FK.KouritenCD=TJ.KouritenCD

				Select 
				TJ.JuchuuNO,
				MAX(TJ.StaffCD),
				MAX(TJ.JuchuuDate),
				MAX(CONVERT(INT, FORMAT(Cast(TJ.JuchuuDate as Date), 'yyyyMM'))) as KaikeiYYMM,
				MAX(TJ.TokuisakiCD),
				MAX(CASE WHEN FT.ShokutiFLG=0 THEN FT.TokuisakiRyakuName ELSE TJ.TokuisakiRyakuName End),
				MAX(TJ.KouritenCD),
				MAX(CASE WHEN FK.ShokutiFLG=0 THEN FK.KouritenRyakuName ELSE TJ.KouritenRyakuName End),
				MAX(FT.TokuisakiCD),
				MAX(FT.TokuisakiRyakuName),
				MAX(TJ.SenpouHacchuuNO),
				MAX(TJ.SenpouBusho),
				MAX(TJ.KibouNouki),
                MAX(TJ.JuchuuDenpyouTekiyou),
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				NULL,
				0,
				0,
				0,
				@TorikomiDenyouNO,
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE TJ.TokuisakiName END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE TJ.TokuisakiYuubinNO1 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE TJ.TokuisakiYuubinNO2 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE TJ.TokuisakiJuusho1 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE TJ.TokuisakiJuusho2 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE TJ.[TokuisakiTelNO1-1] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE TJ.[TokuisakiTelNO1-2] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE TJ.[TokuisakiTelNO1-3] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE TJ.[TokuisakiTelNO2-1] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE TJ.[TokuisakiTelNO2-2] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE TJ.[TokuisakiTelNO2-3] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE TJ.TokuisakiName END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE TJ.TokuisakiYuubinNO1 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE TJ.TokuisakiYuubinNO2 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE TJ.TokuisakiJuusho1 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE TJ.TokuisakiJuusho2 END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE TJ.[TokuisakiTelNO1-1] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE TJ.[TokuisakiTelNO1-2] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE TJ.[TokuisakiTelNO1-3] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE TJ.[TokuisakiTelNO2-1] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE TJ.[TokuisakiTelNO2-2] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE TJ.[TokuisakiTelNO2-3] END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END),
				MAX(CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE TJ.KouritenName END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE TJ.KouritenYuubinNO1 END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE TJ.KouritenYuubinNO2 END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE TJ.KouritenJuusho1 END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE TJ.KouritenJuusho2 END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE TJ.[KouritenTelNO1-1] END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE TJ.[KouritenTelNO1-2] END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE TJ.[KouritenTelNO1-3] END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE TJ.[KouritenTelNO2-1] END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE TJ.[KouritenTelNO2-2] END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE TJ.[KouritenTelNO2-3] END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END),
				MAX(CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END),
				@currentDate,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				From #Temp_Juchuu TJ
				OUTER APPLY (SELECT * FROM F_Tokuisaki(TJ.JuchuuDate) FS WHERE FS.TokuisakiCD = TJ.TokuisakiCD) FT
				OUTER APPLY (SELECT * FROM F_Kouriten(TJ.JuchuuDate) FK WHERE FK.TokuisakiCD = TJ.TokuisakiCD AND FK.KouritenCD = TJ.KouritenCD) FK
				GROUP BY TJ.JuchuuNO
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				
				--Insert into D_JuchuuMeisai
				Insert into D_JuchuuMeisai				
				Select 
				TJ.JuchuuNO,
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				--ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				TJ.JuchuuGyouNO,
				TJ.JuchuuGyouNO,
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				FS.BrandCD,
				--TJ.ShouhinCD,
				TJ.ShouhinCD+TJ.ColorRyakuName+TJ.SizeNO,
				FS.ShouhinName,
				FS.JANCD,
				M_MultiPorpose_Color.Char2,
				TJ.ColorRyakuName,
				TJ.SizeNO,
				1,
				TJ.HacchuuSuu,
				FS.TaniCD,
				--TJ.UriageTanka,
                CASE CAST(TJ.UriageTanka AS decimal) WHEN 0 THEN FS.JoudaiTanka ELSE CAST(TJ.UriageTanka as decimal) END,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				FS.ZeirituKBN,
				0,
				0,
				0,
				0,
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--TJ.HacchuuMeisaiTekiyou,
				TJ.JuchuuMeisaiTekiyou,
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				TJ.SenpouHacchuuNO,
				TJ.SoukoCD,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--(CASE WHEN TH.SiiresakiCD Is Not Null THEN TH.HacchuuNO ELSE NULL END),
				--(CASE WHEN TH.SiiresakiCD Is Not Null THEN ROW_NUMBER() OVER(ORDER BY (SELECT 1)) ELSE NULL END),
				(CASE WHEN TJ.SiiresakiCD Is Not Null THEN TJ.HacchuuNO ELSE NULL END),
				(CASE WHEN TJ.SiiresakiCD Is Not Null THEN TJ.HacchuuGyouNO ELSE NULL END),
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				NULL,
				0,
				@currentDate,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				from #Temp_Juchuu TJ
				--2021/07/07 Y.Nishikawa DEL Remake↓↓
				--left outer Join #Temp_Hacchuu TH on TH.JuchuuNO=TJ.JuchuuNO
				--2021/07/07 Y.Nishikawa DEL Remake↑↑
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
				--Left Outer Join F_Shouhin(@slip_Date) FS on FS.ShouhinCD=(TJ.ShouhinCD+TJ.ColorRyakuName+TJ.SizeNO)
                OUTER APPLY (SELECT * FROM F_Shouhin(TJ.JuchuuDate) FS WHERE FS.ShouhinCD = (TJ.ShouhinCD+TJ.ColorRyakuName+TJ.SizeNO)) FS
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = FS.ColorNO

				----2021/05/24 ses Change Task no-487
				--Insert into D_JuchuuHistory
				Insert Into D_JuchuuHistory				
				select  @Unique,DJ.JuchuuNO,10,DJ.StaffCD,DJ.JuchuuDate,KaikeiYYMM,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.KouritenCD,DJ.KouritenRyakuName,
								   SeikyuusakiCD,SeikyuusakiRyakuName,DJ.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DJ.JuchuuDenpyouTekiyou,DenpyouUriageHontaiKingaku,DenpyouUriageHenpinHontaiKingaku,DenpyouUriageNebikiHontaiKingaku,DenpyouUriageShouhizeiGaku,
								   DenpyouUriageShouhizeiGakuTuujou,DenpyouUriageShouhizeiGakuKeigen,DenpyouGenkaKingaku,DenpyouArariKingaku,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,
								   ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,DJ.[TokuisakiTelNO1-1],DJ.[TokuisakiTelNO1-2],
								   DJ.[TokuisakiTelNO1-3],DJ.[TokuisakiTelNO2-1],DJ.[TokuisakiTelNO2-2],DJ.[TokuisakiTelNO2-3],DJ.TokuisakiTantouBushoName,DJ.TokuisakiTantoushaYakushoku,DJ.TokuisakiTantoushaName,DJ.SeikyuusakiName,DJ.SeikyuusakiYuubinNO1,DJ.SeikyuusakiYuubinNO2,
								   DJ.SeikyuusakiJuusho1,DJ.SeikyuusakiJuusho2,DJ.[SeikyuusakiTelNO1-1],DJ.[SeikyuusakiTelNO1-2],DJ.[SeikyuusakiTelNO1-3],DJ.[SeikyuusakiTelNO2-1],DJ.[SeikyuusakiTelNO2-2],DJ.[SeikyuusakiTelNO2-3],DJ.SeikyuusakiTantouBushoName,DJ.SeikyuusakiTantoushaYakushoku,
								   DJ.SeikyuusakiTantoushaName,DJ.KouritenName,DJ.KouritenYuubinNO1,DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,DJ.[KouritenTelNO1-1],DJ.[KouritenTelNO1-2],DJ.[KouritenTelNO1-3],DJ.[KouritenTelNO2-1],
								   DJ.[KouritenTelNO2-2],DJ.[KouritenTelNO2-3],DJ.KouritenTantouBushoName,DJ.KouritenTantoushaYakushoku,DJ.KouritenTantoushaName,DJ.CreateDatetime,@Operator,@currentDate,@Operator,@currentDate,
								   @Operator,@currentDate
								--2021/07/07 Y.Nishikawa CHG Remake↓↓
								--from D_Juchuu DJ inner join #Temp_Juchuu TM on DJ.JuchuuNO=TM.JuchuuNO
								FROM D_Juchuu DJ
								WHERE EXISTS(SELECT * FROM #Temp_Juchuu WHERE JuchuuNO = DJ.JuchuuNO)
								--2021/07/07 Y.Nishikawa CHG Remake↑↑
				
				--Insert Into D_JuchuuMeisaiHistory
				Insert Into D_JuchuuMeisaiHistory
				
				select  @Unique,DJM.JuchuuNO,DJM.JuchuuGyouNO,GyouHyouziJun,10,DJM.BrandCD,DJM.ShouhinCD,DJM.ShouhinName,DJM.JANCD,DJM.ColorRyakuName,
							   DJM.ColorNO,DJM.SizeNO,Kakeritu,DJM.JuchuuSuu,TaniCD,DJM.UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
							   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
							   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,DJM.JuchuuMeisaiTekiyou,DJM.SenpouHacchuuNO,DJM.SoukoCD,
							   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,DJM.HacchuuNO,DJM.HacchuuGyouNO,
							   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,@Operator,@currentDate,@Operator,@currentDate,@Operator,@currentDate
								from D_JuchuuMeisai DJM inner join #Temp_Juchuu TD on DJM.JuchuuNO=TD.JuchuuNO 
								--2021/07/07 Y.Nishikawa ADD Remake↓↓
								and DJM.JuchuuGyouNO=TD.JuchuuGyouNO
								--2021/07/07 Y.Nishikawa ADD Remake↑↑
				
				BEGIN
                    DECLARE CUR_JUC CURSOR FOR
                        SELECT TJ.JuchuuNO
                          FROM #Temp_Juchuu TJ
                         GROUP BY TJ.JuchuuNO
                         ORDER BY TJ.JuchuuNO
                         
                    --カーソルオープン
                    OPEN CUR_JUC;

                    --最初の1行目を取得して変数へ値をセット
                    FETCH NEXT FROM CUR_JUC
                    INTO @JuchuuNO
                    --データの行数分ループ処理を実行する
                    WHILE @@FETCH_STATUS = 0
                    BEGIN
					   --set @slip_NO = (SELECT JuchuuNO FROM @fun_table WHERE idx = (@i_Count+1))
					   exec dbo.Fnc_Hikiate 1,@JuchuuNO,10,@Operator
					   --SET @i_Count1 = @i_Count1 + 1
			            
                        --次の行のデータを取得して変数へ値をセット
                        FETCH NEXT FROM CUR_JUC
                        INTO @JuchuuNO
                    END
				END;
				
				--2021/07/07 Y.Nishikawa CHG Remake↓↓
--				--Update UseFlg M_Tokuisaki
--				Update M_Tokuisaki
--				set UsedFlg=1
--				where ChangeDate = (select ChangeDate from F_Tokuisaki(@slip_Date) where TokuisakiCD = @ToukisakiCD)
				
--				--Update UseFlg M_Kouriten
--				Update M_Kouriten
--				set UsedFlg=1
--				where ChangeDate = (select ChangeDate from F_Kouriten(@slip_Date) where KouritenCD = @KouritenCD)
				
--				--Update UseFlg M_Siiresaki
--				update M_Siiresaki 
--				set UsedFlg = 1 
--				where ChangeDate = (select ChangeDate from F_Siiresaki(@slip_Date) where SiiresakiCD = @SiiresakiCD)
				
--				--Update UseFlg M_Shouhin
--				update M_Shouhin
--				set UsedFlg = 1 
--				where ChangeDate = (select ChangeDate from F_Shouhin(@slip_Date) where ShouhinCD = @ShouhinCD)
				
--				--Update UseFlg M_Souko
--				update M_Souko
--				set UsedFlg = 1 
--				where SoukoCD = @SoukoCD
				
--				--Update UseFlg M_Staff
--				Update M_Staff
--				set UsedFlg=1
--				where ChangeDate = (select ChangeDate from F_Staff(@slip_Date) where StaffCD = @StaffCD)

--				DECLARE @fun_table2 TABLE (idx int Primary Key IDENTITY(1,1),Operator varchar(10),ProgramID varchar(100),PC varchar(30),JuchuuNO  varchar(12))
--				INSERT @fun_table2 SELECT distinct TH.Operator,TH.ProgramID,TH.PC,TJ.JuchuuNO FROM #Temp_Hacchuu TH inner join #Temp_Juchuu TJ on TH.JuchuuNO=TJ.JuchuuNO
--				--select * from @fun_table2
--				declare @s_Count2 as int =(SELECT COUNT(*) FROM @fun_table2)
--				declare @i_Count2 as int = 0
--WHILE @i_Count2 < @s_Count2
--				BEGIN
--				set @Operator=(SELECT Operator FROM @fun_table2 WHERE idx = (@i_Count2+1))
--				   set @ProgramID=(SELECT ProgramID FROM @fun_table2 WHERE idx = (@i_Count2+1))
--				   set @PC =(SELECT PC FROM @fun_table2 WHERE idx = (@i_Count2+1))
--				   set @JuchuuNO =(SELECT JuchuuNO FROM @fun_table2 WHERE idx = (@i_Count2+1))
--				   exec dbo.L_Log_Insert @Operator,@ProgramID,@PC,'New',@JuchuuNO
--				   SET @i_Count2 = @i_Count2 + 1
--				END;

				--Update UseFlg M_Tokuisaki
				Update MAIN
				set UsedFlg=1
				FROM　M_Tokuisaki MAIN
				INNER JOIN #Temp_Juchuu SUB
				ON MAIN.TokuisakiCD = SUB.TokuisakiCD
				OUTER APPLY (SELECT TokuisakiCD,ChangeDate
				             FROM F_Tokuisaki(SUB.JuchuuDate) where TokuisakiCD = SUB.TokuisakiCD) MTOK
				where MAIN.TokuisakiCD = MTOK.TokuisakiCD
				AND MAIN.ChangeDate = MTOK.ChangeDate
				
				--Update UseFlg M_Kouriten
				Update MAIN
				set UsedFlg=1
				FROM　M_Kouriten MAIN
				INNER JOIN #Temp_Juchuu SUB
				ON MAIN.TokuisakiCD = SUB.TokuisakiCD
				AND MAIN.KouritenCD = SUB.KouritenCD
				OUTER APPLY (SELECT TokuisakiCD,KouritenCD,ChangeDate
				             FROM F_Kouriten(SUB.JuchuuDate) where TokuisakiCD = SUB.TokuisakiCD AND KouritenCD = SUB.KouritenCD) MKOU
				where MAIN.KouritenCD = MKOU.KouritenCD
				AND MAIN.TokuisakiCD = MKOU.TokuisakiCD
				AND MAIN.ChangeDate = MKOU.ChangeDate
				
				--Update UseFlg M_Siiresaki
				update MAIN 
				set UsedFlg = 1 
				FROM　M_Siiresaki MAIN
				INNER JOIN #Temp_Juchuu SUB
				ON MAIN.SiiresakiCD = SUB.SiiresakiCD
				OUTER APPLY (SELECT SiiresakiCD,ChangeDate
				             FROM F_Siiresaki(SUB.JuchuuDate) where SiiresakiCD = SUB.SiiresakiCD) MSII
				where MAIN.SiiresakiCD = MSII.SiiresakiCD
				AND MAIN.ChangeDate = MSII.ChangeDate
				
				--Update UseFlg M_Shouhin
				update MAIN
				set UsedFlg = 1 
				FROM　M_Shouhin MAIN
				INNER JOIN #Temp_Juchuu SUB
				ON MAIN.ShouhinCD = SUB.ShouhinCD
				OUTER APPLY (SELECT ShouhinCD,ChangeDate
				             FROM F_Shouhin(SUB.JuchuuDate) where ShouhinCD = SUB.ShouhinCD) MSHO
				where MAIN.ShouhinCD = MSHO.ShouhinCD
				AND MAIN.ChangeDate = MSHO.ChangeDate
				
				--Update UseFlg M_Souko
				update MAIN
				set UsedFlg = 1 
				FROM　M_Souko MAIN
				INNER JOIN #Temp_Juchuu SUB
				ON MAIN.SoukoCD = SUB.SoukoCD
				
				--Update UseFlg M_Staff
				Update MAIN
				set UsedFlg=1
				FROM　M_Staff MAIN
				INNER JOIN #Temp_Juchuu SUB
				ON MAIN.StaffCD = SUB.StaffCD
				OUTER APPLY (SELECT StaffCD,ChangeDate
				             FROM F_Staff(SUB.JuchuuDate) where StaffCD = SUB.StaffCD) MSTA
				where MAIN.StaffCD = MSTA.StaffCD
				AND MAIN.ChangeDate = MSTA.ChangeDate
				--2021/07/07 Y.Nishikawa CHG Remake↑↑
				
				select '1' as Result
				Drop table #Temp_Hacchuu
				Drop table #Temp_Juchuu
		END
END
