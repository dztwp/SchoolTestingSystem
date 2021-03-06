USE [TestingSystem]
GO
/****** Object:  Table [dbo].[AnswersForQuestion]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnswersForQuestion](
	[Answer1] [nvarchar](50) NOT NULL,
	[Answer2] [nvarchar](50) NOT NULL,
	[Answer3] [nvarchar](50) NOT NULL,
	[Answer4] [nvarchar](50) NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [uniqueidentifier] NOT NULL,
	[NumberOfQuestion] [int] NOT NULL,
	[NumberOfRightAnswer] [int] NOT NULL,
	[IsRight] [bit] NOT NULL,
	[IdTest] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[Id] [uniqueidentifier] NOT NULL,
	[TimeToComplete] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDone] [bit] NOT NULL,
	[NumberOfQuestions] [int] NOT NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[IdRole] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTestResults]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTestResults](
	[IdUser] [uniqueidentifier] NOT NULL,
	[IdTest] [uniqueidentifier] NOT NULL,
	[TestResult] [int] NOT NULL,
	[QuantityOfQuestions] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AnswersForQuestion]  WITH CHECK ADD  CONSTRAINT [FK_AnswersForQuestion_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AnswersForQuestion] CHECK CONSTRAINT [FK_AnswersForQuestion_Question]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Test] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Test]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserTestResults]  WITH CHECK ADD  CONSTRAINT [FK_UserTestResults_Test] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTestResults] CHECK CONSTRAINT [FK_UserTestResults_Test]
GO
ALTER TABLE [dbo].[UserTestResults]  WITH CHECK ADD  CONSTRAINT [FK_UserTestResults_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserTestResults] CHECK CONSTRAINT [FK_UserTestResults_User]
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_AddAnswersForQuestion]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_AddAnswersForQuestion]
	-- Add the parameters for the stored procedure here
	@answer1 nvarchar(50),
	@answer2 nvarchar(50),
	@answer3 nvarchar(50),
	@answer4 nvarchar(50),
	@questionId uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	insert AnswersForQuestion(Answer1,Answer2,Answer3,Answer4,QuestionId) values (@answer1,@answer2,@answer3,@answer4,@questionId)
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_AddQuestion]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_AddQuestion]
	@Id uniqueidentifier,
	@numberOfQuestion int,
	@numberOfRightAnswer int,
	@IdTest uniqueidentifier,
	@description nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Insert into Question(Id,NumberOfQuestion ,NumberOfRightAnswer,IsRight,IdTest,"Description") values(@Id,@numberOfQuestion,@numberOfRightAnswer,0,@IdTest,@description)
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_AddTest]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_AddTest]
	@id uniqueidentifier,
	@description nvarchar(50),
	@timeToComplete int,
	@numberOfQuestions int
AS
BEGIN
	SET NOCOUNT OFF;

    INSERT INTO Test(Id,TimeToComplete,"Name",IsDone,NumberOfQuestions) values (@id,@timeToComplete,@description,0,@numberOfQuestions)
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_AddUser]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TestingSystem_AddUser]
	@Id uniqueidentifier,
	@Login nvarchar(50),
	@Password nvarchar(max),
	@Name nvarchar(50),
	@SurName nvarchar(50),
	@RoleName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO "User"(Id,Login,Password,Name,Surname,IdRole) values (@Id,@Login,@Password,@Name,@SurName,(Select Id from Role Where RoleName=@RoleName))
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_BindingTestToUser]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_BindingTestToUser]
	-- Add the parameters for the stored procedure here
	@userId uniqueidentifier,
	@testId uniqueidentifier,
	@quontityOfRightAnswers int,
	@quontityOfQuestions int
AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO UserTestResults(IdUser,IdTest,TestResult,QuantityOfQuestions) values (@userId,@testId,@quontityOfRightAnswers,@quontityOfQuestions)
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetAllTestsDescriptions]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TestingSystem_GetAllTestsDescriptions]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select Name from Test
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetAnswersByQuestionID]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_GetAnswersByQuestionID]
	@Id uniqueidentifier
AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From AnswersForQuestion where QuestionId=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetQuestionsById]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_GetQuestionsById]
	@Id uniqueidentifier
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Question where IdTest=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetTestByDescription]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_GetTestByDescription]
	@description nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Test where Name=@description
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetTestDescriptionByTestId]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TestingSystem_GetTestDescriptionByTestId]
	-- Add the parameters for the stored procedure here
	@testId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT Test.Name FROM Test Where Id=@testId
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetTestParamsByDescription]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_GetTestParamsByDescription]
	@description nvarchar(50)
AS
BEGIN

	SET NOCOUNT OFF;


	SELECT * FROM Test where Name=@description;
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetTestResultByIds]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_GetTestResultByIds]
	-- Add the parameters for the stored procedure here
	@userId uniqueidentifier,
	@testId uniqueidentifier
AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * From UserTestResults where ((IdUser=@userId) AND (IdTest=@testId))
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetUserByLogin]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_GetUserByLogin]
	 @login nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT * FROM "User" where Login=@login
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetUserRoles]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TestingSystem_GetUserRoles]
	-- Add the parameters for the stored procedure here
	@login nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT RoleName From Role Where (Id=(Select IdRole FROM "User" Where Login=@login))
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_GetUsersResults]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_GetUsersResults]
	@userId uniqueidentifier
AS
BEGIN

	SET NOCOUNT ON;


	SELECT UserTestResults.IdUser,IdTest,Test.Name FROM UserTestResults,Test where UserTestResults.IdUser=@userId AND IdTest=Test.Id
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_IsLoginExist]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_IsLoginExist]
	@login nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	SET NOCOUNT ON;
	if(SELECT COUNT(*) FROM "User" WHERE (Login=@login))>0
	Select 1;
	else
	Select 0;
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_IsTestDone]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_IsTestDone]
	@userId uniqueidentifier,
	@testId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET NOCOUNT ON;
	if(SELECT COUNT(*) FROM UserTestResults WHERE (IdUser=@userId AND IdTest=@testId))>0
	Select 1;
	else
	Select 0;
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_IsTestExist]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_IsTestExist]
	@description nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	if(SELECT COUNT(*) FROM Test WHERE (Name=@description))>0
	Select 1;
	else
	Select 0;
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_IsUserInRole]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_IsUserInRole] 
	@login nvarchar(50),
	@role  nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	if(SELECT COUNT(*) FROM "User" WHERE (Login=@login AND 
	(IdRole=(SELECT Id FROM Role Where RoleName=@role))))>0
	Select 1;
	else
	Select 0;
    
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_IsUserRegistered]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_IsUserRegistered]
	@Login nvarchar(50),
	@password nvarchar(max)
AS
BEGIN

	SET NOCOUNT ON;
	if(SELECT COUNT(*) FROM "User" WHERE (Login=@Login AND Password=@password))>0
	Select 1;
	else
	Select 0;

    
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_TestDeletion]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_TestDeletion]
	@id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here

	
	DELETE FROM Test WHERE (Id=@id)
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_UpdateAnswersForQuestion]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TestingSystem_UpdateAnswersForQuestion]
	-- Add the parameters for the stored procedure here
	@answer1 nvarchar(50),
	@answer2 nvarchar(50),
	@answer3 nvarchar(50),
	@answer4 nvarchar(50),
	@questionId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Update AnswersForQuestion 
	Set Answer1=@answer1,Answer2=@answer2,Answer3=@answer3,Answer4=@answer4
	Where QuestionId=@questionId
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_UpdateQuestion]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_UpdateQuestion]
	@id uniqueidentifier,
	@numberOfQuestion int,
	@numberOfRightAnswer int,
	@description nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Update Question 
	SET Description=@description,NumberOfQuestion=@numberOfQuestion,NumberOfRightAnswer=@numberOfRightAnswer
	WHERE Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[TestingSystem_UpdateTest]    Script Date: 20.07.2021 23:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestingSystem_UpdateTest]
	@id uniqueidentifier,
	@description nvarchar(50),
	@timeToComplete int,
	@numberOfQuestions int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Update Test 
	SET Name=@description, TimeToComplete=@timeToComplete,NumberOfQuestions=@numberOfQuestions
	WHERE Id=@id
END
GO
