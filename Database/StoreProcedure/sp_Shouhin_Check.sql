BEGIN TRY 
 Drop Procedure dbo.[sp_Shouhin_Check]
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
CREATE PROCEDURE [dbo].[sp_Shouhin_Check]
	-- Add the parameters for the stored procedure here
	@shouhinCD	varchar(50),
	@changeDate	varchar(15),
	@error_type varchar(10),
	@colorNO    varchar(13),
	@sizeNO   varchar(13)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @error_type = 'E270'
	BEGIN
		IF EXISTS (SELECT 1 FROM M_Shouhin WHERE ShouhinCD = @shouhinCD + @colorNO + @sizeNO AND ChangeDate = @changeDate AND UsedFlg = 1)
		
		BEGIN
			SELECT * FROM M_Message WHERE MessageID = @error_type
		END
		ELSE
		BEGIN
			SELECT mm.*, ms.* FROM
			(SELECT fs.ShouhinCD, fs.ChangeDate, fs.ShokutiFLG, fs.HinbanCD, fs.ShouhinName, fs.ShouhinRyakuName, fs.KanaName, fs.KensakuHyouziJun, fs.JANCD, fs.YearTerm, fs.SeasonSS, fs.SeasonFW, fs.TaniCD, M_MultiPorpose_Tani.Char1 AS TaniName,
			fs.BrandCD, M_MultiPorpose_Brand.Char1 AS BrandName, fs.ColorNO, M_MultiPorpose_Color.Char1 AS ColorName, fs.SizeNO, M_MultiPorpose_Size.Char1 AS SizeName,  FORMAT(CONVERT(DECIMAL(24,0), fs.JoudaiTanka), '#,0') AS 'JoudaiTanka', FORMAT(CONVERT(DECIMAL(24,0), fs.GedaiTanka), '#,0') AS 'GedaiTanka', FORMAT(CONVERT(DECIMAL(24,0), fs.HyoujunGenkaTanka), '#,0') AS 'HyoujunGenkaTanka',
			fs.ZeirituKBN, M_MultiPorpose_Shouhizeiritu.Char1 AS ZeirituKBN_Name, fs.ZaikoHyoukaKBN, M_MultiPorpose_ZaikoHyouka.Char1 AS ZaikoHyoukaKBN_Name, fs.ZaikoKanriKBN, M_MultiPorpose_ZaikoKanri.Char1 AS ZaikoKanriKBN_Name, 
			fs.MainSiiresakiCD, ms.SiiresakiRyakuName, fs.ToriatukaiShuuryouDate, fs.HanbaiTeisiDate, fs.Model_No, fs.Model_Name, FORMAT(fs.FOB, '#,0.#0') AS FOB, fs.Shipping_Place, FORMAT(CONVERT(DECIMAL(21,0), fs.HacchuuLot), '#,0') AS 'HacchuuLot', fs.ShouhinImageFilePathName, fs.ShouhinImage, fs.Remarks
			FROM F_Shouhin(@changeDate) fs
			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 102) M_MultiPorpose_Tani ON M_MultiPorpose_Tani.[Key] = fs.TaniCD
			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 103) M_MultiPorpose_Brand ON M_MultiPorpose_Brand.[Key] = fs.BrandCD
			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = fs.ColorNO
			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 105) M_MultiPorpose_Size ON M_MultiPorpose_Size.[Key] = fs.SizeNO
			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 221) M_MultiPorpose_Shouhizeiritu ON M_MultiPorpose_Shouhizeiritu.[Key] = fs.ZeirituKBN
			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 106) M_MultiPorpose_ZaikoHyouka ON M_MultiPorpose_ZaikoHyouka.[Key] = fs.ZaikoHyoukaKBN
			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 107) M_MultiPorpose_ZaikoKanri ON M_MultiPorpose_ZaikoKanri.[Key] = fs.ZaikoKanriKBN
			LEFT OUTER JOIN F_Siiresaki(@changeDate) ms ON ms.SiiresakiCD = fs.MainSiiresakiCD) ms, M_Message mm
			WHERE mm.MessageID='E132' AND ms.ShouhinCD=@shouhinCD+@colorNO+@sizeNO 
		END
	END

	ELSE IF @error_type = 'E101'
	BEGIN
		IF EXISTS (SELECT 1 FROM M_MultiPorpose WHERE ID = @shouhinCD AND [Key] = @colorNO)
		BEGIN
			SELECT CASE WHEN @shouhinCD = '102' OR @shouhinCD = '106' OR @shouhinCD = '107' THEN SUBSTRING(char1, 1, 20)
						ELSE SUBSTRING(char1, 1, 40) END AS char1, M_Message.*
			FROM M_MultiPorpose, M_Message
			WHERE ID = @shouhinCD AND [Key] = @ColorNO
		END
		ELSE
		BEGIN
			SELECT * FROM M_Message WHERE MessageID = @error_type
		END
	END

    ELSE IF EXISTS (SELECT * FROM M_Shouhin WHERE ShouhinCD=@shouhinCD + @colorNO + @sizeNO AND ChangeDate=@changeDate)
	
	BEGIN
		--exists
		SELECT mm.*, ms.* FROM
		(SELECT fs.ShouhinCD, fs.ChangeDate, fs.ShokutiFLG, fs.HinbanCD, fs.ShouhinName, fs.ShouhinRyakuName, fs.KanaName, fs.KensakuHyouziJun, fs.JANCD, fs.YearTerm, fs.SeasonSS, fs.SeasonFW, fs.TaniCD, M_MultiPorpose_Tani.Char1 AS TaniName,
		fs.BrandCD, M_MultiPorpose_Brand.Char1 AS BrandName, fs.ColorNO, M_MultiPorpose_Color.Char1 AS ColorName, fs.SizeNO, M_MultiPorpose_Size.Char1 AS SizeName,  FORMAT(CONVERT(DECIMAL(24,0), fs.JoudaiTanka), '#,0') AS 'JoudaiTanka', FORMAT(CONVERT(DECIMAL(24,0), fs.GedaiTanka), '#,0') AS 'GedaiTanka', FORMAT(CONVERT(DECIMAL(24,0), fs.HyoujunGenkaTanka), '#,0') AS 'HyoujunGenkaTanka',
		fs.ZeirituKBN, M_MultiPorpose_Shouhizeiritu.Char1 AS ZeirituKBN_Name, fs.ZaikoHyoukaKBN, M_MultiPorpose_ZaikoHyouka.Char1 AS ZaikoHyoukaKBN_Name, fs.ZaikoKanriKBN, M_MultiPorpose_ZaikoKanri.Char1 AS ZaikoKanriKBN_Name, 
		fs.MainSiiresakiCD, ms.SiiresakiRyakuName, fs.ToriatukaiShuuryouDate, fs.HanbaiTeisiDate, fs.Model_No, fs.Model_Name, FORMAT(fs.FOB, '#,0.#0') AS FOB, fs.Shipping_Place, FORMAT(CONVERT(DECIMAL(21,0), fs.HacchuuLot), '#,0') AS 'HacchuuLot', fs.ShouhinImageFilePathName, fs.ShouhinImage, fs.Remarks
		FROM F_Shouhin(@changeDate) fs
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 102) M_MultiPorpose_Tani ON M_MultiPorpose_Tani.[Key] = fs.TaniCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 103) M_MultiPorpose_Brand ON M_MultiPorpose_Brand.[Key] = fs.BrandCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = fs.ColorNO
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 105) M_MultiPorpose_Size ON M_MultiPorpose_Size.[Key] = fs.SizeNO
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 221) M_MultiPorpose_Shouhizeiritu ON M_MultiPorpose_Shouhizeiritu.[Key] = fs.ZeirituKBN
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 106) M_MultiPorpose_ZaikoHyouka ON M_MultiPorpose_ZaikoHyouka.[Key] = fs.ZaikoHyoukaKBN
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 107) M_MultiPorpose_ZaikoKanri ON M_MultiPorpose_ZaikoKanri.[Key] = fs.ZaikoKanriKBN
		LEFT OUTER JOIN F_Siiresaki(@changeDate) ms ON ms.SiiresakiCD = fs.MainSiiresakiCD) ms, M_Message mm
		WHERE mm.MessageID='E132' AND ms.ShouhinCD=@shouhinCD+@colorNO+@sizeNO 

		--SELECT m.*,s.* FROM M_Message m,M_Shouhin s
		--WHERE  m.MessageID='E132' AND s.ShouhinCD=@shouhinCD AND s.ChangeDate=@ChangeDate
	END
	ELSE
	BEGIN
		--not exists
		SELECT * FROM M_Message WHERE MessageID = 'E133'
	END

END

