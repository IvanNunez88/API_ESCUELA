USE [dbESCUELA]
GO
SET IDENTITY_INSERT [dbo].[ALUMNO] ON 
GO
INSERT [dbo].[ALUMNO] ([Matricula], [Nombre], [APaterno], [AMaterno], [IsActivo], [FecNaci], [FecRegistro]) VALUES (10000, N'LauraP', N'MartinezP', N'PerezP', 1, CAST(N'1994-05-11' AS Date), CAST(N'2024-06-04T11:36:00' AS SmallDateTime))
GO
SET IDENTITY_INSERT [dbo].[ALUMNO] OFF
GO
