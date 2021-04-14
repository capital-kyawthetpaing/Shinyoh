/****** Object:  StoredProcedure [dbo].[ShukkasiziNyuuryoku_Delete]    Script Date: 2021/04/13 18:08:39 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ShukkasiziNyuuryoku_Delete%' and type like '%P%')
DROP PROCEDURE [dbo].[ShukkasiziNyuuryoku_Delete]
GO

/****** Object:  StoredProcedure [dbo].[ShukkasiziNyuuryoku_Delete]    Script Date: 2021/04/13 18:08:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<swe>
-- Create date: <03-06-2021>
-- Description:	<Description,,>
-- History    : 2021/04/13 Y.Nishikawa DEL 引当更新は引当ファンクションで処理しているため、二重計上
--                         Y.Nishikawa DEL すぐ上で同じ処理してる
--              2021/04/14 Y.Nishikawa CHG この時点では受注明細の出荷指示済数に今回出荷指示数を更新していないので、分納時は完了区分が完了にならない(削除なので、必ず完了区分は未完)
-- =============================================
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_Delete]
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
, @OperatorCD as varchar(10) =(select OperatorCD from #Temp_Header)
, @Program varchar(100) = (select ProgramID from #Temp_Header)
,@PC    varchar(30) = (select PC from #Temp_Header)
,@KeyItem  varchar(100)= (select ShukkaSiziNO from #Temp_Header)
, @currentDate as datetime = getdate()
, @Unique as uniqueidentifier = NewID()



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
	@Unique
	,i.ShukkaSiziNO
	,30--陷台ｼ∝求
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
		,30
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
where j.ShukkaSiziNO=@ShukkaSiziNO

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
			,30
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
where ShukkaSiziNO=@ShukkaSiziNO

-- KTP Add start
--call fncHikiate
exec dbo.Fnc_Hikiate 12,@ShukkaSiziNO,30,@OperatorCD

--Reverse/Cancel Old Data KTP Change

declare @tmpsss as decimal(21,6)
select @tmpsss = sum(ShukkaSiziSuu) from D_ShukkaSiziShousai where ShukkaSiziNO = @ShukkaSiziNO group by ShukkaSiziNO

--2021/04/13 Y.Nishikawa DEL 引当更新は引当ファンクションで処理しているため、二重計上↓↓
--UPDATE  A
--SET	
--	HikiateZumiSuu = A.HikiateZumiSuu + @tmpsss -- KTP Add
--	,ShukkaSiziZumiSuu=A.ShukkaSiziZumiSuu - @tmpsss
--	,UpdateOperator=@OperatorCD
--	,UpdateDateTime=@currentDate
--FROM D_JuchuuMeisai A

--update D_JuchuuShousai
--set HikiateZumiSuu = js.HikiateZumiSuu + sss.ShukkaSiziSuu,
--	ShukkaSiziZumiSuu = js.ShukkaSiziZumiSuu - sss.ShukkaSiziSuu
--from D_JuchuuShousai js
--inner join D_ShukkaSiziShousai sss on js.KanriNO = sss.KanriNO and js.NyuukoDate = sss.NyuukoDate and js.SoukoCD = sss.SoukoCD
--and js.ShouhinCD = sss.ShouhinCD
--where sss.ShukkaSiziNO = @ShukkaSiziNO
--2021/04/13 Y.Nishikawa DEL 引当更新は引当ファンクションで処理しているため、二重計上↑↑

delete D_ShukkaSiziShousai
where ShukkaSiziNO = @ShukkaSiziNO
-- KTP Add end

--TableA
DELETE A
FROM D_ShukkaSizi A
WHERE A.ShukkaSiziNO=@ShukkaSiziNO

--TableB
DELETE A
FROM D_ShukkaSiziMeisai A
WHERE A.ShukkaSiziNO=@ShukkaSiziNO

--2021/04/13 Y.Nishikawa DEL すぐ上で同じ処理してる↓↓
----TableC
--DELETE A
--FROM D_ShukkaSiziShousai A
--WHERE A.ShukkaSiziNO=@ShukkaSiziNO
--2021/04/13 Y.Nishikawa DEL すぐ上で同じ処理してる↑↑

--Konkai_price

--Table G --02
--UPDATE  A
--SET	ShukkaSiziZumiSuu= case when A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu>0 then  A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu
--									when A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu<=0 then 0 end
--	,UpdateOperator=@OperatorCD
--	,UpdateDateTime=@currentDate
--FROM D_JuchuuMeisai A
--inner join #Temp_Details B
--on A.JuchuuNO = LEFT((B.SKMSNO), CHARINDEX('-', (B.SKMSNO)) - 1) 
--and A.JuchuuGyouNO=RIGHT(B.SKMSNO, LEN(B.SKMSNO) - CHARINDEX('-', B.SKMSNO))

--D_JuchuuMeisai
UPDATE  A 
--2021/04/14 Y.Nishikawa CHG この時点では受注明細の出荷指示済数に今回出荷指示数を更新していないので、分納時は完了区分が完了にならない(削除なので、必ず完了区分は未完)↓↓
----SET	[ShukkaSiziKanryouKBN]= case when A.JuchuuSuu<=A.ShukkaSiziZumiSuu then 1 
--when C.Kanryo=1 then 1 else 0 end
SET	[ShukkaSiziKanryouKBN]= 0
--2021/04/14 Y.Nishikawa CHG この時点では受注明細の出荷指示済数に今回出荷指示数を更新していないので、分納時は完了区分が完了にならない(削除なので、必ず完了区分は未完)↑↑
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

--L_Log	
declare @OperateMode varchar(50)='蜑企勁'
exec dbo.L_Log_Insert @OperatorCD,@Program,@PC,@OperateMode,@KeyItem

--TableX_12ShukkaSiziNO_Delete
EXEC [dbo].[D_Exclusive_Delete]
		12,
		@ShukkaSiziNO;

Drop Table #Temp_Header
Drop Table #Temp_Details

END

GO


