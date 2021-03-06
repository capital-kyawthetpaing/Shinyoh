BEGIN TRY 
 Drop Procedure dbo.[JuchuuTorikomi_CUD]
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
CREATE PROCEDURE [dbo].[JuchuuTorikomi_CUD]
@XML_Hacchuu as xml,
@XML_Jucchuu as xml,
@condition as varchar(20),
@DenyouNO  as varchar(30) 
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
							  SiiresakiJuusho1 varchar(50) COLLATE DATABASE_DEFAULT,
							  SiiresakiJuusho2 varchar(50) COLLATE DATABASE_DEFAULT,
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
				  SiiresakiJuusho1 varchar(50) 'SiiresakiJuusho1',
				  SiiresakiJuusho2 varchar(50) 'SiiresakiJuusho2',
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
						  JuchuuNO  varchar(12) COLLATE DATABASE_DEFAULT,
						  JuchuuDate date,
						  TokuisakiCD varchar(10) COLLATE DATABASE_DEFAULT,
						  TokuisakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
						  KouritenCD varchar(10) COLLATE DATABASE_DEFAULT,
						  KouritenRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
						  StaffCD varchar(10) COLLATE DATABASE_DEFAULT,
						  SenpouHacchuuNO varchar(20) COLLATE DATABASE_DEFAULT,
						  SenpouBusho varchar(20) COLLATE DATABASE_DEFAULT,
						  KibouNouki varchar(10)COLLATE DATABASE_DEFAULT,
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
						  TokuisakiJuusho1 varchar(50) COLLATE DATABASE_DEFAULT,
						  TokuisakiJuusho2 varchar(50) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-1] varchar(6) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO1-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-1]  varchar(6) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [TokuisakiTelNO2-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  KouritenName varchar(120) COLLATE DATABASE_DEFAULT,
						  KouritenYuubinNO1 varchar(3)COLLATE DATABASE_DEFAULT,
						  KouritenYuubinNO2 varchar(4) COLLATE DATABASE_DEFAULT,
						  KouritenJuusho1 varchar(50) COLLATE DATABASE_DEFAULT,
						  KouritenJuusho2 varchar(50) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-1] varchar(6) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO1-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-1]  varchar(6) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-2] varchar(5) COLLATE DATABASE_DEFAULT,
						  [KouritenTelNO2-3] varchar(5) COLLATE DATABASE_DEFAULT,
						  SiiresakiName varchar(120) COLLATE DATABASE_DEFAULT,
						  SiiresakiYuubinNO1 varchar(3)COLLATE DATABASE_DEFAULT,
						  SiiresakiYuubinNO2 varchar(4) COLLATE DATABASE_DEFAULT,
						  SiiresakiJuusho1 varchar(50) COLLATE DATABASE_DEFAULT,
						  SiiresakiJuusho2 varchar(50) COLLATE DATABASE_DEFAULT,
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
						  Error	varchar(10)
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
						  PC,
						  Error
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
						  TokuisakiName varchar(120) 'TokuisakiName',
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
						  KouritenJuusho1 varchar(50) 'KouritenJuusho1',
						  KouritenJuusho2 varchar(50) 'KouritenJuusho2',
						  [KouritenTelNO1-1] varchar(6) 'KouritenTelNO11',
						  [KouritenTelNO1-2] varchar(5) 'KouritenTelNO12',
						  [KouritenTelNO1-3] varchar(5) 'KouritenTelNO13',
						  [KouritenTelNO2-1]  varchar(6) 'KouritenTelNO21',
						  [KouritenTelNO2-2] varchar(5) 'KouritenTelNO22',
						  [KouritenTelNO2-3] varchar(5) 'KouritenTelNO23',
						  SiiresakiName varchar(120) 'SiiresakiName',
						  SiiresakiYuubinNO1 varchar(3) 'SiiresakiYuubinNO1',
						  SiiresakiYuubinNO2 varchar(4) 'SiiresakiYuubinNO2',
						  SiiresakiJuusho1 varchar(50) 'SiiresakiJuusho1',
						  SiiresakiJuusho2 varchar(50) 'SiiresakiJuusho2',
						  [SiiresakiTelNO1-1] varchar(6) 'SiiresakiTelNO11',
						  [SiiresakiTelNO1-2] varchar(5) 'SiiresakiTelNO12',
						  [SiiresakiTelNO1-3] varchar(5) 'SiiresakiTelNO13',
						  [SiiresakiTelNO2-1]  varchar(6) 'SiiresakiTelNO21',
						  [SiiresakiTelNO2-2] varchar(5) 'SiiresakiTelNO22',
						  [SiiresakiTelNO2-3] varchar(5) 'SiiresakiTelNO23',
						  HacchuuMeisaiTekiyou  varchar(80) 'HacchuuMeisaiTekiyou',
						  Operator varchar(10) 'Operator',
						  ProgramID	 varchar(100) 'ProgramID',
						  PC varchar(30) 'PC',
						  Error	varchar(10) 'Error'
						)
				EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

				DECLARE @fun_table TABLE (idx int Primary Key IDENTITY(1,1), HacchuuDate date,StaffCD varchar(10),ShouhinCD varchar(50),SoukoCD varchar(10),SiiresakiCD varchar(13),TokuisakiCD varchar(10),KouritenCD varchar(10),Operator varchar(10),ProgramID varchar(100),PC varchar(30),JuchuuNO  varchar(12))
				INSERT @fun_table SELECT distinct HacchuuDate,TH.StaffCD,TH.ShouhinCD,TH.SoukoCD,TH.SiiresakiCD,TJ.TokuisakiCD,TJ.KouritenCD,TH.Operator,TH.ProgramID,TH.PC,TJ.JuchuuNO FROM #Temp_Hacchuu TH inner join #Temp_Juchuu TJ on TH.JuchuuNO=TJ.JuchuuNO
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

				if @condition='create_update'
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
				DHM.JANCD,
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
							
				 exec dbo.L_Log_Insert @Operator,@ProgramID,@PC,@OperateMode,@TorikomiDenpyouNO
				
				End
				
				Else if @condition='delete'
				begin
				
				
				--DECLARE @fun_table1 TABLE (idx int Primary Key IDENTITY(1,1), JuchuuNO varchar(12))
				--			INSERT @fun_table1 SELECT distinct JuchuuNO FROM #Temp_Hacchuu
				--			declare @s_Count1 as int =(SELECT COUNT(*) FROM @fun_table)
				--			declare @i_Count1 as int = 0
				--			declare @slip_NO as varchar(12)
				--			WHILE @i_Count1 < @s_Count1
							BEGIN
							   set @slip_NO = (SELECT JuchuuNO FROM @fun_table WHERE idx = (@i_Count+1))
							   exec dbo.Fnc_Hikiate 1,@slip_NO,30,@Operator
							   SET @i_Count1 = @i_Count1 + 1
							END;
				--Delete D_HacchuuMeisai
				Delete A
				From D_HacchuuMeisai A
				Inner Join D_Juchuu B
				on A.JuchuuNO=B.JuchuuNO
				Where B.TorikomiDenpyouNO=@DenyouNO
				
				--Delete D_Hacchuu
				Delete A
				From D_Hacchuu A
				Inner Join D_Juchuu B
				On A.JuchuuNO=B.JuchuuNo
				Where B.TorikomiDenpyouNO=@DenyouNO

				--Insert Sheet C
				Insert Into D_HacchuuHistory
				
				Select 
				@Unique,
				DH.HacchuuNO,
				30,
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
				DH.DenpyouSiireHontaiKingaku*(-1),
				DH.DenpyouSiireHenpinHontaiKingaku*(-1),
				DH.DenpyouSiireNebikiHontaiKingaku*(-1),
				DH.DenpyouSiireShouhizeiGaku*(-1),
				DH.DenpyouSiireShouhizeiGakuTuujou*(-1),
				DH.DenpyouSiireShouhizeiGakuKeigen*(-1),
				DH.DenpyouJoudaiHontaiKingaku*(-1),
				DH.DenpyouJoudaiShouhizeiGaku*(-1),
				DH.DenpyouGaikaSiireHontaiKingaku*(-1),
				DH.DenpyouGaikaSiireHenpinHontaiKingaku*(-1),
				DH.DenpyouGaikaSiireNebikiHontaiKingaku*(-1),
				DH.DenpyouGaikaSiireShouhizeiGaku*(-1),
				DH.DenpyouGaikaJoudaiHontaiKingaku*(-1),
				DH.DenpyouGaikaJoudaiShouhizeiGaku*(-1),
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
				TH.Operator,
				@currentDate
				from D_Hacchuu DH inner join #Temp_Hacchuu TH on DH.HacchuuNO=TH.HacchuuNO

				--Insert Sheet D
				Insert into D_HacchuuMeisaiHistory
				
				Select 
				@Unique,
				DHM.HacchuuNO,
				DHM.HacchuuGyouNO,
				DHM.GyouHyouziJun,
				30,
				DHM.BrandCD,
				DHM.ShouhinCD,
				DHM.ShouhinName,
				DHM.JANCD,
				DHM.ColorRyakuName,
				DHM.ColorNO,
				DHM.SizeNO,
				DHM.Kakeritu,
				DHM.HacchuuSuu*(-1),
				DHM.TaniCD,
				DHM.HacchuuTanka*(-1),
				DHM.HacchuuTankaShouhizei*(-1),
				DHM.HacchuuTankaShouhizeiTuujou*(-1),
				DHM.HacchuuTankaShouhizeiKeigen*(-1),
				DHM.HacchuuHontaiTanka*(-1),
				DHM.HacchuuKingaku*(-1),
				DHM.HacchuuHontaiKingaku*(-1),
				DHM.HacchuuShouhizeiGaku*(-1),
				DHM.HacchuuShouhizeiGakuTuujou*(-1),
				DHM.HacchuuShouhizeiGakuKeigen*(-1),
				DHM.HacchuuShouhizeiChouseiGaku*(-1),
				DHM.GaikaHacchuuTanka*(-1),
				DHM.GaikaHacchuuTankaShouhizei*(-1),
				DHM.GaikaHacchuuHontaiTanka*(-1),
				DHM.GaikaHacchuuKingaku*(-1),
				DHM.GaikaHacchuuHontaiKingaku*(-1),
				DHM.GaikaHacchuuShouhizeiGaku*(-1),
				DHM.GaikaHacchuuShouhizeiChouseiGaku*(-1),
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
				TH.Operator,
				@currentDate
				From D_HacchuuMeisai DHM Inner Join  #Temp_Hacchuu TH on DHM.HacchuuNO=TH.HacchuuNO

				--Delete D_JuchuuShousai
				Delete A
				from D_JuchuuShousai A
				Inner Join D_Juchuu B
				ON A.JuchuuNO=B.JuchuuNO
				Where B.TorikomiDenpyouNO=@DenyouNO
				
				--Delete D_JuchuuMeisai
				Delete A
				from D_JuchuuMeisai A
				Inner Join D_Juchuu B
				ON A.JuchuuNO=B.JuchuuNO
				Where B.TorikomiDenpyouNO=@DenyouNO
				
				--Delete D_Juchuu
				Delete A
				from D_Juchuu A
				Where A.TorikomiDenpyouNO=@DenyouNO
				
				Declare @OperateMode1 varchar(50)='Delete'
				   	   exec dbo.L_Log_Insert @Operator,@ProgramID,@PC,@OperateMode1,@DenyouNO
				
				
				Delete from D_Exclusive where DataKBN = 1 and Number = @JuchuuNO
				End
END
