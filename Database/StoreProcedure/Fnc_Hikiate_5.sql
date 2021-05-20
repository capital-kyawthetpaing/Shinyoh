/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/05/19 16:37:42 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_5%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_5]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/05/19 16:37:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	5:着荷 (all in処理区分 10,21,20,30) 
-- History    : 2021/04/20 Y.Nishikawa 条件が不正
--            : 2021/04/27 Y.Nishikawa 在庫更新を引当ファンクション内に移動
--            : 2021/05/07 Y.Nishikawa 条件追加
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
	select cm.ChakuniNO,cm.ChakuniGyouNO,c.SoukoCD,cm.ShouhinCD,cm.KanriNO,c.ChakuniDate,cm.ChakuniSuu,cm.JuchuuNO,cm.JuchuuGyouNO 
	from D_ChakuniMeisai cm inner join D_Chakuni c on cm.ChakuniNO = c.ChakuniNO
	where cm.ChakuniNO = @SlipNo
	
	open cursorOuter
	
	fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ChakuniSuu,@JuchuuNO,@JuchuuGyouNO
	while @@FETCH_STATUS = 0
		begin
			--2021/04/20 Y.Nishikawa CHG 条件が不正
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

			--新規モード(@ProcessKBN = 10)または修正モード修正後(@ProcessKBN = 21)の場合、
			IF (@ProcessKBN = 10 OR @ProcessKBN = 21)
			BEGIN

			      UPDATE D_HikiateZaiko
			      SET NyuukoDate = @NyuukoDate
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE 
			      	SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = ''

				  UPDATE D_JuchuuShousai
			      SET NyuukoDate = @NyuukoDate
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = ''

				  --2021/05/19↓↓
				  IF EXISTS (SELECT * 
				             FROM D_JuchuuShousai DJUS
							 INNER JOIN D_HacchuuMeisai DHAM
							 ON DJUS.JuchuuNO = DHAM.JuchuuNO
							 AND DJUS.JuchuuGyouNO = DHAM.JuchuuGyouNO
					         WHERE DJUS.JuchuuNO = @JuchuuNO
					         AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
							 AND DHAM.ChakuniYoteiKanryouKBN = 1
							 AND DHAM.ChakuniKanryouKBN = 1
							 AND ISNULL(DJUS.NyuukoDate, '') = '')
				  BEGIN
				        UPDATE DJUM
						SET HikiateZumiSuu = @ChakuniSuu
						   ,MiHikiateSuu = JuchuuSuu - @ChakuniSuu
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
						AND ISNULL(DJUS.NyuukoDate, '') = ''

				        DELETE DJUS
						FROM D_JuchuuShousai DJUS
						WHERE JuchuuNO = @JuchuuNO
						AND JuchuuGyouNO = @JuchuuGyouNO
						AND ISNULL(NyuukoDate, '') = ''

						DECLARE @juchuuShousaiNO smallint
						SELECT @juchuuShousaiNO = MAX(DJUS.JuchuuShousaiNO) + 1
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
                                 ,@juchuuShousaiNO
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
			      FROM D_JuchuuShousai DJUS
				  INNER JOIN D_HacchuuMeisai DHAM
				  ON DJUS.HacchuuNO = DHAM.HacchuuNO
				  AND DJUS.HacchuuGyouNO = DHAM.HacchuuGyouNO
			      WHERE DJUS.JuchuuNO = @JuchuuNO
			      AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
				  AND DHAM.ChakuniYoteiKanryouKBN = 1
				  AND DHAM.ChakuniKanryouKBN = 1
				  AND DJUS.MiHikiateSuu > 0
				  --2021/05/19↑↑

				  UPDATE D_ShukkaSiziShousai
			      SET NyuukoDate = @NyuukoDate
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = ''

				  --2021/04/27 Y.Nishikawa ADD 在庫更新を引当ファンクション内に移動
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
                                            WHERE H.ChakuniNO = @ChakuniNO
											--2021/05/07 Y.Nishikawa ADD 条件追加
											AND M.ChakuniGyouNO = @ChakuniGyouNO
											--2021/05/07 Y.Nishikawa ADD 条件追加
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
                                     WHERE H.ChakuniNO = @ChakuniNO
									 --2021/05/07 Y.Nishikawa ADD 条件追加
									 AND M.ChakuniGyouNO = @ChakuniGyouNO
									 --2021/05/07 Y.Nishikawa ADD 条件追加
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
                        WHERE DCKH.ChakuniNO = @ChakuniNO
                        --2021/05/07 Y.Nishikawa ADD 譚｡莉ｶ霑ｽ蜉竊凪・
						AND DCKM.ChakuniGyouNO = @ChakuniGyouNO
						--2021/05/07 Y.Nishikawa ADD 譚｡莉ｶ霑ｽ蜉竊鯛・
                   END
				  --2021/04/27 Y.Nishikawa ADD  在庫更新を引当ファンクション内に移動

			END
			--修正モード修正前(@ProcessKBN = 20)または削除モード(@ProcessKBN = 30)の場合、
			ELSE
			BEGIN
			
			      UPDATE D_HikiateZaiko
			      SET NyuukoDate = ''
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE 
			      	SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

				  UPDATE D_JuchuuShousai
			      SET NyuukoDate = ''
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

				  --2021/05/19↓↓
				  UPDATE DJUS
			      SET HacchuuNO = DJUM.HacchuuNO
			      	 ,HacchuuGyouNO = DJUM.HacchuuGyouNO
			      FROM D_JuchuuMeisai DJUM
				  INNER JOIN D_JuchuuShousai DJUS
				  ON DJUS.JuchuuNO = DJUM.JuchuuNO
				  AND DJUS.JuchuuGyouNO = DJUM.JuchuuGyouNO
			      WHERE DJUM.JuchuuNO = @JuchuuNO
			      AND DJUM.JuchuuGyouNO = @JuchuuGyouNO
				  --2021/05/19↑↑

				  UPDATE D_ShukkaSiziShousai
			      SET NyuukoDate = ''
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

				  --2021/04/27 Y.Nishikawa ADD  在庫更新を引当ファンクション内に移動
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
                                           WHERE H.ChakuniNO = @ChakuniNO
										   --2021/05/07 Y.Nishikawa ADD 条件追加
										   AND M.ChakuniGyouNO = @ChakuniGyouNO
										   --2021/05/07 Y.Nishikawa ADD 条件追加
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
                                    WHERE H.ChakuniNO = @ChakuniNO
									--2021/05/07 Y.Nishikawa ADD 条件追加
									AND M.ChakuniGyouNO = @ChakuniGyouNO
									--2021/05/07 Y.Nishikawa ADD 条件追加
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
                       WHERE DCKH.ChakuniNO = @ChakuniNO
					   --2021/05/07 Y.Nishikawa ADD 条件追加
					   AND DCKM.ChakuniGyouNO = @ChakuniGyouNO
					   --2021/05/07 Y.Nishikawa ADD 条件追加
                  
                  END
          		--2021/04/27 Y.Nishikawa ADD 在庫更新を引当ファンクション内に移動

			END
			--2021/04/20 Y.Nishikawa CHG 条件が不正

			fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ChakuniSuu,@JuchuuNO,@JuchuuGyouNO

		end
		
	close cursorOuter
	deallocate cursorOuter
	
END
GO


