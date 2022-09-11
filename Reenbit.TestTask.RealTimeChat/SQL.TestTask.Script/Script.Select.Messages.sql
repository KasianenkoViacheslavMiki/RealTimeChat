/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [Id]
      ,[TextMessage]
      ,[DateMessage]
      ,[userId]
      ,[roomId]
  FROM [ChatDB].[dbo].[Message]
  ORDER BY ChatDB.dbo.Message.DateMessage