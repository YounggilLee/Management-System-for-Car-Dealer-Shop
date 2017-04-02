INSERT INTO customer(customerID, firstName, lastName, address, phone)
VALUES(1,'Younggil', 'lee', 'Oakvile',1111111111 ),(2,'Choongwon', 'lee', 'Missisauga',2222222222);

INSERT INTO car(serial, make, model, cyear, price)
VALUES('A1','AQURA', 'MDX', 2017, 10000 ),('A2','BMW', 'M3', 2016 ,20000);

INSERT INTO employee(employeeID, password, firstName, lastName, salary, sales, commission)
VALUES(1,'1234', 'yg', 'lee', 10000, 20000, 300),(2,'1234', 'ch', 'lee', 40000, 50000, 200);

INSERT INTO invoice(invNum, invDate, netPrice, tax, otherFees, customerID, serial,employeeID )
VALUES(1,'2016-07-21', 40000, 400, 100, 1, 'A1', 1),(2,'2016-05-21', 30000, 300, 100, 2, 'A2', 2);

INSERT INTO service(servNum, laborPrice, partPrice, tax, info, customerID, serial)
VALUES(1, 300, 400, 40, 'chage window', 1, 'A1'),(2, 300, 400, 30, 'add lamp', 2, 'A2');

INSERT INTO options(optionCode, optionPrice, OptionDesc, serial)
VALUES('o1', 300,'front window','A1'),('o2', 400,'side window','A2');