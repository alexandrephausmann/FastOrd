USE [FastOrder];
GO
CREATE TABLE TB_ORDER_STATUS (
    ID_ORDER_STATUS INT IDENTITY(1,1),
    DESC_ORDER_STATUS varchar(255),
	PRIMARY KEY (ID_ORDER_STATUS)
);

INSERT INTO TB_ORDER_STATUS 
VALUES 
('Done'),
('Awaiting client'),
('In kitchen'),
('Awaiting for kitchen');

select * from TB_ORDER_STATUS