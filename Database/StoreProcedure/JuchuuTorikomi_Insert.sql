BEGIN TRY 
 Drop Procedure dbo.[JuchuuTorikomi_Insert]
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
CREATE PROCEDURE [dbo].[JuchuuTorikomi_Insert]
@XML_Hacchuu as xml,
@XML_Jucchuu as xml
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
							  HacchuuNO varchar(12) COLLATE DATABASE_DEFAULT,
							  HacchuuDate date,
							  StaffCD varchar(10) COLLATE DATABASE_DEFAULT,
							  HacchuuDenpyouTekiyou varchar(80) COLLATE DATABASE_DEFAULT,
							  ShouhinCD varchar(50) COLLATE DATABASE_DEFAULT,
							  ColorRyakuName varchar(25)COLLATE DATABASE_DEFAULT,
							  SizeNO varchar(13) COLLATE DATABASE_DEFAULT,
							  JANCD varchar(13) COLLATE DATABASE_DEFAULT,
							  HacchuuTanka decimal(21,6),
							  HacchuuSuu decimal(21,6),
							  SiiresakiCD varchar(10) COLLATE DATABASE_DEFAULT,
							  SiiresakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
							  ChakuniYoteiDate varchar(10) COLLATE DATABASE_DEFAULT,
							  SoukoCD varchar(10) COLLATE DATABASE_DEFAULT,
							  SoukoName varchar(80) COLLATE DATABASE_DEFAULT,
							  SiiresakiName varchar(120) COLLATE DATABASE_DEFAULT,
							  SiiresakiYuubinNO1 varchar(3)COLLATE DATABASE_DEFAULT,
							  SiiresakiYuubinNO2 varchar(4) COLLATE DATABASE_DEFAULT,
							  SiiresakiJuusho1 varchar(80) COLLATE DATABASE_DEFAULT,
							  SiiresakiJuusho2 varchar(80) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO1-1] varchar(6) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO1-2] varchar(5) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO1-3] varchar(5) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO2-1]  varchar(6) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO2-2] varchar(5) COLLATE DATABASE_DEFAULT,
							  [SiiresakiTelNO2-3] varchar(5) COLLATE DATABASE_DEFAULT,
							  HacchuuMeisaiTekiyou  varchar(80) COLLATE DATABASE_DEFAULT,
							  Operator varchar(10) COLLATE DATABASE_DEFAULT,
							  ProgramID	 varchar(100) COLLATE DATABASE_DEFAULT,
							  PC varchar(30) COLLATE DATABASE_DEFAULT,
							  Error	varchar(10),
							  JuchuuNO varchar(12)
							)
							EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Hacchuu

			INSERT INTO #Temp_Hacchuu
             (
			   HacchuuNO
			  ,HacchuuDate  
			  ,StaffCD
			  ,HacchuuDenpyouTekiyou          
			  ,ShouhinCD
			  ,ColorRyakuName
			  ,SizeNO 
			  ,JANCD           
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
			  ,Error
			  ,JuchuuNO
			  )

			  SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
				  HacchuuNO varchar(12) 'HacchuuNO',
				  HacchuuDate date 'JuchuuDate',
				  StaffCD varchar(10) 'StaffCD',
				  HacchuuDenpyouTekiyou varchar(80)  'HacchuuDenpyouTekiyou',
				  ShouhinCD varchar(50) 'ShouhinCD',
				  ColorRyakuName varchar(25) 'ColorRyakuName',
				  SizeNO varchar(13) 'SizeNO',
				  JANCD	varchar(13) 'JANCD',
				  HacchuuTanka decimal(21,6) 'HacchuuTanka',
				  HacchuuSuu decimal(21,6) 'HacchuuSuu',
				  SiiresakiCD varchar(10) 'SiiresakiCD',
				  SiiresakiRyakuName varchar(40) 'SiiresakiRyakuName',
				  ChakuniYoteiDate  varchar(10) 'ChakuniYoteiDate',
				  SoukoCD varchar(10)  'SoukoCD',
				  SoukoName varchar(80) 'SoukoName',
				  SiiresakiName varchar(120) 'SiiresakiName',
				  SiiresakiYuubinNO1 varchar(3) 'SiiresakiYuubinNO1',
				  SiiresakiYuubinNO2 varchar(4) 'SiiresakiYuubinNO2',
				  SiiresakiJuusho1 varchar(80) 'SiiresakiJuusho1',
				  SiiresakiJuusho2 varchar(80) 'SiiresakiJuusho2',
				  [SiiresakiTelNO1-1] varchar(6) 'SiiresakiTelNO11',
				  [SiiresakiTelNO1-2] varchar(5) 'SiiresakiTelNO12',
				  [SiiresakiTelNO1-3] varchar(5) 'SiiresakiTelNO13',
				  [SiiresakiTelNO2-1]  varchar(6) 'SiiresakiTelNO21',
				  [SiiresakiTelNO2-2] varchar(5) 'SiiresakiTelNO22',
				  [SiiresakiTelNO2-3] varchar(5) 'SiiresakiTelNO23',
				  HacchuuMeisaiTekiyou varchar(80) 'JuchuuMeisaiTekiyou',
				  Operator varchar(10) 'Operator',
				  ProgramID	 varchar(100) 'ProgramID',
				  PC varchar(30) 'PC',
				  Error	varchar(10) 'Error',
				  JuchuuNO varchar(12) 'JuchuuNO'
				)
			EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

				CREATE TABLE #Temp_Juchuu
						(  
						  SEQ	int IDENTITY(1,1),
						  JuchuuNO  varchar(12) COLLATE DATABASE_DEFAULT,
						  JuchuuDate date,
						  TokuisakiCD varchar(10) COLLATE DATABASE_DEFAULT,
						  TokuisakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
						  KouritenCD varchar(10) COLLATE DATABASE_DEFAULT,
						  KouritenRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
						  StaffCD varchar(10) COLLATE DATABASE_DEFAULT,
						  SenpouHacchuuNO varchar(20) COLLATE DATABASE_DEFAULT,
						  SenpouBusho varchar(20) COLLATE DATABASE_DEFAULT,
						  KibouNouki varchar(10)COLLATE DATABASE_DEFAULT,--date
						  HacchuuDenpyouTekiyou varchar(80) COLLATE DATABASE_DEFAULT,
						  ShouhinCD varchar(50) COLLATE DATABASE_DEFAULT,
						  ColorRyakuName varchar(25)COLLATE DATABASE_DEFAULT,
						  SizeNO varchar(13) COLLATE DATABASE_DEFAULT,
						  JANCD varchar(13) COLLATE DATABASE_DEFAULT,
						  HacchuuSuu decimal(21,6),
						  HacchuuTanka decimal(21,6),
						  UriageTanka decimal(21,6),
						  JuchuuDenpyouTekiyou varchar(80) COLLATE DATABASE_DEFAULT,
						  SiiresakiCD varchar(10) COLLATE DATABASE_DEFAULT,
						  SiiresakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
						  ChakuniYoteiDate varchar(10) COLLATE DATABASE_DEFAULT,
						  SoukoCD varchar(10) COLLATE DATABASE_DEFAULT,
						  SoukoName varchar(80) COLLATE DATABASE_DEFAULT,
						  TokuisakiName varchar(120) COLLATE DATABASE_DEFAULT,
						  TokuisakiYuubinNO1 varchar(3)COLLATE DATABASE_DEFAULT,
						  TokuisakiYuubinNO2 varchar(4) COLLATE DATABASE_DEFAULT,
						  TokuisakiJuusho1 varchar(80) COLLATE DATABASE_DEFAULT,
						  TokuisakiJuusho2 varchar(80) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-1] varchar(6) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-1]  varchar(6) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  KouritenName varchar(120) COLLATE DATABASE_DEFAULT,
						  KouritenYuubinNO1 varchar(3)COLLATE DATABASE_DEFAULT,
						  KouritenYuubinNO2 varchar(4) COLLATE DATABASE_DEFAULT,
						  KouritenJuusho1 varchar(80) COLLATE DATABASE_DEFAULT,
						  KouritenJuusho2 varchar(80) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-1] varchar(6) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-1]  varchar(6) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  SiiresakiName varchar(120) COLLATE DATABASE_DEFAULT,
						  SiiresakiYuubinNO1 varchar(3)COLLATE DATABASE_DEFAULT,
						  SiiresakiYuubinNO2 varchar(4) COLLATE DATABASE_DEFAULT,
						  SiiresakiJuusho1 varchar(80) COLLATE DATABASE_DEFAULT,
						  SiiresakiJuusho2 varchar(80) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO1-1] varchar(6) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO1-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO1-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO2-1]  varchar(6) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO2-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [SiiresakiTelNO2-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  HacchuuMeisaiTekiyou  varchar(80) COLLATE DATABASE_DEFAULT,
						  Operator varchar(10) COLLATE DATABASE_DEFAULT,
						  ProgramID	 varchar(100) COLLATE DATABASE_DEFAULT,
						  PC varchar(30) COLLATE DATABASE_DEFAULT,
						  Error1	varchar(100),
						  Error2 varchar(100),
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
						  JANCD,
						  HacchuuSuu,
						  HacchuuTanka,
						  UriageTanka,
						  JuchuuDenpyouTekiyou,
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
						  JuchuuNO  varchar(12) 'JuchuuNO',
						  JuchuuDate date 'JuchuuDate',
						  TokuisakiCD varchar(10) 'TokuisakiCD',
						  TokuisakiRyakuName varchar(40) 'TokuisakiRyakuName',
						  KouritenCD varchar(10) 'KouritenCD',
						  KouritenRyakuName varchar(40) 'KouritenRyakuName',
						  StaffCD varchar(10) 'StaffCD',
						  SenpouHacchuuNO varchar(20) 'SenpouHacchuuNO',
						  SenpouBusho varchar(20) 'SenpouBusho',
						  KibouNouki varchar(10) 'KibouNouki',
						  HacchuuDenpyouTekiyou varchar(80) 'HacchuuDenpyouTekiyou',
						  ShouhinCD varchar(50) 'ShouhinCD',
						  ColorRyakuName varchar(25) 'ColorRyakuName',
						  SizeNO varchar(13) 'SizeNO',
						  JANCD varchar(13) 'JANCD',
						  HacchuuSuu decimal(21,6) 'HacchuuSuu',
						  HacchuuTanka decimal(21,6) 'HacchuuTanka',
						  UriageTanka decimal(21,6) 'UriageTanka',
						  JuchuuDenpyouTekiyou varchar(80) 'JuchuuDenpyouTekiyou',
						  SiiresakiCD varchar(10) 'SiiresakiCD',
						  SiiresakiRyakuName varchar(40) 'SiiresakiRyakuName',
						  ChakuniYoteiDate varchar(10) 'ChakuniYoteiDate',
						  SoukoCD varchar(10) 'SoukoCD',
						  SoukoName varchar(80) 'SoukoName',
						  TokuisakiName varchar(120) 'TokuisakiuName',
						  TokuisakiYuubinNO1 varchar(3) 'TokuisakiYuubinNO1',
						  TokuisakiYuubinNO2 varchar(4) 'TokuisakiYuubinNO2',
						  TokuisakiJuusho1 varchar(50) 'TokuisakiJuusho1',
						  TokuisakiJuusho2 varchar(50) 'TokuisakiJuusho2',
						  [TokuisakiTelNO1-1] varchar(6) 'TokuisakiTelNO11',
						  [TokuisakiTelNO1-2] varchar(5) 'TokuisakiTelNO12',
						  [TokuisakiTelNO1-3] varchar(5) 'TokuisakiTelNO13',
						  [TokuisakiTelNO2-1]  varchar(6) 'TokuisakiTelNO21',
						  [TokuisakiTelNO2-2] varchar(5) 'TokuisakiTelNO22',
						  [TokuisakiTelNO2-3] varchar(5) 'TokuisakiTelNO23',
						  KouritenName varchar(120) 'KouritenName',
						  KouritenYuubinNO1 varchar(3) 'KouritenYuubinNO1',
						  KouritenYuubinNO2 varchar(4) 'KouritenYuubinNO2',
						  KouritenJuusho1 varchar(80) 'KouritenJuusho1',
						  KouritenJuusho2 varchar(80) 'KouritenJuusho2',
						  [KouritenTelNO1-1] varchar(6) 'KouritenTelNO11',
						  [KouritenTelNO1-2] varchar(5) 'KouritenTelNO12',
						  [KouritenTelNO1-3] varchar(5) 'KouritenTelNO13',
						  [KouritenTelNO2-1]  varchar(6) 'KouritenTelNO21',
						  [KouritenTelNO2-2] varchar(5) 'KouritenTelNO22',
						  [KouritenTelNO2-3] varchar(5) 'KouritenTelNO23',
						  SiiresakiName varchar(120) 'SiiresakiName',
						  SiiresakiYuubinNO1 varchar(3) 'SiiresakiYuubinNO1',
						  SiiresakiYuubinNO2 varchar(4) 'SiiresakiYuubinNO2',
						  SiiresakiJuusho1 varchar(80) 'SiiresakiJuusho1',
						  SiiresakiJuusho2 varchar(80) 'SiiresakiJuusho2',
						  [SiiresakiTelNO1-1] varchar(6) 'SiiresakiTelNO11',
						  [SiiresakiTelNO1-2] varchar(5) 'SiiresakiTelNO12',
						  [SiiresakiTelNO1-3] varchar(5) 'SiiresakiTelNO13',
						  [SiiresakiTelNO2-1]  varchar(6) 'SiiresakiTelNO21',
						  [SiiresakiTelNO2-2] varchar(5) 'SiiresakiTelNO22',
						  [SiiresakiTelNO2-3] varchar(5) 'SiiresakiTelNO23',
						  HacchuuMeisaiTekiyou  varchar(80) 'HacchuuMeisaiTekiyou',
						  Operator varchar(10) 'Operator',
						  ProgramID	 varchar(100) 'ProgramID',
						  PC varchar(30) 'PC'
						  --,
						  --Error1	varchar(100) 'Error'
						)
				EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

			
				DECLARE @fun_table TABLE (idx int Primary Key IDENTITY(1,1), HacchuuDate date,StaffCD varchar(10),ShouhinCD varchar(50),SoukoCD varchar(10),SiiresakiCD varchar(13),TokuisakiCD varchar(10),KouritenCD varchar(10),Operator varchar(10),ProgramID varchar(100),PC varchar(30),JuchuuNO  varchar(12))
				INSERT @fun_table SELECT distinct TH.HacchuuDate,TH.StaffCD,TH.ShouhinCD,TH.SoukoCD,TH.SiiresakiCD,TJ.TokuisakiCD,TJ.KouritenCD,TH.Operator,TH.ProgramID,TH.PC,TJ.JuchuuNO FROM #Temp_Hacchuu TH inner join #Temp_Juchuu TJ on TH.JuchuuNO=TJ.JuchuuNO
				declare @s_Count as int =(SELECT COUNT(*) FROM @fun_table)
				declare @i_Count as int = 0
				declare @JuchuuNO as varchar(12)
				declare @StaffCD as varchar(10)
				declare @ShouhinCD as varchar(50)
				declare @SoukoCD as varchar(10)
				declare @SiiresakiCD as varchar(13)
				declare @ToukisakiCD as varchar(10)
				declare @KouritenCD as varchar(10)
				Declare @Operator as varchar(10)
				declare @ProgramID as varchar(100)
				declare @PC as varchar(30)
				declare @slip_Date as date
				
				WHILE @i_Count < @s_Count
				BEGIN
				   set @StaffCD = (SELECT StaffCD FROM @fun_table WHERE idx = (@i_Count+1))
				   set @ShouhinCD = (SELECT ShouhinCD FROM @fun_table WHERE idx = (@i_Count+1))
				   set @SoukoCD=(SELECT SoukoCD FROM @fun_table WHERE idx = (@i_Count+1))
				   set @SiiresakiCD=(SELECT SiiresakiCD FROM @fun_table WHERE idx = (@i_Count+1))
				   set @ToukisakiCD=(SELECT TokuisakiCD FROM @fun_table WHERE idx = (@i_Count+1))
				   set @KouritenCD=(SELECT KouritenCD FROM @fun_table WHERE idx = (@i_Count+1))
				   set @Operator=(SELECT Operator FROM @fun_table WHERE idx = (@i_Count+1))
				   set @ProgramID=(SELECT ProgramID FROM @fun_table WHERE idx = (@i_Count+1))
				   set @PC =(SELECT PC FROM @fun_table WHERE idx = (@i_Count+1))
				   set @JuchuuNO =(SELECT JuchuuNO FROM @fun_table WHERE idx = (@i_Count+1))
				   set @slip_Date=(Select HacchuuDate from @fun_table WHERE idx = (@i_Count+1))
				   SET @i_Count = @i_Count + 1
				END;

				begin
				--Sheet A
				Insert Into D_Hacchuu
				
				Select 
				TH.HacchuuNO,
				TH.StaffCD,
				TH.HacchuuDate,
				CONVERT(INT, FORMAT(Cast(TH.HacchuuDate as Date), 'yyyyMM')),
				TH.SiiresakiCD,
				CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE TH.SiiresakiRyakuName End,
				FS.SiharaisakiCD,
				FS.SiiresakiRyakuName,
				0,
				1,
				1,
				TH.HacchuuDenpyouTekiyou,
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
				TH.JuchuuNO,
				0,
				0,
				0,
				NULL,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE TH.SiiresakiName END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE TH.SiiresakiYuubinNO1 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE TH.SiiresakiYuubinNO2 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE TH.SiiresakiJuusho1 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE TH.SiiresakiJuusho2 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE TH.[SiiresakiTelNO1-1] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE TH.[SiiresakiTelNO1-2] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE TH.[SiiresakiTelNO1-3] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE TH.[SiiresakiTelNO2-1] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE TH.[SiiresakiTelNO2-2] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE TH.[SiiresakiTelNO2-3] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE TH.SiiresakiName END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE TH.SiiresakiYuubinNO1 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE TH.SiiresakiYuubinNO2 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE TH.SiiresakiJuusho1 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE TH.SiiresakiJuusho2 END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE TH.[SiiresakiTelNO1-1] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE TH.[SiiresakiTelNO1-2] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE TH.[SiiresakiTelNO1-3] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE TH.[SiiresakiTelNO2-1] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE TH.[SiiresakiTelNO2-2] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE TH.[SiiresakiTelNO2-3] END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
				CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				from #Temp_Hacchuu TH
				Left Outer Join F_Siiresaki(@slip_Date) FS on FS.SiiresakiCD=TH.SiiresakiCD
				where TH.SiiresakiCD !=''

				--Insert Sheet B
				Insert Into D_HacchuuMeisai
				
				Select 
				TH.HacchuuNO,
				ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				FS.BrandCD,
				TH.ShouhinCD,
				FS.ShouhinName,
				TH.JANCD,
				TH.ColorRyakuName,
				FS.ColorNO,
				FS.SizeNO,
				1,
				TH.HacchuuSuu,
				FS.TaniCD,
				TH.HacchuuTanka,
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
				TH.HacchuuTanka,
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
				ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				Null,
				0,
				TH.Operator,
				@currentDate,
				TH.Operator,
				@currentDate
				from #Temp_Hacchuu TH
				Left outer join F_Shouhin(@slip_Date) FS on FS.ShouhinCD=TH.ShouhinCD
				where TH.SiiresakiCD !=''


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
				DH.InsertOperator,
				DH.InsertDateTime,
				DH.UpdateOperator,
				DH.UpdateDateTime,
				@Operator,
				@currentDate
				from D_Hacchuu DH inner join #Temp_Hacchuu TH on DH.HacchuuNO=TH.HacchuuNO
				where TH.SiiresakiCD !=''

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
				DHM.InsertOperator,
				DHM.InsertDateTime,
				DHM.UpdateOperator,
				DHM.UpdateDateTime,
				@Operator,
				@currentDate
				From D_HacchuuMeisai DHM Inner Join  #Temp_Hacchuu TH on DHM.HacchuuNO=TH.HacchuuNO
				where TH.SiiresakiCD!=''

				Declare @TorikomiDenpyouNO as varchar(12)=(Select MAX(TorikomiDenpyouNO)+1 from D_Juchuu)
				--Insert into D_Juchuu
				Insert Into D_Juchuu
				
				Select 
				TJ.JuchuuNO,
				TJ.StaffCD,
				TJ.JuchuuDate,
				CONVERT(INT, FORMAT(Cast(TJ.JuchuuDate as Date), 'yyyyMM')) as KaikeiYYMM,
				TJ.TokuisakiCD,
				CASE WHEN FT.ShokutiFLG=0 THEN FT.TokuisakiRyakuName ELSE TJ.TokuisakiRyakuName End,
				TJ.KouritenCD,
				CASE WHEN FK.ShokutiFLG=0 THEN FK.KouritenRyakuName ELSE TJ.KouritenRyakuName End,
				FT.TokuisakiCD,
				FT.TokuisakiRyakuName,
				TJ.SenpouHacchuuNO,
				TJ.SenpouBusho,
				TJ.KibouNouki,
				TJ.HacchuuDenpyouTekiyou,
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
				@TorikomiDenpyouNO,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE TJ.TokuisakiName END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE TJ.TokuisakiYuubinNO1 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE TJ.TokuisakiYuubinNO2 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE TJ.TokuisakiJuusho1 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE TJ.TokuisakiJuusho2 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE TJ.[TokuisakiTelNO1-1] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE TJ.[TokuisakiTelNO1-2] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE TJ.[TokuisakiTelNO1-3] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE TJ.[TokuisakiTelNO2-1] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE TJ.[TokuisakiTelNO2-2] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE TJ.[TokuisakiTelNO2-3] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE TJ.TokuisakiName END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE TJ.TokuisakiYuubinNO1 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE TJ.TokuisakiYuubinNO2 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE TJ.TokuisakiJuusho1 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE TJ.TokuisakiJuusho2 END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE TJ.[TokuisakiTelNO1-1] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE TJ.[TokuisakiTelNO1-2] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE TJ.[TokuisakiTelNO1-3] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE TJ.[TokuisakiTelNO2-1] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE TJ.[TokuisakiTelNO2-2] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE TJ.[TokuisakiTelNO2-3] END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE TJ.KouritenName END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE TJ.KouritenYuubinNO1 END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE TJ.KouritenYuubinNO2 END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE TJ.KouritenJuusho1 END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE TJ.KouritenJuusho2 END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE TJ.[KouritenTelNO1-1] END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE TJ.[KouritenTelNO1-2] END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE TJ.[KouritenTelNO1-3] END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE TJ.[KouritenTelNO2-1] END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE TJ.[KouritenTelNO2-2] END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE TJ.[KouritenTelNO2-3] END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
				CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END,
				@currentDate,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				From #Temp_Juchuu TJ
				Left outer Join F_Tokuisaki(@slip_Date) FT on FT.TokuisakiCD=TJ.TokuisakiCD
				Left Outer Join F_Kouriten(@slip_Date) FK on FK.KouritenCD=TJ.KouritenCD


				--Insert into D_JuchuuMeisai
				Insert into D_JuchuuMeisai
				
				Select 
				TJ.JuchuuNO,
				ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				FS.BrandCD,
				TJ.ShouhinCD,
				FS.ShouhinName,
				TJ.JANCD,
				TJ.ColorRyakuName,
				FS.ColorNO,
				FS.SizeNO,
				1,
				TJ.HacchuuSuu,
				FS.TaniCD,
				TJ.UriageTanka,
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
				TJ.HacchuuMeisaiTekiyou,
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
				TH.HacchuuNO,
				ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
				NULL,
				0,
				@currentDate,
				@Operator,
				@currentDate,
				@Operator,
				@currentDate
				from #Temp_Juchuu TJ
				Inner Join #Temp_Hacchuu TH on TH.JuchuuNO=TJ.JuchuuNO
				Left Outer Join F_Shouhin(@slip_Date) FS on FS.ShouhinCD=TJ.ShouhinCD

				--Insert into D_JuchuuHistory
				Insert Into D_JuchuuHistory
				
				select  @Unique,DJ.JuchuuNO,10,DJ.StaffCD,DJ.JuchuuDate,KaikeiYYMM,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.KouritenCD,DJ.KouritenRyakuName,
								   SeikyuusakiCD,SeikyuusakiRyakuName,DJ.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DJ.JuchuuDenpyouTekiyou,DenpyouUriageHontaiKingaku,DenpyouUriageHenpinHontaiKingaku,DenpyouUriageNebikiHontaiKingaku,DenpyouUriageShouhizeiGaku,
								   DenpyouUriageShouhizeiGakuTuujou,DenpyouUriageShouhizeiGakuKeigen,DenpyouGenkaKingaku,DenpyouArariKingaku,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,
								   ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,DJ.[TokuisakiTelNO1-1],DJ.[TokuisakiTelNO1-2],
								   DJ.[TokuisakiTelNO1-3],DJ.[TokuisakiTelNO2-1],DJ.[TokuisakiTelNO2-2],DJ.[TokuisakiTelNO2-3],DJ.TokuisakiTantouBushoName,DJ.TokuisakiTantoushaYakushoku,DJ.TokuisakiTantoushaName,DJ.SeikyuusakiName,DJ.SeikyuusakiYuubinNO1,DJ.SeikyuusakiYuubinNO2,
								   DJ.SeikyuusakiJuusho1,DJ.SeikyuusakiJuusho2,DJ.[SeikyuusakiTelNO1-1],DJ.[SeikyuusakiTelNO1-2],DJ.[SeikyuusakiTelNO1-3],DJ.[SeikyuusakiTelNO2-1],DJ.[SeikyuusakiTelNO2-2],DJ.[SeikyuusakiTelNO2-3],DJ.SeikyuusakiTantouBushoName,DJ.SeikyuusakiTantoushaYakushoku,
								   DJ.SeikyuusakiTantoushaName,DJ.KouritenName,DJ.KouritenYuubinNO1,DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,DJ.[KouritenTelNO1-1],DJ.[KouritenTelNO1-2],DJ.[KouritenTelNO1-3],DJ.[KouritenTelNO2-1],
								   DJ.[KouritenTelNO2-2],DJ.[KouritenTelNO2-3],DJ.KouritenTantouBushoName,DJ.KouritenTantoushaYakushoku,DJ.KouritenTantoushaName,DJ.CreateDatetime,DJ.InsertOperator,DJ.InsertDateTime,DJ.UpdateOperator,DJ.UpdateDateTime,
								   @Operator,@currentDate
								from D_Juchuu DJ inner join #Temp_Juchuu TM on DJ.JuchuuNO=TM.JuchuuNO
				
				--Insert Into D_JuchuuMeisaiHistory
				Insert Into D_JuchuuMeisaiHistory
				
				select  @Unique,DJM.JuchuuNO,DJM.JuchuuGyouNO,GyouHyouziJun,10,DJM.BrandCD,DJM.ShouhinCD,DJM.ShouhinName,DJM.JANCD,DJM.ColorRyakuName,
							   DJM.ColorNO,DJM.SizeNO,Kakeritu,DJM.JuchuuSuu,TaniCD,DJM.UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
							   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
							   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,DJM.JuchuuMeisaiTekiyou,DJM.SenpouHacchuuNO,DJM.SoukoCD,
							   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,DJM.HacchuuNO,DJM.HacchuuGyouNO,
							   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,DJM.InsertOperator,InsertDateTime,DJM.UpdateOperator,UpdateDateTime,@Operator,@currentDate
								from D_JuchuuMeisai DJM inner join #Temp_Juchuu TD on DJM.JuchuuNO=TD.JuchuuNO 
				
				DECLARE @fun_table1 TABLE (idx int Primary Key IDENTITY(1,1), JuchuuNO varchar(12))
							INSERT @fun_table1 SELECT distinct JuchuuNO FROM #Temp_Hacchuu
							declare @s_Count1 as int =(SELECT COUNT(*) FROM @fun_table)
							declare @i_Count1 as int = 0
							declare @slip_NO as varchar(12)
							WHILE @i_Count1 < @s_Count1
							BEGIN
							   set @slip_NO = (SELECT JuchuuNO FROM @fun_table WHERE idx = (@i_Count+1))
							   exec dbo.Fnc_Hikiate 1,@slip_NO,10,@Operator
							   SET @i_Count1 = @i_Count1 + 1
							END;
				
				--Update UseFlg M_Tokuisaki
				Update M_Tokuisaki
				set UsedFlg=1
				where ChangeDate = (select ChangeDate from F_Tokuisaki(@slip_Date) where TokuisakiCD = @ToukisakiCD)
				
				--Update UseFlg M_Kouriten
				Update M_Kouriten
				set UsedFlg=1
				where ChangeDate = (select ChangeDate from F_Kouriten(@slip_Date) where KouritenCD = @KouritenCD)
				
				--Update UseFlg M_Siiresaki
				update M_Siiresaki 
				set UsedFlg = 1 
				where ChangeDate = (select ChangeDate from F_Siiresaki(@slip_Date) where SiiresakiCD = @SiiresakiCD)
				
				--Update UseFlg M_Shouhin
				update M_Shouhin
				set UsedFlg = 1 
				where ChangeDate = (select ChangeDate from F_Shouhin(@slip_Date) where ShouhinCD = @ShouhinCD)
				
				--Update UseFlg M_Souko
				update M_Souko
				set UsedFlg = 1 
				where SoukoCD = @SoukoCD
				
				--Update UseFlg M_Staff
				Update M_Staff
				set UsedFlg=1
				where ChangeDate = (select ChangeDate from F_Staff(@slip_Date) where StaffCD = @StaffCD)

				declare @OperateMode     varchar(50) = 'New' 
							
				 exec dbo.L_Log_Insert @Operator,@ProgramID,@PC,@OperateMode,@slip_NO
				--Drop table #Temp_Hacchuu
				--Drop table #Temp_Juchuu

				
				--Null error check
				update #Temp_Juchuu
			set ErrorFlg = 1,
				Error1 = case when isnull(ltrim(rtrim(JuchuuDate)),'') = '' then '受注日未入力エラー'
							when isnull(ltrim(rtrim(TokuisakiCD)),'') = '' then '得意先CD未入力エラー' 
							--when isnull(ltrim(rtrim(TokuisakiName)),'') = '' then '得意先名未入力エラー' 
							when isnull(ltrim(rtrim(KouritenCD)),'') = '' then '小売店CD未入力エラー' 
							--when isnull(ltrim(rtrim(KouritenName)),'') = '' then '小売店名未入力エラー' 
							when isnull(ltrim(rtrim(StaffCD)),'') = '' then '担当スタッフCD未入力エラー' 
							when isnull(ltrim(rtrim(ShouhinCD)),'') = '' then '商品CD未入力エラー' 
							when isnull(ltrim(rtrim(ColorRyakuName)),'') = '' then 'カラー未入力エラー' 
							when isnull(ltrim(rtrim(SizeNO)),'') = '' then 'サイズ未入力エラー' 
							when isnull(ltrim(rtrim(JANCD)),'') = '' then 'JANCD未入力エラー' 
							when isnull(ltrim(rtrim(HacchuuSuu)),'') = '' then '数量未入力エラー' 
							--when isnull(ltrim(rtrim(SenpouHacchuuNO)),'') = '' then '出荷指示番号未入力エラー' 	
							--when isnull(ltrim(rtrim(SiiresakiCD)),'') = '' then '出荷指示番号未入力エラー' 	
							when isnull(ltrim(rtrim(ChakuniYoteiDate)),'') = '' then '着荷予定日未入力エラー' 
							when isnull(ltrim(rtrim(SoukoCD)),'') = '' then '倉庫CD未入力エラー' 
							end
			where isnull(ltrim(rtrim(JuchuuDate)),'') = ''
			or isnull(ltrim(rtrim(TokuisakiCD)),'') = ''
			--or isnull(ltrim(rtrim(TokuisakiName)),'') = ''
			or isnull(ltrim(rtrim(KouritenCD)),'') = ''
			--or isnull(ltrim(rtrim(KouritenName)),'') = ''
			or isnull(ltrim(rtrim(StaffCD)),'') = ''
			or isnull(ltrim(rtrim(ShouhinCD)),'') = ''
			or isnull(ltrim(rtrim(ColorRyakuName)),'') = ''
			or isnull(ltrim(rtrim(SizeNO)),'') = ''
			or isnull(ltrim(rtrim(JANCD)),'') = ''
			or isnull(ltrim(rtrim(HacchuuSuu)),'') = ''
			--or isnull(ltrim(rtrim(SenpouHacchuuNO)),'') = ''
			--or isnull(ltrim(rtrim(SiiresakiCD)),'') = ''
			or isnull(ltrim(rtrim(ChakuniYoteiDate)),'') = ''
			or isnull(ltrim(rtrim(SoukoCD)),'') = ''
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end


			--Length Check
			update #Temp_Juchuu
			set ErrorFlg = 1,
				Error1 = case when datalength(TokuisakiCD) > 10 then '得意先CD桁数エラー'
							  --when datalength(TokuisakiName) > 80 then '得意先名桁数エラー'
							  when datalength(KouritenCD) > 10 then '小売店CD桁数エラー'
							  --when datalength(KouritenName) > 80 then '小売店名桁数エラー'
							  when datalength(StaffCD) > 10 then '担当スタッフCD桁数エラー'
							  when datalength(SenpouHacchuuNO) > 20 then '先方発注番号桁数エラー'
							  when datalength(ShouhinCD) > 20 then '商品CD桁数エラー'
							  when datalength(JANCD) > 13 then 'JANCD桁数エラー'
							  when datalength(SiiresakiCD) > 10 then '小売店CD桁数エラー'
							  --when datalength(SiiresakiName) > 80 then '小売店名桁数エラー'
							  when datalength(SenpouHacchuuNO)> 20 then '先方発注番号桁数エラー'
							  when datalength(SoukoCD) > 10 then '倉庫CD桁数エラー'
							end
			from #Temp_Juchuu
			where datalength(TokuisakiCD) > 10
			--or datalength(TokuisakiName) > 80
			or datalength(KouritenCD) > 10
			--or datalength(KouritenName) > 80
			or datalength(StaffCD) > 10
			or datalength(SenpouHacchuuNO) > 20
			or datalength(ShouhinCD) > 20
			or datalength(JANCD) > 13
			or datalength(SiiresakiCD) > 10
			--or datalength(SiiresakiName) >80
			or datalength(SenpouHacchuuNO) > 20
			or datalength(SoukoCD) > 10

			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end


			--Input Value Check
			update #Temp_Juchuu
			set ErrorFlg = 1,
				Error1 = '入力可能値外エラー',
				Error2 = case 
				            when isdate(isnull(nullif(ltrim(rtrim(JuchuuDate)),''),'2100-01-01')) = 0 then '入力可能値外エラー'
							  when isdate(isnull(nullif(ltrim(rtrim(KibouNouki)),''),'2100-01-01')) = 0 then 'bb'
							  when isdate(isnull(nullif(ltrim(rtrim(ChakuniYoteiDate)),''),'2100-01-01')) = 0 then 'cc'
							  when isnumeric(HacchuuSuu) = 0 then '入力可能値外エラー'
							  when isnumeric(SenpouHacchuuNO) = 0 then '入力可能値外エラー'
							  when isnumeric(UriageTanka) = 0 then '入力可能値外エラー'
						end 
			where 
			isdate(isnull(nullif(ltrim(rtrim(JuchuuDate)),''),'2100-01-01')) = 0
			or isdate(isnull(nullif(ltrim(rtrim(KibouNouki)),''),'2100-01-01')) = 0
			or isdate(isnull(nullif(ltrim(rtrim(ChakuniYoteiDate)),''),'2100-01-01')) = 0
			or isnumeric(HacchuuSuu) = 0
			or isnumeric(SenpouHacchuuNO) = 0
			or isnumeric(UriageTanka) = 0
		
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			--ShokutiFLG for M_Tokuisaki
			if exists(select * from M_Tokuisaki where ShokutiFLG=1)
				begin

				--Null error check
				update #Temp_Juchuu
				set ErrorFlg = 1,
				Error1 =case 
						when isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = '' then '得意先略名未入力エラー' 	
						when isnull(ltrim(rtrim(TokuisakiName)),'') = '' then '得意先名未入力エラー' 	
						end

						where isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = ''
						or isnull(ltrim(rtrim(TokuisakiName)),'') = ''

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

				--ShokutiFLG for M_Kouriten
			    if exists(select * from M_Kouriten where ShokutiFLG=1)
				begin

				--Null error check
				update #Temp_Juchuu
				set ErrorFlg = 1,
				Error1 =case 
						when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '小売店略名未入力エラー' 	
						when isnull(ltrim(rtrim(KouritenName)),'') = '' then '小売店名未入力エラー' 	
						end

						where isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''
						or isnull(ltrim(rtrim(KouritenName)),'') = ''

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

				--ShokutiFLG for M_Siiresaki
			    if exists(select * from M_Siiresaki where ShokutiFLG=1)
				begin

				--Null error check
				update #Temp_Juchuu
				set ErrorFlg = 1,
				Error1 =case 
						when isnull(ltrim(rtrim(SiiresakiRyakuName)),'') = '' then '仕入先略名未入力エラー' 	
						when isnull(ltrim(rtrim(SiiresakiName)),'') = '' then '仕入先名未入力エラー' 	
						end

						where isnull(ltrim(rtrim(SiiresakiRyakuName)),'') = ''
						or isnull(ltrim(rtrim(SiiresakiName)),'') = ''

				--Length Check
				update #Temp_Juchuu
				set ErrorFlg = 1,
					Error1 = case when datalength(SiiresakiRyakuName) > 40 then '仕入先略名桁数エラー'								 
								  when datalength(SiiresakiName) > 80 then '仕入先「名桁数エラー'
								end
				from #Temp_Juchuu
				where datalength(SiiresakiRyakuName) > 40
				or datalength(SiiresakiName) > 80				
				end

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

			update tmp
			set ErrorFlg =1,Error1=''
			from #Temp_Juchuu tmp
			where not exists(Select t.TokuisakiCD,t.TokuisakiName from F_Tokuisaki(getdate()) t where t.ShokutiFLG=1)


			update tmp
			set ErrorFlg = 1, Error1 = '小売店CD未登録エラー'			
			from #Temp_Juchuu tmp
			where not exists (select k.KouritenCD from F_Kouriten(getdate()) k where k.KouritenCD = tmp.KouritenCD)
			
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

			update tmp
			set ErrorFlg = 1, Error1 = '商品CD未登録エラー'
			from #Temp_Juchuu tmp
			where not exists (select h.ShouhinCD from F_Shouhin(getdate()) h where h.ShouhinCD = tmp.ShouhinCD)
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			update tmp
			set ErrorFlg = 1, Error1= 'JANCD未登録エラー'
			from #Temp_Juchuu tmp
			where not exists (select j.JANCD from F_Shouhin(getdate()) j where j.JANCD = tmp.JANCD)
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

			update tmp
			set ErrorFlg = 1, Error1= '仕入先CD未登録エラー'
			from #Temp_Juchuu tmp
			where not exists (select j.SiiresakiCD from F_Siiresaki(getdate()) j where j.SiiresakiCD = tmp.SiiresakiCD)
			
			if exists (select 1 from #Temp_Juchuu where ErrorFlg = 1)
			begin
				goto error
			end

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
					DROP TABLE #Temp_Hacchuu
					DROP TABLE #Temp_Juchuu
					return
				end
				process:
			BEGIN
				select '1' as Result
			
			END
		END

END