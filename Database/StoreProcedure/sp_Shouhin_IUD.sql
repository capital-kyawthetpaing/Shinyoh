 BEGIN TRY 
 Drop Procedure dbo.[sp_Shouhin_IUD]
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
CREATE PROCEDURE [dbo].[sp_Shouhin_IUD]
	-- Add the parameters for the stored procedure here
	@ShouhinCD					VARCHAR(50),
	@ChangeDate					VARCHAR(10),
	@ShokutiFLG					INT,
	@HinbanCD					VARCHAR(20),
	@ShouhinName				VARCHAR(100),
	@ShouhinRyakuName			VARCHAR(80),
	@KanaName					VARCHAR(80),
	@KensakuHyouziJun			INT,
	@JANCD						VARCHAR(13),
	@YearTerm					VARCHAR(6),
	@SeasonSS					VARCHAR(6),
	@SeasonFW					VARCHAR(6),
	@TaniCD						VARCHAR(2),
	@BrandCD					VARCHAR(10),
	@ColorNO					VARCHAR(13),
	@SizeNO						VARCHAR(13),
	@JoudaiTanka				VARCHAR(20),
	@GedaiTanka					VARCHAR(20),
	@HyoujunGenkaTanka			VARCHAR(20),
	@ZeirituKBN					INT,
	@ZaikoHyoukaKBN				INT,
	@ZaikoKanriKBN				INT,
	@MainSiiresakiCD			VARCHAR(10),
	@ToriatukaiShuuryouDate		VARCHAR(10),
	@HanbaiTeisiDate			VARCHAR(10),
	@Model_No					VARCHAR(16),
	@Model_Name					VARCHAR(40),
	@FOB						VARCHAR(20),
	@Shipping_Place				VARCHAR(20),
	@HacchuuLot					DECIMAL(21,6),
	@ShouhinImageFilePathName	VARCHAR(100),
	@ShouhinImage				VARBINARY(MAX),
	@Remarks					VARCHAR(80),
	@InsertOperator				VARCHAR(10),
	@UpdateOperator			    VARCHAR(10),
    @Mode					    VARCHAR(15),
    @Program					VARCHAR(40),
	@PC							VARCHAR(100),
	@KeyItem					VARCHAR(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		
			
	begin try
		begin tran

			EXEC dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

			IF @Mode = 'New'
			BEGIN
				INSERT INTO M_Shouhin (ShouhinCD, ChangeDate, ShokutiFLG, HinbanCD, ShouhinName, ShouhinRyakuName, KanaName, KensakuHyouziJun, JANCD, YearTerm, SeasonSS, SeasonFW, TaniCD, BrandCD,
					ColorNO, SizeNO, JoudaiTanka, GedaiTanka, HyoujunGenkaTanka, ZeirituKBN, ZaikoHyoukaKBN, ZaikoKanriKBN, MainSiiresakiCD, ToriatukaiShuuryouDate, HanbaiTeisiDate,
					Model_No, Model_Name, FOB, Shipping_Place, HacchuuLot, ShouhinImageFilePathName, ShouhinImage, Remarks, UsedFlg, InsertOperator, InsertDateTime, UpdateOperator, UpdateDateTime)
				VALUES (@ShouhinCD, @ChangeDate, @ShokutiFLG, @HinbanCD, @ShouhinName, @ShouhinRyakuName, @KanaName, @KensakuHyouziJun, @JANCD, @YearTerm, @SeasonSS, @SeasonFW, @TaniCD, @BrandCD,
					@ColorNO, @SizeNO, @JoudaiTanka, @GedaiTanka, @HyoujunGenkaTanka, @ZeirituKBN, @ZaikoHyoukaKBN, @ZaikoKanriKBN, @MainSiiresakiCD, @ToriatukaiShuuryouDate, @HanbaiTeisiDate,
					@Model_No, @Model_Name, @FOB, @Shipping_Place, @HacchuuLot, @ShouhinImageFilePathName, @ShouhinImage, @Remarks, 0, @InsertOperator, GETDATE(), @UpdateOperator, GETDATE())
			END

			ELSE IF @Mode = 'Update'
			BEGIN
				UPDATE M_Shouhin
				SET ShokutiFLG = @ShokutiFLG,
					HinbanCD = @HinbanCD,
					ShouhinName = @ShouhinName,
					ShouhinRyakuName = @ShouhinRyakuName,
					KanaName = @KanaName,
					KensakuHyouziJun = @KensakuHyouziJun,
					JANCD = @JANCD,
					YearTerm = @YearTerm,
					SeasonSS = @SeasonSS,
					SeasonFW = @SeasonFW,
					TaniCD = @TaniCD,
					BrandCD = @BrandCD,
					ColorNO = @ColorNO,
					SizeNO = @SizeNO,
					JoudaiTanka = @JoudaiTanka,
					GedaiTanka = @GedaiTanka,
					HyoujunGenkaTanka = @HyoujunGenkaTanka,
					ZeirituKBN = @ZeirituKBN,
					ZaikoHyoukaKBN = @ZaikoHyoukaKBN,
					ZaikoKanriKBN = @ZaikoKanriKBN,
					MainSiiresakiCD = @MainSiiresakiCD,
					ToriatukaiShuuryouDate = @ToriatukaiShuuryouDate,
					HanbaiTeisiDate = @HanbaiTeisiDate,
					Model_No = @Model_No,
					Model_Name = @Model_Name,
					FOB = @FOB,
					Shipping_Place = @Shipping_Place,
					HacchuuLot = @HacchuuLot,
					ShouhinImageFilePathName = @ShouhinImageFilePathName,
					ShouhinImage = @ShouhinImage,
					Remarks = @Remarks,
					UpdateOperator = @UpdateOperator,
					UpdateDateTime = GETDATE()
				WHERE ShouhinCD = @ShouhinCD AND ChangeDate = @ChangeDate
			END

			ELSE IF @Mode = 'Delete'
			BEGIN
				DELETE FROM M_Shouhin WHERE ShouhinCD = @ShouhinCD AND ChangeDate = @ChangeDate
			END

		commit tran
	end try
	begin catch
		rollback tran
		throw
	end catch

	
END

