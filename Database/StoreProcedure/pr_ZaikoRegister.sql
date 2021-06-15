/****** Object:  StoredProcedure [dbo].[pr_ZaikoRegister]    Script Date: 2021/05/28 18:38:50 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%pr_ZaikoRegister%' and type like '%P%')
DROP PROCEDURE [dbo].[pr_ZaikoRegister]
GO

/****** Object:  StoredProcedure [dbo].[pr_ZaikoRegister]    Script Date: 2021/05/28 18:38:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Y.Nishikawa
-- Create date: 2021-05-28
-- Description:																													
-- =============================================
CREATE PROCEDURE [dbo].[pr_ZaikoRegister]																	
	-- Add the parameters for the stored procedure here
	@AkaKBN as smallint,
	@SoukoCD as varchar(10),
	@ShouhinCD as varchar(50),
	@KanriNO as varchar(10),
	@NyuukoDate as date,
	@Suuryou as decimal(21,6),
	@UpdateOperator as varchar(10),
	@UpdateDatetime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF EXISTS ( 
                 SELECT * 
                 FROM D_GenZaiko DGZK
                 WHERE DGZK.SoukoCD = @SoukoCD
                 AND DGZK.ShouhinCD = @ShouhinCD
                 AND DGZK.KanriNO = @KanriNO
                 AND DGZK.NyuukoDate = @NyuukoDate
              )
    BEGIN
	   UPDATE DGZK 
	   SET GenZaikoSuu = GenZaikoSuu + @Suuryou * @AkaKBN
	      ,UpdateOperator = @UpdateOperator
	      ,UpdateDateTime = @UpdateDatetime
	   FROM D_GenZaiko DGZK
	   WHERE DGZK.SoukoCD = @SoukoCD
       AND DGZK.ShouhinCD = @ShouhinCD
       AND DGZK.KanriNO = @KanriNO
       AND DGZK.NyuukoDate = @NyuukoDate
	END
	ELSE
	BEGIN
	   INSERT INTO D_GenZaiko
       (SoukoCD
       ,ShouhinCD
       ,KanriNO
       ,NyuukoDate
       ,GenZaikoSuu
       ,IdouSekisouSuu
       ,InsertOperator
       ,InsertDateTime
       ,UpdateOperator
       ,UpdateDateTime)
        SELECT @SoukoCD
              ,@ShouhinCD
              ,@KanriNO
              ,@NyuukoDate
              ,@Suuryou * @AkaKBN
              ,0
              ,@UpdateOperator
              ,@UpdateDatetime
              ,@UpdateOperator
              ,@UpdateDatetime
	END
END

GO


