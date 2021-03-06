/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Update]    Script Date: 2021/05/19 15:47:14 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniNyuuryoku_Update%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniNyuuryoku_Update]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Update]    Script Date: 2021/05/19 15:47:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- History    : 2021/05/11 Y.Nishikawa 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）
--            : 2021/06/14 Y.Nishikawa 改定日直近の意味をはきちがえてる
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_Update]
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
                  ShouhinCD varchar(50) COLLATE DATABASE_DEFAULT,
                  ShouhinName  varchar(100) COLLATE DATABASE_DEFAULT,   
                  KanriNO varchar(10) COLLATE DATABASE_DEFAULT, 
                  JANCD varchar(13) COLLATE DATABASE_DEFAULT,   
                  BrandCD  varchar(10) COLLATE DATABASE_DEFAULT,
                  YearTerm varchar(6) COLLATE DATABASE_DEFAULT, 
                  SeasonSS  varchar(6) COLLATE DATABASE_DEFAULT,    
                  SeasonFW varchar(6) COLLATE DATABASE_DEFAULT, 
                  ColorNO varchar(13) COLLATE DATABASE_DEFAULT,
                  SizeNO     varchar(13) COLLATE DATABASE_DEFAULT,
                  Operator varchar(10) COLLATE DATABASE_DEFAULT,
                  --UpdateOperator varchar(10) COLLATE DATABASE_DEFAULT,
                  PC varchar(20) COLLATE DATABASE_DEFAULT,
                  ProgramID  varchar(100)
                )
                EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

            INSERT INTO #Temp_Main
             (
              ChakuniNO
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
              ,PC
              ,ProgramID
              )

              SELECT ChakuniNO,ChakuniDate,SiiresakiCD,SiiresakiName,SiiresakiRyakuName,NULLIF(SiiresakiYuubinNO1,''),NULLIF(SiiresakiYuubinNO2,''),NULLIF(SiiresakiJuusho1,''),NULLIF(SiiresakiJuusho2,''),
              NULLIF([SiiresakiTelNO1-1],''),NULLIF([SiiresakiTelNO1-2],''),NULLIF([SiiresakiTelNO1-3],''),NULLIF([SiiresakiTelNO2-1],''),NULLIF([SiiresakiTelNO2-2],''),NULLIF([SiiresakiTelNO2-3],''),StaffCD,SoukoCD,
              NULLIF(ChakuniDenpyouTekiyou,''),ChakuniYoteiNO,ShouhinCD,ShouhinName,KanriNO,JANCD,BrandCD,YearTerm,SeasonSS,SeasonFW,ColorNO,SizeNO,Operator,PC,ProgramID
                    FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
                    WITH
                    (
                  ChakuniNO varchar(12) 'ChakuniNO',
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
                  ShouhinCD varchar(50) 'ShouhinCD',
                  ShouhinName  varchar(100) 'ShouhinName',  
                  KanriNO varchar(10) 'KanriNO',    
                  JANCD varchar(13) 'JANCD',    
                  BrandCD  varchar(10) 'BrandCD',
                  YearTerm varchar(6) 'YearTerm',   
                  SeasonSS  varchar(6) 'SeasonSS',  
                  SeasonFW varchar(6) 'SeasonFW',   
                  ColorNO varchar(13) 'ColorNO',
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
                    ChakuniYoteiDate               varchar(10) COLLATE DATABASE_DEFAULT,
                    ChakuniYoteiSuu       varchar(20) COLLATE DATABASE_DEFAULT,
                    ChakuniZumiSuu            varchar(20) COLLATE DATABASE_DEFAULT,
                    ChakuniSuu              varchar(20) COLLATE DATABASE_DEFAULT,
                    SiireKanryouKBN      varchar(10) COLLATE DATABASE_DEFAULT,
                    ChakuniMeisaiTekiyou  varchar(80) COLLATE DATABASE_DEFAULT,
                    JANCD    varchar(13) COLLATE DATABASE_DEFAULT,
                    ChakuniYoteiNO varchar(12)  COLLATE DATABASE_DEFAULT,
                    ChakuniYoteiGyouNO varchar(12)COLLATE DATABASE_DEFAULT,
                    HacchuuNO varchar(12)  COLLATE DATABASE_DEFAULT,
                    HacchuuGyouNO varchar(12) COLLATE DATABASE_DEFAULT,
                    ShouhinCD varchar(50) COLLATE DATABASE_DEFAULT,
                    ChakuniGyouNO   smallint 
                )
        EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

         INSERT INTO #Temp_Detail
         ( 
           HinbanCD,
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
           HacchuuGyouNO,
           ShouhinCD,
           ChakuniGyouNO
         )

         SELECT HinbanCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,ChakuniYoteiSuu,ChakuniZumiSuu,ChakuniSuu,SiireKanryouKBN,NULLIF(ChakuniMeisaiTekiyou,''),
         JanCD,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,ShouhinCD,ChakuniGyouNO
                    FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
                    WITH
                    (
                    HinbanCD                varchar(20) 'HinbanCD',
                    ShouhinName             varchar(100) 'ShouhinName',
                    ColorRyakuName              varchar(25) 'ColorNO',
                    ColorNO             varchar(13) 'ColorNO',
                    SizeNO              varchar(13) 'SizeNO',
                    ChakuniYoteiDate            varchar(10) 'ChakuniYoteiDate',
                    ChakuniYoteiSuu       varchar(20)'ChakuniYoteiSuu',
                    ChakuniZumiSuu             varchar(20) 'ChakuniZumiSuu',
                    ChakuniSuu              varchar(20) 'ChakuniSuu',
                    SiireKanryouKBN      varchar(10) 'SiireKanryouKBN',
                    ChakuniMeisaiTekiyou varchar(80) 'ChakuniMeisaiTekiyou',
                    JanCD               varchar(13) 'JANCD',
                    ChakuniYoteiNO     varchar(12) 'ChakuniYoteiNO',
                    ChakuniYoteiGyouNO              varchar(12) 'ChakuniYoteiGyouNO',
                    HacchuuNO varchar(12) 'HacchuuNO',
                    HacchuuGyouNO               varchar(12) 'HacchuuGyouNO',
                    ShouhinCD   varchar(50) 'ShouhinCD',
                    ChakuniGyouNO      smallint 'ChakuniGyouNO'
                    )
        EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

        --SELECT * FROM #Temp_Detail

declare @filter_date as date = (select ChakuniDate from #Temp_Main)
declare @StaffCD varchar(10) = (select StaffCD from #Temp_Main)
declare @ShouhinCD varchar(50)=(select ShouhinCD from #Temp_Main)
declare @SoukoCD varchar(10)=(select SoukoCD from #Temp_Main)
declare @Siiresaki varchar(13)=(select SiiresakiCD from #Temp_Main)
declare @Operator varchar(10)=(select Operator from #Temp_Main)
declare @ChakuniNO varchar(100)=(select ChakuniNO from #Temp_Main )

--ktp cancel update
exec dbo.Fnc_Hikiate 5,@ChakuniNO,20,@Operator


--ktp cancel update

    --Update D_ChakuniYoteiMeisai(for 修正前または削除)
    Update D_ChakuniYoteiMeisai
    SET ChakuniZumiSuu=CASE WHEN D_ChakuniYoteiMeisai.ChakuniZumiSuu - D_ChakuniMeisai.ChakuniSuu>0 
                            THEN D_ChakuniYoteiMeisai.ChakuniZumiSuu - D_ChakuniMeisai.ChakuniSuu 
                            ElSE 0 END
        ,UpdateOperator=@Operator
        ,UpdateDateTime=@currentdate
    From D_ChakuniMeisai  
    Where D_ChakuniMeisai.ChakuniNO=@ChakuniNO
    and D_ChakuniMeisai.ChakuniYoteiNO=D_ChakuniYoteiMeisai.ChakuniYoteiNO
    and D_ChakuniMeisai.ChakuniYoteiGyouNO=D_ChakuniYoteiMeisai.ChakuniYoteiGyouNO
    ;

	Update D_ChakuniYoteiMeisai
    SET ChakuniKanryouKBN=CASE WHEN D_ChakuniYoteiMeisai.ChakuniYoteiSuu - D_ChakuniYoteiMeisai.ChakuniZumiSuu>0 
                               THEN 0 
                               ElSE 1 END
    From D_ChakuniMeisai  
    Where D_ChakuniMeisai.ChakuniNO=@ChakuniNO
    and D_ChakuniMeisai.ChakuniYoteiNO=D_ChakuniYoteiMeisai.ChakuniYoteiNO
    and D_ChakuniMeisai.ChakuniYoteiGyouNO=D_ChakuniYoteiMeisai.ChakuniYoteiGyouNO
    ;

    --Update D_HacchuuMeisai(for 修正前または削除)
    --Update D_HacchuuMeisai
    --SET ChakuniZumiSuu=CASE WHEN D_HacchuuMeisai.ChakuniZumiSuu- D_ChakuniMeisai.ChakuniSuu>0 THEN D_HacchuuMeisai.ChakuniZumiSuu - D_ChakuniMeisai.ChakuniSuu ElSE 0 END
    --From D_ChakuniYoteiMeisai 
    --Inner Join D_ChakuniMeisai on D_ChakuniMeisai.ChakuniYoteiNO=D_ChakuniYoteiMeisai.ChakuniYoteiNO
    --                          and D_ChakuniMeisai.ChakuniYoteiGyouNO=D_ChakuniYoteiMeisai.ChakuniYoteiGyouNO
    --Where D_ChakuniMeisai.ChakuniNO=@ChakuniNO
    --and D_ChakuniYoteiMeisai.HacchuuNO=D_HacchuuMeisai.HacchuuNO
    --and D_ChakuniYoteiMeisai.HacchuuGyouNO=D_HacchuuMeisai.HacchuuGyouNO
    --;
	Update DHAM
    SET ChakuniZumiSuu=CASE WHEN DHAM.ChakuniZumiSuu- DCKM.ChakuniSuu>0 THEN DHAM.ChakuniZumiSuu - DCKM.ChakuniSuu ElSE 0 END
    From D_HacchuuMeisai DHAM
	Inner Join ( SELECT D_ChakuniMeisai.HacchuuNO
				       ,D_ChakuniMeisai.HacchuuGyouNO
					   ,SUM(D_ChakuniMeisai.ChakuniSuu) ChakuniSuu
	             FROM D_ChakuniMeisai 
                 Where D_ChakuniMeisai.ChakuniNO=@ChakuniNO
				 Group By D_ChakuniMeisai.HacchuuNO
				         ,D_ChakuniMeisai.HacchuuGyouNO
			   ) DCKM
	ON DCKM.HacchuuNO=DHAM.HacchuuNO
    and DCKM.HacchuuGyouNO=DHAM.HacchuuGyouNO
    ;

	Update DHAM
    SET ChakuniKanryouKBN=CASE WHEN DHAM.ChakuniYoteiZumiSuu- DHAM.ChakuniZumiSuu>0 THEN 0 ElSE 1 END
    From D_HacchuuMeisai DHAM
	Inner Join ( SELECT D_ChakuniMeisai.HacchuuNO
				       ,D_ChakuniMeisai.HacchuuGyouNO
					   ,SUM(D_ChakuniMeisai.ChakuniSuu) ChakuniSuu
	             FROM D_ChakuniMeisai 
                 Where D_ChakuniMeisai.ChakuniNO=@ChakuniNO
				 Group By D_ChakuniMeisai.HacchuuNO
				         ,D_ChakuniMeisai.HacchuuGyouNO
			   ) DCKM
	ON DCKM.HacchuuNO=DHAM.HacchuuNO
    and DCKM.HacchuuGyouNO=DHAM.HacchuuGyouNO
    ;
    
    --Sheet A update
    Update D_Chakuni
    SET StaffCD=m.StaffCD,
        KanriNO=m.KanriNO,
        ChakuniDate=convert(varchar(10), m.ChakuniDate, 111),
        KaikeiYYMM=CONVERT(INT, FORMAT(Cast(m.ChakuniDate as Date), 'yyyyMM')),
        SoukoCD=m.SoukoCD,
        SiiresakiCD=m.SiiresakiCD,
        SiiresakiRyakuName=CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,
        TuukaCD=0,
        RateKBN=1,
        SiireRate=1,
        ChakuniDenpyouTekiyou=m.ChakuniDenpyouTekiyou,
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
        SiiresakiTantoushaName= CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE Null END,
        InsertOperator=@Operator,
        InsertDateTime=@currentDate,
        UpdateOperator=@Operator,
        UpdateDateTime=@currentDate
     from #Temp_Main m 
	 --2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
	 --LEFT OUTER JOIN F_Siiresaki(getdate()) FS on FS.SiiresakiCD=m.SiiresakiCD
	 LEFT OUTER JOIN F_Siiresaki(@filter_date) FS on FS.SiiresakiCD=m.SiiresakiCD
	 --2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
     where D_Chakuni.ChakuniNO=m.ChakuniNO

     --Update Sheet B
     Update D_ChakuniMeisai
     SET 
         KanriNO=DCY.KanriNO,
         BrandCD=FS.BrandCD,
         ShouhinCD=TD.ShouhinCD,
         ShouhinName=TD.ShouhinName,
         JANCD=TD.JanCD,
         ColorRyakuName=TD.ColorRyakuName,
         ColorNO=TD.ColorNO,
         SizeNO=TD.SizeNO,
         ChakuniSuu=TD.ChakuniSuu,	--ChakuniZumiSuu, 2020/4/20 chg
         TaniCD=FS.TaniCD,
         ChakuniMeisaiTekiyou=TD.ChakuniMeisaiTekiyou,
         SiireKanryouKBN=0,
         SiireZumiSuu=0,
         ChakuniYoteiNO=DCY.ChakuniYoteiNO,
         ChakuniYoteiGyouNO=DCY.ChakuniYoteiGyouNO,
         HacchuuNO=DCY.HacchuuNO,
         HacchuuGyouNO=DCY.HacchuuGyouNO,
         JuchuuNO=DCY.JuchuuNO,
         JuchuuGyouNO=DCY.JuchuuGyouNO,
         UpdateOperator=@Operator,
         UpdateDateTime=@currentdate
    from  #Temp_Main m ,#Temp_Detail TD
     inner Join D_ChakuniYoteiMeisai DCY on DCY.ChakuniYoteiNO=TD.ChakuniYoteiNO
                                         and DCY.ChakuniYoteiGyouNO=TD.ChakuniYoteiGyouNO
     Left Outer Join F_Shouhin(@filter_date) FS on FS.ShouhinCD=TD.ShouhinCD
      Where  D_ChakuniMeisai.ChakuniNO=@ChakuniNO
     AND D_ChakuniMeisai.ChakuniGyouNO=TD.ChakuniGyouNO
     ;

    --行削除分をDelete
    Delete From D_ChakuniMeisai
    Where not exists(Select 1 From #Temp_Detail AS TD Where TD.ChakuniGyouNO = D_ChakuniMeisai.ChakuniGyouNO And D_ChakuniMeisai.ChakuniNO = @ChakuniNO)
    And D_ChakuniMeisai.ChakuniNO = @ChakuniNO
    ;
 
     --表示順を振り直し
    UPDATE M
    SET M.GyouHyouziJun = S.RowNum
    FROM D_ChakuniMeisai AS M
    INNER JOIN (
                SELECT ChakuniNO, ChakuniGyouNO, ROW_NUMBER() OVER(ORDER BY ChakuniGyouNO) AS RowNum
                FROM D_ChakuniMeisai
                WHERE ChakuniNO = @ChakuniNO
            )AS S
            ON M.ChakuniNO = S.ChakuniNO
            AND M.ChakuniGyouNO = S.ChakuniGyouNO
    WHERE M.ChakuniNO=@ChakuniNO

    Insert into D_ChakuniMeisai
    Select @ChakuniNO,
        (select MAX(ChakuniGyouNO) from D_ChakuniMeisai Where ChakuniNO = @ChakuniNO group by ChakuniNO) + ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
        (select MAX(GyouHyouziJun) from D_ChakuniMeisai Where ChakuniNO = @ChakuniNO group by ChakuniNO) + ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
        dcm.KanriNO,fs.BrandCD,d.ShouhinCD,d.ShouhinName,d.JanCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,
        d.ChakuniSuu,fs.TaniCD,d.ChakuniMeisaiTekiyou,0,0,
        dcm.ChakuniYoteiNO,
        dcm.ChakuniYoteiGyouNO,
        dcm.HacchuuNO,dcm.HacchuuGyouNO,dcm.JuchuuNO,dcm.JuchuuGyouNO,m.Operator,@currentDate,@Operator,@currentDate
        from #Temp_Main m , #Temp_Detail d
    --2021/04/20 Y.Nishikawa CHG 着荷明細が作成されない↓↓
    --inner  join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=d.ChakuniYoteiGyouNO
    inner  join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=d.ChakuniYoteiNO
    and dcm.ChakuniYoteiGyouNO=d.ChakuniYoteiGyouNO
    --2021/04/20 Y.Nishikawa CHG 着荷明細が作成されない↑↑
    Left outer join F_Shouhin(@filter_date) fs on fs.ShouhinCD=d.ShouhinCD
    Where not exists(Select 1 From D_ChakuniMeisai Where d.ChakuniGyouNO = D_ChakuniMeisai.ChakuniGyouNO
                                                    And D_ChakuniMeisai.ChakuniNO = @ChakuniNO)
    ;
    
    --Insert Table C(20 Insert)
    declare @Unique_20 as uniqueidentifier = NewID()
    Insert into D_ChakuniHistory(HistoryGuid,ChakuniNO,ShoriKBN,StaffCD,KanriNO,ChakuniDate,KaikeiYYMM,SoukoCD,SiiresakiCD,SiiresakiRyakuName,TuukaCD,RateKBN,SiireRate,ChakuniDenpyouTekiyou,
SiireKanryouKBN,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],[SiiresakiTelNO2-2],
[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

select 
@Unique_20,dc.ChakuniNO,20,dc.StaffCD,dc.KanriNO,dc.ChakuniDate,dc.KaikeiYYMM,dc.SoukoCD,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.TuukaCD,dc.RateKBN,dc.SiireRate,dc.ChakuniDenpyouTekiyou,dc.SiireKanryouKBN,dc.SiiresakiName,
dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
dc.SiiresakiTantouBushoName,dc.SiiresakiTantoushaYakushoku,dc.SiiresakiTantoushaName,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_Chakuni dc inner join #Temp_Main m on dc.ChakuniNO=m.ChakuniNO

--Insert Table D(Before Modification)
Insert into D_ChakuniMeisaiHistory(HistoryGuid,ChakuniNO,ChakuniGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ChakuniSuu,TaniCD,ChakuniMeisaiTekiyou,
SiireKanryouKBN,SiireZumiSuu,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

Select @Unique_20,dc.ChakuniNO,dc.ChakuniGyouNO,dc.GyouHyouziJun,20,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniSuu,dc.TaniCD,dc.ChakuniMeisaiTekiyou,dc.SiireKanryouKBN,
dc.SiireZumiSuu,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_ChakuniMeisai dc Inner join #Temp_Main m on dc.ChakuniNO=m.ChakuniNO


--Insert table C(New or revised)
Insert into D_ChakuniHistory(HistoryGuid,ChakuniNO,ShoriKBN,StaffCD,KanriNO,ChakuniDate,KaikeiYYMM,SoukoCD,SiiresakiCD,SiiresakiRyakuName,TuukaCD,RateKBN,SiireRate,ChakuniDenpyouTekiyou,
SiireKanryouKBN,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],[SiiresakiTelNO2-2],
[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

select 
@Unique,dc.ChakuniNO,21,dc.StaffCD,dc.KanriNO,dc.ChakuniDate,dc.KaikeiYYMM,dc.SoukoCD,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.TuukaCD,dc.RateKBN,dc.SiireRate,dc.ChakuniDenpyouTekiyou,dc.SiireKanryouKBN,dc.SiiresakiName,
dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
dc.SiiresakiTantouBushoName,dc.SiiresakiTantoushaYakushoku,dc.SiiresakiTantoushaName,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_Chakuni dc inner join #Temp_Main m on dc.ChakuniNO=m.ChakuniNO

--Insert Table D(New or revised)
Insert into D_ChakuniMeisaiHistory(HistoryGuid,ChakuniNO,ChakuniGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ChakuniSuu,TaniCD,ChakuniMeisaiTekiyou,
SiireKanryouKBN,SiireZumiSuu,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

Select @Unique,dc.ChakuniNO,dc.ChakuniGyouNO,dc.GyouHyouziJun,21,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniSuu,dc.TaniCD,dc.ChakuniMeisaiTekiyou,dc.SiireKanryouKBN,
dc.SiireZumiSuu,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_ChakuniMeisai dc Inner join #Temp_Main m on dc.ChakuniNO=m.ChakuniNO
--from D_ChakuniMeisai dc,#Temp_Main m where dc.ChakuniNO=m.ChakuniNO

--Update D_ChakuniYoteiMeisai(for 追加または修正後)
Update a
SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniSuu,
    UpdateOperator=@Operator,
    UpdateDateTime=@currentDate
From D_ChakuniYoteiMeisai a
Inner  Join D_ChakuniMeisai on D_ChakuniMeisai.ChakuniYoteiNO=a.ChakuniYoteiNO---ses
                          and D_ChakuniMeisai.ChakuniYoteiGyouNO=a.ChakuniYoteiGyouNO
INNER JOIN #Temp_Detail d ON d.ChakuniYoteiNO=a.ChakuniYoteiNO AND d.ChakuniYoteiGyouNO=a.ChakuniYoteiGyouNO
Where D_ChakuniMeisai.ChakuniNO=@ChakuniNO
;

--Update D_ChakuniYoteiMeisai
Update D_ChakuniYoteiMeisai
Set ChakuniKanryouKBN=Case When D_ChakuniYoteiMeisai.ChakuniYoteiSuu<=D_ChakuniYoteiMeisai.ChakuniZumiSuu
Then 1
--2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↓↓
--When  TD.SiireKanryouKBN='True'
When  TD.SiireKanryouKBN='1'
--2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↑↑
Then 1
Else 0
End
From D_ChakuniYoteiMeisai,#Temp_Detail TD
Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=TD.ChakuniYoteiNO
AND  D_ChakuniYoteiMeisai.ChakuniYoteiGyouNO=TD.ChakuniYoteiGyouNO
;

--Update D_ChakuniYotei
Update D_ChakuniYotei
Set D_ChakuniYotei.ChakuniKanryouKBN=C.ChakuniKanryouKBN
From D_ChakuniYotei 
INNER JOIN (
        Select D_ChakuniYoteiMeisai.ChakuniYoteiNO,MIN(D_ChakuniYoteiMeisai.ChakuniKanryouKBN) AS ChakuniKanryouKBN
        From D_ChakuniYoteiMeisai,#Temp_Detail TD
        Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=TD.ChakuniYoteiNO
        Group by D_ChakuniYoteiMeisai.ChakuniYoteiNO
        ) C
ON D_ChakuniYotei.ChakuniYoteiNO=C.ChakuniYoteiNO
;


--Update D_HacchuuMeisai(for 追加または修正後)
--Update a
--SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniSuu,
--    UpdateOperator=@Operator,
--    UpdateDateTime=@currentDate
--From D_HacchuuMeisai a
--Inner Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=a.HacchuuNO
--                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=a.HacchuuGyouNO
--INNER JOIN #Temp_Detail d ON d.ChakuniYoteiNO=D_ChakuniYoteiMeisai.ChakuniYoteiNO AND d.ChakuniYoteiGyouNO=D_ChakuniYoteiMeisai.ChakuniYoteiGyouNO
--;

--Update D_HacchuuMeisai
Update D_HacchuuMeisai
Set ChakuniKanryouKBN=Case When D_HacchuuMeisai.HacchuuSuu<=D_HacchuuMeisai.ChakuniZumiSuu
Then 1
--2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↓↓
--When  TD.SiireKanryouKBN='True'
When  TD.SiireKanryouKBN='1'
--2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↑↑
Then 1
Else 0
End,
ChakuniYoteiKanryouKBN=Case When D_HacchuuMeisai.HacchuuSuu<=D_HacchuuMeisai.ChakuniYoteiZumiSuu
Then 1
--2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↓↓
--When  TD.SiireKanryouKBN='True'
When  TD.SiireKanryouKBN='1'
--2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↑↑
Then 1
Else 0
End
From D_HacchuuMeisai,#Temp_Detail TD
Where D_HacchuuMeisai.HacchuuNO=TD.HacchuuNO
AND  D_HacchuuMeisai.HacchuuGyouNO=TD.HacchuuGyouNO
;

--Update D_Hacchuu
Update D_Hacchuu
Set D_Hacchuu.ChakuniKanryouKBN=DH.ChakuniKanryouKBN
   ,D_Hacchuu.ChakuniYoteiKanryouKBN=DH.ChakuniYoteiKanryouKBN
From D_Hacchuu 
INNER JOIN (
Select D_HacchuuMeisai.HacchuuNO
      ,MIN(D_HacchuuMeisai.ChakuniKanryouKBN) ChakuniKanryouKBN
	  ,MIN(D_HacchuuMeisai.ChakuniYoteiKanryouKBN) ChakuniYoteiKanryouKBN
From D_HacchuuMeisai,#Temp_Detail TD
Where D_HacchuuMeisai.HacchuuNO=TD.HacchuuNO
Group by D_HacchuuMeisai.HacchuuNO
) DH
ON D_Hacchuu.HacchuuNO=DH.HacchuuNO
;

exec dbo.Fnc_Hikiate 5,@ChakuniNO,21,@Operator
--Update UseFlg M_Siiresaki
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

--Insert table Z
declare @InsertOperator  varchar(10) = (select m.Operator from #Temp_Main m)
declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
declare @OperateMode     varchar(50) = 'Update' 
 declare @KeyItem         varchar(100)= (select m.ChakuniNO from #Temp_Main m)
            
exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem
--TableW_5ChakuniNO_Delete
EXEC [dbo].[D_Exclusive_Delete]
        5,
        @ChakuniNO;

--D_Exclusive X
            Delete from D_Exclusive where DataKBN = 16 and Number IN (select ChakuniYoteiNO from #Temp_Detail)
--D_Exclusive Y
            Delete from D_Exclusive where DataKBN = 2 and Number IN (select HacchuuNO from #Temp_Detail)

            Drop table #Temp_Main
            Drop table #Temp_Detail

END

GO


