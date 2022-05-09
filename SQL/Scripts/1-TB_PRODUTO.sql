CREATE TABLE TB_PRODUTO (
    COD_PRODUTO INT IDENTITY(1,1),
    DESC_PRODUTO varchar(255),
    VALOR_PRODUTO FLOAT,
	PRIMARY KEY (COD_PRODUTO),
);

INSERT INTO TB_PRODUTO 
VALUES 
('X-Burguer',18.00),
('Refrigerante Lata',5.99),
('Batata Frita M',7.00),
('Casquinha Mista',3);

select * from TB_PRODUTO


