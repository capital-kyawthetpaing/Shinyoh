 BEGIN TRY 
 Drop Procedure dbo.[CSV_M_Kouriten_CUD]
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
CREATE PROCEDURE [dbo].[CSV_M_Kouriten_CUD]
	-- Add the parameters for the stored procedure here
	@xml as XML,
	@condition  varchar(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE  @Rows AS INT 		

		CREATE TABLE #Temp
				(   
					SEQ						int IDENTITY(1,1),
					KouritenCD				VARCHAR(200),
					ChangeDate				VARCHAR(200),
					ShokutiFLG				VARCHAR(200),
					KouritenName			VARCHAR(200),
					KouritenRyakuName       VARCHAR(200), 
					KanaName				VARCHAR(200),
					KensakuHyouziJun		VARCHAR(200),
					TokuisakiCD             VARCHAR(200),
					AliasKBN				VARCHAR(200),
					YuubinNO1               VARCHAR(200),
					YuubinNO2				VARCHAR(200),
					Juusho1					VARCHAR(200),
					Juusho2					VARCHAR(200),
					Tel11					VARCHAR(200),
					Tel12					VARCHAR(200),	
					Tel13					VARCHAR(200),	
					Tel21				    VARCHAR(200),
					Tel22					VARCHAR(200),
					Tel23					VARCHAR(200),
					TantouBusho			    VARCHAR(200),
					TantouYakushoku         VARCHAR(200),
					TantoushaName           VARCHAR(200),
					MailAddress			    VARCHAR(200),
					StaffCD					VARCHAR(200),	
					TorihikiKaisiDate		VARCHAR(200) ,
					TorihikiShuuryouDate	VARCHAR(200) ,
					Remarks					VARCHAR(200),
					UsedFlg					VARCHAR(200),
					InsertOperator			VARCHAR(200),
					UpdateOperator			VARCHAR(200),
					Error1					VARCHAR(100),
					Error2					VARCHAR(100),
					ErrorFlg				BIT default 'FALSE'
				)
	  EXEC sp_xml_preparedocument @Rows OUTPUT, @xml

		
	    INSERT INTO #Temp
           (KouritenCD
			  ,ChangeDate          
			  ,ShokutiFLG          
			  ,KouritenName       
			  ,KouritenRyakuName 
			  ,KanaName           
			  ,KensakuHyouziJun    
			  ,TokuisakiCD 
			  ,AliasKBN
			  ,YuubinNO1           
			  ,YuubinNO2           
			  ,Juusho1             
			  ,Juusho2             
			  ,Tel11               
			  ,Tel12                
			  ,Tel13                
			  ,Tel21                
			  ,Tel22                
			  ,Tel23               
			  ,TantouBusho          
			  ,TantouYakushoku      
			  ,TantoushaName       
			  ,MailAddress  
			  ,StaffCD            
			  ,TorihikiKaisiDate    
			  ,TorihikiShuuryouDate 
			  ,Remarks              
			  ,UsedFlg              
			  ,InsertOperator   
			  ,UpdateOperator)
					 
			  SELECT * FROM OPENXML(@Rows, 'NewDataSet/test') WITH
					(
					KouritenCD				VARCHAR(200) 'KouritenCD',
					ChangeDate				VARCHAR(200) 'ChangeDate',
					ShokutiFLG				VARCHAR(200) 'ShokutiFLG',
					KouritenName			VARCHAR(200) 'KouritenName',
					KouritenRyakuName		VARCHAR(200) 'KouritenRyakuName', 
					KanaName				VARCHAR(200) 'KanaName',
					KensakuHyouziJun		VARCHAR(200) 'KensakuHyouziJun',
					TokuisakiCD             VARCHAR(200) 'TokuisakiCD',
					AliasKBN				VARCHAR(200) 'AliasKBN',
					YuubinNO1               VARCHAR(200) 'YuubinNO1',
					YuubinNO2				VARCHAR(200) 'YuubinNO2',
					Juusho1					VARCHAR(200) 'Juusho1',
					Juusho2					VARCHAR(200) 'Juusho2',
					Tel11					VARCHAR(200) 'Tel11',
					Tel12					VARCHAR(200) 'Tel12',	
					Tel13					VARCHAR(200) 'Tel13',	
					Tel21				    VARCHAR(200) 'Tel21',
					Tel22					VARCHAR(200) 'Tel22',
					Tel23					VARCHAR(200) 'Tel23',
					TantouBusho			    VARCHAR(200) 'TantouBusho',
					TantouYakushoku         VARCHAR(200) 'TantouYakushoku',
					TantoushaName           VARCHAR(200) 'TantoushaName',
					MailAddress			    VARCHAR(200) 'MailAddress',
					StaffCD					VARCHAR(200) 'StaffCD',	
					TorihikiKaisiDate		VARCHAR(200) 'TorihikiKaisiDate',
					TorihikiShuuryouDate	VARCHAR(200) 'TorihikiShuuryouDate',
					Remarks					VARCHAR(200) 'Remarks',
					UsedFlg					VARCHAR(200) 'UsedFlg',
					InsertOperator			varchar(10) 'InsertOperator',
					UpdateOperator			varchar(10) 'UpdateOperator')

		EXEC SP_XML_REMOVEDOCUMENT @Rows

--Null check
	update #Temp
	set ErrorFlg = 1,
		Error1 = case when isnull(ltrim(rtrim(KouritenCD)),'') = '' then '小売店CD未入力エラー'
					when isnull(ltrim(rtrim(ChangeDate)),'') = '' then '改定日未入力エラー' 
					when isnull(ltrim(rtrim(ShokutiFLG)),'') = '' then '諸口未入力エラー' 
					when isnull(ltrim(rtrim(KouritenName)),'') = '' then '小売店名未入力エラー' 
					when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '略名未入力エラー' 
					when isnull(ltrim(rtrim(TokuisakiCD)),'') = '' then '得意先CD未入力エラー' 
					when isnull(ltrim(rtrim(AliasKBN)),'') = '' then '敬称未入力エラー' 
					when isnull(ltrim(rtrim(StaffCD)),'') = '' then '担当スタッフCD未入力エラー' 
					end
	where isnull(ltrim(rtrim(KouritenCD)),'') = ''
	or isnull(ltrim(rtrim(ChangeDate)),'') = ''
	or isnull(ltrim(rtrim(ShokutiFLG)),'') = ''
	or isnull(ltrim(rtrim(KouritenName)),'') = ''
	or isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''
	or isnull(ltrim(rtrim(TokuisakiCD)),'') = ''
	or isnull(ltrim(rtrim(AliasKBN)),'') = ''
	or isnull(ltrim(rtrim(StaffCD)),'') = ''
	
	if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end

	--Length Check
	update #Temp
	set ErrorFlg = 1,
		Error1 = case when datalength(KouritenCD) > 10 then '小売店CD桁数エラー'
					when datalength(KouritenName) > 80 then '小売店名桁数エラー'
					when datalength(KouritenRyakuName) > 40 then '略名桁数エラー'
					when datalength(KanaName) > 80 then 'カナ名桁数エラー'
					when datalength(TokuisakiCD) > 10 then '得意先CD桁数エラー'
					when datalength(YuubinNO1) > 3 then '郵便番号１桁数エラー'
					when datalength(YuubinNO2) > 4 then '郵便番号２桁数エラー'
					when datalength(Juusho1) > 80 then '住所１桁数エラー'
					when datalength(Juusho2) > 80 then '住所２桁数エラー'
					when datalength(Tel11) > 6 then '電話番号①-1桁数エラー'
					when datalength(Tel12) > 5 then '電話番号①-2桁数エラー'
					when datalength(Tel13) > 5 then '電話番号①-3桁数エラー'
					when datalength(Tel21) > 6 then '電話番号②-1桁数エラー'
					when datalength(Tel22) > 5 then '電話番号②-2桁数エラー'
					when datalength(Tel23) > 5 then '電話番号②-3桁数エラー'
					when datalength(TantouBusho) > 40 then '担当部署桁数エラー'
					when datalength(TantouYakushoku) > 40 then '担当役職桁数エラー'
					when datalength(TantoushaName) > 40 then '担当者名桁数エラー'
					when datalength(MailAddress) > 100 then 'メールアドレス桁数エラー'
					when datalength(StaffCD) > 10 then '担当スタッフCD桁数エラー'
					when datalength(Remarks) > 80 then '備考桁数エラー'
				end
	from #Temp
	where datalength(KouritenCD) > 10
	or datalength(KouritenName) > 80
	or datalength(KouritenRyakuName) > 40
	or datalength(KanaName) > 80
	or datalength(TokuisakiCD) > 10
	or datalength(YuubinNO1) > 3
	or datalength(YuubinNO2) > 4
	or datalength(Juusho1) > 80
	or datalength(Juusho2) > 80
	or datalength(Tel11) > 6
	or datalength(Tel12) > 5
	or datalength(Tel13) > 5
	or datalength(Tel21) > 6
	or datalength(Tel22) > 5
	or datalength(Tel23) > 5
	or datalength(TantouBusho) > 40
	or datalength(TantouYakushoku) > 40
	or datalength(TantoushaName) > 40
	or datalength(MailAddress) > 100
	or datalength(StaffCD) > 10
	or datalength(Remarks) > 80


	if exists (select 1 from #Temp where ErrorFlg  = 1)
	begin
		goto error
	end

	--input check
	update #Temp
	set ErrorFlg = 1,
		Error1 = '入力可能値外エラー',
		Error2 = case when (ShokutiFLG < 0 and ShokutiFLG > 1) then '項目:諸口区分(0～1)'
					when (AliasKBN < 1 and AliasKBN > 2 ) then '項目:敬称(1～2)'
					when isdate(ChangeDate) = 0 then '項目:改定日'
					when isdate(isnull(nullif(ltrim(rtrim(TorihikiKaisiDate)),''),'2100-01-01')) = 0 then '取引開始日'
					when isdate(isnull(nullif(ltrim(rtrim(TorihikiShuuryouDate)),''),'2100-01-01')) = 0 then '取引終了日'
					end 
	where (ShokutiFLG < 0 and ShokutiFLG > 1)
	or (AliasKBN < 1 and AliasKBN > 2  )
	or isdate(ChangeDate) = 0
	or isdate(isnull(nullif(ltrim(rtrim(TorihikiKaisiDate)),''),'2100-01-01')) = 0 -- allow null, allow '' blank
	or isdate(isnull(nullif(ltrim(rtrim(TorihikiShuuryouDate)),''),'2100-01-01')) = 0

	if exists (select 1 from #Temp where ErrorFlg  = 1)
	begin
		goto error
	end

	--Not exists item of staff
	update #Temp
	set ErrorFlg = 1,
		Error1 = '担当スタッフCD未登録エラー'
	from #Temp tmp
	left outer join  F_Staff(getdate()) fs on fs.StaffCD = tmp.StaffCD 
	where fs.StaffCD is null

		--Not exists item of staff
	update #Temp
	set ErrorFlg = 1,
		Error1 = '得意先CD未登録エラー'
	from #Temp tmp
	left outer join  F_Tokuisaki(getdate()) ft on ft.TokuisakiCD = tmp.TokuisakiCD 
	where ft.TokuisakiCD is null


	if @condition = 'create_update'
		begin
			--Already exists item(not sure this check require. if we make this check, we can't update Tokuisaki.)
			update #Temp
			set ErrorFlg = 1,
				Error1 = '小売店CD登録済エラー'
			from #Temp tmp
			inner join M_Kouriten mk on mk.TokuisakiCD = tmp.TokuisakiCD and mk.KouritenCD=tmp.KouritenCD and mk.ChangeDate = tmp.ChangeDate
		end


	if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end
	else
		begin
			goto process
		end

	error:
		begin
			select top 1 '0' as Result,SEQ,Error1,Error2 from #Temp  where ErrorFlg = 1
			drop table #Temp
			return
		end
			
	goto process


	process:
		begin
		if @condition = 'create_update'
			begin
			INSERT INTO M_Kouriten
			   (KouritenCD
				  ,ChangeDate          
				  ,ShokutiFLG          
				  ,KouritenName       
				  ,KouritenRyakuName 
				  ,KanaName           
				  ,KensakuHyouziJun    
				  ,TokuisakiCD
				  ,AliasKBN
				  ,YuubinNO1           
				  ,YuubinNO2           
				  ,Juusho1             
				  ,Juusho2             
				  ,Tel11               
				  ,Tel12                
				  ,Tel13                
				  ,Tel21                
				  ,Tel22                
				  ,Tel23               
				  ,TantouBusho          
				  ,TantouYakushoku      
				  ,TantoushaName       
				  ,MailAddress 
				  ,StaffCD            
				  ,TorihikiKaisiDate    
				  ,TorihikiShuuryouDate 
				  ,Remarks              
				  ,UsedFlg              
				  ,InsertOperator
				 ,InsertDateTime
				  ,UpdateOperator,
				 UpdateDateTime) 

				 select KouritenCD
				  ,ChangeDate          
				  ,ShokutiFLG          
				  ,KouritenName       
				  ,KouritenRyakuName 
				  ,KanaName           
				  ,KensakuHyouziJun    
				  ,TokuisakiCD
				  ,AliasKBN
				  ,YuubinNO1           
				  ,YuubinNO2           
				  ,Juusho1             
				  ,Juusho2             
				  ,Tel11               
				  ,Tel12                
				  ,Tel13                
				  ,Tel21                
				  ,Tel22                
				  ,Tel23               
				  ,TantouBusho          
				  ,TantouYakushoku      
				  ,TantoushaName       
				  ,MailAddress 
				  ,StaffCD            
				  ,TorihikiKaisiDate    
				  ,TorihikiShuuryouDate 
				  ,Remarks              
				  ,UsedFlg              
				  ,InsertOperator
				  ,GETDATE()
				  ,UpdateOperator
				  ,GETDATE()
				 from #Temp 
				 --WHERE  NOT EXISTS (SELECT KouritenCD,ChangeDate From M_Kouriten WHERE KouritenCD = #Temp.KouritenCD and ChangeDate=#Temp.ChangeDate)
				 --and #Temp.Error='false'

			--update M_Kouriten
			--set         
			--				ShokutiFLG = t.ShokutiFLG,
			--				KouritenName = t.KouritenName,
			--				KouritenRyakuName = t.KouritenRyakuName,
			--				KanaName = t.KanaName,
			--				KensakuHyouziJun = t.KensakuHyouziJun, 
			--				TokuisakiCD = t.TokuisakiCD,
			--				AliasKBN = t.AliasKBN,
			--				YuubinNO1 = t.YuubinNO1, 
			--				YuubinNO2 = t.YuubinNO2, 
			--				Juusho1 = t.Juusho1, 
			--				Juusho2 = t.Juusho2,
			--				Tel11 = t.Tel11,
			--				Tel12 = t.Tel12,
			--				Tel13 = t.Tel13,
			--				Tel21 = t.Tel21,
			--				Tel22 = t.Tel22,
			--				Tel23 = t.Tel23,
			--				TantouBusho = t.TantouBusho, 
			--				TantouYakushoku = t.TantouYakushoku,
			--				TantoushaName = t.TantoushaName, 
			--				MailAddress = t.MailAddress, 
			--				StaffCD = t.StaffCD,
			--				TorihikiKaisiDate = t.TorihikiKaisiDate,
			--				TorihikiShuuryouDate = t.TorihikiShuuryouDate,
			--				Remarks = t.Remarks,
			--				UpdateOperator = t.UpdateOperator,
			--				UpdateDateTime = @currentDate
			--	from M_Kouriten ms inner join #Temp t on ms.KouritenCD=t.KouritenCD and ms.ChangeDate=t.ChangeDate
			--	where EXISTS (SELECT KouritenCD,ChangeDate From M_Kouriten WHERE KouritenCD = t.KouritenCD and ChangeDate=t.ChangeDate)	and t.Error='false'		
		 end
		else if @condition= 'delete'
		 begin
		   delete ms from M_Kouriten ms inner join #Temp t on ms.KouritenCD= t.KouritenCD and ms.ChangeDate=t.ChangeDate
		   --where EXISTS (SELECT KouritenCD,ChangeDate From M_Kouriten WHERE KouritenCD = t.KouritenCD and ChangeDate = t.ChangeDate ) and t.Error='false'		
		 end
		DROP TABLE #Temp

		select '1' as Result
		end
	
END


