CREATE TABLE TB_PEDIDO (
	COD_PEDIDO INT IDENTITY(1,1),
	RETIRADA VARCHAR(1),
	COD_INTEGRACAO INT,
	RUA VARCHAR(255),
	BAIRRO VARCHAR(255),
	CEP VARCHAR(15),
	NUM_RESIDENCIA INT,
	DADO_COMPLEMENTAR VARCHAR(255),
	NUM_CELULAR VARCHAR(15),
	PRIMARY KEY (COD_PEDIDO),
	FOREIGN KEY (COD_INTEGRACAO) REFERENCES TB_TIPO_INTEGRACAO(COD_TIPO_INTEGRACAO)
);

INSERT INTO TB_PEDIDO 
VALUES 
('S',1,NULL,NULL,NULL,NULL,NULL,NULL),
('N',2,'Avenida 123','Jd azul','123456000','123',NULL,'19989899889'),
('N',2,'Avenida 315','Jd verde','151235000','151','Perto da arvore','19989899889');

select * from TB_PEDIDO