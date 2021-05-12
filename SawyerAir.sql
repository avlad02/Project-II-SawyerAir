CREATE DATABASE SawyerAirDb
ON 
(
	Name = SawyerAir,
	Filename = 'D:\Adelin\Facultate\ANUL 3\14. Project2\SawyerAir.mdf'
)

USE SawyerAirDb

CREATE TABLE Client
(
	ClientID		INT IDENTITY(1,1) PRIMARY KEY,
	Name			varchar(40) NOT NULL,
	Surname			varchar(40) NOT NULL,
	PhoneNumber		varchar(10) NOT NULL,
	Email			varchar(50) NOT NULL,
	Adress			varchar(80) NOT NULL,
)

CREATE TABLE Card
(
	CardID			INT IDENTITY(1,1) PRIMARY KEY,
	ClientID		INT FOREIGN KEY REFERENCES Client(ClientID) ON DELETE CASCADE ON UPDATE CASCADE,
	ExpirationDate	DATE,
	Number			INT,
	CVC				INT,
)

CREATE TABLE Route
(
	RouteID			INT IDENTITY(1,1) PRIMARY KEY,
	DepartureLoc	varchar(40) NOT NULL,
	DestinationLoc	varchar(40) NOT NULL
)

CREATE TABLE Booked
(
	ClientID		INT FOREIGN KEY REFERENCES Client(ClientID) ON DELETE CASCADE ON UPDATE CASCADE,
	RouteID			INT FOREIGN KEY REFERENCES Route(RouteID) ON DELETE CASCADE ON UPDATE CASCADE,
	PaymentDate		DATE,
	PaymentMethod	varchar(20),
	FlightClass		INT,
	BookingDate		DATE,
	UNIQUE (ClientID, RouteID)
)

CREATE TABLE Line
(
	LineID			INT IDENTITY(1,1) PRIMARY KEY,
	Name			varchar(40) NOT NULL
)

CREATE TABLE Plane
(
	PlaneID			INT IDENTITY(1,1) PRIMARY KEY,
	LineID			INT FOREIGN KEY REFERENCES Line(LineID) ON DELETE CASCADE ON UPDATE CASCADE,
	Model			varchar(40) NOT NULL,
	Manufacturer	varchar(40) NOT NULL
)

CREATE TABLE Flight
(
	PlaneID			INT FOREIGN KEY REFERENCES Plane(PlaneID) ON DELETE CASCADE ON UPDATE CASCADE,
	RouteID			INT FOREIGN KEY REFERENCES Route(RouteID) ON DELETE CASCADE ON UPDATE CASCADE,
	DepartureHour	TIME NOT NULL,
	DestinationHour	TIME NOT NULL
	UNIQUE (PlaneID, RouteID)
)

CREATE TABLE Stop
(
	StopID			INT IDENTITY(1,1) PRIMARY KEY,
	Location		varchar(40) NOT NULL
)

CREATE TABLE Route_Stop
(
	RouteID			INT FOREIGN KEY REFERENCES Route(RouteID) ON DELETE CASCADE ON UPDATE CASCADE,
	StopId			INT FOREIGN KEY REFERENCES Stop(StopID)	ON DELETE CASCADE ON UPDATE CASCADE,
	StopTime		TIME NOT NULL
)

CREATE TABLE PlaneClass
(
	ClassID			INT IDENTITY(1,1) PRIMARY KEY,
	Name			varchar(40) NOT NULL
)

CREATE TABLE Class_Info
(
	ClassID			INT FOREIGN KEY REFERENCES PlaneClass(ClassID) ON DELETE CASCADE ON UPDATE CASCADE,
	RouteID			INT FOREIGN KEY REFERENCES Route(RouteID) ON DELETE CASCADE ON UPDATE CASCADE,
	Nr_seats		INT NOT NULL,
	Price			INT NOT NULL
)

select *from Card
select *from Client
select *from Booked
select *from Route
select *from Flight
select *from Plane
select *from Line
select *from Stop
select *from Route_Stop
select *from Class_Info
select *from PlaneClass

drop table Card
drop table Client
drop table Booked
drop table Route
drop table Flight
drop table Plane
drop table Line
drop table Stop
drop table Route_Stop
drop table Class_Info
drop table PlaneClass

