 BEGIN TRY 
 Drop Procedure dbo.[ShukkasiziNyuuryoku_Insert]
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
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_Insert]
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
					TokuisakiJuusho1	varchar(50) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho2    varchar(50) COLLATE DATABASE_DEFAULT,
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
					KouritenJuusho1  varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2	 varchar(50) COLLATE DATABASE_DEFAULT,
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
				TokuisakiJuusho1	varchar(50) ,
				TokuisakiJuusho2    varchar(50) ,
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
				KouritenJuusho1 varchar(50) ,
				KouritenJuusho2	varchar(50) ,
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
					KouritenJuusho1  varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2	 varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenTel11    varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel12	 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel13	 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel21   varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel22   varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel23   varchar(5) COLLATE DATABASE_DEFAULT
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
					KouritenJuusho1  varchar(50),
					KouritenJuusho2	 varchar(50),
					KouritenTel11    varchar(6),	
					KouritenTel12	 varchar(5),	
					KouritenTel13	 varchar(5),	
					KouritenTel21   varchar(6),	
					KouritenTel22   varchar(5),	
					KouritenTel23   varchar(5)
				)
				exec sp_xml_removedocument @idoc

declare @ShippingDate as varchar(10) = (select ShukkaYoteiDate from #Temp_Header)
, @ShukkaSiziNO varchar(12)=(select ShukkaSiziNO from #Temp_Header )
, @StaffCD varchar(20) = (select StaffCD from #Temp_Header)
, @OperatorCD as varchar(10) =(select OperatorCD from #Temp_Header)
, @Program varchar(100) = (select ProgramID from #Temp_Header)
,@PC       varchar(30) = (select PC from #Temp_Header)
,@KeyItem  varchar(100)= (select ShukkaSiziNO from #Temp_Header)
, @currentDate as datetime = getdate()
, @Unique as uniqueidentifier = NewID()

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
	ShukkaSiziNO,TM.StaffCD,ShukkaYoteiDate,DenpyouDate,CONVERT(int, FORMAT(Cast(TM.ShukkaYoteiDate as Date), 'yyyyMM'))
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
	
		@ShukkaSiziNO --邱ｨ髮・==> {繝・・繝悶Ν霆｢騾∽ｻ墓ｧ假ｼ｡笘・→蜷後§蛟､}
		,ROW_NUMBER() OVER(ORDER BY (SELECT 1))
		,ROW_NUMBER() OVER(ORDER BY (SELECT 1))
		,case when TD.KouritenCD is null then DJ.KouritenCD else TD.KouritenCD end
		,case when TD.KouritenRyakuName is null then DJ.KouritenRyakuName else TD.KouritenRyakuName end
		,FS.BrandCD
		,TD.ShouhinCD
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
		,TD.ShukkaSiziMeisaiTekiyou
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
--declare @count int=1;
--while @count <= (select count(*) from #Temp_Details) 
--begin
--   INSERT INTO [dbo].[D_ShukkaSiziShousai]
--		(	[ShukkaSiziNO]
--			,[ShukkaSiziGyouNO]
--			,[ShukkaSiziShousaiNO]
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
--		)

--		SELECT 
--			@ShukkaSiziNO
--			,ROW_NUMBER() OVER(ORDER BY (SELECT 1))
--			,ROW_NUMBER() OVER(ORDER BY (SELECT 1))
--			,(select top 1 SoukoCD from #Temp_Details) 
--			,(select top 1 ShouhinCD from #Temp_Details)
--			,(select top 1 ShouhinName from #Temp_Details)
--			,dj.ShukkaSiziZumiSuu
--			,dj.KanriNO	-- 邱ｨ髮・
--			,dj.NyuukoDate-- 邱ｨ髮・
--			,0
--			,dj.JuchuuNO-- 邱ｨ髮・
--			,dj.JuchuuGyouNO-- 邱ｨ髮・
--			,dj.JuchuuShousaiNO-- 邱ｨ髮・
--			,@OperatorCD,@currentDate,@OperatorCD,@currentDate
--		from  D_JuchuuShousai dj
--		where dj.JuchuuNO = LEFT((select top 1 SKMSNO from #Temp_Details), CHARINDEX('-', (select top 1 SKMSNO from #Temp_Details)) - 1) 
--		and HikiateZumiSuu <> 0
--		order by dj.KanriNO asc,dj.NyuukoDate asc
--    set @count = @count + 1;
--	if(@count=(select count(*) from #Temp_Details))
--	begin
--		break;
--	end
--end

--TableD
INSERT INTO [dbo].[D_ShukkaSiziShousai]
		(	[ShukkaSiziNO]
			,[ShukkaSiziGyouNO]
			,[ShukkaSiziShousaiNO]
			,[SoukoCD]
			,[ShouhinCD]
			,[ShouhinName]
			,[ShukkaSiziSuu]
			,[KanriNO]
			,[NyuukoDate]
			,[ShukkaZumiSuu]
			,[JuchuuNO]
			,[JuchuuGyouNO]
			,[JuchuuShousaiNO]
			,[InsertOperator]
			,[InsertDateTime]
			,[UpdateOperator]
			,[UpdateDateTime]
		)

		SELECT 
			@ShukkaSiziNO
			,ROW_NUMBER() OVER(ORDER BY (SELECT 1))
			,ROW_NUMBER() OVER(ORDER BY (SELECT 1))
			,D.SoukoCD
			,D.ShouhinCD
			,D.ShouhinName
			,dj.ShukkaSiziZumiSuu
			,dj.KanriNO	-- 邱ｨ髮・
			,dj.NyuukoDate-- 邱ｨ髮・
			,0
			,dj.JuchuuNO-- 邱ｨ髮・
			,dj.JuchuuGyouNO-- 邱ｨ髮・
			,dj.JuchuuShousaiNO-- 邱ｨ髮・
			,@OperatorCD,@currentDate,@OperatorCD,@currentDate
		from  D_JuchuuShousai dj,#Temp_Details D
		where dj.JuchuuNO = LEFT((D.SKMSNO), CHARINDEX('-', (D.SKMSNO)) - 1) 
		and HikiateZumiSuu <> 0
		order by dj.KanriNO asc,dj.NyuukoDate asc

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
	,10--新規
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
		,10--譁ｰ隕・
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

--TableF
INSERT INTO [dbo].[D_ShukkaSiziShousaiHistory]
(
	[HistoryGuid]
	,[ShukkaSiziNO]
	,[ShukkaSiziGyouNO]
	,[ShukkaSiziShousaiNO]
	,[ShoriKBN]
	,[SoukoCD]
	,[ShouhinCD]
	,[ShouhinName]
	,[ShukkaSiziSuu]
	,[KanriNO]
	,[NyuukoDate]
	,[ShukkaZumiSuu]
	,[JuchuuNO]
	,[JuchuuGyouNO]
	,[JuchuuShousaiNO]
	,[InsertOperator]
	,[InsertDateTime]
	,[UpdateOperator]
	,[UpdateDateTime]
	,[HistoryOperator]
	,[HistoryDateTime]
)
SELECT 
@Unique,
[ShukkaSiziNO]
			,[ShukkaSiziGyouNO]
			,[ShukkaSiziShousaiNO]
			,10 --譁ｰ隕・
			,[SoukoCD]
			,[ShouhinCD]
			,[ShouhinName]
			,[ShukkaSiziSuu]
			,[KanriNO]
			,[NyuukoDate]
			,[ShukkaZumiSuu]
			,[JuchuuNO]
			,[JuchuuGyouNO]
			,[JuchuuShousaiNO]
			,[InsertOperator]
			,[InsertDateTime]
			,[UpdateOperator]
			,[UpdateDateTime]
			,@OperatorCD
			,@currentDate
FROM [dbo].[D_ShukkaSiziShousai]

--※シート「消込順」参照

--Table G --追加または修正後
UPDATE  A
SET	ShukkaSiziZumiSuu=A.ShukkaSiziZumiSuu + B.KonkaiShukkaSiziSuu
	,UpdateOperator=@OperatorCD
	,UpdateDateTime=@currentDate
FROM D_JuchuuMeisai A
inner join #Temp_Details B
on A.JuchuuNO = LEFT((B.SKMSNO), CHARINDEX('-', (B.SKMSNO)) - 1) 
and A.JuchuuGyouNO=RIGHT(B.SKMSNO, LEN(B.SKMSNO) - CHARINDEX('-', B.SKMSNO))

--D_JuchuuMeisai
UPDATE  A
SET	[ShukkaSiziKanryouKBN]= case when A.JuchuuSuu<=A.ShukkaSiziZumiSuu then 1 
									when C.Kanryo=1 then 1 else 0 end
FROM D_JuchuuMeisai A,#Temp_Details C
where A.JuchuuNO = LEFT((C.SKMSNO), CHARINDEX('-', (C.SKMSNO)) - 1) 
and A.ShouhinCD=C.ShouhinCD

--D_Juchuu
UPDATE	A
SET		[ShukkaSiziKanryouKBN] = B.ShukkaSiziKanryouKBN
FROM D_Juchuu as A
INNER JOIN (select JuchuuNO,MIN(ShukkaSiziKanryouKBN) as ShukkaSiziKanryouKBN 
			from D_JuchuuMeisai C, #Temp_Details D
			where C.JuchuuNO=LEFT(D.SKMSNO, CHARINDEX('-', D.SKMSNO) - 1)
			group by JuchuuNO
) as B
ON A.JuchuuNO=B.JuchuuNO

--スタッフマスタ
UPDATE M_Staff 
set UsedFlg = 1 
where StaffCD=@StaffCD
and  ChangeDate = (select ChangeDate from F_Staff(@ShippingDate) where StaffCD = @StaffCD)

--L_Log
exec dbo.L_Log_Insert @OperatorCD,@Program,@PC,'New' ,@KeyItem


--テーブル転送仕様Ｙ
EXEC [dbo].[D_Exclusive_Delete]
		1,
		@ShukkaSiziNO;

Drop Table #Temp_Header
Drop Table #Temp_Details

END

