-- CREATE DATABASE grudusers;
USE grudusers;
CREATE TABLE usuarios
(
	idUser INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment starting at 1, increment by 1
	nombre VARCHAR(20),
	rol VARCHAR(20)
);