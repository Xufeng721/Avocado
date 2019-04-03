# README #

This console application is to process CSV data and map it to business entities/class. CSV can hold data for set of entities in each row. Each type of CSV will be defined as dataset. This dataset categories are mapped with CSV Columns and Entity attributes.

Used generic method to parse and map the csv column to the entity attributes.

Used Autofac to inject the parser into the processor

Used XUnit to test the parsing and reading data


### Only read the csv data and mapping to the entities into memory, did not persist onto the DB ###