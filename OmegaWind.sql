-- File Name:	 Creat Tab Main.sql
-- Student Name: Younggil Lee (991 395 505)
-- Description:	 Create Tables for c#

-- 1. drop tables if they exist
DROP TABLE options;
DROP TABLE service;
DROP TABLE invoice;
DROP TABLE employee;
DROP TABLE car;
DROP TABLE customer;

-- 2. create tables
CREATE TABLE customer
(
 customerID 	DECIMAL(10),
 firstName		CHAR(10),
 lastName		CHAR(10),
 address		CHAR(50),
 phone			DECIMAL(10),
 CONSTRAINT pk_customer PRIMARY KEY (customerID) 
 );

CREATE TABLE car
(
 serial CHAR(10), 
 make CHAR(10),
 model CHAR(8),
 cyear	DECIMAL(5),
 price	DECIMAL(12),
 CONSTRAINT pk_car PRIMARY KEY (serial)
 );
  
 
 CREATE TABLE employee
(
 employeeID DECIMAL(10),
 password	CHAR(10),
 firstName	CHAR(10),
 lastName	CHAR(10),
 salary		DECIMAL(10),
 sales		DECIMAL(10),
 commission	DECIMAL(10),
 CONSTRAINT pk_employee PRIMARY KEY (employeeID) 
 );
 
  CREATE TABLE invoice
(
 invNum		DECIMAL(10),
 invDate	DATE,
 netPrice	DECIMAL(10),
 tax		DECIMAL(10),
 otherFees	DECIMAL(10),
 customerID DECIMAL(10),
 serial     CHAR(10),
 employeeID DECIMAL(10), 
 CONSTRAINT pk_invoice PRIMARY KEY (invNum),
 CONSTRAINT fk1_invoice FOREIGN KEY (customerID) REFERENCES customer (customerID),
 CONSTRAINT fk2_invoice FOREIGN KEY (serial) REFERENCES car (serial),
 CONSTRAINT fk3_invoice FOREIGN KEY (employeeID) REFERENCES employee (employeeID)
 );
 
   CREATE TABLE service
(
 servNum	DECIMAL(10),
 laborPrice	DECIMAL(10),
 partPrice	DECIMAL(10),
 tax		DECIMAL(10),
 info	 	CHAR(200),
 customerID DECIMAL(10),
 serial 	CHAR(10), 
 CONSTRAINT pk_service PRIMARY KEY (servNum),
 CONSTRAINT fk1_service FOREIGN KEY (customerID) REFERENCES customer (customerID),
 CONSTRAINT fk2_service FOREIGN KEY (serial) REFERENCES car (serial) 
 );
 
    CREATE TABLE options
(
 optionCode	CHAR(10),
 optionPrice DECIMAL(10),
 OptionDesc	CHAR(100),
 serial 	CHAR(10), 
 CONSTRAINT pk_options PRIMARY KEY (optionCode),
 CONSTRAINT fk1_options FOREIGN KEY (serial) REFERENCES car (serial) 
 );
 

 
 
 
 
 
 
 
 
 
 
 
 