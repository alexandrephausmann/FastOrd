USE [FastOrder];
GO
CREATE TABLE TB_PRODUCT (
    COD_PRODUCT INT IDENTITY(1,1),
    DESC_PRODUCT varchar(255),
    PRODUCT_VALUE FLOAT,
	PRIMARY KEY (COD_PRODUCT),
);

INSERT INTO TB_PRODUCT 
VALUES 
('X-Burguer',18.00),
('Refrigerante Lata',5.99),
('Batata Frita M',7.00),
('Casquinha Mista',3);

select * from TB_PRODUCT


