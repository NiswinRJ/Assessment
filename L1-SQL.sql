create database l1;
use l1;

CREATE TABLE ADMIN(
ADMIN_ID INT PRIMARY KEY,
ADMIN_NAME VARCHAR(25),
TOURISM_INFO VARCHAR(25),
TICKET_ID INT,
FOREIGN KEY(TICKET_ID) REFERENCES TICKET(TICKET_ID)
);
INSERT INTO ADMIN(ADMIN_ID, ADMIN_NAME, TOURISM_INFO, TICKET_ID)
VALUES 
(1, 'Ben', 'Kerala', 1),
(2, 'Charles', 'Trichy', 2),
(3, 'Sri', 'Madurai', 3),
(4, 'Adlin', 'Nagercoil', 4),
(5, 'Alex', 'Coimbatore', 5),
(6, 'Adrick', 'Karankadu', 6),
(7, 'Nishin', 'Chunkankadi', 7);

SELECT * FROM ADMIN;

update ADMIN SET TOURISM_INFO='Parvathipuram' where ADMIN_ID='7'; 

delete from ADMIN where ADMIN_ID=3; 

CREATE TABLE TICKET(
TICKET_ID INT PRIMARY KEY,
TIMINGS TIME,
TOURISM_SPOT VARCHAR(25),
TICKET_VALIDITY DATE,
TICKET_PRICE INT
);

INSERT INTO TICKET(TICKET_ID, TIMINGS, TOURISM_SPOT, TICKET_VALIDITY, TICKET_PRICE)
VALUES
(1, '7:00:00', 'KERALA', '2024-01-01', 1000),
(2, '9:00:00', 'BANGALORE', '2024-01-01', 1500),
(3, '6:00:00', 'OOTY', '2024-01-01', 2000),
(4, '6:00:00', 'KODAIKANAL', '2024-01-01', 1500),
(5, '14:00:00', 'MUNNAR', '2024-01-01', 1000),
(6, '18:00:00', 'NAGERCOIL', '2024-01-01', 500),
(7, '20:00:00', 'MADURAI', '2024-01-01', 200);

SELECT * FROM TICKET;


CREATE TABLE TOURIST(
TOURIST_ID INT PRIMARY KEY,
TOURIST_NAME VARCHAR(25),
EMAIL_ID VARCHAR(50),
TOURIST_ADDRESS VARCHAR(25),
PHONE_NUMBER VARCHAR(10)
);
INSERT INTO TOURIST VALUES
(1, 'Aashik', 'aashik@gmail.com', 'Nagercoil', '1234567890'),
(2, 'Niswin', 'niswin@gmail.com', 'Bangakore', '9876543210'),
(3, 'Aaron', 'aaron@gmail.com', 'Coimbatore', '1112223333'),
(4, 'Alex', 'alex@gmail.com', 'Bangalore', '4445556666'),
(5, 'Aadil', 'aadil@gmail.com', 'Thuckalay', '7778889990'),
(6, 'Hasim', 'hasim@gmail.com', 'Nagercoil', '2223334444'),
(7, 'Bhuvan', 'bhuvan@gmail.com', 'Velore', '5556667777');

SELECT * FROM TOURIST;
ALTER TABLE TOURIST
ADD CONSTRAINT chk5 CHECK(EMAIL_ID LIKE '%@%.com' OR EMAIL_ID IS NULL);

CREATE TABLE TOURISM_SPOT(
TOURISM_SPOT_ID INT PRIMARY KEY,
TOURISM_SPOT_NAME VARCHAR(50),
TOURISM_TIMINGS TIME,
TOURISM_TYPE VARCHAR(25)
);

INSERT INTO TOURISM_SPOT(TOURISM_SPOT_ID, TOURISM_SPOT_NAME, TOURISM_TIMINGS, TOURISM_TYPE)
VALUES
(1, 'Wonderla', '10:00:00', 'Amusement Park'),
(2, 'Nandi Hills', '06:00:00', 'Hill Station'),
(3, 'Lalbagh', '09:00:00', 'Garden'),
(4, 'Bangalore Palace', '10:00:00', 'Palace'),
(5, 'ISKCON Temple', '07:00:00', 'Temple'),
(6, 'Cubbon Park', '06:00:00', 'Park'),
(7, 'Ulsoor Lake', '08:00:00', 'Lake');

SELECT * FROM TOURISM_SPOT;



