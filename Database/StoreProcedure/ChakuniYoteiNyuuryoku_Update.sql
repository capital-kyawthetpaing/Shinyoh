BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_Update]
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
ALTER PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Update]
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
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
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
					HacchuuGyouNO varchar(12) COLLATE DATABASE_DEFAULT
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		 INSERT INTO #Temp_Detail
         (
		   ShouhinCD,
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
		   HacchuuGyouNO
		 )
		 SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShouhinCD				varchar(50) 'ShouhinCD',
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
					HacchuuGyouNO               varchar(12) 'HacchuuGyouNO'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

declare @filter_date as date = (select ChakuniYoteiDate from #Temp_Main)
declare @StaffCD varchar(10) = (select StaffCD from #Temp_Main)
declare @ShouhinCD varchar(50)=(select ShouhinCD from #Temp_Main)
declare @SoukoCD varchar(10)=(select SoukoCD from #Temp_Main)
declare @Siiresaki varchar(13)=(select SiiresakiCD from #Temp_Main)
Declare @Operator varchar(10) =(select Operator from #Temp_Main)
--Update Sheet A
Update D_ChakuniYotei
	SET 
	StaffCD=m.StaffCD,
	KanriNO=m.KanriNO,
	ChakuniYoteiDate=convert(varchar(10), m.ChakuniYoteiDate, 111),
	KaikeiYYMM=CONVERT(INT, FORMAT(Cast(m.ChakuniYoteiDate as Date), 'yyyyMM')),
	SoukoCD=m.SoukoCD,
	SiiresakiCD=m.SiiresakiCD,
	SiiresakiRyakuName=CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,
	TuukaCD=0,
	RateKBN=1,
	SiireRate=1,
	ChakuniYoteiDenpyouTekiyou=m.ChakuniYoteiDenpyouTekiyou,
	ChakuniKanryouKBN=0,
	SiireKanryouKBN=0,
	SiiresakiName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
	SiiresakiYuubinNO1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
	SiiresakiYuubinNO2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
	SiiresakiJuusho1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
	SiiresakiJuusho2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
	[SiiresakiTelNO1-1]= CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.[SiiresakiTelNO1-1] END,
	[SiiresakiTelNO1-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.[SiiresakiTelNO1-2] END,
	[SiiresakiTelNO1-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.[SiiresakiTelNO1-3] END,
	[SiiresakiTelNO2-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.[SiiresakiTelNO2-1] END,
	[SiiresakiTelNO2-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.[SiiresakiTelNO2-2] END,
	[SiiresakiTelNO2-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.[SiiresakiTelNO2-3] END,
	SiiresakiTantouBushoName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE Null END,
	SiiresakiTantoushaYakushoku=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE Null END,
	SiiresakiTantoushaName=	CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE Null END,
	InsertOperator=@Operator,
	InsertDateTime=@currentDate,
	UpdateOperator=@Operator,
	UpdateDateTime=@currentDate
	 from #Temp_Main m 
	 LEFT OUTER JOIN F_Siiresaki(getdate()) FS on FS.SiiresakiCD=m.SiiresakiCD
	 where D_ChakuniYotei.ChakuniYoteiNO=m.ChakuniYoteiNO

	 --Update Sheet B
	 Update D_ChakuniYoteiMeisai
	 SET 
	 ChakuniYoteiGyouNO=CASE WHEN d.ChakuniYoteiGyouNO=ChakuniYoteiGyouNO THEN d.ChakuniYoteiGyouNO ELSE (select MAX(ChakuniYoteiGyouNO)+1 from D_ChakuniYoteiMeisai group by ChakuniYoteiGyouNO) End,
	 GyouHyouziJun=(Select ROW_NUMBER() OVER(ORDER BY (SELECT 1))),
	 KanriNO=m.KanriNO,
	 BrandCD=FS.BrandCD,
	 ShouhinCD=TD.ShouhinCD,
	 ShouhinName=TD.ShouhinName,
	 JANCD=TD.JanCD,
	 ColorRyakuName=TD.ColorRyakuName,
	 ColorNO=TD.ColorNO,
	 SizeNO=TD.SizeNO,
	 ChakuniYoteiSuu=TD.ChakuniYoteiSuu,
	 TaniCD=FS.TaniCD,
	 ChakuniYoteiMeisaiTekiyou=TD.ChakuniYoteiMeisaiTekiyou,
	 ChakuniKanryouKBN=0,
	 SiireKanryouKBN=0,
	 ChakuniZumiSuu=0,
	 SiireZumiSuu=0,
	 HacchuuNO=DCY.HacchuuNO,
	 HacchuuGyouNO=DCY.HacchuuGyouNO,
	 JuchuuNO=DCY.JuchuuNO,
	 JuchuuGyouNO=DCY.JuchuuGyouNO,
	 UpdateOperator=m.Operator,
	 UpdateDateTime=@currentdate
     from  D_ChakuniYoteiMeisai as d,#Temp_Main m ,#Temp_Detail TD
	 inner Join D_HacchuuMeisai DCY on DCY.HacchuuNO=TD.HacchuuNO
	                                     and DCY.HacchuuGyouNO=TD.HacchuuGyouNO
	 Left Outer Join F_Shouhin(@filter_date) FS on FS.ShouhinCD=TD.ShouhinCD
	 Where d.ChakuniYoteiNO=m.ChakuniYoteiNO

--Insert 削除または修正前(Before deletion or modification)table C
Insert Into D_ChakuniYoteiHistory

select 
@Unique,dc.ChakuniYoteiNO,21,dc.StaffCD,dc.KanriNO,dc.ChakuniYoteiDate,dc.KaikeiYYMM,dc.SoukoCD,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.TuukaCD,dc.RateKBN,dc.SiireRate,dc.ChakuniYoteiDenpyouTekiyou,dc.ChakuniKanryouKBN,dc.SiireKanryouKBN,dc.SiiresakiName,
dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
dc.SiiresakiTantouBushoName,dc.SiiresakiTantoushaYakushoku,dc.SiiresakiTantoushaName,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,m.Operator,@currentDate
from D_ChakuniYotei dc,#Temp_Main m where dc.ChakuniYoteiNO=m.ChakuniYoteiNO

--Insert 削除または修正前(Before deletion or modification)table D
Insert into D_ChakuniYoteiMeisaiHistory

Select 
@Unique,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.GyouHyouziJun,21,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniYoteiSuu,dc.TaniCD,dc.ChakuniYoteiMeisaiTekiyou,dc.ChakuniKanryouKBN,dc.SiireKanryouKBN,
dc.ChakuniZumiSuu,dc.SiireZumiSuu,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_ChakuniYoteiMeisai dc,#Temp_Main m where dc.ChakuniYoteiNO=m.ChakuniYoteiNO

--Insert 新規または修正後(New or Revised) table C
declare @Unique_20 as uniqueidentifier = NewID()
Insert Into D_ChakuniYoteiHistory

select 
@Unique_20,dc.ChakuniYoteiNO,20,dc.StaffCD,dc.KanriNO,dc.ChakuniYoteiDate,dc.KaikeiYYMM,dc.SoukoCD,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.TuukaCD,dc.RateKBN,dc.SiireRate,dc.ChakuniYoteiDenpyouTekiyou,dc.ChakuniKanryouKBN,dc.SiireKanryouKBN,dc.SiiresakiName,
dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
dc.SiiresakiTantouBushoName,dc.SiiresakiTantoushaYakushoku,dc.SiiresakiTantoushaName,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,m.Operator,@currentDate
from D_ChakuniYotei dc,#Temp_Main m where dc.ChakuniYoteiNO=m.ChakuniYoteiNO

--Insert 新規または修正後(New or Revised)table D
Insert into D_ChakuniYoteiMeisaiHistory

Select 
@Unique_20,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.GyouHyouziJun,20,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniYoteiSuu,dc.TaniCD,dc.ChakuniYoteiMeisaiTekiyou,dc.ChakuniKanryouKBN,dc.SiireKanryouKBN,
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

--Update UseFlg M_Siiresaki
update M_Siiresaki 
set UsedFlg = 1 
where ChangeDate = (select ChangeDate from F_Siiresaki(@filter_date) where SiiresakiCD = @Siiresaki)

--Update UseFlg M_Shouhin
update M_Shouhin
set UsedFlg = 1 
where ChangeDate = (select ChangeDate from F_Shouhin(@filter_date) where ShouhinCD = @ShouhinCD)

--Update UseFlg M_Souko
update M_Souko
set UsedFlg = 1 
where SoukoCD = @SoukoCD

--Update UseFlg M_Staff
Update M_Staff
set UsedFlg=1
where ChangeDate = (select ChangeDate from F_Staff(@filter_date) where StaffCD = @StaffCD)

--Insert table Z
            declare	@InsertOperator  varchar(10) = (select m.Operator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
		    declare @OperateMode     varchar(50) = 'Update' 
		    declare @KeyItem         varchar(100)= (select m.ChakuniYoteiNO from #Temp_Main m)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

--D_Exclusive X
            Delete from D_Exclusive where DataKBN = 16 and Number = (select ChakuniYoteiNO from #Temp_Main) 
--D_Exclusive Y
            Delete from D_Exclusive where DataKBN = 2 and Number = (select ChakuniYoteiNO from #Temp_Main) 

Drop table #Temp_Main
Drop table #Temp_Detail

END
