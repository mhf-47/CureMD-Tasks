--Task 1: Create a Database

Create Database MHFNEW;

USE MHFNEW;

--Task 2: Create Tables
CREATE TABLE Courses (
	CourseID int NOT NULL IDENTITY (101,1),
	CourseName varchar (100),
	PRIMARY KEY (CourseID)
    )
Select*From Courses

CREATE TABLE Students (
	StudentID int NOT NULL IDENTITY (1,1),
	FirstName varchar (50),
	LastName varchar (50),
	Age int,
	CourseID int,
	PRIMARY KEY (StudentID),
	FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
	)
Select*From Students


--Task 3: Insert Data
Insert into Courses(CourseName) 
Values ('Mechanics'), 
('Dynamics'),
('English'),
('Maths'),
('Urdu')
Select*From Courses

Insert into Students(FirstName, LastName, Age, CourseID) 
Values 
('Ahmed', 'Ali', 20, 102),
('Qureshi', 'Ali', 23, 101),
('Fahad', 'Ali', 22, 104),
('Noman', 'Ali', 19, 104),
('Noufil', 'Ali', 28, 104),
('Haider', 'Ali', 27, 102),
('Babar', 'Ali', 25, NULL),
('Haris', 'Ali', 23, 101),
('Shadab', 'Ali', 24, 103),
('Abdullah', 'Ali', 22, 105)
Select*From Students

SELECT Students.StudentID, Courses.CourseName, Students.FirstName, Students.Age
FROM Students
JOIN Courses ON Students.CourseID = Courses.CourseID;

--Task 4: Update and Delete Records
UPDATE Students 
SET Age = 33 
WHERE StudentID = 9

DELETE FROM Students
WHERE StudentID = 10;

--Task 5: Queries and Filters

SELECT * FROM Students
WHERE Age >= 20;

Select Students.StudentID, Students.FirstName, Students.Age, Students.CourseID, Courses.CourseName From Students
JOIN Courses ON Students.CourseID = Courses.CourseID
WHERE Students.CourseID = 104;

--Task 6: Aggregation Functions
Select COUNT(StudentID) --Finds the no. of unique entries (PK) to return the no. of students 
From Students

Select AVG(Age)
From Students

--Task 7: Stored Procedures

--7.4 Create a stored procedure to list all students.
CREATE PROCEDURE ListAllStudents
AS
BEGIN
    SELECT*FROM Students 
END;
GO

--7.1 Create a stored procedure to add a new student. 
CREATE PROCEDURE AddStudent
    
	@newFirstName VARCHAR(50),
	@newLastName VARCHAR(50),
    @newAge INT,
    @newCourseID INT
AS
BEGIN
    INSERT INTO Students (FirstName, LastName, Age, CourseID)
    VALUES (@newFirstName, @newLastName, @newAge, @newCourseID);
END;
GO

--7.2 Create a stored procedure to update a student's age.
CREATE PROCEDURE UpdateStudentAge
    @ID INT,
    @NewAge INT
AS
BEGIN
    UPDATE Students
    SET Age = @NewAge
    WHERE StudentID = @ID;
END;
GO

--7.3 Create a stored procedure to delete a student.
CREATE PROCEDURE DeleteStudent
    @ID INT    
AS
BEGIN
    DELETE FROM Students 
    WHERE StudentID = @ID;
END;
GO






















