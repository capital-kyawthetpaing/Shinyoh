 BEGIN TRY 
 Drop Procedure dbo.[Fnc_GetDenpyouNO]
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
CREATE PROCEDURE [dbo].[Fnc_GetDenpyouNO] 
	-- Add the parameters for the stored procedure here
	@SerialNO as int,
	@refDate as date,
	@SEQNO as int
	--@return varchar(20) OUTPUT
AS
BEGIN
	
   
	declare @Prefix1 as varchar(4)  --＠接頭値1
	declare @Prefix2 as varchar(4) --＠接頭値2
	declare @Counter as int --＠カウンタ桁数
	--declare @outNo as varchar(100)

	set @Prefix1 = (select Settouti from M_DenpyouNO where RenbanKBN = @SerialNO and SEQNO=@SEQNO)
	set @Prefix2 = (select CASE WHEN SeqUnit = 1 THEN '' WHEN SeqUnit = 2 THEN CONVERT(varchar(10), FORMAT(Cast(@refDate as Date), 'yyyy'))  ElSE CONVERT(varchar(10), FORMAT(Cast(@refDate as Date), 'yyMM')) END as SeqUni from M_Control where MainKey=1)

	

	if NOT exists(select * from M_DenpyouNO where RenbanKBN=@SerialNO and SEQNO=@SEQNO)
		 begin
			---- not exists
			INSERT INTO M_DenpyouNO(RenbanKBN,SEQNO,Settouti,[Counter],InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
			values(@SerialNO,@SEQNO,@Prefix1+@Prefix2,0,'Program',GetDate(),NULL,NULL)
	end
	
	
			
		Update M_DenpyouNO set [Counter]=[Counter]+1,UpdateOperator='Program', UpdateDateTime=GETDATE()
		where RenbanKBN=@SerialNO and SEQNO=@SEQNO
			
			
	
	declare @tempCounter as varchar(100)= (select [Counter] from M_DenpyouNO where RenbanKBN=@SerialNO and SEQNO=@SEQNO)

   --select  @return = LEFT(@Prefix1+@Prefix2+'000000000000'+@tempCounter,12);

    declare @outNO as varchar(100) = @Prefix1+@Prefix2+'000000000000'+@tempCounter
   select  LEFT(@outNO,8)+RIGHT(@outNO,4);
  Return 
END

