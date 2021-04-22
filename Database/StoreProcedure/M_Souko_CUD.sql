 BEGIN TRY 
 Drop Procedure dbo.[M_Souko_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020-10-19
-- Description:	Insert M_Souko
-- =============================================
CREATE PROCEDURE [dbo].[M_Souko_CUD]
	-- Add the parameters for the stored procedure here
	@SoukoCD              varchar(10),
    @SoukoName            varchar(50),
    @KanaName             varchar(50),
    @KensakuHyouziJun     int,
    @YuubinNO1            varchar(3),
	@YuubinNO2            varchar(4),
	@Juusho1              varchar(80),
	@Juusho2              varchar(80),
	@Tel11                varchar(6),
	@Tel12                varchar(5),
	@Tel13                varchar(5),
	@Tel21                varchar(6),
	@Tel22                varchar(5),
	@Tel23                varchar(5),
	@Remarks              varchar(80),
	@UsedFlg              tinyint,
	@InsertOperator       varchar(10),
	@UpdateOperator       varchar(10),
	@Mode                 varchar(10),
	@Program              varchar(100),
	@PC                   varchar(30),
	@KeyItem              varchar(100)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

			declare @currentDate as datetime = getdate()
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

			if @Mode='New'
			begin
			    INSERT INTO M_Souko
			       ([SoukoCD]
			       ,[SoukoName]
			       ,[KanaName]
			       ,[KensakuHyouziJun]
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
				   ,[Remarks]
				   ,[UsedFlg]
				   ,[InsertOperator]
				   ,[InsertDateTime]
				   ,[UpdateOperator]
				   ,[UpdateDateTime])
			 VALUES
			       (@SoukoCD
			       ,@SoukoName
			       ,@KanaName
			       ,@KensakuHyouziJun
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
						M_Souko
					set         
								SoukoName=@SoukoName,
								KanaName=@KanaName,
								KensakuHyouziJun=@KensakuHyouziJun,
								YuubinNO1=@YuubinNO1,
								YuubinNO2=@YuubinNO2,
								Juusho1=@Juusho1,
								Juusho2=@Juusho2,
								Tel11=@Tel11,
								Tel12=@Tel12,
								Tel13=@Tel13,
								Tel21=@Tel21,
								Tel22=@Tel22,
								Tel23=@Tel23,
								Remarks=@Remarks,
								UpdateOperator=@UpdateOperator,
								UpdateDateTime=@currentDate
					where  
					      SoukoCD = @SoukoCD
				end
			 else if @Mode = 'Delete'
			 begin
			       delete from M_Souko where SoukoCD=@SoukoCD
			 end
END

