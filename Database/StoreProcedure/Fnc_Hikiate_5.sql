/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/06/07 16:50:51 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_5%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_5]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/06/07 16:50:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	5:íÖâ◊ (all inèàóùãÊï™ 10,21,20,30) 
-- History    : 2021/04/20 Y.Nishikawa Remake
--            : 2021/04/27 Y.Nishikawa Remake
--            : 2021/05/07 Y.Nishikawa Remake
--            : 2021/05/24 Y.Nishikawa Remake
--            : 2021/05/26 Y.Nishikawa Remake
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_5]
	-- Add the parameters for the stored procedure here
	@SlipNo as varchar(12),
	@ProcessKBN as smallint,
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    declare @ChakuniNo  as varchar(12),
		@ChakuniGyouNO as smallint,
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(50),
		@KanriNO as varchar(10),
		@NyuukoDate as varchar(10),
		@ChakuniSuu as decimal(21,6),
		@JuchuuNO as varchar(12),
		@JuchuuGyouNO as smallint

	declare cursorOuter cursor read_only
	for
	--2021/04/20 Y.Nishikawa ADD RemakeÅ´Å´
	--select cm.ChakuniNO,cm.ChakuniGyouNO,c.SoukoCD,cm.ShouhinCD,cm.KanriNO,c.ChakuniDate,cm.ChakuniSuu,cm.JuchuuNO,cm.JuchuuGyouNO 
	--from D_ChakuniMeisai cm inner join D_Chakuni c on cm.ChakuniNO = c.ChakuniNO
	--where cm.ChakuniNO = @SlipNo
	select MAX(cm.ChakuniNO) ChakuniNO
	      ,MAX(cm.ChakuniGyouNO) ChakuniGyouNO
		  ,MAX(c.SoukoCD) SoukoCD
		  ,MAX(cm.ShouhinCD) ShouhinCD
		  ,MAX(cm.KanriNO) KanriNO
		  ,MAX(c.ChakuniDate) ChakuniDate
		  ,SUM(cm.ChakuniSuu) ChakuniSuu
		  ,MAX(cm.JuchuuNO) JuchuuNO
		  ,MAX(cm.JuchuuGyouNO) JuchuuGyouNO
	from D_ChakuniMeisai cm inner join D_Chakuni c on cm.ChakuniNO = c.ChakuniNO
	where cm.ChakuniNO = @SlipNo
	Group by HacchuuNO
	        ,HacchuuGyouNO
	--2021/04/20 Y.Nishikawa ADD RemakeÅ™Å™
	
	open cursorOuter
	
	fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ChakuniSuu,@JuchuuNO,@JuchuuGyouNO
	while @@FETCH_STATUS = 0
		begin
			--2021/04/20 Y.Nishikawa CHG Remake
			--update D_HikiateZaiko
			--set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
			--					when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
			--	UpdateOperator = @UpdateOperator,
			--	UpdateDateTime = @UpdateDateTime
			--where 
			--	SoukoCD = @SoukoCD
			--and ShouhinCD = @ShouhinCD
			--and KanriNO = @KanriNO
			--and isnull(NyuukoDate,'') =  case when @ProcessKBN = 10 or @ProcessKBN = 21 then''
			--		else NyuukoDate end

			--update D_JuchuuShousai
			--set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
			--					when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
			--UpdateOperator = @UpdateOperator,
			--UpdateDateTime = @UpdateDateTime
			--where JuchuuNO = @JuchuuNO
			--and JuchuuGyouNO = @JuchuuGyouNO
			--and KanriNO = @KanriNO
			--and  isnull(NyuukoDate,'') =  case when @ProcessKBN = 10 or @ProcessKBN = 21 then''
			--		else NyuukoDate end

			--update D_ShukkaSiziShousai
			--set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
			--					when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
			--	UpdateOperator = @UpdateOperator,
			--	UpdateDateTime = @UpdateDateTime
			--where JuchuuNO = @JuchuuNO
			--and JuchuuGyouNO = @JuchuuGyouNO
			--and KanriNO = @KanriNO
			--and ShukkaZumiSuu = 0

			IF(ISNULL(@JuchuuNO, '') != '')
			BEGIN

			    --2021/05/26 Y.Nishikawa ADD RemakeÅ´Å´
			    DECLARE @IsShukkaSiziKanryou SMALLINT
			    SELECT @IsShukkaSiziKanryou = CASE WHEN ShukkaSiziKanryouKBN = 1 
			                                       THEN 1
			    								   ELSE 0
			    							  END
			    FROM D_JuchuuMeisai
			    WHERE JuchuuNO = @JuchuuNO
			    AND JuchuuGyouNO = @JuchuuGyouNO
			    --2021/05/26 Y.Nishikawa ADD RemakeÅ™Å™
			    
			    --2021/05/24 Y.Nishikawa ADD RemakeÅ´Å´
			    SELECT @ChakuniSuu = CASE WHEN JuchuuSuu < @ChakuniSuu
			                              THEN JuchuuSuu
			    						  ELSE @ChakuniSuu
			    					 END
			    FROM D_JuchuuMeisai
			    WHERE JuchuuNO = @JuchuuNO
			    AND JuchuuGyouNO = @JuchuuGyouNO
			    --2021/05/24 Y.Nishikawa ADD RemakeÅ™Å™
			    
			    IF (@ProcessKBN = 10 OR @ProcessKBN = 21)
			    BEGIN
			          --2021/05/26 Y.Nishikawa ADD RemakeÅ´Å´
			    	  IF (@IsShukkaSiziKanryou = 0)
			    	  BEGIN
			    	  --2021/05/26 Y.Nishikawa ADD RemakeÅ™Å™
			    
			    	  IF EXISTS (
			    	               SELECT *
			    				   FROM D_JuchuuShousai
			    				   WHERE JuchuuNO = @JuchuuNO
			    				   AND JuchuuGyouNO = @JuchuuGyouNO
			    				   AND KanriNO = @KanriNO
			    				   AND NyuukoDate = @NyuukoDate
			    	            )
			    	  BEGIN
			    		  DECLARE @JuchuuSuu_1 DECIMAL(21,6),
			    				  @ShukkaSiziZumiSuu_1 DECIMAL(21,6)
			    
			    				  SELECT @JuchuuSuu_1 = JuchuuSuu
			    						,@ShukkaSiziZumiSuu_1 = ShukkaSiziZumiSuu
			    				  FROM D_JuchuuShousai
			    				  WHERE JuchuuNO = @JuchuuNO
			    				  AND JuchuuGyouNO = @JuchuuGyouNO
			    				  AND KanriNO = @KanriNO
			    				  AND NyuukoDate = ''
			    		  
			    		  IF (@ChakuniSuu <= @ShukkaSiziZumiSuu_1)
			    		  BEGIN
			    		     UPDATE D_JuchuuShousai
			    		     SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			    ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu - @ChakuniSuu
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE JuchuuNO = @JuchuuNO
			    		     AND JuchuuGyouNO = @JuchuuGyouNO
			    		     AND KanriNO = @KanriNO
			    		     AND NyuukoDate = '' 
			    
			    		     UPDATE D_JuchuuShousai
			    		     SET JuchuuSuu = JuchuuSuu + @ChakuniSuu
			    		        ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + @ChakuniSuu
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE JuchuuNO = @JuchuuNO
			    		     AND JuchuuGyouNO = @JuchuuGyouNO
			    		     AND KanriNO = @KanriNO
			    		     AND NyuukoDate = @NyuukoDate
			    		  END
			    		  ELSE
			    		  BEGIN
			    		     UPDATE D_JuchuuShousai
			    		     SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			    ,HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziZumiSuu_1)
			    				,ShukkaSiziZumiSuu = 0
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE JuchuuNO = @JuchuuNO
			    		     AND JuchuuGyouNO = @JuchuuGyouNO
			    		     AND KanriNO = @KanriNO
			    		     AND NyuukoDate = ''
			    
			    		     UPDATE D_JuchuuShousai
			    		     SET JuchuuSuu = JuchuuSuu + @ChakuniSuu
			    			    ,HikiateZumiSuu = HikiateZumiSuu + (@ChakuniSuu - @ShukkaSiziZumiSuu_1)
			    		        ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + @ShukkaSiziZumiSuu_1
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE JuchuuNO = @JuchuuNO
			    		     AND JuchuuGyouNO = @JuchuuGyouNO
			    		     AND KanriNO = @KanriNO
			    		     AND NyuukoDate = @NyuukoDate
			    		  END
			          END
			    	  ELSE
			    	  BEGIN
			    		  DECLARE @JuchuuSuu_2 DECIMAL(21,6),
			    				  @ShukkaSiziZumiSuu_2 DECIMAL(21,6),
			    				  @JuchuuShousaiNO_2 smallint
			    
			    				  SELECT @JuchuuSuu_2 = JuchuuSuu
			    						,@ShukkaSiziZumiSuu_2 = ShukkaSiziZumiSuu
			    				  FROM D_JuchuuShousai
			    				  WHERE JuchuuNO = @JuchuuNO
			    				  AND JuchuuGyouNO = @JuchuuGyouNO
			    				  AND KanriNO = @KanriNO
			    				  AND NyuukoDate = ''
			    		      
			    		      SELECT @JuchuuShousaiNO_2 = MAX(JuchuuShousaiNO) + 1
			    			  FROM D_JuchuuShousai
			    			  WHERE JuchuuNO = @JuchuuNO
			    		      AND JuchuuGyouNO = @JuchuuGyouNO
			    
			    		  IF (@ChakuniSuu <= @ShukkaSiziZumiSuu_2)
			    		  BEGIN
			    		     UPDATE D_JuchuuShousai
			    		     SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			    ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu - @ChakuniSuu
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE JuchuuNO = @JuchuuNO
			    		     AND JuchuuGyouNO = @JuchuuGyouNO
			    		     AND KanriNO = @KanriNO
			    		     AND NyuukoDate = '' 
			    
			    		     INSERT INTO D_JuchuuShousai
                             (JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,JuchuuSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,HikiateZumiSuu
                             ,MiHikiateSuu
                             ,ShukkaSiziZumiSuu
                             ,ShukkaZumiSuu
                             ,UriageZumiSuu
                             ,HacchuuNO
                             ,HacchuuGyouNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                              SELECT JuchuuNO
                                   ,JuchuuGyouNO
                                   ,@JuchuuShousaiNO_2
                                   ,SoukoCD
                                   ,ShouhinCD
                                   ,ShouhinName
                                   ,@ChakuniSuu
                                   ,@KanriNO
                                   ,@NyuukoDate
                                   ,0
                                   ,0
                                   ,@ChakuniSuu
                                   ,0
                                   ,0
                                   ,HacchuuNO
                                   ,HacchuuGyouNO
                                   ,@UpdateOperator
                                   ,@UpdateDateTime
                                   ,@UpdateOperator
                                   ,@UpdateDateTime
                               FROM D_JuchuuMeisai
			    			   WHERE JuchuuNO = @JuchuuNO
			    			   AND JuchuuGyouNO = @JuchuuGyouNO
			    		  END
			    		  ELSE
			    		  BEGIN
			    		     UPDATE D_JuchuuShousai
			    		     SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			    ,HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziZumiSuu_2)
			    				,ShukkaSiziZumiSuu = 0
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE JuchuuNO = @JuchuuNO
			    		     AND JuchuuGyouNO = @JuchuuGyouNO
			    		     AND KanriNO = @KanriNO
			    		     AND NyuukoDate = ''
			    
			    		     INSERT INTO D_JuchuuShousai
                             (JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,JuchuuSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,HikiateZumiSuu
                             ,MiHikiateSuu
                             ,ShukkaSiziZumiSuu
                             ,ShukkaZumiSuu
                             ,UriageZumiSuu
                             ,HacchuuNO
                             ,HacchuuGyouNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                              SELECT JuchuuNO
                                   ,JuchuuGyouNO
                                   ,@JuchuuShousaiNO_2
                                   ,SoukoCD
                                   ,ShouhinCD
                                   ,ShouhinName
                                   ,@ChakuniSuu
                                   ,@KanriNO
                                   ,@NyuukoDate
                                   ,@ChakuniSuu - @ShukkaSiziZumiSuu_2
                                   ,0
                                   ,@ShukkaSiziZumiSuu_2
                                   ,0
                                   ,0
                                   ,HacchuuNO
                                   ,HacchuuGyouNO
                                   ,@UpdateOperator
                                   ,@UpdateDateTime
                                   ,@UpdateOperator
                                   ,@UpdateDateTime
                               FROM D_JuchuuMeisai
			    			   WHERE JuchuuNO = @JuchuuNO
			    			   AND JuchuuGyouNO = @JuchuuGyouNO
			    		  END
			    	  END
			    
			    	  DELETE DJUS
			    	  FROM D_JuchuuShousai DJUS
			    	  WHERE JuchuuNO = @JuchuuNO
			    	  AND JuchuuGyouNO = @JuchuuGyouNO
			    	  AND SoukoCD = @SoukoCD
			          AND ShouhinCD = @ShouhinCD
			    	  AND JuchuuSuu = 0 
			    	  AND ShukkaSiziZumiSuu = 0
			    	  AND HikiateZumiSuu = 0
			    
			    	  IF EXISTS (
			    	             SELECT * 
			    	             FROM D_JuchuuShousai DJUS
			    				 INNER JOIN D_HacchuuMeisai DHAM
			    				 ON DJUS.JuchuuNO = DHAM.JuchuuNO
			    				 AND DJUS.JuchuuGyouNO = DHAM.JuchuuGyouNO
			    		         WHERE DJUS.JuchuuNO = @JuchuuNO
			    		         AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
			    				 AND DHAM.ChakuniYoteiKanryouKBN = 1
			    				 AND DHAM.ChakuniKanryouKBN = 1
			    				 AND ISNULL(DJUS.NyuukoDate, '') = ''
			    				)
			    	  BEGIN
			    	        UPDATE DJUM
			    			SET HikiateZumiSuu = @ChakuniSuu
			    			   ,MiHikiateSuu = JuchuuSuu - @ChakuniSuu
			    			   ,UpdateOperator = @UpdateOperator
			    			   ,UpdateDateTime = @UpdateDateTime
			    			FROM D_JuchuuMeisai DJUM
			    			WHERE JuchuuNO = @JuchuuNO
			    			AND JuchuuGyouNO = @JuchuuGyouNO
			    
			    			UPDATE DHZK
			                SET  HikiateZumiSuu = DHZK.HikiateZumiSuu - DJUS.HikiateZumiSuu
			    		     	,UpdateOperator = @UpdateOperator
			          	        ,UpdateDateTime = @UpdateDateTime
			    			FROM D_HikiateZaiko DHZK
			    			INNER JOIN D_JuchuuShousai DJUS
			    			ON DHZK.SoukoCD = DJUS.SoukoCD
			    			AND DHZK.ShouhinCD = DJUS.ShouhinCD
			    			AND DHZK.KanriNO = DJUS.KanriNO
			    			AND DHZK.NyuukoDate = DJUS.NyuukoDate
			                WHERE DJUS.JuchuuNO = @JuchuuNO
			    			AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
			    			AND DJUS.SoukoCD = @SoukoCD
			                AND DJUS.ShouhinCD = @ShouhinCD
			    			AND ISNULL(DJUS.NyuukoDate, '') = ''
			    
			    	        DELETE DJUS
			    			FROM D_JuchuuShousai DJUS
			    			WHERE JuchuuNO = @JuchuuNO
			    			AND JuchuuGyouNO = @JuchuuGyouNO
			    			AND SoukoCD = @SoukoCD
			                AND ShouhinCD = @ShouhinCD
			    			AND ISNULL(NyuukoDate, '') = ''
			    
			    			DECLARE @juchuuShousaiNO_3 smallint
			    			SELECT @juchuuShousaiNO_3 = MAX(DJUS.JuchuuShousaiNO) + 1
			    			FROM D_JuchuuShousai DJUS
			    			WHERE JuchuuNO = @JuchuuNO
			    			AND JuchuuGyouNO = @JuchuuGyouNO
			    
			    			INSERT INTO D_JuchuuShousai
                            (JuchuuNO
                            ,JuchuuGyouNO
                            ,JuchuuShousaiNO
                            ,SoukoCD
                            ,ShouhinCD
                            ,ShouhinName
                            ,JuchuuSuu
                            ,KanriNO
                            ,NyuukoDate
                            ,HikiateZumiSuu
                            ,MiHikiateSuu
                            ,ShukkaSiziZumiSuu
                            ,ShukkaZumiSuu
                            ,UriageZumiSuu
                            ,HacchuuNO
                            ,HacchuuGyouNO
                            ,InsertOperator
                            ,InsertDateTime
                            ,UpdateOperator
                            ,UpdateDateTime)
                               SELECT JuchuuNO
                                     ,JuchuuGyouNO
                                     ,@juchuuShousaiNO_3
                                     ,SoukoCD
                                     ,ShouhinCD
                                     ,ShouhinName
                                     ,MiHikiateSuu
                                     ,NULL
                                     ,''
                                     ,0
                                     ,MiHikiateSuu
                                     ,0
                                     ,0
                                     ,0
                                     ,HacchuuNO
                                     ,HacchuuGyouNO
                                     ,@UpdateOperator
                                     ,@UpdateDateTime
                                     ,@UpdateOperator
                                     ,@UpdateDateTime
                                 FROM D_JuchuuMeisai
			    				 WHERE JuchuuNO = @JuchuuNO
			    				 AND JuchuuGyouNO = @JuchuuGyouNO
			    
			    	  END
			    
			    	  UPDATE DJUS
			          SET HacchuuNO = NULL
			          	 ,HacchuuGyouNO = 0
			    		 ,UpdateOperator = @UpdateOperator
			    		 ,UpdateDateTime = @UpdateDateTime
			          FROM D_JuchuuShousai DJUS
			    	  INNER JOIN D_HacchuuMeisai DHAM
			    	  ON DJUS.HacchuuNO = DHAM.HacchuuNO
			    	  AND DJUS.HacchuuGyouNO = DHAM.HacchuuGyouNO
			          WHERE DJUS.JuchuuNO = @JuchuuNO
			          AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
			    	  AND DHAM.ChakuniYoteiKanryouKBN = 1
			    	  AND DHAM.ChakuniKanryouKBN = 1
			    	  AND DJUS.MiHikiateSuu > 0
			    
			    
			    	  IF EXISTS (
			    	               SELECT *
			    				   FROM D_HikiateZaiko
			    				   WHERE SoukoCD = @SoukoCD
			                       AND ShouhinCD = @ShouhinCD
			                       AND KanriNO = @KanriNO
			                       AND NyuukoDate = @NyuukoDate
			    	            )
			    	  BEGIN
			    		 DECLARE @HikiateZumiSuu_3 DECIMAL(21, 6),
			    		         @ShukkaSiziSuu_3 DECIMAL(21, 6)
			    		 SELECT @HikiateZumiSuu_3 = HikiateZumiSuu
			    		       ,@ShukkaSiziSuu_3 = ShukkaSiziSuu
			    		 FROM D_HikiateZaiko
			    		 WHERE SoukoCD = @SoukoCD
			             AND ShouhinCD = @ShouhinCD
			             AND KanriNO = @KanriNO
			             AND NyuukoDate = ''
			    
			    		 IF (@ChakuniSuu <= @ShukkaSiziSuu_3)
			    		 BEGIN
			    		     UPDATE D_HikiateZaiko
			    		     SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
			    			    ,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE SoukoCD = @SoukoCD
			                 AND ShouhinCD = @ShouhinCD
			                 AND KanriNO = @KanriNO
			                 AND NyuukoDate = ''
			    
			    			 UPDATE D_HikiateZaiko
			    		     SET ShukkaSiziSuu = ShukkaSiziSuu + @ChakuniSuu
			    			    ,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE SoukoCD = @SoukoCD
			                 AND ShouhinCD = @ShouhinCD
			                 AND KanriNO = @KanriNO
			                 AND NyuukoDate = @NyuukoDate
			    		 END
			    		 ELSE
			    		 BEGIN
			    		     UPDATE D_HikiateZaiko
			    		     SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_3)
			    				,ShukkaSiziSuu = 0
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE SoukoCD = @SoukoCD
			                 AND ShouhinCD = @ShouhinCD
			                 AND KanriNO = @KanriNO
			    		     AND NyuukoDate = ''
			    
			    		     UPDATE D_HikiateZaiko
			    		     SET HikiateZumiSuu = HikiateZumiSuu + (@ChakuniSuu - @ShukkaSiziSuu_3)
			    		        ,ShukkaSiziSuu = ShukkaSiziSuu + @ShukkaSiziSuu_3
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE SoukoCD = @SoukoCD
			                 AND ShouhinCD = @ShouhinCD
			                 AND KanriNO = @KanriNO
			    		     AND NyuukoDate = @NyuukoDate
			    		  END
			    	  END
			    	  ELSE
			    	  BEGIN
			    		  DECLARE @HikiateZumiSuu_4 DECIMAL(21, 6),
			    		          @ShukkaSiziSuu_4 DECIMAL(21, 6)
			    		  SELECT @HikiateZumiSuu_4 = HikiateZumiSuu
			    		        ,@ShukkaSiziSuu_4 = ShukkaSiziSuu
			    		  FROM D_HikiateZaiko
			    		  WHERE SoukoCD = @SoukoCD
			              AND ShouhinCD = @ShouhinCD
			              AND KanriNO = @KanriNO
			              AND NyuukoDate = ''
			    
			    		  IF (@ChakuniSuu <= @ShukkaSiziSuu_4)
			    		  BEGIN
			    		     UPDATE D_HikiateZaiko
			    		     SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
			    			    ,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE SoukoCD = @SoukoCD
			                 AND ShouhinCD = @ShouhinCD
			                 AND KanriNO = @KanriNO
			                 AND NyuukoDate = ''
			    
			    		     INSERT INTO D_HikiateZaiko
                             (SoukoCD
                             ,ShouhinCD
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaSiziSuu
                             ,HikiateZumiSuu
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                              SELECT @SoukoCD
                                    ,@ShouhinCD
                                    ,@KanriNO
                                    ,@NyuukoDate
                                    ,@ChakuniSuu
                                    ,0
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
			    		  END
			    		  ELSE
			    		  BEGIN
			    		     UPDATE D_HikiateZaiko
			    		     SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_4)
			    				,ShukkaSiziSuu = 0
			    				,UpdateOperator = @UpdateOperator
			    				,UpdateDateTime = @UpdateDateTime
			    		     WHERE SoukoCD = @SoukoCD
			                 AND ShouhinCD = @ShouhinCD
			                 AND KanriNO = @KanriNO
			    		     AND NyuukoDate = ''
			    
			    		     INSERT INTO D_HikiateZaiko
                             (SoukoCD
                             ,ShouhinCD
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaSiziSuu
                             ,HikiateZumiSuu
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                              SELECT @SoukoCD
                                    ,@ShouhinCD
                                    ,@KanriNO
                                    ,@NyuukoDate
                                    ,@ShukkaSiziSuu_4
                                    ,@ChakuniSuu - @ShukkaSiziSuu_4
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
			    		  END
			    	  END
			    
			    
			    	  DELETE DSSS
			    	  FROM D_ShukkaSiziShousai DSSS
			    	  INNER JOIN D_ShukkaSiziMeisai DSSM
			    	  ON DSSS.ShukkaSiziNO = DSSM.ShukkaSiziNO
			    	  AND DSSS.ShukkaSiziGyouNO = DSSM.ShukkaSiziGyouNO
			    	  WHERE DSSS.JuchuuNO = @JuchuuNO
			    	  AND DSSS.JuchuuGyouNO = @JuchuuGyouNO
			    	  AND DSSS.SoukoCD = @SoukoCD
			    	  AND DSSS.ShouhinCD = @ShouhinCD
			    	  AND DSSS.KanriNO = @KanriNO
			    	  AND (DSSS.NyuukoDate = @NyuukoDate OR ISNULL(DSSS.NyuukoDate, '') = '')
			    	  AND DSSM.ShukkaKanryouKBN = 0
			    	  AND DSSM.ShukkaZumiSuu = 0
			    
			    	  DECLARE @JuchuuShousaiNO_5 smallint,
			    	          @ShukkaSiziZumiSuu_5 decimal(21, 6)
			    	  SELECT @JuchuuShousaiNO_5 = JuchuuShousaiNO 
			    	        ,@ShukkaSiziZumiSuu_5 = ShukkaSiziZumiSuu
                      FROM D_JuchuuShousai
			    	  WHERE JuchuuNO = @JuchuuNO
			    	  AND JuchuuGyouNO = @JuchuuGyouNO
			    	  AND SoukoCD = @SoukoCD
			    	  AND ShouhinCD = @ShouhinCD
			    	  AND KanriNO = @KanriNO
			    	  AND NyuukoDate = @NyuukoDate
			    
			    	  DECLARE @ShukkaSiziNO_5 varchar(12),
                              @ShukkaSiziGyouNO_5 smallint,
			    	   	      @MeisaiShukkaSiziSuuZan_5 decimal(21, 6),
			    			  @CUR_ShukkaSiziShousaiNO_5 smallint
                           
                      DECLARE cursorShukkaSiziMeisai CURSOR READ_ONLY
                      FOR
                      SELECT DSSM.ShukkaSiziNO 
			    	        ,DSSM.ShukkaSiziGyouNO
			    	   	    ,DSSM.ShukkaSiziSuu - ISNULL(DSSS.ShukkaSiziSuu, CAST(0 AS DECIMAL(21, 6))) 
                      FROM D_ShukkaSiziMeisai DSSM
			    	  LEFT OUTER JOIN (
			    	                     SELECT ShukkaSiziNO, ShukkaSiziGyouNO, SUM(ShukkaSiziSuu) ShukkaSiziSuu
			    						 FROM D_ShukkaSiziShousai 
			    						 WHERE JuchuuNO = @JuchuuNO
			    	                     AND JuchuuGyouNO = @JuchuuGyouNO
			    						 GROUP BY ShukkaSiziNO, ShukkaSiziGyouNO
			    					  ) DSSS
			    	  ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
			    	  AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
			    	  WHERE DSSM.JuchuuNO = @JuchuuNO
			    	  AND DSSM.JuchuuGyouNO = @JuchuuGyouNO
			    	  AND (DSSM.ShukkaKanryouKBN = 0 OR DSSM.ShukkaZumiSuu = 0)
                      ORDER BY DSSM.ShukkaSiziNO, DSSM.ShukkaSiziGyouNO
			    
                      OPEN cursorShukkaSiziMeisai
                             
                      FETCH NEXT FROM cursorShukkaSiziMeisai INTO @ShukkaSiziNO_5, @ShukkaSiziGyouNO_5, @MeisaiShukkaSiziSuuZan_5
                      WHILE @@FETCH_STATUS = 0
                      BEGIN
			    		 SET @CUR_ShukkaSiziShousaiNO_5 = 0
			    
			    		 SELECT @CUR_ShukkaSiziShousaiNO_5 = MAX(ISNULL(DSSS.ShukkaSiziShousaiNO, 0)) + 1
			    		 FROM D_ShukkaSiziMeisai DSSM
			    		 LEFT OUTER JOIN D_ShukkaSiziShousai DSSS
			    		 ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
			    		 AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
			    		 WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO_5
			    		 AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO_5
			    
			    		 IF(@MeisaiShukkaSiziSuuZan_5 > @ShukkaSiziZumiSuu_5)
			    		 BEGIN
			    		     INSERT INTO D_ShukkaSiziShousai
                             (ShukkaSiziNO
                             ,ShukkaSiziGyouNO
                             ,ShukkaSiziShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,ShukkaSiziSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaZumiSuu
                             ,JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                             SELECT ShukkaSiziNO
                                  ,ShukkaSiziGyouNO
                                  ,@CUR_ShukkaSiziShousaiNO_5
                                  ,@SoukoCD
                                  ,@ShouhinCD
                                  ,ShouhinName
                                  ,@ShukkaSiziZumiSuu_5
                                  ,@KanriNO
                                  ,@NyuukoDate
                                  ,0
                                  ,JuchuuNO
                                  ,JuchuuGyouNO
                                  ,@JuchuuShousaiNO_5
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                              FROM D_ShukkaSiziMeisai
			    		      WHERE ShukkaSiziNO = @ShukkaSiziNO_5
			    		      AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO_5
			    
			    		     INSERT INTO D_ShukkaSiziShousai
                             (ShukkaSiziNO
                             ,ShukkaSiziGyouNO
                             ,ShukkaSiziShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,ShukkaSiziSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaZumiSuu
                             ,JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                             SELECT ShukkaSiziNO
                                  ,ShukkaSiziGyouNO
                                  ,@CUR_ShukkaSiziShousaiNO_5 + 1
                                  ,@SoukoCD
                                  ,@ShouhinCD
                                  ,ShouhinName
                                  ,@MeisaiShukkaSiziSuuZan_5 - @ShukkaSiziZumiSuu_5
                                  ,@KanriNO
                                  ,''
                                  ,0
                                  ,JuchuuNO
                                  ,JuchuuGyouNO
                                  ,(SELECT TOP 1 JuchuuShousaiNO FROM D_JuchuuShousai WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND KanriNO = @KanriNO AND ISNULL(NyuukoDate, '') = '')
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                              FROM D_ShukkaSiziMeisai
			    		      WHERE ShukkaSiziNO = @ShukkaSiziNO_5
			    		      AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO_5
			    			  AND @MeisaiShukkaSiziSuuZan_5 - @ShukkaSiziZumiSuu_5 > 0
			    		 END
			    		 ELSE IF(@MeisaiShukkaSiziSuuZan_5 <= @ShukkaSiziZumiSuu_5 AND @MeisaiShukkaSiziSuuZan_5 > 0)
			    		 BEGIN
			    		     INSERT INTO D_ShukkaSiziShousai
                             (ShukkaSiziNO
                             ,ShukkaSiziGyouNO
                             ,ShukkaSiziShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,ShukkaSiziSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaZumiSuu
                             ,JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                             SELECT ShukkaSiziNO
                                  ,ShukkaSiziGyouNO
                                  ,@CUR_ShukkaSiziShousaiNO_5
                                  ,@SoukoCD
                                  ,@ShouhinCD
                                  ,ShouhinName
                                  ,@MeisaiShukkaSiziSuuZan_5
                                  ,@KanriNO
                                  ,@NyuukoDate
                                  ,0
                                  ,JuchuuNO
                                  ,JuchuuGyouNO
                                  ,@JuchuuShousaiNO_5
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                              FROM D_ShukkaSiziMeisai
			    		      WHERE ShukkaSiziNO = @ShukkaSiziNO_5
			    		      AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO_5
			    
			    			  SET @ShukkaSiziZumiSuu_5 = @ShukkaSiziZumiSuu_5 - @MeisaiShukkaSiziSuuZan_5
			    		 END
			    		 ELSE
			    		 BEGIN
			    		     SELECT 1
			    		 END
			    	    
			    	     FETCH NEXT FROM cursorShukkaSiziMeisai INTO @ShukkaSiziNO_5, @ShukkaSiziGyouNO_5, @MeisaiShukkaSiziSuuZan_5
		              END
	                  CLOSE cursorShukkaSiziMeisai
	                  DEALLOCATE cursorShukkaSiziMeisai
			    
			    	  --2021/05/26 Y.Nishikawa ADD RemakeÅ´Å´
			    	  END
			    	  --2021/05/26 Y.Nishikawa ADD RemakeÅ™Å™
			    
			    	  --2021/06/07 Y.Nishikawa DEL RemakeÅ´Å´
			    	  ----2021/04/27 Y.Nishikawa ADD Remake
			    	  --IF EXISTS ( 
      --                             SELECT * 
      --                             FROM D_GenZaiko DGZK
      --                             INNER JOIN (
      --                 			             SELECT H.SoukoCD
      --                 						       ,M.ShouhinCD
      --                 							   ,M.KanriNO
      --                 							   ,H.ChakuniDate
      --                 						 FROM D_Chakuni H
      --                                          INNER JOIN D_ChakuniMeisai M
      --                                          ON H.ChakuniNO = M.ChakuniNO
      --                                          WHERE H.ChakuniNO = @ChakuniNO
			    			--					--2021/05/07 Y.Nishikawa ADD Remake
			    			--					AND M.ChakuniGyouNO = @ChakuniGyouNO
			    			--					--2021/05/07 Y.Nishikawa ADD Remake
      --                 			           ) DCKM
      --                                            ON DGZK.SoukoCD = DCKM.SoukoCD
      --                                            AND DGZK.ShouhinCD = DCKM.ShouhinCD
      --                                            AND DGZK.KanriNO = DCKM.KanriNO
      --                                            AND DGZK.NyuukoDate = DCKM.ChakuniDate
      --                            )
      --                 BEGIN
                       
      --                    UPDATE DGZK
      --                       SET GenZaikoSuu = GenZaikoSuu + DCKM.ChakuniSuu
      --                          ,UpdateOperator = @UpdateOperator
      --                          ,UpdateDateTime = @UpdateDateTime
      --                 	FROM D_GenZaiko DGZK
      --                 	INNER JOIN (
      --                 			      SELECT H.SoukoCD
      --                 		         	    ,M.ShouhinCD
      --                 		         	    ,M.KanriNO
      --                 		         	    ,H.ChakuniDate
      --                 						,M.ChakuniSuu
      --                 		          FROM D_Chakuni H
      --                                   INNER JOIN D_ChakuniMeisai M
      --                                   ON H.ChakuniNO = M.ChakuniNO
      --                                   WHERE H.ChakuniNO = @ChakuniNO
			    			--			 --2021/05/07 Y.Nishikawa ADD Remake
			    			--			 AND M.ChakuniGyouNO = @ChakuniGyouNO
			    			--			 --2021/05/07 Y.Nishikawa ADD Remake
      --                 			    ) DCKM
      --                    ON DGZK.SoukoCD = DCKM.SoukoCD
      --                    AND DGZK.ShouhinCD = DCKM.ShouhinCD
      --                    AND DGZK.KanriNO = DCKM.KanriNO
      --                    AND DGZK.NyuukoDate = DCKM.ChakuniDate
      --                 END
      --                 ELSE
      --                 BEGIN
                       
      --                    INSERT INTO D_GenZaiko
      --                               (SoukoCD
      --                               ,ShouhinCD
      --                               ,KanriNO
      --                               ,NyuukoDate
      --                               ,GenZaikoSuu
      --                               ,IdouSekisouSuu
      --                               ,InsertOperator
      --                               ,InsertDateTime
      --                               ,UpdateOperator
      --                               ,UpdateDateTime)
      --                    SELECT DCKH.SoukoCD
      --                          ,DCKM.ShouhinCD
      --                          ,DCKM.KanriNO
      --                          ,DCKH.ChakuniDate
      --                          ,DCKM.ChakuniSuu
      --                          ,0
      --                          ,@UpdateOperator
      --                          ,@UpdateDateTime
      --                          ,@UpdateOperator
      --                          ,@UpdateDateTime
      --                      FROM D_Chakuni DCKH
      --                      INNER JOIN D_ChakuniMeisai DCKM
      --                      ON DCKH.ChakuniNO = DCKM.ChakuniNO
      --                      WHERE DCKH.ChakuniNO = @ChakuniNO
      --                      --2021/05/07 Y.Nishikawa ADD Remake
			    			--AND DCKM.ChakuniGyouNO = @ChakuniGyouNO
			    			----2021/05/07 Y.Nishikawa ADD Remake
      --                 END
			    	  ----2021/04/27 Y.Nishikawa ADD  Remake
			    	  --2021/06/07 Y.Nishikawa DEL RemakeÅ™Å™
			    
			    END
			    ELSE
			    BEGIN
			    	  DECLARE @JuchuuSuu_11 DECIMAL(21,6),
			    	          @HikiateZumiSuu_11 DECIMAL(21,6),
			    		      @ShukkaSiziZumiSuu_11 DECIMAL(21,6),
			    			  @JuchuuShousaiNO_11 smallint
			    		      
			    		      SELECT @JuchuuSuu_11 = JuchuuSuu
			    		      	    ,@HikiateZumiSuu_11 = HikiateZumiSuu
			    					,@ShukkaSiziZumiSuu_11 = ShukkaSiziZumiSuu
			    		      FROM D_JuchuuShousai
			    		      WHERE JuchuuNO = @JuchuuNO
			    		      AND JuchuuGyouNO = @JuchuuGyouNO
			    		      AND KanriNO = @KanriNO
			    		      AND NyuukoDate = @NyuukoDate
			    
			    			  SELECT @JuchuuShousaiNO_11 = MAX(JuchuuShousaiNO) + 1
			    			  FROM D_JuchuuShousai
			    			  WHERE JuchuuNO = @JuchuuNO
			    			  AND JuchuuGyouNO = @JuchuuGyouNO
			    	  
			    	  --2021/05/26 Y.Nishikawa ADD RemakeÅ´Å´
			    	  IF (@IsShukkaSiziKanryou = 0)
			    	  BEGIN
			    	  --2021/05/26 Y.Nishikawa ADD RemakeÅ™Å™
			    
			    	  IF EXISTS (
			    	               SELECT *
			    				   FROM D_JuchuuShousai
			    				   WHERE JuchuuNO = @JuchuuNO
			    		           AND JuchuuGyouNO = @JuchuuGyouNO
			    		           AND KanriNO = @KanriNO
			    				   AND ISNULL(NyuukoDate, '') = ''
			    	            )
			    	  BEGIN
			    	     IF (@JuchuuSuu_11 >= @ChakuniSuu)
			    	     BEGIN
			    	        IF (@ShukkaSiziZumiSuu_11 >= @ChakuniSuu)
			    	        BEGIN
			    			   IF (@HikiateZumiSuu_11 > 0)
			    			   BEGIN
			    			      DECLARE @ShukkaSiziZumiSuu_Chouseigo_11 DECIMAL(21, 6)
			    				  DECLARE @HikiateZumiSuu_Chouseigo_11 DECIMAL(21, 6)
			    				  SELECT @ShukkaSiziZumiSuu_Chouseigo_11 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    					                                            THEN CAST(0 AS DECIMAL(21, 6))
			    									 		                    ELSE @ChakuniSuu - HikiateZumiSuu
			    									                       END
			    					    ,@HikiateZumiSuu_Chouseigo_11 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    					                                         THEN @ChakuniSuu
			    									 		                 ELSE HikiateZumiSuu
			    									                    END
			    				  FROM D_JuchuuShousai
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND NyuukoDate = @NyuukoDate
			    
			    			      UPDATE D_JuchuuShousai
			    			      SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    				     ,HikiateZumiSuu = HikiateZumiSuu - @HikiateZumiSuu_Chouseigo_11
			    					 ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu - @ShukkaSiziZumiSuu_Chouseigo_11
			    					 ,UpdateOperator = @UpdateOperator
			    				     ,UpdateDateTime = @UpdateDateTime
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND NyuukoDate = @NyuukoDate
			    			      
			    			      UPDATE D_JuchuuShousai
			    			      SET JuchuuSuu = JuchuuSuu + @ChakuniSuu
			    				     ,HikiateZumiSuu = HikiateZumiSuu + @HikiateZumiSuu_Chouseigo_11
			    			         ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + @ShukkaSiziZumiSuu_Chouseigo_11
			    				     ,UpdateOperator = @UpdateOperator
			    				     ,UpdateDateTime = @UpdateDateTime
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND ISNULL(NyuukoDate, '') = ''
			    			   END
			    			   ELSE
			    			   BEGIN
			    			      UPDATE D_JuchuuShousai
			    			      SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			         ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu - @ChakuniSuu
			    				     ,UpdateOperator = @UpdateOperator
			    				     ,UpdateDateTime = @UpdateDateTime
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND NyuukoDate = @NyuukoDate
			    			      
			    			      UPDATE D_JuchuuShousai
			    			      SET JuchuuSuu = JuchuuSuu + @ChakuniSuu
			    			         ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + @ChakuniSuu
			    				     ,UpdateOperator = @UpdateOperator
			    				     ,UpdateDateTime = @UpdateDateTime
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND ISNULL(NyuukoDate, '') = ''
			    			   END
			    			END
			    			ELSE
			    			BEGIN
			    			   UPDATE D_JuchuuShousai
			    			   SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			      ,HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziZumiSuu_11)
			    			      ,ShukkaSiziZumiSuu = 0
			    				  ,UpdateOperator = @UpdateOperator
			    			  	  ,UpdateDateTime = @UpdateDateTime
			    			   WHERE JuchuuNO = @JuchuuNO
			    		       AND JuchuuGyouNO = @JuchuuGyouNO
			    		       AND KanriNO = @KanriNO
			    			   AND NyuukoDate = @NyuukoDate
			    
			    			   UPDATE D_JuchuuShousai
			    			   SET JuchuuSuu = JuchuuSuu + @ChakuniSuu
			    			      ,HikiateZumiSuu = HikiateZumiSuu + (@ChakuniSuu - @ShukkaSiziZumiSuu_11)
			    			      ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + @ShukkaSiziZumiSuu_11
			    				  ,UpdateOperator = @UpdateOperator
			    				  ,UpdateDateTime = @UpdateDateTime
			    			   WHERE JuchuuNO = @JuchuuNO
			    		       AND JuchuuGyouNO = @JuchuuGyouNO
			    		       AND KanriNO = @KanriNO
			    			   AND ISNULL(NyuukoDate, '') = ''
			    			END
			    
			    			DELETE D_JuchuuShousai
			    			WHERE JuchuuNO = @JuchuuNO
			    		    AND JuchuuGyouNO = @JuchuuGyouNO
			    		    AND KanriNO = @KanriNO
			    			AND NyuukoDate = @NyuukoDate
			    			AND HikiateZumiSuu = 0
			    			AND ShukkaSiziZumiSuu = 0
			    	     END
			    		 ELSE
			    		 BEGIN
			    		    SELECT 1
			    		 END
			    	  END
			    	  ELSE
			    	  BEGIN
			    	     IF (@JuchuuSuu_11 >= @ChakuniSuu)
			    	     BEGIN
			    	        IF (@ShukkaSiziZumiSuu_11 >= @ChakuniSuu)
			    	        BEGIN
			    			   IF (@HikiateZumiSuu_11 > 0)
			    			   BEGIN
			    			      DECLARE @ShukkaSiziZumiSuu_Chouseigo_111 DECIMAL(21, 6)
			    			      DECLARE @HikiateZumiSuu_Chouseigo_111 DECIMAL(21, 6)
			    			      SELECT @ShukkaSiziZumiSuu_Chouseigo_111 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    				                                                 THEN CAST(0 AS DECIMAL(21, 6))
			    				   				 		                         ELSE @ChakuniSuu - HikiateZumiSuu
			    				   				                            END
			    				        ,@HikiateZumiSuu_Chouseigo_111 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    				                                              THEN @ChakuniSuu
			    				   				 		                      ELSE HikiateZumiSuu
			    				   				                         END
			    			      FROM D_JuchuuShousai
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND NyuukoDate = @NyuukoDate
			    			      
			    			      UPDATE D_JuchuuShousai
			    			      SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			         ,HikiateZumiSuu = HikiateZumiSuu - @HikiateZumiSuu_Chouseigo_11
			    			         ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu - @ShukkaSiziZumiSuu_Chouseigo_11
			    			         ,UpdateOperator = @UpdateOperator
			    			         ,UpdateDateTime = @UpdateDateTime
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND NyuukoDate = @NyuukoDate
			    			      
			    			      INSERT INTO D_JuchuuShousai
                                  (JuchuuNO
                                  ,JuchuuGyouNO
                                  ,JuchuuShousaiNO
                                  ,SoukoCD
                                  ,ShouhinCD
                                  ,ShouhinName
                                  ,JuchuuSuu
                                  ,KanriNO
                                  ,NyuukoDate
                                  ,HikiateZumiSuu
                                  ,MiHikiateSuu
                                  ,ShukkaSiziZumiSuu
                                  ,ShukkaZumiSuu
                                  ,UriageZumiSuu
                                  ,HacchuuNO
                                  ,HacchuuGyouNO
                                  ,InsertOperator
                                  ,InsertDateTime
                                  ,UpdateOperator
                                  ,UpdateDateTime)
                                  SELECT JuchuuNO
                                       ,JuchuuGyouNO
                                       ,@JuchuuShousaiNO_11
                                       ,SoukoCD
                                       ,ShouhinCD
                                       ,ShouhinName
                                       ,@ChakuniSuu
                                       ,@KanriNO
                                       ,''
                                       ,@HikiateZumiSuu_Chouseigo_11
                                       ,0
                                       ,@ShukkaSiziZumiSuu_Chouseigo_11
                                       ,0
                                       ,0
                                       ,HacchuuNO
                                       ,HacchuuGyouNO
                                       ,@UpdateOperator
                                       ,@UpdateDateTime
                                       ,@UpdateOperator
                                       ,@UpdateDateTime
                                   FROM D_JuchuuMeisai
			    			       WHERE JuchuuNO = @JuchuuNO
			    			       AND JuchuuGyouNO = @JuchuuGyouNO
			    			   END
			    			   ELSE
			    			   BEGIN
			    			      UPDATE D_JuchuuShousai
			    			      SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			         ,ShukkaSiziZumiSuu = ShukkaSiziZumiSuu - @ChakuniSuu
			    			         ,UpdateOperator = @UpdateOperator
			    			         ,UpdateDateTime = @UpdateDateTime
			    			      WHERE JuchuuNO = @JuchuuNO
			    		          AND JuchuuGyouNO = @JuchuuGyouNO
			    		          AND KanriNO = @KanriNO
			    			      AND NyuukoDate = @NyuukoDate
			    			      
			    			      INSERT INTO D_JuchuuShousai
                                  (JuchuuNO
                                  ,JuchuuGyouNO
                                  ,JuchuuShousaiNO
                                  ,SoukoCD
                                  ,ShouhinCD
                                  ,ShouhinName
                                  ,JuchuuSuu
                                  ,KanriNO
                                  ,NyuukoDate
                                  ,HikiateZumiSuu
                                  ,MiHikiateSuu
                                  ,ShukkaSiziZumiSuu
                                  ,ShukkaZumiSuu
                                  ,UriageZumiSuu
                                  ,HacchuuNO
                                  ,HacchuuGyouNO
                                  ,InsertOperator
                                  ,InsertDateTime
                                  ,UpdateOperator
                                  ,UpdateDateTime)
                                  SELECT JuchuuNO
                                       ,JuchuuGyouNO
                                       ,@JuchuuShousaiNO_11
                                       ,SoukoCD
                                       ,ShouhinCD
                                       ,ShouhinName
                                       ,@ChakuniSuu
                                       ,@KanriNO
                                       ,''
                                       ,0
                                       ,0
                                       ,@ChakuniSuu
                                       ,0
                                       ,0
                                       ,HacchuuNO
                                       ,HacchuuGyouNO
                                       ,@UpdateOperator
                                       ,@UpdateDateTime
                                       ,@UpdateOperator
                                       ,@UpdateDateTime
                                   FROM D_JuchuuMeisai
			    			       WHERE JuchuuNO = @JuchuuNO
			    			       AND JuchuuGyouNO = @JuchuuGyouNO
			    			   END
			    			END
			    			ELSE
			    			BEGIN
			    			   UPDATE D_JuchuuShousai
			    			   SET JuchuuSuu = JuchuuSuu - @ChakuniSuu
			    			      ,HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziZumiSuu_11)
			    			      ,ShukkaSiziZumiSuu = 0
			    				  ,UpdateOperator = @UpdateOperator
			    				  ,UpdateDateTime = @UpdateDateTime
			    			   WHERE JuchuuNO = @JuchuuNO
			    		       AND JuchuuGyouNO = @JuchuuGyouNO
			    		       AND KanriNO = @KanriNO
			    			   AND NyuukoDate = @NyuukoDate
			    
			    			   INSERT INTO D_JuchuuShousai
                               (JuchuuNO
                               ,JuchuuGyouNO
                               ,JuchuuShousaiNO
                               ,SoukoCD
                               ,ShouhinCD
                               ,ShouhinName
                               ,JuchuuSuu
                               ,KanriNO
                               ,NyuukoDate
                               ,HikiateZumiSuu
                               ,MiHikiateSuu
                               ,ShukkaSiziZumiSuu
                               ,ShukkaZumiSuu
                               ,UriageZumiSuu
                               ,HacchuuNO
                               ,HacchuuGyouNO
                               ,InsertOperator
                               ,InsertDateTime
                               ,UpdateOperator
                               ,UpdateDateTime)
                               SELECT JuchuuNO
                                    ,JuchuuGyouNO
                                    ,@JuchuuShousaiNO_11
                                    ,SoukoCD
                                    ,ShouhinCD
                                    ,ShouhinName
                                    ,@ChakuniSuu
                                    ,@KanriNO
                                    ,''
                                    ,@ChakuniSuu - @ShukkaSiziZumiSuu_11
                                    ,0
                                    ,@ShukkaSiziZumiSuu_11
                                    ,0
                                    ,0
                                    ,HacchuuNO
                                    ,HacchuuGyouNO
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
                                FROM D_JuchuuMeisai
			    			    WHERE JuchuuNO = @JuchuuNO
			    			    AND JuchuuGyouNO = @JuchuuGyouNO
			    			END
			    
			    			DELETE D_JuchuuShousai
			    			WHERE JuchuuNO = @JuchuuNO
			    		    AND JuchuuGyouNO = @JuchuuGyouNO
			    		    AND KanriNO = @KanriNO
			    			AND NyuukoDate = @NyuukoDate
			    			AND HikiateZumiSuu = 0
			    			AND ShukkaSiziZumiSuu = 0
			    	     END
			    		 ELSE
			    		 BEGIN
			    		    SELECT 1
			    		 END
			    	  END
			    
			    	  DELETE DJUS
			    	  FROM D_JuchuuShousai DJUS
			    	  WHERE JuchuuNO = @JuchuuNO
			    	  AND JuchuuGyouNO = @JuchuuGyouNO
			    	  AND SoukoCD = @SoukoCD
			          AND ShouhinCD = @ShouhinCD
			    	  AND JuchuuSuu = 0 
			    	  AND ShukkaSiziZumiSuu = 0
			    	  AND HikiateZumiSuu = 0
			    
			    	  UPDATE DJUS
			          SET HacchuuNO = DJUM.HacchuuNO
			          	 ,HacchuuGyouNO = DJUM.HacchuuGyouNO
			    		 ,UpdateOperator = @UpdateOperator
			    		 ,UpdateDateTime = @UpdateDateTime
			          FROM D_JuchuuMeisai DJUM
			    	  INNER JOIN D_JuchuuShousai DJUS
			    	  ON DJUS.JuchuuNO = DJUM.JuchuuNO
			    	  AND DJUS.JuchuuGyouNO = DJUM.JuchuuGyouNO
			          WHERE DJUM.JuchuuNO = @JuchuuNO
			          AND DJUM.JuchuuGyouNO = @JuchuuGyouNO
			    	   
			    
			    	  DECLARE @ShukkaSiziSuu_21 DECIMAL(21,6),
			    	          @HikiateZumiSuu_21 DECIMAL(21,6)
			    	  SELECT @ShukkaSiziSuu_21 = ShukkaSiziSuu
			    	        ,@HikiateZumiSuu_21 = HikiateZumiSuu
			    	  FROM D_HikiateZaiko
			    	  WHERE SoukoCD = @SoukoCD
			          AND ShouhinCD = @ShouhinCD
			          AND KanriNO = @KanriNO
			          AND NyuukoDate = @NyuukoDate
			    
			    	  IF EXISTS (
			    	               SELECT *
			    				   FROM D_HikiateZaiko
			    				   WHERE SoukoCD = @SoukoCD
			                       AND ShouhinCD = @ShouhinCD
			                       AND KanriNO = @KanriNO
			                       AND ISNULL(NyuukoDate, '') = ''
			    	            )
			    	  BEGIN
			    	     IF (@ShukkaSiziSuu_21 >= @ChakuniSuu) 
			    	     BEGIN
			    			IF (@HikiateZumiSuu_21 > 0)
			    			BEGIN
			    			   DECLARE @ShukkaSiziSuu_Chouseigo_21 DECIMAL(21, 6)
			    			   DECLARE @HikiateZumiSuu_Chouseigo_21 DECIMAL(21, 6)
			    			   SELECT @ShukkaSiziSuu_Chouseigo_21 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    			   	                                         THEN CAST(0 AS DECIMAL(21, 6))
			    			   					 	                     ELSE @ChakuniSuu - HikiateZumiSuu
			    			   					                    END
			    			         ,@HikiateZumiSuu_Chouseigo_21 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    			   	                                          THEN @ChakuniSuu
			    			   					 	                      ELSE HikiateZumiSuu
			    			   					                     END
			    			   FROM D_HikiateZaiko
			    			   WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
			    			   
			    	           UPDATE D_HikiateZaiko
			    	           SET ShukkaSiziSuu = ShukkaSiziSuu - @ShukkaSiziSuu_Chouseigo_21
			    			      ,HikiateZumiSuu = HikiateZumiSuu - @HikiateZumiSuu_Chouseigo_21
			    			      ,UpdateOperator = @UpdateOperator
			                      ,UpdateDateTime = @UpdateDateTime
			    	           WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
			    			   
			    			   UPDATE D_HikiateZaiko
			    	           SET ShukkaSiziSuu = ShukkaSiziSuu + @ShukkaSiziSuu_Chouseigo_21
			    			      ,HikiateZumiSuu = HikiateZumiSuu + @HikiateZumiSuu_Chouseigo_21
			    			      ,UpdateOperator = @UpdateOperator
			                      ,UpdateDateTime = @UpdateDateTime
			    	           WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND ISNULL(NyuukoDate, '') = ''
			    			END
			    			ELSE
			    			BEGIN
			    	           UPDATE D_HikiateZaiko
			    	           SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
			    			      ,UpdateOperator = @UpdateOperator
			                      ,UpdateDateTime = @UpdateDateTime
			    	           WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
			    			   
			    			   UPDATE D_HikiateZaiko
			    	           SET ShukkaSiziSuu = ShukkaSiziSuu + @ChakuniSuu
			    			      ,UpdateOperator = @UpdateOperator
			                      ,UpdateDateTime = @UpdateDateTime
			    	           WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND ISNULL(NyuukoDate, '') = ''
			    			END
			    	     END
			    		 ELSE
			    		 BEGIN
			    	        UPDATE D_HikiateZaiko
			    	        SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_21)
			    			   ,ShukkaSiziSuu = 0
			    			   ,UpdateOperator = @UpdateOperator
			                   ,UpdateDateTime = @UpdateDateTime
			    	        WHERE SoukoCD = @SoukoCD
			                AND ShouhinCD = @ShouhinCD
			                AND KanriNO = @KanriNO
			                AND NyuukoDate = @NyuukoDate
			    
			    			UPDATE D_HikiateZaiko
			    	        SET HikiateZumiSuu = HikiateZumiSuu + (@ChakuniSuu - @ShukkaSiziSuu_21)
			    			   ,ShukkaSiziSuu = ShukkaSiziSuu + @ShukkaSiziSuu_21
			    			   ,UpdateOperator = @UpdateOperator
			                   ,UpdateDateTime = @UpdateDateTime
			    	        WHERE SoukoCD = @SoukoCD
			                AND ShouhinCD = @ShouhinCD
			                AND KanriNO = @KanriNO
			                AND ISNULL(NyuukoDate, '') = ''
			    		 END
			             
			    		 DELETE D_HikiateZaiko
			             WHERE SoukoCD = @SoukoCD
			             AND ShouhinCD = @ShouhinCD
			             AND KanriNO = @KanriNO
			             AND NyuukoDate = @NyuukoDate
			    		 AND ShukkaSiziSuu = 0
			    		 AND HikiateZumiSuu = 0
		              END
			    	  ELSE
			    	  BEGIN
			    	     IF (@ShukkaSiziSuu_21 >= @ChakuniSuu) 
			    	     BEGIN
			    			IF (@HikiateZumiSuu_21 > 0)
			    			BEGIN
			    			   DECLARE @ShukkaSiziSuu_Chouseigo_211 DECIMAL(21, 6)
			    			   DECLARE @HikiateZumiSuu_Chouseigo_211 DECIMAL(21, 6)
			    			   SELECT @ShukkaSiziSuu_Chouseigo_211 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    			   	                                          THEN CAST(0 AS DECIMAL(21, 6))
			    			   					 	                      ELSE @ChakuniSuu - HikiateZumiSuu
			    			   					                     END
			    			         ,@HikiateZumiSuu_Chouseigo_211 = CASE WHEN HikiateZumiSuu - @ChakuniSuu > 0
			    			   	                                           THEN @ChakuniSuu
			    			   					 	                       ELSE HikiateZumiSuu
			    			   					                      END
			    			   FROM D_HikiateZaiko
			    			   WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
			    
			    	           UPDATE D_HikiateZaiko
			    	           SET ShukkaSiziSuu = ShukkaSiziSuu - @ShukkaSiziSuu_Chouseigo_211
			    			      ,HikiateZumiSuu = HikiateZumiSuu - @HikiateZumiSuu_Chouseigo_211
			    			      ,UpdateOperator = @UpdateOperator
			                      ,UpdateDateTime = @UpdateDateTime
			    	           WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
			    			   
			    			   INSERT INTO D_HikiateZaiko
                               (SoukoCD
                               ,ShouhinCD
                               ,KanriNO
                               ,NyuukoDate
                               ,ShukkaSiziSuu
                               ,HikiateZumiSuu
                               ,InsertOperator
                               ,InsertDateTime
                               ,UpdateOperator
                               ,UpdateDateTime)
                               SELECT @SoukoCD
                                    ,@ShouhinCD
                                    ,@KanriNO
                                    ,''
                                    ,@ShukkaSiziSuu_Chouseigo_211
                                    ,@HikiateZumiSuu_Chouseigo_211
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
			    			END
			    			ELSE
			    			BEGIN
			    	           UPDATE D_HikiateZaiko
			    	           SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
			    			      ,UpdateOperator = @UpdateOperator
			                      ,UpdateDateTime = @UpdateDateTime
			    	           WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
			    			   
			    			   INSERT INTO D_HikiateZaiko
                               (SoukoCD
                               ,ShouhinCD
                               ,KanriNO
                               ,NyuukoDate
                               ,ShukkaSiziSuu
                               ,HikiateZumiSuu
                               ,InsertOperator
                               ,InsertDateTime
                               ,UpdateOperator
                               ,UpdateDateTime)
                               SELECT @SoukoCD
                                    ,@ShouhinCD
                                    ,@KanriNO
                                    ,''
                                    ,@ChakuniSuu
                                    ,0
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
                                    ,@UpdateOperator
                                    ,@UpdateDateTime
			    			END
			    	     END
			    		 ELSE
			    		 BEGIN
			    	        UPDATE D_HikiateZaiko
			    	        SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_21)
			    			   ,ShukkaSiziSuu = 0
			    			   ,UpdateOperator = @UpdateOperator
			                   ,UpdateDateTime = @UpdateDateTime
			    	        WHERE SoukoCD = @SoukoCD
			                AND ShouhinCD = @ShouhinCD
			                AND KanriNO = @KanriNO
			                AND NyuukoDate = @NyuukoDate
			    
			    			INSERT INTO D_HikiateZaiko
                            (SoukoCD
                            ,ShouhinCD
                            ,KanriNO
                            ,NyuukoDate
                            ,ShukkaSiziSuu
                            ,HikiateZumiSuu
                            ,InsertOperator
                            ,InsertDateTime
                            ,UpdateOperator
                            ,UpdateDateTime)
                            SELECT @SoukoCD
                                 ,@ShouhinCD
                                 ,@KanriNO
                                 ,''
                                 ,@ShukkaSiziSuu_21
                                 ,@ChakuniSuu - @ShukkaSiziSuu_21
                                 ,@UpdateOperator
                                 ,@UpdateDateTime
                                 ,@UpdateOperator
                                 ,@UpdateDateTime
			    		 END
			             
			    		 DELETE D_HikiateZaiko
			             WHERE SoukoCD = @SoukoCD
			             AND ShouhinCD = @ShouhinCD
			             AND KanriNO = @KanriNO
			             AND NyuukoDate = @NyuukoDate
			    		 AND ShukkaSiziSuu = 0
			    		 AND HikiateZumiSuu = 0
			    	  
			    	  END
			    	  
			    	  
			    	  DELETE DSSS
			    	  FROM D_ShukkaSiziShousai DSSS
			    	  INNER JOIN D_ShukkaSiziMeisai DSSM
			    	  ON DSSS.ShukkaSiziNO = DSSM.ShukkaSiziNO
			    	  AND DSSS.ShukkaSiziGyouNO = DSSM.ShukkaSiziGyouNO
			    	  WHERE DSSS.JuchuuNO = @JuchuuNO
			    	  AND DSSS.JuchuuGyouNO = @JuchuuGyouNO
			    	  AND DSSS.SoukoCD = @SoukoCD
			    	  AND DSSS.ShouhinCD = @ShouhinCD
			    	  AND DSSS.KanriNO = @KanriNO
			    	  AND (DSSS.NyuukoDate = @NyuukoDate OR ISNULL(DSSS.NyuukoDate, '') = '')
			    	  AND DSSM.ShukkaKanryouKBN = 0
			    	  AND DSSM.ShukkaZumiSuu = 0
			    
			    	  DECLARE @JuchuuShousaiNO_31 smallint = CAST(0 AS smallint),
			    	          @NyuukoDate_31 varchar(10),
			    	          @ShukkaSiziZumiSuu_31 decimal(21, 6)
			    	  SELECT @JuchuuShousaiNO_31 = JuchuuShousaiNO 
			    	        ,@NyuukoDate_31 = NyuukoDate
			    	        ,@ShukkaSiziZumiSuu_31 = ShukkaSiziZumiSuu
                      FROM D_JuchuuShousai
			    	  WHERE JuchuuNO = @JuchuuNO
			    	  AND JuchuuGyouNO = @JuchuuGyouNO
			    	  AND SoukoCD = @SoukoCD
			    	  AND ShouhinCD = @ShouhinCD
			    	  AND KanriNO = @KanriNO
			    	  AND NyuukoDate = @NyuukoDate
			    
			    	  IF (ISNULL(@JuchuuShousaiNO_31, CAST(0 AS smallint)) = CAST(0 AS smallint))
			    	  BEGIN
			    	     SELECT @JuchuuShousaiNO_31 = JuchuuShousaiNO 
			    		    ,@NyuukoDate_31 = NyuukoDate
			    	        ,@ShukkaSiziZumiSuu_31 = ShukkaSiziZumiSuu
                         FROM D_JuchuuShousai
			    	     WHERE JuchuuNO = @JuchuuNO
			    	     AND JuchuuGyouNO = @JuchuuGyouNO
			    	     AND SoukoCD = @SoukoCD
			    	     AND ShouhinCD = @ShouhinCD
			    	     AND KanriNO = @KanriNO
			    	     AND ISNULL(NyuukoDate, '') = ''
			    	  END
			    
			    
			    	  DECLARE @ShukkaSiziNO_31 varchar(12),
                              @ShukkaSiziGyouNO_31 smallint,
			    	   	      @MeisaiShukkaSiziSuuZan_31 decimal(21, 6),
			    			  @CUR_ShukkaSiziShousaiNO_31 smallint
                           
                      DECLARE cursorShukkaSiziMeisai CURSOR READ_ONLY
                      FOR
                      SELECT DSSM.ShukkaSiziNO 
			    	        ,DSSM.ShukkaSiziGyouNO
			    	   	    ,DSSM.ShukkaSiziSuu - ISNULL(DSSS.ShukkaSiziSuu, CAST(0 AS DECIMAL(21, 6))) 
                      FROM D_ShukkaSiziMeisai DSSM
			    	  LEFT OUTER JOIN (
			    	                     SELECT ShukkaSiziNO, ShukkaSiziGyouNO, SUM(ShukkaSiziSuu) ShukkaSiziSuu
			    						 FROM D_ShukkaSiziShousai 
			    						 WHERE JuchuuNO = @JuchuuNO
			    	                     AND JuchuuGyouNO = @JuchuuGyouNO
			    						 GROUP BY ShukkaSiziNO, ShukkaSiziGyouNO
			    					  ) DSSS
			    	  ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
			    	  AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
			    	  WHERE DSSM.JuchuuNO = @JuchuuNO
			    	  AND DSSM.JuchuuGyouNO = @JuchuuGyouNO
			    	  AND (DSSM.ShukkaKanryouKBN = 0 OR DSSM.ShukkaZumiSuu = 0)
                      ORDER BY DSSM.ShukkaSiziNO, DSSM.ShukkaSiziGyouNO
			    
                      OPEN cursorShukkaSiziMeisai
                             
                      FETCH NEXT FROM cursorShukkaSiziMeisai INTO @ShukkaSiziNO_31, @ShukkaSiziGyouNO_31, @MeisaiShukkaSiziSuuZan_31
                      WHILE @@FETCH_STATUS = 0
                      BEGIN
			    		 SET @CUR_ShukkaSiziShousaiNO_31 = 0
			    
			    		 SELECT @CUR_ShukkaSiziShousaiNO_31 = MAX(ISNULL(DSSS.ShukkaSiziShousaiNO, 0)) + 1
			    		 FROM D_ShukkaSiziMeisai DSSM
			    		 LEFT OUTER JOIN D_ShukkaSiziShousai DSSS
			    		 ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
			    		 AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
			    		 WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO_31
			    		 AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO_31
			    		 
			    		 IF(@MeisaiShukkaSiziSuuZan_31 > @ShukkaSiziZumiSuu_31)
			    		 BEGIN
			    		     INSERT INTO D_ShukkaSiziShousai
                             (ShukkaSiziNO
                             ,ShukkaSiziGyouNO
                             ,ShukkaSiziShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,ShukkaSiziSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaZumiSuu
                             ,JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                             SELECT ShukkaSiziNO
                                  ,ShukkaSiziGyouNO
                                  ,@CUR_ShukkaSiziShousaiNO_31
                                  ,@SoukoCD
                                  ,@ShouhinCD
                                  ,ShouhinName
                                  ,@ShukkaSiziZumiSuu_31
                                  ,@KanriNO
                                  ,@NyuukoDate_31
                                  ,0
                                  ,JuchuuNO
                                  ,JuchuuGyouNO
                                  ,@JuchuuShousaiNO_31
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                              FROM D_ShukkaSiziMeisai
			    		      WHERE ShukkaSiziNO = @ShukkaSiziNO_31
			    		      AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO_31
			    
			    		     INSERT INTO D_ShukkaSiziShousai
                             (ShukkaSiziNO
                             ,ShukkaSiziGyouNO
                             ,ShukkaSiziShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,ShukkaSiziSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaZumiSuu
                             ,JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                             SELECT ShukkaSiziNO
                                  ,ShukkaSiziGyouNO
                                  ,@CUR_ShukkaSiziShousaiNO_31 + 1
                                  ,@SoukoCD
                                  ,@ShouhinCD
                                  ,ShouhinName
                                  ,@MeisaiShukkaSiziSuuZan_31 - @ShukkaSiziZumiSuu_31
                                  ,@KanriNO
                                  ,''
                                  ,0
                                  ,JuchuuNO
                                  ,JuchuuGyouNO
                                  ,(SELECT TOP 1 JuchuuShousaiNO FROM D_JuchuuShousai WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND KanriNO = @KanriNO AND ISNULL(NyuukoDate, '') = '')
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                              FROM D_ShukkaSiziMeisai
			    		      WHERE ShukkaSiziNO = @ShukkaSiziNO_31
			    		      AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO_31
			    			  AND @MeisaiShukkaSiziSuuZan_31 - @ShukkaSiziZumiSuu_31 > 0
			    		 END
			    		 ELSE IF(@MeisaiShukkaSiziSuuZan_31 <= @ShukkaSiziZumiSuu_31 AND @MeisaiShukkaSiziSuuZan_31 > 0)
			    		 BEGIN
			    		     INSERT INTO D_ShukkaSiziShousai
                             (ShukkaSiziNO
                             ,ShukkaSiziGyouNO
                             ,ShukkaSiziShousaiNO
                             ,SoukoCD
                             ,ShouhinCD
                             ,ShouhinName
                             ,ShukkaSiziSuu
                             ,KanriNO
                             ,NyuukoDate
                             ,ShukkaZumiSuu
                             ,JuchuuNO
                             ,JuchuuGyouNO
                             ,JuchuuShousaiNO
                             ,InsertOperator
                             ,InsertDateTime
                             ,UpdateOperator
                             ,UpdateDateTime)
                             SELECT ShukkaSiziNO
                                  ,ShukkaSiziGyouNO
                                  ,@CUR_ShukkaSiziShousaiNO_31
                                  ,@SoukoCD
                                  ,@ShouhinCD
                                  ,ShouhinName
                                  ,@MeisaiShukkaSiziSuuZan_31
                                  ,@KanriNO
                                  ,@NyuukoDate_31
                                  ,0
                                  ,JuchuuNO
                                  ,JuchuuGyouNO
                                  ,@JuchuuShousaiNO_31
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                                  ,@UpdateOperator
                                  ,@UpdateDateTime
                              FROM D_ShukkaSiziMeisai
			    		      WHERE ShukkaSiziNO = @ShukkaSiziNO_31
			    		      AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO_31
			    
			    		 END
			    	    
			    	     FETCH NEXT FROM cursorShukkaSiziMeisai INTO @ShukkaSiziNO_31, @ShukkaSiziGyouNO_31, @MeisaiShukkaSiziSuuZan_31
		              END
	                  CLOSE cursorShukkaSiziMeisai
	                  DEALLOCATE cursorShukkaSiziMeisai
			    
			    	  --2021/05/26 Y.Nishikawa ADD RemakeÅ´Å´
			    	  END
			    	  --2021/05/26 Y.Nishikawa ADD RemakeÅ™Å™
			    
			    	  --2021/06/07 Y.Nishikawa ADD RemakeÅ´Å´
			    	  ----2021/04/27 Y.Nishikawa DEL Remake
      --                IF EXISTS ( 
      --                            SELECT * 
      --                            FROM D_GenZaiko DGZK
      --                            INNER JOIN (
      --                			             SELECT H.SoukoCD
      --                						       ,M.ShouhinCD
      --                							   ,M.KanriNO
      --                							   ,H.ChakuniDate
      --                						 FROM D_Chakuni H
      --                                         INNER JOIN D_ChakuniMeisai M
      --                                         ON H.ChakuniNO = M.ChakuniNO
      --                                         WHERE H.ChakuniNO = @ChakuniNO
			    			--				   --2021/05/07 Y.Nishikawa ADD Remake
			    			--				   AND M.ChakuniGyouNO = @ChakuniGyouNO
			    			--				   --2021/05/07 Y.Nishikawa ADD Remake
      --                			           ) DCKM
      --                                           ON DGZK.SoukoCD = DCKM.SoukoCD
      --                                           AND DGZK.ShouhinCD = DCKM.ShouhinCD
      --                                           AND DGZK.KanriNO = DCKM.KanriNO
      --                                           AND DGZK.NyuukoDate = DCKM.ChakuniDate
      --                           )
      --                BEGIN
                      
      --                   UPDATE DGZK
      --                      SET GenZaikoSuu = GenZaikoSuu - DCKM.ChakuniSuu
      --                         ,UpdateOperator = @UpdateOperator
      --                         ,UpdateDateTime = @UpdateDateTime
      --                	FROM D_GenZaiko DGZK
      --                	INNER JOIN (
      --                			      SELECT H.SoukoCD
      --                		         	    ,M.ShouhinCD
      --                		         	    ,M.KanriNO
      --                		         	    ,H.ChakuniDate
      --                						,M.ChakuniSuu
      --                		          FROM D_Chakuni H
      --                                  INNER JOIN D_ChakuniMeisai M
      --                                  ON H.ChakuniNO = M.ChakuniNO
      --                                  WHERE H.ChakuniNO = @ChakuniNO
			    			--			--2021/05/07 Y.Nishikawa ADD Remake
			    			--			AND M.ChakuniGyouNO = @ChakuniGyouNO
			    			--			--2021/05/07 Y.Nishikawa ADD Remake
      --                			    ) DCKM
      --                   ON DGZK.SoukoCD = DCKM.SoukoCD
      --                   AND DGZK.ShouhinCD = DCKM.ShouhinCD
      --                   AND DGZK.KanriNO = DCKM.KanriNO
      --                   AND DGZK.NyuukoDate = DCKM.ChakuniDate
      --                END
      --                ELSE
      --                BEGIN
                      
      --                   INSERT INTO D_GenZaiko
      --                              (SoukoCD
      --                              ,ShouhinCD
      --                              ,KanriNO
      --                              ,NyuukoDate
      --                              ,GenZaikoSuu
      --                              ,IdouSekisouSuu
      --                              ,InsertOperator
      --                              ,InsertDateTime
      --                              ,UpdateOperator
      --                              ,UpdateDateTime)
      --                   SELECT DCKH.SoukoCD
      --                         ,DCKM.ShouhinCD
      --                         ,DCKM.KanriNO
      --                         ,DCKH.ChakuniDate
      --                         ,DCKM.ChakuniSuu * (-1)
      --                         ,0
      --                         ,@UpdateOperator
      --                         ,@UpdateDateTime
      --                         ,@UpdateOperator
      --                         ,@UpdateDateTime
      --                     FROM D_Chakuni DCKH
      --                     INNER JOIN D_ChakuniMeisai DCKM
      --                     ON DCKH.ChakuniNO = DCKM.ChakuniNO
      --                     WHERE DCKH.ChakuniNO = @ChakuniNO
			    		 --  --2021/05/07 Y.Nishikawa ADD Remake
			    		 --  AND DCKM.ChakuniGyouNO = @ChakuniGyouNO
			    		 --  --2021/05/07 Y.Nishikawa ADD Remake
                      
      --                END
      --        		--2021/04/27 Y.Nishikawa ADD Remake
			    	--2021/06/07 Y.Nishikawa DEL RemakeÅ™Å™
			    
			    END
			    --2021/04/20 Y.Nishikawa CHG Remake
			END

			fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ChakuniSuu,@JuchuuNO,@JuchuuGyouNO

		end
		
	close cursorOuter
	deallocate cursorOuter

	--2021/06/07 Y.Nishikawa ADD RemakeÅ´Å´
	declare @ChakuniNo_Zaiko  as varchar(12),
		@ChakuniGyouNO_Zaiko as smallint,
		@SoukoCD_Zaiko as varchar(10),
		@ShouhinCD_Zaiko as varchar(50),
		@KanriNO_Zaiko as varchar(10),
		@NyuukoDate_Zaiko as varchar(10),
		@ChakuniSuu_Zaiko as decimal(21,6)

	declare cursorZaiko cursor read_only
	for
	select cm.ChakuniNO,cm.ChakuniGyouNO,c.SoukoCD,cm.ShouhinCD,cm.KanriNO,c.ChakuniDate,cm.ChakuniSuu
	from D_ChakuniMeisai cm inner join D_Chakuni c on cm.ChakuniNO = c.ChakuniNO
	where cm.ChakuniNO = @SlipNo
	
	open cursorZaiko
	
	fetch next from cursorZaiko into @ChakuniNo_Zaiko,@ChakuniGyouNO_Zaiko,@SoukoCD_Zaiko,@ShouhinCD_Zaiko,@KanriNO_Zaiko,@NyuukoDate_Zaiko,@ChakuniSuu_Zaiko
	while @@FETCH_STATUS = 0
		begin
			IF (@ProcessKBN = 10 OR @ProcessKBN = 21)
			BEGIN
				  IF EXISTS ( 
                               SELECT * 
                               FROM D_GenZaiko DGZK
                               INNER JOIN (
                   			             SELECT H.SoukoCD
                   						       ,M.ShouhinCD
                   							   ,M.KanriNO
                   							   ,H.ChakuniDate
                   						 FROM D_Chakuni H
                                            INNER JOIN D_ChakuniMeisai M
                                            ON H.ChakuniNO = M.ChakuniNO
                                            WHERE H.ChakuniNO = @ChakuniNO_Zaiko
											AND M.ChakuniGyouNO = @ChakuniGyouNO_Zaiko
                   			           ) DCKM
                                              ON DGZK.SoukoCD = DCKM.SoukoCD
                                              AND DGZK.ShouhinCD = DCKM.ShouhinCD
                                              AND DGZK.KanriNO = DCKM.KanriNO
                                              AND DGZK.NyuukoDate = DCKM.ChakuniDate
                              )
                   BEGIN
                   
                      UPDATE DGZK
                         SET GenZaikoSuu = GenZaikoSuu + DCKM.ChakuniSuu
                            ,UpdateOperator = @UpdateOperator
                            ,UpdateDateTime = @UpdateDateTime
                   	FROM D_GenZaiko DGZK
                   	INNER JOIN (
                   			      SELECT H.SoukoCD
                   		         	    ,M.ShouhinCD
                   		         	    ,M.KanriNO
                   		         	    ,H.ChakuniDate
                   						,M.ChakuniSuu
                   		          FROM D_Chakuni H
                                     INNER JOIN D_ChakuniMeisai M
                                     ON H.ChakuniNO = M.ChakuniNO
                                     WHERE H.ChakuniNO = @ChakuniNO_Zaiko
									 AND M.ChakuniGyouNO = @ChakuniGyouNO_Zaiko
                   			    ) DCKM
                      ON DGZK.SoukoCD = DCKM.SoukoCD
                      AND DGZK.ShouhinCD = DCKM.ShouhinCD
                      AND DGZK.KanriNO = DCKM.KanriNO
                      AND DGZK.NyuukoDate = DCKM.ChakuniDate
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
                      SELECT DCKH.SoukoCD
                            ,DCKM.ShouhinCD
                            ,DCKM.KanriNO
                            ,DCKH.ChakuniDate
                            ,DCKM.ChakuniSuu
                            ,0
                            ,@UpdateOperator
                            ,@UpdateDateTime
                            ,@UpdateOperator
                            ,@UpdateDateTime
                        FROM D_Chakuni DCKH
                        INNER JOIN D_ChakuniMeisai DCKM
                        ON DCKH.ChakuniNO = DCKM.ChakuniNO
                        WHERE DCKH.ChakuniNO = @ChakuniNO_Zaiko
						AND DCKM.ChakuniGyouNO = @ChakuniGyouNO_Zaiko
                   END
			END
			ELSE
			BEGIN
                  IF EXISTS ( 
                              SELECT * 
                              FROM D_GenZaiko DGZK
                              INNER JOIN (
                  			             SELECT H.SoukoCD
                  						       ,M.ShouhinCD
                  							   ,M.KanriNO
                  							   ,H.ChakuniDate
                  						 FROM D_Chakuni H
                                           INNER JOIN D_ChakuniMeisai M
                                           ON H.ChakuniNO = M.ChakuniNO
                                           WHERE H.ChakuniNO = @ChakuniNO_Zaiko
										   AND M.ChakuniGyouNO = @ChakuniGyouNO_Zaiko
                  			           ) DCKM
                                             ON DGZK.SoukoCD = DCKM.SoukoCD
                                             AND DGZK.ShouhinCD = DCKM.ShouhinCD
                                             AND DGZK.KanriNO = DCKM.KanriNO
                                             AND DGZK.NyuukoDate = DCKM.ChakuniDate
                             )
                  BEGIN
                  
                     UPDATE DGZK
                        SET GenZaikoSuu = GenZaikoSuu - DCKM.ChakuniSuu
                           ,UpdateOperator = @UpdateOperator
                           ,UpdateDateTime = @UpdateDateTime
                  	FROM D_GenZaiko DGZK
                  	INNER JOIN (
                  			      SELECT H.SoukoCD
                  		         	    ,M.ShouhinCD
                  		         	    ,M.KanriNO
                  		         	    ,H.ChakuniDate
                  						,M.ChakuniSuu
                  		          FROM D_Chakuni H
                                    INNER JOIN D_ChakuniMeisai M
                                    ON H.ChakuniNO = M.ChakuniNO
                                    WHERE H.ChakuniNO = @ChakuniNO_Zaiko
									AND M.ChakuniGyouNO = @ChakuniGyouNO_Zaiko
                  			    ) DCKM
                     ON DGZK.SoukoCD = DCKM.SoukoCD
                     AND DGZK.ShouhinCD = DCKM.ShouhinCD
                     AND DGZK.KanriNO = DCKM.KanriNO
                     AND DGZK.NyuukoDate = DCKM.ChakuniDate
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
                     SELECT DCKH.SoukoCD
                           ,DCKM.ShouhinCD
                           ,DCKM.KanriNO
                           ,DCKH.ChakuniDate
                           ,DCKM.ChakuniSuu * (-1)
                           ,0
                           ,@UpdateOperator
                           ,@UpdateDateTime
                           ,@UpdateOperator
                           ,@UpdateDateTime
                       FROM D_Chakuni DCKH
                       INNER JOIN D_ChakuniMeisai DCKM
                       ON DCKH.ChakuniNO = DCKM.ChakuniNO
                       WHERE DCKH.ChakuniNO = @ChakuniNO_Zaiko
					   AND DCKM.ChakuniGyouNO = @ChakuniGyouNO_Zaiko
                  
                  END
			END

			fetch next from cursorZaiko into @ChakuniNo_Zaiko,@ChakuniGyouNO_Zaiko,@SoukoCD_Zaiko,@ShouhinCD_Zaiko,@KanriNO_Zaiko,@NyuukoDate_Zaiko,@ChakuniSuu_Zaiko

		end
		
	close cursorZaiko
	deallocate cursorZaiko
	--2021/06/07 Y.Nishikawa ADD RemakeÅ™Å™
	
END
GO


