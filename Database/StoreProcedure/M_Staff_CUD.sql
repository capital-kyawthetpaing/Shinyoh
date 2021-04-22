 BEGIN TRY 
 Drop Procedure dbo.[M_Staff_CUD]
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
CREATE PROCEDURE [dbo].[M_Staff_CUD]
	-- Add the parameters for the stored procedure here
	@StaffCD				varchar(10),
    @ChangeDate				varchar(10),
    @StaffName				varchar(40),
    @KanaName				varchar(40),
    @KensakuHyouziJun       int,
	@MenuCD					varchar(4),
	@AuthorizationsCD       varchar(4),
	@PositionCD             varchar(3),
	@JoinDate               date,
	@LeaveDate              date,
	@Passward               varchar(10),
	@Remarks                varchar(80),
	--@UsedFlg			    tinyint = 0,
	@InsertOperator         varchar(10),	
	@UpdateOperator         varchar(10),	
	@Mode				    varchar(10),
	@Program			    varchar(100),
    @PC					    varchar(30),
    @KeyItem			    varchar(100)
	--@YuubinNO1				varchar(3),
	--@YuubinNO2				varchar(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

			declare @currentDate as datetime = getdate()

			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

			if @Mode='New'
				begin
				    INSERT INTO M_Staff
			        ([StaffCD]
			        ,[ChangeDate]
			        ,[StaffName]
			        ,[KanaName]
			        ,[KensakuHyouziJun]
					   --,[YuubinNO1]
					   --,[YuubinNO2]
			        ,[MenuCD]
			        ,[AuthorizationsCD]
					,[PositionCD]
					,[JoinDate]
					,[LeaveDate]
					,[Passward]
					,[Remarks]
					,[UsedFlg]
					,[InsertOperator]
					,[InsertDateTime]
					,[UpdateOperator]
					,[UpdateDateTime])
			  VALUES
			        (@StaffCD
			        ,@ChangeDate
			        ,@StaffName
			        ,@KanaName
			        ,@KensakuHyouziJun
					   --,@YuubinNO1
					   --,@YuubinNO2
			        ,@MenuCD
			        ,@AuthorizationsCD 
					   ,@PositionCD 
					   ,@JoinDate 
					   ,@LeaveDate 
					   ,@Passward 
					   ,@Remarks
					   ,0
					   ,@InsertOperator
					   ,@currentDate 
					   ,@UpdateOperator
					   ,@currentDate);
				end
				else if @Mode = 'Update'
					begin
						update
							M_Staff
						set         
									StaffName = @StaffName,
									KanaName = @KanaName,
									KensakuHyouziJun = @KensakuHyouziJun,
									--YuubinNO1 = @YuubinNO1,
									--YuubinNO2 = @YuubinNO2,
									MenuCD = @MenuCD,
									AuthorizationsCD = @AuthorizationsCD, 
									PositionCD = @PositionCD,
									JoinDate = @JoinDate, 
									LeaveDate = @LeaveDate, 
									Passward = @Passward, 
									Remarks = @Remarks,
									UpdateOperator = @UpdateOperator,
									UpdateDateTime = @currentDate
						where  
						      StaffCD = @StaffCD and ChangeDate = @ChangeDate
				end
				else if @Mode = 'Delete'
				 begin
				       delete from M_Staff where StaffCD = @StaffCD and ChangeDate = @ChangeDate
				 end	
END

GO




