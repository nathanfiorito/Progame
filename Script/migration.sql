USE [progame]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
ALTER TABLE [dbo].[Question] DROP CONSTRAINT IF EXISTS [FK_Question_IdQuestionType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
ALTER TABLE [dbo].[Question] DROP CONSTRAINT IF EXISTS [FK_Question_IdModule]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
ALTER TABLE [dbo].[Question] DROP CONSTRAINT IF EXISTS [FK_Question_IdCorrectAnswer]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Module]') AND type in (N'U'))
ALTER TABLE [dbo].[Module] DROP CONSTRAINT IF EXISTS [FK_Module_IdCategory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompletedModules]') AND type in (N'U'))
ALTER TABLE [dbo].[CompletedModules] DROP CONSTRAINT IF EXISTS [FK_CompletedModules_IdUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompletedModules]') AND type in (N'U'))
ALTER TABLE [dbo].[CompletedModules] DROP CONSTRAINT IF EXISTS [FK_CompletedModules_IdModule]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Answer]') AND type in (N'U'))
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT IF EXISTS [FK_Answer_IdQuestion]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/12/2022 10:45:44 ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 09/12/2022 10:45:44 ******/
DROP TABLE IF EXISTS [dbo].[QuestionType]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 09/12/2022 10:45:44 ******/
DROP TABLE IF EXISTS [dbo].[Question]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 09/12/2022 10:45:44 ******/
DROP TABLE IF EXISTS [dbo].[Module]
GO
/****** Object:  Table [dbo].[CompletedModules]    Script Date: 09/12/2022 10:45:44 ******/
DROP TABLE IF EXISTS [dbo].[CompletedModules]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/12/2022 10:45:44 ******/
DROP TABLE IF EXISTS [dbo].[Category]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 09/12/2022 10:45:44 ******/
DROP TABLE IF EXISTS [dbo].[Answer]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 09/12/2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnswerText] [varchar](100) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/12/2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](30) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompletedModules]    Script Date: 09/12/2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompletedModules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_CompletedModules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 09/12/2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [varchar](30) NOT NULL,
	[SupportText] [varchar](max) NOT NULL,
	[ImgUrl] [varchar](max) NOT NULL,
	[Resume] [varchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 09/12/2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [varchar](max) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[CorrectAnswerId] [int] NULL,
	[QuestionTypeId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 09/12/2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_QuestionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/12/2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Experience] [int] NOT NULL,
	[ImgUrl] [varchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (1, N'Restrict', 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (2, N'Protected', 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (3, N'Public', 1, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (4, N'Private', 1, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (5, N'Namespace', 2, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (6, N'Properties', 2, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (7, N'Fields', 2, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (8, N'Methods', 2, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (9, N'Função Recursiva', 3, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (10, N'Função Responsiva', 3, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (11, N'Função Paliativa', 3, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (12, N'Função Repetitiva', 3, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (13, N'De alto nível', 4, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (14, N'De baixo nível', 4, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (15, N'De médio nível', 4, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
INSERT [dbo].[Answer] ([Id], [AnswerText], [QuestionId], [CreatedAt], [UpdatedAt]) VALUES (16, N'De altissímo nível', 4, CAST(N'2022-11-07T21:40:51.367' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Id], [CategoryName], [CreatedAt], [UpdatedAt]) VALUES (1, N'Fundamentos', CAST(N'2022-11-07T21:40:51.360' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [CategoryName], [CreatedAt], [UpdatedAt]) VALUES (2, N'WEB', CAST(N'2022-11-07T21:40:51.360' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [CategoryName], [CreatedAt], [UpdatedAt]) VALUES (3, N'UI/UX', CAST(N'2022-11-07T21:40:51.360' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [CategoryName], [CreatedAt], [UpdatedAt]) VALUES (4, N'Data Science', CAST(N'2022-11-07T21:40:51.360' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[CompletedModules] ON 
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (1, 1, 1, CAST(N'2022-12-05T21:36:08.893' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (2, 1, 1, CAST(N'2022-12-05T21:36:25.090' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (3, 1, 1, CAST(N'2022-12-05T21:38:06.540' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (4, 1, 1, CAST(N'2022-12-05T21:39:01.177' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (5, 1, 1, CAST(N'2022-12-05T21:39:50.943' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (6, 1, 1, CAST(N'2022-12-05T21:40:07.823' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (7, 1, 1, CAST(N'2022-12-05T21:51:49.473' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (8, 5, 1, CAST(N'2022-12-05T22:09:52.043' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (9, 5, 1, CAST(N'2022-12-05T22:15:52.420' AS DateTime), NULL)
GO
INSERT [dbo].[CompletedModules] ([Id], [UserId], [ModuleId], [CreatedAt], [UpdatedAt]) VALUES (10, 7, 1, CAST(N'2022-12-06T20:00:39.160' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[CompletedModules] OFF
GO
SET IDENTITY_INSERT [dbo].[Module] ON 
GO
INSERT [dbo].[Module] ([Id], [ModuleName], [SupportText], [ImgUrl], [Resume], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (1, N'Introdução', N'A linguagem C# (lê-se “cêsharp”) foi criada juntamente com a arquitetura da plataforma .NET da Microsoft. Construída do zero, sem se preocupar com compatibilidade de código legado, e a maioria das classes do framework .NET foram escritas com essa linguagem. Vários desenvolvedores participaram do projeto de criação da linguagem, mas o principal envolvido no projeto foi o engenheiro Anders Hejlsberg, que além do C# foi criador do Turbo Pascal e do Delphi.

O nome C# fez com que muitas pessoas pensassem que a cerquilha (#) seria uma sobreposição de quatro símbolos de adição, dando assim a entender que poderia ser um C++++, mas na verdade o símbolo # se refere ao sinal musical de sustenido (#), que indica meio tom acima de uma determinada nota musical. Possui uma sintaxe expressiva, elegante e é totalmente orientada a objetos.

Características da linguagem C#
A linguagem C# foi influenciada por várias linguagens, como por exemplo, JAVA e C++. Na verdade, ela é uma junção das principais vantagens dentre essas linguagens, melhorando suas implementações e adicionando novos recursos, fazendo a linguagem atrativa para desenvolvedores que queiram migrar para o Microsoft .NET.

Sua sintaxe é simples e de fácil aprendizagem, muito familiar com a sintaxe de JAVA e C. Além disso, simplifica muitas complexidades do C++, fornecendo recursos poderosos, como tipos de valor nulo, enumerações, delegações, expressões lambdas e acesso direto a memória, suporte a métodos e tipos genéricos, gerando uma melhor segurança de tipo e desempenho.', N'https://res.cloudinary.com/dte7upwcr/image/upload/v1618959177/blog/blog2/curso-de-programacao/curso-de-programacao-img_header.jpg', N'Resumo do curso de introdução', 1, CAST(N'2022-11-07T21:40:51.360' AS DateTime), NULL)
GO
INSERT [dbo].[Module] ([Id], [ModuleName], [SupportText], [ImgUrl], [Resume], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (2, N'Lógica de programação', N'', N'https://eadccna.com.br/images/logicaprog_vendas.png', N'Resumo do curso de lógica de programação', 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Module] ([Id], [ModuleName], [SupportText], [ImgUrl], [Resume], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (3, N'Criando uma API', N'', N'https://i.ytimg.com/vi/-2WKgis1wcw/maxresdefault.jpg', N'Resumo do curso de criando uma api', 2, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Module] ([Id], [ModuleName], [SupportText], [ImgUrl], [Resume], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (4, N'Figma', N'', N'https://chiefofdesign.com.br/wp-content/uploads/2021/11/curso-de-figma.png', N'Resumo do curso de figma', 3, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Module] ([Id], [ModuleName], [SupportText], [ImgUrl], [Resume], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (5, N'Introdução á Data Science', N'', N'https://insightlab.ufc.br/wp-content/uploads/2020/09/Curso-ci%C3%AAncia-de-dados.jpg', N'Resumo do curso de data science', 4, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Module] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (1, N'Em C# qual desses não é um modificador de acesso de uma classe?', 1, 1, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (2, N'Em C# qual desses não é um membro de uma classe?', 1, 5, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (3, N'Qual o nome de uma função que chama á si mesma repetidas vezes?', 1, 9, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (4, N'O C# é conhecido como uma linguagem:', 1, 13, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (5, N'Exemplo de pergunta 1', 2, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (6, N'Exemplo de pergunta 2', 2, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (7, N'Exemplo de pergunta 3', 2, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (8, N'Exemplo de pergunta 4', 2, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (9, N'Exemplo de pergunta 1', 3, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (10, N'Exemplo de pergunta 2', 3, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (11, N'Exemplo de pergunta 3', 3, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (12, N'Exemplo de pergunta 4', 3, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (13, N'Exemplo de pergunta 1', 4, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (14, N'Exemplo de pergunta 2', 4, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (15, N'Exemplo de pergunta 3', 4, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
INSERT [dbo].[Question] ([Id], [QuestionText], [ModuleId], [CorrectAnswerId], [QuestionTypeId], [CreatedAt], [UpdatedAt]) VALUES (16, N'Exemplo de pergunta 4', 4, NULL, 1, CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[QuestionType] ON 
GO
INSERT [dbo].[QuestionType] ([Id], [Type], [CreatedAt], [UpdatedAt]) VALUES (1, N'ALTERNATIVA', CAST(N'2022-11-07T21:40:51.363' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[QuestionType] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordSalt], [PasswordHash], [Email], [Experience], [ImgUrl], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (1, N'nathanfiorito', 0x4E93CFFE71F1A99BA87DF027618E5EBF2623A7E5E930708D96114439407FBA31A3B4BB33BE2C5ACAEBEF2E95A3985D5E002266724774EE491D8E9BE15DE40B366E35B6CD17A6B95CECACF17FC09287FEA7E7D07C16E2B2AE3C18A025ECE7068ECDCC6E6A6B510CDE5A0723CD8A55C9A867C015146E42056A125B6ADB79DA58C3, 0xD350B8B054AB78E82C592AF483AAA9D4B3C410FD20F696CF55806CCD169C07B5098826BFBF6E37212581A27E063BF1EB520116F9E6AB8646AD7D913F462D6CF5, N'nfiorito64@gmail.com', 690, N'../../../assets/nathan.jpg', 0, CAST(N'2022-11-07T21:39:49.813' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordSalt], [PasswordHash], [Email], [Experience], [ImgUrl], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (2, N'luisfelipe', 0xC4D844B02049CF0776D549AA56BFBF6F671BD70B26C18DECBE043BB360953680F917F403DE2E32D1B060C561CDD3FA75AA6B51FFD2DBC62F02277A95F9E30C2BA9FB4B55ACEC3E2F7B8C3ACA60F38375968B0ABAFB89DA0D993941AECC637B794B8C6A7CA388186BEB7713CD66294EC1BF3D064BB3AF44234CFC1BD6184461E5, 0xD657579016FDFC262EA00C270AF06A79D763762D9F41C0278F51FF7415E3462054231FF663C782290ED47926E9FC97BF1D8AC9FBF981700C42814E550CA544D9, N'luisfelipe', 0, N'../../../assets/luis.jpg', 0, CAST(N'2022-12-05T22:02:56.440' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordSalt], [PasswordHash], [Email], [Experience], [ImgUrl], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (3, N'felipeborges', 0xE2FC8928CC9DA3F545E8F503FE9E6A27574A3607F37F281DF70F1D4F00213A0423B5D9D60F78D20B6AF59F6ABA55C32289ADA6AC7ED0372AB0A98D5FB5D71D308FB4DED8A5208AF54C21B3D1DF1E8813ECA017ACD2749F1AC3E860791F01A83BAF1EEDAE0B776860D48D40EC915CB91DE57F21A79C45090255984A5BCB530C2F, 0x1D11360125AEDB9A778575B3DAFD115201422957F3DEBF74C4DAA947C991D2A091515B6A79DFFF04959CBAD1363CB3EDD3AADE35A1C80942163AD161556A6399, N'felipeborges', 0, N'../../../assets/felipe.jpg', 0, CAST(N'2022-12-05T22:04:11.253' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordSalt], [PasswordHash], [Email], [Experience], [ImgUrl], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (4, N'jorgelucas', 0xD5D1AAD9881F4AB1E6F784ECB521DC0C1CD7D905D55AA0C14CBEFEC9F7E9AEA4C284B31F46CEAE0F0B4DCBD62F983120680008D0E374E1A7BAD62DE6909A5F9AEAB3413FBA1D35D4A310243F65207A58DF2D2A24043D2B87B4AAA7ED9E2FB13C8EF6395E1724AD081034F790751A6D8A1F5601F147429067BEAEFA44C02E5994, 0x743832768B9387B7E101D7C37D6EE12EF9625D54A1355BFE389ACE984B5CC9739AE245EE5EE510F0F9E50F398BA48200FFC98CEAA5C656A790EA385C585C5ADA, N'jorgelucas', 0, N'../../../assets/jorge.jpg', 0, CAST(N'2022-12-05T22:04:57.937' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordSalt], [PasswordHash], [Email], [Experience], [ImgUrl], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (5, N'leoribeiro', 0xC906BF30498217A43E66047A2D603B0C5E050E0F7DFF4424905E7422AB5B24A015FF86C463D118BFD8F9938AA1167C272D01CDC7348A563B57B9EA6F64056BB1B28CF08C9820B03D616D148841FBB7B7BC42AB288EBE18B7E12AA542325A82570B92FC79F3C35C2F971A25465D3B9D3B352BCCF1D36FD753C960525410B928D3, 0x297FFDF1EE32A8D682A1F560715457800063DF5A01883F12EDC20F52D0994541165FE5ACCC023F74864D4CE2A4A6F11220A8D7E11475142DAA55ADA17ED9F751, N'leoribeiro', 240, N'../../../assets/leo.jpg', 0, CAST(N'2022-12-05T22:06:43.670' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordSalt], [PasswordHash], [Email], [Experience], [ImgUrl], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (6, N'ApresetacaoTCC', 0xA7DD4CAFD2E61AFD04A4D3799ABD39C41363D2693DC0A764F85038DEE6B79BB6BF73456A525EA585B8A4DAEAADBF393495AFCA310477BC56463B1B07136E21E52F859218B4123B6A1D5D657361A4DF01794D811DAE3F949027FBDAE2275DB649238D3032B685103BAE01A02C92238D4541A457CDC7F833E385C22F51D8D36354, 0x7E2C10618083F4C1D817A14ED626CF173EA2DA22A726FB789FF73126DB211277A45AF175D1D5761BC7076E6D5CC0C46ED823B5E5BEF7B87A880200C31280E5D2, N'teste@gmail.com', 0, N'https://cdn.discordapp.com/attachments/527648118955835394/1034984951617171566/generic.png', 0, CAST(N'2022-12-06T19:58:24.953' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordSalt], [PasswordHash], [Email], [Experience], [ImgUrl], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (7, N'apresentacao', 0xA9CA5A5452F5D8EDC17C33C32003839A92A3521C87BCA8582B2B617388B83A434BD527B0163CA364C2A2684F785DF819517A36FC558F212D1FCCC4EBEDD0B7E6CE38BFE573A36EDCB824DBC62C50F5DB15B760E02B63E7E0A9B47360BCE089E52BDB92AEC74D2D2D023B7DCA065E42EE296382B32299487553B8D0A7A24D75AC, 0x89DDF1C317EEDE6825A85B1CFEB045AEDF30EFE660103E959B522B54FFBAC51D448803A656504397A1953721CB49345DF2D83261CBE3A5623ECC0CE7D31A7343, N'teste@gmail.com', 90, N'https://cdn.discordapp.com/attachments/527648118955835394/1034984951617171566/generic.png', 0, CAST(N'2022-12-06T19:59:00.610' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Answer]  WITH NOCHECK ADD  CONSTRAINT [FK_Answer_IdQuestion] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_IdQuestion]
GO
ALTER TABLE [dbo].[CompletedModules]  WITH CHECK ADD  CONSTRAINT [FK_CompletedModules_IdModule] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[CompletedModules] CHECK CONSTRAINT [FK_CompletedModules_IdModule]
GO
ALTER TABLE [dbo].[CompletedModules]  WITH CHECK ADD  CONSTRAINT [FK_CompletedModules_IdUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CompletedModules] CHECK CONSTRAINT [FK_CompletedModules_IdUser]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_Module_IdCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_Module_IdCategory]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_IdCorrectAnswer] FOREIGN KEY([CorrectAnswerId])
REFERENCES [dbo].[Answer] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_IdCorrectAnswer]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_IdModule] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_IdModule]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_IdQuestionType] FOREIGN KEY([QuestionTypeId])
REFERENCES [dbo].[QuestionType] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_IdQuestionType]
GO
