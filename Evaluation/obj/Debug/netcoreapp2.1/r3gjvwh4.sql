IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Profesor] (
    [pId] int NOT NULL IDENTITY,
    [Username] nvarchar(30) NOT NULL,
    [Password] nvarchar(18) NOT NULL,
    CONSTRAINT [PK_Profesor] PRIMARY KEY ([pId])
);

GO

CREATE TABLE [Student] (
    [sId] int NOT NULL IDENTITY,
    [studUsername] nvarchar(30) NOT NULL,
    [studPassword] nvarchar(18) NOT NULL,
    [grade] int NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([sId])
);

GO

CREATE TABLE [Course] (
    [cId] int NOT NULL IDENTITY,
    [courseName] nvarchar(max) NOT NULL,
    [profesorId] int NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([cId]),
    CONSTRAINT [FK_Course_Profesor_profesorId] FOREIGN KEY ([profesorId]) REFERENCES [Profesor] ([pId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Question] (
    [qId] int NOT NULL IDENTITY,
    [Text] nvarchar(1200) NOT NULL,
    [Answer] nvarchar(500) NOT NULL,
    [Difficulty] int NOT NULL,
    [Time] int NOT NULL,
    [profesorId] int NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY ([qId]),
    CONSTRAINT [FK_Question_Profesor_profesorId] FOREIGN KEY ([profesorId]) REFERENCES [Profesor] ([pId]) ON DELETE CASCADE
);

GO

CREATE TABLE [CourseStudent] (
    [sId] int NOT NULL,
    [cId] int NOT NULL,
    CONSTRAINT [PK_CourseStudent] PRIMARY KEY ([sId], [cId]),
    CONSTRAINT [FK_CourseStudent_Course_cId] FOREIGN KEY ([cId]) REFERENCES [Course] ([cId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CourseStudent_Student_sId] FOREIGN KEY ([sId]) REFERENCES [Student] ([sId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Exam] (
    [eId] int NOT NULL IDENTITY,
    [nrQuestions] int NOT NULL,
    [examTime] int NOT NULL,
    [examDifficulty] int NOT NULL,
    [profesorId] int NOT NULL,
    [CoursecId] int NULL,
    CONSTRAINT [PK_Exam] PRIMARY KEY ([eId]),
    CONSTRAINT [FK_Exam_Course_CoursecId] FOREIGN KEY ([CoursecId]) REFERENCES [Course] ([cId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Exam_Profesor_profesorId] FOREIGN KEY ([profesorId]) REFERENCES [Profesor] ([pId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ExamQuestion] (
    [qId] int NOT NULL,
    [eId] int NOT NULL,
    CONSTRAINT [PK_ExamQuestion] PRIMARY KEY ([eId], [qId]),
    CONSTRAINT [FK_ExamQuestion_Exam_eId] FOREIGN KEY ([eId]) REFERENCES [Exam] ([eId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ExamQuestion_Question_qId] FOREIGN KEY ([qId]) REFERENCES [Question] ([qId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Feedback] (
    [fId] int NOT NULL IDENTITY,
    [Text] nvarchar(max) NOT NULL,
    [examId] int NOT NULL,
    CONSTRAINT [PK_Feedback] PRIMARY KEY ([fId]),
    CONSTRAINT [FK_Feedback_Exam_examId] FOREIGN KEY ([examId]) REFERENCES [Exam] ([eId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Course_profesorId] ON [Course] ([profesorId]);

GO

CREATE INDEX [IX_CourseStudent_cId] ON [CourseStudent] ([cId]);

GO

CREATE INDEX [IX_Exam_CoursecId] ON [Exam] ([CoursecId]);

GO

CREATE INDEX [IX_Exam_profesorId] ON [Exam] ([profesorId]);

GO

CREATE INDEX [IX_ExamQuestion_qId] ON [ExamQuestion] ([qId]);

GO

CREATE INDEX [IX_Feedback_examId] ON [Feedback] ([examId]);

GO

CREATE INDEX [IX_Question_profesorId] ON [Question] ([profesorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181110113719_Initial', N'2.1.4-rtm-31024');

GO

