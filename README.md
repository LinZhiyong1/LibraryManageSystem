# LibraryManageSystem
##  Create table by SqlServer
### Create table sql
```
CREATE TABLE LibraryUser(

	userID  INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 

	userName VARCHAR(50) NOT NULL,

	password VARCHAR(50) NOT NULL,

	fullName VARCHAR(50) NOT NULL,

	email VARCHAR(50) NOT NULL,

	phone VARCHAR(20) NOT NULL,

	registerTime DATETIME NOT NULL,
);

CREATE TABLE LibraryBook(

	bookID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,

	title VARCHAR(100) NOT NULL,

	author VARCHAR(50) NOT NULL,

	publisher VARCHAR(50) NOT NULL,

	isbn VARCHAR(20) NOT NULL,

	category VARCHAR(50) NOT NULL,

	price DECIMAL(8,2) NOT NULL,

	description VARCHAR(500) DEFAULT NULL,

	totalCount INT NOT NULL,

	availableCount INT NOT NULL,

	createTime DATETIME NOT NULL
);

CREATE TABLE LibraryRecord(

	recordID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,

	userID INT NOT NULL,

	bookID INT NOT NULL,

	lendTime DATETIME NOT NULL,

	returnTime  DATETIME DEFAULT NULL,

	status INT NOT NULL,
	
	FOREIGN KEY (userID) REFERENCES LibraryUser(userID),
	
	FOREIGN KEY (bookID) REFERENCES LibraryBook(bookID)
);

CREATE TABLE LibraryAdmin(

	adminID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,

	adminName VARCHAR(50) NOT NULL,

	password VARCHAR(50) NOT NULL,

	createTime DATETIME NOT NULL
);
```