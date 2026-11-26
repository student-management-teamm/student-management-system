-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: student_management_group
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `student_management_group`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `student_management_group` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `student_management_group`;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classes` (
  `ClassID` int NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DepartmentID` int DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`ClassID`),
  UNIQUE KEY `ClassName` (`ClassName`),
  KEY `FK_Classes_Departments` (`DepartmentID`),
  CONSTRAINT `FK_Classes_Departments` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`DepartmentID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES (1,'DCIT.13.10',1,NULL),(2,'DCBM.13.10',2,NULL),(3,'DCIT.14.1',1,NULL),(4,'DCIT.15',1,NULL),(5,'DCIT.14.2',1,NULL),(6,'DCIT.14.3',1,NULL),(7,'DCBM.16',2,NULL),(8,'DCMM.16',3,NULL),(9,'DCIT.12.10',1,NULL),(10,'DCBM.12.10',2,NULL);
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classsubjects`
--

DROP TABLE IF EXISTS `classsubjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classsubjects` (
  `ClassID` int NOT NULL,
  `SubjectID` int NOT NULL,
  `LecturerID` int DEFAULT NULL,
  PRIMARY KEY (`ClassID`,`SubjectID`),
  KEY `FK_ClassSubjects_Subjects` (`SubjectID`),
  KEY `FK_ClassSubjects_Lecturers` (`LecturerID`),
  CONSTRAINT `FK_ClassSubjects_Classes` FOREIGN KEY (`ClassID`) REFERENCES `classes` (`ClassID`),
  CONSTRAINT `FK_ClassSubjects_Lecturers` FOREIGN KEY (`LecturerID`) REFERENCES `lecturers` (`LecturerID`),
  CONSTRAINT `FK_ClassSubjects_Subjects` FOREIGN KEY (`SubjectID`) REFERENCES `subjects` (`SubjectID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classsubjects`
--

LOCK TABLES `classsubjects` WRITE;
/*!40000 ALTER TABLE `classsubjects` DISABLE KEYS */;
INSERT INTO `classsubjects` VALUES (1,2,1),(1,7,1),(3,2,1),(3,7,1),(4,2,1),(4,7,1),(5,2,1),(5,7,1),(6,2,1),(6,7,1),(9,2,1),(9,7,1),(1,3,2),(1,6,2),(3,3,2),(3,6,2),(4,3,2),(4,6,2),(5,3,2),(5,6,2),(6,3,2),(6,6,2),(9,3,2),(9,6,2),(1,4,3),(3,4,3),(4,4,3),(5,4,3),(6,4,3),(9,4,3),(1,5,4),(3,5,4),(4,5,4),(5,5,4),(6,5,4),(9,5,4),(1,8,5),(3,8,5),(4,8,5),(5,8,5),(6,8,5),(9,8,5),(1,1,6),(3,1,6),(4,1,6),(5,1,6),(6,1,6),(9,1,6),(2,9,7),(7,9,7),(10,9,7),(2,10,8),(7,10,8),(10,10,8),(2,11,9),(7,11,9),(10,11,9),(2,12,10),(7,12,10),(10,12,10),(2,13,11),(7,13,11),(10,13,11),(2,14,12),(7,14,12),(10,14,12),(2,15,13),(7,15,13),(10,15,13),(2,16,14),(7,16,14),(10,16,14),(2,17,15),(7,17,15),(10,17,15),(8,18,16),(8,19,17),(8,20,18),(8,21,19),(8,22,20);
/*!40000 ALTER TABLE `classsubjects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departments` (
  `DepartmentID` int NOT NULL AUTO_INCREMENT,
  `DepartmentCode` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DepartmentName` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`DepartmentID`),
  UNIQUE KEY `DepartmentCode` (`DepartmentCode`),
  UNIQUE KEY `DepartmentName` (`DepartmentName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'DCIT','Công nghệ thông tin (bằng tiếng Anh)',NULL),(2,'DCBM','Quản trị kinh doanh (chương trình quốc tế)',NULL),(3,'DCMM','Quản trị Marketing (bằng tiếng Anh)',NULL);
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lecturers`
--

DROP TABLE IF EXISTS `lecturers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lecturers` (
  `LecturerID` int NOT NULL AUTO_INCREMENT,
  `LecturerCode` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `LastName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `FirstName` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Email` varchar(150) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PhoneNumber` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `DepartmentID` int DEFAULT NULL,
  PRIMARY KEY (`LecturerID`),
  UNIQUE KEY `LecturerCode` (`LecturerCode`),
  UNIQUE KEY `UX_Lecturers_Email` (`Email`),
  KEY `FK_Lecturers_Departments` (`DepartmentID`),
  CONSTRAINT `FK_Lecturers_Departments` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`DepartmentID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lecturers`
--

LOCK TABLES `lecturers` WRITE;
/*!40000 ALTER TABLE `lecturers` DISABLE KEYS */;
INSERT INTO `lecturers` VALUES (1,'GV001','Nguyễn Viết','Hùng',NULL,NULL,1),(2,'GV002','Nguyễn Công','Bình',NULL,NULL,1),(3,'GV003','Hoàng Trọng','Bình',NULL,NULL,1),(4,'GV004','Phạm Duy','Trung',NULL,NULL,1),(5,'GV005','Nguyễn Thị','Nga',NULL,NULL,1),(6,'GV006','Trần Minh','Tuấn',NULL,NULL,1),(7,'GV007','Lê Hoàng','Nam',NULL,NULL,2),(8,'GV008','Phạm Thu','Hà',NULL,NULL,2),(9,'GV009','Nguyễn Quốc','Bảo',NULL,NULL,2),(10,'GV010','Trần Thanh','Tùng',NULL,NULL,2),(11,'GV011','Đỗ Minh','Anh',NULL,NULL,2),(12,'GV012','Vũ Đức','Long',NULL,NULL,2),(13,'GV013','Nguyễn Thị','Hương',NULL,NULL,2),(14,'GV014','Phan Tuấn','Kiệt',NULL,NULL,2),(15,'GV015','Lê Thị','Mai',NULL,NULL,2),(16,'GV016','Nguyễn Bảo','Trân',NULL,NULL,3),(17,'GV017','Nguyễn Hoàng','Phúc',NULL,NULL,3),(18,'GV018','Lê Quốc','Khánh',NULL,NULL,3),(19,'GV019','Trần Ngọc','Lan',NULL,NULL,3),(20,'GV020','Đặng Minh','Khoa',NULL,NULL,3);
/*!40000 ALTER TABLE `lecturers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lecturersubjects`
--

DROP TABLE IF EXISTS `lecturersubjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lecturersubjects` (
  `LecturerID` int NOT NULL,
  `SubjectID` int NOT NULL,
  PRIMARY KEY (`LecturerID`,`SubjectID`),
  KEY `FK_LecturerSubjects_Subjects` (`SubjectID`),
  CONSTRAINT `FK_LecturerSubjects_Lecturers` FOREIGN KEY (`LecturerID`) REFERENCES `lecturers` (`LecturerID`),
  CONSTRAINT `FK_LecturerSubjects_Subjects` FOREIGN KEY (`SubjectID`) REFERENCES `subjects` (`SubjectID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lecturersubjects`
--

LOCK TABLES `lecturersubjects` WRITE;
/*!40000 ALTER TABLE `lecturersubjects` DISABLE KEYS */;
INSERT INTO `lecturersubjects` VALUES (6,1),(1,2),(2,3),(3,4),(4,5),(2,6),(1,7),(5,8),(7,9),(8,10),(9,11),(10,12),(11,13),(12,14),(13,15),(14,16),(15,17),(16,18),(17,19),(18,20),(19,21),(20,22);
/*!40000 ALTER TABLE `lecturersubjects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `students` (
  `StudentID` int NOT NULL AUTO_INCREMENT,
  `StudentCode` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `LastName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `FirstName` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `Email` varchar(150) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PhoneNumber` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ClassID` int DEFAULT NULL,
  PRIMARY KEY (`StudentID`),
  UNIQUE KEY `StudentCode` (`StudentCode`),
  KEY `FK_Students_Classes` (`ClassID`),
  CONSTRAINT `FK_Students_Classes` FOREIGN KEY (`ClassID`) REFERENCES `classes` (`ClassID`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (32,'24002412','Hồ Lê Sỹ','Anh','2006-05-15',NULL,NULL,4),(33,'24004510','Nguyễn Việt','Anh','2006-06-15',NULL,NULL,4),(34,'24000827','Trần Thái','Anh','2006-04-05',NULL,NULL,4),(35,'24003534','Nguyễn Công','Bằng','2006-12-10',NULL,NULL,4),(36,'24004140','Nguyễn Hoàng','Dũng','2006-05-22',NULL,NULL,4),(37,'24003740','Hà Quang','Đạo','2006-04-09',NULL,NULL,4),(38,'24000347','Đoàn Mạnh','Đức','2006-10-22',NULL,NULL,4),(39,'24000527','Vương Quốc','Đức','2006-03-04',NULL,NULL,4),(40,'24002045','Đinh Quang','Hiếu','2004-04-13',NULL,NULL,4),(41,'24004049','Lộc Thị Ngọc','Hoa','2006-12-06',NULL,NULL,4),(42,'24000533','Đặng Mạnh','Hùng','2006-10-05',NULL,NULL,4),(43,'24000291','Nguyễn Bình','Khang','2006-12-08',NULL,NULL,4),(44,'24000056','Đặng Đức','Khôi','2006-10-23',NULL,NULL,4),(45,'24002059','Nguyễn Việt','Khôi','2006-12-29',NULL,NULL,4),(46,'24001449','Nguyễn Trung','Kiên','2005-01-03',NULL,NULL,4),(47,'24000134','Đỗ Văn','Kiệt','2006-12-20',NULL,NULL,4),(48,'20221057','Trần Phát','Lộc','2004-06-11',NULL,NULL,1),(49,'24003496','Nguyễn Hữu','Mạnh','2006-09-24',NULL,NULL,4),(50,'24004130','Nguyễn Thành','Nam','2006-04-09',NULL,NULL,4),(51,'24000265','Đèo Hoàng','Nguyên','2006-05-23',NULL,NULL,4),(52,'24003376','Nguyễn Quý Anh','Quân','2006-09-14',NULL,NULL,4),(53,'24002659','Nguyễn Văn','Thanh','2006-12-13',NULL,NULL,4),(54,'24000706','Cao Xuân','Thành','2006-08-02',NULL,NULL,4),(55,'24000888','Dương Quang','Thiện','2006-09-24',NULL,NULL,4),(56,'24001433','Võ Văn','Thuận','2006-04-05',NULL,NULL,4),(57,'24002424','Nông Xuân','Trường','2006-07-06',NULL,NULL,4),(58,'24004256','Đoàn Quốc','Việt','2006-06-30',NULL,NULL,4),(59,'20220611','Hoàng Văn','Kết','2004-03-21',NULL,NULL,1),(60,'20221095','Nguyễn Đức','Đạt','2001-10-10',NULL,NULL,2),(61,'20220574','Vũ Thị Ngọc','Hân','2004-02-05',NULL,NULL,2),(62,'20230845','Đinh Sỹ Bình','An','2005-03-22',NULL,NULL,3),(63,'20230865','Lê Đức','Trung','2005-09-09',NULL,NULL,3),(64,'20232952','Phạm Vân','Anh','2005-04-01',NULL,NULL,5),(65,'20231826','Nguyễn Đức','Trung','2005-01-01',NULL,NULL,5),(66,'20233177','Nguyễn Tùng','Dương','2005-08-10',NULL,NULL,6),(67,'20233123','Vũ Thành','Khiêm','2005-09-26',NULL,NULL,6),(68,'20232739','Nguyễn Trần','Tùng','2005-04-09',NULL,NULL,6),(69,'24001090','Trần Trọng','Nhất','2006-11-14',NULL,NULL,4),(70,'25003367','Nguyễn Hải','Đăng','2007-02-22',NULL,NULL,7),(71,'25005706','Phạm Việt','Hùng','2007-08-20',NULL,NULL,7),(72,'25000178','Nguyễn Hoàng','Anh','2007-07-07',NULL,NULL,8),(73,'25006024','Đoàn Thị','Hạnh','2007-04-27',NULL,NULL,8),(74,'25003938','Võ Thị Tường','Vy','2007-10-06',NULL,NULL,8),(75,'20210131','Trần Trung','Đức','2003-05-20',NULL,NULL,9),(76,'20210527','Hoàng Trọng','Hưng','2003-12-22',NULL,NULL,9),(77,'20212995','Đỗ Minh','Quân','2003-06-11',NULL,NULL,9),(78,'20211041','Nguyễn Xuân','Toàn','2003-10-04',NULL,NULL,9),(79,'20212616','Nguyễn Văn','Tưởng','2003-08-04',NULL,NULL,9),(80,'20211977','Hoàng Đức','Mạnh','2003-02-11',NULL,NULL,10);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subjects`
--

DROP TABLE IF EXISTS `subjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subjects` (
  `SubjectID` int NOT NULL AUTO_INCREMENT,
  `SubjectCode` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SubjectName` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Credits` int DEFAULT NULL,
  `DepartmentID` int DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`SubjectID`),
  UNIQUE KEY `SubjectCode` (`SubjectCode`),
  KEY `FK_Subjects_Departments` (`DepartmentID`),
  CONSTRAINT `FK_Subjects_Departments` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`DepartmentID`),
  CONSTRAINT `CK_Subjects_Credits` CHECK (((`Credits` is null) or (`Credits` > 0)))
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subjects`
--

LOCK TABLES `subjects` WRITE;
/*!40000 ALTER TABLE `subjects` DISABLE KEYS */;
INSERT INTO `subjects` VALUES (1,'DCIT01','An toàn bảo mật thông tin',3,1,NULL),(2,'DCIT02','Đồ án chuyên ngành',5,1,NULL),(3,'DCIT03','Kiến trúc máy tính',3,1,NULL),(4,'DCIT04','Phát triển ứng dụng cho thiết bị di động',4,1,NULL),(5,'DCIT05','Quản trị hệ thống Windows Server',3,1,NULL),(6,'DCIT06','Thiết kế Web (HTML, Javascript)',3,1,NULL),(7,'DCIT07','Thực tập',4,1,NULL),(8,'DCIT08','Thương mại điện tử',3,1,NULL),(9,'DCBM01','Dự án Nghiên cứu',10,2,NULL),(10,'DCBM02','Khởi sự kinh doanh',3,2,NULL),(11,'DCBM03','Logistics và Quản trị chuỗi cung ứng',3,2,NULL),(12,'DCBM04','Luật doanh nghiệp và Quản trị công ty',5,2,NULL),(13,'DCBM05','Môi trường Kinh doanh Toàn cầu',5,2,NULL),(14,'DCBM06','Quản lý dự án',3,2,NULL),(15,'DCBM07','Quản trị chiến lược',3,2,NULL),(16,'DCBM08','Quản trị Marketing',3,2,NULL),(17,'DCBM09','Tin ứng dụng quản trị kinh doanh',3,2,NULL),(18,'DCMM01','Khởi sự kinh doanh',3,3,NULL),(19,'DCMM02','Quản trị bán hàng',3,3,NULL),(20,'DCMM03','Quản trị chiến lược',3,3,NULL),(21,'DCMM04','Quản trị thương hiệu',3,3,NULL),(22,'DCMM05','Truyền thông marketing tích hợp',3,3,NULL);
/*!40000 ALTER TABLE `subjects` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-26 11:25:46
