BEGIN TRY 
 Drop Procedure dbo.[CSV_M_Siiresaki_CUD]
END try
BEGIN CATCH END CATCH 
/****** Object:  StoredProcedure [dbo].[CSV_M_Siiresaki_CUD]    Script Date: 04/13/21 12:28:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-11-16
-- Description:	Insert M_Siiresaki Table
-- =============================================
CREATE PROCEDURE [dbo].[CSV_M_Siiresaki_CUD]
	-- Add the parameters for the stored procedure here
		@xml as XML,
		@condition  varchar(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;		
					DECLARE  @hQuantityAdjust AS INT 
					declare @currentDate as datetime = getdate()

					CREATE TABLE #Temp
							(   
								SEQ						int IDENTITY(1,1),
								SiiresakiCD				VARCHAR(200),
								ChangeDate				VARCHAR(200),
								ShokutiFLG				VARCHAR(200),
								SiiresakiName			VARCHAR(200),
								SiiresakiRyakuName      VARCHAR(200), 
								KanaName				VARCHAR(200),
								KensakuHyouziJun        VARCHAR(200) default '0',
								SiharaisakiCD           VARCHAR(200),
								YuubinNO1               VARCHAR(200),
								YuubinNO2               VARCHAR(200),
								Juusho1					VARCHAR(200),
								Juusho2                 VARCHAR(200),
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
								TuukaCD					VARCHAR(200),	
								StaffCD					VARCHAR(200),	
								TorihikiKaisiDate		VARCHAR(200),
								TorihikiShuuryouDate	VARCHAR(200),
								Remarks					VARCHAR(200),
								UsedFlg					VARCHAR(200) default '0',
								InsertOperator			VARCHAR(200),
								UpdateOperator			VARCHAR(200),
								Error1					VARCHAR(100),
								Error2					VARCHAR(100),
								ErrorFlg				BIT default 'FALSE'
							)
					EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @xml

					
					INSERT INTO #Temp
					   (SiiresakiCD
						  ,ChangeDate          
						  ,ShokutiFLG          
						  ,SiiresakiName       
						  ,SiiresakiRyakuName 
						  ,KanaName           
						  ,KensakuHyouziJun    
						  ,SiharaisakiCD        
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
						  ,TuukaCD             
						  ,StaffCD            
						  ,TorihikiKaisiDate    
						  ,TorihikiShuuryouDate 
						  ,Remarks              
						  ,UsedFlg              
						  ,InsertOperator   
						  ,UpdateOperator)
						 
						   SELECT *
								FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
								WITH
								(
								SiiresakiCD				VARCHAR(200) 'SiiresakiCD',
								ChangeDate				VARCHAR(200) 'ChangeDate',
								ShokutiFLG				VARCHAR(200) 'ShokutiFLG',
								SiiresakiName			VARCHAR(200) 'SiiresakiName',
								SiiresakiRyakuName      VARCHAR(200) 'SiiresakiRyakuName', 
								KanaName				VARCHAR(200) 'KanaName',
								KensakuHyouziJun        VARCHAR(200) 'KensakuHyouziJun',
								SiharaisakiCD           VARCHAR(200) 'SiharaisakiCD',
								YuubinNO1               VARCHAR(200) 'YuubinNO1',
								YuubinNO2               VARCHAR(200) 'YuubinNO2',
								Juusho1                 VARCHAR(200) 'Juusho1',
								Juusho2                 VARCHAR(200) 'Juusho2',
								Tel11			        VARCHAR(200) 'Tel11',
								Tel12					VARCHAR(200) 'Tel12',	
								Tel13					VARCHAR(200) 'Tel13',	
								Tel21				    VARCHAR(200) 'Tel21',
								Tel22					VARCHAR(200) 'Tel22',
								Tel23					VARCHAR(200) 'Tel23',
								TantouBusho			    VARCHAR(200) 'TantouBusho',
								TantouYakushoku         VARCHAR(200) 'TantouYakushoku',
								TantoushaName           VARCHAR(200) 'TantoushaName',
								MailAddress			    VARCHAR(200) 'MailAddress',
								TuukaCD					VARCHAR(200) 'TuukaCD',	
								StaffCD					VARCHAR(200) 'StaffCD',	
								TorihikiKaisiDate		VARCHAR(200) 'TorihikiKaisiDate',
								TorihikiShuuryouDate	VARCHAR(200) 'TorihikiShuuryouDate',
								Remarks					VARCHAR(200) 'Remarks',
								UsedFlg					VARCHAR(200) 'UsedFlg',
								InsertOperator			VARCHAR(200) 'InsertOperator',
								UpdateOperator			VARCHAR(200) 'UpdateOperator'
								)
					EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

					if @condition = 'create_update'
					begin
					INSERT INTO M_Siiresaki
								(SiiresakiCD
								,ChangeDate          
								,ShokutiFLG          
								,SiiresakiName       
								,SiiresakiRyakuName 
								,KanaName           
								,KensakuHyouziJun    
								,SiharaisakiCD        
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
								,TuukaCD             
								,StaffCD            
								,TorihikiKaisiDate    
								,TorihikiShuuryouDate 
								,Remarks              
								,UsedFlg              
								,InsertOperator
								,InsertDateTime
								,UpdateOperator,
								UpdateDateTime) 

							 select SiiresakiCD
										  ,ChangeDate          
										  ,ShokutiFLG          
										  ,SiiresakiName       
										  ,SiiresakiRyakuName 
										  ,KanaName           
										  ,ISNULL(KensakuHyouziJun, 0)
										  ,SiharaisakiCD        
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
										  ,TuukaCD             
										  ,StaffCD            
										  ,TorihikiKaisiDate    
										  ,TorihikiShuuryouDate 
										  ,Remarks              
										  ,UsedFlg              
										  ,InsertOperator
										  ,@currentDate
										  ,UpdateOperator
										  ,@currentDate
										 from #Temp 
										 WHERE  NOT EXISTS (SELECT SiiresakiCD,ChangeDate From M_Siiresaki WHERE SiiresakiCD = #Temp.SiiresakiCD and ChangeDate=#Temp.ChangeDate)	

									--update M_Siiresaki
									--set         
									--	ShokutiFLG = t.ShokutiFLG,
									--	SiiresakiName = t.SiiresakiName,
									--	SiiresakiRyakuName = t.SiiresakiRyakuName,
									--	KanaName = t.KanaName,
									--	KensakuHyouziJun = t.KensakuHyouziJun, 
									--	SiharaisakiCD = t.SiharaisakiCD,
									--	YuubinNO1 = t.YuubinNO1, 
									--	YuubinNO2 = t.YuubinNO2, 
									--	Juusho1 = t.Juusho1, 
									--	Juusho2 = t.Juusho2,
									--	Tel11 = t.Tel11,
									--	Tel12 = t.Tel12,
									--	Tel13 = t.Tel13,
									--	Tel21 = t.Tel21,
									--	Tel22 = t.Tel22,
									--	Tel23 = t.Tel23,
									--	TantouBusho = t.TantouBusho, 
									--	TantouYakushoku = t.TantouYakushoku,
									--	TantoushaName = t.TantoushaName, 
									--	MailAddress = t.MailAddress, 
									--	TuukaCD = t.TuukaCD, 
									--	StaffCD = t.StaffCD,
									--	TorihikiKaisiDate = t.TorihikiKaisiDate,
									--	TorihikiShuuryouDate = t.TorihikiShuuryouDate,
									--	Remarks = t.Remarks,
									--	UpdateOperator = t.UpdateOperator,
									--	UpdateDateTime = @currentDate
									--from M_Siiresaki ms inner join #Temp t on ms.SiiresakiCD=t.SiiresakiCD and ms.ChangeDate=t.ChangeDate
								
					select '1' as Result
						DROP TABLE #Temp
					END
		
					ELSE IF @condition= 'delete'
					BEGIN
						DELETE ms from M_Siiresaki ms inner join #Temp t on ms.SiiresakiCD= t.SiiresakiCD and ms.ChangeDate=t.ChangeDate	
					
							select '1' as Result
						drop table #Temp
					END	
					
					ELSE
					BEGIN
					


				--Null check
					update #Temp
					set ErrorFlg = 1,
						Error1 = case when isnull(ltrim(rtrim(SiiresakiCD)),'') = '' then '仕入先CD未入力エラー'
									when isnull(ltrim(rtrim(ChangeDate)),'') = '' then '改定日未入力エラー' 
									when isnull(ltrim(rtrim(ShokutiFLG)),'') = '' then '諸口未入力エラー' 
									when isnull(ltrim(rtrim(SiiresakiName)),'') = '' then '仕入先名未入力エラー' 
									when isnull(ltrim(rtrim(SiiresakiRyakuName)),'') = '' then '略名未入力エラー' 
									when isnull(ltrim(rtrim(SiharaisakiCD)),'') = '' then '支払先CD未入力エラー' 
									when isnull(ltrim(rtrim(StaffCD)),'') = '' then '担当スタッフCD未入力エラー' 
									when isnull(ltrim(rtrim(TuukaCD)),'') = '' then '通貨CD未入力エラー' 
									end
					where isnull(ltrim(rtrim(SiiresakiCD)),'') = ''
					or isnull(ltrim(rtrim(ChangeDate)),'') = ''
					or isnull(ltrim(rtrim(ShokutiFLG)),'') = ''
					or isnull(ltrim(rtrim(SiiresakiName)),'') = ''
					or isnull(ltrim(rtrim(SiiresakiRyakuName)),'') = ''
					or isnull(ltrim(rtrim(SiharaisakiCD)),'') = ''
					or isnull(ltrim(rtrim(StaffCD)),'') = ''
					or isnull(ltrim(rtrim(TuukaCD)),'') = ''

					if exists (select 1 from #Temp where ErrorFlg  = 1)
					begin
						goto error
					end

					--Length Check
					update #Temp
					set ErrorFlg = 1,
						Error1 = case when datalength(SiiresakiCD) > 10			then '仕入先CD桁数エラー'
									when datalength(SiiresakiName) > 80			then '仕入先名桁数エラー'
									when datalength(SiiresakiRyakuName) > 40	then '略名桁数エラー'
									when datalength(KanaName) > 80				then 'カナ名桁数エラー'
									when datalength(SiharaisakiCD) > 10			then '支払先CD桁数エラー'
									when datalength(YuubinNO1) > 3				then '郵便番号１桁数エラー'
									when datalength(YuubinNO2) > 4				then '郵便番号２桁数エラー'
									when datalength(Juusho1) > 80				then '住所１桁数エラー'
									when datalength(Juusho2) > 80				then '住所２桁数エラー'
									when datalength(Tel11) > 6					then '電話番号①-1桁数エラー'
									when datalength(Tel12) > 5					then '電話番号①-2桁数エラー'
									when datalength(Tel13) > 5					then '電話番号①-3桁数エラー'
									when datalength(Tel21) > 6					then '電話番号②-1桁数エラー'
									when datalength(Tel22) > 5					then '電話番号②-2桁数エラー'
									when datalength(Tel23) > 5					then '電話番号②-3桁数エラー'
									when datalength(TantouBusho) > 40			then '担当部署桁数エラー'
									when datalength(TantouYakushoku) > 40		then '担当役職桁数エラー'
									when datalength(TantoushaName) > 40			then '担当者名桁数エラー'
									when datalength(MailAddress) > 100			then 'メールアドレス桁数エラー'
									when datalength(TuukaCD) > 3				then '通貨CD桁数エラー'
									when datalength(StaffCD) > 10				then '担当スタッフCD桁数エラー'
									when datalength(Remarks) > 80				then '備考桁数エラー'
								end
					from #Temp
					where datalength(SiharaisakiCD) > 10
					or datalength(SiiresakiName) > 80		
					or datalength(SiiresakiRyakuName) > 40
					or datalength(KanaName) > 80			
					or datalength(SiharaisakiCD) > 10		
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
					or datalength(TuukaCD) > 3			
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
						Error2 = case when (ShokutiFLG !=0 and ShokutiFLG !=1) then '項目:諸口区分(0～1)'
									when isdate(ChangeDate) = 0 then '項目:改定日'
									when isdate(isnull(nullif(ltrim(rtrim(TorihikiKaisiDate)),''),'2100-01-01')) = 0 then '項目:取引開始日'
									when isdate(isnull(nullif(ltrim(rtrim(TorihikiShuuryouDate)),''),'2100-01-01')) = 0 then '項目:取引終了日'
									end 
					where (ShokutiFLG !=0 and ShokutiFLG !=1)
					or isdate(ChangeDate) = 0
					or isdate(isnull(nullif(ltrim(rtrim(TorihikiKaisiDate)),''),'2100-01-01')) = 0 -- allow null, allow '' blank
					or isdate(isnull(nullif(ltrim(rtrim(TorihikiShuuryouDate)),''),'2100-01-01')) = 0

					if exists (select 1 from #Temp where ErrorFlg  = 1)
						begin
							goto error
						end

					--Master Check
					update #Temp
					set ErrorFlg = 1,
						Error1 = '担当スタッフCD未登録エラー'
					from #Temp tmp
					left join F_Staff(getdate()) fs on tmp.StaffCD = fs.StaffCD
					where fs.StaffCD is null

					if exists (select 1 from #Temp where ErrorFlg  = 1)
						begin
							goto error
						end

					if @condition = 'create_Err_Check'
					begin
						--Already exists item(not sure this check require. if we make this check, we can't update shouhin.)
						update #Temp
						set ErrorFlg = 1,
							Error1 = '仕入先CD登録済エラー'
						from #Temp tmp
						inner join M_Siiresaki ms on ms.SiiresakiCD = tmp.SiiresakiCD and ms.ChangeDate = tmp.ChangeDate
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
					BEGIN
						select '1' as Result
						drop table #Temp
					END
				END

			END



