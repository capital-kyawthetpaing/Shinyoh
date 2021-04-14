 BEGIN TRY 
 Drop Procedure dbo.[M_Kouriten_CUD]
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
CREATE PROCEDURE [dbo].[M_Kouriten_CUD]
	@KouritenCD				varchar(10),
    @ChangeDate				date,
    @ShokutiFLG				tinyint,
    @KouritenName				varchar(80),
    @KouritenRyakuName       varchar(40),
	@KanaName					varchar(80),
	@KensakuHyouziJun       int,
	@TokuisakiCD             varchar(10),
	@AliasKBN         tinyint,	
	@YuubinNO1               varchar(3),
	@YuubinNO2              varchar(4),
	@Juusho1               varchar(80),
	@Juusho2                varchar(80),
	@Tel11			    varchar(6),
	@Tel12         varchar(5),	
	@Tel13         varchar(5),	
	@Tel21				     varchar(6),
	@Tel22			    varchar(5),
    @Tel23					    varchar(5),
    @TantouBusho			    varchar(40),
	@TantouYakushoku               varchar(40),
	@TantoushaName                varchar(40),
	@MailAddress			    varchar(100),
	@StaffCD         varchar(10),	
	@TorihikiKaisiDate				    date,
	@TorihikiShuuryouDate			    date,
    @Remarks					    varchar(80),
    @UsedFlg			    tinyint,
	@InsertOperator				    varchar(10),
	@UpdateOperator			    varchar(10),
    @Mode					    varchar(15),
    @Program			    varchar(40),
	@PC			    varchar(100),
	@KeyItem			    varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	begin try
		begin tran

			declare @currentDate as datetime = getdate()

			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

			if @Mode='New'
				begin
				    INSERT INTO M_Kouriten
			        ([KouritenCD]
						  ,[ChangeDate]           
						  ,[ShokutiFLG]          
						  ,[KouritenName]       
						  ,[KouritenRyakuName]  
						  ,[KanaName]           
						  ,[KensakuHyouziJun]    
						  ,[TokuisakiCD] 
						  ,[AliasKBN]
						  ,[YuubinNO1]            
						  ,[YuubinNO2]           
						  ,[Juusho1]             
						  ,[Juusho2]             
						  ,[Tel11]                
						  ,[Tel12]                
						  ,[Tel13]                
						  ,[Tel21]                
						  ,[Tel22]                
						  ,[Tel23]               
						  ,[TantouBusho]          
						  ,[TantouYakushoku]      
						  ,[TantoushaName]       
						  ,[MailAddress]  
						  ,[StaffCD]             
						  ,[TorihikiKaisiDate]    
						  ,[TorihikiShuuryouDate] 
						  ,[Remarks]              
						  ,[UsedFlg]              
						  ,[InsertOperator]       
						  ,[InsertDateTime]       
						  ,[UpdateOperator]      
						  ,[UpdateDateTime])
			  VALUES
			        (@KouritenCD
					   , @ChangeDate
						,@ShokutiFLG
						,@KouritenName
						,@KouritenRyakuName  
						,@KanaName		
						,@KensakuHyouziJun     
						,@TokuisakiCD 
						,@AliasKBN 
						,@YuubinNO1              
						,@YuubinNO2             
						,@Juusho1            
						,@Juusho2               
						,@Tel11			    
						,@Tel12         
						,@Tel13         
						,@Tel21				   
						,@Tel22			   
						,@Tel23					   
						,@TantouBusho			   
						,@TantouYakushoku               
						,@TantoushaName               
						,@MailAddress	
						,@StaffCD        
						,@TorihikiKaisiDate				   
						,@TorihikiShuuryouDate			    
						,@Remarks					   
						,@UsedFlg			   
						,@InsertOperator
						,@currentDate 
						,@UpdateOperator
						,@currentDate);
				end
				

				else if @Mode = 'Update'
					begin
						update
							M_Kouriten
						set         
									ShokutiFLG = @ShokutiFLG,
									KouritenName = @KouritenName,
									KouritenRyakuName = @KouritenRyakuName,
									KanaName = @KanaName,
									KensakuHyouziJun = @KensakuHyouziJun, 
									TokuisakiCD = @TokuisakiCD,
									AliasKBN = @AliasKBN,
									YuubinNO1 = @YuubinNO1, 
									YuubinNO2 = @YuubinNO2, 
									Juusho1 = @Juusho1, 
									Juusho2 = @Juusho2,
									Tel11 = @Tel11,
									Tel12 = @Tel12,
									Tel13 = @Tel13,
									Tel21 = @Tel21,
									Tel22 = @Tel22,
									Tel23 = @Tel23,
									TantouBusho =@TantouBusho, 
									TantouYakushoku = @TantouYakushoku,
									TantoushaName = @TantoushaName, 
									MailAddress = @MailAddress, 
									StaffCD = @StaffCD,
									TorihikiKaisiDate = @TorihikiKaisiDate,
									TorihikiShuuryouDate = @TorihikiShuuryouDate,
									Remarks = @Remarks,
									UpdateOperator = @UpdateOperator,
									UpdateDateTime = @currentDate
						where  
						      KouritenCD = @KouritenCD and ChangeDate = @ChangeDate
				end
				else if @Mode = 'Delete'
				 begin
				       delete from M_Kouriten where KouritenCD = @KouritenCD and ChangeDate = @ChangeDate
				 end

		commit tran
	end try
	begin catch
		rollback tran
		throw
	end catch

END

