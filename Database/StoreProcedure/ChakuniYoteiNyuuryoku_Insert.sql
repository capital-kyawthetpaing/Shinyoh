/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Insert]    Script Date: 2021/05/10 10:20:28 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniYoteiNyuuryoku_Insert%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Insert]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Insert]    Script Date: 2021/05/10 10:20:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,> 
-- History    : 2021/05/10 Y.Nishikawa Remake
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Insert]
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
				  --ChakuniYoteiNO varchar(12) COLLATE DATABASE_DEFAULT,
				  ChakuniYoteiDate varchar(10) COLLATE DATABASE_DEFAULT,
				  SiiresakiCD varchar(10) COLLATE DATABASE_DEFAULT,
				  SiiresakiName varchar(120) COLLATE DATABASE_DEFAULT,
				  SiiresakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
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
             (
			 --ChakuniYoteiNO
			   ChakuniYoteiDate          
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

		SELECT ChakuniYoteiDate,SiiresakiCD,SiiresakiName,SiiresakiRyakuName,NULLIF(SiiresakiYuubinNO1,''),NULLIF(SiiresakiYuubinNO2,''),NULLIF(SiiresakiJuusho1,''),NULLIF(SiiresakiJuusho2,''),			    
			   NULLIF([SiiresakiTelNO1-1],''),NULLIF([SiiresakiTelNO1-2],''),NULLIF([SiiresakiTelNO1-3],''),NULLIF([SiiresakiTelNO2-1],''),NULLIF([SiiresakiTelNO2-2],''),NULLIF([SiiresakiTelNO2-3],''),
			   StaffCD,SoukoCD,KanriNO,NULLIF(ChakuniYoteiDenpyouTekiyou,''),BrandCD,ShouhinCD,ShouhinName,JANCD,YearTerm,SeasonSS,SeasonFW,ColorNO,
			   ChakuniYoteiDateFrom,ChakuniYoteiDateTo,SizeNO,Operator,PC,ProgramID
		FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
				WITH
                (
              --ChakuniYoteiNO  varchar(12) 'ChakuniYoteiNO',
              ChakuniYoteiDate varchar(10) 'ChakuniYoteiDate',
              SiiresakiCD varchar(10) 'SiiresakiCD',
              SiiresakiName varchar(120) 'SiiresakiName',
              SiiresakiRyakuName varchar(40) 'SiiresakiRyakuName',
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
              StaffCD varchar(10)  'StaffCD',
              SoukoCD varchar(10)  'SoukoCD',
              KanriNO varchar(10) 'KanriNO',
              ChakuniYoteiDenpyouTekiyou varchar(80) 'ChakuniYoteiDenpyouTekiyou',
              BrandCD  varchar(10) 'BrandCD',
              ShouhinCD varchar(50) 'ShouhinCD',
              ShouhinName  varchar(100) 'ShouhinName',
              JANCD varchar(13) 'JANCD',
              YearTerm varchar(6) 'YearTerm',   
              SeasonSS  varchar(6) 'SeasonSS',  
              SeasonFW varchar(6) 'SeasonFW',   
              ColorNO varchar(13) 'ColorNO',
              ChakuniYoteiDateFrom varchar(10) 'ChakuniYoteiDateFrom',
              ChakuniYoteiDateTo varchar(10) 'ChakuniYoteiDateTo',
              SizeNO     varchar(13) 'SizeNO',
              Operator varchar(10) 'Operator',
              PC varchar(20) 'PC',
              ProgramID  varchar(100) 'ProgramID'
            )
        EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    --SELECT * FROM #Temp_Main

		CREATE TABLE #Temp_Detail
                (   
                    HinbanCD                varchar(20) COLLATE DATABASE_DEFAULT,
                    ShouhinName             varchar(100) COLLATE DATABASE_DEFAULT,
                    ColorRyakuName              varchar(25) COLLATE DATABASE_DEFAULT,
                    ColorNO             varchar(13) COLLATE DATABASE_DEFAULT,
                    SizeNO              varchar(13) COLLATE DATABASE_DEFAULT,
                    HacchuuDate            varchar(10) COLLATE DATABASE_DEFAULT,
                    HacchuuSuu       decimal(21,6) DEFAULT 0.0,
                    ChakuniYoteiZumiSuu            decimal(21,6) DEFAULT 0.0,
                    ChakuniYoteiSuu              decimal(21,6) DEFAULT 0.0,
                    ChakuniYoteiMeisaiTekiyou  varchar(80) COLLATE DATABASE_DEFAULT,
                    JANCD    varchar(13) COLLATE DATABASE_DEFAULT,
                    HacchuuNO varchar(12)  COLLATE DATABASE_DEFAULT,
                    HacchuuGyouNO smallint,
                    ShouhinCD    varchar(50) COLLATE DATABASE_DEFAULT
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
		 SELECT HinbanCD,ShouhinName,NULLIF(ColorRyakuName,''),ColorNO,SizeNO,HacchuuDate,HacchuuSuu,ChakuniYoteiZumiSuu,ChakuniYoteiSuu,
		 NULLIF(ChakuniYoteiMeisaiTekiyou,''),JanCD,HacchuuNO,HacchuuGyouNO,ShouhinCD
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
                    WITH
                    (
                    HinbanCD                varchar(20) 'HinbanCD',
                    ShouhinName             varchar(100) 'ShouhinName',
                    ColorRyakuName              varchar(25) 'ColorNO',
                    ColorNO             varchar(13) 'ColorNO',
                    SizeNO              varchar(13) 'SizeNO',
                    HacchuuDate         varchar(10) 'HacchuuDate',
                    HacchuuSuu       decimal(21,6) 'HacchuuSuu',
                    ChakuniYoteiZumiSuu             decimal(21,6) 'ChakuniYoteiZumiSuu',
                    ChakuniYoteiSuu             decimal(21,6) 'ChakuniYoteiSuu',
                    ChakuniYoteiMeisaiTekiyou varchar(80) 'ChakuniYoteiMeisaiTekiyou',
                    JanCD               varchar(13) 'JANCD',
                    HacchuuNO varchar(12) 'HacchuuNO',
                    HacchuuGyouNO               smallint 'HacchuuGyouNO',
                    ShouhinCD  varchar(50) 'ShouhinCD'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    --SELECT * FROM #Temp_Detail

declare @filter_date as date = (select ChakuniYoteiDate from #Temp_Main)
declare @StaffCD varchar(10) = (select StaffCD from #Temp_Main)
declare @ShouhinCD varchar(50)=(select ShouhinCD from #Temp_Main)
declare @SoukoCD varchar(10)=(select SoukoCD from #Temp_Main)
declare @Siiresaki varchar(13)=(select SiiresakiCD from #Temp_Main)
Declare @Operator varchar(10) =(select Operator from #Temp_Main)
declare @ChakuniYoteiNO as varchar(100)
EXEC [dbo].[Fnc_GetNumber]
            16,-------------in連番区分
            @filter_date,----in基準日
            0,-------inSEQNO
            @ChakuniYoteiNO OUTPUT

IF ISNULL(@ChakuniYoteiNO,'') = ''
            BEGIN
                print  '1' ;
            END

 ----Insert Sheet A
 Insert Into D_ChakuniYotei
 Select
    @ChakuniYoteiNO,
    m.StaffCD,
    m.KanriNO,
    m.ChakuniYoteiDate,
    CONVERT(INT, FORMAT(Cast(m.ChakuniYoteiDate as Date), 'yyyyMM')),
    m.SoukoCD,
    m.SiiresakiCD,
    CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,
    '0',
    1,
    1,
    m.ChakuniYoteiDenpyouTekiyou,
    0,
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

----Insert Sheet B
--2021/05/10 Y.Nishikawa ADD Remake↓↓
DECLARE @HacchuuNO  AS VARCHAR(12),
		@HacchuuGyouNO AS SMALLINT,
		@GyouNO AS SMALLINT = 1

	DECLARE cursorHacchuu CURSOR READ_ONLY
	FOR
	SELECT d.HacchuuNO
	      ,d.HacchuuGyouNO 
	FROM #Temp_Main m,#Temp_Detail d
    INNER JOIN D_HacchuuMeisai dhm 
	ON dhm.HacchuuNO = d.HacchuuNO
    AND dhm.HacchuuGyouNO = d.HacchuuGyouNO
	ORDER BY d.HacchuuNO
	        ,d.HacchuuGyouNO
	
	OPEN cursorHacchuu
	
	FETCH NEXT FROM cursorHacchuu INTO @HacchuuNO,@HacchuuGyouNO
	WHILE @@FETCH_STATUS = 0
		BEGIN
		--2021/05/10 Y.Nishikawa ADD Remake↑↑

Insert into D_ChakuniYoteiMeisai
    Select @ChakuniYoteiNO,
	    --2021/05/10 Y.Nishikawa CHG Remake↓↓
        --ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
        --ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
		@GyouNO,
        @GyouNO,
		--2021/05/10 Y.Nishikawa CHG Remake↑↑
        m.KanriNO,
        fs.BrandCD,
        d.ShouhinCD,
        d.ShouhinName,
        d.JANCD,
        d.ColorRyakuName,
        d.ColorNO,
        d.SizeNO,
        d.ChakuniYoteiSuu,
        fs.TaniCD,
        d.ChakuniYoteiMeisaiTekiyou,
        0,
        0,
        0,
        0,
        dhm.HacchuuNO,
        dhm.HacchuuGyouNO,
        dhm.JuchuuNO,
        dhm.JuchuuGyouNO,
        @Operator,
        @currentDate,
        @Operator,
        @currentDate
    from #Temp_Main m,#Temp_Detail d
    inner join D_HacchuuMeisai dhm on dhm.HacchuuNO=d.HacchuuNO
                                   and dhm.HacchuuGyouNO=d.HacchuuGyouNO
    Left outer join F_Shouhin(@filter_date) fs on fs.ShouhinCD=d.ShouhinCD
	--2021/05/10 Y.Nishikawa ADD Remake↓↓
	WHERE d.HacchuuNO = @HacchuuNO
	AND d.HacchuuGyouNO = @HacchuuGyouNO

	SET @GyouNO = @GyouNO + 1
	FETCH NEXT FROM cursorHacchuu INTO @HacchuuNO,@HacchuuGyouNO

		END
		
	CLOSE cursorHacchuu
	DEALLOCATE cursorHacchuu
--2021/05/10 Y.Nishikawa ADD Remake↑↑

--Insert History Table For SheetA
Insert Into D_ChakuniYoteiHistory

select 
@Unique,dc.ChakuniYoteiNO,10,dc.StaffCD,dc.KanriNO,dc.ChakuniYoteiDate,dc.KaikeiYYMM,dc.SoukoCD,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.TuukaCD,dc.RateKBN,dc.SiireRate,dc.ChakuniYoteiDenpyouTekiyou,dc.ChakuniKanryouKBN,dc.SiireKanryouKBN,dc.SiiresakiName,
dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
dc.SiiresakiTantouBushoName,dc.SiiresakiTantoushaYakushoku,dc.SiiresakiTantoushaName,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_ChakuniYotei dc,#Temp_Main m where dc.ChakuniYoteiNO=@ChakuniYoteiNO

--Insert History Table For SheetB
Insert into D_ChakuniYoteiMeisaiHistory

Select @Unique,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.GyouHyouziJun,10,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniYoteiSuu,dc.TaniCD,dc.ChakuniYoteiMeisaiTekiyou,dc.ChakuniKanryouKBN,dc.SiireKanryouKBN,
dc.ChakuniZumiSuu,dc.SiireZumiSuu,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_ChakuniYoteiMeisai dc,#Temp_Main m where dc.ChakuniYoteiNO=@ChakuniYoteiNO


--update table E
Update a
SET a.ChakuniYoteiZumiSuu=a.ChakuniYoteiZumiSuu + d.ChakuniYoteiSuu,
    UpdateOperator=@Operator,
	UpdateDateTime=@currentDate
From D_HacchuuMeisai a
Inner  Join D_ChakuniYoteiMeisai  d on d.HacchuuNO=a.HacchuuNO
                          and d.HacchuuGyouNO=a.HacchuuGyouNO
Where d.ChakuniYoteiNO=@ChakuniYoteiNO

--Update D_HacchuuMeisai
Update A 
SET ChakuniYoteiKanryouKBN = Case When A.HacchuuSuu <= A.ChakuniYoteiZumiSuu
                           Then 1
						   Else 0
						   End
From D_HacchuuMeisai A ,#Temp_Detail td
Where  A.HacchuuNO = td.HacchuuNO

--Update D_Hacchuu
Update A
Set A.ChakuniYoteiKanryouKBN=B.ChakuniYoteiKanryouKBN
From D_Hacchuu A
Inner Join (Select C.HacchuuNO,MIN(C.ChakuniYoteiKanryouKBN) As ChakuniYoteiKanryouKBN
From D_HacchuuMeisai C,#Temp_Detail d
Where C.HacchuuNO=d.HacchuuNO
Group by C.HacchuuNO
)B
ON A.HacchuuNO=B.HacchuuNO


----Update UseFlg M_Siiresaki
update M_Siiresaki 
set UsedFlg = 1 
where SiiresakiCD = @Siiresaki
and ChangeDate = (select ChangeDate from F_Siiresaki(@filter_date) where SiiresakiCD = @Siiresaki)

--Update UseFlg M_Shouhin
update M_Shouhin
set UsedFlg = 1 
where ShouhinCD = @ShouhinCD
and ChangeDate = (select ChangeDate from F_Shouhin(@filter_date) where ShouhinCD = @ShouhinCD)

--Update UseFlg M_Souko
update M_Souko
set UsedFlg = 1 
where SoukoCD = @SoukoCD

--Update UseFlg M_Staff
Update M_Staff
set UsedFlg=1
where StaffCD = @StaffCD
and ChangeDate = (select ChangeDate from F_Staff(@filter_date) where StaffCD = @StaffCD)

--Fnc_Hikiate
exec dbo.Fnc_Hikiate 16,@ChakuniYoteiNO,10,@Operator

--Insert table Z
            declare	@InsertOperator  varchar(10) = (select m.Operator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
		    declare @OperateMode     varchar(50) = 'New' 
		    declare @KeyItem         varchar(100)= (select @ChakuniYoteiNO from #Temp_Main m)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

--D_Exclusive X
			DECLARE @HacchuuNO_table TABLE (idx int Primary Key IDENTITY(1,1), HacchuuNO varchar(20))
			INSERT @HacchuuNO_table SELECT distinct HacchuuNO FROM #Temp_Detail
			declare @Count as int = 1
			WHILE @Count <= (SELECT COUNT(*) FROM @HacchuuNO_table)
			BEGIN
			 DELETE A 
			 From D_Exclusive A
			 where A.DataKBN=2
			 and A.Number=(select HacchuuNO from @HacchuuNO_table WHERE idx =@Count)
		SET @Count = @Count + 1
			END;

Drop table #Temp_Main
Drop table #Temp_Detail

END
GO


