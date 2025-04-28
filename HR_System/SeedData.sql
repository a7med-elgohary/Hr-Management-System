-- Seed data for HR_System

-- 1. Departments
INSERT INTO Departments (Name)
VALUES ('IT'), ('HR'), ('Finance');

-- 2. Employees
INSERT INTO Employees (FullName, Email, Password, Address, PhoneNumber, JobTitle, HireDate, NetSalary, DepartmentId, UserAccountId)
VALUES 
  ('Ahmed Ali', 'ahmed.ali@company.com', 'Test1234!', 'Cairo', '01000000001', 'Developer', '2025-01-01', 5000.00, 1, NULL),
  ('Sara Samir', 'sara.samir@company.com', 'Test1234!', 'Giza', '01000000002', 'HR Manager', '2024-07-15', 6000.00, 2, NULL);

-- 3. Roles
INSERT INTO Roles (Name)
VALUES ('Admin'), ('Employee'), ('Manager');

-- 4. Permissions
INSERT INTO Permissions (Name, Description)
VALUES 
  ('ViewEmployees', 'View employees'),
  ('EditEmployees', 'Edit employees'),
  ('DeleteEmployees', 'Delete employees'),
  ('ViewAttendance', 'View attendance');

-- 5. Users
INSERT INTO Users (EmployeeId, Username, PasswordHash, Email, IsActive, CreatedAt)
VALUES 
  (1, 'ahmed', '$2a$11$hashedpassword1', 'ahmed.ali@company.com', 1, GETDATE()),
  (2, 'sara', '$2a$11$hashedpassword2', 'sara.samir@company.com', 1, GETDATE());

-- 6. UserRoles
INSERT INTO UserRoles (UserId, RoleId)
VALUES (1, 1), (2, 2);

-- 7. RolePermissions
INSERT INTO RolePermissions (RoleId, PermissionId)
VALUES 
  (1, 1), (1, 2), (1, 3),  -- Admin
  (2, 1), (2, 4),          -- Employee
  (3, 1), (3, 2), (3, 4);  -- Manager

-- 8. Attendances
INSERT INTO Attendances (EmployeeId, DayDate, CheckInTime, CheckOutTime, Status)
VALUES 
  (1, '2025-04-27', '08:00:00', '16:00:00', 0),
  (2, '2025-04-27', '08:15:00', '16:15:00', 2);

-- 9. Leaves
INSERT INTO Leaves (EmployeeId, LeaveType, StartDate, EndDate, Status, Reason)
VALUES 
  (1, 'Sick', '2025-04-25', '2025-04-27', 1, 'Flu'),
  (2, 'Annual', '2025-05-01', '2025-05-03', 0, 'Vacation');

-- 10. Salaries
INSERT INTO Salaries (EmployeeId, Bounes, Deduction, Ammout, PaymentDate, Status)
VALUES 
  (1, 500, 0, 5500.00, '2025-04-01', 0),
  (2, 0, 100, 4900.00, '2025-04-01', 1);

-- 11. Promotions
INSERT INTO Promotions (employeeId, PromotionDate, NewJobTitle, NewSalary, Reason)
VALUES (1, '2025-03-01', 'Senior Developer', 7000.00, 'Excellent performance');

-- 12. EmployeeTasks
INSERT INTO EmployeeTasks (EmployeeId, TaskDescription, StartDate, EndDate, Status)
VALUES 
  (1, 'Build API Endpoints', '2025-04-20', '2025-04-30', 1),
  (2, 'Prepare HR Report', '2025-04-21', '2025-04-28', 0);

-- 13. Trainings
INSERT INTO Trainings (EmployeeId, TrainingName, TrainingDate, Status)
VALUES 
  (1, 'C# Advanced', '2025-04-10', 2),
  (2, 'HR Best Practices', '2025-04-15', 0);

-- 14. AuditLogs
INSERT INTO AuditLogs (UserId, Action, Timestamp)
VALUES 
  (1, 'Login', GETDATE()),
  (2, 'View Employees', GETDATE());
