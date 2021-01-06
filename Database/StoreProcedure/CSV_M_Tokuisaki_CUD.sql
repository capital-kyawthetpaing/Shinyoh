 BEGIN TRY 
 Drop Procedure dbo.[CSV_M_Tokuisaki_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020-11-16
-- Description:	Insert M_Tokuisaki Table
-- =============================================
CREATE PROCEDURE [dbo].[CSV_M_Tokuisaki_CUD]
	-- Add the parameters for the stored procedure here
	@xml as XML,
	@condition  varchar(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE  @hQuantityAdjust	AS INT 
	declare  @currentDate as datetime = getdate()

	begin

		CREATE TABLE #Temp
				(   
					TokuisakiCD					varchar(10) COLLATE DATABASE_DEFAULT,
					ChangeDate					date,
					ShokutiFLG					tinyint,
					TokuisakiName				varchar(80) COLLATE DATABASE_DEFAULT,
					TokuisakiRyakuName			varchar(40) COLLATE DATABASE_DEFAULT, 
					KanaName					varchar(80) COLLATE DATABASE_DEFAULT,
					KensakuHyouziJun			int DEFAULT 0,
					SeikyuusakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
					AliasKBN					tinyint,
					YuubinNO1					varchar(3) COLLATE DATABASE_DEFAULT,
					YuubinNO2					varchar(4) COLLATE DATABASE_DEFAULT,
					Juusho1						varchar(80) COLLATE DATABASE_DEFAULT,
					Juusho2						varchar(80) COLLATE DATABASE_DEFAULT,
					Tel11						varchar(5) COLLATE DATABASE_DEFAULT,
					Tel12						varchar(4) COLLATE DATABASE_DEFAULT,	
					Tel13						varchar(4) COLLATE DATABASE_DEFAULT,	
					Tel21						varchar(5) COLLATE DATABASE_DEFAULT,
					Tel22						varchar(4) COLLATE DATABASE_DEFAULT,
					Tel23					    varchar(4) COLLATE DATABASE_DEFAULT,
					TantouBusho					varchar(40) COLLATE DATABASE_DEFAULT,
					TantouYakushoku             varchar(40) COLLATE DATABASE_DEFAULT,
					TantoushaName               varchar(40) COLLATE DATABASE_DEFAULT,
					MailAddress					varchar(100) COLLATE DATABASE_DEFAULT,
					StaffCD						varchar(10) COLLATE DATABASE_DEFAULT,	
					TorihikiKaisiDate			date ,
					TorihikiShuuryouDate		date ,
					ShukkaSizishoHuyouKBN		tinyint,
					Remarks					    varchar(80) COLLATE DATABASE_DEFAULT,
					UsedFlg						tinyint DEFAULT 0,
					InsertOperator				varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator			    varchar(10) COLLATE DATABASE_DEFAULT,
					Error						varchar(10)
				)
	   EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @xml

	    INSERT INTO #Temp
           (TokuisakiCD
			  ,ChangeDate          
			  ,ShokutiFLG          
			  ,TokuisakiName       
			  ,TokuisakiRyakuName 
			  ,KanaName           
			  ,KensakuHyouziJun    
			  ,SeikyuusakiCD 
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
			  ,ShukkaSizishoHuyouKBN
			  ,Remarks              
			  ,UsedFlg              
			  ,InsertOperator   
			  ,UpdateOperator
			  ,Error)
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					TokuisakiCD					varchar(10) 'TokuisakiCD',
					ChangeDate					date 'ChangeDate',
					ShokutiFLG					tinyint 'ShokutiFLG',
					TokuisakiName				varchar(80) 'TokuisakiName',
					TokuisakiRyakuName			varchar(40) 'TokuisakiRyakuName', 
					KanaName					varchar(80) 'KanaName',
					KensakuHyouziJun			int 'KensakuHyouziJun',
					SeikyuusakiCD				varchar(13) 'SeikyuusakiCD',
					AliasKBN					tinyint 'AliasKBN',
					YuubinNO1					varchar(3) 'YuubinNO1',
					YuubinNO2					varchar(4) 'YuubinNO2',
					Juusho1						varchar(80) 'Juusho1',
					Juusho2						varchar(80) 'Juusho2',
					Tel11						varchar(5) 'Tel11',
					Tel12						varchar(4) 'Tel12',	
					Tel13						varchar(4) 'Tel13',	
					Tel21						varchar(5) 'Tel21',
					Tel22						varchar(4) 'Tel22',
					Tel23					    varchar(4) 'Tel23',
					TantouBusho					varchar(40) 'TantouBusho',
					TantouYakushoku             varchar(40) 'TantouYakushoku',
					TantoushaName               varchar(40) 'TantoushaName',
					MailAddress					varchar(100) 'MailAddress',
					StaffCD						varchar(10) 'StaffCD',	
					TorihikiKaisiDate			date 'TorihikiKaisiDate',
					TorihikiShuuryouDate	    date 'TorihikiShuuryouDate',
					ShukkaSizishoHuyouKBN		tinyint 'ShukkaSizishoHuyouKBN',
					Remarks					    varchar(80) 'Remarks',
					UsedFlg						tinyint 'UsedFlg',
					InsertOperator				varchar(10) 'InsertOperator',
					UpdateOperator			    varchar(10) 'UpdateOperator',
					Error						varchar(10) 'Error'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp
		if @condition = 'create_update'
			begin
				INSERT INTO M_Tokuisaki
           (TokuisakiCD
			  ,ChangeDate          
			  ,ShokutiFLG          
			  ,TokuisakiName       
			  ,TokuisakiRyakuName 
			  ,KanaName           
			  ,KensakuHyouziJun    
			  ,SeikyuusakiCD 
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
			  ,ShukkaSizishoHuyouKBN
			  ,Remarks              
			  ,UsedFlg              
			  ,InsertOperator
			  ,InsertDateTime
			  ,UpdateOperator,
			   UpdateDateTime) 

			 select TokuisakiCD
			  ,ChangeDate          
			  ,ShokutiFLG          
			  ,TokuisakiName       
			  ,TokuisakiRyakuName 
			  ,KanaName           
			  ,KensakuHyouziJun    
			  ,SeikyuusakiCD  
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
			  ,ShukkaSizishoHuyouKBN
			  ,Remarks              
			  ,UsedFlg              
			  ,InsertOperator
			  ,@currentDate
			  ,UpdateOperator
			  ,@currentDate
			 from #Temp 
			 WHERE  NOT EXISTS (SELECT TokuisakiCD,ChangeDate From M_Tokuisaki WHERE TokuisakiCD = #Temp.TokuisakiCD and ChangeDate=#Temp.ChangeDate)
			 and #Temp.Error='false'

			update M_Tokuisaki
		set         
						ShokutiFLG = t.ShokutiFLG,
						TokuisakiName = t.TokuisakiName,
						TokuisakiRyakuName = t.TokuisakiRyakuName,
						KanaName = t.KanaName,
						KensakuHyouziJun = t.KensakuHyouziJun, 
						SeikyuusakiCD = t.SeikyuusakiCD,
						AliasKBN=t.AliasKBN,
						YuubinNO1 = t.YuubinNO1, 
						YuubinNO2 = t.YuubinNO2, 
						Juusho1 = t.Juusho1, 
						Juusho2 = t.Juusho2,
						Tel11 = t.Tel11,
						Tel12 = t.Tel12,
						Tel13 = t.Tel13,
						Tel21 = t.Tel21,
						Tel22 = t.Tel22,
						Tel23 = t.Tel23,
						TantouBusho = t.TantouBusho, 
						TantouYakushoku = t.TantouYakushoku,
						TantoushaName = t.TantoushaName, 
						MailAddress = t.MailAddress, 
						StaffCD = t.StaffCD,
						TorihikiKaisiDate = t.TorihikiKaisiDate,
						TorihikiShuuryouDate = t.TorihikiShuuryouDate,
						ShukkaSizishoHuyouKBN=t.ShukkaSizishoHuyouKBN,
						Remarks = t.Remarks,
						UpdateOperator = t.UpdateOperator,
						UpdateDateTime = @currentDate
			from M_Tokuisaki ms inner join #Temp t on ms.TokuisakiCD=t.TokuisakiCD and ms.ChangeDate=t.ChangeDate
			where EXISTS (SELECT TokuisakiCD,ChangeDate From M_Tokuisaki WHERE TokuisakiCD = t.TokuisakiCD and ChangeDate=t.ChangeDate)	and t.Error='false'			
			end

		else if @condition= 'delete'
		 begin
		   delete mt from M_Tokuisaki mt inner join #Temp t on mt.TokuisakiCD= t.TokuisakiCD and mt.ChangeDate=t.ChangeDate
		   where EXISTS (SELECT TokuisakiCD,ChangeDate From M_Tokuisaki WHERE TokuisakiCD = t.TokuisakiCD and ChangeDate = t.ChangeDate ) and t.Error='false'		
		 end
		DROP TABLE #Temp
	end
END



