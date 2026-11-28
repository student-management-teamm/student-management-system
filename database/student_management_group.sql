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
INSERT INTO `departments` VALUES (1,'DCIT','Information Technology (English-taught)',NULL),(2,'DCBM','Business Administration (International Program)',NULL),(3,'DCMM','Marketing Management (English-taught)',NULL);
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
INSERT INTO `lecturers` VALUES (1,'GV001','Nguyen Viet','Hung','NguyenVietHung@eaut.edu.vn','0900000001',1),(2,'GV002','Nguyen Cong','Binh','NguyenCongBinh@eaut.edu.vn','0900000002',1),(3,'GV003','Hoang Trong','Binh','HoangTrongBinh@eaut.edu.vn','0900000003',1),(4,'GV004','Pham Duy','Trung','PhamDuyTrung@eaut.edu.vn','0900000004',1),(5,'GV005','Nguyen Thi','Nga','NguyenThiNga@eaut.edu.vn','0900000005',1),(6,'GV006','Tran Minh','Tuan','TranMinhTuan@eaut.edu.vn','0900000006',1),(7,'GV007','Le Hoang','Nam','LeHoangNam@eaut.edu.vn','0900000007',2),(8,'GV008','Pham Thu','Ha','PhamThuHa@eaut.edu.vn','0900000008',2),(9,'GV009','Nguyen Quoc','Bao','NguyenQuocBao@eaut.edu.vn','0900000009',2),(10,'GV010','Tran Thanh','Tung','TranThanhTung@eaut.edu.vn','0900000010',2),(11,'GV011','Do Minh','Anh','DoMinhAnh@eaut.edu.vn','0900000011',2),(12,'GV012','Vu Duc','Long','VuDucLong@eaut.edu.vn','0900000012',2),(13,'GV013','Trieu Thu','Huong','TrieuThuHuong@eaut.edu.vn','0900000013',2),(14,'GV014','Phan Tuan','Kiet','PhanTuanKiet@eaut.edu.vn','0900000014',2),(15,'GV015','Le Thi','Mai','LeThiMai@eaut.edu.vn','0900000015',2),(16,'GV016','Nguyen Bao','Tran','NguyenBaoTran@eaut.edu.vn','0900000016',3),(17,'GV017','Nguyen Hoang','Phuc','NguyenHoangPhuc@eaut.edu.vn','0900000017',3),(18,'GV018','Le Quoc','Khanh','LeQuocKhanh@eaut.edu.vn','0900000018',3),(19,'GV019','Tran Ngoc','Lan','TranNgocLan@eaut.edu.vn','0900000019',3),(20,'GV020','Dang Minh','Khoa','DangMinhKhoa@eaut.edu.vn','0900000020',3);
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
) ENGINE=InnoDB AUTO_INCREMENT=336 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (32,'24002412','Ho Le Sy','Anh','2006-05-15','24002412@eaut.edu.vn','0915052006',4),(33,'24004510','Nguyen Viet','Anh','2006-06-15','24004510@eaut.edu.vn','0915062006',4),(34,'24000827','Tran Thai','Anh','2006-04-05','24000827@eaut.edu.vn','0905042006',4),(35,'24003534','Nguyen Cong','Bang','2006-12-10','24003534@eaut.edu.vn','0910122006',4),(36,'24004140','Nguyen Hoang','Dung','2006-05-22','24004140@eaut.edu.vn','0922052006',4),(37,'24003740','Ha Quang','Dao','2006-04-09','24003740@eaut.edu.vn','0909042006',4),(38,'24000347','Doan Manh','Duc','2006-10-22','24000347@eaut.edu.vn','0922102006',4),(39,'24000527','Vuong Quoc','Duc','2006-03-04','24000527@eaut.edu.vn','0904032006',4),(40,'24002045','Dinh Quang','Hieu','2004-04-13','24002045@eaut.edu.vn','0913042004',4),(41,'24004049','Loc Thi Ngoc','Hoa','2006-12-06','24004049@eaut.edu.vn','0906122006',4),(42,'24000533','Dang Manh','Hung','2006-10-05','24000533@eaut.edu.vn','0905102006',4),(43,'24000291','Nguyen Binh','Khang','2006-12-08','24000291@eaut.edu.vn','0908122006',4),(44,'24000056','Dang Duc','Khoi','2006-10-23','24000056@eaut.edu.vn','0923102006',4),(45,'24002059','Nguyen Viet','Khoi','2006-12-29','24002059@eaut.edu.vn','0929122006',4),(46,'24001449','Nguyen Trung','Kien','2005-01-03','24001449@eaut.edu.vn','0903012005',4),(47,'24000134','Do Van','Kiet','2006-12-20','24000134@eaut.edu.vn','0920122006',4),(48,'20221057','Tran Phat','Loc','2004-06-11','20221057@eaut.edu.vn','0911062004',1),(49,'24003496','Nguyen Huu','Manh','2006-09-24','24003496@eaut.edu.vn','0924092006',4),(50,'24004130','Nguyen Thanh','Nam','2006-04-09','24004130@eaut.edu.vn','0909042006',4),(51,'24000265','Deo Hoang','Nguyen','2006-05-23','24000265@eaut.edu.vn','0923052006',4),(52,'24003376','Nguyen Quy Anh','Quan','2006-09-14','24003376@eaut.edu.vn','0914092006',4),(53,'24002659','Nguyen Van','Thanh','2006-12-13','24002659@eaut.edu.vn','0913122006',4),(54,'24000706','Cao Xuan','Thanh','2006-08-02','24000706@eaut.edu.vn','0902082006',4),(55,'24000888','Duong Quang','Thien','2006-09-24','24000888@eaut.edu.vn','0924092006',4),(56,'24001433','Vo Van','Thuan','2006-04-05','24001433@eaut.edu.vn','0905042006',4),(57,'24002424','Nong Xuan','Truong','2006-07-06','24002424@eaut.edu.vn','0906072006',4),(58,'24004256','Doan Quoc','Viet','2006-06-30','24004256@eaut.edu.vn','0930062006',4),(59,'20220611','Hoang Van','Ket','2004-03-21','20220611@eaut.edu.vn','0921032004',1),(60,'20221095','Nguyen Duc','Dat','2001-10-10','20221095@eaut.edu.vn','0910102001',2),(61,'20220574','Vu Thi Ngoc','Han','2004-02-05','20220574@eaut.edu.vn','0905022004',2),(62,'20230845','Dinh Sy Binh','An','2005-03-22','20230845@eaut.edu.vn','0922032005',3),(63,'20230865','Le Duc','Trung','2005-09-09','20230865@eaut.edu.vn','0909092005',3),(64,'20232952','Pham Van','Anh','2005-04-01','20232952@eaut.edu.vn','0901042005',5),(65,'20231826','Nguyen Duc','Trung','2005-01-01','20231826@eaut.edu.vn','0901012005',5),(66,'20233177','Nguyen Tung','Duong','2005-08-10','20233177@eaut.edu.vn','0910082005',6),(67,'20233123','Vu Thanh','Khiem','2005-09-26','20233123@eaut.edu.vn','0926092005',6),(68,'20232739','Nguyen Tran','Tung','2005-04-09','20232739@eaut.edu.vn','0909042005',6),(69,'24001090','Tran Trong','Nhat','2006-11-14','24001090@eaut.edu.vn','0914112006',4),(70,'25003367','Nguyen Hai','Dang','2007-02-22','25003367@eaut.edu.vn','0922022007',7),(71,'25005706','Pham Viet','Hung','2007-08-20','25005706@eaut.edu.vn','0920082007',7),(72,'25000178','Nguyen Hoang','Anh','2007-07-07','25000178@eaut.edu.vn','0907072007',8),(73,'25006024','Doan Thi','Hanh','2007-04-27','25006024@eaut.edu.vn','0927042007',8),(74,'25003938','Vo Thi Tuong','Vy','2007-10-06','25003938@eaut.edu.vn','0906102007',8),(75,'20210131','Tran Trung','Duc','2003-05-20','20210131@eaut.edu.vn','0920052003',9),(76,'20210527','Hoang Trong','Hung','2003-12-22','20210527@eaut.edu.vn','0922122003',9),(77,'20212995','Do Minh','Quan','2003-06-11','20212995@eaut.edu.vn','0911062003',9),(78,'20211041','Nguyen Xuan','Toan','2003-10-04','20211041@eaut.edu.vn','0904102003',9),(79,'20212616','Nguyen Van','Tuong','2003-08-04','20212616@eaut.edu.vn','0904082003',9),(80,'20211977','Hoang Duc','Manh','2003-02-11','20211977@eaut.edu.vn','0911022003',10),(81,'260000801','Nguyen Van','An','2004-04-09','260000801@eaut.edu.vn','0909042004',8),(82,'260000601','Nguyen Van','An','2004-03-26','260000601@eaut.edu.vn','0926032004',6),(83,'260000501','Nguyen Van','An','2004-03-19','260000501@eaut.edu.vn','0919032004',5),(84,'260000301','Nguyen Van','An','2004-03-05','260000301@eaut.edu.vn','0905032004',3),(85,'260000101','Nguyen Van','An','2004-02-20','260000101@eaut.edu.vn','0920022004',1),(86,'260000901','Nguyen Van','An','2004-04-16','260000901@eaut.edu.vn','0916042004',9),(87,'260000701','Nguyen Van','An','2004-04-02','260000701@eaut.edu.vn','0902042004',7),(88,'260000201','Nguyen Van','An','2004-02-27','260000201@eaut.edu.vn','0927022004',2),(89,'260001001','Nguyen Van','An','2004-04-23','260001001@eaut.edu.vn','0923042004',10),(90,'260000802','Tran Minh','Binh','2004-05-22','260000802@eaut.edu.vn','0922052004',8),(91,'260000602','Tran Minh','Binh','2004-05-08','260000602@eaut.edu.vn','0908052004',6),(92,'260000502','Tran Minh','Binh','2004-05-01','260000502@eaut.edu.vn','0901052004',5),(93,'260000302','Tran Minh','Binh','2004-04-17','260000302@eaut.edu.vn','0917042004',3),(94,'260000102','Tran Minh','Binh','2004-04-03','260000102@eaut.edu.vn','0903042004',1),(95,'260000902','Tran Minh','Binh','2004-05-29','260000902@eaut.edu.vn','0929052004',9),(96,'260000702','Tran Minh','Binh','2004-05-15','260000702@eaut.edu.vn','0915052004',7),(97,'260000202','Tran Minh','Binh','2004-04-10','260000202@eaut.edu.vn','0910042004',2),(98,'260001002','Tran Minh','Binh','2004-06-05','260001002@eaut.edu.vn','0905062004',10),(99,'260000803','Le Quoc','Cuong','2004-07-04','260000803@eaut.edu.vn','0904072004',8),(100,'260000603','Le Quoc','Cuong','2004-06-20','260000603@eaut.edu.vn','0920062004',6),(101,'260000503','Le Quoc','Cuong','2004-06-13','260000503@eaut.edu.vn','0913062004',5),(102,'260000303','Le Quoc','Cuong','2004-05-30','260000303@eaut.edu.vn','0930052004',3),(103,'260000103','Le Quoc','Cuong','2004-05-16','260000103@eaut.edu.vn','0916052004',1),(104,'260000903','Le Quoc','Cuong','2004-07-11','260000903@eaut.edu.vn','0911072004',9),(105,'260000703','Le Quoc','Cuong','2004-06-27','260000703@eaut.edu.vn','0927062004',7),(106,'260000203','Le Quoc','Cuong','2004-05-23','260000203@eaut.edu.vn','0923052004',2),(107,'260001003','Le Quoc','Cuong','2004-07-18','260001003@eaut.edu.vn','0918072004',10),(108,'260000804','Pham Duc','Dung','2004-08-16','260000804@eaut.edu.vn','0916082004',8),(109,'260000604','Pham Duc','Dung','2004-08-02','260000604@eaut.edu.vn','0902082004',6),(110,'260000504','Pham Duc','Dung','2004-07-26','260000504@eaut.edu.vn','0926072004',5),(111,'260000304','Pham Duc','Dung','2004-07-12','260000304@eaut.edu.vn','0912072004',3),(112,'260000104','Pham Duc','Dung','2004-06-28','260000104@eaut.edu.vn','0928062004',1),(113,'260000904','Pham Duc','Dung','2004-08-23','260000904@eaut.edu.vn','0923082004',9),(114,'260000704','Pham Duc','Dung','2004-08-09','260000704@eaut.edu.vn','0909082004',7),(115,'260000204','Pham Duc','Dung','2004-07-05','260000204@eaut.edu.vn','0905072004',2),(116,'260001004','Pham Duc','Dung','2004-08-30','260001004@eaut.edu.vn','0930082004',10),(117,'260000805','Hoang Gia','Huy','2004-09-28','260000805@eaut.edu.vn','0928092004',8),(118,'260000605','Hoang Gia','Huy','2004-09-14','260000605@eaut.edu.vn','0914092004',6),(119,'260000505','Hoang Gia','Huy','2004-09-07','260000505@eaut.edu.vn','0907092004',5),(120,'260000305','Hoang Gia','Huy','2004-08-24','260000305@eaut.edu.vn','0924082004',3),(121,'260000105','Hoang Gia','Huy','2004-08-10','260000105@eaut.edu.vn','0910082004',1),(122,'260000905','Hoang Gia','Huy','2004-10-05','260000905@eaut.edu.vn','0905102004',9),(123,'260000705','Hoang Gia','Huy','2004-09-21','260000705@eaut.edu.vn','0921092004',7),(124,'260000205','Hoang Gia','Huy','2004-08-17','260000205@eaut.edu.vn','0917082004',2),(125,'260001005','Hoang Gia','Huy','2004-10-12','260001005@eaut.edu.vn','0912102004',10),(126,'260000806','Vu Thanh','Khang','2004-11-10','260000806@eaut.edu.vn','0910112004',8),(127,'260000606','Vu Thanh','Khang','2004-10-27','260000606@eaut.edu.vn','0927102004',6),(128,'260000506','Vu Thanh','Khang','2004-10-20','260000506@eaut.edu.vn','0920102004',5),(129,'260000306','Vu Thanh','Khang','2004-10-06','260000306@eaut.edu.vn','0906102004',3),(130,'260000106','Vu Thanh','Khang','2004-09-22','260000106@eaut.edu.vn','0922092004',1),(131,'260000906','Vu Thanh','Khang','2004-11-17','260000906@eaut.edu.vn','0917112004',9),(132,'260000706','Vu Thanh','Khang','2004-11-03','260000706@eaut.edu.vn','0903112004',7),(133,'260000206','Vu Thanh','Khang','2004-09-29','260000206@eaut.edu.vn','0929092004',2),(134,'260001006','Vu Thanh','Khang','2004-11-24','260001006@eaut.edu.vn','0924112004',10),(135,'260000807','Dang Minh','Khoi','2004-12-23','260000807@eaut.edu.vn','0923122004',8),(136,'260000607','Dang Minh','Khoi','2004-12-09','260000607@eaut.edu.vn','0909122004',6),(137,'260000507','Dang Minh','Khoi','2004-12-02','260000507@eaut.edu.vn','0902122004',5),(138,'260000307','Dang Minh','Khoi','2004-11-18','260000307@eaut.edu.vn','0918112004',3),(139,'260000107','Dang Minh','Khoi','2004-11-04','260000107@eaut.edu.vn','0904112004',1),(140,'260000907','Dang Minh','Khoi','2004-12-30','260000907@eaut.edu.vn','0930122004',9),(141,'260000707','Dang Minh','Khoi','2004-12-16','260000707@eaut.edu.vn','0916122004',7),(142,'260000207','Dang Minh','Khoi','2004-11-11','260000207@eaut.edu.vn','0911112004',2),(143,'260001007','Dang Minh','Khoi','2005-01-06','260001007@eaut.edu.vn','0906012005',10),(144,'260000808','Bui Quang','Long','2005-02-04','260000808@eaut.edu.vn','0904022005',8),(145,'260000608','Bui Quang','Long','2005-01-21','260000608@eaut.edu.vn','0921012005',6),(146,'260000508','Bui Quang','Long','2005-01-14','260000508@eaut.edu.vn','0914012005',5),(147,'260000308','Bui Quang','Long','2004-12-31','260000308@eaut.edu.vn','0931122004',3),(148,'260000108','Bui Quang','Long','2004-12-17','260000108@eaut.edu.vn','0917122004',1),(149,'260000908','Bui Quang','Long','2005-02-11','260000908@eaut.edu.vn','0911022005',9),(150,'260000708','Bui Quang','Long','2005-01-28','260000708@eaut.edu.vn','0928012005',7),(151,'260000208','Bui Quang','Long','2004-12-24','260000208@eaut.edu.vn','0924122004',2),(152,'260001008','Bui Quang','Long','2005-02-18','260001008@eaut.edu.vn','0918022005',10),(153,'260000809','Do Tuan','Minh','2005-03-19','260000809@eaut.edu.vn','0919032005',8),(154,'260000609','Do Tuan','Minh','2005-03-05','260000609@eaut.edu.vn','0905032005',6),(155,'260000509','Do Tuan','Minh','2005-02-26','260000509@eaut.edu.vn','0926022005',5),(156,'260000309','Do Tuan','Minh','2005-02-12','260000309@eaut.edu.vn','0912022005',3),(157,'260000109','Do Tuan','Minh','2005-01-29','260000109@eaut.edu.vn','0929012005',1),(158,'260000909','Do Tuan','Minh','2005-03-26','260000909@eaut.edu.vn','0926032005',9),(159,'260000709','Do Tuan','Minh','2005-03-12','260000709@eaut.edu.vn','0912032005',7),(160,'260000209','Do Tuan','Minh','2005-02-05','260000209@eaut.edu.vn','0905022005',2),(161,'260001009','Do Tuan','Minh','2005-04-02','260001009@eaut.edu.vn','0902042005',10),(162,'260000810','Ngo Hoang','Nam','2005-05-01','260000810@eaut.edu.vn','0901052005',8),(163,'260000610','Ngo Hoang','Nam','2005-04-17','260000610@eaut.edu.vn','0917042005',6),(164,'260000510','Ngo Hoang','Nam','2005-04-10','260000510@eaut.edu.vn','0910042005',5),(165,'260000310','Ngo Hoang','Nam','2005-03-27','260000310@eaut.edu.vn','0927032005',3),(166,'260000110','Ngo Hoang','Nam','2005-03-13','260000110@eaut.edu.vn','0913032005',1),(167,'260000910','Ngo Hoang','Nam','2005-05-08','260000910@eaut.edu.vn','0908052005',9),(168,'260000710','Ngo Hoang','Nam','2005-04-24','260000710@eaut.edu.vn','0924042005',7),(169,'260000210','Ngo Hoang','Nam','2005-03-20','260000210@eaut.edu.vn','0920032005',2),(170,'260001010','Ngo Hoang','Nam','2005-05-15','260001010@eaut.edu.vn','0915052005',10),(171,'260000811','Duong Nhat','Phong','2005-06-13','260000811@eaut.edu.vn','0913062005',8),(172,'260000611','Duong Nhat','Phong','2005-05-30','260000611@eaut.edu.vn','0930052005',6),(173,'260000511','Duong Nhat','Phong','2005-05-23','260000511@eaut.edu.vn','0923052005',5),(174,'260000311','Duong Nhat','Phong','2005-05-09','260000311@eaut.edu.vn','0909052005',3),(175,'260000111','Duong Nhat','Phong','2005-04-25','260000111@eaut.edu.vn','0925042005',1),(176,'260000911','Duong Nhat','Phong','2005-06-20','260000911@eaut.edu.vn','0920062005',9),(177,'260000711','Duong Nhat','Phong','2005-06-06','260000711@eaut.edu.vn','0906062005',7),(178,'260000211','Duong Nhat','Phong','2005-05-02','260000211@eaut.edu.vn','0902052005',2),(179,'260001011','Duong Nhat','Phong','2005-06-27','260001011@eaut.edu.vn','0927062005',10),(180,'260000812','Ho Anh','Quan','2005-07-26','260000812@eaut.edu.vn','0926072005',8),(181,'260000612','Ho Anh','Quan','2005-07-12','260000612@eaut.edu.vn','0912072005',6),(182,'260000512','Ho Anh','Quan','2005-07-05','260000512@eaut.edu.vn','0905072005',5),(183,'260000312','Ho Anh','Quan','2005-06-21','260000312@eaut.edu.vn','0921062005',3),(184,'260000112','Ho Anh','Quan','2005-06-07','260000112@eaut.edu.vn','0907062005',1),(185,'260000912','Ho Anh','Quan','2005-08-02','260000912@eaut.edu.vn','0902082005',9),(186,'260000712','Ho Anh','Quan','2005-07-19','260000712@eaut.edu.vn','0919072005',7),(187,'260000212','Ho Anh','Quan','2005-06-14','260000212@eaut.edu.vn','0914062005',2),(188,'260001012','Ho Anh','Quan','2005-08-09','260001012@eaut.edu.vn','0909082005',10),(189,'260000813','Vo Thanh','Tam','2005-09-07','260000813@eaut.edu.vn','0907092005',8),(190,'260000613','Vo Thanh','Tam','2005-08-24','260000613@eaut.edu.vn','0924082005',6),(191,'260000513','Vo Thanh','Tam','2005-08-17','260000513@eaut.edu.vn','0917082005',5),(192,'260000313','Vo Thanh','Tam','2005-08-03','260000313@eaut.edu.vn','0903082005',3),(193,'260000113','Vo Thanh','Tam','2005-07-20','260000113@eaut.edu.vn','0920072005',1),(194,'260000913','Vo Thanh','Tam','2005-09-14','260000913@eaut.edu.vn','0914092005',9),(195,'260000713','Vo Thanh','Tam','2005-08-31','260000713@eaut.edu.vn','0931082005',7),(196,'260000213','Vo Thanh','Tam','2005-07-27','260000213@eaut.edu.vn','0927072005',2),(197,'260001013','Vo Thanh','Tam','2005-09-21','260001013@eaut.edu.vn','0921092005',10),(198,'260000814','Mai Huu','Thanh','2005-10-20','260000814@eaut.edu.vn','0920102005',8),(199,'260000614','Mai Huu','Thanh','2005-10-06','260000614@eaut.edu.vn','0906102005',6),(200,'260000514','Mai Huu','Thanh','2005-09-29','260000514@eaut.edu.vn','0929092005',5),(201,'260000314','Mai Huu','Thanh','2005-09-15','260000314@eaut.edu.vn','0915092005',3),(202,'260000114','Mai Huu','Thanh','2005-09-01','260000114@eaut.edu.vn','0901092005',1),(203,'260000914','Mai Huu','Thanh','2005-10-27','260000914@eaut.edu.vn','0927102005',9),(204,'260000714','Mai Huu','Thanh','2005-10-13','260000714@eaut.edu.vn','0913102005',7),(205,'260000214','Mai Huu','Thanh','2005-09-08','260000214@eaut.edu.vn','0908092005',2),(206,'260001014','Mai Huu','Thanh','2005-11-03','260001014@eaut.edu.vn','0903112005',10),(207,'260000815','Phan Xuan','Viet','2005-12-02','260000815@eaut.edu.vn','0902122005',8),(208,'260000615','Phan Xuan','Viet','2005-11-18','260000615@eaut.edu.vn','0918112005',6),(209,'260000515','Phan Xuan','Viet','2005-11-11','260000515@eaut.edu.vn','0911112005',5),(210,'260000315','Phan Xuan','Viet','2005-10-28','260000315@eaut.edu.vn','0928102005',3),(211,'260000115','Phan Xuan','Viet','2005-10-14','260000115@eaut.edu.vn','0914102005',1),(212,'260000915','Phan Xuan','Viet','2005-12-09','260000915@eaut.edu.vn','0909122005',9),(213,'260000715','Phan Xuan','Viet','2005-11-25','260000715@eaut.edu.vn','0925112005',7),(214,'260000215','Phan Xuan','Viet','2005-10-21','260000215@eaut.edu.vn','0921102005',2),(215,'260001015','Phan Xuan','Viet','2005-12-16','260001015@eaut.edu.vn','0916122005',10);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students_backup`
--

DROP TABLE IF EXISTS `students_backup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `students_backup` (
  `StudentID` int NOT NULL DEFAULT '0',
  `StudentCode` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `LastName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `FirstName` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `Email` varchar(150) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PhoneNumber` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ClassID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students_backup`
--

LOCK TABLES `students_backup` WRITE;
/*!40000 ALTER TABLE `students_backup` DISABLE KEYS */;
INSERT INTO `students_backup` VALUES (32,'24002412','Hồ Lê Sỹ','Anh','2006-05-15','24002412@eaut.edu.vn','0915052006',4),(33,'24004510','Nguyễn Việt','Anh','2006-06-15','24004510@eaut.edu.vn','0915062006',4),(34,'24000827','Trần Thái','Anh','2006-04-05','24000827@eaut.edu.vn','0905042006',4),(35,'24003534','Nguyễn Công','Bằng','2006-12-10','24003534@eaut.edu.vn','0910122006',4),(36,'24004140','Nguyễn Hoàng','Dũng','2006-05-22','24004140@eaut.edu.vn','0922052006',4),(37,'24003740','Hà Quang','Đạo','2006-04-09','24003740@eaut.edu.vn','0909042006',4),(38,'24000347','Đoàn Mạnh','Đức','2006-10-22','24000347@eaut.edu.vn','0922102006',4),(39,'24000527','Vương Quốc','Đức','2006-03-04','24000527@eaut.edu.vn','0904032006',4),(40,'24002045','Đinh Quang','Hiếu','2004-04-13','24002045@eaut.edu.vn','0913042004',4),(41,'24004049','Lộc Thị Ngọc','Hoa','2006-12-06','24004049@eaut.edu.vn','0906122006',4),(42,'24000533','Đặng Mạnh','Hùng','2006-10-05','24000533@eaut.edu.vn','0905102006',4),(43,'24000291','Nguyễn Bình','Khang','2006-12-08','24000291@eaut.edu.vn','0908122006',4),(44,'24000056','Đặng Đức','Khôi','2006-10-23','24000056@eaut.edu.vn','0923102006',4),(45,'24002059','Nguyễn Việt','Khôi','2006-12-29','24002059@eaut.edu.vn','0929122006',4),(46,'24001449','Nguyễn Trung','Kiên','2005-01-03','24001449@eaut.edu.vn','0903012005',4),(47,'24000134','Đỗ Văn','Kiệt','2006-12-20','24000134@eaut.edu.vn','0920122006',4),(48,'20221057','Trần Phát','Lộc','2004-06-11','20221057@eaut.edu.vn','0911062004',1),(49,'24003496','Nguyễn Hữu','Mạnh','2006-09-24','24003496@eaut.edu.vn','0924092006',4),(50,'24004130','Nguyễn Thành','Nam','2006-04-09','24004130@eaut.edu.vn','0909042006',4),(51,'24000265','Đèo Hoàng','Nguyên','2006-05-23','24000265@eaut.edu.vn','0923052006',4),(52,'24003376','Nguyễn Quý Anh','Quân','2006-09-14','24003376@eaut.edu.vn','0914092006',4),(53,'24002659','Nguyễn Văn','Thanh','2006-12-13','24002659@eaut.edu.vn','0913122006',4),(54,'24000706','Cao Xuân','Thành','2006-08-02','24000706@eaut.edu.vn','0902082006',4),(55,'24000888','Dương Quang','Thiện','2006-09-24','24000888@eaut.edu.vn','0924092006',4),(56,'24001433','Võ Văn','Thuận','2006-04-05','24001433@eaut.edu.vn','0905042006',4),(57,'24002424','Nông Xuân','Trường','2006-07-06','24002424@eaut.edu.vn','0906072006',4),(58,'24004256','Đoàn Quốc','Việt','2006-06-30','24004256@eaut.edu.vn','0930062006',4),(59,'20220611','Hoàng Văn','Kết','2004-03-21','20220611@eaut.edu.vn','0921032004',1),(60,'20221095','Nguyễn Đức','Đạt','2001-10-10','20221095@eaut.edu.vn','0910102001',2),(61,'20220574','Vũ Thị Ngọc','Hân','2004-02-05','20220574@eaut.edu.vn','0905022004',2),(62,'20230845','Đinh Sỹ Bình','An','2005-03-22','20230845@eaut.edu.vn','0922032005',3),(63,'20230865','Lê Đức','Trung','2005-09-09','20230865@eaut.edu.vn','0909092005',3),(64,'20232952','Phạm Vân','Anh','2005-04-01','20232952@eaut.edu.vn','0901042005',5),(65,'20231826','Nguyễn Đức','Trung','2005-01-01','20231826@eaut.edu.vn','0901012005',5),(66,'20233177','Nguyễn Tùng','Dương','2005-08-10','20233177@eaut.edu.vn','0910082005',6),(67,'20233123','Vũ Thành','Khiêm','2005-09-26','20233123@eaut.edu.vn','0926092005',6),(68,'20232739','Nguyễn Trần','Tùng','2005-04-09','20232739@eaut.edu.vn','0909042005',6),(69,'24001090','Trần Trọng','Nhất','2006-11-14','24001090@eaut.edu.vn','0914112006',4),(70,'25003367','Nguyễn Hải','Đăng','2007-02-22','25003367@eaut.edu.vn','0922022007',7),(71,'25005706','Phạm Việt','Hùng','2007-08-20','25005706@eaut.edu.vn','0920082007',7),(72,'25000178','Nguyễn Hoàng','Anh','2007-07-07','25000178@eaut.edu.vn','0907072007',8),(73,'25006024','Đoàn Thị','Hạnh','2007-04-27','25006024@eaut.edu.vn','0927042007',8),(74,'25003938','Võ Thị Tường','Vy','2007-10-06','25003938@eaut.edu.vn','0906102007',8),(75,'20210131','Trần Trung','Đức','2003-05-20','20210131@eaut.edu.vn','0920052003',9),(76,'20210527','Hoàng Trọng','Hưng','2003-12-22','20210527@eaut.edu.vn','0922122003',9),(77,'20212995','Đỗ Minh','Quân','2003-06-11','20212995@eaut.edu.vn','0911062003',9),(78,'20211041','Nguyễn Xuân','Toàn','2003-10-04','20211041@eaut.edu.vn','0904102003',9),(79,'20212616','Nguyễn Văn','Tưởng','2003-08-04','20212616@eaut.edu.vn','0904082003',9),(80,'20211977','Hoàng Đức','Mạnh','2003-02-11','20211977@eaut.edu.vn','0911022003',10),(81,'260000801','Nguyễn Văn','An','2004-04-09','260000801@eaut.edu.vn','0909042004',8),(82,'260000601','Nguyễn Văn','An','2004-03-26','260000601@eaut.edu.vn','0926032004',6),(83,'260000501','Nguyễn Văn','An','2004-03-19','260000501@eaut.edu.vn','0919032004',5),(84,'260000301','Nguyễn Văn','An','2004-03-05','260000301@eaut.edu.vn','0905032004',3),(85,'260000101','Nguyễn Văn','An','2004-02-20','260000101@eaut.edu.vn','0920022004',1),(86,'260000901','Nguyễn Văn','An','2004-04-16','260000901@eaut.edu.vn','0916042004',9),(87,'260000701','Nguyễn Văn','An','2004-04-02','260000701@eaut.edu.vn','0902042004',7),(88,'260000201','Nguyễn Văn','An','2004-02-27','260000201@eaut.edu.vn','0927022004',2),(89,'260001001','Nguyễn Văn','An','2004-04-23','260001001@eaut.edu.vn','0923042004',10),(90,'260000802','Trần Minh','Bình','2004-05-22','260000802@eaut.edu.vn','0922052004',8),(91,'260000602','Trần Minh','Bình','2004-05-08','260000602@eaut.edu.vn','0908052004',6),(92,'260000502','Trần Minh','Bình','2004-05-01','260000502@eaut.edu.vn','0901052004',5),(93,'260000302','Trần Minh','Bình','2004-04-17','260000302@eaut.edu.vn','0917042004',3),(94,'260000102','Trần Minh','Bình','2004-04-03','260000102@eaut.edu.vn','0903042004',1),(95,'260000902','Trần Minh','Bình','2004-05-29','260000902@eaut.edu.vn','0929052004',9),(96,'260000702','Trần Minh','Bình','2004-05-15','260000702@eaut.edu.vn','0915052004',7),(97,'260000202','Trần Minh','Bình','2004-04-10','260000202@eaut.edu.vn','0910042004',2),(98,'260001002','Trần Minh','Bình','2004-06-05','260001002@eaut.edu.vn','0905062004',10),(99,'260000803','Lê Quốc','Cường','2004-07-04','260000803@eaut.edu.vn','0904072004',8),(100,'260000603','Lê Quốc','Cường','2004-06-20','260000603@eaut.edu.vn','0920062004',6),(101,'260000503','Lê Quốc','Cường','2004-06-13','260000503@eaut.edu.vn','0913062004',5),(102,'260000303','Lê Quốc','Cường','2004-05-30','260000303@eaut.edu.vn','0930052004',3),(103,'260000103','Lê Quốc','Cường','2004-05-16','260000103@eaut.edu.vn','0916052004',1),(104,'260000903','Lê Quốc','Cường','2004-07-11','260000903@eaut.edu.vn','0911072004',9),(105,'260000703','Lê Quốc','Cường','2004-06-27','260000703@eaut.edu.vn','0927062004',7),(106,'260000203','Lê Quốc','Cường','2004-05-23','260000203@eaut.edu.vn','0923052004',2),(107,'260001003','Lê Quốc','Cường','2004-07-18','260001003@eaut.edu.vn','0918072004',10),(108,'260000804','Phạm Đức','Dũng','2004-08-16','260000804@eaut.edu.vn','0916082004',8),(109,'260000604','Phạm Đức','Dũng','2004-08-02','260000604@eaut.edu.vn','0902082004',6),(110,'260000504','Phạm Đức','Dũng','2004-07-26','260000504@eaut.edu.vn','0926072004',5),(111,'260000304','Phạm Đức','Dũng','2004-07-12','260000304@eaut.edu.vn','0912072004',3),(112,'260000104','Phạm Đức','Dũng','2004-06-28','260000104@eaut.edu.vn','0928062004',1),(113,'260000904','Phạm Đức','Dũng','2004-08-23','260000904@eaut.edu.vn','0923082004',9),(114,'260000704','Phạm Đức','Dũng','2004-08-09','260000704@eaut.edu.vn','0909082004',7),(115,'260000204','Phạm Đức','Dũng','2004-07-05','260000204@eaut.edu.vn','0905072004',2),(116,'260001004','Phạm Đức','Dũng','2004-08-30','260001004@eaut.edu.vn','0930082004',10),(117,'260000805','Hoàng Gia','Huy','2004-09-28','260000805@eaut.edu.vn','0928092004',8),(118,'260000605','Hoàng Gia','Huy','2004-09-14','260000605@eaut.edu.vn','0914092004',6),(119,'260000505','Hoàng Gia','Huy','2004-09-07','260000505@eaut.edu.vn','0907092004',5),(120,'260000305','Hoàng Gia','Huy','2004-08-24','260000305@eaut.edu.vn','0924082004',3),(121,'260000105','Hoàng Gia','Huy','2004-08-10','260000105@eaut.edu.vn','0910082004',1),(122,'260000905','Hoàng Gia','Huy','2004-10-05','260000905@eaut.edu.vn','0905102004',9),(123,'260000705','Hoàng Gia','Huy','2004-09-21','260000705@eaut.edu.vn','0921092004',7),(124,'260000205','Hoàng Gia','Huy','2004-08-17','260000205@eaut.edu.vn','0917082004',2),(125,'260001005','Hoàng Gia','Huy','2004-10-12','260001005@eaut.edu.vn','0912102004',10),(126,'260000806','Vũ Thành','Khang','2004-11-10','260000806@eaut.edu.vn','0910112004',8),(127,'260000606','Vũ Thành','Khang','2004-10-27','260000606@eaut.edu.vn','0927102004',6),(128,'260000506','Vũ Thành','Khang','2004-10-20','260000506@eaut.edu.vn','0920102004',5),(129,'260000306','Vũ Thành','Khang','2004-10-06','260000306@eaut.edu.vn','0906102004',3),(130,'260000106','Vũ Thành','Khang','2004-09-22','260000106@eaut.edu.vn','0922092004',1),(131,'260000906','Vũ Thành','Khang','2004-11-17','260000906@eaut.edu.vn','0917112004',9),(132,'260000706','Vũ Thành','Khang','2004-11-03','260000706@eaut.edu.vn','0903112004',7),(133,'260000206','Vũ Thành','Khang','2004-09-29','260000206@eaut.edu.vn','0929092004',2),(134,'260001006','Vũ Thành','Khang','2004-11-24','260001006@eaut.edu.vn','0924112004',10),(135,'260000807','Đặng Minh','Khôi','2004-12-23','260000807@eaut.edu.vn','0923122004',8),(136,'260000607','Đặng Minh','Khôi','2004-12-09','260000607@eaut.edu.vn','0909122004',6),(137,'260000507','Đặng Minh','Khôi','2004-12-02','260000507@eaut.edu.vn','0902122004',5),(138,'260000307','Đặng Minh','Khôi','2004-11-18','260000307@eaut.edu.vn','0918112004',3),(139,'260000107','Đặng Minh','Khôi','2004-11-04','260000107@eaut.edu.vn','0904112004',1),(140,'260000907','Đặng Minh','Khôi','2004-12-30','260000907@eaut.edu.vn','0930122004',9),(141,'260000707','Đặng Minh','Khôi','2004-12-16','260000707@eaut.edu.vn','0916122004',7),(142,'260000207','Đặng Minh','Khôi','2004-11-11','260000207@eaut.edu.vn','0911112004',2),(143,'260001007','Đặng Minh','Khôi','2005-01-06','260001007@eaut.edu.vn','0906012005',10),(144,'260000808','Bùi Quang','Long','2005-02-04','260000808@eaut.edu.vn','0904022005',8),(145,'260000608','Bùi Quang','Long','2005-01-21','260000608@eaut.edu.vn','0921012005',6),(146,'260000508','Bùi Quang','Long','2005-01-14','260000508@eaut.edu.vn','0914012005',5),(147,'260000308','Bùi Quang','Long','2004-12-31','260000308@eaut.edu.vn','0931122004',3),(148,'260000108','Bùi Quang','Long','2004-12-17','260000108@eaut.edu.vn','0917122004',1),(149,'260000908','Bùi Quang','Long','2005-02-11','260000908@eaut.edu.vn','0911022005',9),(150,'260000708','Bùi Quang','Long','2005-01-28','260000708@eaut.edu.vn','0928012005',7),(151,'260000208','Bùi Quang','Long','2004-12-24','260000208@eaut.edu.vn','0924122004',2),(152,'260001008','Bùi Quang','Long','2005-02-18','260001008@eaut.edu.vn','0918022005',10),(153,'260000809','Đỗ Tuấn','Minh','2005-03-19','260000809@eaut.edu.vn','0919032005',8),(154,'260000609','Đỗ Tuấn','Minh','2005-03-05','260000609@eaut.edu.vn','0905032005',6),(155,'260000509','Đỗ Tuấn','Minh','2005-02-26','260000509@eaut.edu.vn','0926022005',5),(156,'260000309','Đỗ Tuấn','Minh','2005-02-12','260000309@eaut.edu.vn','0912022005',3),(157,'260000109','Đỗ Tuấn','Minh','2005-01-29','260000109@eaut.edu.vn','0929012005',1),(158,'260000909','Đỗ Tuấn','Minh','2005-03-26','260000909@eaut.edu.vn','0926032005',9),(159,'260000709','Đỗ Tuấn','Minh','2005-03-12','260000709@eaut.edu.vn','0912032005',7),(160,'260000209','Đỗ Tuấn','Minh','2005-02-05','260000209@eaut.edu.vn','0905022005',2),(161,'260001009','Đỗ Tuấn','Minh','2005-04-02','260001009@eaut.edu.vn','0902042005',10),(162,'260000810','Ngô Hoàng','Nam','2005-05-01','260000810@eaut.edu.vn','0901052005',8),(163,'260000610','Ngô Hoàng','Nam','2005-04-17','260000610@eaut.edu.vn','0917042005',6),(164,'260000510','Ngô Hoàng','Nam','2005-04-10','260000510@eaut.edu.vn','0910042005',5),(165,'260000310','Ngô Hoàng','Nam','2005-03-27','260000310@eaut.edu.vn','0927032005',3),(166,'260000110','Ngô Hoàng','Nam','2005-03-13','260000110@eaut.edu.vn','0913032005',1),(167,'260000910','Ngô Hoàng','Nam','2005-05-08','260000910@eaut.edu.vn','0908052005',9),(168,'260000710','Ngô Hoàng','Nam','2005-04-24','260000710@eaut.edu.vn','0924042005',7),(169,'260000210','Ngô Hoàng','Nam','2005-03-20','260000210@eaut.edu.vn','0920032005',2),(170,'260001010','Ngô Hoàng','Nam','2005-05-15','260001010@eaut.edu.vn','0915052005',10),(171,'260000811','Dương Nhật','Phong','2005-06-13','260000811@eaut.edu.vn','0913062005',8),(172,'260000611','Dương Nhật','Phong','2005-05-30','260000611@eaut.edu.vn','0930052005',6),(173,'260000511','Dương Nhật','Phong','2005-05-23','260000511@eaut.edu.vn','0923052005',5),(174,'260000311','Dương Nhật','Phong','2005-05-09','260000311@eaut.edu.vn','0909052005',3),(175,'260000111','Dương Nhật','Phong','2005-04-25','260000111@eaut.edu.vn','0925042005',1),(176,'260000911','Dương Nhật','Phong','2005-06-20','260000911@eaut.edu.vn','0920062005',9),(177,'260000711','Dương Nhật','Phong','2005-06-06','260000711@eaut.edu.vn','0906062005',7),(178,'260000211','Dương Nhật','Phong','2005-05-02','260000211@eaut.edu.vn','0902052005',2),(179,'260001011','Dương Nhật','Phong','2005-06-27','260001011@eaut.edu.vn','0927062005',10),(180,'260000812','Hồ Anh','Quân','2005-07-26','260000812@eaut.edu.vn','0926072005',8),(181,'260000612','Hồ Anh','Quân','2005-07-12','260000612@eaut.edu.vn','0912072005',6),(182,'260000512','Hồ Anh','Quân','2005-07-05','260000512@eaut.edu.vn','0905072005',5),(183,'260000312','Hồ Anh','Quân','2005-06-21','260000312@eaut.edu.vn','0921062005',3),(184,'260000112','Hồ Anh','Quân','2005-06-07','260000112@eaut.edu.vn','0907062005',1),(185,'260000912','Hồ Anh','Quân','2005-08-02','260000912@eaut.edu.vn','0902082005',9),(186,'260000712','Hồ Anh','Quân','2005-07-19','260000712@eaut.edu.vn','0919072005',7),(187,'260000212','Hồ Anh','Quân','2005-06-14','260000212@eaut.edu.vn','0914062005',2),(188,'260001012','Hồ Anh','Quân','2005-08-09','260001012@eaut.edu.vn','0909082005',10),(189,'260000813','Võ Thanh','Tâm','2005-09-07','260000813@eaut.edu.vn','0907092005',8),(190,'260000613','Võ Thanh','Tâm','2005-08-24','260000613@eaut.edu.vn','0924082005',6),(191,'260000513','Võ Thanh','Tâm','2005-08-17','260000513@eaut.edu.vn','0917082005',5),(192,'260000313','Võ Thanh','Tâm','2005-08-03','260000313@eaut.edu.vn','0903082005',3),(193,'260000113','Võ Thanh','Tâm','2005-07-20','260000113@eaut.edu.vn','0920072005',1),(194,'260000913','Võ Thanh','Tâm','2005-09-14','260000913@eaut.edu.vn','0914092005',9),(195,'260000713','Võ Thanh','Tâm','2005-08-31','260000713@eaut.edu.vn','0931082005',7),(196,'260000213','Võ Thanh','Tâm','2005-07-27','260000213@eaut.edu.vn','0927072005',2),(197,'260001013','Võ Thanh','Tâm','2005-09-21','260001013@eaut.edu.vn','0921092005',10),(198,'260000814','Mai Hữu','Thành','2005-10-20','260000814@eaut.edu.vn','0920102005',8),(199,'260000614','Mai Hữu','Thành','2005-10-06','260000614@eaut.edu.vn','0906102005',6),(200,'260000514','Mai Hữu','Thành','2005-09-29','260000514@eaut.edu.vn','0929092005',5),(201,'260000314','Mai Hữu','Thành','2005-09-15','260000314@eaut.edu.vn','0915092005',3),(202,'260000114','Mai Hữu','Thành','2005-09-01','260000114@eaut.edu.vn','0901092005',1),(203,'260000914','Mai Hữu','Thành','2005-10-27','260000914@eaut.edu.vn','0927102005',9),(204,'260000714','Mai Hữu','Thành','2005-10-13','260000714@eaut.edu.vn','0913102005',7),(205,'260000214','Mai Hữu','Thành','2005-09-08','260000214@eaut.edu.vn','0908092005',2),(206,'260001014','Mai Hữu','Thành','2005-11-03','260001014@eaut.edu.vn','0903112005',10),(207,'260000815','Phan Xuân','Việt','2005-12-02','260000815@eaut.edu.vn','0902122005',8),(208,'260000615','Phan Xuân','Việt','2005-11-18','260000615@eaut.edu.vn','0918112005',6),(209,'260000515','Phan Xuân','Việt','2005-11-11','260000515@eaut.edu.vn','0911112005',5),(210,'260000315','Phan Xuân','Việt','2005-10-28','260000315@eaut.edu.vn','0928102005',3),(211,'260000115','Phan Xuân','Việt','2005-10-14','260000115@eaut.edu.vn','0914102005',1),(212,'260000915','Phan Xuân','Việt','2005-12-09','260000915@eaut.edu.vn','0909122005',9),(213,'260000715','Phan Xuân','Việt','2005-11-25','260000715@eaut.edu.vn','0925112005',7),(214,'260000215','Phan Xuân','Việt','2005-10-21','260000215@eaut.edu.vn','0921102005',2),(215,'260001015','Phan Xuân','Việt','2005-12-16','260001015@eaut.edu.vn','0916122005',10);
/*!40000 ALTER TABLE `students_backup` ENABLE KEYS */;
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
INSERT INTO `subjects` VALUES (1,'DCIT01','Information Security',3,1,NULL),(2,'DCIT02','Capstone Project',5,1,NULL),(3,'DCIT03','Computer Architecture',3,1,NULL),(4,'DCIT04','Mobile Application Development',4,1,NULL),(5,'DCIT05','Windows Server Administration',3,1,NULL),(6,'DCIT06','Web Design (HTML, JavaScript)',3,1,NULL),(7,'DCIT07','Internship',4,1,NULL),(8,'DCIT08','E-commerce',3,1,NULL),(9,'DCBM01','Research Project',10,2,NULL),(10,'DCBM02','Business Start-up',3,2,NULL),(11,'DCBM03','Logistics and Supply Chain Management',3,2,NULL),(12,'DCBM04','Business Law and Corporate Governance',5,2,NULL),(13,'DCBM05','Global Business Environment',5,2,NULL),(14,'DCBM06','Financial Management',3,2,NULL),(15,'DCBM07','Strategic Management',3,2,NULL),(16,'DCBM08','Marketing Management',3,2,NULL),(17,'DCBM09','Management Information Systems',3,2,NULL),(18,'DCMM01','Business Start-up',3,3,NULL),(19,'DCMM02','Sales Management',3,3,NULL),(20,'DCMM03','Strategic Management',3,3,NULL),(21,'DCMM04','Brand Management',3,3,NULL),(22,'DCMM05','Integrated Marketing Communications',3,3,NULL);
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

-- Dump completed on 2026-11-27  0:09:49
