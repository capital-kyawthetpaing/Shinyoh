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
-- Description:	5:���� (all in�����敪 10,21,20,30) 
-- History    : 2021/04/20 Y.Nishikawa �������s��
--            : 2021/04/27 Y.Nishikawa �݌ɍX�V�������t�@���N�V�������Ɉړ�
--            : 2021/05/07 Y.Nishikawa �����ǉ�
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
			--2021/04/20 Y.Nishikawa CHG �������s��
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

			--�V�K���[�h(@ProcessKBN = 10)�܂��͏C�����[�h�C����(@ProcessKBN = 21)�̏ꍇ�A
			IF (@ProcessKBN = 10 OR @ProcessKBN = 21)
			BEGIN
			      --�P�D������ɓ��̎󒍏ڍׂ����ɑ��݂���ꍇ�A���̒��ד`�[�Ŋ��Ɍv��ς݂̂��߁A���̎󒍏ڍׂɑ�������
				  IF EXISTS (
				               SELECT *
							   FROM D_JuchuuShousai
							   WHERE JuchuuNO = @JuchuuNO
							   AND JuchuuGyouNO = @JuchuuGyouNO
							   AND KanriNO = @KanriNO
							   AND NyuukoDate = @NyuukoDate
				            )
				  BEGIN
				      --�P�|�P�D���ɓ�����̎󒍏ڍׂ����݂���͂��Ȃ̂ŁA���̏����擾
					  DECLARE @JuchuuSuu_1 DECIMAL(21,6),
							  @ShukkaSiziZumiSuu_1 DECIMAL(21,6)

							  SELECT @JuchuuSuu_1 = JuchuuSuu
									,@ShukkaSiziZumiSuu_1 = ShukkaSiziZumiSuu
							  FROM D_JuchuuShousai
							  WHERE JuchuuNO = @JuchuuNO
							  AND JuchuuGyouNO = @JuchuuGyouNO
							  AND KanriNO = @KanriNO
							  AND NyuukoDate = ''
					  
					  --�P�|�Q�D��L�󒍏ڍׂ���󒍐��A�o�׎w���ϐ��A�����ϐ�����������
					  --�P�|�Q�[�P�D���񒅉א����o�׎w���ϐ��ȉ��̏ꍇ
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

						 --������ɓ��̎󒍏ڍׂɑ�������
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
					  --�P�|�Q�[�Q�D���񒅉א����o�׎w���ϐ����傫���ꍇ
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

						 --������ɓ��̎󒍏ڍׂɑ�������
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
				  --�Q�D������ɓ��̎󒍏ڍׂ����݂��Ȃ��ꍇ�A���ɓ����󔒂̏�񂪑��݂���͂��Ȃ̂ŁA���̏��ɍX�V
				  ELSE
				  BEGIN
				      --�Q�|�P�D���̖��ׂœ��ɓ�����̎󒍏ڍׂ����݂���͂��Ȃ̂ŁA���̏����擾
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
					      
						  --�󒍏ڍׂ�INSERT����ۂ̃L�[���擾
					      SELECT @JuchuuShousaiNO_2 = MAX(JuchuuShousaiNO) + 1
						  FROM D_JuchuuShousai
						  WHERE JuchuuNO = @JuchuuNO
					      AND JuchuuGyouNO = @JuchuuGyouNO

					  --�Q�|�Q�D��L�󒍏ڍׂ���󒍐��A�o�׎w���ϐ��A�����ϐ�����������
					  --�Q�|�Q�[�P�D���񒅉א����o�׎w���ϐ��ȉ��̏ꍇ
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

						 --�󒍏ڍׂ�INSERT
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
					  --�Q�|�Q�[�Q�D���񒅉א����o�׎w���ϐ����傫���ꍇ
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

						 --�󒍏ڍׂ�INSERT
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

				  --�c���Ă���s�v�ȏڍׂ͍폜
				  DELETE DJUS
				  FROM D_JuchuuShousai DJUS
				  WHERE JuchuuNO = @JuchuuNO
				  AND JuchuuGyouNO = @JuchuuGyouNO
				  AND SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
				  AND JuchuuSuu = 0 
				  AND ShukkaSiziZumiSuu = 0
				  AND HikiateZumiSuu = 0

				  --�����敪�Ƀ`�F�b�N�����čX�V�����ꍇ�A
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
				        --�󒍖��ׂ̈����������񒅉א��ōX�V�i�����c�𖳂����j
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


				  --�R�D�����݌�
				  --�R�[�P�D������ɓ��Ŋ��Ɉ����݌ɂɃf�[�^�����݂���ꍇ�A
				  IF EXISTS (
				               SELECT *
							   FROM D_HikiateZaiko
							   WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND NyuukoDate = @NyuukoDate
				            )
				  BEGIN
				     --�R�[�P�|�P�D���ɓ�����̈��������i�[
					 DECLARE @HikiateZumiSuu_3 DECIMAL(21, 6),
					         @ShukkaSiziSuu_3 DECIMAL(21, 6)
					 SELECT @HikiateZumiSuu_3 = HikiateZumiSuu
					       ,@ShukkaSiziSuu_3 = ShukkaSiziSuu
					 FROM D_HikiateZaiko
					 WHERE SoukoCD = @SoukoCD
			         AND ShouhinCD = @ShouhinCD
			         AND KanriNO = @KanriNO
			         AND NyuukoDate = ''

					 --�R�[�P�|�Q�D���񒅉א����o�׎w�����ȉ��̏ꍇ
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

						 --������ɓ��̈����݌ɂɑ�������
						 UPDATE D_HikiateZaiko
					     SET ShukkaSiziSuu = ShukkaSiziSuu + @ChakuniSuu
						    ,UpdateOperator = @UpdateOperator
							,UpdateDateTime = @UpdateDateTime
					     WHERE SoukoCD = @SoukoCD
			             AND ShouhinCD = @ShouhinCD
			             AND KanriNO = @KanriNO
			             AND NyuukoDate = @NyuukoDate
					 END
					 --�R�|�P�|�R�D���񒅉א����o�׎w�������傫���ꍇ
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

						 --������ɓ��̈����݌ɂɑ�������
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
				  --�S�D������ɓ��̈����݌ɂ����݂��Ȃ��ꍇ�A���ɓ����󔒂̏�񂪑��݂���͂��Ȃ̂ŁA���̏��ɍX�V
				  ELSE
				  BEGIN
				      --�S�|�P�D���ɓ�����̈����݌ɂ����݂���͂��Ȃ̂ŁA���̏����擾
					  DECLARE @HikiateZumiSuu_4 DECIMAL(21, 6),
					          @ShukkaSiziSuu_4 DECIMAL(21, 6)
					  SELECT @HikiateZumiSuu_4 = HikiateZumiSuu
					        ,@ShukkaSiziSuu_4 = ShukkaSiziSuu
					  FROM D_HikiateZaiko
					  WHERE SoukoCD = @SoukoCD
			          AND ShouhinCD = @ShouhinCD
			          AND KanriNO = @KanriNO
			          AND NyuukoDate = ''

					  --�S�|�Q�D��L�����݌ɂ���o�׎w�����A�����ϐ�����������
					  --�S�|�Q�[�P�D���񒅉א����o�׎w�����ȉ��̏ꍇ
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

						 --�����݌ɂ�INSERT
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
					  --�S�|�Q�[�Q�D���񒅉א����o�׎w�������傫���ꍇ
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

						 --�����݌ɂ�INSERT
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


				  --�T�D�o�׎w���ڍ�
				  --�����܂ł̍X�V�Ŏ󒍏ڍהԍ����ς���Ă���\��������̂ŁA����󒍖��ׁE�Ǘ��ԍ��̎󒍏ڍׂ��x�[�X�ɁA�o�׎w���ڍׂ���蒼��
				  --����󒍖��ׁE�Ǘ��ԍ����o�׊������Ă��Ȃ��o�׎w���ڍׂ��폜
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

				  --�����܂ł̍X�V�Ő������Ȃ����󒍏ڍ׏����g�p���ďo�׎w���ڍׂ��쐬
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

				  --�o�׊������Ă��Ȃ��o�׎w�����ׂ��擾���A�J�[�\�����܂킷
				  DECLARE @ShukkaSiziNO_5 varchar(12),
                          @ShukkaSiziGyouNO_5 smallint,
				   	      @MeisaiShukkaSiziSuuZan_5 decimal(21, 6),
						  @CUR_ShukkaSiziShousaiNO_5 smallint
                       
                  DECLARE cursorShukkaSiziMeisai CURSOR READ_ONLY
                  FOR
                  SELECT DSSM.ShukkaSiziNO 
				        ,DSSM.ShukkaSiziGyouNO
				   	    ,DSSM.ShukkaSiziSuu - ISNULL(DSSS.ShukkaSiziSuu, CAST(0 AS DECIMAL(21, 6))) --����̓��ɓ��ȊO�̏o�׎w���ڍׂ͏���
                  FROM D_ShukkaSiziMeisai DSSM
				  LEFT OUTER JOIN (
				                     --���̃^�C�~���O�Ŏc���Ă���o�׎w���ڍׂ́A�ʂ̊Ǘ��ԍ��܂��͓��ɓ��̃f�[�^�̂�
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
				     --�o�׎w���ڍהԍ����̔�
					 SET @CUR_ShukkaSiziShousaiNO_5 = 0

					 SELECT @CUR_ShukkaSiziShousaiNO_5 = MAX(ISNULL(DSSS.ShukkaSiziShousaiNO, 0)) + 1
					 FROM D_ShukkaSiziMeisai DSSM--�ڍׂ��S�č폜����Ă���\��������̂ŁA���ׂ����C���e�[�u���ɂ���
					 LEFT OUTER JOIN D_ShukkaSiziShousai DSSS
					 ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					 AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					 WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO_5
					 AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO_5

				     --���׏o�׎w���c�����󒍏ڍׂ̏o�׎w���ϐ��̏ꍇ
					 IF(@MeisaiShukkaSiziSuuZan_5 > @ShukkaSiziZumiSuu_5)
					 BEGIN
					     --�󒍏ڍׂ̏o�׎w���ϐ��ŏo�׎w���ڍׂ��쐬
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

						 --�c�����ɓ��󔒂ō쐬
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
					 --���׏o�׎w���c�����󒍏ڍׂ̏o�׎w���ϐ��̏ꍇ
					 ELSE
					 BEGIN
					     --�󒍏ڍׂ̏o�׎w���ϐ��ŏo�׎w���ڍׂ��쐬
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


				  --�U�D���݌�
				  --2021/04/27 Y.Nishikawa ADD �݌ɍX�V�������t�@���N�V�������Ɉړ�
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
											--2021/05/07 Y.Nishikawa ADD �����ǉ�
											AND M.ChakuniGyouNO = @ChakuniGyouNO
											--2021/05/07 Y.Nishikawa ADD �����ǉ�
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
									 --2021/05/07 Y.Nishikawa ADD �����ǉ�
									 AND M.ChakuniGyouNO = @ChakuniGyouNO
									 --2021/05/07 Y.Nishikawa ADD �����ǉ�
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
                        --2021/05/07 Y.Nishikawa ADD �����ǉ�
						AND DCKM.ChakuniGyouNO = @ChakuniGyouNO
						--2021/05/07 Y.Nishikawa ADD �����ǉ�
                   END
				  --2021/04/27 Y.Nishikawa ADD  �݌ɍX�V�������t�@���N�V�������Ɉړ�

			END
			--�C�����[�h�C���O(@ProcessKBN = 20)�܂��͍폜���[�h(@ProcessKBN = 30)�̏ꍇ�A
			ELSE
			BEGIN
			      --�P�D������ɓ��̎󒍏ڍ׏����擾
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
				  
				  --���ɓ�����̎󒍏ڍׂ����݂���ꍇ�A������ɓ��̎󒍏ڍׂ��獷�������A���ɓ�����̎󒍏ڍׂɑ�������
				  IF EXISTS (
				               SELECT *
							   FROM D_JuchuuShousai
							   WHERE JuchuuNO = @JuchuuNO
					           AND JuchuuGyouNO = @JuchuuGyouNO
					           AND KanriNO = @KanriNO
							   AND ISNULL(NyuukoDate, '') = ''
				            )
				  BEGIN
				     --������ɓ��̎󒍏ڍׂ̎󒍐������񒅉א��̏ꍇ�A���̒��ד`�[�Ōv�コ��Ă���i���[�j���߁A�Y���󒍏ڍׂ̏o�׎w���ϐ��ƈ����ϐ��Œ�������
				     IF (@JuchuuSuu_11 >= @ChakuniSuu)
				     BEGIN
				        --������ɓ��̎󒍏ڍׂ̏o�׎w���ϐ������񒅉א��̏ꍇ�A
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
						--������ɓ��̎󒍏ڍׂ̏o�׎w���ϐ������񒅉א��̏ꍇ�A
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

						--UPDATE�̌��ʁA�����ϐ����O���o�׎w���ϐ����O�ɂȂ����ꍇ�A���R�[�h�폜
						DELETE D_JuchuuShousai
						WHERE JuchuuNO = @JuchuuNO
					    AND JuchuuGyouNO = @JuchuuGyouNO
					    AND KanriNO = @KanriNO
						AND NyuukoDate = @NyuukoDate
						AND HikiateZumiSuu = 0
						AND ShukkaSiziZumiSuu = 0
				     END
					 --������ɓ��̎󒍏ڍׂ̎󒍐������񒅉א��̏ꍇ�A�V�X�e���゠�蓾�Ȃ�
					 ELSE
					 BEGIN
					    SELECT 1
					 END
				  END
				  --���ɓ�����̎󒍏ڍׂ����݂��Ȃ��ꍇ�A������ɓ��̎󒍏ڍׂ��獷�������A���ɓ�����̎󒍏ڍׂ�ǉ�
				  ELSE
				  BEGIN
				     --������ɓ��̎󒍏ڍׂ̎󒍐������񒅉א��̏ꍇ�A���̒��ד`�[�Ōv�コ��Ă���i���[�j���߁A�Y���󒍏ڍׂ̏o�׎w���ϐ��ƈ����ϐ��Œ�������
				     IF (@JuchuuSuu_11 >= @ChakuniSuu)
				     BEGIN
				        --������ɓ��̎󒍏ڍׂ̏o�׎w���ϐ������񒅉א��̏ꍇ�A
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
						--������ɓ��̎󒍏ڍׂ̏o�׎w���ϐ������񒅉א��̏ꍇ�A
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

						--UPDATE�̌��ʁA�����ϐ����O���o�׎w���ϐ����O�ɂȂ����ꍇ�A���R�[�h�폜
						DELETE D_JuchuuShousai
						WHERE JuchuuNO = @JuchuuNO
					    AND JuchuuGyouNO = @JuchuuGyouNO
					    AND KanriNO = @KanriNO
						AND NyuukoDate = @NyuukoDate
						AND HikiateZumiSuu = 0
						AND ShukkaSiziZumiSuu = 0
				     END
					 --������ɓ��̎󒍏ڍׂ̎󒍐������񒅉א��̏ꍇ�A�V�X�e���゠�蓾�Ȃ�
					 ELSE
					 BEGIN
					    SELECT 1
					 END
				  END

				  --�c���Ă���s�v�ȏڍׂ͍폜
				  DELETE DJUS
				  FROM D_JuchuuShousai DJUS
				  WHERE JuchuuNO = @JuchuuNO
				  AND JuchuuGyouNO = @JuchuuGyouNO
				  AND SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
				  AND JuchuuSuu = 0 
				  AND ShukkaSiziZumiSuu = 0
				  AND HikiateZumiSuu = 0

				  --2021/05/19����
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
				  --2021/05/19����
				  

				  --�Q�D�����݌�
				  --������ɓ��̏o�׎w�����ƈ����ϐ����擾
				  DECLARE @ShukkaSiziSuu_21 DECIMAL(21,6),
				          @HikiateZumiSuu_21 DECIMAL(21,6)
				  SELECT @ShukkaSiziSuu_21 = ShukkaSiziSuu
				        ,@HikiateZumiSuu_21 = HikiateZumiSuu
				  FROM D_HikiateZaiko
				  WHERE SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

				  --���Ɉ����݌ɂɓ���q�ɁE���i�E�Ǘ��ԍ��œ��ɓ����󔒂̏�񂪑��݂��Ă����ꍇ�A
				  --������ɓ��̏�񂩂獷�������A���ɓ����󔒂̈������ɏC���O�܂��͍폜���钅�א����v���X
				  IF EXISTS (
				               SELECT *
							   FROM D_HikiateZaiko
							   WHERE SoukoCD = @SoukoCD
			                   AND ShouhinCD = @ShouhinCD
			                   AND KanriNO = @KanriNO
			                   AND ISNULL(NyuukoDate, '') = ''
				            )
				  BEGIN
				     --�o�׎w���������񒅉א��̏ꍇ�A
				     IF (@ShukkaSiziSuu_21 >= @ChakuniSuu) 
				     BEGIN
				        --������ɓ��̏�񂩂獷������
				        UPDATE D_HikiateZaiko
				        SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--���ɓ����󔒂̏��ɍX�V
						UPDATE D_HikiateZaiko
				        SET ShukkaSiziSuu = ShukkaSiziSuu + @ChakuniSuu
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND ISNULL(NyuukoDate, '') = ''
				     END
					 --�o�׎w���������񒅉א��̏ꍇ�A
					 ELSE
					 BEGIN
					    --������ɓ��̏�񂩂獷������
				        UPDATE D_HikiateZaiko
				        SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_21)
						   ,ShukkaSiziSuu = 0
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--���ɓ����󔒂̏��ɍX�V
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
			         
				     --�}�C�i�X�Ώۂ̈����݌ɂɂ��āA�����ϐ��Əo�׎w�������[���ɂȂ����ꍇ�i�܂葼�̒��ׂœ�����ɓ��ŕ��[�v�オ�����ꍇ�j�A���R�[�h�폜
					 DELETE D_HikiateZaiko
			         WHERE SoukoCD = @SoukoCD
			         AND ShouhinCD = @ShouhinCD
			         AND KanriNO = @KanriNO
			         AND NyuukoDate = @NyuukoDate
					 AND ShukkaSiziSuu = 0
					 AND HikiateZumiSuu = 0
		          END
				  --�����݌ɂɓ���q�ɁE���i�E�Ǘ��ԍ��œ��ɓ����󔒂̏�񂪑��݂��Ă��Ȃ��ꍇ�A
				  ELSE
				  BEGIN
				     --�o�׎w���������񒅉א��̏ꍇ�A
				     IF (@ShukkaSiziSuu_21 >= @ChakuniSuu) 
				     BEGIN
				        --������ɓ��̏�񂩂獷������
				        UPDATE D_HikiateZaiko
				        SET ShukkaSiziSuu = ShukkaSiziSuu - @ChakuniSuu
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--���ɓ����󔒂̏��ɍX�V
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
				     --�o�׎w���������񒅉א��̏ꍇ�A
					 ELSE
					 BEGIN
					    --������ɓ��̏�񂩂獷������
				        UPDATE D_HikiateZaiko
				        SET HikiateZumiSuu = HikiateZumiSuu - (@ChakuniSuu - @ShukkaSiziSuu_21)
						   ,ShukkaSiziSuu = 0
						   ,UpdateOperator = @UpdateOperator
			               ,UpdateDateTime = @UpdateDateTime
				        WHERE SoukoCD = @SoukoCD
			            AND ShouhinCD = @ShouhinCD
			            AND KanriNO = @KanriNO
			            AND NyuukoDate = @NyuukoDate

						--���ɓ����󔒂̏��ɍX�V
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
			         
				     --�}�C�i�X�Ώۂ̈����݌ɂɂ��āA�����ϐ��Əo�׎w�������[���ɂȂ����ꍇ�i�܂葼�̒��ׂœ�����ɓ��ŕ��[�v�オ�����ꍇ�j�A���R�[�h�폜
					 DELETE D_HikiateZaiko
			         WHERE SoukoCD = @SoukoCD
			         AND ShouhinCD = @ShouhinCD
			         AND KanriNO = @KanriNO
			         AND NyuukoDate = @NyuukoDate
					 AND ShukkaSiziSuu = 0
					 AND HikiateZumiSuu = 0
				  
				  END
				  
				  
				  --�R�D�o�׎w���ڍ�
				  --�����܂ł̍X�V�Ŏ󒍏ڍהԍ����ς���Ă���\��������̂ŁA����󒍖��ׁE�Ǘ��ԍ��̎󒍏ڍׂ��x�[�X�ɁA�o�׎w���ڍׂ���蒼��
				  --����󒍖��ׁE�Ǘ��ԍ����o�׊������Ă��Ȃ��o�׎w���ڍׂ��폜
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

				  --�����܂ł̍X�V�Ő������Ȃ����󒍏ڍ׏����g�p���ďo�׎w���ڍׂ��쐬
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

				  --�󒍏ڍׂɈ����������Ă������ɓ����󔒂łȂ����ʕ��ɂ��āA���񒅉א����Ɠ������ʂ̏ꍇ�A
				  --�󒍏ڍׂɓ��ɓ���������ԂɂȂ��Ă���̂ŁA��L�N�G���ł͎󒍏ڍׂ��擾�ł��Ȃ��\��������
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


				  --�o�׊������Ă��Ȃ��o�׎w�����ׂ��擾���A�J�[�\�����܂킷
				  DECLARE @ShukkaSiziNO_31 varchar(12),
                          @ShukkaSiziGyouNO_31 smallint,
				   	      @MeisaiShukkaSiziSuuZan_31 decimal(21, 6),
						  @CUR_ShukkaSiziShousaiNO_31 smallint
                       
                  DECLARE cursorShukkaSiziMeisai CURSOR READ_ONLY
                  FOR
                  SELECT DSSM.ShukkaSiziNO 
				        ,DSSM.ShukkaSiziGyouNO
				   	    ,DSSM.ShukkaSiziSuu - ISNULL(DSSS.ShukkaSiziSuu, CAST(0 AS DECIMAL(21, 6))) --����̓��ɓ��ȊO�̏o�׎w���ڍׂ͏���
                  FROM D_ShukkaSiziMeisai DSSM
				  LEFT OUTER JOIN (
				                     --���̃^�C�~���O�Ŏc���Ă���o�׎w���ڍׂ́A�ʂ̊Ǘ��ԍ��܂��͓��ɓ��̃f�[�^�̂�
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
				     --�o�׎w���ڍהԍ����̔�
					 SET @CUR_ShukkaSiziShousaiNO_31 = 0

					 SELECT @CUR_ShukkaSiziShousaiNO_31 = MAX(ISNULL(DSSS.ShukkaSiziShousaiNO, 0)) + 1
					 FROM D_ShukkaSiziMeisai DSSM--�ڍׂ��S�č폜����Ă���\��������̂ŁA���ׂ����C���e�[�u���ɂ���
					 LEFT OUTER JOIN D_ShukkaSiziShousai DSSS
					 ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					 AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					 WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO_31
					 AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO_31
					 
					 --���׏o�׎w���c�����󒍏ڍׂ̏o�׎w���ϐ��̏ꍇ
					 IF(@MeisaiShukkaSiziSuuZan_31 > @ShukkaSiziZumiSuu_31)
					 BEGIN
					     --�󒍏ڍׂ̏o�׎w���ϐ��ŏo�׎w���ڍׂ��쐬
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

						 --�c�����ɓ��󔒂ō쐬
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
					 --���׏o�׎w���c�����󒍏ڍׂ̏o�׎w���ϐ��̏ꍇ
					 ELSE
					 BEGIN
					     --�󒍏ڍׂ̏o�׎w���ϐ��ŏo�׎w���ڍׂ��쐬
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


				  --�S�D���݌�
				  --2021/04/27 Y.Nishikawa ADD  �݌ɍX�V�������t�@���N�V�������Ɉړ�
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
										   --2021/05/07 Y.Nishikawa ADD �����ǉ�
										   AND M.ChakuniGyouNO = @ChakuniGyouNO
										   --2021/05/07 Y.Nishikawa ADD �����ǉ�
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
									--2021/05/07 Y.Nishikawa ADD �����ǉ�
									AND M.ChakuniGyouNO = @ChakuniGyouNO
									--2021/05/07 Y.Nishikawa ADD �����ǉ�
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
					   --2021/05/07 Y.Nishikawa ADD �����ǉ�
					   AND DCKM.ChakuniGyouNO = @ChakuniGyouNO
					   --2021/05/07 Y.Nishikawa ADD �����ǉ�
                  
                  END
          		--2021/04/27 Y.Nishikawa ADD �݌ɍX�V�������t�@���N�V�������Ɉړ�

			END
			--2021/04/20 Y.Nishikawa CHG �������s��

			fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ChakuniSuu,@JuchuuNO,@JuchuuGyouNO

		end
		
	close cursorOuter
	deallocate cursorOuter
	
END
GO


