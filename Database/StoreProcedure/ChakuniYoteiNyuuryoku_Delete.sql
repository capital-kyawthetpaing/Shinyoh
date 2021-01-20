BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_Delete]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Shweeainsan
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Delete]
@XML_Main as xml,
@XML_Detail as xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  DECLARE  @hQuantityAdjust AS INT 
    declare @currentDate as datetime = getdate()
    declare @Unique as uniqueidentifier = NewID()

	CREATE TABLE #Temp_Main
				(   
				  ChakuniYoteiNO varchar(12) COLLATE DATABASE_DEFAULT,
				  ChakuniYoteiDate varchar(10) COLLATE DATABASE_DEFAULT,
				  SiiresakiCD varchar(10) COLLATE DATABASE_DEFAULT,
				  SiiresakiName varchar(120) COLLATE DATABASE_DEFAULT,
				  SiiresakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
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
				  StaffCD varchar(10) COLLATE DATABASE_DEFAULT,
				  SoukoCD varchar(10) COLLATE DATABASE_DEFAULT,
				  KanriNO varchar(10) COLLATE DATABASE_DEFAULT,	
				  ChakuniYoteiDenpyouTekiyou varchar(80) COLLATE DATABASE_DEFAULT,
				  BrandCD  varchar(10) COLLATE DATABASE_DEFAULT,
				  ShouhinCD	varchar(50) COLLATE DATABASE_DEFAULT,
				  ShouhinName  varchar(100) COLLATE DATABASE_DEFAULT,	
				  JANCD	varchar(13) COLLATE DATABASE_DEFAULT,	
				  YearTerm varchar(6) COLLATE DATABASE_DEFAULT,	
				  SeasonSS	varchar(6) COLLATE DATABASE_DEFAULT,	
				  SeasonFW varchar(6) COLLATE DATABASE_DEFAULT,	
				  ColorNO varchar(13) COLLATE DATABASE_DEFAULT,
				  ChakuniYoteiDateFrom varchar(10) COLLATE DATABASE_DEFAULT,
				  ChakuniYoteiDateTo varchar(10) COLLATE DATABASE_DEFAULT,
				  SizeNO	 varchar(13) COLLATE DATABASE_DEFAULT,
				  Operator varchar(10) COLLATE DATABASE_DEFAULT,
				  PC varchar(20) COLLATE DATABASE_DEFAULT,
				  ProgramID	 varchar(100)
				)
				EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

				INSERT INTO #Temp_Main
             (ChakuniYoteiNO
			  ,ChakuniYoteiDate          
			  ,SiiresakiCD          
			  ,SiiresakiName
			  ,SiiresakiRyakuName
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
			  ,StaffCD                
			  ,SoukoCD                
			  ,KanriNO                
			  ,ChakuniYoteiDenpyouTekiyou     
			  ,BrandCD  
			  ,ShouhinCD               
			  ,ShouhinName 
			  ,JANCD       
			  ,YearTerm            
			  ,SeasonSS    
			  ,SeasonFW
			  ,ColorNO 
			  ,ChakuniYoteiDateFrom
			  ,ChakuniYoteiDateTo
			  ,SizeNO   
			  ,Operator    
			  ,PC
			  ,ProgramID
			  )

			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
				  ChakuniYoteiNO	varchar(12) 'ChakuniYoteiNO',
				  ChakuniYoteiDate varchar(10) 'ChakuniYoteiDate',
				  SiiresakiCD varchar(10) 'SiiresakiCD',
				  SiiresakiName varchar(120) 'SiiresakiName',
				  SiiresakiRyakuName varchar(40) 'SiiresakiRyakuName',
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
				  StaffCD varchar(10)  'StaffCD',
				  SoukoCD varchar(10)  'SoukoCD',
				  KanriNO varchar(10) 'KanriNO',
				  ChakuniYoteiDenpyouTekiyou varchar(80) 'ChakuniYoteiDenpyouTekiyou',
				  BrandCD  varchar(10) 'BrandCD',
				  ShouhinCD	varchar(50) 'ShouhinCD',
				  ShouhinName  varchar(100) 'ShouhinName',	
				  JANCD	varchar(13) 'JANCD',
				  YearTerm varchar(6) 'YearTerm',	
				  SeasonSS	varchar(6) 'SeasonSS',	
				  SeasonFW varchar(6) 'SeasonFW',	
				  ColorNO varchar(13) 'ColorNO',
				  ChakuniYoteiDateFrom varchar(10) 'ChakuniYoteiDateFrom',
				  ChakuniYoteiDateTo varchar(10) 'ChakuniYoteiDateTo',
				  SizeNO	 varchar(13) 'SizeNO',
				  Operator varchar(10) 'Operator',
				  PC varchar(20) 'PC',
				  ProgramID	 varchar(100) 'ProgramID'
				)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Main

		CREATE TABLE #Temp_Detail
				(   
					HinbanCD				varchar(20) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					ColorRyakuName				varchar(25) COLLATE DATABASE_DEFAULT,
					ColorNO				varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO				varchar(13) COLLATE DATABASE_DEFAULT,
					HacchuuDate			   varchar(10) COLLATE DATABASE_DEFAULT,
					HacchuuSuu       varchar(20) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiZumiSuu            varchar(20) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiSuu				varchar(20) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiMeisaiTekiyou  varchar(80) COLLATE DATABASE_DEFAULT,
					JANCD	 varchar(13) COLLATE DATABASE_DEFAULT,
					HacchuuNO varchar(12)  COLLATE DATABASE_DEFAULT,
					HacchuuGyouNO varchar(12) COLLATE DATABASE_DEFAULT,
					ShouhinCD	varchar(50) COLLATE DATABASE_DEFAULT
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		 INSERT INTO #Temp_Detail
         (
		   HinbanCD,
		   ShouhinName,
		   ColorRyakuName,
		   ColorNO,
		   SizeNO,
		   HacchuuDate,
		   HacchuuSuu,
		   ChakuniYoteiZumiSuu,
		   ChakuniYoteiSuu,
		   ChakuniYoteiMeisaiTekiyou,
		   JANCD,
		   HacchuuNO,
		   HacchuuGyouNO,
		   ShouhinCD
		 )
		 SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					HinbanCD				varchar(50) 'HinbanCD',
					ShouhinName				varchar(100) 'ShouhinName',
					ColorRyakuName				varchar(25) 'ColorRyakuName',
					ColorNO				varchar(13) 'ColorNO',
					SizeNO				varchar(13) 'SizeNO',
					HacchuuDate			varchar(10) 'HacchuuDate',
					HacchuuSuu       varchar(20)'HacchuuSuu',
					ChakuniYoteiZumiSuu             varchar(20) 'ChakuniYoteiZumiSuu',
					ChakuniYoteiSuu				varchar(20) 'ChakuniYoteiSuu',
					ChakuniYoteiMeisaiTekiyou varchar(80) 'ChakuniYoteiMeisaiTekiyou',
					JanCD               varchar(13) 'JanCD',
					HacchuuNO varchar(12) 'HacchuuNO',
					HacchuuGyouNO               varchar(12) 'HacchuuGyouNO',
					ShouhinCD				varchar(50) 'ShouhinCD'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

declare @filter_date as date = (select ChakuniYoteiDate from #Temp_Main)
Declare @Operator varchar(10) =(select Operator from #Temp_Main)
--Delete Sheet A
        Delete A
		from D_ChakuniYotei A
		Where A.ChakuniYoteiNO IN (select ChakuniYoteiNO from #Temp_Main)
--Delete Sheet B
        Delete A
		from D_ChakuniYoteiMeisai A
		Where A.ChakuniYoteiNO IN (select ChakuniYoteiNO from #Temp_Main)
--Insert Sheet D
        Insert into D_ChakuniYoteiMeisaiHistory

        Select 
        @Unique,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.GyouHyouziJun,30,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniYoteiSuu,dc.TaniCD,dc.ChakuniYoteiMeisaiTekiyou,dc.ChakuniKanryouKBN,dc.SiireKanryouKBN,
        dc.ChakuniZumiSuu,dc.SiireZumiSuu,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
        from D_ChakuniYoteiMeisai dc,#Temp_Main m where dc.ChakuniYoteiNO=m.ChakuniYoteiNO

--Update D_ChakuniYoteiMeisai(for 菫ｮ豁｣蜑阪∪縺溘・蜑企勁)
Update D_HacchuuMeisai
SET ChakuniYoteiZumiSuu=CASE WHEN CAST(d.ChakuniYoteiZumiSuu AS DECIMAL(21, 0))>0 THEN CAST(d.ChakuniYoteiZumiSuu AS DECIMAL(21, 0)) ElSE 0 END
From D_HacchuuMeisai 
Inner  Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=D_HacchuuMeisai.HacchuuNO
                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=D_HacchuuMeisai.HacchuuGyouNO,#Temp_Detail d,#Temp_Main m
Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=m.ChakuniYoteiNO

 --Update D_ChakuniYoteiMeisai(for 霑ｽ蜉縺ｾ縺溘・菫ｮ豁｣蠕)
Update a
SET a.ChakuniZumiSuu=a.ChakuniYoteiZumiSuu+d.ChakuniYoteiZumiSuu,
    UpdateOperator=@Operator,
	UpdateDateTime=@currentDate
From D_HacchuuMeisai a
Inner  Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=a.HacchuuNO
                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=a.HacchuuGyouNO,#Temp_Detail d,#Temp_Main m
Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=m.ChakuniYoteiNO

--Update D_HacchuuMeisai
Update D_HacchuuMeisai
Set ChakuniYoteiKanryouKBN=Case When D_HacchuuMeisai.HacchuuSuu<=D_HacchuuMeisai.ChakuniYoteiZumiSuu
Then 1 
else 0
End
From D_HacchuuMeisai,#Temp_Detail td
Where D_HacchuuMeisai.HacchuuNO=td.HacchuuNO

--Update D_Hacchuu
Update A
Set A.ChakuniYoteiKanryouKBN=B.ChakuniYoteiKanryouKBN
From D_Hacchuu A
Inner Join (Select C.HacchuuNO,MIN(ChakuniYoteiKanryouKBN)　ChakuniYoteiKanryouKBN
From D_HacchuuMeisai C,#Temp_Detail d
Where C.HacchuuNO=d.HacchuuNO
Group by C.HacchuuNO
)B
ON A.HacchuuNO=B.HacchuuNO

--Insert table Z
            declare	@InsertOperator  varchar(10) = (select m.Operator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
		    declare @OperateMode     varchar(50) = 'Delete' 
		    declare @KeyItem         varchar(100)= (select m.ChakuniYoteiNO from #Temp_Main m)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

--Delete D_Exclusive table
            DECLARE @HacchuuNO_table TABLE (idx int Primary Key IDENTITY(1,1), HacchuuNO varchar(20))
			INSERT @HacchuuNO_table SELECT distinct HacchuuNO FROM #Temp_Detail
			declare @Count as int = 1
			WHILE @Count <= (SELECT COUNT(*) FROM @HacchuuNO_table)
			BEGIN
			  DELETE A 
			  From D_Exclusive A
			  where A.DataKBN=16
			  and A.Number=(select HacchuuNO from @HacchuuNO_table WHERE idx =@Count)
		     SET @Count = @Count + 1
			END;


Drop table #Temp_Main
Drop table #Temp_Detail

END
GO
