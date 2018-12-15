CREATE TABLE [Profesor] (
	Id integer NOT NULL,
	Username varchar(255) NOT NULL UNIQUE,
	Password varchar(255) NOT NULL,
	classId integer NOT NULL,
  CONSTRAINT [PK_PROFESOR] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Student] (
	sId integer NOT NULL,
	studentName varchar(255) NOT NULL,
	studentPassword varchar(255) NOT NULL,
	grade integer NOT NULL,
  CONSTRAINT [PK_STUDENT] PRIMARY KEY CLUSTERED
  (
  [sId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Exam] (
	examId integer NOT NULL,
	nrQuestions integer NOT NULL,
	examTime datetime NOT NULL,
	examDifficulty integer NOT NULL,
	profId integer NOT NULL,
  CONSTRAINT [PK_EXAM] PRIMARY KEY CLUSTERED
  (
  [examId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Question] (
	qId integer NOT NULL,
	profId integer NOT NULL,
	Text varchar(5000) NOT NULL,
	Answer varchar(500) NOT NULL,
	 Difficulty integer NOT NULL,
	Time datetime NOT NULL,
  CONSTRAINT [PK_QUESTION] PRIMARY KEY CLUSTERED
  (
  [qId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Class] (
	cId integer NOT NULL,
	Name varchar(50) NOT NULL,
  CONSTRAINT [PK_CLASS] PRIMARY KEY CLUSTERED
  (
  [cId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Feedback] (
	fId integer NOT NULL,
	text varchar(5000) NOT NULL,
	examId integer NOT NULL,
  CONSTRAINT [PK_FEEDBACK] PRIMARY KEY CLUSTERED
  (
  [fId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ExamQuestions] (
	ExamId integer NOT NULL,
	QuestionId integer NOT NULL
)
GO
CREATE TABLE [StudClass] (
	classId integer NOT NULL,
	studId integer NOT NULL
)
GO
ALTER TABLE [Profesor] WITH CHECK ADD CONSTRAINT [Profesor_fk0] FOREIGN KEY ([classId]) REFERENCES [Class]([cId])
ON UPDATE CASCADE
GO
ALTER TABLE [Profesor] CHECK CONSTRAINT [Profesor_fk0]
GO


ALTER TABLE [Exam] WITH CHECK ADD CONSTRAINT [Exam_fk0] FOREIGN KEY ([profId]) REFERENCES [Profesor]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Exam] CHECK CONSTRAINT [Exam_fk0]
GO

ALTER TABLE [Question] WITH CHECK ADD CONSTRAINT [Question_fk0] FOREIGN KEY ([profId]) REFERENCES [Profesor]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Question] CHECK CONSTRAINT [Question_fk0]
GO


ALTER TABLE [Feedback] WITH CHECK ADD CONSTRAINT [Feedback_fk0] FOREIGN KEY ([examId]) REFERENCES [Exam]([examId])
ON UPDATE CASCADE
GO
ALTER TABLE [Feedback] CHECK CONSTRAINT [Feedback_fk0]
GO

ALTER TABLE [ExamQuestions] WITH CHECK ADD CONSTRAINT [ExamQuestions_fk0] FOREIGN KEY ([ExamId]) REFERENCES [Exam]([examId])
ON UPDATE CASCADE
GO
ALTER TABLE [ExamQuestions] CHECK CONSTRAINT [ExamQuestions_fk0]
GO
ALTER TABLE [ExamQuestions] WITH CHECK ADD CONSTRAINT [ExamQuestions_fk1] FOREIGN KEY ([QuestionId]) REFERENCES [Question]([qId])
ON UPDATE NO ACTION
GO
ALTER TABLE [ExamQuestions] CHECK CONSTRAINT [ExamQuestions_fk1]
GO

ALTER TABLE [StudClass] WITH CHECK ADD CONSTRAINT [StudClass_fk0] FOREIGN KEY ([classId]) REFERENCES [Class]([cId])
ON UPDATE CASCADE
GO
ALTER TABLE [StudClass] CHECK CONSTRAINT [StudClass_fk0]
GO
ALTER TABLE [StudClass] WITH CHECK ADD CONSTRAINT [StudClass_fk1] FOREIGN KEY ([studId]) REFERENCES [Student]([sId])
ON UPDATE CASCADE
GO
ALTER TABLE [StudClass] CHECK CONSTRAINT [StudClass_fk1]
GO
