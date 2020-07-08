create database [employee_db]
use [employee_db]

create table tbl_employee_designation
(
designation_id int primary key IDENTITY,
pName varchar(255) not null,
pDescription varchar(255) null
);

SET IDENTITY_INSERT tbl_employee_designation ON
insert into tbl_employee_designation (designation_id,pName) values(1,'software engineer');
insert into tbl_employee_designation (designation_id,pName) values(2,'manager');
SET IDENTITY_INSERT tbl_employee_designation OFF

create table tbl_employee
(employee_id int primary key IDENTITY,
 pName varchar(255) not null,
 designation_id int not null foreign key references tbl_employee_designation(designation_id)
 )
 delete from tbl_employee where employee_id>0;

 SET IDENTITY_INSERT tbl_employee ON
insert into tbl_employee (employee_id,pName,designation_id) values(1,'Oliver 1',1);
insert into tbl_employee (employee_id,pName,designation_id) values(2,'Joseph 2',1);
insert into tbl_employee (employee_id,pName,designation_id) values(3,'Samuel 3',1);
insert into tbl_employee (employee_id,pName,designation_id) values(4,'Oliver 11',1);
insert into tbl_employee (employee_id,pName,designation_id) values(5,'Joseph 12',1);
insert into tbl_employee (employee_id,pName,designation_id) values(6,'Samuel 13',1);
insert into tbl_employee (employee_id,pName,designation_id) values(7,'Oliver 21',1);
insert into tbl_employee (employee_id,pName,designation_id) values(8,'Joseph 22',1);
insert into tbl_employee (employee_id,pName,designation_id) values(9,'Samuel 23',1);
insert into tbl_employee (employee_id,pName,designation_id) values(51,'Hema',2);
insert into tbl_employee (employee_id,pName,designation_id) values(52,'Nagaraj',2);
insert into tbl_employee (employee_id,pName,designation_id) values(53,'Raju',2);
SET IDENTITY_INSERT tbl_employee OFF

 create table tbl_employee_manager_relationship
 (
  relationshiop_id int primary key IDENTITY,
  employee_id int not null foreign key references tbl_employee(employee_id),
  manager_id int not null foreign key references tbl_employee(employee_id)
 )

  SET IDENTITY_INSERT tbl_employee_manager_relationship ON
  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(1,1,51);
  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(2,2,52);
  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(3,3,53);

  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(4,4,51);
  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(5,5,52);
  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(6,6,53);

  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(7,7,51);
  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(8,8,52);
  insert into tbl_employee_manager_relationship (relationshiop_id,employee_id,manager_id) values(9,9,53);
  SET IDENTITY_INSERT tbl_employee_manager_relationship OFF