CREATE TABLE public.discount (
	id serial4 NOT NULL,
	userid varchar(200) NOT NULL,
	rate int2 NOT NULL,
	code varchar(50) NOT NULL,
	createddate timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT discount_pkey PRIMARY KEY (id)
);
/*
create table discount (
	Id serial primary key,
	UserId varchar(200) unique not null,
	Rate smallint not null,
	Code varchar(50) not null,
	CreatedDate timestamp not null default CURRENT_TIMESTAMP
);
*/