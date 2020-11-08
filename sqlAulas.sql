/* Tipos de Criptografia
PASSWORD
SHA1
MD5*/


USE `dbcarlos`;
SELECT * FROM `funcionario`;

INSERT INTO `endereco` (`cep`, `logradouro`, `numero`, `bairro`, `cidade`, `estado`)
				   VALUES ('05882000', 'Rua Teste 1', 123, 'Bairro 1', 'Sao Paulo', 'São Paulo');
INSERT INTO `endereco` (`cep`, `logradouro`, `numero`, `bairro`, `cidade`, `estado`)
				   VALUES ('05228000', 'Rua Teste 2', 123, 'Bairro 2', 'Sao Paulo', 'São Paulo');

INSERT INTO `funcionario` (`cpf`, `nome`, `telefone`, `email`, `login`, `senha`, `nivel`, `codigoEndereco`)
				   VALUES ('12-34-567-89', 'Carlos', '12345678', 'crs@crs123.com', 'carlos', MD5('crs123'), 1, 1);
INSERT INTO `funcionario` (`cpf`, `nome`, `telefone`, `email`, `login`, `senha`, `nivel`, `codigoEndereco`)
				   VALUES ('987654321', 'Matheus', '87654321', 'mds@mds123.com', 'mds', MD5('mds123'), 2, 2);

select * from funcionario;
select * from endereco;
select * from cliente;
select * from veiculo;
desc cliente;

INSERT INTO `cliente` (`cpf`, `nome`, `email`, `telefone`, `mensalista`, `codigoEndereco`) VALUES (05228000, 'Carlos', 'crs@crs123.com', '12345678', false, 1);

SELECT `codigoCliente`, `cpf`, `nome`, `telefone` FROM `cliente`; 

SELECT `cpf`, `nome`, `login` FROM `funcionario` WHERE `nome` LIKE '%%';

SELECT `placa`, `modelo`, `fabricante`, `cor`, `codigoCliente` FROM `veiculo` WHERE placa LIKE '%MMM-4321%';

DELETE FROM `funcionario` WHERE `cpf` LIKE '987654321';
DELETE FROM `endereco` WHERE `codigoEndereco` = (SELECT `codigoEndereco` FROM `funcionario` WHERE `cpf` = '987654321');

SELECT * FROM `funcionario` WHERE `login` = 'crs' AND `senha` = md5('crs157');

DELETE FROM `endereco` WHERE `codigoEndereco` = (SELECT `codigoEndereco` FROM `cliente` WHERE `cpf` = '5228000');
DELETE FROM `cliente` WHERE `cpf` = '5228000';
SELECT `codigoEndereco` FROM `cliente` WHERE `codigoCliente` = 2;

/* CPF
028.578.352-13
810.104.456-69
671.762.423-05
976.856.511-06
637.522.547-77
571.615.318-61
232.262.747-08
541.345.964-59
126.164.852-81
391.783.258-54
293.766.425-38
644.865.402-04
*/


