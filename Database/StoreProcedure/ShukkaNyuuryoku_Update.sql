 BEGIN TRY 
 Drop Procedure dbo.[ShukkaNyuuryoku_Update]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 12/24/2020 
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaNyuuryoku_Update]
	-- Add the parameters for the stored procedure here
	@XML_Main as xml,
	@XML_Detail as xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE  @hQuantityAdjust AS INT 
	declare @currentDate as datetime = getdate()

	declare @ShukkauNO as varchar(12) = 'S001' 
	--declare @HacchuuNO as varchar(12) = 'H002'
	declare @Unique as uniqueidentifier = NewID()

	begin

		CREATE TABLE #Temp_Main
				(   
					ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
					StaffCD					varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaDate				date,
					TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
					TokuisakiName			varchar(120) COLLATE DATABASE_DEFAULT,
					TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO1      varchar(3) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO2      varchar(4) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho1		varchar(50) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho2        varchar(50) COLLATE DATABASE_DEFAULT,
					TokuisakiTel11          varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel12          varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel13          varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel21			varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel22			varchar(5) COLLATE DATABASE_DEFAULT,	
					TokuisakiTel23			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenCD				varchar(10) COLLATE DATABASE_DEFAULT,
					KouritenName			varchar(120) COLLATE DATABASE_DEFAULT,
					KouritenRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO1		varchar(3) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO2       varchar(4) COLLATE DATABASE_DEFAULT,
					KouritenJuusho1         varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2			varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenTel11			varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel12			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel13			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel21			varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel22			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel23			varchar(5) COLLATE DATABASE_DEFAULT,	
					ShukkaDenpyouTekiyou    varchar(80) COLLATE DATABASE_DEFAULT,
					ShukkaSiziNO            varchar(12) COLLATE DATABASE_DEFAULT,
					ShukkaYoteiDate1		date,
					ShukkaYoteiDate2        date,	
					DenpyouDate1			date,	
					DenpyouDate2			date,	
					YuubinNo1				varchar(3) COLLATE DATABASE_DEFAULT,	
					YuubinNo2				varchar(4) COLLATE DATABASE_DEFAULT,	
					TelNo1					varchar(6) COLLATE DATABASE_DEFAULT,	
					TelNo2					varchar(5) COLLATE DATABASE_DEFAULT,	
					TelNo3					varchar(5) COLLATE DATABASE_DEFAULT,	
					Juusho					varchar(80) COLLATE DATABASE_DEFAULT,	
					Meishou					varchar(40) COLLATE DATABASE_DEFAULT,
					InsertOperator			varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator			varchar(10) COLLATE DATABASE_DEFAULT,
					PC						varchar(20) COLLATE DATABASE_DEFAULT,
					ProgramID				varchar(100)
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

		
	    INSERT INTO #Temp_Main
           (ShukkaNO
			  ,StaffCD          
			  ,ShukkaDate          
			  ,TokuisakiCD       
			  ,TokuisakiName 
			  ,TokuisakiRyakuName           
			  ,TokuisakiYuubinNO1    
			  ,TokuisakiYuubinNO2 
			  ,TokuisakiJuusho1
			  ,TokuisakiJuusho2           
			  ,TokuisakiTel11           
			  ,TokuisakiTel12             
			  ,TokuisakiTel13             
			  ,TokuisakiTel21               
			  ,TokuisakiTel22                
			  ,TokuisakiTel23                
			  ,KouritenCD                
			  ,KouritenName                
			  ,KouritenRyakuName               
			  ,KouritenYuubinNO1          
			  ,KouritenYuubinNO2      
			  ,KouritenJuusho1       
			  ,KouritenJuusho2  
			  ,KouritenTel11            
			  ,KouritenTel12    
			  ,KouritenTel13 
			  ,KouritenTel21              
			  ,KouritenTel22              
			  ,KouritenTel23   
			  ,ShukkaDenpyouTekiyou
			  ,ShukkaSiziNO  
			  ,ShukkaYoteiDate1            
			  ,ShukkaYoteiDate2    
			  ,DenpyouDate1 
			  ,DenpyouDate2              
			  ,YuubinNo1              
			  ,YuubinNo2   
			  ,TelNo1
			  ,TelNo2            
			  ,TelNo3    
			  ,Juusho 
			  ,Meishou              
			  ,InsertOperator              
			  ,UpdateOperator   
			  ,PC
			  ,ProgramID)
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShukkaNO				varchar(12) 'ShukkaNO',
					StaffCD					varchar(10) 'StaffCD',
					ShukkaDate				date 'ShukkaDate',
					TokuisakiCD				varchar(10) 'TokuisakiCD',
					TokuisakiName			varchar(120) 'TokuisakiName',
					TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
					TokuisakiYuubinNO1      varchar(3) 'TokuisakiYuubinNO1',
					TokuisakiYuubinNO2      varchar(4) 'TokuisakiYuubinNO2',
					TokuisakiJuusho1		varchar(50) 'TokuisakiJuusho1',
					TokuisakiJuusho2        varchar(50) 'TokuisakiJuusho2',
					TokuisakiTel11          varchar(6) 'TokuisakiTel11',
					TokuisakiTel12          varchar(5) 'TokuisakiTel12',
					TokuisakiTel13          varchar(5) 'TokuisakiTel13',
					TokuisakiTel21			varchar(6) 'TokuisakiTel21',
					TokuisakiTel22			varchar(5) 'TokuisakiTel22',	
					TokuisakiTel23			varchar(5) 'TokuisakiTel23',	
					KouritenCD				varchar(10) 'KouritenCD',
					KouritenName			varchar(120) 'KouritenName',
					KouritenRyakuName		varchar(40) 'KouritenRyakuName',
					KouritenYuubinNO1		varchar(3) 'KouritenYuubinNO1',
					KouritenYuubinNO2       varchar(4) 'KouritenYuubinNO2',
					KouritenJuusho1         varchar(50) 'KouritenJuusho1',
					KouritenJuusho2			varchar(50) 'KouritenJuusho2',
					KouritenTel11			varchar(6) 'KouritenTel11',	
					KouritenTel12			varchar(5) 'KouritenTel12',	
					KouritenTel13			varchar(5) 'KouritenTel13',	
					KouritenTel21			varchar(6) 'KouritenTel21',	
					KouritenTel22			varchar(5) 'KouritenTel22',	
					KouritenTel23			varchar(5) 'KouritenTel23',	
					ShukkaDenpyouTekiyou	varchar(80) 'ShukkaDenpyouTekiyou',
					ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
					ShukkaYoteiDate1		date 'ShukkaYoteiDate1',
					ShukkaYoteiDate2        date 'ShukkaYoteiDate2',
					DenpyouDate1			date 'DenpyouDate1',
					DenpyouDate2			date 'DenpyouDate2',
					YuubinNo1				varchar(3) 'YuubinNo1',	
					YuubinNo2				varchar(4) 'YuubinNo2',	
					TelNo1					varchar(6) 'TelNo1',	
					TelNo2					varchar(5) 'TelNo2',	
					TelNo3					varchar(5) 'TelNo3',	
					Juusho				    varchar(80) 'Juusho',
					Meishou					varchar(40) 'Meishou',
					InsertOperator			varchar(10) 'InsertOperator',
					UpdateOperator			varchar(10) 'UpdateOperator',
					PC						varchar(20) 'PC',
					ProgramID				varchar(100) 'ProgramID'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Main

		CREATE TABLE #Temp_Detail
				(   
					JANCD					varchar(13) COLLATE DATABASE_DEFAULT,
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					ColorRyakuName			varchar(25) COLLATE DATABASE_DEFAULT,
					ColorNO					varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO					varchar(13) COLLATE DATABASE_DEFAULT,
					ShukkaSiziZumiSuu		decimal(21,6) DEFAULT 0.0,
					MiNyuukaSuu				decimal(21,6) DEFAULT 0.0,
					KonkaiShukkaSuu			decimal(21,6) DEFAULT 0.0,
					Kanryo					tinyint DEFAULT 0,
					Detail					varchar(80) COLLATE DATABASE_DEFAULT,
					ShukkaSiziNO			varchar(12) COLLATE DATABASE_DEFAULT,
					ShukkaSiziGyouNO		varchar(12) COLLATE DATABASE_DEFAULT,
					DenpyouDate				date
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		
	    INSERT INTO #Temp_Detail
           (JANCD
			  ,ShouhinCD
			  ,ShouhinName          
			  ,ColorRyakuName          
			  ,ColorNO       
			  ,SizeNO 
			  ,ShukkaSiziZumiSuu           
			  ,MiNyuukaSuu    
			  ,KonkaiShukkaSuu 
			  ,Kanryo
			  ,Detail           
			  ,ShukkaSiziNO   
			  ,ShukkaSiziGyouNO
			  ,DenpyouDate
			 )
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					JANCD					varchar(13) 'JANCD',
					ShouhinCD				varchar(50) 'ShouhinCD',
					ShouhinName				varchar(100) 'ShouhinName',
					ColorRyakuName			varchar(25) 'ColorRyakuName',
					ColorNO					varchar(13) 'ColorNO',
					SizeNO					varchar(13) 'SizeNO',
					ShukkaSiziZumiSuu		decimal(21,6) 'ShukkaSiziZumiSuu',
					MiNyuukaSuu				decimal(21,6) 'MiNyuukaSuu',
					KonkaiShukkaSuu         decimal(21,6) 'KonkaiShukkaSuu',
					Kanryo					tinyint 'Kanryo',
					Detail					varchar(80) 'Detail',
					ShukkaSiziNO			varchar(12)'ShukkaSiziNO',
					ShukkaSiziGyouNO		varchar(12)'ShukkaSiziGyouNO',
					DenpyouDate				date 'DenpyouDate'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

		
		 begin
		 declare @filter_date as date = (select ShukkaDate from #Temp_Main)

			----D_Shukka A
			--UPDATE D_Shukka SET 
			-- StaffCD=m.StaffCD,HacchuuDate=h.JuchuuDate,KaikeiYYMM=CONVERT(INT, FORMAT(Cast(h.JuchuuDate as Date), 'yyyyMM')),SiiresakiCD=m.SiiresakiCD,SiiresakiRyakuName=CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,
			-- SiharaisakiCD=FS.SiharaisakiCD,SiharaisakiRyakuName=FS.SiiresakiRyakuName,TuukaCD=0,RateKBN=1,SiireRate=1,
			-- HacchuuDenpyouTekiyou=h.JuchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku=0,DenpyouSiireHenpinHontaiKingaku=0,DenpyouSiireNebikiHontaiKingaku=0,DenpyouSiireShouhizeiGaku=0,DenpyouSiireShouhizeiGakuTuujou=0,
			-- DenpyouSiireShouhizeiGakuKeigen=0,DenpyouJoudaiHontaiKingaku=0,DenpyouJoudaiShouhizeiGaku=0,DenpyouGaikaSiireHontaiKingaku=0,DenpyouGaikaSiireHenpinHontaiKingaku=0,DenpyouGaikaSiireNebikiHontaiKingaku=0,
			-- DenpyouGaikaSiireShouhizeiGaku=0,DenpyouGaikaJoudaiHontaiKingaku=0,DenpyouGaikaJoudaiShouhizeiGaku=0,SiharaiKBN=0,SiharaiChouhaKBN=0,SiharaiHouhouCD=NULL,SiharaiYoteiDate=NULL,HacchuushoTekiyou=NULL,HacchuushoHuyouFLG=0,HacchuushoHakkouFLG=0,
			-- HacchuushoHakkouDatetime=NULL,ChakuniYoteiKanryouKBN=0,CHakuniKanryouKBN=0,SiireKanryouKBN=0,TorikomiDenpyouNO=NULL,
			-- SiiresakiName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
			-- SiiresakiYuubinNO1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
			-- SiiresakiYuubinNO2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
			-- SiiresakiJuusho1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
			-- SiiresakiJuusho2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
			--[SiiresakiTelNO1-1]= CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.SiiresakiTelNO11 END,
			--[SiiresakiTelNO1-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.SiiresakiTelNO12 END,
			--[SiiresakiTelNO1-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.SiiresakiTelNO13 END,
			--[SiiresakiTelNO2-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.SiiresakiTelNO21 END,
			--[SiiresakiTelNO2-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.SiiresakiTelNO22 END,
			--[SiiresakiTelNO2-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.SiiresakiTelNO23 END,
			--SiiresakiTantouBushoName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
			--SiiresakiTantoushaYakushoku=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
			--SiiresakiTantoushaName=	CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
			--SiharaisakiName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
			--SiharaisakiYuubinNO1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
			--SiharaisakiYuubinNO2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
			--SiharaisakiJuusho1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
			--SiharaisakiJuusho2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
			--[SiharaisakiTelNO1-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.SiiresakiTelNO11 END,
			--[SiharaisakiTelNO1-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.SiiresakiTelNO12 END,
			--[SiharaisakiTelNO1-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.SiiresakiTelNO13 END,
			--[SiharaisakiTelNO2-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.SiiresakiTelNO21 END,
			--[SiharaisakiTelNO2-2] =	CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.SiiresakiTelNO22 END,
			--[SiharaisakiTelNO2-3]=	CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.SiiresakiTelNO23 END,
			--SiharaisakiTantouBushoName =	CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
			--SiharaisakiTantoushaYakushoku=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
		 --   SiharaisakiTantoushaName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
			--UpdateOperator = h.UpdateOperator,UpdateDateTime=@currentDate
			--from  #Temp_Main m
			--left outer join F_Tokuisaki(@filter_date) FS on FS.TokuisakiCD  = m.TokuisakiCD	
			--left outer join F_Kouriten(@filter_date) FK on FK.KouritenCD  = m.KouritenCD	


			--D_Exclusive Y
			INSERT INTO D_Exclusive
				(DataKBN,Number,OperateDataTime,Operator,Program,PC)

			select  12,m.ShukkaSiziNO,@currentDate,m.InsertOperator,m.ProgramID,m.PC
			from #Temp_Main m

			--L_Log Z
			declare	@InsertOperator  varchar(10) = (select m.InsertOperator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
			declare @OperateMode     varchar(50) = 'New' 
			declare @KeyItem         varchar(100)= (select m.ShukkaNO from #Temp_Main m)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

		 end
		
		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail
	end
END




