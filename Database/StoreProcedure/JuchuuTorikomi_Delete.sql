BEGIN TRY 
 Drop Procedure dbo.[JuchuuTorikomi_Delete]
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
CREATE PROCEDURE [dbo].[JuchuuTorikomi_Delete]
@XML as xml,
@DenyouNO  as varchar(30),
@ProgramID as varchar(100),
@PC as varchar(30),
@OperatorCD as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE  @hQuantityAdjust AS INT 
			declare @currentDate as datetime = getdate()
			declare @Unique as uniqueidentifier = NewID()

			CREATE TABLE #Temp
							(  
							  TorikomiDenpyouNO varchar(12) COLLATE DATABASE_DEFAULT,
							  InsertDateTime datetime,
							  JuchuuNO varchar(12) COLLATE DATABASE_DEFAULT,
							  JuchuuDate date,
							  TokuisakiCD varchar(10) COLLATE DATABASE_DEFAULT,
							  TokuisakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
							  KouritenCD varchar(10)COLLATE DATABASE_DEFAULT,
							  KouritenRyakuName varchar(40) COLLATE DATABASE_DEFAULT
							)
							EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML

			INSERT INTO #Temp
             (
			   TorikomiDenpyouNO
			  ,InsertDateTime  
			  ,JuchuuNO
			  ,JuchuuDate          
			  ,TokuisakiCD
			  ,TokuisakiRyakuName
			  ,KouritenCD
			  ,KouritenRyakuName 
			  )

			  SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
				  TorikomiDenpyouNO varchar(12) 'TorikomiDenpyouNO',
				  InsertDateTime datetime 'InsertDateTime',
				  JuchuuNO varchar(12) 'JuchuuNO',
				  JuchuuDate date  'JuchuuDate',
				  TokuisakiCD varchar(10) 'TokuisakiCD',
				  TokuisakiRyakuName varchar(40) 'TokuisakiRyakuName',
				  KouritenCD varchar(10) 'KouritenCD',
				  KouritenRyakuName varchar(40) 'KouritenRyakuName'
				)
			EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

			--IF NOT EXISTS(select * FROM D_Juchuu  WHERE TorikomiDenpyouNO = @DenyouNO)
			--	BEGIN
			--	Drop table #Temp
			--	select '0' as Result
			--	END
			--ELSE
			   --BEGIN
			    declare @slip_NO as varchar(12) = (select JuchuuNO FROM #Temp where TorikomiDenpyouNO='@DenyouNO')
			    exec dbo.Fnc_Hikiate 1,@slip_NO,30,@OperatorCD
				
					--Delete D_HacchuuMeisai
				Delete A
				From D_HacchuuMeisai A
				Inner Join D_Juchuu B
				on A.JuchuuNO=B.JuchuuNO
				Where B.TorikomiDenpyouNO=@DenyouNO
				
				--Delete D_Hacchuu
				Delete A
				From D_Hacchuu A
				Inner Join D_Juchuu B
				On A.JuchuuNO=B.JuchuuNo
				Where B.TorikomiDenpyouNO=@DenyouNO

				--Insert Sheet C
				Insert Into D_HacchuuHistory
				
				Select 
				@Unique,
				DH.HacchuuNO,
				30,
				DH.StaffCD,
				DH.HacchuuDate,
				DH.KaikeiYYMM,
				DH.SiiresakiCD,
				DH.SiiresakiRyakuName,
				DH.SiharaisakiCD,
				DH.SiharaisakiRyakuName,
				DH.TuukaCD,
				DH.RateKBN,
				DH.SiireRate,
				DH.HacchuuDenpyouTekiyou,
				DH.DenpyouSiireHontaiKingaku*(-1),
				DH.DenpyouSiireHenpinHontaiKingaku*(-1),
				DH.DenpyouSiireNebikiHontaiKingaku*(-1),
				DH.DenpyouSiireShouhizeiGaku*(-1),
				DH.DenpyouSiireShouhizeiGakuTuujou*(-1),
				DH.DenpyouSiireShouhizeiGakuKeigen*(-1),
				DH.DenpyouJoudaiHontaiKingaku*(-1),
				DH.DenpyouJoudaiShouhizeiGaku*(-1),
				DH.DenpyouGaikaSiireHontaiKingaku*(-1),
				DH.DenpyouGaikaSiireHenpinHontaiKingaku*(-1),
				DH.DenpyouGaikaSiireNebikiHontaiKingaku*(-1),
				DH.DenpyouGaikaSiireShouhizeiGaku*(-1),
				DH.DenpyouGaikaJoudaiHontaiKingaku*(-1),
				DH.DenpyouGaikaJoudaiShouhizeiGaku*(-1),
				DH.SiharaiKBN,
				DH.SiharaiChouhaKBN,
				DH.SiharaiHouhouCD,
				DH.SiharaiYoteiDate,
				DH.HacchuushoTekiyou,
				DH.HacchuushoHuyouFLG,
				DH.HacchuushoHakkouFLG,
				DH.HacchuushoHakkouDatetime,
				DH.JuchuuNO,
				DH.ChakuniYoteiKanryouKBN,
				DH.ChakuniKanryouKBN,
				DH.SiireKanryouKBN,
				DH.TorikomiDenpyouNO,
				DH.SiiresakiName,
				DH.SiiresakiYuubinNO1,
				DH.SiiresakiYuubinNO2,
				DH.SiiresakiJuusho1,
				DH.SiiresakiJuusho2,
				DH.[SiiresakiTelNO1-1],
				DH.[SiiresakiTelNO1-2],
				DH.[SiiresakiTelNO1-3],
				DH.[SiiresakiTelNO2-1],
				DH.[SiiresakiTelNO2-2],
				DH.[SiiresakiTelNO2-3],
				DH.SiiresakiTantouBushoName,
				DH.SiiresakiTantoushaYakushoku,
				DH.SiiresakiTantoushaName,
				DH.SiharaisakiName,
				DH.SiharaisakiYuubinNO1,
				DH.SiharaisakiYuubinNO2,
				DH.SiharaisakiJuusho1,
				DH.SiharaisakiJuusho2,
				DH.[SiharaisakiTelNO1-1],
				DH.[SiharaisakiTelNO1-2],
				DH.[SiharaisakiTelNO1-3],
				DH.[SiharaisakiTelNO2-1],
				DH.[SiharaisakiTelNO2-2],
				DH.[SiharaisakiTelNO2-3],
				DH.SiharaisakiTantouBushoName,
				DH.SiharaisakiTantoushaYakushoku,
				DH.SiharaisakiTantoushaName,
				DH.InsertOperator,
				DH.InsertDateTime,
				DH.UpdateOperator,
				DH.UpdateDateTime,
				@OperatorCD,
				@currentDate
				from D_Hacchuu DH inner join #Temp TH on DH.JuchuuNO=TH.JuchuuNO

				----Insert Sheet D
				Insert into D_HacchuuMeisaiHistory
				
				Select 
				@Unique,
				DHM.HacchuuNO,
				DHM.HacchuuGyouNO,
				DHM.GyouHyouziJun,
				30,
				DHM.BrandCD,
				DHM.ShouhinCD,
				DHM.ShouhinName,
				--DHM.JANCD,
				DHM.ColorRyakuName,
				DHM.ColorNO,
				DHM.SizeNO,
				DHM.Kakeritu,
				DHM.HacchuuSuu*(-1),
				DHM.TaniCD,
				DHM.HacchuuTanka*(-1),
				DHM.HacchuuTankaShouhizei*(-1),
				DHM.HacchuuTankaShouhizeiTuujou*(-1),
				DHM.HacchuuTankaShouhizeiKeigen*(-1),
				DHM.HacchuuHontaiTanka*(-1),
				DHM.HacchuuKingaku*(-1),
				DHM.HacchuuHontaiKingaku*(-1),
				DHM.HacchuuShouhizeiGaku*(-1),
				DHM.HacchuuShouhizeiGakuTuujou*(-1),
				DHM.HacchuuShouhizeiGakuKeigen*(-1),
				DHM.HacchuuShouhizeiChouseiGaku*(-1),
				DHM.GaikaHacchuuTanka*(-1),
				DHM.GaikaHacchuuTankaShouhizei*(-1),
				DHM.GaikaHacchuuHontaiTanka*(-1),
				DHM.GaikaHacchuuKingaku*(-1),
				DHM.GaikaHacchuuHontaiKingaku*(-1),
				DHM.GaikaHacchuuShouhizeiGaku*(-1),
				DHM.GaikaHacchuuShouhizeiChouseiGaku*(-1),
				DHM.ShouhizeirituKBN,
				DHM.ShouhizeiNaigaiKBN,
				DHM.HacchuuMeisaiTekiyou,
				DHM.ChakuniYoteiDate,
				DHM.SoukoCD,
				DHM.ChakuniYoteiKanryouKBN,
				DHM.ChakuniKanryouKBN,
				DHM.SiireKanryouKBN,
				DHM.ChakuniYoteiZumiSuu,
				DHM.ChakuniZumiSuu,
				DHM.SiireZumiSuu,
				DHM.JuchuuNO,
				DHM.JuchuuGyouNO,
				DHM.TorikomiDenpyouNO,
				DHM.TorikomiDenpyouGyouNO,
				DHM.InsertOperator,
				DHM.InsertDateTime,
				DHM.UpdateOperator,
				DHM.UpdateDateTime,
				@OperatorCD,
				@currentDate
				From D_HacchuuMeisai DHM Inner Join  #Temp TH on DHM.JuchuuNO=TH.JuchuuNO

				--Delete D_JuchuuShousai
				Delete A
				from D_JuchuuShousai A
				Inner Join D_Juchuu B
				ON A.JuchuuNO=B.JuchuuNO
				Where B.TorikomiDenpyouNO=@DenyouNO
				
				--Delete D_JuchuuMeisai
				Delete A
				from D_JuchuuMeisai A
				Inner Join D_Juchuu B
				ON A.JuchuuNO=B.JuchuuNO
				Where B.TorikomiDenpyouNO=@DenyouNO
				
				--Delete D_Juchuu
				Delete A
				from D_Juchuu A
				Where A.TorikomiDenpyouNO=@DenyouNO
				
				Declare @OperateMode1 varchar(50)='Delete'
				   	   exec dbo.L_Log_Insert @OperatorCD,@ProgramID,@PC,@OperateMode1,@DenyouNO
				
				
				--Delete from D_Exclusive where DataKBN = 1 and Number = ( SELECT  JuchuuNO FROM #Temp)
				DELETE de FROM D_Exclusive de INNER JOIN #Temp t ON de.DataKBN = 1 AND de.Number = t.JuchuuNO

				Drop table #Temp
			 --   select 1 as Result
				--END
end
				
