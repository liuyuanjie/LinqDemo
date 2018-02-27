USE [LINQ]
CREATE TABLE [Student]
(
	[StID] [INT] IDENTITY(1,1) NOT NULL,
	[FirstName] [VARCHAR](50) NOT NULL,
	[LastName] [VARCHAR](50)  NOT NULL,
	[Age] [INT] NOT NULL

	CONSTRAINT PK_StudentId PRIMARY KEY CLUSTERED
		(StID)
)

ALTER TABLE [Student]
ADD CONSTRAINT UX_FirstName_LastName UNIQUE
	(FirstName, LastName)

CREATE NONCLUSTERED INDEX [IX_Student_FirstName]
	ON [Zion].[Student](FirstName)
GO

CREATE NONCLUSTERED INDEX [IX_Student_LastName]
	ON [Zion].[Student](LastName)
GO

INSERT INTO [Student]
VALUES('Liu','Yuanjie',2),
		('Liu','Jia',12),
		('Qu','Jiangbo',2),
		('Li','Xing',15)

CREATE TABLE [Course]
(
	[StID] [INT] NOT NULL,
	[CourseName] [VARCHAR](50) NULL
)

ALTER TABLE [Course]
ADD CONSTRAINT UX_StID_CourseName UNIQUE
	(StID, CourseName)

INSERT INTO [Course]
VALUES(1,'Art'),
		(2,'History'),
		(3,'History'),
		(4,'Physics')