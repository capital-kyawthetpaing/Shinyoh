 BEGIN TRY 
 Drop Procedure dbo.[sp_ZaikoIkkatuSaiHikiate_Process]
END try
BEGIN CATCH END CATCH 
GO
/****** Object:  StoredProcedure [dbo].[sp_ZaikoIkkatuSaiHikiate_Process]    Script Date: 04/14/21 8:11:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ZaikoIkkatuSaiHikiate_Process]
	-- Add the parameters for the stored procedure here
	@SerialKBN			SMALLINT,--in連番区分
	@SlipNo				VARCHAR(10),--in伝票番号
	@ProcessKBN			SMALLINT,--in処理区分
	@OperatorCD			VARCHAR(10),
	@PC					VARCHAR(100),
    @Program			VARCHAR(40),
    @Mode				VARCHAR(15),
	@KeyItem			VARCHAR(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	EXEC dbo.Fnc_Hikiate @SerialKBN, @SlipNo, @ProcessKBN, @OperatorCD

	EXEC dbo.L_Log_Insert @OperatorCD, @Program, @PC, @Mode, @KeyItem

END
