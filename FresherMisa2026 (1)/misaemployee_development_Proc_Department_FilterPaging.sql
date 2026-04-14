-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE misaemployee_development;

DELIMITER $$

--
-- Create procedure `Proc_Department_FilterPaging`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE Proc_Department_FilterPaging (IN v_pageIndex int,
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


END
$$

DELIMITER ;