/****** Object:  StoredProcedure [dbo].[ShukkasiziNyuuryoku_Insert]    Script Date: 2021/04/13 13:05:34 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ShukkasiziNyuuryoku_Insert%' and type like '%P%')
DROP PROCEDURE [dbo].[ShukkasiziNyuuryoku_Insert]
GO

/****** Object:  StoredProcedure [dbo].[ShukkasiziNyuuryoku_Insert]    Script Date: 2021/04/13 13:05:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Swe Swe
-- Create date: <19-01-2021>
-- Description:	<Description,,>
-- History    : 2021/04/13 Y.Nishikawa DEL 堷摉峏怴偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋
--              2021/04/14 Y.Nishikawa ADD TaskNO.0271
--                         Y.Nishikawa DEL 弌壸巜帵徻嵶棜楌偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋
--                         Y.Nishikawa CHG 偙偺帪揰偱偼庴拲柧嵶偺弌壸巜帵嵪悢偵崱夞弌壸巜帵悢傪峏怴偟偰偄側偄偺偱丄暘擺帪偼姰椆嬫暘偑姰椆偵側傜側偄
--                         Y.Nishikawa ADD 忦審晄懌乮忦審偵峴斣崋偑側偄偺偱丄庴拲柧嵶悢暘朿傟偰寁嶼偝傟傞乯
-- =============================================
CREATE  PROCEDURE [dbo].[ShukkasiziNyuuryoku_Insert]
	-- Add the parameters for the stored procedure here
@XML_Header as xml,
@XML_Detail as xml

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
declare  @idoc AS INT

CREATE TABLE  [dbo].[#Temp_Header]
				(   
				  [ShukkaSiziNO] varchar(12) COLLATE DATABASE_DEFAULT,
				  [StaffCD] varchar(10) COLLATE DATABASE_DEFAULT,
				  [ShukkaYoteiDate] varchar(10) COLLATE DATABASE_DEFAULT,
				  [DenpyouDate] varchar(10) COLLATE DATABASE_DEFAULT,
				  [TokuisakiCD] varchar(10) COLLATE DATABASE_DEFAULT,
					TokuisakiName		varchar(120) COLLATE DATABASE_DEFAULT,
					TokuisakiRyakuName	varchar(40) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO1  varchar(3) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO2  varchar(4) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho1	varchar(80) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho2    varchar(80) COLLATE DATABASE_DEFAULT,
					TokuisakiTel11    varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel12   varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel13   varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel21   varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel22   varchar(5) COLLATE DATABASE_DEFAULT,	
					TokuisakiTel23    varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenCD	    varchar(10) COLLATE DATABASE_DEFAULT,
					KouritenName	  varchar(120) COLLATE DATABASE_DEFAULT,
					KouritenRyakuName    varchar(40) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO1    varchar(3) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO2    varchar(4) COLLATE DATABASE_DEFAULT,
					KouritenJuusho1  varchar(80) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2	 varchar(80) COLLATE DATABASE_DEFAULT,
					KouritenTel11    varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel12	 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel13	 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel21   varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel22   varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel23   varchar(5) COLLATE DATABASE_DEFAULT,	
				  [ShukkaSiziDenpyouTekiyou] varchar(80) COLLATE DATABASE_DEFAULT,
				  [ShukkaSizishoHuyouKBN] varchar(5) COLLATE DATABASE_DEFAULT,
				  OperatorCD varchar(10) COLLATE DATABASE_DEFAULT,
				  PC varchar(20) COLLATE DATABASE_DEFAULT,
				  ProgramID	 varchar(100) COLLATE DATABASE_DEFAULT
				)
				EXEC sp_xml_preparedocument @idoc OUTPUT, @XML_Header

INSERT INTO [#Temp_Header]
		SELECT *  FROM openxml(@idoc,'/NewDataSet/test',2)
		with(
				[ShukkaSiziNO] varchar(12) ,
				[StaffCD] varchar(10) ,
				[ShukkaYoteiDate] varchar(10) ,
				[DenpyouDate] varchar(10) ,
				[TokuisakiCD] varchar(10) ,
				TokuisakiName	varchar(120) ,
				TokuisakiRyakuName	varchar(40) ,
				TokuisakiYuubinNO1  varchar(3) ,
				TokuisakiYuubinNO2  varchar(4) ,
				TokuisakiJuusho1	varchar(80) ,
				TokuisakiJuusho2    varchar(80) ,
				TokuisakiTel11     varchar(6) ,
				TokuisakiTel12     varchar(5) ,
				TokuisakiTel13      varchar(5) ,
				TokuisakiTel21		varchar(6) ,
				TokuisakiTel22      varchar(5) ,	
				TokuisakiTel23      varchar(5) ,	
				KouritenCD		  varchar(10) ,
				KouritenName	   varchar(120) ,
				KouritenRyakuName  varchar(40) ,
				KouritenYuubinNO1  varchar(3) ,
				KouritenYuubinNO2  varchar(4) ,
				KouritenJuusho1 varchar(80) ,
				KouritenJuusho2	varchar(80) ,
				KouritenTel11 varchar(6) ,	
				KouritenTel12 varchar(5) ,	
				KouritenTel13 varchar(5) ,	
				KouritenTel21  varchar(6) ,	
				KouritenTel22  varchar(5) ,	
				KouritenTel23  varchar(5) ,	
				[ShukkaSiziDenpyouTekiyou] varchar(80) ,
				[ShukkaSizishoHuyouKBN] varchar(5) ,
				OperatorCD varchar(10) ,
				PC varchar(20) ,
				ProgramID	 varchar(100))
		exec sp_xml_removedocument @idoc


CREATE TABLE  [dbo].[#Temp_Details]
				(	[ShouhinCD]			varchar(25) COLLATE DATABASE_DEFAULT,
					[ShouhinName]		varchar(100) COLLATE DATABASE_DEFAULT,
					[ColorRyakuName]	varchar(25) COLLATE DATABASE_DEFAULT,
					[ColorNO]			varchar(13) COLLATE DATABASE_DEFAULT,
					[SizeNO]			varchar(13)  COLLATE DATABASE_DEFAULT,
					[JuchuuSuu]			varchar(30)  COLLATE DATABASE_DEFAULT,
					[ShukkanouSuu]		varchar(30)  COLLATE DATABASE_DEFAULT,
					[ShukkaSiziZumiSuu] varchar(30)  COLLATE DATABASE_DEFAULT,
					[KonkaiShukkaSiziSuu]		varchar(30)  COLLATE DATABASE_DEFAULT,
					[UriageTanka]		varchar(30)  COLLATE DATABASE_DEFAULT,
					[UriageKingaku]		varchar(15)  COLLATE DATABASE_DEFAULT,
					[Kanryo]			varchar(2)  COLLATE DATABASE_DEFAULT,
					[SKMSNO]			varchar(25)  COLLATE DATABASE_DEFAULT,
					[ShukkaSiziMeisaiTekiyou]varchar(80)  COLLATE DATABASE_DEFAULT,
					[SoukoCD]			varchar(10)  COLLATE DATABASE_DEFAULT,
					[SoukoName]			varchar(50)  COLLATE DATABASE_DEFAULT,
					[TokuisakiCD]		varchar(10)  COLLATE DATABASE_DEFAULT,
					[KouritenCD]		varchar(10)  COLLATE DATABASE_DEFAULT,
					KouritenRyakuName    varchar(40) COLLATE DATABASE_DEFAULT,
					KouritenName	  varchar(120) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO1    varchar(3) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO2    varchar(4) COLLATE DATABASE_DEFAULT,
					KouritenJuusho1  varchar(80) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2	 varchar(80) COLLATE DATABASE_DEFAULT,
					KouritenTel11    varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel12	 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel13	 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel21   varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel22   varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel23   varchar(5) COLLATE DATABASE_DEFAULT,
					Hidden_ShouhinCD varchar(50) COLLATE DATABASE_DEFAULT,
					--2021/04/14 Y.Nishikawa ADD TaskNO.0271伀伀
					ShukkaSiziGyouNO smallint
					--2021/04/14 Y.Nishikawa ADD TaskNO.0271仾仾
				)
				EXEC sp_xml_preparedocument @idoc OUTPUT, @XML_Detail

INSERT INTO [#Temp_Details]
			SELECT *  FROM openxml(@idoc,'/NewDataSet/test',2)
			with(	
					[ShouhinCD]			varchar(25),
					[ShouhinName]		varchar(100),
					[ColorRyakuName]	varchar(25),
					[ColorNO]			varchar(13),
					[SizeNO]			varchar(13) ,
					[JuchuuSuu]			varchar(30) ,
					[ShukkanouSuu]		varchar(30) ,
					[ShukkaSiziZumiSuu] varchar(30),
					[KonkaiShukkaSiziSuu]varchar(30) ,
					[UriageTanka]		varchar(30) ,
					[UriageKingaku]		varchar(15) ,
					[Kanryo]			varchar(2) ,
					[SKMSNO]			varchar(25) ,
					[ShukkaSiziMeisaiTekiyou]varchar(80) ,
					[SoukoCD]			varchar(10) ,
					[SoukoName]			varchar(50) ,
					[TokuisakiCD]		varchar(10) ,
					[KouritenCD]		varchar(10) ,
					KouritenRyakuName    varchar(40),
					KouritenName	  varchar(120),
					KouritenYuubinNO1    varchar(3),
					KouritenYuubinNO2    varchar(4),
					KouritenJuusho1  varchar(80),
					KouritenJuusho2	 varchar(80),
					KouritenTel11    varchar(6),	
					KouritenTel12	 varchar(5),	
					KouritenTel13	 varchar(5),	
					KouritenTel21   varchar(6),	
					KouritenTel22   varchar(5),	
					KouritenTel23   varchar(5),
					Hidden_ShouhinCD varchar(50),
					--2021/04/14 Y.Nishikawa ADD TaskNO.0271伀伀
					ShukkaSiziGyouNO smallint
					--2021/04/14 Y.Nishikawa ADD TaskNO.0271仾仾
				)
				exec sp_xml_removedocument @idoc

declare @ShippingDate as varchar(10) = (select ShukkaYoteiDate from #Temp_Header)
, @ShukkaSiziNO varchar(100) -- =(select ShukkaSiziNO from #Temp_Header)
, @StaffCD varchar(20) = (select StaffCD from #Temp_Header)
, @OperatorCD as varchar(10) =(select OperatorCD from #Temp_Header)
, @Program varchar(100) = (select ProgramID from #Temp_Header)
,@PC       varchar(30) = (select PC from #Temp_Header)
, @currentDate as datetime = getdate()
, @Unique as uniqueidentifier = NewID()

exec Fnc_GetNumber'12',@ShippingDate,0,@ShukkaSiziNO output

--TabelA
INSERT INTO [dbo].[D_ShukkaSizi]
						(ShukkaSiziNO
						,StaffCD
						,ShukkaYoteiDate
						,DenpyouDate
						,KaikeiYYMM
						,TokuisakiCD
						,TokuisakiRyakuName
						,KouritenCD
						,KouritenRyakuName
						,ShukkaSiziDenpyouTekiyou
						,ShukkaSizishoHuyouKBN
						,ShukkaKanryouKBN
						,TokuisakiName
						,TokuisakiYuubinNO1
						,TokuisakiYuubinNO2
						,TokuisakiJuusho1
						,TokuisakiJuusho2
						,[TokuisakiTelNO1-1]
						,[TokuisakiTelNO1-2]
						,[TokuisakiTelNO1-3]
						,[TokuisakiTelNO2-1]
						,[TokuisakiTelNO2-2]
						,[TokuisakiTelNO2-3]
						,TokuisakiTantouBushoName
						,TokuisakiTantoushaYakushoku
						,TokuisakiTantoushaName
						,KouritenName
						,KouritenYuubinNO1
						,KouritenYuubinNO2
						,KouritenJuusho1
						,KouritenJuusho2
						,[KouritenTelNO1-1]
						,[KouritenTelNO1-2]
						,[KouritenTelNO1-3]
						,[KouritenTelNO2-1]
						,[KouritenTelNO2-2]
						,[KouritenTelNO2-3]
						,KouritenTantouBushoName
						,KouritenTantoushaYakushoku
						,KouritenTantoushaName
						,ShukkaSiziShuturyokuKBN
						,InsertOperator
						,InsertDateTime
						,UpdateOperator
						,UpdateDateTime
						)
	SELECT 
	@ShukkaSiziNO,TM.StaffCD,ShukkaYoteiDate,DenpyouDate,CONVERT(int, FORMAT(Cast(TM.ShukkaYoteiDate as Date), 'yyyyMM'))
	,TM.TokuisakiCD,case when FT.ShokutiFLG=0 then FT.TokuisakiRyakuName else TM.TokuisakiRyakuName end
	,TM.KouritenCD,case when FK.ShokutiFLG=0 then FK.KouritenRyakuName else TM.KouritenRyakuName end
	,TM.ShukkaSiziDenpyouTekiyou,TM.ShukkaSizishoHuyouKBN,0
	,case when FT.ShokutiFLG=0 then FT.TokuisakiName else TM.TokuisakiName end
	,case when FT.ShokutiFLG=0 then FT.YuubinNO1 else TM.TokuisakiYuubinNO1 end
	,case when FT.ShokutiFLG=0 then FT.YuubinNO2 else TM.TokuisakiYuubinNO2 end
	,case when FT.ShokutiFLG=0 then FT.Juusho1 else TM.TokuisakiJuusho1 end
	,case when FT.ShokutiFLG=0 then FT.Juusho2 else TM.TokuisakiJuusho2 end
	,case when FT.ShokutiFLG=0 then FT.Tel11 else TM.TokuisakiTel11 end
	,case when FT.ShokutiFLG=0 then FT.Tel12 else TM.TokuisakiTel12 end
	,case when FT.ShokutiFLG=0 then FT.Tel13 else TM.TokuisakiTel13 end
	,case when FT.ShokutiFLG=0 then FT.Tel21 else TM.TokuisakiTel21 end
	,case when FT.ShokutiFLG=0 then FT.Tel22 else TM.TokuisakiTel22 end
	,case when FT.ShokutiFLG=0 then FT.Tel23 else TM.TokuisakiTel23 end
	,case when FT.ShokutiFLG=0 then FT.TantouBusho else NULL end
	,case when FT.ShokutiFLG=0 then FT.TantouYakushoku else NULL end
	,case when FT.ShokutiFLG=0 then FT.TantoushaName else NULL end
	,case when FK.ShokutiFLG=0 then FK.KouritenName else TM.KouritenName end
	,case when FK.ShokutiFLG=0 then FK.YuubinNO1 else TM.KouritenYuubinNO1 end
	,case when FK.ShokutiFLG=0 then FK.YuubinNO2 else TM.KouritenYuubinNO2 end
	,case when FK.ShokutiFLG=0 then FK.Juusho1 else TM.KouritenJuusho1 end
	,case when FK.ShokutiFLG=0 then FK.Juusho2 else TM.KouritenJuusho2 end
	,case when FK.ShokutiFLG=0 then FK.Tel11 else TM.KouritenTel11 end
	,case when FK.ShokutiFLG=0 then FK.Tel12 else TM.KouritenTel12 end
	,case when FK.ShokutiFLG=0 then FK.Tel13 else TM.KouritenTel13 end
	,case when FK.ShokutiFLG=0 then FK.Tel21 else TM.KouritenTel21 end
	,case when FK.ShokutiFLG=0 then FK.Tel22 else TM.KouritenTel22 end
	,case when FK.ShokutiFLG=0 then FK.Tel23 else TM.KouritenTel23 end
	,case when FK.ShokutiFLG=0 then FK.TantouBusho else NULL end
	,case when FK.ShokutiFLG=0 then FK.TantouYakushoku else NULL end
	,case when FK.ShokutiFLG=0 then FK.TantoushaName else NULL end
	,0
	,OperatorCD,@currentDate
	,OperatorCD,@currentDate

	FROM [#Temp_Header] TM
	left outer join F_Tokuisaki(@ShippingDate) FT on FT.TokuisakiCD=TM.TokuisakiCD
	left outer join F_Kouriten(@ShippingDate) FK on FK.KouritenCD=TM.KouritenCD

	declare @GyouNo as smallint = 1
--TableB
INSERT INTO [dbo].[D_ShukkaSiziMeisai]
	(
		[ShukkaSiziNO]
		,[ShukkaSiziGyouNO]
		,[GyouHyouziJun]
		,[KouritenCD]
		,[KouritenRyakuName]
		,[BrandCD]
		,[ShouhinCD]
		,[ShouhinName]
		,[JANCD]
		,[ColorRyakuName]
		,[ColorNO]
		,[SizeNO]
		,[Kakeritu]
		,[ShukkaSiziSuu]
		,[TaniCD]
		,[UriageTanka]
		,[UriageTankaShouhizei]
		,[UriageHontaiTanka]
		,[UriageKingaku]
		,[UriageHontaiKingaku]
		,[UriageShouhizeiGaku]
		,[ShukkaSiziMeisaiTekiyou]
		,[SoukoCD]
		,[ShukkaKanryouKBN]
		,[ShukkaZumiSuu]
		,[JuchuuNO]
		,[JuchuuGyouNO]
		,[KouritenName]
		,[KouritenYuubinNO1]
		,[KouritenYuubinNO2]
		,[KouritenJuusho1]
		,[KouritenJuusho2]
		,[KouritenTelNO1-1]
		,[KouritenTelNO1-2]
		,[KouritenTelNO1-3]
		,[KouritenTelNO2-1]
		,[KouritenTelNO2-2]
		,[KouritenTelNO2-3]
		,[KouritenTantouBushoName]
		,[KouritenTantoushaYakushoku]
		,[KouritenTantoushaName]
		,[InsertOperator]
		,[InsertDateTime]
		,[UpdateOperator]
		,[UpdateDateTime]
	)
	SELECT
	
		@ShukkaSiziNO --Fnc_Number
		--2021/04/14 Y.Nishikawa ADD TaskNO.0271伀伀
		--,@GyouNo
		--,@GyouNo
		,TD.ShukkaSiziGyouNO                        --@GyouNo
		,TD.ShukkaSiziGyouNO                        --@GyouNo
		--2021/04/14 Y.Nishikawa ADD TaskNO.0271仾仾
		,case when TD.KouritenCD is null then DJ.KouritenCD else TD.KouritenCD end
		,case when TD.KouritenRyakuName is null then DJ.KouritenRyakuName else TD.KouritenRyakuName end
		,FS.BrandCD
		,TD.Hidden_ShouhinCD--Add
		,TD.ShouhinName
		,FS.JANCD
		,TD.ColorRyakuName
		,TD.ColorNO
		,TD.SizeNO
		,1
		,TD.KonkaiShukkaSiziSuu
		,FS.TaniCD
		,TD.UriageTanka
		,0
		,0
		,TD.UriageKingaku
		,0
		,0
		,(CASE ISNULL(TD.ShukkaSiziMeisaiTekiyou,'') WHEN '' THEN NULL
		  ELSE TD.ShukkaSiziMeisaiTekiyou END)
		,TD.SoukoCD
		,0
		,0
		,LEFT(TD.SKMSNO, CHARINDEX('-', TD.SKMSNO) - 1)
		,RIGHT(TD.SKMSNO, LEN(TD.SKMSNO) - CHARINDEX('-', TD.SKMSNO))
		,case when TD.KouritenName is null then DJ.KouritenName else TD.KouritenName end
		,case when TD.KouritenYuubinNO1  is null then DJ.KouritenYuubinNO1 else TD.KouritenYuubinNO1 end
		,case when TD.KouritenYuubinNO2  is null then DJ.KouritenYuubinNO2 else TD.KouritenYuubinNO2 end
		,case when TD.KouritenJuusho1  is null then DJ.KouritenJuusho1 else TD.KouritenJuusho1 end
		,case when TD.KouritenJuusho2  is null then DJ.KouritenJuusho2 else TD.KouritenJuusho2 end
		,case when TD.KouritenTel11  is null then DJ.[KouritenTelNO1-1] else TD.KouritenTel11 end
		,case when TD.KouritenTel12  is null then DJ.[KouritenTelNO1-2] else TD.KouritenTel12 end
		,case when TD.KouritenTel13  is null then DJ.[KouritenTelNO1-3] else TD.KouritenTel13 end
		,case when TD.KouritenTel21  is null then DJ.[KouritenTelNO2-1] else TD.KouritenTel21 end
		,case when TD.KouritenTel22  is null then DJ.[KouritenTelNO2-2] else TD.KouritenTel23 end
		,case when TD.KouritenTel23  is null then DJ.[KouritenTelNO2-3] else TD.KouritenTel23 end
		,NULL,NULL,NULL
		,@OperatorCD,@currentDate,@OperatorCD,@currentDate
	FROM #Temp_Details TD
	LEFT OUTER JOIN D_Juchuu DJ
	ON DJ.JuchuuNO=LEFT(TD.SKMSNO, CHARINDEX('-', TD.SKMSNO) - 1)
	LEFT OUTER JOIN [dbo].[F_Shouhin](@ShippingDate) FS
	ON FS.ShouhinCD=TD.ShouhinCD

--TableC

	declare @a decimal(21,6), @b decimal(21, 6), @JuchuuNO VARCHAR(12), @JuchuuGyouNO SMALLINT, @KonkaiShukkaSiziSuu VARCHAR(30), @SKMSNO VARCHAR(25), @Hidden_ShouhinCD VARCHAR(25)
	DECLARE @SoukoCD VARCHAR(10), @ShouhinCD VARCHAR(20), @ShouhinName VARCHAR(100)
	DECLARE cursor1 CURSOR READ_ONLY FOR SELECT SoukoCD, ShouhinCD, ShouhinName, SKMSNO, Hidden_ShouhinCD, KonkaiShukkaSiziSuu FROM #Temp_Details
	OPEN cursor1
	FETCH NEXT FROM cursor1 INTO @SoukoCD, @ShouhinCD, @ShouhinName, @SKMSNO, @Hidden_ShouhinCD, @KonkaiShukkaSiziSuu
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @JuchuuNO = LEFT(@SKMSNO, CHARINDEX('-', @SKMSNO) - 1)
		SET @JuchuuGyouNO = RIGHT(@SKMSNO, LEN(@SKMSNO) - CHARINDEX('-', @SKMSNO))
		SET @a = ABS(@KonkaiShukkaSiziSuu)

	--2021/04/13 Y.Nishikawa DEL 堷摉峏怴偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋伀伀
	-----KTP Change
	--declare 
	--@JuchuuShousaiNO as smallint,
	--@KanriNO as varchar(10),
	--@NyuukoDate as varchar(10),
	--@HikiateZumiSuu as decimal(21,6),
	--@ShukkaSiziZumiSuu as decimal(21,6)
	
	----Step 3(loop by JuchuuNO,JuchuuGyouNO)
	--declare cursorInner cursor read_only
	--for select JuchuuShousaiNO,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,HikiateZumiSuu,ShukkaSiziZumiSuu
	--from D_JuchuuShousai 
	--where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO
	--and HikiateZumiSuu > 0
	--order by KanriNO,case when NyuukoDate = '' or NyuukoDate is null then '2100-01-01' else NyuukoDate end
	
	--open cursorInner
	
	--fetch next from cursorInner
	--into @JuchuuShousaiNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@HikiateZumiSuu,
	--@ShukkaSiziZumiSuu
	
	--while @@FETCH_STATUS = 0
	--	begin
	
	--		if(@a > 0)
	--			begin
	--				declare @tmpHikiateSuu as decimal(21,6)
	--				declare @tmpShukkasiziSuu as decimal(21,6)
	
	--				--Step3 : Update D_JuchuuShousai(庴拲徻嵶)
	--				update D_JuchuuShousai
	--				set 
	--					@tmpHikiateSuu = HikiateZumiSuu,
	--					@tmpShukkasiziSuu = case when @a <= HikiateZumiSuu then @a else HikiateZumiSuu end,
	--					HikiateZumiSuu = case when @a >= HikiateZumiSuu then 0 else HikiateZumiSuu - @a end,
	--					ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + (case when @a <= HikiateZumiSuu then @a else HikiateZumiSuu end),
	--					ShukkaZumiSuu = 0,
	--					UriageZumiSuu = 0,
	--					UpdateOperator = @OperatorCD,
	--					UpdateDateTime = @currentDate
	--				from D_JuchuuShousai
	--				where JuchuuNO = @JuchuuNo
	--				and JuchuuGyouNO = @JuchuuGyouNO 
	--				and JuchuuShousaiNO = @JuchuuShousaiNO
	
	--				set @a = case when @a > @tmpHikiateSuu then @a - @tmpHikiateSuu else 0 end
	
	--				declare @maxShousaiNo as smallint
	
	--				select @maxShousaiNo = isnull(max(ShukkaSiziShousaiNO),0) from D_ShukkaSiziShousai where ShukkaSiziNO = @ShukkaSiziNO
	
	--				-- Step5 : Insert D_ShukkaSiziShousai(弌壸巜帵徻嵶)
	--				insert into D_ShukkaSiziShousai( ShukkaSiziNO, ShukkaSiziGyouNO, ShukkaSiziShousaiNO, 
	--				SoukoCD,ShouhinCD,ShouhinName,ShukkaSiziSuu,KanriNO,NyuukoDate,ShukkaZumiSuu,
	--				JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime
	--				)
	--				select 
	--					@ShukkaSiziNO,@GyouNo,@maxShousaiNo + 1,
	--					js.SoukoCD,js.ShouhinCD,jms.ShouhinName,@tmpShukkasiziSuu,@KanriNO,@NyuukoDate,0,
	--					@JuchuuNo,@JuchuuGyouNO,@JuchuuShousaiNO,@OperatorCD,@currentDate,@OperatorCD,@currentDate
					
	--				from D_JuchuuShousai js
	--				left outer join D_JuchuuMeisai jms on js.JuchuuNO = jms.JuchuuNO and js.JuchuuGyouNO = jms.JuchuuGyouNO
	--				where js.JuchuuNO = @JuchuuNo 
	--				and js.JuchuuGyouNO = @JuchuuGyouNO
	--				and js.JuchuuShousaiNO = @JuchuuShousaiNO
	--			end
			
	
	--		fetch next from 
	--		cursorInner into @JuchuuShousaiNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@HikiateZumiSuu,
	--		@ShukkaSiziZumiSuu
	--	end
	
	--close cursorInner
	--deallocate cursorInner
	--2021/04/13 Y.Nishikawa DEL 堷摉峏怴偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋仾仾

	set @GyouNO = @GyouNO + 1

	---KTP Change


    -- Insert statements for procedure here
		--WHILE @a >0
		--	BEGIN
		--	IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai dj
		--		INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
		--		AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO ORDER BY KanriNO ASC, NyuukoDate ASC) dj1
		--		ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
		--		AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO)
			
		--	BEGIN
		--		INSERT INTO [dbo].[D_ShukkaSiziShousai]
		--		(	[ShukkaSiziNO]
		--		,[ShukkaSiziGyouNO]
		--		,[ShukkaSiziShousaiNO]
		--		,[SoukoCD]
		--		,[ShouhinCD]
		--		,[ShouhinName]
		--		,[ShukkaSiziSuu]
		--		,[KanriNO]
		--		,[NyuukoDate]
		--		,[ShukkaZumiSuu]
		--		,[JuchuuNO]
		--		,[JuchuuGyouNO]
		--		,[JuchuuShousaiNO]
		--		,[InsertOperator]
		--		,[InsertDateTime]
		--		,[UpdateOperator]
		--		,[UpdateDateTime]
		--		)

		--		SELECT 
		--		@ShukkaSiziNO
		--		,@GyouNo				
		--		,(select isnull(max(1),0) + 1 from D_ShukkaSiziShousai where ShukkaSiziNO =@ShukkaSiziNO and ShukkaSiziGyouNO = @GyouNo )				
		--		,@SoukoCD
		--		,@ShouhinCD
		--		,@ShouhinName
		--		,dj.ShukkaSiziZumiSuu
		--		,dj.KanriNO	
		--		,dj.NyuukoDate
		--		,0
		--		,dj.JuchuuNO
		--		,dj.JuchuuGyouNO
		--		,dj.JuchuuShousaiNO
		--		,@OperatorCD,@currentDate,@OperatorCD,@currentDate
		--		from  D_JuchuuShousai dj
		--		INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
		--		AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO ORDER BY KanriNO ASC, NyuukoDate ASC) dj1
		--		ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
		--		AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO

		--		UPDATE dj
		--		SET dj.HikiateZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN dj.HikiateZumiSuu - @a ELSE 0 END, 
		--			dj.ShukkaSiziZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN @a ELSE dj.HikiateZumiSuu END,
		--			@b = CASE WHEN dj.HikiateZumiSuu > @a THEN 0 ELSE @a - dj.HikiateZumiSuu END
		--		from  D_JuchuuShousai dj
		--		INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
		--		AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO ORDER BY KanriNO ASC, NyuukoDate ASC) dj1
		--		ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
		--		AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO
		--	END
		--	ELSE
		--		BREAK
		--	SET @a = @b
		--END
		--set @GyouNo = @GyouNo + 1		
		FETCH NEXT FROM cursor1 INTO @SoukoCD, @ShouhinCD, @ShouhinName, @SKMSNO, @Hidden_ShouhinCD, @KonkaiShukkaSiziSuu
	END
	CLOSE cursor1
	DEALLOCATE cursor1

--Table D
INSERT INTO [dbo].[D_ShukkaSiziHistory]
	(	[HistoryGuid]
		,[ShukkaSiziNO]
		,[ShoriKBN]
		,[StaffCD]
		,[ShukkaYoteiDate]
		,[DenpyouDate]
		,[KaikeiYYMM]
		,[TokuisakiCD]
		,[TokuisakiRyakuName]
		,[KouritenCD]
		,[KouritenRyakuName]
		,[ShukkaSiziDenpyouTekiyou]
		,[ShukkaSizishoHuyouKBN]
		,[ShukkaKanryouKBN]
		,[TokuisakiName]
		,[TokuisakiYuubinNO1]
		,[TokuisakiYuubinNO2]
		,[TokuisakiJuusho1]
		,[TokuisakiJuusho2]
		,[TokuisakiTelNO1-1]
		,[TokuisakiTelNO1-2]
		,[TokuisakiTelNO1-3]
		,[TokuisakiTelNO2-1]
		,[TokuisakiTelNO2-2]
		,[TokuisakiTelNO2-3]
		,[TokuisakiTantouBushoName]
		,[TokuisakiTantoushaYakushoku]
		,[TokuisakiTantoushaName]
		,[KouritenName]
		,[KouritenYuubinNO1]
		,[KouritenYuubinNO2]
		,[KouritenJuusho1]
		,[KouritenJuusho2]
		,[KouritenTelNO1-1]
		,[KouritenTelNO1-2]
		,[KouritenTelNO1-3]
		,[KouritenTelNO2-1]
		,[KouritenTelNO2-2]
		,[KouritenTelNO2-3]
		,[KouritenTantouBushoName]
		,[KouritenTantoushaYakushoku]
		,[KouritenTantoushaName]
		,[ShukkaSiziShuturyokuKBN]
		,[ShukkaSiziShuturyokuDateTime]
		,[InsertOperator]
		,[InsertDateTime]
		,[UpdateOperator]
		,[UpdateDateTime]
		,[HistoryOperator]
		,[HistoryDateTime]
	)
	SELECT 
	@Unique
	,i.ShukkaSiziNO
	,10--怴婯
	,i.StaffCD
	,i.ShukkaYoteiDate
	,i.DenpyouDate
	,i.KaikeiYYMM
	,i.TokuisakiCD
	,i.TokuisakiRyakuName
	,i.KouritenCD
	,i.KouritenRyakuName
	,i.ShukkaSiziDenpyouTekiyou
	,i.ShukkaSizishoHuyouKBN
	,i.ShukkaKanryouKBN
	,i.TokuisakiName
	,i.TokuisakiYuubinNO1
	,i.TokuisakiYuubinNO2
	,i.TokuisakiJuusho1
	,i.TokuisakiJuusho2
	,i.[TokuisakiTelNO1-1]
	,i.[TokuisakiTelNO1-2]
	,i.[TokuisakiTelNO1-3]
	,i.[TokuisakiTelNO2-1]
	,i.[TokuisakiTelNO2-2]
	,i.[TokuisakiTelNO2-3]
	,i.[TokuisakiTantouBushoName]
	,i.[TokuisakiTantoushaYakushoku]
	,i.[TokuisakiTantoushaName]
	,i.KouritenName
	,i.KouritenYuubinNO1
	,i.KouritenYuubinNO2
	,i.KouritenJuusho1
	,i.KouritenJuusho2
	,i.[KouritenTelNO1-1]
	,i.[KouritenTelNO1-2]
	,i.[KouritenTelNO1-3]
	,i.[KouritenTelNO2-1]
	,i.[KouritenTelNO2-2]
	,i.[KouritenTelNO2-3]
	,i.[KouritenTantouBushoName]
	,i.[KouritenTantoushaYakushoku]
	,i.[KouritenTantoushaName]
	,i.[ShukkaSiziShuturyokuKBN]
	,i.[ShukkaSiziShuturyokuDateTime]
	,i.[InsertOperator]
	,i.InsertDateTime
	,i.UpdateOperator
	,i.UpdateDateTime
	,@OperatorCD
	,@currentDate
    FROM [dbo].[D_ShukkaSizi] AS i
where i.ShukkaSiziNO=@ShukkaSiziNO

--TableE
INSERT INTO [dbo].[D_ShukkaSiziMeisaiHistory]
(
		[HistoryGuid]
		,[ShukkaSiziNO]
		,[ShukkaSiziGyouNO]
		,[GyouHyouziJun]
		,[ShoriKBN]
		,[KouritenCD]
		,[KouritenRyakuName]
		,[BrandCD]
		,[ShouhinCD]
		,[ShouhinName]
		,[JANCD]
		,[ColorRyakuName]
		,[ColorNO]
		,[SizeNO]
		,[Kakeritu]
		,[ShukkaSiziSuu]
		,[TaniCD]
		,[UriageTanka]
		,[UriageTankaShouhizei]
		,[UriageHontaiTanka]
		,[UriageKingaku]
		,[UriageHontaiKingaku]
		,[UriageShouhizeiGaku]
		,[ShukkaSiziMeisaiTekiyou]
		,[SoukoCD]
		,[ShukkaKanryouKBN]
		,[ShukkaZumiSuu]
		,[JuchuuNO]
		,[JuchuuGyouNO]
		,[KouritenName]
		,[KouritenYuubinNO1]
		,[KouritenYuubinNO2]
		,[KouritenJuusho1]
		,[KouritenJuusho2]
		,[KouritenTelNO1-1]
		,[KouritenTelNO1-2]
		,[KouritenTelNO1-3]
		,[KouritenTelNO2-1]
		,[KouritenTelNO2-2]
		,[KouritenTelNO2-3]
		,[InsertOperator]
		,[InsertDateTime]
		,[UpdateOperator]
		,[UpdateDateTime]
		,[HistoryOperator]
		,[HistoryDateTime]
		)
SELECT 
		@Unique
		,j.[ShukkaSiziNO]
		,j.[ShukkaSiziGyouNO]
		,j.[GyouHyouziJun]
		,10--怴婯
		,j.[KouritenCD]
		,j.[KouritenRyakuName]
		,j.[BrandCD]
		,j.[ShouhinCD]
		,j.[ShouhinName]
		,j.[JANCD]
		,j.[ColorRyakuName]
		,j.[ColorNO]
		,j.[SizeNO]
		,j.[Kakeritu]
		,j.[ShukkaSiziSuu]
		,j.[TaniCD]
		,j.[UriageTanka]
		,j.[UriageTankaShouhizei]
		,j.[UriageHontaiTanka]
		,j.[UriageKingaku]
		,j.[UriageHontaiKingaku]
		,j.[UriageShouhizeiGaku]
		,j.[ShukkaSiziMeisaiTekiyou]
		,j.[SoukoCD]
		,j.[ShukkaKanryouKBN]
		,j.[ShukkaZumiSuu]
		,j.[JuchuuNO]
		,j.[JuchuuGyouNO]
		,j.[KouritenName]
		,j.[KouritenYuubinNO1]
		,j.[KouritenYuubinNO2]
		,j.[KouritenJuusho1]
		,j.[KouritenJuusho2]
		,j.[KouritenTelNO1-1]
		,j.[KouritenTelNO1-2]
		,j.[KouritenTelNO1-3]
		,j.[KouritenTelNO2-1]
		,j.[KouritenTelNO2-2]
		,j.[KouritenTelNO2-3]
		,j.[InsertOperator]
		,j.[InsertDateTime]
		,j.[UpdateOperator]
		,j.[UpdateDateTime]
		,@OperatorCD
		,@currentDate
FROM [dbo].[D_ShukkaSiziMeisai] AS j
where j.ShukkaSiziNO=@ShukkaSiziNO

--2021/04/14 Y.Nishikawa DEL 弌壸巜帵徻嵶偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋伀伀
----TableF
--INSERT INTO [dbo].[D_ShukkaSiziShousaiHistory]
--(
--	[HistoryGuid]
--	,[ShukkaSiziNO]
--	,[ShukkaSiziGyouNO]
--	,[ShukkaSiziShousaiNO]
--	,[ShoriKBN]
--	,[SoukoCD]
--	,[ShouhinCD]
--	,[ShouhinName]
--	,[ShukkaSiziSuu]
--	,[KanriNO]
--	,[NyuukoDate]
--	,[ShukkaZumiSuu]
--	,[JuchuuNO]
--	,[JuchuuGyouNO]
--	,[JuchuuShousaiNO]
--	,[InsertOperator]
--	,[InsertDateTime]
--	,[UpdateOperator]
--	,[UpdateDateTime]
--	,[HistoryOperator]
--	,[HistoryDateTime]
--)
--SELECT 
--@Unique,
--[ShukkaSiziNO]
--			,[ShukkaSiziGyouNO]
--			,[ShukkaSiziShousaiNO]
--			,10 --怴婯
--			,[SoukoCD]
--			,[ShouhinCD]
--			,[ShouhinName]
--			,[ShukkaSiziSuu]
--			,[KanriNO]
--			,[NyuukoDate]
--			,[ShukkaZumiSuu]
--			,[JuchuuNO]
--			,[JuchuuGyouNO]
--			,[JuchuuShousaiNO]
--			,[InsertOperator]
--			,[InsertDateTime]
--			,[UpdateOperator]
--			,[UpdateDateTime]
--			,@OperatorCD
--			,@currentDate
--FROM [dbo].[D_ShukkaSiziShousai]
--where ShukkaSiziNO=@ShukkaSiziNO
--2021/04/14 Y.Nishikawa DEL 弌壸巜帵徻嵶偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋仾仾
--Konkai_Price

--2021/04/13 Y.Nishikawa DEL 堷摉峏怴偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋伀伀
----Table G  --捛壛傑偨偼廋惓屻
--UPDATE  A
--SET	
--	HikiateZumiSuu = A.HikiateZumiSuu - B.KonkaiShukkaSiziSuu -- KTP Add
--	,ShukkaSiziZumiSuu=A.ShukkaSiziZumiSuu + B.KonkaiShukkaSiziSuu
--	,UpdateOperator=@OperatorCD
--	,UpdateDateTime=@currentDate
--FROM D_JuchuuMeisai A
--inner join #Temp_Details B
--on A.JuchuuNO = LEFT((B.SKMSNO), CHARINDEX('-', (B.SKMSNO)) - 1) 
--and A.JuchuuGyouNO=RIGHT(B.SKMSNO, LEN(B.SKMSNO) - CHARINDEX('-', B.SKMSNO))
--2021/04/13 Y.Nishikawa DEL 堷摉峏怴偼堷摉僼傽儞僋僔儑儞偱張棟偟偰偄傞偨傔丄擇廳寁忋仾仾


--D_JuchuuMeisai
UPDATE  A
--2021/04/14 Y.Nishikawa CHG 偙偺帪揰偱偼庴拲柧嵶偺弌壸巜帵嵪悢偵崱夞弌壸巜帵悢傪峏怴偟偰偄側偄偺偱丄暘擺帪偼姰椆嬫暘偑姰椆偵側傜側偄伀伀
--SET	[ShukkaSiziKanryouKBN]= case when A.JuchuuSuu<=A.ShukkaSiziZumiSuu then 1 
SET	[ShukkaSiziKanryouKBN]= case when A.JuchuuSuu <= (case when ISNUMERIC(C.KonkaiShukkaSiziSuu) = 1 then cast(C.KonkaiShukkaSiziSuu as decimal(21, 6)) else 0 end 
                                                    + case when ISNUMERIC(C.ShukkaSiziZumiSuu) = 1 then cast(C.ShukkaSiziZumiSuu as decimal(21, 6)) else 0 end) then 1
--2021/04/14 Y.Nishikawa CHG 偙偺帪揰偱偼庴拲柧嵶偺弌壸巜帵嵪悢偵崱夞弌壸巜帵悢傪峏怴偟偰偄側偄偺偱丄暘擺帪偼姰椆嬫暘偑姰椆偵側傜側偄仾仾
									when C.Kanryo=1 then 1 else 0 end
--2021/04/14 Y.Nishikawa ADD 忦審晄懌乮忦審偵峴斣崋偑側偄偺偱丄庴拲柧嵶悢暘朿傟偰寁嶼偝傟傞乯伀伀
--FROM D_JuchuuMeisai A,#Temp_Details C
--where A.JuchuuNO = LEFT((C.SKMSNO), CHARINDEX('-', (C.SKMSNO)) - 1) 
FROM D_JuchuuMeisai A
INNER JOIN #Temp_Details C
ON A.JuchuuNO = LEFT((C.SKMSNO), CHARINDEX('-', (C.SKMSNO)) - 1) 
and A.JuchuuGyouNO = RIGHT(C.SKMSNO, LEN(C.SKMSNO) - CHARINDEX('-', C.SKMSNO)) 
--2021/04/14 Y.Nishikawa ADD 忦審晄懌乮忦審偵峴斣崋偑側偄偺偱丄庴拲柧嵶悢暘朿傟偰寁嶼偝傟傞乯仾仾
--and A.ShouhinCD=C.ShouhinCD


--D_Juchuu
UPDATE	A
SET		A.[ShukkaSiziKanryouKBN] = B.ShukkaSiziKanryouKBN
FROM D_Juchuu as A
INNER JOIN (select JuchuuNO,MIN(ShukkaSiziKanryouKBN) as ShukkaSiziKanryouKBN 
			from D_JuchuuMeisai C, #Temp_Details D
			where C.JuchuuNO=LEFT(D.SKMSNO, CHARINDEX('-', D.SKMSNO) - 1)
			group by JuchuuNO
) as B
ON A.JuchuuNO=B.JuchuuNO



--ktp call fncHikiate
exec dbo.Fnc_Hikiate 12,@ShukkaSiziNO,10,@OperatorCD

--僗僞僢僼儅僗僞
UPDATE M_Staff 
set UsedFlg = 1 
where StaffCD=@StaffCD
and  ChangeDate = (select ChangeDate from F_Staff(@ShippingDate) where StaffCD = @StaffCD)

--L_Log
declare @OperatorMode varchar(50)='怴婯'
exec dbo.L_Log_Insert @OperatorCD,@Program,@PC,@OperatorMode,@ShukkaSiziNO

--僥乕僽儖揮憲巇條倄--嶍彍
exec [dbo].[D_Exclusive_Remove_NO] 1,@OperatorCD,@Program,@PC
	
END

GO


 [ C o l o r R y a k u N a m e ]  
                 , [ C o l o r N O ]  
                 , [ S i z e N O ]  
                 , [ K a k e r i t u ]  
                 , [ S h u k k a S i z i S u u ]  
                 , [ T a n i C D ]  
                 , [ U r i a g e T a n k a ]  
                 , [ U r i a g e T a n k a S h o u h i z e i ]  
                 , [ U r i a g e H o n t a i T a n k a ]  
                 , [ U r i a g e K i n g a k u ]  
                 , [ U r i a g e H o n t a i K i n g a k u ]  
                 , [ U r i a g e S h o u h i z e i G a k u ]  
                 , [ S h u k k a S i z i M e i s a i T e k i y o u ]  
                 , [ S o u k o C D ]  
                 , [ S h u k k a K a n r y o u K B N ]  
                 , [ S h u k k a Z u m i S u u ]  
                 , [ J u c h u u N O ]  
                 , [ J u c h u u G y o u N O ]  
                 , [ K o u r i t e n N a m e ]  
                 , [ K o u r i t e n Y u u b i n N O 1 ]  
                 , [ K o u r i t e n Y u u b i n N O 2 ]  
                 , [ K o u r i t e n J u u s h o 1 ]  
                 , [ K o u r i t e n J u u s h o 2 ]  
                 , [ K o u r i t e n T e l N O 1 - 1 ]  
                 , [ K o u r i t e n T e l N O 1 - 2 ]  
                 , [ K o u r i t e n T e l N O 1 - 3 ]  
                 , [ K o u r i t e n T e l N O 2 - 1 ]  
                 , [ K o u r i t e n T e l N O 2 - 2 ]  
                 , [ K o u r i t e n T e l N O 2 - 3 ]  
                 , [ K o u r i t e n T a n t o u B u s h o N a m e ]  
                 , [ K o u r i t e n T a n t o u s h a Y a k u s h o k u ]  
                 , [ K o u r i t e n T a n t o u s h a N a m e ]  
                 , [ I n s e r t O p e r a t o r ]  
                 , [ I n s e r t D a t e T i m e ]  
                 , [ U p d a t e O p e r a t o r ]  
                 , [ U p d a t e D a t e T i m e ]  
         )  
         S E L E C T  
          
                 @ S h u k k a S i z i N O   - - F n c _ N u m b e r  
                 , T D . S h u k k a S i z i G y o u N O                                                 - - @ G y o u N o  
                 , T D . S h u k k a S i z i G y o u N O   A S   G y o u H y o u z i J u n               - - @ G y o u N o  
                 , c a s e   w h e n   T D . K o u r i t e n C D   i s   n u l l   t h e n   D J . K o u r i t e n C D   e l s e   T D . K o u r i t e n C D   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n R y a k u N a m e   i s   n u l l   t h e n   D J . K o u r i t e n R y a k u N a m e   e l s e   T D . K o u r i t e n R y a k u N a m e   e n d  
                 , F S . B r a n d C D  
                 , T D . H i d d e n _ S h o u h i n C D - - A d d  
                 , T D . S h o u h i n N a m e  
                 , F S . J A N C D  
                 , T D . C o l o r R y a k u N a m e  
                 , T D . C o l o r N O  
                 , T D . S i z e N O  
                 , 1  
                 , T D . K o n k a i S h u k k a S i z i S u u  
                 , F S . T a n i C D  
                 , T D . U r i a g e T a n k a  
                 , 0  
                 , 0  
                 , T D . U r i a g e K i n g a k u  
                 , 0  
                 , 0  
                 , T D . S h u k k a S i z i M e i s a i T e k i y o u  
                 , T D . S o u k o C D  
                 , 0  
                 , 0  
                 , L E F T ( T D . S K M S N O ,   C H A R I N D E X ( ' - ' ,   T D . S K M S N O )   -   1 )  
                 , R I G H T ( T D . S K M S N O ,   L E N ( T D . S K M S N O )   -   C H A R I N D E X ( ' - ' ,   T D . S K M S N O ) )  
                 , c a s e   w h e n   T D . K o u r i t e n N a m e   i s   n u l l   t h e n   D J . K o u r i t e n N a m e   e l s e   T D . K o u r i t e n N a m e   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n Y u u b i n N O 1     i s   n u l l   t h e n   D J . K o u r i t e n Y u u b i n N O 1   e l s e   T D . K o u r i t e n Y u u b i n N O 1   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n Y u u b i n N O 2     i s   n u l l   t h e n   D J . K o u r i t e n Y u u b i n N O 2   e l s e   T D . K o u r i t e n Y u u b i n N O 2   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n J u u s h o 1     i s   n u l l   t h e n   D J . K o u r i t e n J u u s h o 1   e l s e   T D . K o u r i t e n J u u s h o 1   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n J u u s h o 2     i s   n u l l   t h e n   D J . K o u r i t e n J u u s h o 2   e l s e   T D . K o u r i t e n J u u s h o 2   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n T e l 1 1     i s   n u l l   t h e n   D J . [ K o u r i t e n T e l N O 1 - 1 ]   e l s e   T D . K o u r i t e n T e l 1 1   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n T e l 1 2     i s   n u l l   t h e n   D J . [ K o u r i t e n T e l N O 1 - 2 ]   e l s e   T D . K o u r i t e n T e l 1 2   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n T e l 1 3     i s   n u l l   t h e n   D J . [ K o u r i t e n T e l N O 1 - 3 ]   e l s e   T D . K o u r i t e n T e l 1 3   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n T e l 2 1     i s   n u l l   t h e n   D J . [ K o u r i t e n T e l N O 2 - 1 ]   e l s e   T D . K o u r i t e n T e l 2 1   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n T e l 2 2     i s   n u l l   t h e n   D J . [ K o u r i t e n T e l N O 2 - 2 ]   e l s e   T D . K o u r i t e n T e l 2 3   e n d  
                 , c a s e   w h e n   T D . K o u r i t e n T e l 2 3     i s   n u l l   t h e n   D J . [ K o u r i t e n T e l N O 2 - 3 ]   e l s e   T D . K o u r i t e n T e l 2 3   e n d  
                 , N U L L , N U L L , N U L L  
                 , @ O p e r a t o r C D , @ c u r r e n t D a t e , @ O p e r a t o r C D , @ c u r r e n t D a t e  
         F R O M   # T e m p _ D e t a i l s   T D  
         L E F T   O U T E R   J O I N   D _ J u c h u u   D J  
         O N   D J . J u c h u u N O = L E F T ( T D . S K M S N O ,   C H A R I N D E X ( ' - ' ,   T D . S K M S N O )   -   1 )  
         L E F T   O U T E R   J O I N   [ d b o ] . [ F _ S h o u h i n ] ( @ S h i p p i n g D a t e )   F S  
         O N   F S . S h o u h i n C D = T D . S h o u h i n C D  
  
 - - T a b l e C  
  
         d e c l a r e   @ a   d e c i m a l ( 2 1 , 6 ) ,   @ b   d e c i m a l ( 2 1 ,   6 ) ,   @ J u c h u u N O   V A R C H A R ( 1 2 ) ,   @ J u c h u u G y o u N O   S M A L L I N T ,   @ K o n k a i S h u k k a S i z i S u u   V A R C H A R ( 3 0 ) ,   @ S K M S N O   V A R C H A R ( 2 5 ) ,   @ H i d d e n _ S h o u h i n C D   V A R C H A R ( 2 5 )  
         D E C L A R E   @ S o u k o C D   V A R C H A R ( 1 0 ) ,   @ S h o u h i n C D   V A R C H A R ( 2 0 ) ,   @ S h o u h i n N a m e   V A R C H A R ( 1 0 0 )  
         D E C L A R E   c u r s o r 1   C U R S O R   R E A D _ O N L Y   F O R   S E L E C T   S o u k o C D ,   S h o u h i n C D ,   S h o u h i n N a m e ,   S K M S N O ,   H i d d e n _ S h o u h i n C D ,   K o n k a i S h u k k a S i z i S u u   F R O M   # T e m p _ D e t a i l s  
         O P E N   c u r s o r 1  
         F E T C H   N E X T   F R O M   c u r s o r 1   I N T O   @ S o u k o C D ,   @ S h o u h i n C D ,   @ S h o u h i n N a m e ,   @ S K M S N O ,   @ H i d d e n _ S h o u h i n C D ,   @ K o n k a i S h u k k a S i z i S u u  
         W H I L E   @ @ F E T C H _ S T A T U S   =   0  
         B E G I N  
                 S E T   @ J u c h u u N O   =   L E F T ( @ S K M S N O ,   C H A R I N D E X ( ' - ' ,   @ S K M S N O )   -   1 )  
                 S E T   @ J u c h u u G y o u N O   =   R I G H T ( @ S K M S N O ,   L E N ( @ S K M S N O )   -   C H A R I N D E X ( ' - ' ,   @ S K M S N O ) )  
                 S E T   @ a   =   A B S ( @ K o n k a i S h u k k a S i z i S u u )  
  
         - - 2 0 2 1 / 0 4 / 1 3   Y . N i s h i k a w a   D E L   _S_鬴癳o0_S_󤕘丒񯟤丒丒g0鍽tW0f0D0丒_0丒0孨蛠E丒N丒丒 
         - - - - - K T P   C h a n g e  
         - - d e c l a r e    
         - - @ J u c h u u S h o u s a i N O   a s   s m a l l i n t ,  
         - - @ K a n r i N O   a s   v a r c h a r ( 1 0 ) ,  
         - - @ N y u u k o D a t e   a s   v a r c h a r ( 1 0 ) ,  
         - - @ H i k i a t e Z u m i S u u   a s   d e c i m a l ( 2 1 , 6 ) ,  
         - - @ S h u k k a S i z i Z u m i S u u   a s   d e c i m a l ( 2 1 , 6 )  
          
         - - - - S t e p   3 ( l o o p   b y   J u c h u u N O , J u c h u u G y o u N O )  
         - - d e c l a r e   c u r s o r I n n e r   c u r s o r   r e a d _ o n l y  
         - - f o r   s e l e c t   J u c h u u S h o u s a i N O , S o u k o C D , S h o u h i n C D , K a n r i N O , N y u u k o D a t e , H i k i a t e Z u m i S u u , S h u k k a S i z i Z u m i S u u  
         - - f r o m   D _ J u c h u u S h o u s a i    
         - - w h e r e   J u c h u u N O   =   @ J u c h u u N o   a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O  
         - - a n d   H i k i a t e Z u m i S u u   >   0  
         - - o r d e r   b y   K a n r i N O , c a s e   w h e n   N y u u k o D a t e   =   ' '   o r   N y u u k o D a t e   i s   n u l l   t h e n   ' 2 1 0 0 - 0 1 - 0 1 '   e l s e   N y u u k o D a t e   e n d  
          
         - - o p e n   c u r s o r I n n e r  
          
         - - f e t c h   n e x t   f r o m   c u r s o r I n n e r  
         - - i n t o   @ J u c h u u S h o u s a i N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N O , @ N y u u k o D a t e , @ H i k i a t e Z u m i S u u ,  
         - - @ S h u k k a S i z i Z u m i S u u  
          
         - - w h i l e   @ @ F E T C H _ S T A T U S   =   0  
         - -     b e g i n  
          
         - -             i f ( @ a   >   0 )  
         - -                     b e g i n  
         - -                             d e c l a r e   @ t m p H i k i a t e S u u   a s   d e c i m a l ( 2 1 , 6 )  
         - -                             d e c l a r e   @ t m p S h u k k a s i z i S u u   a s   d e c i m a l ( 2 1 , 6 )  
          
         - -                             - - S t e p 3   :   U p d a t e   D _ J u c h u u S h o u s a i ( 譙鑜s丒})  
         - -                             u p d a t e   D _ J u c h u u S h o u s a i  
         - -                             s e t    
         - -                                     @ t m p H i k i a t e S u u   =   H i k i a t e Z u m i S u u ,  
         - -                                     @ t m p S h u k k a s i z i S u u   =   c a s e   w h e n   @ a   < =   H i k i a t e Z u m i S u u   t h e n   @ a   e l s e   H i k i a t e Z u m i S u u   e n d ,  
         - -                                     H i k i a t e Z u m i S u u   =   c a s e   w h e n   @ a   > =   H i k i a t e Z u m i S u u   t h e n   0   e l s e   H i k i a t e Z u m i S u u   -   @ a   e n d ,  
         - -                                     S h u k k a S i z i Z u m i S u u   =   S h u k k a S i z i Z u m i S u u   +   ( c a s e   w h e n   @ a   < =   H i k i a t e Z u m i S u u   t h e n   @ a   e l s e   H i k i a t e Z u m i S u u   e n d ) ,  
         - -                                     S h u k k a Z u m i S u u   =   0 ,  
         - -                                     U r i a g e Z u m i S u u   =   0 ,  
         - -                                     U p d a t e O p e r a t o r   =   @ O p e r a t o r C D ,  
         - -                                     U p d a t e D a t e T i m e   =   @ c u r r e n t D a t e  
         - -                             f r o m   D _ J u c h u u S h o u s a i  
         - -                             w h e r e   J u c h u u N O   =   @ J u c h u u N o  
         - -                             a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O    
         - -                             a n d   J u c h u u S h o u s a i N O   =   @ J u c h u u S h o u s a i N O  
          
         - -                             s e t   @ a   =   c a s e   w h e n   @ a   >   @ t m p H i k i a t e S u u   t h e n   @ a   -   @ t m p H i k i a t e S u u   e l s e   0   e n d  
          
         - -                             d e c l a r e   @ m a x S h o u s a i N o   a s   s m a l l i n t  
          
         - -                             s e l e c t   @ m a x S h o u s a i N o   =   i s n u l l ( m a x ( S h u k k a S i z i S h o u s a i N O ) , 0 )   f r o m   D _ S h u k k a S i z i S h o u s a i   w h e r e   S h u k k a S i z i N O   =   @ S h u k k a S i z i N O  
          
         - -                             - -   S t e p 5   :   I n s e r t   D _ S h u k k a S i z i S h o u s a i ( 嘯w丒c:ys丒})  
         - -                             i n s e r t   i n t o   D _ S h u k k a S i z i S h o u s a i (   S h u k k a S i z i N O ,   S h u k k a S i z i G y o u N O ,   S h u k k a S i z i S h o u s a i N O ,    
         - -                             S o u k o C D , S h o u h i n C D , S h o u h i n N a m e , S h u k k a S i z i S u u , K a n r i N O , N y u u k o D a t e , S h u k k a Z u m i S u u ,  
         - -                             J u c h u u N O , J u c h u u G y o u N O , J u c h u u S h o u s a i N O , I n s e r t O p e r a t o r , I n s e r t D a t e T i m e , U p d a t e O p e r a t o r , U p d a t e D a t e T i m e  
         - -                             )  
         - -                             s e l e c t    
         - -                                     @ S h u k k a S i z i N O , @ G y o u N o , @ m a x S h o u s a i N o   +   1 ,  
         - -                                     j s . S o u k o C D , j s . S h o u h i n C D , j m s . S h o u h i n N a m e , @ t m p S h u k k a s i z i S u u , @ K a n r i N O , @ N y u u k o D a t e , 0 ,  
         - -                                     @ J u c h u u N o , @ J u c h u u G y o u N O , @ J u c h u u S h o u s a i N O , @ O p e r a t o r C D , @ c u r r e n t D a t e , @ O p e r a t o r C D , @ c u r r e n t D a t e  
                                          
         - -                             f r o m   D _ J u c h u u S h o u s a i   j s  
         - -                             l e f t   o u t e r   j o i n   D _ J u c h u u M e i s a i   j m s   o n   j s . J u c h u u N O   =   j m s . J u c h u u N O   a n d   j s . J u c h u u G y o u N O   =   j m s . J u c h u u G y o u N O  
         - -                             w h e r e   j s . J u c h u u N O   =   @ J u c h u u N o    
         - -                             a n d   j s . J u c h u u G y o u N O   =   @ J u c h u u G y o u N O  
         - -                             a n d   j s . J u c h u u S h o u s a i N O   =   @ J u c h u u S h o u s a i N O  
         - -                     e n d  
                          
          
         - -             f e t c h   n e x t   f r o m    
         - -             c u r s o r I n n e r   i n t o   @ J u c h u u S h o u s a i N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N O , @ N y u u k o D a t e , @ H i k i a t e Z u m i S u u ,  
         - -             @ S h u k k a S i z i Z u m i S u u  
         - -     e n d  
          
         - - c l o s e   c u r s o r I n n e r  
         - - d e a l l o c a t e   c u r s o r I n n e r  
         - - 2 0 2 1 / 0 4 / 1 3   Y . N i s h i k a w a   D E L   _S_鬴癳o0_S_󤕘丒񯟤丒丒g0鍽tW0f0D0丒_0丒0孨蛠E丒N丒丒 
  
         s e t   @ G y o u N O   =   @ G y o u N O   +   1  
  
         - - - K T P   C h a n g e  
  
  
         - -   I n s e r t   s t a t e m e n t s   f o r   p r o c e d u r e   h e r e  
                 - - W H I L E   @ a   > 0  
                 - -     B E G I N  
                 - -     I F   E X I S T S   ( S E L E C T   T O P   1   *   F R O M   D _ J u c h u u S h o u s a i   d j  
                 - -             I N N E R   J O I N   ( S E L E C T   T O P   1   *   F R O M   D _ J u c h u u S h o u s a i   W H E R E   H i k i a t e Z u m i S u u   < >   0  
                 - -             A N D   J u c h u u N O   =   @ J u c h u u N O   A N D   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O   O R D E R   B Y   K a n r i N O   A S C ,   N y u u k o D a t e   A S C )   d j 1  
                 - -             O N   d j . J u c h u u N O   =   d j 1 . J u c h u u N O   A N D   d j . J u c h u u G y o u N O   =   d j 1 . J u c h u u G y o u N O   A N D   d j . J u c h u u S h o u s a i N O   =   d j 1 . J u c h u u S h o u s a i N O   A N D   d j . H i k i a t e Z u m i S u u   < >   0  
                 - -             A N D   d j . J u c h u u N O   =   @ J u c h u u N O   A N D   d j . J u c h u u G y o u N O   =   @ J u c h u u G y o u N O )  
                          
                 - -     B E G I N  
                 - -             I N S E R T   I N T O   [ d b o ] . [ D _ S h u k k a S i z i S h o u s a i ]  
                 - -             (       [ S h u k k a S i z i N O ]  
                 - -             , [ S h u k k a S i z i G y o u N O ]  
                 - -             , [ S h u k k a S i z i S h o u s a i N O ]  
                 - -             , [ S o u k o C D ]  
                 - -             , [ S h o u h i n C D ]  
                 - -             , [ S h o u h i n N a m e ]  
                 - -             , [ S h u k k a S i z i S u u ]  
                 - -             , [ K a n r i N O ]  
                 - -             , [ N y u u k o D a t e ]  
                 - -             , [ S h u k k a Z u m i S u u ]  
                 - -             , [ J u c h u u N O ]  
                 - -             , [ J u c h u u G y o u N O ]  
                 - -             , [ J u c h u u S h o u s a i N O ]  
                 - -             , [ I n s e r t O p e r a t o r ]  
                 - -             , [ I n s e r t D a t e T i m e ]  
                 - -             , [ U p d a t e O p e r a t o r ]  
                 - -             , [ U p d a t e D a t e T i m e ]  
                 - -             )  
  
                 - -             S E L E C T    
                 - -             @ S h u k k a S i z i N O  
                 - -             , @ G y o u N o                                  
                 - -             , ( s e l e c t   i s n u l l ( m a x ( 1 ) , 0 )   +   1   f r o m   D _ S h u k k a S i z i S h o u s a i   w h e r e   S h u k k a S i z i N O   = @ S h u k k a S i z i N O   a n d   S h u k k a S i z i G y o u N O   =   @ G y o u N o   )                                
                 - -             , @ S o u k o C D  
                 - -             , @ S h o u h i n C D  
                 - -             , @ S h o u h i n N a m e  
                 - -             , d j . S h u k k a S i z i Z u m i S u u  
                 - -             , d j . K a n r i N O    
                 - -             , d j . N y u u k o D a t e  
                 - -             , 0  
                 - -             , d j . J u c h u u N O  
                 - -             , d j . J u c h u u G y o u N O  
                 - -             , d j . J u c h u u S h o u s a i N O  
                 - -             , @ O p e r a t o r C D , @ c u r r e n t D a t e , @ O p e r a t o r C D , @ c u r r e n t D a t e  
                 - -             f r o m     D _ J u c h u u S h o u s a i   d j  
                 - -             I N N E R   J O I N   ( S E L E C T   T O P   1   *   F R O M   D _ J u c h u u S h o u s a i   W H E R E   H i k i a t e Z u m i S u u   < >   0  
                 - -             A N D   J u c h u u N O   =   @ J u c h u u N O   A N D   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O   O R D E R   B Y   K a n r i N O   A S C ,   N y u u k o D a t e   A S C )   d j 1  
                 - -             O N   d j . J u c h u u N O   =   d j 1 . J u c h u u N O   A N D   d j . J u c h u u G y o u N O   =   d j 1 . J u c h u u G y o u N O   A N D   d j . J u c h u u S h o u s a i N O   =   d j 1 . J u c h u u S h o u s a i N O   A N D   d j . H i k i a t e Z u m i S u u   < >   0  
                 - -             A N D   d j . J u c h u u N O   =   @ J u c h u u N O   A N D   d j . J u c h u u G y o u N O   =   @ J u c h u u G y o u N O  
  
                 - -             U P D A T E   d j  
                 - -             S E T   d j . H i k i a t e Z u m i S u u   =   C A S E   W H E N   d j . H i k i a t e Z u m i S u u   >   @ a   T H E N   d j . H i k i a t e Z u m i S u u   -   @ a   E L S E   0   E N D ,    
                 - -                     d j . S h u k k a S i z i Z u m i S u u   =   C A S E   W H E N   d j . H i k i a t e Z u m i S u u   >   @ a   T H E N   @ a   E L S E   d j . H i k i a t e Z u m i S u u   E N D ,  
                 - -                     @ b   =   C A S E   W H E N   d j . H i k i a t e Z u m i S u u   >   @ a   T H E N   0   E L S E   @ a   -   d j . H i k i a t e Z u m i S u u   E N D  
                 - -             f r o m     D _ J u c h u u S h o u s a i   d j  
                 - -             I N N E R   J O I N   ( S E L E C T   T O P   1   *   F R O M   D _ J u c h u u S h o u s a i   W H E R E   H i k i a t e Z u m i S u u   < >   0  
                 - -             A N D   J u c h u u N O   =   @ J u c h u u N O   A N D   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O   O R D E R   B Y   K a n r i N O   A S C ,   N y u u k o D a t e   A S C )   d j 1  
                 - -             O N   d j . J u c h u u N O   =   d j 1 . J u c h u u N O   A N D   d j . J u c h u u G y o u N O   =   d j 1 . J u c h u u G y o u N O   A N D   d j . J u c h u u S h o u s a i N O   =   d j 1 . J u c h u u S h o u s a i N O   A N D   d j . H i k i a t e Z u m i S u u   < >   0  
                 - -             A N D   d j . J u c h u u N O   =   @ J u c h u u N O   A N D   d j . J u c h u u G y o u N O   =   @ J u c h u u G y o u N O  
                 - -     E N D  
                 - -     E L S E  
                 - -             B R E A K  
                 - -     S E T   @ a   =   @ b  
                 - - E N D  
                 - - s e t   @ G y o u N o   =   @ G y o u N o   +   1            
                 F E T C H   N E X T   F R O M   c u r s o r 1   I N T O   @ S o u k o C D ,   @ S h o u h i n C D ,   @ S h o u h i n N a m e ,   @ S K M S N O ,   @ H i d d e n _ S h o u h i n C D ,   @ K o n k a i S h u k k a S i z i S u u  
         E N D  
         C L O S E   c u r s o r 1  
         D E A L L O C A T E   c u r s o r 1  
  
 - - T a b l e   D  
 I N S E R T   I N T O   [ d b o ] . [ D _ S h u k k a S i z i H i s t o r y ]  
         (       [ H i s t o r y G u i d ]  
                 , [ S h u k k a S i z i N O ]  
                 , [ S h o r i K B N ]  
                 , [ S t a f f C D ]  
                 , [ S h u k k a Y o t e i D a t e ]  
                 , [ D e n p y o u D a t e ]  
                 , [ K a i k e i Y Y M M ]  
                 , [ T o k u i s a k i C D ]  
                 , [ T o k u i s a k i R y a k u N a m e ]  
                 , [ K o u r i t e n C D ]  
                 , [ K o u r i t e n R y a k u N a m e ]  
                 , [ S h u k k a S i z i D e n p y o u T e k i y o u ]  
                 , [ S h u k k a S i z i s h o H u y o u K B N ]  
                 , [ S h u k k a K a n r y o u K B N ]  
                 , [ T o k u i s a k i N a m e ]  
                 , [ T o k u i s a k i Y u u b i n N O 1 ]  
                 , [ T o k u i s a k i Y u u b i n N O 2 ]  
                 , [ T o k u i s a k i J u u s h o 1 ]  
                 , [ T o k u i s a k i J u u s h o 2 ]  
                 , [ T o k u i s a k i T e l N O 1 - 1 ]  
                 , [ T o k u i s a k i T e l N O 1 - 2 ]  
                 , [ T o k u i s a k i T e l N O 1 - 3 ]  
                 , [ T o k u i s a k i T e l N O 2 - 1 ]  
                 , [ T o k u i s a k i T e l N O 2 - 2 ]  
                 , [ T o k u i s a k i T e l N O 2 - 3 ]  
                 , [ T o k u i s a k i T a n t o u B u s h o N a m e ]  
                 , [ T o k u i s a k i T a n t o u s h a Y a k u s h o k u ]  
                 , [ T o k u i s a k i T a n t o u s h a N a m e ]  
                 , [ K o u r i t e n N a m e ]  
                 , [ K o u r i t e n Y u u b i n N O 1 ]  
                 , [ K o u r i t e n Y u u b i n N O 2 ]  
                 , [ K o u r i t e n J u u s h o 1 ]  
                 , [ K o u r i t e n J u u s h o 2 ]  
                 , [ K o u r i t e n T e l N O 1 - 1 ]  
                 , [ K o u r i t e n T e l N O 1 - 2 ]  
                 , [ K o u r i t e n T e l N O 1 - 3 ]  
                 , [ K o u r i t e n T e l N O 2 - 1 ]  
                 , [ K o u r i t e n T e l N O 2 - 2 ]  
                 , [ K o u r i t e n T e l N O 2 - 3 ]  
                 , [ K o u r i t e n T a n t o u B u s h o N a m e ]  
                 , [ K o u r i t e n T a n t o u s h a Y a k u s h o k u ]  
                 , [ K o u r i t e n T a n t o u s h a N a m e ]  
                 , [ S h u k k a S i z i S h u t u r y o k u K B N ]  
                 , [ S h u k k a S i z i S h u t u r y o k u D a t e T i m e ]  
                 , [ I n s e r t O p e r a t o r ]  
                 , [ I n s e r t D a t e T i m e ]  
                 , [ U p d a t e O p e r a t o r ]  
                 , [ U p d a t e D a t e T i m e ]  
                 , [ H i s t o r y O p e r a t o r ]  
                 , [ H i s t o r y D a t e T i m e ]  
         )  
         S E L E C T    
         @ U n i q u e  
         , i . S h u k k a S i z i N O  
         , 1 0 - - 癳弶 
         , i . S t a f f C D  
         , i . S h u k k a Y o t e i D a t e  
         , i . D e n p y o u D a t e  
         , i . K a i k e i Y Y M M  
         , i . T o k u i s a k i C D  
         , i . T o k u i s a k i R y a k u N a m e  
         , i . K o u r i t e n C D  
         , i . K o u r i t e n R y a k u N a m e  
         , i . S h u k k a S i z i D e n p y o u T e k i y o u  
         , i . S h u k k a S i z i s h o H u y o u K B N  
         , i . S h u k k a K a n r y o u K B N  
         , i . T o k u i s a k i N a m e  
         , i . T o k u i s a k i Y u u b i n N O 1  
         , i . T o k u i s a k i Y u u b i n N O 2  
         , i . T o k u i s a k i J u u s h o 1  
         , i . T o k u i s a k i J u u s h o 2  
         , i . [ T o k u i s a k i T e l N O 1 - 1 ]  
         , i . [ T o k u i s a k i T e l N O 1 - 2 ]  
         , i . [ T o k u i s a k i T e l N O 1 - 3 ]  
         , i . [ T o k u i s a k i T e l N O 2 - 1 ]  
         , i . [ T o k u i s a k i T e l N O 2 - 2 ]  
         , i . [ T o k u i s a k i T e l N O 2 - 3 ]  
         , i . [ T o k u i s a k i T a n t o u B u s h o N a m e ]  
         , i . [ T o k u i s a k i T a n t o u s h a Y a k u s h o k u ]  
         , i . [ T o k u i s a k i T a n t o u s h a N a m e ]  
         , i . K o u r i t e n N a m e  
         , i . K o u r i t e n Y u u b i n N O 1  
         , i . K o u r i t e n Y u u b i n N O 2  
         , i . K o u r i t e n J u u s h o 1  
         , i . K o u r i t e n J u u s h o 2  
         , i . [ K o u r i t e n T e l N O 1 - 1 ]  
         , i . [ K o u r i t e n T e l N O 1 - 2 ]  
         , i . [ K o u r i t e n T e l N O 1 - 3 ]  
         , i . [ K o u r i t e n T e l N O 2 - 1 ]  
         , i . [ K o u r i t e n T e l N O 2 - 2 ]  
         , i . [ K o u r i t e n T e l N O 2 - 3 ]  
         , i . [ K o u r i t e n T a n t o u B u s h o N a m e ]  
         , i . [ K o u r i t e n T a n t o u s h a Y a k u s h o k u ]  
         , i . [ K o u r i t e n T a n t o u s h a N a m e ]  
         , i . [ S h u k k a S i z i S h u t u r y o k u K B N ]  
         , i . [ S h u k k a S i z i S h u t u r y o k u D a t e T i m e ]  
         , i . [ I n s e r t O p e r a t o r ]  
         , i . I n s e r t D a t e T i m e  
         , i . U p d a t e O p e r a t o r  
         , i . U p d a t e D a t e T i m e  
         , @ O p e r a t o r C D  
         , @ c u r r e n t D a t e  
         F R O M   [ d b o ] . [ D _ S h u k k a S i z i ]   A S   i  
 w h e r e   i . S h u k k a S i z i N O = @ S h u k k a S i z i N O  
  
 - - T a b l e E  
 I N S E R T   I N T O   [ d b o ] . [ D _ S h u k k a S i z i M e i s a i H i s t o r y ]  
 (  
                 [ H i s t o r y G u i d ]  
                 , [ S h u k k a S i z i N O ]  
                 , [ S h u k k a S i z i G y o u N O ]  
                 , [ G y o u H y o u z i J u n ]  
                 , [ S h o r i K B N ]  
                 , [ K o u r i t e n C D ]  
                 , [ K o u r i t e n R y a k u N a m e ]  
                 , [ B r a n d C D ]  
                 , [ S h o u h i n C D ]  
                 , [ S h o u h i n N a m e ]  
                 , [ J A N C D ]  
                 , [ C o l o r R y a k u N a m e ]  
                 , [ C o l o r N O ]  
                 , [ S i z e N O ]  
                 , [ K a k e r i t u ]  
                 , [ S h u k k a S i z i S u u ]  
                 , [ T a n i C D ]  
                 , [ U r i a g e T a n k a ]  
                 , [ U r i a g e T a n k a S h o u h i z e i ]  
                 , [ U r i a g e H o n t a i T a n k a ]  
                 , [ U r i a g e K i n g a k u ]  
                 , [ U r i a g e H o n t a i K i n g a k u ]  
                 , [ U r i a g e S h o u h i z e i G a k u ]  
                 , [ S h u k k a S i z i M e i s a i T e k i y o u ]  
                 , [ S o u k o C D ]  
                 , [ S h u k k a K a n r y o u K B N ]  
                 , [ S h u k k a Z u m i S u u ]  
                 , [ J u c h u u N O ]  
                 , [ J u c h u u G y o u N O ]  
                 , [ K o u r i t e n N a m e ]  
                 , [ K o u r i t e n Y u u b i n N O 1 ]  
                 , [ K o u r i t e n Y u u b i n N O 2 ]  
                 , [ K o u r i t e n J u u s h o 1 ]  
                 , [ K o u r i t e n J u u s h o 2 ]  
                 , [ K o u r i t e n T e l N O 1 - 1 ]  
                 , [ K o u r i t e n T e l N O 1 - 2 ]  
                 , [ K o u r i t e n T e l N O 1 - 3 ]  
                 , [ K o u r i t e n T e l N O 2 - 1 ]  
                 , [ K o u r i t e n T e l N O 2 - 2 ]  
                 , [ K o u r i t e n T e l N O 2 - 3 ]  
                 , [ I n s e r t O p e r a t o r ]  
                 , [ I n s e r t D a t e T i m e ]  
                 , [ U p d a t e O p e r a t o r ]  
                 , [ U p d a t e D a t e T i m e ]  
                 , [ H i s t o r y O p e r a t o r ]  
                 , [ H i s t o r y D a t e T i m e ]  
                 )  
 S E L E C T    
                 @ U n i q u e  
                 , j . [ S h u k k a S i z i N O ]  
                 , j . [ S h u k k a S i z i G y o u N O ]  
                 , j . [ G y o u H y o u z i J u n ]  
                 , 1 0 - - 癳弶 
                 , j . [ K o u r i t e n C D ]  
                 , j . [ K o u r i t e n R y a k u N a m e ]  
                 , j . [ B r a n d C D ]  
                 , j . [ S h o u h i n C D ]  
                 , j . [ S h o u h i n N a m e ]  
                 , j . [ J A N C D ]  
                 , j . [ C o l o r R y a k u N a m e ]  
                 , j . [ C o l o r N O ]  
                 , j . [ S i z e N O ]  
                 , j . [ K a k e r i t u ]  
                 , j . [ S h u k k a S i z i S u u ]  
                 , j . [ T a n i C D ]  
                 , j . [ U r i a g e T a n k a ]  
                 , j . [ U r i a g e T a n k a S h o u h i z e i ]  
                 , j . [ U r i a g e H o n t a i T a n k a ]  
                 , j . [ U r i a g e K i n g a k u ]  
                 , j . [ U r i a g e H o n t a i K i n g a k u ]  
                 , j . [ U r i a g e S h o u h i z e i G a k u ]  
                 , j . [ S h u k k a S i z i M e i s a i T e k i y o u ]  
                 , j . [ S o u k o C D ]  
                 , j . [ S h u k k a K a n r y o u K B N ]  
                 , j . [ S h u k k a Z u m i S u u ]  
                 , j . [ J u c h u u N O ]  
                 , j . [ J u c h u u G y o u N O ]  
                 , j . [ K o u r i t e n N a m e ]  
                 , j . [ K o u r i t e n Y u u b i n N O 1 ]  
                 , j . [ K o u r i t e n Y u u b i n N O 2 ]  
                 , j . [ K o u r i t e n J u u s h o 1 ]  
                 , j . [ K o u r i t e n J u u s h o 2 ]  
                 , j . [ K o u r i t e n T e l N O 1 - 1 ]  
                 , j . [ K o u r i t e n T e l N O 1 - 2 ]  
                 , j . [ K o u r i t e n T e l N O 1 - 3 ]  
                 , j . [ K o u r i t e n T e l N O 2 - 1 ]  
                 , j . [ K o u r i t e n T e l N O 2 - 2 ]  
                 , j . [ K o u r i t e n T e l N O 2 - 3 ]  
                 , j . [ I n s e r t O p e r a t o r ]  
                 , j . [ I n s e r t D a t e T i m e ]  
                 , j . [ U p d a t e O p e r a t o r ]  
                 , j . [ U p d a t e D a t e T i m e ]  
                 , @ O p e r a t o r C D  
                 , @ c u r r e n t D a t e  
 F R O M   [ d b o ] . [ D _ S h u k k a S i z i M e i s a i ]   A S   j  
 w h e r e   j . S h u k k a S i z i N O = @ S h u k k a S i z i N O  
  
 - - T a b l e F  
 I N S E R T   I N T O   [ d b o ] . [ D _ S h u k k a S i z i S h o u s a i H i s t o r y ]  
 (  
         [ H i s t o r y G u i d ]  
         , [ S h u k k a S i z i N O ]  
         , [ S h u k k a S i z i G y o u N O ]  
         , [ S h u k k a S i z i S h o u s a i N O ]  
         , [ S h o r i K B N ]  
         , [ S o u k o C D ]  
         , [ S h o u h i n C D ]  
         , [ S h o u h i n N a m e ]  
         , [ S h u k k a S i z i S u u ]  
         , [ K a n r i N O ]  
         , [ N y u u k o D a t e ]  
         , [ S h u k k a Z u m i S u u ]  
         , [ J u c h u u N O ]  
         , [ J u c h u u G y o u N O ]  
         , [ J u c h u u S h o u s a i N O ]  
         , [ I n s e r t O p e r a t o r ]  
         , [ I n s e r t D a t e T i m e ]  
         , [ U p d a t e O p e r a t o r ]  
         , [ U p d a t e D a t e T i m e ]  
         , [ H i s t o r y O p e r a t o r ]  
         , [ H i s t o r y D a t e T i m e ]  
 )  
 S E L E C T    
 @ U n i q u e ,  
 [ S h u k k a S i z i N O ]  
                         , [ S h u k k a S i z i G y o u N O ]  
                         , [ S h u k k a S i z i S h o u s a i N O ]  
                         , 1 0   - - 癳弶 
                         , [ S o u k o C D ]  
                         , [ S h o u h i n C D ]  
                         , [ S h o u h i n N a m e ]  
                         , [ S h u k k a S i z i S u u ]  
                         , [ K a n r i N O ]  
                         , [ N y u u k o D a t e ]  
                         , [ S h u k k a Z u m i S u u ]  
                         , [ J u c h u u N O ]  
                         , [ J u c h u u G y o u N O ]  
                         , [ J u c h u u S h o u s a i N O ]  
                         , [ I n s e r t O p e r a t o r ]  
                         , [ I n s e r t D a t e T i m e ]  
                         , [ U p d a t e O p e r a t o r ]  
                         , [ U p d a t e D a t e T i m e ]  
                         , @ O p e r a t o r C D  
                         , @ c u r r e n t D a t e  
 F R O M   [ d b o ] . [ D _ S h u k k a S i z i S h o u s a i ]  
 w h e r e   S h u k k a S i z i N O = @ S h u k k a S i z i N O  
  
 - - K o n k a i _ P r i c e  
  
 - - 2 0 2 1 / 0 4 / 1 3   Y . N i s h i k a w a   D E L   _S_鬴癳o0_S_󤕘丒񯟤丒丒g0鍽tW0f0D0丒_0丒0孨蛠E丒N丒丒 
 - - - - T a b l e   G     - - 龔燫~0_0o0鹝ck宊 
 - - U P D A T E     A  
 - - S E T        
 - -     H i k i a t e Z u m i S u u   =   A . H i k i a t e Z u m i S u u   -   B . K o n k a i S h u k k a S i z i S u u   - -   K T P   A d d  
 - -     , S h u k k a S i z i Z u m i S u u = A . S h u k k a S i z i Z u m i S u u   +   B . K o n k a i S h u k k a S i z i S u u  
 - -     , U p d a t e O p e r a t o r = @ O p e r a t o r C D  
 - -     , U p d a t e D a t e T i m e = @ c u r r e n t D a t e  
 - - F R O M   D _ J u c h u u M e i s a i   A  
 - - i n n e r   j o i n   # T e m p _ D e t a i l s   B  
 - - o n   A . J u c h u u N O   =   L E F T ( ( B . S K M S N O ) ,   C H A R I N D E X ( ' - ' ,   ( B . S K M S N O ) )   -   1 )    
 - - a n d   A . J u c h u u G y o u N O = R I G H T ( B . S K M S N O ,   L E N ( B . S K M S N O )   -   C H A R I N D E X ( ' - ' ,   B . S K M S N O ) )  
 - - 2 0 2 1 / 0 4 / 1 3   Y . N i s h i k a w a   D E L   _S_鬴癳o0_S_󤕘丒񯟤丒丒g0鍽tW0f0D0丒_0丒0孨蛠E丒N丒丒 
  
 - - D _ J u c h u u M e i s a i  
 U P D A T E     A  
 S E T   [ S h u k k a S i z i K a n r y o u K B N ] =   c a s e   w h e n   A . J u c h u u S u u < = A . S h u k k a S i z i Z u m i S u u   t h e n   1    
                                                                         w h e n   C . K a n r y o = 1   t h e n   1   e l s e   0   e n d  
 F R O M   D _ J u c h u u M e i s a i   A , # T e m p _ D e t a i l s   C  
 w h e r e   A . J u c h u u N O   =   L E F T ( ( C . S K M S N O ) ,   C H A R I N D E X ( ' - ' ,   ( C . S K M S N O ) )   -   1 )    
 - - a n d   A . S h o u h i n C D = C . S h o u h i n C D  
  
 - - D _ J u c h u u  
 U P D A T E     A  
 S E T           A . [ S h u k k a S i z i K a n r y o u K B N ]   =   B . S h u k k a S i z i K a n r y o u K B N  
 F R O M   D _ J u c h u u   a s   A  
 I N N E R   J O I N   ( s e l e c t   J u c h u u N O , M I N ( S h u k k a S i z i K a n r y o u K B N )   a s   S h u k k a S i z i K a n r y o u K B N    
                         f r o m   D _ J u c h u u M e i s a i   C ,   # T e m p _ D e t a i l s   D  
                         w h e r e   C . J u c h u u N O = L E F T ( D . S K M S N O ,   C H A R I N D E X ( ' - ' ,   D . S K M S N O )   -   1 )  
                         g r o u p   b y   J u c h u u N O  
 )   a s   B  
 O N   A . J u c h u u N O = B . J u c h u u N O  
  
 - - k t p   c a l l   f n c H i k i a t e  
 e x e c   d b o . F n c _ H i k i a t e   1 2 , @ S h u k k a S i z i N O , 1 0 , @ O p e r a t o r C D  
  
 - - 򎑤򭅰􀅀�0 
 U P D A T E   M _ S t a f f    
 s e t   U s e d F l g   =   1    
 w h e r e   S t a f f C D = @ S t a f f C D  
 a n d     C h a n g e D a t e   =   ( s e l e c t   C h a n g e D a t e   f r o m   F _ S t a f f ( @ S h i p p i n g D a t e )   w h e r e   S t a f f C D   =   @ S t a f f C D )  
  
 - - L _ L o g  
 d e c l a r e   @ O p e r a t o r M o d e   v a r c h a r ( 5 0 ) = ' 癳弶'  
 e x e c   d b o . L _ L o g _ I n s e r t   @ O p e r a t o r C D , @ P r o g r a m , @ P C , @ O p e r a t o r M o d e , @ S h u k k a S i z i N O  
  
 - - �0丒�0丒鈳愓N豬9�- - JRd丒 
 e x e c   [ d b o ] . [ D _ E x c l u s i v e _ R e m o v e _ N O ]   1 , @ O p e r a t o r C D , @ P r o g r a m , @ P C  
          
 E N D  
  
 G O  
  
  
 