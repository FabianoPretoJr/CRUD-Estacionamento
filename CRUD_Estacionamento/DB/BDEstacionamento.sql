CREATE DATABASE BDEstacionamento;

GO

USE BDEstacionamento;

	CREATE TABLE TBVeiculo(
	Id			INT	IDENTITY,
	Placa		VARCHAR(8)	NOT NULL UNIQUE,
	Fabricante	VARCHAR(20)	NOT NULL,
	Modelo		VARCHAR(20)	NOT NULL,
	CONSTRAINT PK_TBVeiculo_Id PRIMARY KEY(Id)
);

select * from TBVeiculo;