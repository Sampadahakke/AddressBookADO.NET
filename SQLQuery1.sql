CREATE proc SpAddContactDetails
@FirstName varchar(50),
@LastName varchar(15),
@Address varchar(100),
@City varchar(20),
@State varchar(20),
@Zip int,
@PhoneNumber bigint,
@BookName varchar(30),
@Type varchar(20)
as

insert into AddressBook values (@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @BookName, @Type)