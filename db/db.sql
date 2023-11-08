--CREATE DATABASE AIRCRAFT_APP
--GO

USE AIRCRAFT_APP
GO

-- 1) Drop and create all tables
DROP TABLE IF EXISTS Aircraft;
DROP TABLE IF EXISTS AircraftModels;
DROP TABLE IF EXISTS AircraftManufacturers;

CREATE TABLE Aircraft
(
  id int primary key identity,
  model int not null,
  serialnumber varchar(63) not null,
  tailnumber varchar(63) not null
);

CREATE TABLE AircraftModels
(
  id int primary key identity,
  name varchar(127),
  make int not null,
  CONSTRAINT unique_model UNIQUE(name)
);

CREATE TABLE AircraftManufacturers
(
  id int primary key identity,
  name varchar(127),
  CONSTRAINT unique_manufacturer UNIQUE(name)
);

ALTER TABLE Aircraft
  ADD CONSTRAINT fk_aircraft_aircraftmodels FOREIGN KEY (model)
    REFERENCES AircraftModels(id)
    ON DELETE CASCADE -- If a row from the parent table (AircraftModels) is deleted, the Aircraft entry referencing it will also be deleted
    ON UPDATE CASCADE -- If a row from the parent table (AircraftModels) is updated, the Aircraft entry referencing it will also be updated
;

ALTER TABLE AircraftModels
  ADD CONSTRAINT fk_aircraftmodels_aircraftmanufacturers FOREIGN KEY (make)
    REFERENCES AircraftManufacturers(id)
;