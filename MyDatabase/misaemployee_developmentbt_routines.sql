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
-- Dumping routines for database 'misaemployee_developmentbt'
--
/*!50003 DROP PROCEDURE IF EXISTS `Proc_DeleteDepartmentById` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_DeleteDepartmentById`(IN v_DepartmentID char(36))
BEGIN
  DELETE
    FROM Department
  WHERE DepartmentID = v_DepartmentID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_DeleteEmployeeById` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_DeleteEmployeeById`(IN v_EmployeeID char(36))
BEGIN
  DELETE
    FROM Employee
  WHERE EmployeeID = v_EmployeeID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_DeletePositionById` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_DeletePositionById`(IN v_PositionID char(36))
BEGIN
  DELETE
    FROM Position
  WHERE PositionID = v_PositionID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Department_FilterPaging` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Department_FilterPaging`(IN v_pageIndex int,
IN v_pageSize int,
IN v_search varchar(255),
IN v_sort varchar(200),
IN v_searchFields json)
BEGIN

  DECLARE v_offset int;
  DECLARE v_where text DEFAULT ' WHERE 1=1 ';
  DECLARE v_orderBy text DEFAULT '';
  DECLARE v_searchCondition text;

  -- 1️⃣ Paging cơ bản
  IF v_pageIndex < 1 THEN
    SET v_pageIndex = 1;
  END IF;
  IF v_pageSize < 1 THEN
    SET v_pageSize = 20;
  END IF;

  SET v_offset = (v_pageIndex - 1) * v_pageSize;

  -- 2️⃣ Search nhiều field
  IF v_search IS NOT NULL
    AND v_search <> ''
    AND v_searchFields IS NOT NULL THEN

    SELECT
      GROUP_CONCAT(
      CONCAT(
      '`',
      JSON_UNQUOTE(JSON_EXTRACT(v_searchFields, CONCAT('$[', n, ']'))),
      '` LIKE "%', v_search, '%"'
      )
      SEPARATOR ' OR '
      ) INTO v_searchCondition
    FROM (SELECT
        0 n
      UNION
      SELECT
        1
      UNION
      SELECT
        2
      UNION
      SELECT
        3
      UNION
      SELECT
        4) t
    WHERE n < JSON_LENGTH(v_searchFields);

    IF v_searchCondition IS NOT NULL THEN
      SET v_where = CONCAT(v_where, ' AND (', v_searchCondition, ')');
    END IF;

  END IF;

  -- 3️⃣ Sort nhiều cột
  IF v_sort IS NOT NULL
    AND v_sort <> '' THEN

    SELECT
      GROUP_CONCAT(
      CONCAT(
      '`', SUBSTRING(item, 2), '` ',
      IF(LEFT(item, 1) = '-', 'DESC', 'ASC')
      )
      SEPARATOR ', '
      ) INTO v_orderBy
    FROM (SELECT
        TRIM(SUBSTRING_INDEX (SUBSTRING_INDEX (v_sort, ',', n), ',', -1)) item
      FROM (SELECT
          1 n
        UNION
        SELECT
          2
        UNION
        SELECT
          3
        UNION
        SELECT
          4) x
      WHERE n <= 1 + LENGTH(v_sort) - LENGTH(REPLACE(v_sort, ',', ''))) y;

    IF v_orderBy IS NOT NULL THEN
      SET v_orderBy = CONCAT(' ORDER BY ', v_orderBy);
    END IF;

  END IF;

  -- 4️⃣ Default sort
  IF v_orderBy IS NULL
    OR v_orderBy = '' THEN
    SET v_orderBy = ' ORDER BY DepartmentID DESC';
  END IF;

  -- 5️⃣ Build SQL
  SET @v_sql = CONCAT(
  'SELECT * FROM Department ',
  v_where,
  v_orderBy,
  ' LIMIT ', v_offset, ',', v_pageSize, '; '
  );


  -- 6. SQL count
  SET @v_sqlCount = CONCAT(
  'SELECT COUNT(*) AS Total FROM Department ',
  v_where
  );



  PREPARE stmt1 FROM @v_sql;
  EXECUTE stmt1;
  DEALLOCATE PREPARE stmt1;

  PREPARE stmt FROM @v_sqlCount;
  EXECUTE stmt;
  DEALLOCATE PREPARE stmt;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Employee_FilterPaging` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Employee_FilterPaging`(IN v_pageIndex int,
IN v_pageSize int,
IN v_search varchar(255),
IN v_sort varchar(200),
IN v_searchFields json)
BEGIN
  DECLARE v_offset int;
  DECLARE v_where text DEFAULT ' WHERE 1=1 ';
  DECLARE v_orderBy text DEFAULT '';
  DECLARE v_searchCondition text;

  -- 1. Paging
  IF v_pageIndex < 1 THEN
    SET v_pageIndex = 1;
  END IF;
  IF v_pageSize < 1 THEN
    SET v_pageSize = 20;
  END IF;

  SET v_offset = (v_pageIndex - 1) * v_pageSize;

  -- 2. Search multiple fields
  IF v_search IS NOT NULL
    AND v_search <> ''
    AND v_searchFields IS NOT NULL THEN

    SELECT
      GROUP_CONCAT(
      CONCAT(
      '`',
      JSON_UNQUOTE(JSON_EXTRACT(v_searchFields, CONCAT('$[', n, ']'))),
      '` LIKE "%', v_search, '%"'
      )
      SEPARATOR ' OR '
      ) INTO v_searchCondition
    FROM (SELECT
        0 n
      UNION
      SELECT
        1
      UNION
      SELECT
        2
      UNION
      SELECT
        3
      UNION
      SELECT
        4
      UNION
      SELECT
        5
      UNION
      SELECT
        6
      UNION
      SELECT
        7
      UNION
      SELECT
        8
      UNION
      SELECT
        9) t
    WHERE n < JSON_LENGTH(v_searchFields);

    IF v_searchCondition IS NOT NULL THEN
      SET v_where = CONCAT(v_where, ' AND (', v_searchCondition, ')');
    END IF;
  END IF;

  -- 3. Sort multiple columns
  IF v_sort IS NOT NULL
    AND v_sort <> '' THEN
    SELECT
      GROUP_CONCAT(
      CONCAT(
      '`', IF(LEFT(item,1)='-', SUBSTRING(item,2), item), '` ',
      IF(LEFT(item, 1) = '-', 'DESC', 'ASC')
      )
      SEPARATOR ', '
      ) INTO v_orderBy
    FROM (SELECT
        TRIM(SUBSTRING_INDEX (SUBSTRING_INDEX (v_sort, ',', n), ',', -1)) item
      FROM (SELECT
          1 n
        UNION
        SELECT
          2
        UNION
        SELECT
          3
        UNION
        SELECT
          4
        UNION
        SELECT
          5) x
      WHERE n <= 1 + LENGTH(v_sort) - LENGTH(REPLACE(v_sort, ',', ''))) y;

    IF v_orderBy IS NOT NULL THEN
      SET v_orderBy = CONCAT(' ORDER BY ', v_orderBy);
    END IF;
  END IF;

  -- 4. Default sort
  IF v_orderBy IS NULL
    OR v_orderBy = '' THEN
    SET v_orderBy = ' ORDER BY EmployeeID DESC';
  END IF;

  -- 5. Build SQL
  SET @v_sql = CONCAT(
  'SELECT * FROM Employee ',
  v_where,
  v_orderBy,
  ' LIMIT ', v_offset, ',', v_pageSize, ';'
  );

  -- 6. SQL count
  SET @v_sqlCount = CONCAT(
  'SELECT COUNT(*) AS Total FROM Employee ',
  v_where
  );

  PREPARE stmt1 FROM @v_sql;
  EXECUTE stmt1;
  DEALLOCATE PREPARE stmt1;

  PREPARE stmt FROM @v_sqlCount;
  EXECUTE stmt;
  DEALLOCATE PREPARE stmt;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_InsertDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_InsertDepartment`(IN v_DepartmentID char(36),
IN v_DepartmentCode varchar(20),
IN v_DepartmentName varchar(255),
IN v_Description varchar(255))
BEGIN
 
    INSERT INTO department (DepartmentID,
    DepartmentCode,
    DepartmentName,
    Description)
      VALUES (v_DepartmentID, v_DepartmentCode, v_DepartmentName, v_Description);
  END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_InsertEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_InsertEmployee`(IN v_EmployeeID char(36),
IN v_EmployeeCode varchar(20),
IN v_EmployeeName varchar(100),
IN v_Gender int,
IN v_DateOfBirth date,
IN v_PhoneNumber varchar(50),
IN v_Email varchar(100),
IN v_Address varchar(255),
IN v_DepartmentID char(36),
IN v_PositionID char(36),
IN v_Salary decimal(18, 4),
IN v_CreatedDate datetime)
BEGIN
  
    INSERT INTO employee (EmployeeID,
    EmployeeCode,
    EmployeeName,
    Gender,
    DateOfBirth,
    PhoneNumber,
    Email,
    Address,
    DepartmentID,
    PositionID,
    Salary,
    CreatedDate)
      VALUES (v_EmployeeID, v_EmployeeCode, v_EmployeeName, v_Gender, v_DateOfBirth, v_PhoneNumber, v_Email, v_Address, v_DepartmentID, v_PositionID, v_Salary, v_CreatedDate);
  END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_InsertPosition` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_InsertPosition`(IN v_PositionID char(36),
IN v_PositionCode varchar(20),
IN v_PositionName varchar(255))
BEGIN
  -- Check duplicate code
  IF EXISTS (SELECT
        1
      FROM position
      WHERE PositionCode = v_PositionCode) THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'PositionCode đã tồn tại';
  ELSE
    INSERT INTO position (PositionID,
    PositionCode,
    PositionName)
      VALUES (v_PositionID, v_PositionCode, v_PositionName);
  END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Position_FilterPaging` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Position_FilterPaging`(IN v_pageIndex int,
IN v_pageSize int,
IN v_search varchar(255),
IN v_sort varchar(200),
IN v_searchFields json)
BEGIN
  DECLARE v_offset int;
  DECLARE v_where text DEFAULT ' WHERE 1=1 ';
  DECLARE v_orderBy text DEFAULT '';
  DECLARE v_searchCondition text;

  -- 1. Paging
  IF v_pageIndex < 1 THEN
    SET v_pageIndex = 1;
  END IF;
  IF v_pageSize < 1 THEN
    SET v_pageSize = 20;
  END IF;

  SET v_offset = (v_pageIndex - 1) * v_pageSize;

  -- 2. Search multiple fields
  IF v_search IS NOT NULL
    AND v_search <> ''
    AND v_searchFields IS NOT NULL THEN

    SELECT
      GROUP_CONCAT(
      CONCAT(
      '`',
      JSON_UNQUOTE(JSON_EXTRACT(v_searchFields, CONCAT('$[', n, ']'))),
      '` LIKE "%', v_search, '%"'
      )
      SEPARATOR ' OR '
      ) INTO v_searchCondition
    FROM (SELECT
        0 n
      UNION
      SELECT
        1
      UNION
      SELECT
        2
      UNION
      SELECT
        3
      UNION
      SELECT
        4) t
    WHERE n < JSON_LENGTH(v_searchFields);

    IF v_searchCondition IS NOT NULL THEN
      SET v_where = CONCAT(v_where, ' AND (', v_searchCondition, ')');
    END IF;
  END IF;

  -- 3. Sort multiple columns
  IF v_sort IS NOT NULL
    AND v_sort <> '' THEN
    SELECT
      GROUP_CONCAT(
      CONCAT(
      '`', SUBSTRING(item, 2), '` ',
      IF(LEFT(item, 1) = '-', 'DESC', 'ASC')
      )
      SEPARATOR ', '
      ) INTO v_orderBy
    FROM (SELECT
        TRIM(SUBSTRING_INDEX (SUBSTRING_INDEX (v_sort, ',', n), ',', -1)) item
      FROM (SELECT
          1 n
        UNION
        SELECT
          2
        UNION
        SELECT
          3
        UNION
        SELECT
          4) x
      WHERE n <= 1 + LENGTH(v_sort) - LENGTH(REPLACE(v_sort, ',', ''))) y;

    IF v_orderBy IS NOT NULL THEN
      SET v_orderBy = CONCAT(' ORDER BY ', v_orderBy);
    END IF;
  END IF;

  -- 4. Default sort
  IF v_orderBy IS NULL
    OR v_orderBy = '' THEN
    SET v_orderBy = ' ORDER BY PositionID DESC';
  END IF;

  -- 5. Build SQL
  SET @v_sql = CONCAT(
  'SELECT * FROM Position ',
  v_where,
  v_orderBy,
  ' LIMIT ', v_offset, ',', v_pageSize, ';'
  );

  -- 6. SQL count
  SET @v_sqlCount = CONCAT(
  'SELECT COUNT(*) AS Total FROM Position ',
  v_where
  );

  PREPARE stmt1 FROM @v_sql;
  EXECUTE stmt1;
  DEALLOCATE PREPARE stmt1;

  PREPARE stmt FROM @v_sqlCount;
  EXECUTE stmt;
  DEALLOCATE PREPARE stmt;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_UpdateDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_UpdateDepartment`(IN v_DepartmentID char(36),
IN v_DepartmentCode varchar(20),
IN v_DepartmentName varchar(255),
IN v_Description varchar(255))
BEGIN
  -- Update
  UPDATE department
  SET DepartmentCode = v_DepartmentCode,
      DepartmentName = v_DepartmentName,
      Description = v_Description
  WHERE DepartmentID = v_DepartmentID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_UpdateEmployee` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_UpdateEmployee`(IN v_EmployeeID char(36),
IN v_EmployeeCode varchar(20),
IN v_EmployeeName varchar(100),
IN v_Gender int,
IN v_DateOfBirth date,
IN v_PhoneNumber varchar(50),
IN v_Email varchar(100),
IN v_Address varchar(255),
IN v_DepartmentID char(36),
IN v_PositionID char(36),
IN v_Salary decimal(18, 4),
IN v_CreatedDate datetime)
BEGIN
  -- Check exists
  IF NOT EXISTS (SELECT
        1
      FROM employee
      WHERE EmployeeID = v_EmployeeID) THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'Employee không tồn tại';
  END IF;

  -- Check duplicate code (except itself)
  IF EXISTS (SELECT
        1
      FROM employee
      WHERE EmployeeCode = v_EmployeeCode
      AND EmployeeID <> v_EmployeeID) THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'EmployeeCode đã tồn tại';
  END IF;

  -- Update
  UPDATE employee
  SET EmployeeCode = v_EmployeeCode,
      EmployeeName = v_EmployeeName,
      Gender = v_Gender,
      DateOfBirth = v_DateOfBirth,
      PhoneNumber = v_PhoneNumber,
      Email = v_Email,
      Address = v_Address,
      DepartmentID = v_DepartmentID,
      PositionID = v_PositionID,
      Salary = v_Salary,
      CreatedDate = v_CreatedDate
  WHERE EmployeeID = v_EmployeeID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_UpdatePosition` */;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_UpdatePosition`(IN v_PositionID char(36),
IN v_PositionCode varchar(20),
IN v_PositionName varchar(255))
BEGIN
  -- Check exists
  IF NOT EXISTS (SELECT
        1
      FROM position
      WHERE PositionID = v_PositionID) THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'Position không tồn tại';
  END IF;

  -- Check duplicate code (except itself)
  IF EXISTS (SELECT
        1
      FROM position
      WHERE PositionCode = v_PositionCode
      AND PositionID <> v_PositionID) THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'PositionCode đã tồn tại';
  END IF;

  -- Update
  UPDATE position
  SET PositionCode = v_PositionCode,
      PositionName = v_PositionName
  WHERE PositionID = v_PositionID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `misaemployee_developmentbt` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-15 22:00:26
