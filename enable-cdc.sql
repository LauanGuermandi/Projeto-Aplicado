DECLARE @tableName VARCHAR(100)

DECLARE db_cursor CURSOR FOR 
    SELECT TABLE_NAME
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG=DB_NAME()

-- Enable CDC
EXEC sys.sp_cdc_enable_db;

OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @tableName  

WHILE @@FETCH_STATUS = 0  
BEGIN  
    -- Create CDC proc on table
    IF NOT charindex('dbo_', @tableName) >= 1
    BEGIN
        EXEC sys.sp_cdc_enable_table @source_schema = 'dbo', @source_name = @tableName, @role_name = NULL, @supports_net_changes = 0;
    END

    FETCH NEXT FROM db_cursor INTO @tableName  
END 

CLOSE db_cursor  
DEALLOCATE db_cursor 
