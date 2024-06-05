CREATE TABLE [dbo].[ALUMNO] (
    [Matricula]   INT           IDENTITY (10000, 1) NOT NULL,
    [Nombre]      VARCHAR (80)  NOT NULL,
    [APaterno]    VARCHAR (80)  NOT NULL,
    [AMaterno]    VARCHAR (80)  NOT NULL,
    [IsActivo]    BIT           CONSTRAINT [DF_IsActivo_ALU] DEFAULT ((1)) NOT NULL,
    [FecNaci]     DATE          NOT NULL,
    [FecRegistro] SMALLDATETIME CONSTRAINT [DF_FecRegistro_ALU] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Matricula_ALU] PRIMARY KEY CLUSTERED ([Matricula] ASC)
);

