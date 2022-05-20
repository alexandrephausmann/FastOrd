USE FASTORDER
GO

IF EXISTS (SELECT 1 
			FROM SYS.OBJECTS
			WHERE OBJECT_ID = OBJECT_ID('PR_I_TB_ITEM_PEDIDO')
					AND TYPE IN ('P','PC'))
	DROP PROCEDURE PR_I_TB_ITEM_PEDIDO

GO

CREATE PROC PR_I_TB_ITEM_PEDIDO
(
	 @COD_PEDIDO INT = NULL
	,@COD_ITEM_PEDIDO INT = NULL
	,@COD_PRODUTO INT = NULL
	,@QUANTIDADE INT = NULL
)

AS
BEGIN 

	INSERT INTO dbo.TB_ITEM_PEDIDO
			   (
				   COD_PEDIDO,
				   COD_ITEM_PEDIDO,
				   COD_PRODUTO,
				   QUANTIDADE
			   )
		 VALUES
			   (
				   @COD_PEDIDO,
				   @COD_ITEM_PEDIDO,
				   @COD_PRODUTO,
				   @QUANTIDADE
			   )

	END
GO

GRANT EXECUTE ON PR_I_TB_ITEM_PEDIDO TO PUBLIC
GO
