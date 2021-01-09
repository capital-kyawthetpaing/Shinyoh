 BEGIN TRY 
 Drop Procedure dbo.[Get_Siiresaki_ExportData]
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
CREATE PROCEDURE [dbo].[Get_Siiresaki_ExportData]
	-- Add the parameters for the stored procedure here
	@SiiresakiCD1				VARCHAR(10),
	@SiiresakiCD2				VARCHAR(10),
	@SiiresakiName				VARCHAR(80),
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

    -- Insert statements for procedure here

	DECLARE @Mode VARCHAR(15), @KeyItem VARCHAR(100)
	SET @Mode = NULL
	SET @KeyItem = NULL
	
	DECLARE @currentDate AS DATETIME = GETDATE()

	IF @Output_Type = 0
	BEGIN
		SELECT fs.SiharaisakiCD AS '仕入先CD',
			CONVERT(varchar(10),fs.ChangeDate,111)  AS '改定日',
			fs.ShokutiFLG AS '諸口区分',
			CASE WHEN fs.ShokutiFLG = 0 THEN '通常' ELSE '諸口' END AS '諸口区分名',
			fs.SiiresakiName AS '仕入先名',
			fs.SiiresakiRyakuName AS '略名',
			fs.KanaName AS 'カナ名',
			fs.KensakuHyouziJun AS '検索表示順',
			fs.SiharaisakiCD AS '支払先CD',
			fs.YuubinNO1 AS '郵便番号1',
			fs.YuubinNO2 AS '郵便番号2',
			fs.Juusho1 AS '住所1',
			fs.Juusho2 AS '住所2',
			fs.Tel11 AS '電話番号11',
			fs.Tel12 AS '電話番号12',
			fs.Tel13 AS '電話番号13',
			fs.Tel21 AS '電話番号21',
			fs.Tel22 AS '電話番号22',
			fs.Tel23 AS '電話番号23',
			fs.TantouBusho AS '担当部署',
			fs.TantouYakushoku AS '担当役職',
			fs.TantoushaName AS '担当者名',
			fs.MailAddress AS 'メールアドレス',
			fs.TuukaCD as'通貨CD',
			mp.Char1 as '通貨名',
			fs.StaffCD AS '担当スタッフCD',
			fstaff.StaffName AS '担当スタッフ名',
			fs.TorihikiKaisiDate AS '取引開始日',
			fs.TorihikiShuuryouDate AS '取引終了日',
			fs.Remarks AS '備考',
			fs.InsertOperator AS '新規登録者',
			fs.InsertDateTime AS '新規登録日時',
			fs.UpdateOperator AS '変更登録者',
			fs.UpdateDateTime AS '変更登録日時'
		FROM F_Siiresaki(GETDATE()) fs
		LEFT OUTER JOIN F_Staff(GETDATE()) fstaff ON fstaff.StaffCD = fs.StaffCD
		LEFT OUTER JOIN M_MultiPorpose mp ON mp.ID=108 and mp.[Key]=fs.TuukaCD

		WHERE (@SiiresakiCD1 IS NULL OR (fs.SiiresakiCD>= @SiiresakiCD1))
		AND (@SiiresakiCD2 IS NULL OR (fs.SiharaisakiCD <= @SiiresakiCD2))
		AND (@SiiresakiName IS NULL OR ((fs.SiiresakiRyakuName LIKE '%' + @SiiresakiName + '%') OR (fs.SiiresakiName LIKE '%' + @SiiresakiName + '%')))
		AND (@YuubinNO1 IS NULL OR (fs.YuubinNO1 = @YuubinNO1))
		AND (@YuubinNO2 IS NULL OR (fs.YuubinNO2 = @YuubinNO2))
		AND (@Juusho IS NULL OR ((fs.Juusho1 LIKE '%' + @Juusho + '%') OR (fs.Juusho2 LIKE '%' + @Juusho + '%')))
		AND ((@Tel1 IS NULL AND @Tel2 IS NULL AND @Tel3 IS NULL) OR (fs.Tel11 = @Tel1 AND fs.Tel12 = @Tel2 AND fs.Tel13 = @Tel3) OR (fs.Tel21 = @Tel1 AND fs.Tel22 = @Tel2 AND fs.Tel23 = @Tel3))
		AND (@Remarks IS NULL OR (fs.Remarks LIKE '%' + @Remarks + '%'))
		ORDER BY fs.SiiresakiCD ASC, fs.ChangeDate ASC
	END

	ELSE
	BEGIN
		SELECT fs.SiharaisakiCD AS '仕入先CD',
			CONVERT(varchar(10),fs.ChangeDate,111)  AS '改定日',
			fs.ShokutiFLG AS '諸口区分',
			CASE WHEN fs.ShokutiFLG = 0 THEN '通常' ELSE '諸口' END AS '諸口区分名',
			fs.SiiresakiName AS '仕入先名',
			fs.SiiresakiRyakuName AS '略名',
			fs.KanaName AS 'カナ名',
			fs.KensakuHyouziJun AS '検索表示順',
			fs.SiharaisakiCD AS '支払先CD',
			fs.YuubinNO1 AS '郵便番号1',
			fs.YuubinNO2 AS '郵便番号2',
			fs.Juusho1 AS '住所1',
			fs.Juusho2 AS '住所2',
			fs.Tel11 AS '電話番号11',
			fs.Tel12 AS '電話番号12',
			fs.Tel13 AS '電話番号13',
			fs.Tel21 AS '電話番号21',
			fs.Tel22 AS '電話番号22',
			fs.Tel23 AS '電話番号23',
			fs.TantouBusho AS '担当部署',
			fs.TantouYakushoku AS '担当役職',
			fs.TantoushaName AS '担当者名',
			fs.MailAddress AS 'メールアドレス',
			fs.TuukaCD as'通貨CD',
			mp.Char1 as '通貨名',
			fs.StaffCD AS '担当スタッフCD',
			fstaff.StaffName AS '担当スタッフ名',
			fs.TorihikiKaisiDate AS '取引開始日',
			fs.TorihikiShuuryouDate AS '取引終了日',
			fs.Remarks AS '備考',
			fs.InsertOperator AS '新規登録者',
			fs.InsertDateTime AS '新規登録日時',
			fs.UpdateOperator AS '変更登録者',
			fs.UpdateDateTime AS '変更登録日時'
		FROM M_Siiresaki fs
		LEFT OUTER JOIN F_Staff(GETDATE()) fstaff ON fstaff.StaffCD = fs.StaffCD
		LEFT OUTER JOIN M_MultiPorpose mp ON mp.ID=108 and mp.[Key]=fs.TuukaCD

		WHERE (@SiiresakiCD1 IS NULL OR (fs.SiiresakiCD>= @SiiresakiCD1))
		AND (@SiiresakiCD2 IS NULL OR (fs.SiharaisakiCD <= @SiiresakiCD2))
		AND (@SiiresakiName IS NULL OR ((fs.SiiresakiRyakuName LIKE '%' + @SiiresakiName + '%') OR (fs.SiiresakiName LIKE '%' + @SiiresakiName + '%')))
		AND (@YuubinNO1 IS NULL OR (fs.YuubinNO1 = @YuubinNO1))
		AND (@YuubinNO2 IS NULL OR (fs.YuubinNO2 = @YuubinNO2))
		AND (@Juusho IS NULL OR ((fs.Juusho1 LIKE '%' + @Juusho + '%') OR (fs.Juusho2 LIKE '%' + @Juusho + '%')))
		AND ((@Tel1 IS NULL AND @Tel2 IS NULL AND @Tel3 IS NULL) OR (fs.Tel11 = @Tel1 AND fs.Tel12 = @Tel2 AND fs.Tel13 = @Tel3) OR (fs.Tel21 = @Tel1 AND fs.Tel22 = @Tel2 AND fs.Tel23 = @Tel3))
		AND (@Remarks IS NULL OR (fs.Remarks LIKE '%' + @Remarks + '%'))
		ORDER BY fs.SiiresakiCD ASC, fs.ChangeDate ASC
	END

	EXEC dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem
END
GO
