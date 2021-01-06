 BEGIN TRY 
 Drop Procedure dbo.[ChakuniNyuuryoku_Insert]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Shwe Eain San
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_Insert]
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
				  ChakuniNO varchar(12) COLLATE DATABASE_DEFAULT,
				  ChakuniDate varchar(10) COLLATE DATABASE_DEFAULT,
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
				  ChakuniDenpyouTekiyou varchar(80) COLLATE DATABASE_DEFAULT,
				  ChakuniYoteiNO varchar(12) COLLATE DATABASE_DEFAULT,
				  ShouhinCD	varchar(50) COLLATE DATABASE_DEFAULT,
				  ShouhinName  varchar(100) COLLATE DATABASE_DEFAULT,	
				  KanriNO varchar(10) COLLATE DATABASE_DEFAULT,	
				  JANCD	varchar(13) COLLATE DATABASE_DEFAULT,	
				  BrandCD  varchar(10) COLLATE DATABASE_DEFAULT,
				  YearTerm varchar(6) COLLATE DATABASE_DEFAULT,	
				  SeasonSS	varchar(6) COLLATE DATABASE_DEFAULT,	
				  SeasonFW varchar(6) COLLATE DATABASE_DEFAULT,	
				  ColorNO varchar(13) COLLATE DATABASE_DEFAULT,
				  SizeNO	 varchar(13) COLLATE DATABASE_DEFAULT,
				  Operator varchar(10) COLLATE DATABASE_DEFAULT,
				  --UpdateOperator varchar(10) COLLATE DATABASE_DEFAULT,
				  PC varchar(20) COLLATE DATABASE_DEFAULT,
				  ProgramID	 varchar(100)
				)
				EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

			INSERT INTO #Temp_Main
             (ChakuniNO
			  ,ChakuniDate          
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
			  ,ChakuniDenpyouTekiyou                
			  ,ChakuniYoteiNO                
			  ,ShouhinCD               
			  ,ShouhinName          
			  ,KanriNO      
			  ,JANCD       
			  ,BrandCD  
			  ,YearTerm            
			  ,SeasonSS    
			  ,SeasonFW
			  ,ColorNO              
			  ,SizeNO   
			  ,Operator              
			  --,UpdateOperator   
			  ,PC
			  ,ProgramID
			  )

			  SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
				  ChakuniNO	varchar(12) 'ChakuniNO',
				  ChakuniDate varchar(10) 'ChakuniDate',
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
				  ChakuniDenpyouTekiyou varchar(80) 'ChakuniDenpyouTekiyou',
				  ChakuniYoteiNO varchar(12) 'ChakuniYoteiNO',
				  ShouhinCD	varchar(50) 'ShouhinCD',
				  ShouhinName  varchar(100) 'ShouhinName',	
				  KanriNO varchar(10) 'KanriNO',	
				  JANCD	varchar(13) 'JANCD',	
				  BrandCD  varchar(10) 'BrandCD',
				  YearTerm varchar(6) 'YearTerm',	
				  SeasonSS	varchar(6) 'SeasonSS',	
				  SeasonFW varchar(6) 'SeasonFW',	
				  ColorNO varchar(13) 'ColorNO',
				  SizeNO	 varchar(13) 'SizeNO',
				  Operator varchar(10) 'Operator',
				  --UpdateOperator varchar(10) 'UpdateOperator',
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
					ChakuniYoteiDate			   varchar(10) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiSuu       varchar(20) COLLATE DATABASE_DEFAULT,
					ChakuniZumiSuu            varchar(20) COLLATE DATABASE_DEFAULT,
					ChakuniSuu				varchar(20) COLLATE DATABASE_DEFAULT,
					SiireKanryouKBN      varchar(10) COLLATE DATABASE_DEFAULT,
					ChakuniMeisaiTekiyou  varchar(80) COLLATE DATABASE_DEFAULT,
					JANCD	 varchar(13) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiNO varchar(12)  COLLATE DATABASE_DEFAULT,
					ChakuniYoteiGyouNO varchar(12)COLLATE DATABASE_DEFAULT,
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
		   ChakuniYoteiDate,
		   ChakuniYoteiSuu,
		   ChakuniZumiSuu,
		   ChakuniSuu,
		   SiireKanryouKBN,
		   ChakuniMeisaiTekiyou,
		   JANCD,
		   ChakuniYoteiNO,
		   ChakuniYoteiGyouNO,
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
					ChakuniYoteiDate			varchar(10) 'ChakuniYoteiDate',
					ChakuniYoteiSuu       varchar(20)'ChakuniYoteiSuu',
					ChakuniZumiSuu             varchar(20) 'ChakuniZumiSuu',
					ChakuniSuu				varchar(20) 'ChakuniSuu',
					SiireKanryouKBN      varchar(10) 'SiireKanryouKBN',
					ChakuniMeisaiTekiyou varchar(80) 'ChakuniMeisaiTekiyou',
					JanCD               varchar(13) 'JanCD',
					ChakuniYoteiNO     varchar(12) 'ChakuniYoteiNO',
					ChakuniYoteiGyouNO              varchar(12) 'ChakuniYoteiGyouNO',
					HacchuuNO varchar(12) 'HacchuuNO',
					HacchuuGyouNO               varchar(12) 'HacchuuGyouNO'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

declare @filter_date as date = (select ChakuniDate from #Temp_Main)
declare @StaffCD varchar(10) = (select StaffCD from #Temp_Main)
declare @ShouhinCD varchar(50)=(select ShouhinCD from #Temp_Main)
declare @SoukoCD varchar(10)=(select SoukoCD from #Temp_Main)
declare @Siiresaki varchar(13)=(select SiiresakiCD from #Temp_Main)

--sheet A
Insert INTO D_Chakuni
Select
m.ChakuniNO,
m.StaffCD,
m.KanriNO,
m.ChakuniDate,
CONVERT(INT, FORMAT(Cast(m.ChakuniDate as Date), 'yyyyMM')),
m.SoukoCD,
m.SiiresakiCD,
CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,
0,
1,
1,
m.ChakuniDenpyouTekiyou,
0,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.[SiiresakiTelNO1-1] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.[SiiresakiTelNO1-2] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.[SiiresakiTelNO1-3] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.[SiiresakiTelNO2-1] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.[SiiresakiTelNO2-2] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.[SiiresakiTelNO2-3] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
m.Operator,@currentDate,m.Operator,@currentDate
from #Temp_Main m 
LEFT OUTER JOIN F_Siiresaki(@filter_date) FS on FS.SiiresakiCD=m.SiiresakiCD

--SheetB
Insert into D_ChakuniMeisai

	Select m.ChakuniNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),ROW_NUMBER() OVER(ORDER BY (SELECT 1)),dcm.KanriNO,fs.BrandCD,d.ShouhinCD,d.ShouhinName,d.JanCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,
	d.ChakuniSuu,fs.TaniCD,d.ChakuniMeisaiTekiyou,0,0,
	dcm.ChakuniYoteiNO,
	dcm.ChakuniYoteiGyouNO,
	dcm.HacchuuNO,dcm.HacchuuGyouNO,dcm.JuchuuNO,dcm.JuchuuGyouNO,m.Operator,@currentDate,m.Operator,@currentDate
	from #Temp_Main m , #Temp_Detail d
	inner   join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=d.ChakuniYoteiGyouNO--ses inner jon
	Left outer join F_Shouhin(@filter_date) fs on fs.ShouhinCD=d.ShouhinCD

--SheetC

Insert into D_ChakuniHistory(HistoryGuid,ChakuniNO,ShoriKBN,StaffCD,KanriNO,ChakuniDate,KaikeiYYMM,SoukoCD,SiiresakiCD,SiiresakiRyakuName,TuukaCD,RateKBN,SiireRate,ChakuniDenpyouTekiyou,
SiireKanryouKBN,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],[SiiresakiTelNO2-2],
[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

select 
@Unique,dc.ChakuniNO,10,dc.StaffCD,dc.KanriNO,dc.ChakuniDate,dc.KaikeiYYMM,dc.SoukoCD,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.TuukaCD,dc.RateKBN,dc.SiireRate,dc.ChakuniDenpyouTekiyou,dc.SiireKanryouKBN,dc.SiiresakiName,
dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
dc.SiiresakiTantouBushoName,dc.SiiresakiTantoushaYakushoku,dc.SiiresakiTantoushaName,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,m.Operator,@currentDate
from D_Chakuni dc,#Temp_Main m where dc.ChakuniNO=m.ChakuniNO

--Sheet D

Insert into D_ChakuniMeisaiHistory(HistoryGuid,ChakuniNO,ChakuniGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ChakuniSuu,TaniCD,ChakuniMeisaiTekiyou,
SiireKanryouKBN,SiireZumiSuu,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)


Select @Unique,dc.ChakuniNO,dc.ChakuniGyouNO,dc.GyouHyouziJun,10,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniSuu,dc.TaniCD,dc.ChakuniMeisaiTekiyou,dc.SiireKanryouKBN,
dc.SiireZumiSuu,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,m.Operator,@currentDate
from D_ChakuniMeisai dc inner join #Temp_Detail TD on dc.ChakuniNO=TD.ChakuniYoteiNO and  dc.ChakuniGyouNO=TD.ChakuniYoteiGyouNO,#Temp_Main m


--update table E
Update a
SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniZumiSuu,
    UpdateOperator=m.Operator,
	UpdateDateTime=@currentDate
From D_ChakuniYoteiMeisai a
Inner  Join D_ChakuniMeisai on D_ChakuniMeisai.ChakuniYoteiNO=a.ChakuniYoteiNO
                          and D_ChakuniMeisai.ChakuniYoteiGyouNO=a.ChakuniYoteiGyouNO,#Temp_Detail d,#Temp_Main m
Where D_ChakuniMeisai.ChakuniNO=m.ChakuniNO

--update D_ChakuniYoteiMeisai
Update  A
Set ChakuniKanryouKBN=Case When A.ChakuniYoteiSuu<=A.ChakuniZumiSuu
Then 1
When m.SiireKanryouKBN=1
Then 1
Else 0
End
From D_ChakuniYoteiMeisai A,#Temp_Detail m
Where A.ChakuniYoteiNO=m.ChakuniYoteiNO
and A.ChakuniYoteiGyouNO=m.ChakuniYoteiGyouNO

----update D_ChakuniYotei

Update A
Set A.ChakuniKanryouKBN=B.ChakuniKanryouKBN
From D_ChakuniYotei A
Inner Join (Select C.ChakuniYoteiNO,MIN(ChakuniKanryouKBN)　ChakuniKanryouKBN
From D_ChakuniYoteiMeisai C,#Temp_Detail d
Where C.ChakuniYoteiNO=d.ChakuniYoteiNO
Group by C.ChakuniYoteiNO
)B
ON A.ChakuniYoteiNO=B.ChakuniYoteiNO


 --Update Table F
 Update a
SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniZumiSuu,
    UpdateOperator=m.Operator,
	UpdateDateTime=@currentDate
From D_HacchuuMeisai a
Inner Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=a.HacchuuNO
                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=a.HacchuuGyouNO,#Temp_Detail d,#Temp_Main m
Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=m.ChakuniYoteiNO

 --Update D_HacchuuMeisai
 	Update	A	
	SET ChakuniKanryouKBN=B.ChakuniKanryouKBN
	From D_Hacchuu A
	INNER JOIN(Select DH.HacchuuNO,MIN(ChakuniKanryouKBN) ChakuniKanryouKBN
	from D_HacchuuMeisai DH,#Temp_Detail dt
	where DH.HacchuuNO=dt.HacchuuNO
	Group by DH.HacchuuNO
	)B
	ON A.HacchuuNO=B.HacchuuNO
	

--Insert table Z
declare	@InsertOperator  varchar(10) = (select m.Operator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
		   declare @OperateMode     varchar(50) = 'New' 
		   declare @KeyItem         varchar(100)= (select m.ChakuniNO from #Temp_Main m)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

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

--D_Exclusive X
			INSERT INTO D_Exclusive
				(DataKBN,Number,OperateDataTime,Operator,Program,PC)

			select  16,m.ChakuniNO,@currentDate,m.Operator,m.ProgramID,m.PC
			from #Temp_Main m 


Drop table #Temp_Main
Drop table #Temp_Detail

END



