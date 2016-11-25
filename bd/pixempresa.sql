create database pixempresa;
use pixempresa;
drop database pixempresa;

create table emp_empresa(
	emp_codigo int(5) not null auto_increment,
	emp_nomefantasia varchar(100) not null,
    emp_telefone1 varchar(20),
    emp_telefone2 varchar(20),
    emp_endereco varchar(140),
    emp_cidade varchar(40),
    emp_estado enum('AC','AL','AP','AM','BA','CE','DF','ES','GO','MA','MT','MS','MG','PA','PB','PR','PE','PI','RJ','RN','RS','RO','RR','SC','SP','SE','TO'),
    emp_bairro varchar(25),
    emp_cep varchar(10),
    emp_email varchar(50),
    PRIMARY KEY (emp_codigo)
); 

create table ans_anosemestre(
	ans_codigo int(5) not null auto_increment,
	ans_ano int(4) not null,
    ans_semestre int(1) not null,
    primary key (ans_codigo)
);

create table cur_cursos(
	cur_codigo int(5) not null,
    cur_nome varchar(200) not null,
    cur_sigla varchar(5) not null,
    PRIMARY KEY (cur_codigo)
);

create table psq_pesquisa(
	psq_codigo int not null auto_increment,
	psq_tipo varchar(20) not null,
    psq_implementacao varchar(20) not null,
    emp_codigo int(5) not null,
    cur_codigo int(5) not null,
    ans_codigo int(5) not null,
    psq_descricao varchar(600),
    psq_contato varchar(100) not null,
    PRIMARY KEY (psq_codigo),
    KEY (emp_codigo),
    KEY (cur_codigo),
    KEY (ans_codigo),
    CONSTRAINT psq_pesquisa_fk_1 foreign key (emp_codigo) REFERENCES emp_empresa(emp_codigo),
    CONSTRAINT psq_pesquisa_fk_2 foreign key (ans_codigo) REFERENCES ans_anosemestre(ans_codigo),
    CONSTRAINT psq_pesquisa_fk_3 foreign key (cur_codigo) REFERENCES cur_cursos(cur_codigo)
);

create table alu_aluno(
	alu_ra int(10) not null,
    alu_nome varchar(100) not null,
    PRIMARY KEY (alu_ra)
);

create table pro_professor(
	pro_matricula varchar(30) not null,
    pro_nome varchar(100) not null,
    PRIMARY KEY (pro_matricula)
);

create table psa_pesquisa_aluno(
	psa_codigo int(5) not null auto_increment,
    psq_codigo int(5) not null,
    alu_ra int(10) not null,
    PRIMARY KEY (psa_codigo),
    KEY (psq_codigo),
    KEY (alu_ra),
    CONSTRAINT psq_pesquisaaluno_fk_1 foreign key (psq_codigo) REFERENCES psq_pesquisa(psq_codigo),
    CONSTRAINT alu_pesquisaaluno_fk_2 foreign key (alu_ra) REFERENCES alu_aluno(alu_ra)
);

create table psp_pesquisa_professor(
	psp_codigo int(5) not null auto_increment,
    psq_codigo int(5) not null,
    pro_matricula varchar(30) not null,
    PRIMARY KEY (psp_codigo),
    KEY (psq_codigo),
    KEY (pro_matricula),
    CONSTRAINT psq_pesquisaprofessor_fk_1 foreign key (psq_codigo) REFERENCES psq_pesquisa(psq_codigo),
    CONSTRAINT pro_pesquisaprofessor_fk_2 foreign key (pro_matricula) REFERENCES pro_professor(pro_matricula)
);


insert into cur_cursos value(33, 'CURSO SUPERIOR DE TECNOLOGIA EM ANÁLISE E DESENVOLVIMENTO DE SISTEMAS','ADS');
insert into cur_cursos value(77, 'CURSO SUPERIOR DE TECNOLOGIA EM GESTÃO COMERCIAL','G.COM');
insert into cur_cursos value(74, 'CURSO SUPERIOR DE TECNOLOGIA EM GESTÃO EMPRESARIAL','G.EMP');
insert into cur_cursos value(73, 'CURSO SUPERIOR DE TECNOLOGIA EM GESTÃO FINANCEIRA','G.FIN');
insert into cur_cursos value(32, 'CURSO SUPERIOR DE TECNOLOGIA EM GESTÃO DA TECNOLOGIA DA INFORMAÇÃO','GTI');
insert into cur_cursos value(75, 'CURSO SUPERIOR DE TECNOLOGIA EM LOGÍSTICA','LOG');

insert into ans_anosemestre value(0,2012,1);
insert into ans_anosemestre value(0,2012,2);
insert into ans_anosemestre value(0,2013,1);
insert into ans_anosemestre value(0,2013,2);
insert into ans_anosemestre value(0,2014,1);
insert into ans_anosemestre value(0,2014,2);
insert into ans_anosemestre value(0,2015,1);
insert into ans_anosemestre value(0,2015,2);
insert into ans_anosemestre value(0,2016,1);
insert into ans_anosemestre value(0,2016,2);

insert into emp_empresa value(0,'Coca-Cola Ltda','(12)3333-3333','(12)3333-3333','Rua Tem Coca Ai Na Geladeira','Lorena','SP','Parque dos Copos','12312-123','coca@coca.com');
insert into emp_empresa value(0,'Chili Beans','(12)3333-3333','(12)3333-3333','Rua dos Oculos','Guaratinguetá','SP','Parque dos Copos','12312-123','chilibeans@hotmail.com');
insert into emp_empresa value(0,'Bradesco','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Lorena','SP','Parque dos Copos','12312-165','bradesco@banco.com');
insert into emp_empresa value(0,'Mac-Donalds','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Pindamonhangaba','SP','Primavera','12312-165','macdonalds@mcfeliz.com');
insert into emp_empresa value(0,'Santander','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Lorena','SP','Parque dos Copos','12312-165','santander@banco.com');
insert into emp_empresa value(0,'Pastelaria do Mariano','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Lorena','SP','Parque dos Copos','12312-165','pastelzin@mariano.com');
insert into emp_empresa value(0,'Riachuelo','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Guaratinguetá','SP','Parque Pereque','12312-165','riachuelo@oficial.com');
insert into emp_empresa value(0,'AGC Vidros','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Guaratinguetá','SP','Jardim Industrial','12312-165','vidros@agc.com.br');
insert into emp_empresa value(0,'Samsung','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Lorena','SP','Parque dos Copos','12312-165','samsung@company.com');
insert into emp_empresa value(0,'LG','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Lorena','SP','Parque dos Copos','12312-165','LG@banco.com');
insert into emp_empresa value(0,'Microsoft','(12)3333-3333','(12)3333-3333','Rua das Greves de Fatima','Lorena','SP','Parque dos Copos','12312-165','microsoft@miscrosoft.com');

select * from psq_pesquisa;
select * from ans_anosemestre;
select * from emp_empresa;
SELECT ans_codigo as codigo, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM ans_anosemestre ORDER BY ans_codigo;
SELECT *, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM psq_pesquisa LEFT JOIN emp_empresa USING(emp_codigo) LEFT JOIN ans_anosemestre USING(ans_codigo) ORDER BY psq_codigo;
SELECT *, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM psq_pesquisa LEFT JOIN emp_empresa USING(emp_codigo) LEFT JOIN ans_anosemestre USING(ans_codigo) LEFT JOIN cur_cursos USING(cur_codigo) ORDER BY psq_codigo;

SELECT * FROM ans_anosemestre;
SELECT *, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre,(SELECT group_concat(alu_nome separator '<br/>') FROM psa_pesquisa_aluno a INNER JOIN alu_aluno USING(alu_ra) WHERE a.psq_codigo = b.psq_codigo) as alunos, (SELECT group_concat(pro_nome separator '<br/>') FROM psp_pesquisa_professor a INNER JOIN pro_professor USING(pro_matricula) WHERE a.psq_codigo = b.psq_codigo) as professores FROM psq_pesquisa b LEFT JOIN emp_empresa USING(emp_codigo) LEFT JOIN ans_anosemestre USING(ans_codigo) LEFT JOIN cur_cursos USING(cur_codigo) WHERE cur_codigo = 73 ORDER BY anosemestre DESC ;

SELECT alu_nome FROM alu_aluno RIGHT JOIN psa_pesquisa_aluno USING(alu_ra) RIGHT JOIN psq_pesquisa USING(psq_codigo) WHERE psq_codigo = 1;
SELECT pro_nome FROM pro_professor RIGHT JOIN psp_pesquisa_professor USING(pro_matricula) RIGHT JOIN psq_pesquisa USING(psq_codigo) WHERE psq_codigo = 1; 


SELECT *, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM psq_pesquisa LEFT JOIN emp_empresa USING(emp_codigo) LEFT JOIN ans_anosemestre USING(ans_codigo) LEFT JOIN cur_cursos USING(cur_codigo) LEFT JOIN psa_pesquisa_aluno USING(psq_codigo) LEFT JOIN alu_aluno USING(alu_ra) LEFT JOIN psp_pesquisa_professor USING(psq_codigo) LEFT JOIN pro_professor USING(pro_matricula) WHERE cur_codigo = 33 ORDER BY anosemestre;
select psq_codigo from psq_pesquisa ORDER BY psq_codigo DESC limit 1;

SELECT *, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM psq_pesquisa 
LEFT JOIN emp_empresa USING(emp_codigo) 
LEFT JOIN ans_anosemestre USING(ans_codigo) 
LEFT JOIN cur_cursos USING(cur_codigo) 
LEFT JOIN psa_pesquisa_aluno USING(psq_codigo) 
LEFT JOIN alu_aluno USING(alu_ra) 
LEFT JOIN psp_pesquisa_professor USING(psq_codigo) 
LEFT JOIN pro_professor USING(pro_matricula) 
WHERE cur_codigo = 33 
ORDER BY anosemestre;





