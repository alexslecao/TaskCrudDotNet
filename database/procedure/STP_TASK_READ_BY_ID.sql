SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[STP_TASK_READ_BY_ID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
    drop procedure [dbo].[STP_TASK_READ_BY_ID]
GO


CREATE PROCEDURE STP_TASK_READ_BY_ID
	@SQ_TASK INT
AS
BEGIN
	SET NOCOUNT ON;

    SET @SQ_TASK = (SELECT SQ_TASK FROM TB_TASK WHERE SQ_TASK = @SQ_TASK)
    
    IF (@SQ_TASK > 0)
    BEGIN
	    SELECT SQ_TASK, NM_TASK, DS_TASK 
        FROM TB_TASK 
        WHERE SQ_TASK = @SQ_TASK
    END
    ELSE
    BEGIN
       SELECT 'Warning' as 'Type', 'Registro não encontrado!' as 'Message'
    END
END
GO
