USE [ChatDB]
GO

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[ConcurrencyStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnd]
           ,[LockoutEnabled]
           ,[AccessFailedCount])
     VALUES
           ('d03d50c4-533e-4ff0-8618-a0ecb8a0b820'
           ,'Miki'
           ,'MIKI'
           ,NULL
           ,NULL
           ,1
           ,'AQAAAAEAACcQAAAAEMI1HKZ/2PFGQ314DR93QTAAxS5S3fzYVtJWr6liHEdaxt2v5fAm5DAXtHOoBCHkQA==' /*Пароль qaqa10qa*/
           ,'GKREPIMP7J3PS6MBKRW5UJJVCVGC6ADY'
           ,'1c8646e1-013e-4db5-9c0e-3f2bd8b4702d'
           ,NULL
           ,0
           ,0
           ,NULL
           ,1
           ,0),
		    ('84b3d539-932b-4fa5-9859-8451673752b5'
           ,'Garu'
           ,'GARU'
           ,NULL
           ,NULL
           ,1
           ,'AQAAAAEAACcQAAAAEB5xEjxVp9P87PNd7Y9Vy/WStW6ENBnvnkNQlk7ePN2rY2/e3toqUVe6nbtwR/FF4w==' /*Пароль gaga10ga*/
           ,'VC3BYKGXCOXSBOMSGFCTNQOGZGQLGUUZ'
           ,'afa0730a-9450-4ffe-928b-50a9f7f93ef0'
           ,NULL
           ,0
           ,0
           ,NULL
           ,1
           ,0),
		    ('f4c2d385-12f7-43a1-8fd4-ad3e46610637'
           ,'Mouse'
           ,'MOUSE'
           ,NULL
           ,NULL
           ,1
           ,'AQAAAAEAACcQAAAAELCmktC4t/BTF8krBLgNIfcA5XSmcS6LOMNN1QaHvK6T9ZJjANlPQl9pgNfd0YZJNQ==' /*Пароль dada10da*/
           ,'5VYLOX67HAMEFUQV4A6GX57ZDOJMBLK5'
           ,'9797ee2b-b3eb-4372-936c-a16dd4968fc0'
           ,NULL
           ,0
           ,0
           ,NULL
           ,1
           ,0),
		    ('c71c2dcf-f540-45e4-85d0-524a6b0503a9'
           ,'AnimeBoy'
           ,'ANIMEBOY'
           ,NULL
           ,NULL
           ,1
           ,'AQAAAAEAACcQAAAAEJkoPij25C2B7pwTqF+92Rv1cmWt7iHE3ksUhWNSOV9xTLch51CTrvPjVkAlKmPqQg==' /*Пароль AnimeBoy*/
           ,'EMAUCOEHT2XQNXNSAJUHAS4ZXV3AGDLK'
           ,'92163290-d235-467c-889b-b60b7f997821'
           ,NULL
           ,0
           ,0
           ,NULL
           ,1
           ,0)
GO


