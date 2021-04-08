 BEGIN TRY 
 Drop Procedure dbo.[M_Tokuisaki_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		HninEi Thu
-- Create date: 2020-11-09
-- Description:	Insert M_Tokuisaki Table
-- =============================================
CREATE PROCEDURE [dbo].[M_Tokuisaki_CUD]
	-- Add the parameters for the stored procedure here
	@TokuisakiCD				varchar(10),
    @ChangeDate				    date,
    @ShokutiFLG				    tinyint,
    @TokuisakiName				varchar(80),
    @TokuisakiRyakuName         varchar(40),
	@KanaName					varchar(80),
	@KensakuHyouziJun           int,
	@SeikyuusakiCD              varchar(10),
	@AliasKBN					tinyint,
	@YuubinNO1                  varchar(3),
	@YuubinNO2				    varchar(4),
	@Juusho1                    varchar(80),
	@Juusho2                    varchar(80),
	@Tel11			            varchar(6),
	@Tel12                      varchar(5),	
	@Tel13						varchar(5),	
	@Tel21						varchar(6),
	@Tel22						varchar(5),
    @Tel23					    varchar(5),
    @TantouBusho			    varchar(40),
	@TantouYakushoku            varchar(40),
	@TantoushaName              varchar(40),
	@MailAddress			    varchar(100),
	@StaffCD					varchar(10),	
	@TorihikiKaisiDate			date,
	@TorihikiShuuryouDate		date,
	@ShukkaSizishoHuyouKBN		tinyint,
    @Remarks					varchar(80),
    @UsedFlg					tinyint,
	@InsertOperator				varchar(10),
	@UpdateOperator			    varchar(10),
    @Mode					    varchar(15),
    @Program					varchar(40),
	@PC							varchar(100),
	@KeyItem					varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @currentDate as datetime = getdate()

	exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

   if @Mode='New'
	begin
	    INSERT INTO M_Tokuisaki
           ([TokuisakiCD]
			  ,[ChangeDate]           
			  ,[ShokutiFLG]          
			  ,[TokuisakiName]       
			  ,[TokuisakiRyakuName]  
			  ,[KanaName]           
			  ,[KensakuHyouziJun]    
			  ,[SeikyuusakiCD]
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
			  ,[ShukkaSizishoHuyouKBN]
			  ,[Remarks]              
			  ,[UsedFlg]              
			  ,[InsertOperator]       
			  ,[InsertDateTime]       
			  ,[UpdateOperator]      
			  ,[UpdateDateTime])
     VALUES
           (@TokuisakiCD
		   , @ChangeDate
			,@ShokutiFLG
			,@TokuisakiName	
			,@TokuisakiRyakuName  
			,@KanaName		
			,@KensakuHyouziJun     
			,@SeikyuusakiCD
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
			,@ShukkaSizishoHuyouKBN
			,@Remarks					   
			,@UsedFlg			   
			,@InsertOperator
			,@currentDate 
			,@UpdateOperator
			,@currentDate );
	end
		else if @Mode = 'Update'
		begin
			update
				M_Tokuisaki
			set         
						ShokutiFLG = @ShokutiFLG,
						TokuisakiName = @TokuisakiName,
						TokuisakiRyakuName = @TokuisakiRyakuName,
						KanaName = @KanaName,
						KensakuHyouziJun = @KensakuHyouziJun, 
						SeikyuusakiCD = @SeikyuusakiCD,
						AliasKBN=@AliasKBN,
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
						ShukkaSizishoHuyouKBN=@ShukkaSizishoHuyouKBN,
						Remarks = @Remarks,
						UpdateOperator = @UpdateOperator,
						UpdateDateTime = @currentDate
			where  
			      TokuisakiCD = @TokuisakiCD and ChangeDate = @ChangeDate
	end
	else if @Mode = 'Delete'
	 begin
	       delete from M_Tokuisaki where TokuisakiCD = @TokuisakiCD and ChangeDate = @ChangeDate
	 end

END



