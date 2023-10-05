USE [ServicoResidencia]
GO
/****** Object:  Table [dbo].[LocalizacaCliente]    Script Date: 05/10/2023 12:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizacaCliente](
	[LocalizacaoId] [int] IDENTITY(1,1) NOT NULL,
	[Cidade] [nvarchar](80) NOT NULL,
	[Bairro] [nvarchar](50) NOT NULL,
	[NomeClienteId] [int] NOT NULL,
 CONSTRAINT [PK_LocalizacaCliente] PRIMARY KEY CLUSTERED 
(
	[LocalizacaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NomeClientes]    Script Date: 05/10/2023 12:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NomeClientes](
	[NomeClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[NumeroCelular] [nvarchar](15) NOT NULL,
	[LocalizacaoId] [int] NULL,
 CONSTRAINT [PK_NomeClientes] PRIMARY KEY CLUSTERED 
(
	[NomeClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NomeServicos]    Script Date: 05/10/2023 12:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NomeServicos](
	[NomeServicoId] [int] IDENTITY(1,1) NOT NULL,
	[NomeClienteId] [int] NOT NULL,
	[NomeServicoRes] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_NomeServicos] PRIMARY KEY CLUSTERED 
(
	[NomeServicoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LocalizacaCliente] ADD  DEFAULT ((0)) FOR [NomeClienteId]
GO
ALTER TABLE [dbo].[NomeServicos] ADD  DEFAULT ((0)) FOR [NomeClienteId]
GO
ALTER TABLE [dbo].[NomeServicos] ADD  DEFAULT (N'') FOR [NomeServicoRes]
GO
ALTER TABLE [dbo].[NomeClientes]  WITH CHECK ADD  CONSTRAINT [FK_NomeClientes_LocalizacaCliente_LocalizacaoId] FOREIGN KEY([LocalizacaoId])
REFERENCES [dbo].[LocalizacaCliente] ([LocalizacaoId])
GO
ALTER TABLE [dbo].[NomeClientes] CHECK CONSTRAINT [FK_NomeClientes_LocalizacaCliente_LocalizacaoId]
GO
ALTER TABLE [dbo].[NomeServicos]  WITH CHECK ADD  CONSTRAINT [FK_NomeServicos_NomeClientes_NomeClienteId] FOREIGN KEY([NomeClienteId])
REFERENCES [dbo].[NomeClientes] ([NomeClienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NomeServicos] CHECK CONSTRAINT [FK_NomeServicos_NomeClientes_NomeClienteId]
GO
