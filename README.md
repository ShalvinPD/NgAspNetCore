# Angular with .Net Core and Authentication

## Creating Database and Tables 
Open a new terminal in Visual Studio code and type the following commands. Each command should end with go
`sqlcmd -S .`
`create database CM`
`use CM`

`create table Contacts (ContactId int identity(1,1) primary key, ContactName varchar(40), Location varchar(40))`

 `insert into Contacts values ('Vishnu', 'Kochi'), ('Sarathlal', 'Kakkanad'), ('Vaiskhak', 'Palarivattom')`
