 BEGIN TRY 
 Drop Procedure dbo.[Get_Tokuisaki_ExportData]
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
CREATE PROCEDURE [dbo].[Get_Tokuisaki_ExportData]
	-- Add the parameters for the stored procedure here
	@TokuisakiCD1				VARCHAR(10),
	@TokuisakiCD2				VARCHAR(10),
	@TokuisakiName				VARCHAR(80),
	@YuubinNO1					VARCHAR(3),
	@YuubinNO2					VARCHAR(4),
	@Juusho						VARCHAR(80),
	@Tel1						VARCHAR(5),
	@Tel2						VARCHAR(5),
	@Tel3						VARCHAR(5),
	@Remarks					VARCHAR(80),
	@InsertOperator				VARCHAR(10),
    @Program					VARCHAR(40),
	@PC							VARCHAR(100),
	@Output_Type				VARCHAR(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Mode VARCHAR(15), @KeyItem VARCHAR(100)
	SET @Mode = NULL
	SET @KeyItem = NULL
	
	DECLARE @currentDate AS DATETIME = GETDATE()

	EXEC dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

	IF @Output_Type = 0
	BEGIN
		SELECT mt.TokuisakiCD AS '得意先CD',
			mt.ChangeDate AS '改定日',
			mt.ShokutiFLG AS '諸口区分',
			CASE WHEN mt.ShokutiFLG = 0 THEN '通常' ELSE '諸口' END AS '諸口区分名',
			mt.TokuisakiName AS '得意先名',
			mt.TokuisakiRyakuName AS '略名',
			mt.KanaName AS 'カナ名',
			mt.KensakuHyouziJun AS '検索表示順',
			mt.SeikyuusakiCD AS '請求先CD',
			mt.AliasKBN AS '敬称',
			CASE WHEN mt.AliasKBN = 1 THEN '様' ELSE '御中' END '敬称名',
			mt.YuubinNO1 AS '郵便番号1',
			mt.YuubinNO2 AS '郵便番号2',
			mt.Juusho1 AS '住所1',
			mt.Juusho2 AS '住所2',
			mt.Tel11 AS '電話番号11',
			mt.Tel12 AS '電話番号12',
			mt.Tel13 AS '電話番号13',
			mt.Tel21 AS '電話番号21',
			mt.Tel22 AS '電話番号22',
			mt.Tel23 AS '電話番号23',
			mt.TantouBusho AS '担当部署',
			mt.TantouYakushoku AS '担当役職',
			mt.TantoushaName AS '担当者名',
			mt.MailAddress AS 'メールアドレス',
			mt.StaffCD AS '担当スタッフCD',
			ms.StaffName AS '担当スタッフ名',
			mt.TorihikiKaisiDate AS '取引開始日',
			mt.TorihikiShuuryouDate AS '取引終了日',
			mt.ShukkaSizishoHuyouKBN AS '出荷指示書不要区分',
			CASE WHEN mt.ShukkaSizishoHuyouKBN = 0 THEN '必要' ELSE '不要' END AS '出荷指示書不要区分名',
			mt.Remarks AS '備考',
			mt.InsertOperator AS '新規登録者',
			mt.InsertDateTime AS '新規登録日時',
			mt.UpdateOperator AS '変更登録者',
			mt.UpdateDateTime AS '変更登録日時'
		FROM F_Tokuisaki(GETDATE()) mt
		LEFT OUTER JOIN F_Staff(GETDATE()) ms ON ms.StaffCD = mt.StaffCD
		WHERE (@TokuisakiCD1 IS NULL OR (mt.TokuisakiCD >= @TokuisakiCD1))
		AND (@TokuisakiCD2 IS NULL OR (mt.TokuisakiCD <= @TokuisakiCD2))
		AND (@TokuisakiName IS NULL OR ((mt.TokuisakiRyakuName LIKE '%' + @TokuisakiName + '%') OR (mt.TokuisakiName LIKE '%' + @TokuisakiName + '%')))
		AND (@YuubinNO1 IS NULL OR (mt.YuubinNO1 = @YuubinNO1))
		AND (@YuubinNO2 IS NULL OR (mt.YuubinNO2 = @YuubinNO2))
		AND (@Juusho IS NULL OR ((mt.Juusho1 LIKE '%' + @Juusho + '%') OR (mt.Juusho2 LIKE '%' + @Juusho + '%')))
		AND ((@Tel1 IS NULL AND @Tel2 IS NULL AND @Tel3 IS NULL) OR (mt.Tel11 = @Tel1 AND mt.Tel12 = @Tel2 AND mt.Tel13 = @Tel3) OR (mt.Tel21 = @Tel1 AND mt.Tel22 = @Tel2 AND mt.Tel23 = @Tel3))
		AND (@Remarks IS NULL OR (mt.Remarks LIKE '%' + @Remarks + '%'))
		ORDER BY mt.TokuisakiCD ASC, mt.ChangeDate ASC
	END

	ELSE
	BEGIN
		SELECT mt.TokuisakiCD AS '得意先CD',
			mt.ChangeDate AS '改定日',
			mt.ShokutiFLG AS '諸口区分',
			CASE WHEN mt.ShokutiFLG = 0 THEN '通常' ELSE '諸口' END AS '諸口区分名',
			mt.TokuisakiName AS '得意先名',
			mt.TokuisakiRyakuName AS '略名',
			mt.KanaName AS 'カナ名',
			mt.KensakuHyouziJun AS '検索表示順',
			mt.SeikyuusakiCD AS '請求先CD',
			mt.AliasKBN AS '敬称',
			CASE WHEN mt.AliasKBN = 1 THEN '様' ELSE '御中' END '敬称名',
			mt.YuubinNO1 AS '郵便番号1',
			mt.YuubinNO2 AS '郵便番号2',
			mt.Juusho1 AS '住所1',
			mt.Juusho2 AS '住所2',
			mt.Tel11 AS '電話番号11',
			mt.Tel12 AS '電話番号12',
			mt.Tel13 AS '電話番号13',
			mt.Tel21 AS '電話番号21',
			mt.Tel22 AS '電話番号22',
			mt.Tel23 AS '電話番号23',
			mt.TantouBusho AS '担当部署',
			mt.TantouYakushoku AS '担当役職',
			mt.TantoushaName AS '担当者名',
			mt.MailAddress AS 'メールアドレス',
			mt.StaffCD AS '担当スタッフCD',
			ms.StaffName AS '担当スタッフ名',
			mt.TorihikiKaisiDate AS '取引開始日',
			mt.TorihikiShuuryouDate AS '取引終了日',
			mt.ShukkaSizishoHuyouKBN AS '出荷指示書不要区分',
			CASE WHEN mt.ShukkaSizishoHuyouKBN = 0 THEN '必要' ELSE '不要' END AS '出荷指示書不要区分名',
			mt.Remarks AS '備考',
			mt.InsertOperator AS '新規登録者',
			mt.InsertDateTime AS '新規登録日時',
			mt.UpdateOperator AS '変更登録者',
			mt.UpdateDateTime AS '変更登録日時'
		FROM M_Tokuisaki mt
		LEFT OUTER JOIN F_Staff(GETDATE()) ms ON ms.StaffCD = mt.StaffCD
		WHERE (@TokuisakiCD1 IS NULL OR (mt.TokuisakiCD >= @TokuisakiCD1))
		AND (@TokuisakiCD2 IS NULL OR (mt.TokuisakiCD <= @TokuisakiCD2))
		AND (@TokuisakiName IS NULL OR ((mt.TokuisakiRyakuName LIKE '%' + @TokuisakiName + '%') OR (mt.TokuisakiName LIKE '%' + @TokuisakiName + '%')))
		AND (@YuubinNO1 IS NULL OR (mt.YuubinNO1 = @YuubinNO1))
		AND (@YuubinNO2 IS NULL OR (mt.YuubinNO2 = @YuubinNO2))
		AND (@Juusho IS NULL OR ((mt.Juusho1 LIKE '%' + @Juusho + '%') OR (mt.Juusho2 LIKE '%' + @Juusho + '%')))
		AND ((@Tel1 IS NULL AND @Tel2 IS NULL AND @Tel3 IS NULL) OR (mt.Tel11 = @Tel1 AND mt.Tel12 = @Tel2 AND mt.Tel13 = @Tel3) OR (mt.Tel21 = @Tel1 AND mt.Tel22 = @Tel2 AND mt.Tel23 = @Tel3))
		AND (@Remarks IS NULL OR (mt.Remarks LIKE '%' + @Remarks + '%'))
		ORDER BY mt.TokuisakiCD ASC, mt.ChangeDate ASC
	END
END

