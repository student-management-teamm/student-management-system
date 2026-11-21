CREATE DATABASE IF NOT EXISTS student_management_group
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE student_management_group;

CREATE TABLE IF NOT EXISTS students (
    StudentId INT NOT NULL AUTO_INCREMENT,
    StudentCode VARCHAR(20) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(150),
    DateOfBirth DATE,
    PhoneNumber VARCHAR(20),
    PRIMARY KEY (StudentId),
    UNIQUE (StudentCode)
);