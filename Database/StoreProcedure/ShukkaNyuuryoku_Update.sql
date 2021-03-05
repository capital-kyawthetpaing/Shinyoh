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
					ShukkaSuu				decimal(21,6) DEFAULT 0.0,		--konkai
					Kanryo					tinyint DEFAULT 0,
					ShukkaMeisaiTekiyou		varchar(80) COLLATE DATABASE_DEFAULT,		--Detail
					SoukoCD					varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaSiziNOGyouNO		varchar(25) COLLATE DATABASE_DEFAULT,
					JuchuuNOGyouNO			varchar(12) COLLATE DATABASE_DEFAULT,
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
			  ,ShukkaSuu
			  ,Kanryo
			  ,ShukkaMeisaiTekiyou
			  ,SoukoCD
			  ,ShukkaSiziNOGyouNO   			 
			  ,JuchuuNOGyouNO
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
					ShukkaSuu				decimal(21,6) 'ShukkaSuu',
					Kanryo					tinyint 'Kanryo',
					ShukkaMeisaiTekiyou		varchar(80) 'ShukkaMeisaiTekiyou',
					SoukoCD					varchar(12)'SoukoCD',
					ShukkaSiziNOGyouNO		varchar(25)'ShukkaSiziNOGyouNO',
					JuchuuNOGyouNO			varchar(12)'JuchuuNOGyouNO',
					DenpyouDate				date 'DenpyouDate'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust
					
		declare		@Unique as uniqueidentifier = NewID(),
					@ShukkaDate as varchar(10) = (select ShukkaDate from #Temp_Main),
					@ShukkaNO varchar(12)=(select ShukkaNO from #Temp_Main ),
					@StaffCD varchar(10) = (select StaffCD from #Temp_Main),
					@TokuisakiCD varchar(10) = (select TokuisakiCD from #Temp_Main),
					@KouritenCD varchar(10) = (select KouritenCD from #Temp_Main),
					--@ShouhinCD varchar(10) = (select ShouhinCD from #Temp_Detail),
					@InsertOperator varchar(10) = (select InsertOperator from #Temp_Main),
					@UpdateOperator varchar(10) = (select UpdateOperator from #Temp_Main),
					@ProgramID varchar(100) = (select ProgramID from #Temp_Main),
					@PC varchar(30) = (select PC from #Temp_Main),
					@KeyItem varchar(100)= (select ShukkaNO from #Temp_Main),
					@currentDate as datetime = getdate(),
					@row as int =0


			--D_Shukka A
		UPDATE D_Shukka
		SET StaffCD=m.StaffCD
			,ShukkaDate=m.ShukkaDate
			,KaikeiYYMM=CONVERT(int, FORMAT(Cast(m.ShukkaDate as Date), 'yyyyMM'))
			,TokuisakiCD=m.TokuisakiCD
			,TokuisakiRyakuName=case when FT.ShokutiFLG=0 then FT.TokuisakiRyakuName else m.TokuisakiRyakuName end
			,KouritenCD=m.KouritenCD
			,[KouritenRyakuName]=case when FK.ShokutiFLG=0 then FK.KouritenRyakuName else m.KouritenRyakuName end
			,ShukkaDenpyouTekiyou=m.ShukkaDenpyouTekiyou
			,UriageKanryouKBN=0
			,TokuisakiName=case when FT.ShokutiFLG=0 then FT.TokuisakiName else m.TokuisakiName end
			,TokuisakiYuubinNO1=case when FT.ShokutiFLG=0 then FT.YuubinNO1 else m.TokuisakiYuubinNO1 end
			,TokuisakiYuubinNO2=case when FT.ShokutiFLG=0 then FT.YuubinNO2 else m.TokuisakiYuubinNO2 end
			,TokuisakiJuusho1=case when FT.ShokutiFLG=0 then FT.Juusho1 else m.TokuisakiJuusho1 end
			,TokuisakiJuusho2=case when FT.ShokutiFLG=0 then FT.Juusho2 else m.TokuisakiJuusho2 end
			,[TokuisakiTelNO1-1]=case when FT.ShokutiFLG=0 then FT.Tel11 else m.TokuisakiTel11 end
			,[TokuisakiTelNO1-2]=case when FT.ShokutiFLG=0 then FT.Tel12 else m.TokuisakiTel12 end
			,[TokuisakiTelNO1-3]=case when FT.ShokutiFLG=0 then FT.Tel13 else m.TokuisakiTel13 end
			,[TokuisakiTelNO2-1]=case when FT.ShokutiFLG=0 then FT.Tel21 else m.TokuisakiTel21 end
			,[TokuisakiTelNO2-2]=case when FT.ShokutiFLG=0 then FT.Tel22 else m.TokuisakiTel22 end
			,[TokuisakiTelNO2-3]=case when FT.ShokutiFLG=0 then FT.Tel23 else m.TokuisakiTel23 end
			,TokuisakiTantouBushoName=case when FT.ShokutiFLG=0 then FT.TantouBusho else NULL end
			,TokuisakiTantoushaYakushoku=case when FT.ShokutiFLG=0 then FT.TantouYakushoku else NULL end
			,TokuisakiTantoushaName=case when FT.ShokutiFLG=0 then FT.TantoushaName else NULL end

			,KouritenName=case when FK.ShokutiFLG=0 then FK.KouritenName else m.KouritenName end
			,KouritenYuubinNO1=case when FK.ShokutiFLG=0 then FK.YuubinNO1 else m.KouritenYuubinNO1 end
			,KouritenYuubinNO2=case when FK.ShokutiFLG=0 then FK.YuubinNO2 else m.KouritenYuubinNO2 end
			,KouritenJuusho1=case when FK.ShokutiFLG=0 then FK.Juusho1 else m.KouritenJuusho1 end
			,KouritenJuusho2=case when FK.ShokutiFLG=0 then FK.Juusho2 else m.KouritenJuusho2 end
			,[KouritenTelNO1-1]=case when FK.ShokutiFLG=0 then FK.Tel11 else m.KouritenTel11 end
			,[KouritenTelNO1-2]=case when FK.ShokutiFLG=0 then FK.Tel12 else m.KouritenTel12 end
			,[KouritenTelNO1-3]=case when FK.ShokutiFLG=0 then FK.Tel13 else m.KouritenTel13 end
			,[KouritenTelNO2-1]=case when FK.ShokutiFLG=0 then FK.Tel21 else m.KouritenTel21 end
			,[KouritenTelNO2-2]=case when FK.ShokutiFLG=0 then FK.Tel22 else m.KouritenTel22 end
			,[KouritenTelNO2-3]=case when FK.ShokutiFLG=0 then FK.Tel23 else m.KouritenTel23 end
			,KouritenTantouBushoName=case when FK.ShokutiFLG=0 then FK.TantouBusho else NUll end
			,KouritenTantoushaYakushoku=case when FK.ShokutiFLG=0 then FK.TantouYakushoku else NUll end
			,KouritenTantoushaName=case when FK.ShokutiFLG=0 then FK.TantoushaName else NUll end

			,TorikomiDenpyouNO=NULL
			,[UpdateOperator]=m.UpdateOperator
			,[UpdateDateTime]=@currentDate
		FROM #Temp_Main m
			left outer join F_Tokuisaki(@ShukkaDate) FT on FT.TokuisakiCD=m.TokuisakiCD
			left outer join F_Kouriten(@ShukkaDate) FK on FK.KouritenCD=m.KouritenCD
			where D_Shukka.ShukkaNO=m.ShukkaNO



			--D_ShukkaMeisai B
			update D_ShukkaMeisai set 
			GyouHyouziJun = @row + @row + 1,
			DenpyouDate = d.DenpyouDate,
			BrandCD = FS.BrandCD,
			ShouhinCD = d.ShouhinCD,
			ShouhinName = d.ShouhinName,
			JANCD =d.JANCD,
			ColorRyakuName = d.ColorRyakuName,
			ColorNO = d.ColorNO,
			SizeNO = d.SizeNO,
			ShukkaSuu = case when d.ShukkaSuu is not null then d.ShukkaSuu else 0 end,
			TaniCD = FS.TaniCD,
			ShukkaMeisaiTekiyou = NULLIF(d.ShukkaMeisaiTekiyou,''),
			UriageKanryouKBN = 0,
			UriageZumiSuu = 0,
			ShukkaSiziNO = (select val from dbo.split(d.ShukkaSiziNOGyouNO,'-') where id=1),
			ShukkaSiziGyouNO =(select val from dbo.split(d.ShukkaSiziNOGyouNO,'-') where id=2),
			JuchuuNO = (select val from dbo.split(d.JuchuuNOGyouNO,'-') where id=1),
			JuchuuGyouNO =(select val from dbo.split(d.JuchuuNOGyouNO,'-') where id=2),
			UpdateOperator = @UpdateOperator,
			UpdateDateTime = @currentDate
			from #Temp_Detail d
			left outer join D_ShukkaSiziMeisai DSM  on DSM.ShukkaSiziNO=LEFT((d.ShukkaSiziNOGyouNO), CHARINDEX('-', (d.ShukkaSiziNOGyouNO)) - 1) 
			and DSM.ShukkaSiziGyouNO=RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))
			left outer join F_Shouhin(@ShukkaDate) FS on FS.ShouhinCD=d.ShouhinCD


		--D_ShukkaShousai C
		Update  D_ShukkaShousai set				
		 SoukoCD = d.SoukoCD,
		 ShouhinCD = d.ShouhinCD,
		 ShouhinName = d.ShouhinName,
		 ShukkaSuu = DS.ShukkaZumiSuu,
		 KanriNO = DS.KanriNO,
		 NyuukoDate = DS.NyuukoDate,
		 UriageZumiSuu = 0,
		ShukkaSiziNO = DS.ShukkaSiziNO,
		ShukkaSiziGyouNO = DS.ShukkaSiziGyouNO,
		ShukkaSiziShousaiNO = DS.ShukkaSiziShousaiNO,
		JuchuuNO = DS.JuchuuNO,
		JuchuuGyouNO = DS.JuchuuGyouNO,
		JuchuuShousaiNO =DS.JuchuuShousaiNO,
		InsertOperator = m.InsertOperator,
		InsertDateTime = @currentDate,
		UpdateOperator = m.UpdateOperator,
		UpdateDateTime= @currentDate
				from D_ShukkaSiziShousai DS,#Temp_Detail d,#Temp_Main m
				where DS.ShukkaSiziNO = LEFT((d.ShukkaSiziNOGyouNO), CHARINDEX('-', (d.ShukkaSiziNOGyouNO)) - 1)
				and DS.ShukkaSiziGyouNO=RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))
				and d.ShouhinCD=DS.ShouhinCD
				and  DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != '' 
			


			--D_ShukkaHistory D
			INSERT INTO D_ShukkaHistory
				(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
				 ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
				 [TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
				 KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
				 KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select @Unique,DS.ShukkaNO,20,DS.StaffCD,DS.ShukkaDate,KaikeiYYMM,DS.TokuisakiCD,DS.TokuisakiRyakuName,DS.KouritenCD,DS.KouritenRyakuName,
					DS.ShukkaDenpyouTekiyou,UriageKanryouKBN,DS.TokuisakiName,DS.TokuisakiYuubinNO1,DS.TokuisakiYuubinNO2,DS.TokuisakiJuusho1,DS.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
					[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,DS.KouritenName,DS.KouritenYuubinNO1,DS.KouritenYuubinNO2,
					DS.KouritenJuusho1,DS.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
					KouritenTantoushaName,TorikomiDenpyouNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				 from D_Shukka DS, #Temp_Main m
		

			  --D_ShukkaMeisaiHistory E
			INSERT INTO D_ShukkaMeisaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
				 UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select  @Unique,DS.ShukkaNO,ShukkaGyouNO,GyouHyouziJun,20,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,
					UriageKanryouKBN,UriageZumiSuu,DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				from D_ShukkaMeisai DS,#Temp_Main m 


			---- D_ShukkaShousaiHistory F
			INSERT INTO D_ShukkaShousaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				  JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select  @Unique,DS.ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,20,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,DS.ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				   JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				from D_ShukkaShousai DS, #Temp_Main m
	

			--D_GenZaiko 
				Update  DG set  
				SoukoCD = DS.SoukoCD,
				ShouhinCD = DS.ShouhinCD,
				KanriNO = DS.KanriNO,
				NyuukoDate = DS.NyuukoDate,
				GenZaikoSuu = DS.ShukkaSiziSuu,
				IdouSekisouSuu = DS.ShukkaZumiSuu,
				InsertOperator = m.InsertOperator,
				InsertDateTime = @currentDate,
				UpdateOperator = m.UpdateOperator,
				UpdateDateTime = @currentDate
					 from D_ShukkaSiziShousai DS,#Temp_Detail d,#Temp_Main m,D_GenZaiko DG
					 where DS.ShukkaSiziNO = LEFT((d.ShukkaSiziNOGyouNO), CHARINDEX('-', (d.ShukkaSiziNOGyouNO)) - 1)
						and DS.ShukkaSiziGyouNO=RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))
						and d.ShouhinCD=DS.ShouhinCD
						and  ShukkaSiziSuu > ShukkaZumiSuu and DS.NyuukoDate != '' and  	DG.SoukoCD= DS.SoukoCD and
				DG.ShouhinCD = DS.ShouhinCD and
				DG.KanriNO = DS.KanriNO and
				DG.NyuukoDate= DS.NyuukoDate
						


				--D_JuchuuShousai 
				Update DJ set
				 JuchuuNO = DS.JuchuuNO,
				 JuchuuGyouNO = DS.JuchuuGyouNO,
				 JuchuuShousaiNO = DS.JuchuuShousaiNO,
				 SoukoCD = DS.SoukoCD,
				 ShouhinCD = DS.ShouhinCD,
				 ShouhinName = DS.ShouhinName,
				 JuchuuSuu = 0,
				 KanriNO = DS.KanriNO,
				 NyuukoDate = DS.NyuukoDate,
				 HikiateZumiSuu = 0,
				 MiHikiateSuu = 0,
				 ShukkaSiziZumiSuu = 0,
				 ShukkaZumiSuu = DS.ShukkaZumiSuu,
				 UriageZumiSuu = 0,
				 HacchuuNO = NULL,
				 HacchuuGyouNO = NULL,
				InsertOperator = m.InsertOperator,
				InsertDateTime = @currentDate,
				UpdateOperator = m.UpdateOperator,
				UpdateDateTime = @currentDate
						from D_ShukkaSiziShousai DS,#Temp_Detail d,#Temp_Main m,D_JuchuuShousai DJ
						where DS.ShukkaSiziNO = LEFT((d.ShukkaSiziNOGyouNO), CHARINDEX('-', (d.ShukkaSiziNOGyouNO)) - 1)
						and DS.ShukkaSiziGyouNO=RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))
						and d.ShouhinCD=DS.ShouhinCD
						and  DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != '' and DJ.JuchuuNO = DS.JuchuuNO and 
				 DJ.JuchuuGyouNO = DS.JuchuuGyouNO and
				 DJ.JuchuuShousaiNO = DS.JuchuuShousaiNO
					


				--窶ｻ繧ｷ繝ｼ繝医梧ｶ郁ｾｼ鬆・榊盾辣ｧ
			DECLARE @Price_table TABLE (idx int Primary Key IDENTITY(1,1),
									KonkaiShukkaSuu varchar(50),
									ShukkaSiziNOGyouNO  varchar(25),ShouhinCD  varchar(50))
						INSERT @Price_table  SELECT ShukkaSuu,ShukkaSiziNOGyouNO,ShouhinCD FROM #Temp_Detail
			
			declare @Count as int = 1
			
						WHILE @Count <= (SELECT COUNT(*) FROM #Temp_Detail)
						BEGIN
						declare @KonkaiShukkaSuu varchar(50)=(select KonkaiShukkaSuu from @Price_table  WHERE idx =@Count)
							declare @Value2 as varchar(25)=(select ShukkaSiziNOGyouNO from @Price_table WHERE idx =@Count),
								@Value3 as varchar(50)=(select ShouhinCD  from @Price_table WHERE idx =@Count)
			 
							DECLARE CUR_POINTER CURSOR FAST_FORWARD FOR
							SELECT ShukkaSuu
							FROM   #Temp_Detail    
 
						OPEN CUR_POINTER
						FETCH NEXT FROM CUR_POINTER INTO @KonkaiShukkaSuu
 
						WHILE @@FETCH_STATUS = 0
						BEGIN		

							exec  [dbo].[Shukka_Price]  @KonkaiShukkaSuu,@Value2,@Value3

							FETCH NEXT FROM CUR_POINTER INTO @KonkaiShukkaSuu
						END
						CLOSE CUR_POINTER
						DEALLOCATE CUR_POINTER
					SET @Count = @Count + 1
						END;

			--D_ShukkaSiziMeisai G
			update D_ShukkaSiziMeisai set	
				ShukkaZumiSuu = ShukkaZumiSuu + d.ShukkaSuu,
				UpdateOperator = m.InsertOperator,
				UpdateDateTime = @currentDate			
			from #Temp_Main m,D_ShukkaSiziMeisai DS
			inner join #Temp_Detail d on LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1)=DS.ShukkaSiziNO 
										and RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))=DS.ShukkaSiziGyouNO
			

			----D_ShukkaSiziMeisai G
				update D_ShukkaSiziMeisai set	
					ShukkaZumiSuu = case when DS.ShukkaZumiSuu-d.ShukkaSuu>0 then  DS.ShukkaZumiSuu-d.ShukkaSuu
									when DS.ShukkaZumiSuu-d.ShukkaSuu<=0 then 0 end,
					UpdateOperator = m.UpdateOperator,
					UpdateDateTime = @currentDate			
				from #Temp_Main m,D_ShukkaSiziMeisai DS
				inner join #Temp_Detail d on LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1)=DS.ShukkaSiziNO 
											and RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))=DS.ShukkaSiziGyouNO


			----D_ShukkaSiziMeisai A
			update A set	
				ShukkaKanryouKBN = case WHEN ShukkaSiziSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 1 Then 1 ELSE 0 End
			from D_ShukkaSiziMeisai A,#Temp_Detail d
			where A.ShukkaSiziNO=LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1) 



			--D_ShukkaSizi A
			update A set	
				ShukkaKanryouKBN = B.ShukkaKanryouKBN
			from D_ShukkaSizi A
			inner join (select ShukkaSiziNO,min(ShukkaKanryouKBN) ShukkaKanryouKBN from D_ShukkaSiziMeisai, #Temp_Detail d 
			where ShukkaSiziNO=LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1)	group by ShukkaSiziNO)B
			on A.ShukkaSiziNO=B.ShukkaSiziNO 

		----	------D_JuchuuShousai 
		----	----	WHILE @a >0
		----	----		BEGIN
		----	----		IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai DJ
		----	----			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE ShukkaSiziZumiSuu > ShukkaZumiSuu and NyuukoDate != ''
		----	----			AND ShukkaSi = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
		----	----			ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
		----	----			AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)))
		----	----		BEGIN		
		----	----			UPDATE DS
		----	----			SET DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaSiziSuu > @a THEN DS.ShukkaZumiSuu + 200 ELSE 0 END, 
		----	----				--DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaZumiSuu > @a THEN DS.ShukkaZumiSuu + @b ELSE 0 END,
		----	----				@b = CASE WHEN DS.ShukkaSiziSuu > @a THEN @a - 200 ELSE 0 END
		----	----			FROM D_ShukkaSiziShousai DS
		----	----			INNER JOIN (SELECT TOP 1 * FROM D_ShukkaSiziShousai WHERE ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
		----	----			AND ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
		----	----			ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
		----	----			AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO))
		----	----		END
		----	----			ELSE
		----	----				BREAK
		----	----		END

			--D_JuchuuMeisai H
			update DJ set	
				ShukkaZumiSuu = ShukkaZumiSuu + d.ShukkaSuu,
				UpdateOperator = m.InsertOperator,
				UpdateDateTime = @currentDate			
			from #Temp_Main m,D_JuchuuMeisai DJ
			inner join #Temp_Detail d on LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)=DJ.JuchuuNO 
			and RIGHT(d.JuchuuNOGyouNO, LEN(d.JuchuuNOGyouNO) - CHARINDEX('-', d.JuchuuNOGyouNO))=DJ.JuchuuGyouNO


			--D_JuchuuMeisai H
				update DJ set	
					ShukkaZumiSuu =  case when DJ.ShukkaZumiSuu-d.ShukkaSuu>0 then  DJ.ShukkaZumiSuu-d.ShukkaSuu
									when DJ.ShukkaZumiSuu-d.ShukkaSuu<=0 then 0 end,
					UpdateOperator = m.InsertOperator,
					UpdateDateTime = @currentDate			
				from #Temp_Main m,D_JuchuuMeisai DJ
				inner join #Temp_Detail d on LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)=DJ.JuchuuNO 
				and RIGHT(d.JuchuuNOGyouNO, LEN(d.JuchuuNOGyouNO) - CHARINDEX('-', d.JuchuuNOGyouNO))=DJ.JuchuuGyouNO


			--D_JuchuuMeisai A
			update A set	
				ShukkaKanryouKBN = case WHEN A.ShukkaSiziZumiSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 1 Then 1 ELSE 0 End
			from #Temp_Detail d,D_JuchuuMeisai A
			where A.JuchuuNO=LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)


			--D_Juchuu A
			update A set	
				ShukkaKanryouKBN = B.ShukkaKanryouKBN
			from #Temp_Detail d,D_Juchuu A
			inner join (select JuchuuNO,min(ShukkaKanryouKBN) ShukkaKanryouKBN from D_JuchuuMeisai DM,#Temp_Detail d 
			where DM.JuchuuNO=LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)	group by JuchuuNO) B
			on A.JuchuuNO=B.JuchuuNO
			

			UPDATE M_Tokuisaki 
			set UsedFlg = 1 
			where TokuisakiCD=@TokuisakiCD
			and  ChangeDate = (select ChangeDate from F_Tokuisaki(@ShukkaDate) where TokuisakiCD = @TokuisakiCD)

			UPDATE  M
			set UsedFlg = 1 from M_Shouhin M ,#Temp_Detail d
			where M.ShouhinCD=d.ShouhinCD
			and  ChangeDate = (select ChangeDate from F_Shouhin(@ShukkaDate) where ShouhinCD = d.ShouhinCD)

			UPDATE M_Kouriten 
			set UsedFlg = 1 
			where KouritenCD=@KouritenCD
			and  ChangeDate = (select ChangeDate from F_Kouriten(@ShukkaDate) where KouritenCD = @KouritenCD)

			UPDATE M_Staff 
			set UsedFlg = 1 
			where StaffCD=@StaffCD
			and  ChangeDate = (select ChangeDate from F_Staff(@ShukkaDate) where StaffCD = @StaffCD)


			--L_Log Z	
			exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'Update',@KeyItem

		
			--D_Exclusive X
			EXEC [dbo].[D_Exclusive_Delete]
				6,
				@ShukkaNO;


					

		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail
END




