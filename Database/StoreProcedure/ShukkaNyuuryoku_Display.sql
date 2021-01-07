 BEGIN TRY 
 Drop Procedure dbo.[ShukkaNyuuryoku_Display]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 12/15/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaNyuuryoku_Display]
	@TokuisakiCD		AS varchar(10),
	@ShukkaSiziNO		AS varchar(12),
	@ShukkaYoteiDate1	AS varchar(10),
	@ShukkaYoteiDate2	AS varchar(10),
	@DenpyouDate1		AS varchar(10),
	@DenpyouDate2		AS varchar(10),
	@ChangeDate			AS varchar(10),
	@YuubinNO1			AS varchar(3),
	@YuubinNO2			AS varchar(4),
	@TelNO1				AS varchar(5),
	@TelNO2				AS varchar(6),
	@TelNO3				AS varchar(6),
	@Name				AS varchar(120),
	@Juusho				AS varchar(50),
	@Condition			AS int,
	@Operator			varchar(10),
    @Program			varchar(100),
    @PC					varchar(30)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	CREATE TABLE  #WK_MiNyuukaSuu2					
		(
			[ShukkaSiziNO] Varchar(12), 
			[ShukkaSiziGyouNO] smallint,
			[MiNyuukaSuu]	decimal(21,6)
		)
		Insert Into #WK_MiNyuukaSuu2
		SELECT DSS.ShukkaSiziNO,DSS.ShukkaSiziGyouNO,SUM(DSS.ShukkaSiziSuu)
		FROM D_ShukkaSizi DS
		inner join D_ShukkaSiziMeisai DSM on DSM.ShukkaSiziNO=DS.ShukkaSiziNO
		inner join D_ShukkaSiziShousai DSS on DSS.ShukkaSiziNO=DSM.ShukkaSiziNO and DSS.ShukkaSiziGyouNO=DSM.ShukkaSiziGyouNO
		left outer join F_Tokuisaki(@ChangeDate) FT on FT.TokuisakiCD = DS.TokuisakiCD
		left outer join F_Kouriten(@ChangeDate) FK on FK.KouritenCD = DSM.KouritenCD
		where DSS.NyuukoDate = ''
		GROUP BY DSS.ShukkaSiziNO,DSS.ShukkaSiziGyouNO

		Set @Condition = (select Top(1) ShokutiFLG from M_Tokuisaki  where ShokutiFLG=1)
	  

	if (@Condition = 1)
	begin
		select DSM.JANCD,DSM.ShouhinCD,DSM.ShouhinName,DSM.ColorRyakuName,DSM.ColorNO,DSM.SizeNO,(DSM.ShukkaSiziSuu-DSM.ShukkaZumiSuu) as ShukkaSiziZumiSuu,
			   WK.MiNyuukaSuu,ISNULL(FLOOR(DSM.ShukkaSiziSuu -(DSM.ShukkaZumiSuu + WK.MiNyuukaSuu)),'0') as ShukkaSuu,null as Kanryou,null as ShukkaMeisaiTekiyou,--明細摘要
			   (DSM.ShukkaSiziNO + '-'+ cast(DSM.ShukkaSiziGyouNO as varchar)) as ShukkaSiziNOGyouNO,
			   --hidden field
			   DS.TokuisakiCD,DSM.KouritenCD,DS.DenpyouDate,(DSM.JuchuuNO+'-'+cast(DSM.JuchuuGyouNO as varchar)) as JuchuuNOGyouNO

		from D_ShukkaSizi DS
		inner join D_ShukkaSiziMeisai DSM on DSM.ShukkaSiziNO = DS.ShukkaSiziNO
		left outer join #WK_MiNyuukaSuu2	WK on WK.ShukkaSiziNO = DSM.ShukkaSiziNO and WK.ShukkaSiziGyouNO=DSM.ShukkaSiziGyouNO	
		left outer join F_Tokuisaki(@ChangeDate) FT on FT.TokuisakiCD = DS.TokuisakiCD
		left outer join F_Kouriten(@ChangeDate) FK on FK.KouritenCD = DSM.KouritenCD
		where (@TokuisakiCD is null or(DS.TokuisakiCD=@TokuisakiCD))  
		and (@ShukkaSiziNO is null or(DS.ShukkaSiziNO=@ShukkaSiziNO))  
		and	DSM.ShukkaKanryouKBN =0
		and (@ShukkaYoteiDate1 is null or(DS.ShukkaYoteiDate>=@ShukkaYoteiDate1))  
		and (@ShukkaYoteiDate2 is null or(DS.ShukkaYoteiDate<=@ShukkaYoteiDate2))  
		and (@DenpyouDate1 is null or(DS.DenpyouDate>=@DenpyouDate1))  
		and (@DenpyouDate2 is null or(DS.DenpyouDate<=@DenpyouDate2))  
		and	(((@YuubinNO1 is null or(DS.TokuisakiYuubinNO1=@YuubinNO1))  and (@YuubinNO2 is null or(DS.TokuisakiYuubinNO2=@YuubinNO2)))
			or ((@YuubinNO1 is null or(DSM.KouritenYuubinNO1=@YuubinNO1))  and (@YuubinNO2 is null or(DSM.KouritenYuubinNO2=@YuubinNO2))))
		and (((@TelNO1 is null or(DS.[TokuisakiTelNO1-1]=@TelNO1))  and (@TelNO2 is null or(DS.[TokuisakiTelNO1-2]=@TelNO2)) and (@TelNO3 is null or(DS.[TokuisakiTelNO1-3]=@TelNO3)))
			or ((@TelNO1 is null or(DSM.[KouritenTelNO1-1]=@TelNO1))  and (@TelNO2 is null or(DSM.[KouritenTelNO1-2]=@TelNO2)) and (@TelNO3 is null or(DSM.[KouritenTelNO1-3]=@TelNO3))))
		and ((@Name is null or(DS.TokuisakiRyakuName=@Name)) or (@Name is null or(DS.TokuisakiName=@Name)) or (@Name is null or(DSM.KouritenRyakuName=@Name)) or (@Name is null or(DSM.KouritenName=@Name)))
		and ((@Name is null or(DS.TokuisakiJuusho1=@Name)) or (@Name is null or(DS.TokuisakiJuusho2=@Name)) or (@Name is null or(DSM.KouritenJuusho1=@Name)) or (@Name is null or(DSM.KouritenJuusho2=@Name)))

		order by DSM.ShouhinCD ASC,DSM.ShukkaSiziNO ASC,DSM.GyouHyouziJun ASC
	end
	else 
	begin
		select DSM.JANCD,DSM.ShouhinCD,DSM.ShouhinName,DSM.ColorRyakuName,DSM.ColorNO,DSM.SizeNO,(DSM.ShukkaSiziSuu-DSM.ShukkaZumiSuu) as ShukkaSiziZumiSuu,
			   WK.MiNyuukaSuu,ISNULL(FLOOR(DSM.ShukkaSiziSuu -(DSM.ShukkaZumiSuu + WK.MiNyuukaSuu)),'0') as ShukkaSuu,null as Kanryou,null as ShukkaMeisaiTekiyou,--明細摘要
			   (DSM.ShukkaSiziNO + '-'+ cast(DSM.ShukkaSiziGyouNO as varchar)) as ShukkaSiziNOGyouNO,
			   --hidden field
			   DS.TokuisakiCD,DSM.KouritenCD,DS.DenpyouDate,(DSM.JuchuuNO+'-'+cast(DSM.JuchuuGyouNO as varchar)) as JuchuuNOGyouNO

		from D_ShukkaSizi DS
		inner join D_ShukkaSiziMeisai DSM on DSM.ShukkaSiziNO = DS.ShukkaSiziNO
		left outer join #WK_MiNyuukaSuu2	WK on WK.ShukkaSiziNO = DSM.ShukkaSiziNO and WK.ShukkaSiziGyouNO=DSM.ShukkaSiziGyouNO	
		left outer join F_Tokuisaki(@ChangeDate) FT on FT.TokuisakiCD = DS.TokuisakiCD
		left outer join F_Kouriten(@ChangeDate) FK on FK.KouritenCD = DSM.KouritenCD
		where (@TokuisakiCD is null or(DS.TokuisakiCD=@TokuisakiCD))  
		and (@ShukkaSiziNO is null or(DS.ShukkaSiziNO=@ShukkaSiziNO))  
		and	DSM.ShukkaKanryouKBN =0
		and (@ShukkaYoteiDate1 is null or(DS.ShukkaYoteiDate>=@ShukkaYoteiDate1))  
		and (@ShukkaYoteiDate2 is null or(DS.ShukkaYoteiDate<=@ShukkaYoteiDate2))  
		and (@DenpyouDate1 is null or(DS.DenpyouDate>=@DenpyouDate1))  
		and (@DenpyouDate2 is null or(DS.DenpyouDate<=@DenpyouDate2))  
		order by DSM.ShouhinCD ASC,DSM.ShukkaSiziNO ASC,DSM.GyouHyouziJun ASC
	end

		If(OBJECT_ID('tempdb..#WK_MiNyuukaSuu2') Is Not Null)
		begin
			Drop Table #WK_MiNyuukaSuu2
		end

		EXEC D_Exclusive_Insert
		12,
		@ShukkaSiziNO,
		@Operator,
		@Program,
		@PC;
	
END
