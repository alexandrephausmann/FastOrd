USE [FastOrder];
GO
CREATE TABLE TB_INTEGRATION_TYPE (
    ID_INTEGRATION_TYPE INT IDENTITY(1,1),
    DESC_INTEGRATION_TYPE varchar(255),
	PRIMARY KEY (ID_INTEGRATION_TYPE)
);

INSERT INTO TB_INTEGRATION_TYPE 
VALUES 
('No integration'),
('Ifood');

select * from TB_INTEGRATION_TYPE