 BEGIN TRY 
 Drop Procedure dbo.[M_Siiresaki_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-10-21
-- Description:	Insert M_Staff Table
-- =============================================
CREATE PROCEDURE [dbo].[M_Siiresaki_CUD]
	-- Add the parameters for the stored procedure here
	@SiiresakiCD				varchar(13),
    @ChangeDate				date,
    @ShokutiFLG				tinyint,
    @SiiresakiName				varchar(80),
    @SiiresakiRyakuName       varchar(40),
	@KanaName					varchar(80),
	@KensakuHyouziJun       int,
	@SiharaisakiCD             varchar(13),
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
	@TuukaCD         varchar(3),	
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

	declare @currentDate as datetime = getdate()

	exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

   if @Mode='New'
	begin
	    INSERT INTO M_Siiresaki
           ([SiiresakiCD]
			  ,[ChangeDate]           
			  ,[ShokutiFLG]          
			  ,[SiiresakiName]       
			  ,[SiiresakiRyakuName]  
			  ,[KanaName]           
			  ,[KensakuHyouziJun]    
			  ,[SiharaisakiCD]        
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
			  ,[TuukaCD]             
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
           (@SiiresakiCD
		   , @ChangeDate
			,@ShokutiFLG
			,@SiiresakiName	
			,@SiiresakiRyakuName  
			,@KanaName		
			,@KensakuHyouziJun     
			,@SiharaisakiCD        
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
			,@TuukaCD         	
			,@StaffCD        
			,@TorihikiKaisiDate				   
			,@TorihikiShuuryouDate			    
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
				M_Siiresaki
			set         
						ShokutiFLG = @ShokutiFLG,
						SiiresakiName = @SiiresakiName,
						SiiresakiRyakuName = @SiiresakiRyakuName,
						KanaName = @KanaName,
						KensakuHyouziJun = @KensakuHyouziJun, 
						SiharaisakiCD = @SiharaisakiCD,
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
						TuukaCD = @TuukaCD, 
						StaffCD = @StaffCD,
						TorihikiKaisiDate = @TorihikiKaisiDate,
						TorihikiShuuryouDate = @TorihikiShuuryouDate,
						Remarks = @Remarks,
						UpdateOperator = @UpdateOperator,
						UpdateDateTime = @currentDate
			where  
			      SiiresakiCD = @SiiresakiCD and ChangeDate = @ChangeDate
	end
	else if @Mode = 'Delete'
	 begin
	       delete from M_Siiresaki where SiiresakiCD = @SiiresakiCD and ChangeDate = @ChangeDate
	 end

END



