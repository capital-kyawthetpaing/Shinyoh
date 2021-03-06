 BEGIN TRY 
 Drop Procedure dbo.[Get_Max_HacchuuNO]
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
CREATE PROCEDURE [dbo].[Get_Max_HacchuuNO]
	@JuchuuNO as varchar(12),
	@HacchuuNO as varchar(12),
	@SiiresakiCD as varchar(10),
	@SoukoCD as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select DHM.HacchuuNO, MAX(DHM.HacchuuGyouNO) as HacchuuGyouNO  from D_HacchuuMeisai DHM
	inner join D_Hacchuu DH on DHM.HacchuuNO=DH.HacchuuNO
	where DHM.JuchuuNO = @JuchuuNO and DHM.SoukoCD=@SoukoCD and DH.SiiresakiCD= @SiiresakiCD 
	and  (@HacchuuNO is null or(DHM.HacchuuNO=@HacchuuNO)) 
	group by DHM.HacchuuNO
   
END
