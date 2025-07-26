-- Создание таблицы Контейнеров
CREATE TABLE Containers (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),           
    Number INT NOT NULL,                                       
    Type NVARCHAR(100) NOT NULL,                               
    Length DECIMAL(10, 2) NOT NULL,                            
    Width DECIMAL(10, 2) NOT NULL,                             
    Height DECIMAL(10, 2) NOT NULL,                            
    Weight DECIMAL(10, 2) NOT NULL,                            
    IsEmpty BIT NOT NULL DEFAULT 1,                            
    ArrivalDate DATETIME NOT NULL                             
);


-- Создание таблицы Операций
CREATE TABLE Operations (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),          
    ContainerId UNIQUEIDENTIFIER NOT NULL,                     
    StartDate DATETIME NOT NULL,                              
    EndDate DATETIME NOT NULL,                                    
    OperationType NVARCHAR(100) NOT NULL,                      
    OperatorFullName NVARCHAR(200) NOT NULL,                   
    InspectionLocation NVARCHAR(200) NOT NULL,                        

    CONSTRAINT CHK_Operations_DateOrder CHECK (EndDate >= StartDate),
    CONSTRAINT FK_Operations_Containers FOREIGN KEY (ContainerId)
        REFERENCES Containers(Id)
);


-- JSON c всеми данными по контейнерам
SELECT 
    '[' + STRING_AGG(
        FORMATMESSAGE(
            '{"Id":"%s","Number":%d,"Type":"%s","Length":"%s","Width":"%s","Height":"%s","Weight":"%s","IsEmpty":"%s","ArrivalDate":"%s"}',
            CONVERT(NVARCHAR(36), Id),                     
            Number,                                         
            Type,                                          
            CONVERT(NVARCHAR(20), Length),
            CONVERT(NVARCHAR(20), Width),      
            CONVERT(NVARCHAR(20), Height),           
            CONVERT(NVARCHAR(20), Weight),                
            CONVERT(NVARCHAR(1), IsEmpty),                 
            CONVERT(NVARCHAR(30), ArrivalDate, 126)         
        ), 
    ',') + ']'
AS JsonResult
FROM Containers;


-- JSON cо всеми данными по операциям для контейнера с ContainerId = @ContainerId
DECLARE @ContainerId UNIQUEIDENTIFIER = '11111111-1111-1111-1111-111111111111';

SELECT 
    '[' + STRING_AGG(
        FORMATMESSAGE(
            '{"Id":"%s","ContainerId":"%s","StartDate":"%s","EndDate":"%s","OperationType":"%s","OperatorFullName":"%s","InspectionLocation":"%s"}',
            CONVERT(NVARCHAR(36), Id),
            CONVERT(NVARCHAR(36), ContainerId),
            CONVERT(NVARCHAR, StartDate, 126),
            CONVERT(NVARCHAR, EndDate, 126),
            OperationType,
            OperatorFullName,
            InspectionLocation
        ), 
    ',') + ']'
AS JsonResult
FROM Operations
WHERE ContainerId = @ContainerId;
