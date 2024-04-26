ale wykłady bardzo fajne <3
BAZA Z DOCKERA
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker run --name SQLServer -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password12345' -e 'MSSQL_PID=Express’ -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest\n\ndocker run --name SQLServer -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password12345' -e 'MSSQL_PID=Express’ -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

TWORZENIE:
CREATE TABLE Animal
(
    IdAnimal INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200),
    Description NVARCHAR(200) NULL,
    Category NVARCHAR(200),
    Area NVARCHAR(200)
)

JAKIEŚ DEFAULTOWE DANE DO TESTOWANIA
INSERT INTO Animal (Name, Description, Category, Area)
VALUES ('Lion', 'King', 'Mammal', 'Africa'),
       ('Eagle', 'Bird', 'Bird', 'America'),
       ('Python', 'Snake', 'Reptile', 'Asia')
