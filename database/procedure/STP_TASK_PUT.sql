SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[STP_TASK_PUT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
    drop procedure [dbo].[STP_TASK_PUT]
GO


CREATE PROCEDURE STP_TASK_PUT
    @SQ_TASK INT,
	@NM_TASK VARCHAR(100),
    @DS_TASK VARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;

	SET @SQ_TASK = (SELECT SQ_TASK FROM TB_TASK WHERE SQ_TASK = @SQ_TASK)
    
    IF (@SQ_TASK > 0)
    BEGIN
	    UPDATE TB_TASK 
            SET NM_TASK = @NM_TASK,
                DS_TASK = @DS_TASK
        WHERE SQ_TASK = @SQ_TASK

       SELECT 'Success' as 'Type', '' as 'Message'
    END
    ELSE
    BEGIN
       SELECT 'Warning' as 'Type', 'Registro não encontrado!' as 'Message'
    END
END
GO
