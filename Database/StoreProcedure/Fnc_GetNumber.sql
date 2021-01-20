 BEGIN TRY 
 Drop Procedure [dbo].[Fnc_GetNumber] 
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Swe Swe
-- Create date: <19-01-2021>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[Fnc_GetNumber] 
	-- Add the parameters for the stored procedure here
		@SerialNO as int,
	@refDate as date,
	@SEQNO as int,
	@Output as varchar(100) OUTPUT
AS
BEGIN
	
   
	declare @Prefix1 as varchar(4)
	declare @Prefix2 as varchar(4) 
	declare @Counter as int

	set @Prefix1 = (select Settouti from M_DenpyouNO where RenbanKBN = @SerialNO and SEQNO=@SEQNO)
	set @Prefix2 = (select CASE WHEN SeqUnit = 1 THEN '' WHEN SeqUnit = 2 THEN CONVERT(varchar(10), FORMAT(Cast(@refDate as Date), 'yyyy'))  ElSE CONVERT(varchar(10), FORMAT(Cast(@refDate as Date), 'yyMM')) END as SeqUni from M_Control where MainKey=1)

	

	if NOT exists(select * from M_DenpyouNO where RenbanKBN=@SerialNO and SEQNO=@SEQNO)
		 begin
			---- not exists
			INSERT INTO M_DenpyouNO(RenbanKBN,SEQNO,Settouti,[Counter],InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
			values(@SerialNO,@SEQNO,ISNULL(@Prefix1,'')+ISNULL(@Prefix2,''),0,'Program',GetDate(),NULL,NULL)
		 end

	Update M_DenpyouNO set [Counter]=[Counter]+1,UpdateOperator='Program', UpdateDateTime=GETDATE()
	where RenbanKBN=@SerialNO and SEQNO=@SEQNO

	declare @tempCounter as varchar(100)= (select [Counter] from M_DenpyouNO where RenbanKBN=@SerialNO and SEQNO=@SEQNO)
	declare @outNO as varchar(100) =ISNULL(@Prefix1,'')+ISNULL(@Prefix2,'')+'000000000000'+@tempCounter   
	set  @Output= LEFT(@outNO,8)+RIGHT(@outNO,4);

END