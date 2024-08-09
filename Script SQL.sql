-- SQL Manager for SQL Server 5.0.1.51843
-- ---------------------------------------
-- Host      : localhost
-- Database  : master
-- Version   : Microsoft SQL Server 2017 (RTM-CU31-GDR) (KB5029376) 14.0.3465.1


CREATE DATABASE master
ON PRIMARY
  ( NAME = master,
    FILENAME = N'/var/opt/mssql/data/master.mdf',
    SIZE = 4 MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 10 % )
LOG ON
  ( NAME = mastlog,
    FILENAME = N'/var/opt/mssql/data/mastlog.ldf',
    SIZE = 2 MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 10 % )
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

USE master
GO

SET NOCOUNT ON
GO

--
-- Definition for table Entrega : 
--

CREATE TABLE dbo.Entrega (
  id int IDENTITY(0, 1) NOT NULL,
  DataHora datetime2(7) NOT NULL,
  IdPedido int NOT NULL,
  PRIMARY KEY CLUSTERED (id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Pedidos : 
--

CREATE TABLE dbo.Pedidos (
  Id int IDENTITY(0, 1) NOT NULL,
  Descricao varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  Valor decimal(18, 2) NULL,
  Cep varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  Rua varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  Numero varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  Bairro varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  Cidade varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  Estado varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  StatusPedido int NOT NULL,
  DataHoraPedido datetime2(7) NOT NULL,
  IdUserPedido int DEFAULT 0 NOT NULL,
  PRIMARY KEY CLUSTERED (Id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table StatusPedido : 
--

CREATE TABLE dbo.StatusPedido (
  Id int IDENTITY(0, 1) NOT NULL,
  Descricao varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  PRIMARY KEY CLUSTERED (Id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Usuarios : 
--

CREATE TABLE dbo.Usuarios (
  Id int IDENTITY(0, 1) NOT NULL,
  Nome varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  Email varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  Senha varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  PRIMARY KEY CLUSTERED (Id)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Data for table dbo.Entrega  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Entrega ON
GO

INSERT INTO dbo.Entrega (id, DataHora, IdPedido)
VALUES 
  (0, N'2024-08-08 10:54:13.6178549', 3)
GO

INSERT INTO dbo.Entrega (id, DataHora, IdPedido)
VALUES 
  (1, N'2024-08-08 11:03:14.9145033', 0)
GO

INSERT INTO dbo.Entrega (id, DataHora, IdPedido)
VALUES 
  (2, N'2024-08-09 12:05:14.9616268', 9)
GO

SET IDENTITY_INSERT dbo.Entrega OFF
GO

--
-- Data for table dbo.Pedidos  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Pedidos ON
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (0, N'Pizza a Moda Gigante', 120.99, N'31130070', N'Rua Iça', N'207', N'Renascença', N'BH', N'mg', 4, N'2024-08-07 20:38:33.9115970', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (1, N'Teste', 11.55, N'30280320', N'Rua Itajobi', N'108', N'Pompéia', N'Belo Horizonte', N'MG', 1, N'2024-08-07 21:11:08.5047409', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (2, N'Mil Tijolos', 658.88, N'31130070', N'Rua Içá', N'209', N'Renascença', N'Belo Horizonte', N'MG', 3, N'2024-08-08 09:29:41.2106077', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (3, N'Notebook', 3889.7, N'31130070', N'Rua Içá', N'209', N'Renascença', N'Belo Horizonte', N'MG', 4, N'2024-08-08 09:30:14.0619902', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (4, N'Monitor Gamer', 1450.99, N'30280320', N'Rua Itajobi', N'108', N'Pompéia', N'Belo Horizonte', N'MG', 3, N'2024-08-08 09:31:05.9197163', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (5, N'Feijoada Grande', 20, N'30280320', N'Rua Itajobi', N'108', N'Pompéia', N'Belo Horizonte', N'MG', 2, N'2024-08-08 09:31:30.9670644', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (6, N'Serviço de Pintura do Quarto', 600, N'31130070', N'Rua Içá', N'209', N'Renascença', N'Belo Horizonte', N'MG', 1, N'2024-08-08 09:32:08.9363231', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (7, N'Mouse Optico', 35, N'32661785', N'Rua Jupiter', N'200', N'Campos Elíseos', N'Betim', N'MG', 0, N'2024-08-08 11:07:07.4013287', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (8, N'Teste Botão cadastrar', 654, N'32676235', N'Rua Içá', N'209', N'Renascença', N'Belo Horizonte', N'MG', 3, N'2024-08-08 19:42:02.0979460', 5)
GO

INSERT INTO dbo.Pedidos (Id, Descricao, Valor, Cep, Rua, Numero, Bairro, Cidade, Estado, StatusPedido, DataHoraPedido, IdUserPedido)
VALUES 
  (9, N'Dia de Podrão', 30, N'32807411', N'Rua Vinte e Sete', N'111', N'Recanto Verde II', N'Esmeraldas', N'MG', 4, N'2024-08-09 12:05:06.9943115', 5)
GO

SET IDENTITY_INSERT dbo.Pedidos OFF
GO

--
-- Data for table dbo.StatusPedido  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.StatusPedido ON
GO

INSERT INTO dbo.StatusPedido (Id, Descricao)
VALUES 
  (0, N'Cancelado')
GO

INSERT INTO dbo.StatusPedido (Id, Descricao)
VALUES 
  (1, N'Recebido')
GO

INSERT INTO dbo.StatusPedido (Id, Descricao)
VALUES 
  (2, N'Em Preparação')
GO

INSERT INTO dbo.StatusPedido (Id, Descricao)
VALUES 
  (3, N'Saiu Para a Entrega')
GO

INSERT INTO dbo.StatusPedido (Id, Descricao)
VALUES 
  (4, N'Entregue')
GO

SET IDENTITY_INSERT dbo.StatusPedido OFF
GO

--
-- Data for table dbo.Usuarios  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Usuarios ON
GO

INSERT INTO dbo.Usuarios (Id, Nome, Email, Senha)
VALUES 
  (0, N'Administrador', N'adm.teste@gmail.com', N'VG9yYTYyMzU=')
GO

INSERT INTO dbo.Usuarios (Id, Nome, Email, Senha)
VALUES 
  (1, N'Bruno Mazzinghy', N'brunoibs2@gmail.com', N'VG9yYTYyMzU=')
GO

INSERT INTO dbo.Usuarios (Id, Nome, Email, Senha)
VALUES 
  (2, N'Gustavo', N'gugaalves@gmail.com', N'VGVzdGVAMTIzNA==')
GO

INSERT INTO dbo.Usuarios (Id, Nome, Email, Senha)
VALUES 
  (3, N'Denise Lombardi', N'deni@teste.com', N'VG9yYTYyMzU=')
GO

INSERT INTO dbo.Usuarios (Id, Nome, Email, Senha)
VALUES 
  (4, N'Theo Mazzinghy', N'theo@teste.com', N'VG9yYTYyMzU=')
GO

INSERT INTO dbo.Usuarios (Id, Nome, Email, Senha)
VALUES 
  (5, N'Luiz Felipe', N'luiz@teste.com', N'VG9yYTYyMzU=')
GO

INSERT INTO dbo.Usuarios (Id, Nome, Email, Senha)
VALUES 
  (6, N'Fred Aec', N'fred@gmail.com', N'VG9yYTYyMzU=')
GO

SET IDENTITY_INSERT dbo.Usuarios OFF
GO

