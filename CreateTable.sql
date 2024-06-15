CREATE TABLE tb_party(
    id int identity(1,1) primary key,
    date_party date,
    number_of_guests int,
    space_id int,
    type_party varchar(20),
    price decimal(9,2),
    CONSTRAINT FK_party_space FOREIGN KEY (space_id) REFERENCES tb_space(id)
);

CREATE TABLE tb_space(
	id int identity(1,1) primary key,
	space_name char,
	capacity int
);