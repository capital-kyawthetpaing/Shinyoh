/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/05/20 11:12:39 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_5%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_5]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/05/20 11:12:39 ******/
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
			      --１．同一入庫日の受注詳細が既に存在する場合、他の着荷伝票で既に計上済みのため、その受注詳細に足し込む
				  IF EXISTS (
				               SELECT *
							   FROM D_JuchuuShousai
							   WHERE JuchuuNO = @JuchuuNO
							   AND JuchuuGyouNO = @JuchuuGyouNO
							   AND KanriNO = @KanriNO
							   AND NyuukoDate = @NyuukoDate
				            )
				  BEGIN
				      --１－１．入庫日が空の受注詳細が存在するはずなので、その情報を取得
					  DECLARE @JuchuuSuu_1 DECIMAL(21,6),
							  @ShukkaSiziZumiSuu_1 DECIMAL(21,6)

							  SELECT @JuchuuSuu_1 = JuchuuSuu
									,@ShukkaSiziZumiSuu_1 = ShukkaSiziZumiSuu
							  FROM D_JuchuuShousai
							  WHERE JuchuuNO = @JuchuuNO
							  AND JuchuuGyouNO = @JuchuuGyouNO
							  AND KanriNO = @KanriNO
							  AND NyuukoDate = ''
					  
					  --１－２．上記受注詳細から受注数、出荷指示済数、引当済数を差し引く
					  --１－２ー１．今回着荷数が出荷指示済数以下の場合
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

						 --同一入庫日の受注詳細に足し込む
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
					  --１－２ー２．今回着荷数が出荷指示済数より大きい場合
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

						 --同一入庫日の受注詳細に足し込む
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
				  --２．同一入庫日の受注詳細が存在しない場合、入庫日が空白の情報が存在するはずなので、その情報に更新
				  ELSE
				  BEGIN
				      --２－１．他の明細で入庫日が空の受注詳細が存在するはずなので、その情報を取得
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
					      
						  --受注詳細にINSERTする際のキーを取得
					      SELECT @JuchuuShousaiNO_2 = MAX(JuchuuShousaiNO) + 1
						  FROM D_JuchuuShousai
						  WHERE JuchuuNO = @JuchuuNO
					      AND JuchuuGyouNO = @JuchuuGyouNO

					  --２－２．上記受注詳細から受注数、出荷指示済数、引当済数を差し引く
					  --２－２ー１．今回着荷数が出荷指示済数以下の場合
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

						 --受注詳細にINSERT
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
					  --２－２ー２．今回着荷数が出荷指示済数より大きい場合
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

						 --受注詳細にINSERT
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

				  --残っている不要な詳細は削除
				  DELETE DJUS
				  FROM D_JuchuuShousai DJUS
				  WHERE JuchuuNO = @JuchuuNO
				  AND JuchuuGyouNO = @JuchuuGyouNO
				  AND SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
				  AND JuchuuSuu = 0 
				  AND ShukkaSiziZumiSuu = 0
				  AND HikiateZumiSuu = 0

				  --完了区分にチェックを入れて更新した場合、
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
				        --受注明細の引当情報を今回着荷数で更新（引当残を無くす）
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


				  --３．引当在庫
				  --３ー１．同一入庫日で既に引当在庫にデータが存在する場合、
				  IF EXISTS (
				               SELECT *
							   FROM D_HikiateZaiko
							   WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
				            )
				  BEGIN
				     --３ー１－１．入庫日が空の引当情報を格納
					 DECLARE @HikiateZumiSuu_3 DECIMAL(21, 6),
					         @ShukkaSiziSuu_3 DECIMAL(21, 6)
					 SELECT @HikiateZumiSuu_3 = HikiateZumiSuu
					       ,@ShukkaSiziSuu_3 = ShukkaSiziSuu
					 FROM D_HikiateZaiko
					 WHERE SoukoCD = @SoukoCD
			         AND ShouhinCD = @ShouhinCD
			         AND KanriNO = @KanriNO
			         AND NyuukoDate = ''

					 --３ー１－２．今回着荷数が出荷指示数以下の場合
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

						 --同一入庫日の引当在庫に足し込む
						 UPDATE D_HikiateZaiko
					     SET ShukkaSiziSuu = ShukkaSiziSuu + @ChakuniSuu
						    ,UpdateOperator = @UpdateOperator
							,UpdateDateTime = @UpdateDateTime
					     WHERE SoukoCD = @SoukoCD
			             AND ShouhinCD = @ShouhinCD
			             AND KanriNO = @KanriNO
			             AND NyuukoDate = @NyuukoDate
					 END
					 --３－１－３．今回着荷数が出荷指示数より大きい場合
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

						 --同一入庫日の引当在庫に足し込む
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
				  --４．同一入庫日の引当在庫が存在しない場合、入庫日が空白の情報が存在するはずなので、その情報に更新
				  ELSE
				  BEGIN
				      --４－１．入庫日が空の引当在庫が存在するはずなので、その情報を取得
					  DECLARE @HikiateZumiSuu_4 DECIMAL(21, 6),
					          @ShukkaSiziSuu_4 DECIMAL(21, 6)
					  SELECT @HikiateZumiSuu_4 = HikiateZumiSuu
					        ,@ShukkaSiziSuu_4 = ShukkaSiziSuu
					  FROM D_HikiateZaiko
					  WHERE SoukoCD = @SoukoCD
			          AND ShouhinCD = @ShouhinCD
			          AND KanriNO = @KanriNO
			          AND NyuukoDate = ''

					  --４－２．上記引当在庫から出荷指示数、引当済数を差し引く
					  --４－２ー１．今回着荷数が出荷指示数以下の場合
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

						 --引当在庫にINSERT
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
					  --４－２ー２．今回着荷数が出荷指示数より大きい場合
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

						 --引当在庫にINSERT
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


				  --５．出荷指示詳細
				  --ここまでの更新で受注詳細番号が変わっている可能性があるので、同一受注明細・管理番号の受注詳細をベースに、出荷指示詳細を作り直す
				  --同一受注明細・管理番号かつ出荷完了していない出荷指示詳細を削除
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

				  --ここまでの更新で正しくなった受注詳細情報を使用して出荷指示詳細を作成
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

				  --出荷完了していない出荷指示明細を取得し、カーソルをまわす
				  DECLARE @ShukkaSiziNO_5 varchar(12),
                          @ShukkaSiziGyouNO_5 smallint,
				   	      @MeisaiShukkaSiziSuuZan_5 decimal(21, 6),
						  @CUR_ShukkaSiziShousaiNO_5 smallint
                       
                  DECLARE cursorShukkaSiziMeisai CURSOR READ_ONLY
                  FOR
                  SELECT DSSM.ShukkaSiziNO 
				        ,DSSM.ShukkaSiziGyouNO
				   	    ,DSSM.ShukkaSiziSuu - ISNULL(DSSS.ShukkaSiziSuu, CAST(0 AS DECIMAL(21, 6))) --今回の入庫日以外の出荷指示詳細は除く
                  FROM D_ShukkaSiziMeisai DSSM
				  LEFT OUTER JOIN (
				                     --このタイミングで残っている出荷指示詳細は、別の管理番号または入庫日のデータのみ
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
				     --出荷指示詳細番号を採番
					 SET @CUR_ShukkaSiziShousaiNO_5 = 0

					 SELECT @CUR_ShukkaSiziShousaiNO_5 = MAX(ISNULL(DSSS.ShukkaSiziShousaiNO, 0)) + 1
					 FROM D_ShukkaSiziMeisai DSSM--詳細が全て削除されている可能性があるので、明細をメインテーブルにする
					 LEFT OUTER JOIN D_ShukkaSiziShousai DSSS
					 ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					 AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					 WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO_5
					 AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO_5

				     --明細出荷指示残数＞受注詳細の出荷指示済数の場合
					 IF(@MeisaiShukkaSiziSuuZan_5 > @ShukkaSiziZumiSuu_5)
					 BEGIN
					     --受注詳細の出荷指示済数で出荷指示詳細を作成
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

						 --残りを入庫日空白で作成
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
					 END
					 --明細出荷指示残数≦受注詳細の出荷指示済数の場合
					 ELSE
					 BEGIN
					     --受注詳細の出荷指示済数で出荷指示詳細を作成
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
				    
				     FETCH NEXT FROM cursorShukkaSiziMeisai INTO @ShukkaSiziNO_5, @ShukkaSiziGyouNO_5, @MeisaiShukkaSiziSuuZan_5
		          END
	              CLOSE cursorShukkaSiziMeisai
	              DEALLOCATE cursorShukkaSiziMeisai


				  --６．現在庫
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
                        --2021/05/07 Y.Nishikawa ADD 条件追加
						AND DCKM.ChakuniGyouNO = @ChakuniGyouNO
						--2021/05/07 Y.Nishikawa ADD 条件追加
                   END
				  --2021/04/27 Y.Nishikawa ADD  在庫更新を引当ファンクション内に移動

			END
			--修正モード修正前(@ProcessKBN = 20)または削除モード(@ProcessKBN = 30)の場合、
			ELSE
			BEGIN
			      --１．同一入庫日の受注詳細情報を取得
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
				  
				  --入庫日が空の受注詳細が存在する場合、同一入庫日の受注詳細から差し引き、入庫日が空の受注詳細に足し込む
				  IF EXISTS (
				               SELECT *
							   FROM D_JuchuuShousai
							   WHERE JuchuuNO = @JuchuuNO
					           AND JuchuuGyouNO = @JuchuuGyouNO
					           AND KanriNO = @KanriNO
							   AND ISNULL(NyuukoDate, '') = ''
				            )
				  BEGIN
				     --同一入庫日の受注詳細の受注数≧今回着荷数の場合、他の着荷伝票で計上されている（分納）ため、該当受注詳細の出荷指示済数と引当済数で調整する
				     IF (@JuchuuSuu_11 >= @ChakuniSuu)
				     BEGIN
				        --同一入庫日の受注詳細の出荷指示済数≧今回着荷数の場合、
				        IF (@ShukkaSiziZumiSuu_11 >= @ChakuniSuu)
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
						--同一入庫日の受注詳細の出荷指示済数＜今回着荷数の場合、
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

						--UPDATEの結果、引当済数＝０かつ出荷指示済数＝０になった場合、レコード削除
						DELETE D_JuchuuShousai
						WHERE JuchuuNO = @JuchuuNO
					    AND JuchuuGyouNO = @JuchuuGyouNO
					    AND KanriNO = @KanriNO
						AND NyuukoDate = @NyuukoDate
						AND HikiateZumiSuu = 0
						AND ShukkaSiziZumiSuu = 0
				     END
					 --同一入庫日の受注詳細の受注数＜今回着荷数の場合、システム上あり得ない
					 ELSE
					 BEGIN
					    SELECT 1
					 END
				  END
				  --入庫日が空の受注詳細が存在しない場合、同一入庫日の受注詳細から差し引き、入庫日が空の受注詳細を追加
				  ELSE
				  BEGIN
				     --同一入庫日の受注詳細の受注数≧今回着荷数の場合、他の着荷伝票で計上されている（分納）ため、該当受注詳細の出荷指示済数と引当済数で調整する
				     IF (@JuchuuSuu_11 >= @ChakuniSuu)
				     BEGIN
				        --同一入庫日の受注詳細の出荷指示済数≧今回着荷数の場合、
				        IF (@ShukkaSiziZumiSuu_11 >= @ChakuniSuu)
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
						--同一入庫日の受注詳細の出荷指示済数＜今回着荷数の場合、
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

						--UPDATEの結果、引当済数＝０かつ出荷指示済数＝０になった場合、レコード削除
						DELETE D_JuchuuShousai
						WHERE JuchuuNO = @JuchuuNO
					    AND JuchuuGyouNO = @JuchuuGyouNO
					    AND KanriNO = @KanriNO
						AND NyuukoDate = @NyuukoDate
						AND HikiateZumiSuu = 0
						AND ShukkaSiziZumiSuu = 0
				     END
					 --同一入庫日の受注詳細の受注数＜今回着荷数の場合、システム上あり得ない
					 ELSE
					 BEGIN
					    SELECT 1
					 END
				  END

				  --残っている不要な詳細は削除
				  DELETE DJUS
				  FROM D_JuchuuShousai DJUS
				  WHERE JuchuuNO = @JuchuuNO
				  AND JuchuuGyouNO = @JuchuuGyouNO
				  AND SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
				  AND JuchuuSuu = 0 
				  AND ShukkaSiziZumiSuu = 0
				  AND HikiateZumiSuu = 0

				  --2021/05/19↓↓
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
				  --2021/05/19↑↑
				  

				  --２．引当在庫
				  --同一入庫日の出荷指示数と引当済数を取得
				  DECLARE @ShukkaSiziSuu_21 DECIMAL(21,6),
				          @HikiateZumiSuu_21 DECIMAL(21,6)
				  SELECT @ShukkaSiziSuu_21 = ShukkaSiziSuu
				        ,@HikiateZumiSuu_21 = HikiateZumiSuu
				  FROM D_HikiateZaiko
				  WHERE SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

				  --既に引当在庫に同一倉庫・商品・管理番号で入庫日が空白の情報が存在していた場合、
				  --同一入庫日の情報から差し引き、入庫日が空白の引当情報に修正前または削除する着荷数をプラス
				  IF EXISTS (
				               SELECT *
							   FROM D_HikiateZaiko
							   WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND ISNULL(NyuukoDate, '') = ''
				            )
				  BEGIN
				     --出荷指示数≧今回着荷数の場合、
				     IF (@ShukkaSiziSuu_21 >= @ChakuniSuu) 
				     BEGIN
				        --同一入庫日の情報から差し引く
				        UPDATE D_HikiateZaiko
				        SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--入庫日が空白の情報に更新
						UPDATE D_HikiateZaiko
				        SET ShukkaSiziSuu = ShukkaSiziSuu + @ChakuniSuu
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND ISNULL(NyuukoDate, '') = ''
				     END
					 --出荷指示数＜今回着荷数の場合、
					 ELSE
					 BEGIN
					    --同一入庫日の情報から差し引く
				        UPDATE D_HikiateZaiko
				        SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_21)
						   ,ShukkaSiziSuu = 0
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--入庫日が空白の情報に更新
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
			         
				     --マイナス対象の引当在庫について、引当済数と出荷指示数がゼロになった場合（つまり他の着荷で同一入庫日で分納計上が無い場合）、レコード削除
					 DELETE D_HikiateZaiko
			         WHERE SoukoCD = @SoukoCD
			         AND ShouhinCD = @ShouhinCD
			         AND KanriNO = @KanriNO
			         AND NyuukoDate = @NyuukoDate
					 AND ShukkaSiziSuu = 0
					 AND HikiateZumiSuu = 0
		          END
				  --引当在庫に同一倉庫・商品・管理番号で入庫日が空白の情報が存在していない場合、
				  ELSE
				  BEGIN
				     --出荷指示数≧今回着荷数の場合、
				     IF (@ShukkaSiziSuu_21 >= @ChakuniSuu) 
				     BEGIN
				        --同一入庫日の情報から差し引く
				        UPDATE D_HikiateZaiko
				        SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--入庫日が空白の情報に更新
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
				     --出荷指示数＜今回着荷数の場合、
					 ELSE
					 BEGIN
					    --同一入庫日の情報から差し引く
				        UPDATE D_HikiateZaiko
				        SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_21)
						   ,ShukkaSiziSuu = 0
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--入庫日が空白の情報に更新
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
			         
				     --マイナス対象の引当在庫について、引当済数と出荷指示数がゼロになった場合（つまり他の着荷で同一入庫日で分納計上が無い場合）、レコード削除
					 DELETE D_HikiateZaiko
			         WHERE SoukoCD = @SoukoCD
			         AND ShouhinCD = @ShouhinCD
			         AND KanriNO = @KanriNO
			         AND NyuukoDate = @NyuukoDate
					 AND ShukkaSiziSuu = 0
					 AND HikiateZumiSuu = 0
				  
				  END
				  
				  
				  --３．出荷指示詳細
				  --ここまでの更新で受注詳細番号が変わっている可能性があるので、同一受注明細・管理番号の受注詳細をベースに、出荷指示詳細を作り直す
				  --同一受注明細・管理番号かつ出荷完了していない出荷指示詳細を削除
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

				  --ここまでの更新で正しくなった受注詳細情報を使用して出荷指示詳細を作成
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

				  --受注詳細に引き当たっていた入庫日が空白でない数量分について、今回着荷数分と同じ数量の場合、
				  --受注詳細に入庫日が無い状態になっているので、上記クエリでは受注詳細を取得できない可能性がある
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


				  --出荷完了していない出荷指示明細を取得し、カーソルをまわす
				  DECLARE @ShukkaSiziNO_31 varchar(12),
                          @ShukkaSiziGyouNO_31 smallint,
				   	      @MeisaiShukkaSiziSuuZan_31 decimal(21, 6),
						  @CUR_ShukkaSiziShousaiNO_31 smallint
                       
                  DECLARE cursorShukkaSiziMeisai CURSOR READ_ONLY
                  FOR
                  SELECT DSSM.ShukkaSiziNO 
				        ,DSSM.ShukkaSiziGyouNO
				   	    ,DSSM.ShukkaSiziSuu - ISNULL(DSSS.ShukkaSiziSuu, CAST(0 AS DECIMAL(21, 6))) --今回の入庫日以外の出荷指示詳細は除く
                  FROM D_ShukkaSiziMeisai DSSM
				  LEFT OUTER JOIN (
				                     --このタイミングで残っている出荷指示詳細は、別の管理番号または入庫日のデータのみ
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
				     --出荷指示詳細番号を採番
					 SET @CUR_ShukkaSiziShousaiNO_31 = 0

					 SELECT @CUR_ShukkaSiziShousaiNO_31 = MAX(ISNULL(DSSS.ShukkaSiziShousaiNO, 0)) + 1
					 FROM D_ShukkaSiziMeisai DSSM--詳細が全て削除されている可能性があるので、明細をメインテーブルにする
					 LEFT OUTER JOIN D_ShukkaSiziShousai DSSS
					 ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					 AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					 WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO_31
					 AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO_31
					 
					 --明細出荷指示残数＞受注詳細の出荷指示済数の場合
					 IF(@MeisaiShukkaSiziSuuZan_31 > @ShukkaSiziZumiSuu_31)
					 BEGIN
					     --受注詳細の出荷指示済数で出荷指示詳細を作成
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

						 --残りを入庫日空白で作成
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
					 END
					 --明細出荷指示残数≦受注詳細の出荷指示済数の場合
					 ELSE
					 BEGIN
					     --受注詳細の出荷指示済数で出荷指示詳細を作成
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

						  --SET @ShukkaSiziZumiSuu_31 = @ShukkaSiziZumiSuu_31 - @MeisaiShukkaSiziSuuZan_31
					 END
				    
				     FETCH NEXT FROM cursorShukkaSiziMeisai INTO @ShukkaSiziNO_31, @ShukkaSiziGyouNO_31, @MeisaiShukkaSiziSuuZan_31
		          END
	              CLOSE cursorShukkaSiziMeisai
	              DEALLOCATE cursorShukkaSiziMeisai


				  --４．現在庫
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


