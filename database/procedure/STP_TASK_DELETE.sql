SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[STP_TASK_DELETE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
    drop procedure [dbo].[STP_TASK_DELETE]
GO


CREATE PROCEDURE STP_TASK_DELETE
    @SQ_TASK INT
AS
BEGIN
	SET NOCOUNT ON;

	SET @SQ_TASK = (SELECT SQ_TASK FROM TB_TASK WHERE SQ_TASK = @SQ_TASK)
    
    IF (@SQ_TASK > 0)
    BEGIN
	    DELETE TB_TASK
        WHERE SQ_TASK = @SQ_TASK

       SELECT 'Success' as 'Type', '' as 'Message'
    END
    ELSE
    BEGIN
       SELECT 'Warning' as 'Type', 'Registro não encontrado!' as 'Message'
    END
END
GO
