 BEGIN TRY 
 Drop Procedure dbo.[ShukkaNyuuryoku_Select_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Hnin Ei Thu
-- Create date: 12/11/2020 
-- Description: exist or not from the M_Staff Table
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaNyuuryoku_Select_Check]
    -- Add the parameters for the stored procedure here
    @ShukkaNo as varchar(12),
    @ShukkaDate as varchar(10),
    @Errortype as varchar(10)
    
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

        CREATE TABLE  #WK_MiNyuukaSuu1                  
            (
                [ShukkaSiziNO] Varchar(12), 
                [ShukkaSiziGyouNO] smallint,
                [MiNyuukaSuu]   decimal(21,6)
            )
        Insert Into #WK_MiNyuukaSuu1
        select DSS.ShukkaSiziNO,
        DSS.ShukkaSiziGyouNO,
        SUM(DSS.ShukkaSiziSuu) --as ShukkaSuu
        from D_ShukkaSiziShousai DSS
        left outer join D_ShukkaShousai D1 on D1.ShukkaSiziNO = DSS.ShukkaSiziNO and D1.ShukkaSiziGyouNO=DSS.ShukkaSiziGyouNO and D1.ShukkaSiziShousaiNO=DSS.ShukkaSiziShousaiNO
        where D1.ShukkaNO=@ShukkaNo and DSS.NyuukoDate=''
        group by DSS.ShukkaSiziNO,DSS.ShukkaSiziGyouNO

    -- select statements for procedure here
    if @Errortype = 'E115'
    begin
        if NOT exists(select MC.*,M_Message.* from M_Message,M_Control MC inner join M_FiscalYear MFY on MFY.FiscalYear=MC.FiscalYear 
            where MC.MainKey=1 and MFY.InputPossibleStartDate <= @ShukkaDate and MFY.InputPossibleEndDate >= @ShukkaDate)
            begin
            --not exist
            select * from M_Message where MessageID = 'E115'
            end
    end

    if @Errortype = 'E165'
    begin
        if exists(select * from D_ShukkaMeisai where ShukkaNO=@ShukkaNO and (UriageZumiSuu>0 OR UriageKanryouKBN=1))
            begin
            --exist
            select * from M_Message where MessageID = 'E165'
            end
    end
    
    if @Errortype='E160'
    begin
        if exists(select * from D_Shukka where UriageKanryouKBN=1)
            begin
            --exists
            select * from M_Message where MessageID = 'E160'
            end
         else
            begin
            ---- not exists
            select DS.ShukkaDate, DS.TokuisakiCD,DS.TokuisakiRyakuName,DS.TokuisakiName,DS.TokuisakiYuubinNO1,DS.TokuisakiYuubinNO2,
                    DS.TokuisakiJuusho1,DS.TokuisakiJuusho2,DS.[TokuisakiTelNO1-1],DS.[TokuisakiTelNO1-2],DS.[TokuisakiTelNO1-3],
                    DS.[TokuisakiTelNO2-1],DS.[TokuisakiTelNO2-2], DS.[TokuisakiTelNO2-3], DS.KouritenCD, DS.KouritenRyakuName,
                    DS.KouritenName,DS.KouritenYuubinNO1, DS.KouritenYuubinNO2,DS.KouritenJuusho1,DS.KouritenJuusho2,
                    DS.[KouritenTelNO1-1],DS.[KouritenTelNO1-2],DS.[KouritenTelNO1-3],DS.[KouritenTelNO2-1],DS.[KouritenTelNO2-2],
                    DS.[KouritenTelNO2-3],DS.StaffCD,FS.StaffName,DS.ShukkaDenpyouTekiyou,DSM.JANCD,F.HinbanCD,DSM.ShouhinName,DSM.ColorRyakuName,
                    DSM.ColorNO,DSM.SizeNO,ISNULL(FLOOR(DSM1.ShukkaSiziSuu - DSM1.ShukkaZumiSuu),'0') as ShukkaSiziZumiSuu,ISNULL(FLOOR(WK.MiNyuukaSuu),'0') as MiNyuukaSuu,
                    DSM.ShukkaSuu,NULL as Kanryou,DSM.ShukkaMeisaiTekiyou,
                    (DSM.ShukkaSiziNO +'-'+ cast(DSM.ShukkaSiziGyouNO as varchar)) as ShukkaSiziNOGyouNO,DSM.ShukkaSiziNO,
                    DSM.DenpyouDate,(DSM1.JuchuuNO +'-'+ cast(DSM1.JuchuuGyouNO as varchar)) as JuchuuNOGyouNO,DSM1.SoukoCD,F.ShouhinCD,M_Message.MessageID,DSM.UriageKanryouKBN                            
            from D_Shukka DS 
            inner join D_ShukkaMeisai DSM on DSM.ShukkaNO=DS.ShukkaNO
            left outer join D_ShukkaSiziMeisai DSM1 on DSM1.ShukkaSiziNO=DSM.ShukkaSiziNO and DSM1.ShukkaSiziGyouNO = DSM.ShukkaSiziGyouNO
            left outer join #WK_MiNyuukaSuu1 WK on WK.ShukkaSiziNO = DSM.ShukkaSiziNO and WK.ShukkaSiziGyouNO = DSM.ShukkaSiziGyouNO
            left outer join F_Staff(@ShukkaDate) FS on FS.StaffCD=DS.StaffCD    
            left outer join M_Souko MS on MS.SoukoCD=DSM1.SoukoCD
            left outer join F_Shouhin(@ShukkaDate) F on F.ShouhinCD = DSM.ShouhinCD,M_Message
            where DS.ShukkaNO =@ShukkaNo and M_Message.MessageID='E132'
            order by DSM.GyouHyouziJun ASC      
            end
        end

         if exists(select * from D_Shukka where ShukkaNO=@ShukkaNo)
        begin
            --exists
                select DS.ShukkaDate, DS.TokuisakiCD,DS.TokuisakiRyakuName,DS.TokuisakiName,DS.TokuisakiYuubinNO1,DS.TokuisakiYuubinNO2,
                    DS.TokuisakiJuusho1,DS.TokuisakiJuusho2,DS.[TokuisakiTelNO1-1],DS.[TokuisakiTelNO1-2],DS.[TokuisakiTelNO1-3],
                    DS.[TokuisakiTelNO2-1],DS.[TokuisakiTelNO2-2], DS.[TokuisakiTelNO2-3], DS.KouritenCD, DS.KouritenRyakuName,
                    DS.KouritenName,DS.KouritenYuubinNO1, DS.KouritenYuubinNO2,DS.KouritenJuusho1,DS.KouritenJuusho2,
                    DS.[KouritenTelNO1-1],DS.[KouritenTelNO1-2],DS.[KouritenTelNO1-3],DS.[KouritenTelNO2-1],DS.[KouritenTelNO2-2],
                    DS.[KouritenTelNO2-3],DS.StaffCD,FS.StaffName,DS.ShukkaDenpyouTekiyou,DSM.JANCD,F.HinbanCD,DSM.ShouhinName,DSM.ColorRyakuName,
                    DSM.ColorNO,DSM.SizeNO,ISNULL(FLOOR(DSM1.ShukkaSiziSuu - DSM1.ShukkaZumiSuu),'0') as ShukkaSiziZumiSuu,ISNULL(FLOOR(WK.MiNyuukaSuu),'0') as MiNyuukaSuu,
                    DSM.ShukkaSuu,NULL as Kanryou,DSM.ShukkaMeisaiTekiyou,
                    (DSM.ShukkaSiziNO +'-'+ cast(DSM.ShukkaSiziGyouNO as varchar)) as ShukkaSiziNOGyouNO,DSM.ShukkaSiziNO,
                    DSM.DenpyouDate,(DSM1.JuchuuNO +'-'+ cast(DSM1.JuchuuGyouNO as varchar)) as JuchuuNOGyouNO,DSM1.SoukoCD,F.ShouhinCD,M_Message.MessageID,DSM.UriageKanryouKBN
                    ,DSM.ShukkaGyouNO                            
            from D_Shukka DS 
            inner join D_ShukkaMeisai DSM on DSM.ShukkaNO=DS.ShukkaNO
            left outer join D_ShukkaSiziMeisai DSM1 on DSM1.ShukkaSiziNO=DSM.ShukkaSiziNO and DSM1.ShukkaSiziGyouNO = DSM.ShukkaSiziGyouNO
            left outer join #WK_MiNyuukaSuu1 WK on WK.ShukkaSiziNO = DSM.ShukkaSiziNO and WK.ShukkaSiziGyouNO = DSM.ShukkaSiziGyouNO
            left outer join F_Staff(@ShukkaDate) FS on FS.StaffCD=DS.StaffCD    
            left outer join M_Souko MS on MS.SoukoCD=DSM1.SoukoCD
            left outer join F_Shouhin(@ShukkaDate) F on F.ShouhinCD = DSM.ShouhinCD,M_Message
            where DS.ShukkaNO =@ShukkaNo and M_Message.MessageID='E132'
            order by DSM.GyouHyouziJun ASC      
        end
    else
        begin
            --not exists
            select * from M_Message
            where MessageID = 'E133'
        end

        If(OBJECT_ID('tempdb..#WK_MiNyuukaSuu1') Is Not Null)
        begin
            Drop Table #WK_MiNyuukaSuu1
        end
END




