/* Use MS Access UI or a tool to run equivalent CREATE TABLE statements.
   Access SQL may differ; recommended: create tables in Access design view
   using the fields below. 
*/

-- Students
CREATE TABLE Students (
  StudentID AUTOINCREMENT PRIMARY KEY,
  FirstName TEXT(100),
  LastName TEXT(100),
  Class TEXT(50),
  RollNo TEXT(20),
  DOB DATETIME,
  Contact TEXT(50),
  Email TEXT(100)
);

-- Users
CREATE TABLE Users (
  UserID AUTOINCREMENT PRIMARY KEY,
  Username TEXT(100),
  PasswordHash TEXT(200),
  Role TEXT(20),
  StudentID LONG
);

-- Attendance
CREATE TABLE Attendance (
  AttendanceID AUTOINCREMENT PRIMARY KEY,
  StudentID LONG,
  Date DATETIME,
  Status TEXT(20),
  MarkedBy TEXT(100),
  Remarks TEXT(255)
);
