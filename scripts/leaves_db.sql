create database [leave_db]
use [leave_db]

create table tbl_leave_status
(
status_id int primary key IDENTITY,
pName varchar(255) not null,
)

create table tbl_leave_requests
(
request_id int primary key IDENTITY,
reason varchar(255) not null,
manager_id int not null,
employee_id int not null,
appliedDate varchar(255) not null,
status_id int foreign key references tbl_leave_status(status_id),
comments varchar(255)
)

SET IDENTITY_INSERT tbl_leave_status ON
insert into tbl_leave_status (status_id,pName) values(1,'Applied');
insert into tbl_leave_status (status_id,pName) values(2,'Cancelled');
insert into tbl_leave_status (status_id,pName) values(3,'Approved');
insert into tbl_leave_status (status_id,pName) values(4,'Rejected');
SET IDENTITY_INSERT tbl_leave_status OFF