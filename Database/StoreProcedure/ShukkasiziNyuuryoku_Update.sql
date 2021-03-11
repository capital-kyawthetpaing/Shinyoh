 BEGIN TRY 
 Drop Procedure dbo.[ShukkasiziNyuuryoku_Update]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<SWE>
-- Create date: <06-03-2021>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_Update]
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
					Hidden_ShouhinCD varchar(50) COLLATE DATABASE_DEFAULT
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
					Hidden_ShouhinCD varchar(50)
				)
				exec sp_xml_removedocument @idoc

declare @ShippingDate as varchar(10) = (select ShukkaYoteiDate from #Temp_Header)
, @ShukkaSiziNO varchar(100)=(select ShukkaSiziNO from #Temp_Header )
, @StaffCD varchar(20) = (select StaffCD from #Temp_Header)
, @OperatorCD as varchar(10) =(select OperatorCD from #Temp_Header)
, @Program varchar(100) = (select ProgramID from #Temp_Header)
,@PC       varchar(30) = (select PC from #Temp_Header)
, @currentDate as datetime = getdate()
, @Unique_21 as uniqueidentifier = NewID()
,@Unique_20 as uniqueidentifier = NewID()
,@row as int =0

--TableA
UPDATE [dbo].[D_ShukkaSizi]
SET [StaffCD]=TM.StaffCD
	,[ShukkaYoteiDate]=TM.ShukkaYoteiDate
	,[DenpyouDate]=TM.DenpyouDate
	,[KaikeiYYMM]=CONVERT(int, FORMAT(Cast(TM.ShukkaYoteiDate as Date), 'yyyyMM'))
	,[TokuisakiCD]=TM.TokuisakiCD
	,[TokuisakiRyakuName]=case when FT.ShokutiFLG=0 then FT.TokuisakiRyakuName else TM.TokuisakiRyakuName end
	,[KouritenCD]=TM.KouritenCD
	,[KouritenRyakuName]=case when FK.ShokutiFLG=0 then FK.KouritenRyakuName else TM.KouritenRyakuName end
	,[ShukkaSiziDenpyouTekiyou]=TM.ShukkaSiziDenpyouTekiyou
	,[ShukkaSizishoHuyouKBN]=TM.ShukkaSizishoHuyouKBN
	,[ShukkaKanryouKBN]=0
	,[TokuisakiName]=case when FT.ShokutiFLG=0 then FT.TokuisakiName else TM.TokuisakiName end
	,[TokuisakiYuubinNO1]=case when FT.ShokutiFLG=0 then FT.YuubinNO1 else TM.TokuisakiYuubinNO1 end
	,[TokuisakiYuubinNO2]=case when FT.ShokutiFLG=0 then FT.YuubinNO2 else TM.TokuisakiYuubinNO2 end
	,[TokuisakiJuusho1]=case when FT.ShokutiFLG=0 then FT.Juusho1 else TM.TokuisakiJuusho1 end
	,[TokuisakiJuusho2]=case when FT.ShokutiFLG=0 then FT.Juusho2 else TM.TokuisakiJuusho2 end
	,[TokuisakiTelNO1-1]=case when FT.ShokutiFLG=0 then FT.Tel11 else TM.TokuisakiTel11 end
	,[TokuisakiTelNO1-2]=case when FT.ShokutiFLG=0 then FT.Tel12 else TM.TokuisakiTel12 end
	,[TokuisakiTelNO1-3]=case when FT.ShokutiFLG=0 then FT.Tel13 else TM.TokuisakiTel13 end
	,[TokuisakiTelNO2-1]=case when FT.ShokutiFLG=0 then FT.Tel21 else TM.TokuisakiTel21 end
	,[TokuisakiTelNO2-2]=case when FT.ShokutiFLG=0 then FT.Tel22 else TM.TokuisakiTel22 end
	,[TokuisakiTelNO2-3]=case when FT.ShokutiFLG=0 then FT.Tel23 else TM.TokuisakiTel23 end
	,[TokuisakiTantouBushoName]=case when FT.ShokutiFLG=0 then FT.TantouBusho else NULL end
	,[TokuisakiTantoushaYakushoku]=case when FT.ShokutiFLG=0 then FT.TantouYakushoku else NULL end
	,[TokuisakiTantoushaName]=case when FT.ShokutiFLG=0 then FT.TantoushaName else NULL end
	,[KouritenName]=case when FK.ShokutiFLG=0 then FK.KouritenName else TM.KouritenName end
	,[KouritenYuubinNO1]=case when FK.ShokutiFLG=0 then FK.YuubinNO1 else TM.KouritenYuubinNO1 end
	,[KouritenYuubinNO2]=case when FK.ShokutiFLG=0 then FK.YuubinNO2 else TM.KouritenYuubinNO2 end
	,[KouritenJuusho1]=case when FK.ShokutiFLG=0 then FK.Juusho1 else TM.KouritenJuusho1 end
	,[KouritenJuusho2]=case when FK.ShokutiFLG=0 then FK.Juusho2 else TM.KouritenJuusho2 end
	,[KouritenTelNO1-1]=case when FK.ShokutiFLG=0 then FK.Tel11 else TM.KouritenTel11 end
	,[KouritenTelNO1-2]=case when FK.ShokutiFLG=0 then FK.Tel12 else TM.KouritenTel12 end
	,[KouritenTelNO1-3]=case when FK.ShokutiFLG=0 then FK.Tel13 else TM.KouritenTel13 end
	,[KouritenTelNO2-1]=case when FK.ShokutiFLG=0 then FK.Tel21 else TM.KouritenTel21 end
	,[KouritenTelNO2-2]=case when FK.ShokutiFLG=0 then FK.Tel22 else TM.KouritenTel22 end
	,[KouritenTelNO2-3]=case when FK.ShokutiFLG=0 then FK.Tel23 else TM.KouritenTel23 end
	,[KouritenTantouBushoName]=case when FK.ShokutiFLG=0 then FK.TantouBusho else NULL end
	,[KouritenTantoushaYakushoku]=case when FK.ShokutiFLG=0 then FK.TantouYakushoku else NULL end
	,[KouritenTantoushaName]=case when FK.ShokutiFLG=0 then FK.TantoushaName else NULL end
	,[ShukkaSiziShuturyokuKBN]=0
	,[ShukkaSiziShuturyokuDateTime] = NULL
	,[UpdateOperator]=@OperatorCD
	,[UpdateDateTime]=@currentDate
FROM [#Temp_Header] TM
	left outer join F_Tokuisaki(@ShippingDate) FT on FT.TokuisakiCD=TM.TokuisakiCD
	left outer join F_Kouriten(@ShippingDate) FK on FK.KouritenCD=TM.KouritenCD
where D_Shukkasizi.ShukkaSiziNO=TM.ShukkaSiziNO

--TableB
UPDATE [dbo].[D_ShukkaSiziMeisai] 
SET [GyouHyouziJun]=@row, @row = @row + 1
	,[KouritenCD]=case when TD.KouritenCD is null then DJ.KouritenCD else TD.KouritenCD end
	,[KouritenRyakuName]=case when TD.KouritenRyakuName is null then DJ.KouritenRyakuName else TD.KouritenRyakuName end
	,[BrandCD]=FS.BrandCD
	,[ShouhinCD]=TD.ShouhinCD
	,[ShouhinName]=TD.ShouhinName
	,[JANCD]=FS.JANCD
	,[ColorRyakuName]=TD.ColorRyakuName
	,[ColorNO]=TD.ColorNO
	,[SizeNO]=TD.SizeNO
	,[Kakeritu]=1
	,[ShukkaSiziSuu]=TD.KonkaiShukkaSiziSuu
	,[TaniCD]=FS.TaniCD
	,[UriageTanka]=TD.UriageTanka
	,[UriageTankaShouhizei]=0
	,[UriageHontaiTanka]=0
	,[UriageKingaku]=TD.UriageKingaku
	,[UriageHontaiKingaku]=0
	,[UriageShouhizeiGaku]=0
	,[ShukkaSiziMeisaiTekiyou]=TD.ShukkaSiziMeisaiTekiyou
	,[SoukoCD]=TD.SoukoCD
	,[ShukkaKanryouKBN]=0
	,[ShukkaZumiSuu]=0
	,[JuchuuNO]=LEFT(TD.SKMSNO, CHARINDEX('-', TD.SKMSNO) - 1) 
	,[JuchuuGyouNO]=RIGHT(TD.SKMSNO, LEN(TD.SKMSNO) - CHARINDEX('-', TD.SKMSNO))
	,[KouritenName]=case when TD.KouritenName is null then DJ.KouritenName else TD.KouritenName end
	,[KouritenYuubinNO1]=case when TD.KouritenYuubinNO1  is null then DJ.KouritenYuubinNO1 else TD.KouritenYuubinNO1 end
	,[KouritenYuubinNO2]=case when TD.KouritenYuubinNO2 is null then DJ.KouritenYuubinNO2 else TD.KouritenYuubinNO2 end
	,[KouritenJuusho1]=case when TD.KouritenJuusho1 is null then DJ.KouritenJuusho1 else TD.KouritenJuusho1 end
	,[KouritenJuusho2]=case when TD.KouritenJuusho2 is null then DJ.KouritenJuusho2 else TD.KouritenJuusho2 end
	,[KouritenTelNO1-1]=case when TD.KouritenTel11 is null then DJ.[KouritenTelNO1-1] else TD.KouritenTel11 end
	,[KouritenTelNO1-2]=case when TD.KouritenTel12 is null then DJ.[KouritenTelNO1-2] else TD.KouritenTel12 end
	,[KouritenTelNO1-3]=case when TD.KouritenTel13 is null then DJ.[KouritenTelNO1-3] else TD.KouritenTel13 end
	,[KouritenTelNO2-1]=case when TD.KouritenTel21 is null then DJ.[KouritenTelNO2-1] else TD.KouritenTel21 end
	,[KouritenTelNO2-2]=case when TD.KouritenTel22 is null then DJ.[KouritenTelNO2-2] else TD.KouritenTel23 end
	,[KouritenTelNO2-3]=case when TD.KouritenTel23 is null then DJ.[KouritenTelNO2-3] else TD.KouritenTel23 end
	,[KouritenTantouBushoName]=NULL
	,[KouritenTantoushaYakushoku]=NULL
	,[KouritenTantoushaName]=NULL
	,[UpdateOperator]=@OperatorCD
	,[UpdateDateTime]=@currentDate
FROM #Temp_Details TD
	LEFT OUTER JOIN D_Juchuu DJ
	ON DJ.JuchuuNO=LEFT(TD.SKMSNO, CHARINDEX('-', TD.SKMSNO) - 1) 
	LEFT OUTER JOIN [dbo].[F_Shouhin](@ShippingDate) FS
	ON FS.ShouhinCD=TD.Hidden_ShouhinCD
where D_ShukkaSiziMeisai.ShukkaSiziNO=@ShukkaSiziNO
and D_ShukkaSiziMeisai.JuchuuNO=LEFT(TD.SKMSNO, CHARINDEX('-', TD.SKMSNO) - 1) 
and D_ShukkaSiziMeisai.JuchuuGyouNO=RIGHT(TD.SKMSNO, LEN(TD.SKMSNO) - CHARINDEX('-', TD.SKMSNO))

--TableC
declare @GyouNo as smallint = 1
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

    -- Insert statements for procedure here
		WHILE @a >0
			BEGIN
			IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai dj
				INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
				AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO ORDER BY KanriNO ASC, NyuukoDate ASC) dj1
				ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
				AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO)
			
			BEGIN
				UPDATE [dbo].[D_ShukkaSiziShousai]
				SET [SoukoCD] =@SoukoCD
					,[ShouhinCD] =@ShouhinCD
					,[ShouhinName] =@ShouhinName
					,ShukkaSiziSuu=dj.ShukkaSiziZumiSuu
					,KanriNO=dj.KanriNO
					,NyuukoDate=dj.NyuukoDate
					,ShukkaZumiSuu=0
					,JuchuuNO=dj.JuchuuNO
					,JuchuuGyouNO=dj.JuchuuGyouNO
					,JuchuuShousaiNO=dj.JuchuuShousaiNO
					,[UpdateOperator]=@OperatorCD
					,[UpdateDateTime]=@currentDate
				from  D_JuchuuShousai dj
				INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
				AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO ORDER BY KanriNO ASC, NyuukoDate ASC) dj1
				ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
				AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO
				where D_ShukkaSiziShousai.ShukkaSiziNO=@ShukkaSiziNO

				UPDATE dj
				SET dj.HikiateZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN dj.HikiateZumiSuu - @a ELSE 0 END, 
					dj.ShukkaSiziZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN @a ELSE dj.HikiateZumiSuu END,
					@b = CASE WHEN dj.HikiateZumiSuu > @a THEN 0 ELSE @a - dj.HikiateZumiSuu END
				from  D_JuchuuShousai dj
				INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
				AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO ORDER BY KanriNO ASC, NyuukoDate ASC) dj1
				ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
				AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO
			END
			ELSE
				BREAK
			SET @a = @b
		END
		set @GyouNo = @GyouNo + 1		
		FETCH NEXT FROM cursor1 INTO @SoukoCD, @ShouhinCD, @ShouhinName, @SKMSNO, @Hidden_ShouhinCD, @KonkaiShukkaSiziSuu
	END
	CLOSE cursor1
	DEALLOCATE cursor1


--TableD
INSERT INTO [dbo].[D_ShukkaSiziHistory]
	(
		[HistoryGuid]
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
	@Unique_20
	,i.ShukkaSiziNO
	,20-- Before correction
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

INSERT INTO [dbo].[D_ShukkaSiziHistory]
	(
		[HistoryGuid]
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
	@Unique_21
	,i.ShukkaSiziNO
	,21--After modification
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
WHERE i.ShukkaSiziNO=@ShukkaSiziNO


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
		@Unique_20
		,j.[ShukkaSiziNO]
		,j.[ShukkaSiziGyouNO]
		,j.[GyouHyouziJun]
		,20--Before correction
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
		,j.[ShukkaSiziSuu]*(-1)
		,j.[TaniCD]
		,j.[UriageTanka]*(-1)
		,j.[UriageTankaShouhizei]*(-1)
		,j.[UriageHontaiTanka]*(-1)
		,j.[UriageKingaku]*(-1)
		,j.[UriageHontaiKingaku]*(-1)
		,j.[UriageShouhizeiGaku]*(-1)
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
WHERE j.ShukkaSiziNO=@ShukkaSiziNO

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
		@Unique_21
		,j.[ShukkaSiziNO]
		,j.[ShukkaSiziGyouNO]
		,j.[GyouHyouziJun]
		,21--After modification
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

--TableF
INSERT INTO [dbo].[D_ShukkaSiziShousaiHistory]
(	[HistoryGuid]
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
			@Unique_20,
			[ShukkaSiziNO]
			,[ShukkaSiziGyouNO]
			,[ShukkaSiziShousaiNO]
			,20 --Before correction
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
WHERE ShukkaSiziNO=@ShukkaSiziNO

INSERT INTO [dbo].[D_ShukkaSiziShousaiHistory]
(	[HistoryGuid]
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
	@Unique_21,
	[ShukkaSiziNO]
	,[ShukkaSiziGyouNO]
	,[ShukkaSiziShousaiNO]
	,21 --After modification
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
WHERE ShukkaSiziNO=@ShukkaSiziNO

--Konkai_Price--

--Table G--02
UPDATE  A
SET	ShukkaSiziZumiSuu= case when A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu>0 then  A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu
									when A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu<=0 then 0 end
	,UpdateOperator=@OperatorCD
	,UpdateDateTime=@currentDate
FROM D_JuchuuMeisai A
inner join #Temp_Details B
on A.JuchuuNO = LEFT((B.SKMSNO), CHARINDEX('-', (B.SKMSNO)) - 1) 
and A.JuchuuGyouNO=RIGHT(B.SKMSNO, LEN(B.SKMSNO) - CHARINDEX('-', B.SKMSNO))

--Table G --01
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
,UpdateOperator=@OperatorCD
,UpdateDateTime=@currentDate
FROM D_JuchuuMeisai A,#Temp_Details C
where A.JuchuuNO = LEFT((C.SKMSNO), CHARINDEX('-', (C.SKMSNO)) - 1) 

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

--UsedFLG 
update M_Staff 
set UsedFlg = 1 
where StaffCD = @StaffCD
and ChangeDate = (select ChangeDate from F_Staff(@ShippingDate) where StaffCD = @StaffCD)

--L_Log	
declare @OperateMode varchar(50)='修正'
exec dbo.L_Log_Insert @OperatorCD,@Program,@PC,@OperateMode,@ShukkaSiziNO


--TableX_12ShukkaSiziNO_Delete
EXEC [dbo].[D_Exclusive_Delete]
		12,
		@ShukkaSiziNO;

Drop Table #Temp_Header
Drop Table #Temp_Details

END
