CREATE DATABASE  IF NOT EXISTS `misaemployee_developmentbt` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `misaemployee_developmentbt`;
-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: misaemployee_developmentbt
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `DepartmentID` char(36) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Khóa chính phòng ban',
  `DepartmentCode` varchar(20) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Mã phòng ban',
  `DepartmentName` varchar(255) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Tên phòng ban',
  `Description` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'Diễn giải',
  PRIMARY KEY (`DepartmentID`),
  UNIQUE KEY `UQ_DepartmentCode` (`DepartmentCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci AVG_ROW_LENGTH=2048;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES ('3fa85f64-5717-4562-b3fc-2c963a55afa6','cap nhat','cap nhat ','string'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','string','string','string'),('3fa85f64-5717-4562-b3fc-2c963f66afc1','stringg','string','string'),('550e8400-e29b-41d4-a716-446655440010','RND','Research & Development','Nghiên cứu và phát triển sản phẩm'),('550e8400-e29b-41d4-a716-446655440011','CS','Customer Service','Chăm sóc khách hàng'),('550e8400-e29b-41d4-a716-446655440012','SALE','Sales','Kinh doanh và bán hàng'),('550e8400-e29b-41d4-a716-446655440013','ADMIN','Administration','Hành chính tổng hợp'),('550e8400-e29b-41d4-a716-446655440014','LEGAL','Legal','Pháp chế doanh nghiệp'),('550e8400-e29b-41d4-a716-446655440015','DATA','Data Engineering','Quản lý và phân tích dữ liệu'),('550e8400-e29b-41d4-a716-446655440016','SEC','Security','An ninh hệ thống'),('550e8400-e29b-41d4-a716-446655440017','SUP','Support','Hỗ trợ kỹ thuật');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-15 22:00:25
