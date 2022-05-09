CREATE TABLE TB_PRODUTO (
    COD_PROD INT IDENTITY(1,1),
    DESC_PROD varchar(255),
    VALOR_PROD FLOAT,
	PRIMARY KEY (COD_PROD),
);

INSERT INTO TB_PRODUTO 
VALUES 
('X-Burguer',18.00),
('Refrigerante Lata',5.99),
('Batata Frita M',7.00),
('Casquinha Mista',3);

select * from TB_PRODUTO


