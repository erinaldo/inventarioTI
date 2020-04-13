USE master

IF NOT EXISTS (SELECT * FROM SYS.databases WHERE NAME = 'INVTIC')
	CREATE DATABASE INVTIC

GO

USE INVTIC

GO

/***************************************************************************************************************************************************************/
												/*********   IN�CIO DO M�DULO DE COMPUTADORES   *********/
/***************************************************************************************************************************************************************/

IF NOT EXISTS (SELECT * fROM SYS.objects WHERE type = 'U' AND name = 'NOTAFISCAL')
	CREATE TABLE NOTAFISCAL
	(
		ID				INT IDENTITY,
		NUMNF			VARCHAR(20),
		FORNECEDOR		VARCHAR(200),
		DATA			SMALLDATETIME,
		EMPRESA			VARCHAR(200),
		LINK			VARCHAR(MAX)

		PRIMARY KEY (ID)
	)

GO

IF NOT EXISTS (SELECT * fROM SYS.objects WHERE type = 'U' AND name = 'SOFTWARE')
	CREATE TABLE SOFTWARE
	(
		ID				INT IDENTITY,
		NOME			VARCHAR(200),
		FABRICANTE		VARCHAR(200),
		VERSAO			VARCHAR(10),
		NOMETECNICO		VARCHAR(500)

		PRIMARY KEY (ID)
	)

GO

IF NOT EXISTS (SELECT * fROM SYS.objects WHERE type = 'U' AND name = 'LICENCAS')
	CREATE TABLE LICENCAS
	(
		ID						INT IDENTITY,
		NOTAFISCALID			INT,
		SOFTWAREID				INT,
		QUANTIDADE				DECIMAL(18,2),
		CHAVE					VARCHAR(200),
		STATUS					VARCHAR(1)

		PRIMARY KEY (ID),
		FOREIGN KEY (NOTAFISCALID) REFERENCES NOTAFISCAL (ID),
		FOREIGN KEY (SOFTWAREID) REFERENCES SOFTWARE (ID)
		--, CONSTRAINT UNLICENCAS UNIQUE (NOTAFISCALID, SOFTWAREID, CHAVE)
	)

GO

IF NOT EXISTS (SELECT * fROM SYS.objects WHERE type = 'U' AND name = 'COMPUTADORES')
	CREATE TABLE COMPUTADORES
	(
		ID						INT IDENTITY,
		ATIVOANTIGO				VARCHAR(100),
		ATIVONOVO				VARCHAR(100),
		USUARIO					VARCHAR(200),
		DEPARTAMENTO			VARCHAR(100),
		STATUS					CHAR(2),
		OCSID					INT,
		OBSERVACOES				VARCHAR(MAX)

		PRIMARY KEY (ID)
	)

GO

IF NOT EXISTS (SELECT * fROM SYS.objects WHERE type = 'U' AND name = 'COMPUTADORESLICENCAS')
	CREATE TABLE COMPUTADORESLICENCAS
	(
		COMPUTADORESID			INT,
		LICENCAID				INT

		PRIMARY KEY (COMPUTADORESID, LICENCAID),
		FOREIGN KEY (COMPUTADORESID) REFERENCES COMPUTADORES (ID),
		FOREIGN KEY (LICENCAID) REFERENCES LICENCAS (ID),
		CONSTRAINT UNCOMPUTADORESLICENCA UNIQUE (LICENCAID),
		CONSTRAINT UNCOMPUTADORESID UNIQUE (COMPUTADORESID, LICENCAID)
	)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'V' AND name = 'OCS')
	DROP VIEW OCS

GO

CREATE VIEW OCS
AS
SELECT * FROM OPENQUERY(MYSQLNEWOCS,'select id, name, ipaddr, osname, userid, winprodid, winprodkey, workgroup, processort, memory, lastdate, lastcome
									From hardware
									order by id') 

GO

IF NOT EXISTS (SELECT * fROM SYS.objects WHERE type = 'U' AND name = 'STATUS')
	CREATE TABLE STATUS
	(
		ID				INT IDENTITY,
		CODIGO			VARCHAR(10),
		NOME			VARCHAR(200)

		PRIMARY KEY (ID)
	)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETCOMPUTADORES')
	DROP PROCEDURE GETCOMPUTADORES

GO

CREATE PROCEDURE GETCOMPUTADORES
AS
SELECT C.ID, C.ATIVOANTIGO, C.ATIVONOVO, C.USUARIO, C.DEPARTAMENTO,
CASE WHEN C.STATUS = 'EE' THEN
	'Em Estoque'
ELSE CASE WHEN c.STATUS = 'VA' THEN
	'Vago'
ELSE CASE WHEN c.STATUS = 'EU' THEN
	'Em Uso'
END END END AS STATUS, C.STATUS AS STATUS1,
CASE WHEN OCS.ID IS NOT NULL THEN
	'Sim'
ELSE
	'N�o'
END AS TEMLIGACAOCOMOCS, C.OBSERVACOES,
C.OCSID, 
OCS.ID, OCS.name, OCS.IPADDR, OCS.OSNAME, OCS.USERID, OCS.WINPRODID, OCS.WINPRODKEY, OCS.WORKGROUP, OCS.PROCESSORT, OCS.MEMORY, OCS.LASTDATE, OCS.LASTCOME, 
		OCS.id AS DISCOID, OCS.HARDWARE_ID, OCS.LETTER, OCS.TYPE, OCS.FILESYSTEM, OCS.TOTAL, OCS.FREE, OCS.VOLUMN
FROM COMPUTADORES C
LEFT OUTER JOIN 
(		SELECT * FROM OPENQUERY(MYSQLNEWOCS,'
		SELECT h.ID, h.name, h.IPADDR, h.OSNAME, h.USERID, h.WINPRODID, h.WINPRODKEY, h.WORKGROUP, h.PROCESSORT, h.MEMORY, h.LASTDATE, h.LASTCOME, 
		d.id AS DISCOID, d.HARDWARE_ID, d.LETTER, d.TYPE, d.FILESYSTEM, d.TOTAL, d.FREE, d.VOLUMN
		FROM hardware h
		LEFT JOIN drives d on h.id = d.hardware_id
		WHERE h.DEVICEID not like ''%android%''')
) OCS ON OCS.ID = C.OCSID
ORDER BY C.ATIVONOVO

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETCOMPUTADORSTATUS')
	DROP PROCEDURE GETCOMPUTADORSTATUS

GO

CREATE PROCEDURE GETCOMPUTADORSTATUS
AS
	SELECT 'EU' AS CODSTATUS, 'Em Uso' AS STATUS
	UNION ALL
	SELECT 'EE' AS CODSTATUS, 'Em Estoque' AS STATUS
	UNION ALL
	SELECT 'VA' AS CODSTATUS, 'Vago' AS STATUS

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTCOMPUTADORES')
	DROP PROCEDURE POSTCOMPUTADORES

GO

CREATE PROCEDURE POSTCOMPUTADORES
	-- @ID						int,
	@ATIVOANTIGO			varchar(100),
	@ATIVONOVO				varchar(100),
	@USUARIO				varchar(200),
	@DEPARTAMENTO			varchar(100),
	@STATUS					char(2),
	@OBSERVACOES			VARCHAR(MAX) = NULL
	--,@OCSID					int
AS
	INSERT INTO COMPUTADORES 
	(ATIVOANTIGO, ATIVONOVO, USUARIO, DEPARTAMENTO, STATUS, OBSERVACOES) VALUES 
	(@ATIVOANTIGO, @ATIVONOVO, @USUARIO, @DEPARTAMENTO, @STATUS, @OBSERVACOES)

	SELECT scope_identity()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTCOMPUTADORES')
	DROP PROCEDURE PUTCOMPUTADORES

GO

CREATE PROCEDURE PUTCOMPUTADORES
	@ID						int,
	@ATIVOANTIGO			varchar(100),
	@ATIVONOVO				varchar(100),
	@USUARIO				varchar(200),
	@DEPARTAMENTO			varchar(100),
	@STATUS					char(2),
	@OBSERVACOES			VARCHAR(MAX)
AS
	UPDATE COMPUTADORES SET
	ATIVOANTIGO = @ATIVOANTIGO, 
	ATIVONOVO = @ATIVONOVO, 
	USUARIO = @USUARIO, 
	DEPARTAMENTO = @DEPARTAMENTO, 
	STATUS = @STATUS,
	OBSERVACOES = @OBSERVACOES
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETECOMPUTADORES')
	DROP PROCEDURE DELETECOMPUTADORES

GO

CREATE PROCEDURE DELETECOMPUTADORES
	@ID					INT
AS
	DELETE COMPUTADORES
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETCOMPUTADORESOCS')
	DROP PROCEDURE GETCOMPUTADORESOCS

GO

CREATE PROCEDURE GETCOMPUTADORESOCS
AS
	SELECT * FROM OCS

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTASSOCIARAOOCS')
	DROP PROCEDURE PUTASSOCIARAOOCS

GO

CREATE PROCEDURE PUTASSOCIARAOOCS
	@COMPUTADORID			INT,
	@COMPUTADOROCSID		INT
AS
	UPDATE COMPUTADORES
	SET OCSID = @COMPUTADOROCSID
	WHERE ID = @COMPUTADORID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETNOTASFISCAIS')
	DROP PROCEDURE GETNOTASFISCAIS

GO

CREATE PROCEDURE GETNOTASFISCAIS
AS
	SELECT * FROM NOTAFISCAL	

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTNOTAFISCAL')
	DROP PROCEDURE POSTNOTAFISCAL

GO

CREATE PROCEDURE POSTNOTAFISCAL
	-- @ID	int,
	@NUMNF	varchar(20),
	@FORNECEDOR	varchar(200),
	@DATA	smalldatetime,
	@EMPRESA	varchar(200),
	@LINK	varchar(max)	
AS
	INSERT INTO NOTAFISCAL (NUMNF, FORNECEDOR, DATA, EMPRESA, LINK) VALUES (@NUMNF, @FORNECEDOR, @DATA, @EMPRESA, @LINK)

	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTNOTAFISCAL')
	DROP PROCEDURE PUTNOTAFISCAL

GO

CREATE PROCEDURE PUTNOTAFISCAL
	@NUMNF	varchar(20),
	@FORNECEDOR	varchar(200),
	@DATA	smalldatetime,
	@EMPRESA	varchar(200),
	@LINK	varchar(max),
	@ID	int
AS
	UPDATE NOTAFISCAL SET
	NUMNF = @NUMNF,
	FORNECEDOR = @FORNECEDOR,
	DATA = @DATA,
	EMPRESA = @EMPRESA,
	LINK = @LINK
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETENOTAFISCAL')
	DROP PROCEDURE DELETENOTAFISCAL

GO

CREATE PROCEDURE DELETENOTAFISCAL
	@ID			INT
AS
	DELETE NOTAFISCAL
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTSOFTWARE')
	DROP PROCEDURE POSTSOFTWARE

GO

CREATE PROCEDURE POSTSOFTWARE
	@NOME			VARCHAR(200),
	@FABRICANTE		VARCHAR(200),
	@VERSAO			VARCHAR(10),
	@NOMETECNICO	VARCHAR(500) = NULL
AS
	INSERT SOFTWARE (NOME, FABRICANTE, VERSAO, NOMETECNICO) VALUES (@NOME, @FABRICANTE, @VERSAO, @NOMETECNICO)
	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTSOFTWARE')
	DROP PROCEDURE PUTSOFTWARE

GO

CREATE PROCEDURE PUTSOFTWARE
	@NOME			VARCHAR(200),
	@FABRICANTE		VARCHAR(200),
	@VERSAO			VARCHAR(10),	
	@NOMETECNICO		VARCHAR(500),
	@ID				INT
AS
	UPDATE SOFTWARE 
	SET NOME = @NOME,
	FABRICANTE = @FABRICANTE,
	VERSAO = @VERSAO,
	NOMETECNICO = @NOMETECNICO
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETESOFTWARE')
	DROP PROCEDURE DELETESOFTWARE

GO

CREATE PROCEDURE DELETESOFTWARE
	@ID			INT
AS
	DELETE SOFTWARE
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETSOFTWARES')
	DROP PROCEDURE GETSOFTWARES

GO

CREATE PROCEDURE GETSOFTWARES
AS
	SELECT * FROM SOFTWARE

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTLICENCAS')
	DROP PROCEDURE POSTLICENCAS

GO

CREATE PROCEDURE POSTLICENCAS
	--@ID	int,
	@NOTAFISCALID	int,
	@SOFTWAREID	int,
	@QUANTIDADE	decimal,
	@CHAVE	varchar(200),
	@STATUS	varchar(1)
AS
	INSERT INTO LICENCAS (NOTAFISCALID, SOFTWAREID, QUANTIDADE, CHAVE, STATUS) VALUES (@NOTAFISCALID, @SOFTWAREID, @QUANTIDADE, @CHAVE, @STATUS)
	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTLICENCAS')
	DROP PROCEDURE PUTLICENCAS

GO

CREATE PROCEDURE PUTLICENCAS
	@NOTAFISCALID	int,
	@SOFTWAREID	int,
	@QUANTIDADE	decimal,
	@CHAVE	varchar(200),
	@STATUS	varchar(1),
	@ID	int
AS
	UPDATE LICENCAS SET
	NOTAFISCALID = @NOTAFISCALID, 
	SOFTWAREID = @SOFTWAREID,
	QUANTIDADE = @QUANTIDADE,
	CHAVE = @CHAVE,
	STATUS = @STATUS
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETELICENCAS')
	DROP PROCEDURE DELETELICENCAS

GO

CREATE PROCEDURE DELETELICENCAS
	@ID		INT
AS
	DELETE LICENCAS
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETLICENCAS')
	DROP PROCEDURE GETLICENCAS

GO

CREATE PROCEDURE GETLICENCAS
AS
SELECT *
FROM LICENCAS L
LEFT JOIN  NOTAFISCAL NF ON L.NOTAFISCALID = NF.ID
LEFT JOIN SOFTWARE S ON S.ID = L.SOFTWAREID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTCOMPUTADORESLICENCAS')
	DROP PROCEDURE POSTCOMPUTADORESLICENCAS

GO

CREATE PROCEDURE POSTCOMPUTADORESLICENCAS
	@COMPUTADORESID		INT,
	@LICENCAID			INT
AS
	INSERT COMPUTADORESLICENCAS VALUES (@COMPUTADORESID, @LICENCAID)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETECOMPUTADORESLICENCAS')
	DROP PROCEDURE DELETECOMPUTADORESLICENCAS

GO	

CREATE PROCEDURE DELETECOMPUTADORESLICENCAS
	@COMPUTADORESID		INT,
	@LICENCAID			INT
AS
	DELETE COMPUTADORESLICENCAS
	WHERE COMPUTADORESID = @COMPUTADORESID AND
	LICENCAID = @LICENCAID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETCOMPUTADORESLICENCAS')
	DROP PROCEDURE GETCOMPUTADORESLICENCAS

GO	

CREATE PROCEDURE GETCOMPUTADORESLICENCAS
AS
SELECT CL.COMPUTADORESID, CL.LICENCAID,
C.ID, ATIVOANTIGO, ATIVONOVO, USUARIO, DEPARTAMENTO, C.STATUS, OCSID, 
L.ID, L.NOTAFISCALID, L.SOFTWAREID, L.QUANTIDADE, L.CHAVE, L.STATUS, 
NF.ID, NF.NUMNF, NF.FORNECEDOR, NF.DATA, NF.EMPRESA, NF.LINK,
S.ID, S.NOME, S.FABRICANTE, S.VERSAO
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
order by c.ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETCONFRONTOLICENCASCOMPUTADORES')
	DROP PROCEDURE GETCONFRONTOLICENCASCOMPUTADORES

GO	

CREATE PROCEDURE GETCONFRONTOLICENCASCOMPUTADORES
AS
/*CONTINUAR BATENDO AS LICEN�AS DE WINDOWS E OFFICE COLETADAS DA PLANILHA DO MICHEL COM O OCS*/
--DROP TABLE #TMPLICENCAS

SELECT C.ID, C.ATIVOANTIGO, C.ATIVONOVO, C.USUARIO, C.DEPARTAMENTO, C.STATUS, C.OCSID, WINDOWS.NOME AS WINDOWS, OFFICE.NOME AS OFFICE
INTO #TMPLICENCAS
FROM COMPUTADORES C
LEFT OUTER JOIN
(
	SELECT S.NOMETECNICO AS NOME, CL.COMPUTADORESID
	FROM COMPUTADORESLICENCAS CL 
	INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
	INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
	WHERE S.NOME LIKE '%WINDOWS%'
) AS WINDOWS ON WINDOWS.COMPUTADORESID = C.ID
LEFT OUTER JOIN
(
	SELECT S.NOMETECNICO AS NOME, CL.COMPUTADORESID
	FROM COMPUTADORESLICENCAS CL 
	INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
	INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
	WHERE S.NOME LIKE '%OFFICE%'
) AS OFFICE ON OFFICE.COMPUTADORESID = C.ID
--WHERE C.ID = 6

SELECT * 
INTO #TMPOCS
FROM OPENQUERY(MYSQLNEWOCS,'SELECT h.ID, h.NAME, h.USERID, h.USERDOMAIN, h.WINPRODID, h.OSNAME AS WINDOWS, OFFICE.OFFICE
FROM hardware h
LEFT OUTER JOIN
(
	SELECT DISTINCT h.ID, s.name as OFFICE
	FROM hardware h
	INNER JOIN softwares s ON h.ID = s.HARDWARE_ID
	WHERE (s.name LIKE ''microsoft%office%home%'' OR 
	s.name LIKE ''microsoft%office%prof%'')
) AS OFFICE ON OFFICE.ID = h.ID')
									 
SELECT CASE WHEN A.WINDOWS = B.WINDOWS THEN --CASE WHEN LTRIM(RTRIM(SUBSTRING(A.WINDOWS, 0, LEN(A.WINDOWS) -3))) = LTRIM(RTRIM(B.WINDOWS)) THEN
	'LICEN�A WINDOWS OK COM O OCS'
ELSE CASE WHEN A.WINDOWS IS NULL THEN
	'N�O EXISTE NF DO WINDOWS'
ELSE
	'LICEN�A COM PROBLEMA'
END END AS STATUSLICENCAWINDOWS,
CASE WHEN A.OFFICE = B.OFFICE THEN --CASE WHEN SUBSTRING(A.OFFICE, 0, LEN(A.OFFICE) -3) = B.OFFICE THEN
	'LICEN�A OFFICE OK COM O OCS'
ELSE CASE WHEN A.OFFICE IS NULL THEN
	'N�O TEM OFFICE INSTALADO'
ELSE
	'LICEN�A COM PROBLEMA'
END END AS STATUSLICENCAOFFICE, *
FROM #TMPLICENCAS A
INNER JOIN #TMPOCS B ON A.ATIVONOVO = B.NAME

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'RELLICENCASNAOUTILIZADAS')
	DROP PROCEDURE RELLICENCASNAOUTILIZADAS

GO	

CREATE PROCEDURE RELLICENCASNAOUTILIZADAS
	@SOFTWAREID			INT,
	@FORNECEDOR			VARCHAR(200),
	@NUMNF				VARCHAR(9)
AS

SELECT NF.NUMNF, NF.FORNECEDOR, NF.EMPRESA, NF.LINK, S.NOME AS SOFTWARE, SUM(L.QUANTIDADE) QTDELICENCAS, 
COUNT(CL.COMPUTADORESID) QTDEUTILIZADA, L.STATUS STATUSLICENCA, SUM(L.QUANTIDADE) - COUNT(CL.COMPUTADORESID) AS QTDESOBRANDO
FROM LICENCAS L
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID
LEFT JOIN COMPUTADORESLICENCAS CL ON L.ID = CL.LICENCAID
WHERE (S.ID = @SOFTWAREID OR @SOFTWAREID = -1) AND
(NF.FORNECEDOR = @FORNECEDOR OR @FORNECEDOR = '') AND
(NF.NUMNF = @NUMNF OR @NUMNF = '')
GROUP BY NF.NUMNF, NF.FORNECEDOR, NF.LINK, S.NOME, NF.EMPRESA, L.STATUS
HAVING SUM(L.QUANTIDADE) - COUNT(CL.COMPUTADORESID) > 0
ORDER BY NF.NUMNF


/***************************************************************************************************************************************************************/
												/*********   FINAL DO M�DULO DE COMPUTADORES   *********/
/***************************************************************************************************************************************************************/

GO


/***************************************************************************************************************************************************************/
												/*********   IN�CIO DO M�DULO DE CELULARES   *********/
/***************************************************************************************************************************************************************/

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE TYPE = 'U' AND NAME = 'LINHA')
	CREATE TABLE LINHA
	(
		ID			INT IDENTITY,
		NUMERO		VARCHAR(11),
		CHIP		VARCHAR(100),
		PIN			VARCHAR(100),
		PUK			VARCHAR(100)

		PRIMARY KEY (ID)
	)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTLINHA')
	DROP PROCEDURE POSTLINHA

GO

CREATE PROCEDURE POSTLINHA
	@NUMERO		VARCHAR(11),
	@CHIP		VARCHAR(100),
	@PIN		VARCHAR(100) = NULL,
	@PUK		VARCHAR(100) = NULL
AS
	INSERT LINHA VALUES (@NUMERO, @CHIP, @PIN, @PUK)	

	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTLINHA')
	DROP PROCEDURE PUTLINHA

GO

CREATE PROCEDURE PUTLINHA	
	@NUMERO		VARCHAR(11),
	@CHIP		VARCHAR(100),
	@PIN		VARCHAR(100) = NULL,
	@PUK		VARCHAR(100) = NULL,
	@ID			INT
AS
	UPDATE LINHA SET
	NUMERO = @NUMERO,
	CHIP = @CHIP,
	PIN = @PIN,
	PUK = @PUK
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETELINHA')
	DROP PROCEDURE DELETELINHA

GO

CREATE PROCEDURE DELETELINHA	
	@ID			INT
AS
	DELETE LINHA
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETLINHA')
	DROP PROCEDURE GETLINHA

GO

CREATE PROCEDURE GETLINHA	
AS 
    SELECT * FROM LINHA

GO

/******************************************************************************************************/

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'UNLINHA' AND type = 'UQ')
	ALTER TABLE LINHA
	ADD CONSTRAINT UNLINHA UNIQUE (NUMERO)

GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE TYPE = 'U' AND NAME = 'USUARIO')
	CREATE TABLE USUARIO
	(
		ID			INT IDENTITY,
		CHAPA		VARCHAR(10),
		NOME		VARCHAR(200),
		CPF			VARCHAR(200)
		--GESTOR		VARCHAR(500)

		PRIMARY KEY (ID)
	)

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'USUARIO' AND  COLUMN_NAME = 'GESTOR')
	ALTER TABLE USUARIO
	DROP COLUMN GESTOR

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'USUARIO' AND  COLUMN_NAME = 'TERCEIRO')
	ALTER TABLE USUARIO
	ADD TERCEIRO		INT

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETUSUARIOS')
	DROP PROCEDURE GETUSUARIOS

GO

CREATE PROCEDURE GETUSUARIOS
AS
    SELECT * FROM USUARIO

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'V' AND name = 'COLABORADORES')
	DROP VIEW COLABORADORES

GO

CREATE VIEW COLABORADORES
AS
	SELECT C.CHAPA, P.NOME, P.CPF, C.CODSITUACAO, PS.NROCENCUSTOCONT AS CODCCUSTO, GC.NOME AS CENTROCUSTO
	FROM CORPORENOVO..PFUNC C  
	INNER JOIN CORPORENOVO..PPESSOA P ON C.CODPESSOA = P.CODIGO
	INNER JOIN CORPORENOVO..PSECAO PS ON C.CODSECAO = PS.CODIGO AND C.CODCOLIGADA = PS.CODCOLIGADA
	INNER JOIN CORPORENOVO..GCCUSTO GC ON GC.CODCCUSTO = PS.NROCENCUSTOCONT AND GC.CODCOLIGADA = PS.CODCOLIGADA
	WHERE C.CODCOLIGADA = 5 AND  
	C.CODTIPO = 'N'

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTUSUARIOS')
	DROP PROCEDURE POSTUSUARIOS

GO

CREATE PROCEDURE POSTUSUARIOS
AS
	INSERT INTO USUARIO

	SELECT C.CHAPA, C.NOME + ' (' + C.CODSITUACAO + ')' AS NOME, ISNULL(C.CPF, '') AS CPF, '1' AS TERCEIRO
	FROM COLABORADORES C
	LEFT JOIN USUARIO U ON C.CHAPA COLLATE SQL_Latin1_General_CP1_CI_AS = C.CHAPA COLLATE SQL_Latin1_General_CP1_CI_AS
	WHERE U.Id IS NULL AND
	U.TERCEIRO = 1
	ORDER BY C.CODSITUACAO, C.NOME

	SELECT *,
	CASE WHEN TERCEIRO = 1 THEN
		'N�o'
	ELSE
		'Sim'
	END AS TERCEIRODESCRICAO
	FROM USUARIO

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTUSUARIO')
	DROP PROCEDURE POSTUSUARIO

GO

CREATE PROCEDURE POSTUSUARIO
	@CHAPA		VARCHAR(10),
	@NOME		VARCHAR(200),
	@CPF		VARCHAR(200),
	@TERCEIRO	INT
AS
	INSERT USUARIO VALUES (@CHAPA, @NOME, @CPF, @TERCEIRO)

	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTUSUARIO')
	DROP PROCEDURE PUTUSUARIO

GO

CREATE PROCEDURE PUTUSUARIO
	@CHAPA		VARCHAR(10),
	@NOME		VARCHAR(200),
	@CPF		VARCHAR(200),
	@TERCEIRO	INT,
	@ID			INT
AS
	UPDATE USUARIO SET
	CHAPA = @CHAPA, 
	NOME = @NOME, 
	CPF = @CPF, 
	TERCEIRO = @TERCEIRO
	WHERE ID = @ID

/*****************************************************************************************************************************/

GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE TYPE = 'U' AND NAME = 'APARELHO')
	CREATE TABLE APARELHO
	(
		ID			INT IDENTITY,
		MARCA		VARCHAR(100),
		MODELO		VARCHAR(100),
		IMEI1		VARCHAR(100),
		IMEI2		VARCHAR(100),
		VALOR		DECIMAL(18,2)

		PRIMARY KEY (ID)
	)

GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'UNIMEI1' AND type = 'UQ')
	ALTER TABLE APARELHO
	ADD CONSTRAINT UNIMEI1 UNIQUE (IMEI1)

GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'UNIMEI2' AND type = 'UQ')
	ALTER TABLE APARELHO
	ADD CONSTRAINT UNIMEI2 UNIQUE (IMEI2)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTAPARELHO')
	DROP PROCEDURE POSTAPARELHO

GO

CREATE PROCEDURE POSTAPARELHO
    @MARCA		VARCHAR(100),
    @MODELO		VARCHAR(100),
    @IMEI1		VARCHAR(100),
    @IMEI2		VARCHAR(100),
    @VALOR		DECIMAL(18,2)
AS
    INSERT APARELHO VALUES 
    (
    @MARCA,
    @MODELO,
    @IMEI1,
    @IMEI2,
    @VALOR
    )

	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTAPARELHO')
	DROP PROCEDURE PUTAPARELHO

GO

CREATE PROCEDURE PUTAPARELHO
    @MARCA		VARCHAR(100),
    @MODELO		VARCHAR(100),
    @IMEI1		VARCHAR(100),
    @IMEI2		VARCHAR(100),
    @VALOR		DECIMAL(18,2),
    @ID         INT
AS
    UPDATE APARELHO SET
    MARCA = @MARCA,
    MODELO = @MODELO,
    IMEI1 = @IMEI1,
    IMEI2 = @IMEI2,
    VALOR = @VALOR
    WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETEAPARELHO')
	DROP PROCEDURE DELETEAPARELHO

GO

CREATE PROCEDURE DELETEAPARELHO
	@ID			INT
AS
    DELETE APARELHO WHERE ID = @ID
    
GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETAPARELHO')
	DROP PROCEDURE GETAPARELHO

GO

CREATE PROCEDURE GETAPARELHO    
AS
    SELECT * FROM APARELHO

GO

/*********************************************************************************************************************/

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE TYPE = 'U' AND NAME = 'CARREGADOR')
	CREATE TABLE CARREGADOR
	(
		ID			INT IDENTITY,
		MARCA		VARCHAR(100),
		NUMSERIE	VARCHAR(100),
		VALOR		DECIMAL(18,2)

		PRIMARY KEY (ID)
	)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTCARREGADOR')
	DROP PROCEDURE POSTCARREGADOR

GO

CREATE PROCEDURE POSTCARREGADOR
--    ID			INT IDENTITY,
    @MARCA		VARCHAR(100),
    @NUMSERIE	VARCHAR(100),
    @VALOR		DECIMAL(18,2)
AS
    INSERT CARREGADOR VALUES
    (
        @MARCA,
        @NUMSERIE,
        @VALOR
    )    

    SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTCARREGADOR')
	DROP PROCEDURE PUTCARREGADOR

GO

CREATE PROCEDURE PUTCARREGADOR
    @MARCA		VARCHAR(100),
    @NUMSERIE	VARCHAR(100),
    @VALOR		DECIMAL(18,2),
    @ID			INT
AS  
    UPDATE CARREGADOR SET    
    MARCA = @MARCA,
    NUMSERIE = @NUMSERIE,
    VALOR = @VALOR
    WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETECARREGADOR')
	DROP PROCEDURE DELETECARREGADOR

GO

CREATE PROCEDURE DELETECARREGADOR
    @ID         INT
AS 
    DELETE CARREGADOR
    WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETCARREGADOR')
	DROP PROCEDURE GETCARREGADOR

GO

CREATE PROCEDURE GETCARREGADOR    
AS
    SELECT * FROM CARREGADOR

/*********************************************************************************************************************/

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE TYPE = 'U' AND NAME = 'GESTOR')
	CREATE TABLE GESTOR
	(
		ID			INT IDENTITY,
		NOME		VARCHAR(500),
		STATUS		INT

		PRIMARY KEY (ID)
	)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTGESTOR')
	DROP PROCEDURE POSTGESTOR

GO

CREATE PROCEDURE POSTGESTOR
	@NOME		VARCHAR(500),
	@STATUS		INT	
AS
	INSERT GESTOR VALUES (@NOME, @STATUS)

	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTGESTOR')
	DROP PROCEDURE PUTGESTOR

GO

CREATE PROCEDURE PUTGESTOR
	@NOME		VARCHAR(500),
	@STATUS		INT,
	@ID			INT
AS
	UPDATE GESTOR SET
	NOME = @NOME,
	STATUS = @STATUS
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETEGESTOR')
	DROP PROCEDURE DELETEGESTOR

GO

CREATE PROCEDURE DELETEGESTOR	
	@ID			INT
AS
	DELETE GESTOR
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETGESTOR')
	DROP PROCEDURE GETGESTOR

GO

CREATE PROCEDURE GETGESTOR	
AS
	SELECT ID, NOME, STATUS, 
	CASE WHEN STATUS = 0 THEN
		'ATIVO'
	ELSE
		'INATIVO'
	END AS STATUSDESCRICAO
	FROM GESTOR
	ORDER BY NOME

/*********************************************************************************************************************/

GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE TYPE = 'U' AND NAME = 'TERMOCELULAR')
	CREATE TABLE TERMOCELULAR
	(
		ID				INT IDENTITY,
		LINHAID			INT,
		APARELHOID		INT,
		CARREGADORID	INT,
		GESTORID		INT,
		FONEOUVIDO		INT,
		DATAENTREGA		SMALLDATETIME,
		DATADEVOLUCAO	SMALLDATETIME,
		LINKENTREGA		VARCHAR(MAX),
		LINKDEVOLUCAO	VARCHAR(MAX)

		PRIMARY KEY (ID),
		CONSTRAINT UNIQUE_LINHA UNIQUE (LINHAID),
		CONSTRAINT UNIQUE_APARELHO UNIQUE (APARELHOID), 
		CONSTRAINT UNIQUE_CARREGADOR UNIQUE (CARREGADORID),
		FOREIGN KEY (LINHAID) REFERENCES LINHA (ID),
		FOREIGN KEY (APARELHOID) REFERENCES APARELHO (ID),
		FOREIGN KEY (CARREGADORID) REFERENCES CARREGADOR (ID),
		FOREIGN KEY (GESTORID) REFERENCES GESTOR (ID)
	)

GO

--ALTER TABLE TERMOCELULAR
--ADD CONSTRAINT UNIQUE_LINHA_APARELHO UNIQUE (LINHAID, APARELHOID)

--ALTER TABLE TERMOCELULAR
--DROP CONSTRAINT UNIQUE_LINHA_APARELHO


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TERMOCELULAR' AND COLUMN_NAME = 'DATADEVOLUCAO')
	ALTER TABLE TERMOCELULAR
	DROP COLUMN DATADEVOLUCAO

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TERMOCELULAR' AND COLUMN_NAME = 'LINKENTREGA')
	ALTER TABLE TERMOCELULAR
	DROP COLUMN LINKENTREGA

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TERMOCELULAR' AND COLUMN_NAME = 'LINKDEVOLUCAO')
	ALTER TABLE TERMOCELULAR
	DROP COLUMN LINKDEVOLUCAO

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTTERMOCELULAR')
	DROP PROCEDURE POSTTERMOCELULAR

GO

CREATE PROCEDURE POSTTERMOCELULAR
    @LINHAID        			INT,
    @APARELHOID     			INT,
    @CARREGADORID       		INT,
    @FONEOUVIDO     			INT,
    @GESTORID       			INT,
    @DATAENTREGA        		SMALLDATETIME
AS
    INSERT TERMOCELULAR (LINHAID, APARELHOID, CARREGADORID, FONEOUVIDO, GESTORID, DATAENTREGA) VALUES (
    @LINHAID,
    @APARELHOID,
    @CARREGADORID,
    @FONEOUVIDO,
    @GESTORID,
    @DATAENTREGA
    )        

	SELECT SCOPE_IDENTITY()

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTTERMOCELULARENTREGA')
	DROP PROCEDURE POSTTERMOCELULARENTREGA

GO

CREATE PROCEDURE POSTTERMOCELULARENTREGA
	@ID				INT,
	@LINKENTREGA	VARCHAR(MAX)
AS
	UPDATE TERMOCELULAR
	SET LINKENTREGA = @LINKENTREGA
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTTERMOCELULARDEVOLUCAO')
	DROP PROCEDURE POSTTERMOCELULARDEVOLUCAO

GO

CREATE PROCEDURE POSTTERMOCELULARDEVOLUCAO
	@ID				INT,
	@LINKDEVOLUCAO	VARCHAR(MAX)
AS
	UPDATE TERMOCELULAR
	SET LINKDEVOLUCAO = @LINKDEVOLUCAO
	WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETETERMOCELULAR')
	DROP PROCEDURE DELETETERMOCELULAR

GO

CREATE PROCEDURE DELETETERMOCELULAR
    @ID			INT
AS 
    DELETE TERMOCELULAR WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETTERMOCELULAR')
	DROP PROCEDURE GETTERMOCELULAR

GO

CREATE PROCEDURE GETTERMOCELULAR
AS
	SELECT C.*, CASE WHEN C.FONEOUVIDO = 0 THEN 'Sim' ELSE 'N�o' END AS FONEOUVIDODESCRICAO, 
	CASE WHEN TCU.DATADEVOLUCAO IS NULL AND TCU.LINKENTREGA IS NULL THEN
		'Ativo Sem Termo Escaneado'
	ELSE CASE WHEN TCU.DATADEVOLUCAO IS NULL AND TCU.LINKENTREGA IS NOT NULL THEN
		'Ativo Com Termo Escaneado'
	ELSE CASE WHEN TCU.DATADEVOLUCAO IS NOT NULL AND TCU.LINKDEVOLUCAO IS NULL THEN
		'Devolvido Sem Termo Escaneado'
	ELSE CASE WHEN TCU.DATADEVOLUCAO IS NOT NULL AND TCU.LINKDEVOLUCAO IS NOT NULL THEN
		'Devolvido Com Termo Escaneado'
	END END END	END AS STATUS
	, L.*, A.*, CA.*, G.*, U.*,
	CASE WHEN DATADEVOLUCAO IS NULL THEN
		'Ativo'
	ELSE
		'Devolvido'
	END AS STATUSTERMO, TCU.*
	FROM TERMOCELULAR C
	LEFT JOIN LINHA L ON L.ID = C.LINHAID
	LEFT JOIN APARELHO A ON A.ID = C.APARELHOID
	LEFT JOIN CARREGADOR CA ON CA.ID = C.CARREGADORID
	LEFT JOIN GESTOR G ON G.ID = C.GESTORID
	LEFT JOIN TERMOCELULARUSUARIO TCU ON TCU.TERMOCELULARID = C.ID
	LEFT JOIN USUARIO U ON U.ID = TCU.USUARIOID
	LEFT JOIN dbo.FNTERMOSTATUS() S ON S.TERMOID = C.ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PUTTERMOCELULAR')
	DROP PROCEDURE PUTTERMOCELULAR

GO

CREATE PROCEDURE PUTTERMOCELULAR
    @ID                         INT,
    @LINHAID        			INT,
    @APARELHOID     			INT,
    @CARREGADORID       		INT,
    @FONEOUVIDO     			INT,
    @GESTORID       			INT,
    @DATAENTREGA        		SMALLDATETIME
    -- @DATADEVOLUCAO        		SMALLDATETIME
AS
    UPDATE TERMOCELULAR SET
    LINHAID = @LINHAID,
    APARELHOID = @APARELHOID,
    CARREGADORID = @CARREGADORID,
    FONEOUVIDO = @FONEOUVIDO,
    GESTORID = @GESTORID,
    DATAENTREGA = @DATAENTREGA
    -- DATADEVOLUCAO = @DATADEVOLUCAO
    WHERE ID = @ID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'RELATORIOTERMOCELULARENTREGA')
	DROP PROCEDURE RELATORIOTERMOCELULARENTREGA

GO

CREATE PROCEDURE RELATORIOTERMOCELULARENTREGA
	@LINHANUMERO	VARCHAR(15)
AS
	SELECT 
	U.NOME AS USUARIONOME, U.CHAPA AS USUARIOMATRICULA, U.CPF AS USUARIOCPF, 
	A.MODELO AS APARELHOMODELO, L.NUMERO AS LINHANUMERO, A.IMEI1 AS APARELHOIMEI1, L.CHIP AS LINHACHIP, A.VALOR AS APARELHOVALOR,
	CA.MARCA AS CARREGADORMARCA, CA.NUMSERIE AS CARREGADORNUMSERIE, CA.VALOR AS CARREGADORVALOR,
	G.NOME AS GESTORNOME, C.FONEOUVIDO, C.DATAENTREGA, TCU.DATADEVOLUCAO, TCU.MOTIVO, C.ID AS TERMNOID
	--C.*, CASE WHEN C.FONEOUVIDO = 0 THEN 'Sim' ELSE 'N�o' END AS FONEOUVIDODESCRICAO, L.*, A.*, CA.*, G.*, U.*
	FROM TERMOCELULAR C
	LEFT JOIN LINHA L ON L.ID = C.LINHAID
	LEFT JOIN APARELHO A ON A.ID = C.APARELHOID
	LEFT JOIN CARREGADOR CA ON CA.ID = C.CARREGADORID
	LEFT JOIN GESTOR G ON G.ID = C.GESTORID
	LEFT JOIN TERMOCELULARUSUARIO TCU ON TCU.TERMOCELULARID = C.ID
	LEFT JOIN USUARIO U ON U.ID = TCU.USUARIOID
	WHERE L.NUMERO = @LINHANUMERO


GO


IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'RELATORIOTERMOCELULARDEVOLUCAO')
	DROP PROCEDURE RELATORIOTERMOCELULARDEVOLUCAO

GO

CREATE PROCEDURE RELATORIOTERMOCELULARDEVOLUCAO
	@LINHANUMERO	VARCHAR(15),
	@USUARIOID		INT
AS
	SELECT 
	U.NOME AS USUARIONOME, U.CHAPA AS USUARIOMATRICULA, U.CPF AS USUARIOCPF, 
	A.MODELO AS APARELHOMODELO, L.NUMERO AS LINHANUMERO, A.IMEI1 AS APARELHOIMEI1, L.CHIP AS LINHACHIP, A.VALOR AS APARELHOVALOR,
	CA.MARCA AS CARREGADORMARCA, CA.NUMSERIE AS CARREGADORNUMSERIE, CA.VALOR AS CARREGADORVALOR,
	G.NOME AS GESTORNOME, C.FONEOUVIDO, C.DATAENTREGA, TCU.DATADEVOLUCAO, TCU.MOTIVO
	--C.*, CASE WHEN C.FONEOUVIDO = 0 THEN 'Sim' ELSE 'N�o' END AS FONEOUVIDODESCRICAO, L.*, A.*, CA.*, G.*, U.*
	FROM TERMOCELULAR C
	LEFT JOIN LINHA L ON L.ID = C.LINHAID
	LEFT JOIN APARELHO A ON A.ID = C.APARELHOID
	LEFT JOIN CARREGADOR CA ON CA.ID = C.CARREGADORID
	LEFT JOIN GESTOR G ON G.ID = C.GESTORID
	LEFT JOIN TERMOCELULARUSUARIO TCU ON TCU.TERMOCELULARID = C.ID
	LEFT JOIN USUARIO U ON U.ID = TCU.USUARIOID
	WHERE L.NUMERO = @LINHANUMERO AND
	U.ID = @USUARIOID

/*******************************************************************************************************************************/


GO


IF NOT EXISTS (SELECT * FROM SYS.objects WHERE TYPE = 'U' AND NAME = 'TERMOCELULARUSUARIO')
	CREATE TABLE TERMOCELULARUSUARIO
	(
		TERMOCELULARID				INT,
		USUARIOID					INT

		PRIMARY KEY (TERMOCELULARID, USUARIOID)
		FOREIGN KEY (TERMOCELULARID) REFERENCES TERMOCELULAR (ID),
		FOREIGN KEY (USUARIOID) REFERENCES USUARIO (ID)
	)

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TERMOCELULARUSUARIO' AND COLUMN_NAME = 'DATADEVOLUCAO')
	ALTER TABLE TERMOCELULARUSUARIO
	ADD DATADEVOLUCAO			SMALLDATETIME

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TERMOCELULARUSUARIO' AND COLUMN_NAME = 'MOTIVO')
	ALTER TABLE TERMOCELULARUSUARIO
	ADD MOTIVO			VARCHAR(MAX)

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TERMOCELULARUSUARIO' AND COLUMN_NAME = 'LINKENTREGA')
	ALTER TABLE TERMOCELULARUSUARIO
	ADD LINKENTREGA			VARCHAR(MAX)

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TERMOCELULARUSUARIO' AND COLUMN_NAME = 'LINKDEVOLUCAO')
	ALTER TABLE TERMOCELULARUSUARIO
	ADD LINKDEVOLUCAO			VARCHAR(MAX)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'POSTTERMOCELULARUSUARIO')
	DROP PROCEDURE POSTTERMOCELULARUSUARIO

GO

CREATE PROCEDURE POSTTERMOCELULARUSUARIO
	@TERMOCELULARID				INT,
	@USUARIOID					INT
AS
	INSERT TERMOCELULARUSUARIO (TERMOCELULARID, USUARIOID) VALUES (@TERMOCELULARID, @USUARIOID)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PATHTERMOCELULARUSUARIO')
	DROP PROCEDURE PATHTERMOCELULARUSUARIO

GO

CREATE PROCEDURE PATHTERMOCELULARUSUARIO
	@TERMOCELULARID				INT,
	@USUARIOID					INT,
	@DATADEVOLUCAO				SMALLDATETIME,
	@MOTIVO						VARCHAR(MAX)
AS
	UPDATE TERMOCELULARUSUARIO
	SET DATADEVOLUCAO = @DATADEVOLUCAO,
	MOTIVO = @MOTIVO
	WHERE TERMOCELULARID = @TERMOCELULARID AND
	USUARIOID = @USUARIOID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PATHTERMOCELULARUSUARIOENTREGA')
	DROP PROCEDURE PATHTERMOCELULARUSUARIOENTREGA

GO

CREATE PROCEDURE PATHTERMOCELULARUSUARIOENTREGA
	@TERMOCELULARID				INT,
	@USUARIOID					INT,
	@LINKENTREGA				VARCHAR(MAX)
AS
	UPDATE TERMOCELULARUSUARIO
	SET LINKENTREGA = @LINKENTREGA
	WHERE TERMOCELULARID = @TERMOCELULARID AND
	USUARIOID = @USUARIOID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'PATHTERMOCELULARUSUARIODEVOLUCAO')
	DROP PROCEDURE PATHTERMOCELULARUSUARIODEVOLUCAO

GO

CREATE PROCEDURE PATHTERMOCELULARUSUARIODEVOLUCAO
	@TERMOCELULARID				INT,
	@USUARIOID					INT,
	@LINKDEVOLUCAO				VARCHAR(MAX)
AS
	UPDATE TERMOCELULARUSUARIO
	SET LINKDEVOLUCAO = @LINKDEVOLUCAO
	WHERE TERMOCELULARID = @TERMOCELULARID AND
	USUARIOID = @USUARIOID

GO


IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETETERMOCELULARUSUARIO')
	DROP PROCEDURE DELETETERMOCELULARUSUARIO

GO

CREATE PROCEDURE DELETETERMOCELULARUSUARIO
	@TERMOCELULARID				INT
AS
	DELETE TERMOCELULARUSUARIO
	WHERE TERMOCELULARID = @TERMOCELULARID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'IF' AND name = 'FNTERMOSTATUS')
	DROP FUNCTION FNTERMOSTATUS

GO

CREATE FUNCTION FNTERMOSTATUS()
RETURNS TABLE
AS
RETURN(
SELECT A.ID AS TERMOID, 
CASE WHEN COUNT(TCU.DATADEVOLUCAO) = 0  THEN
	'Ativo'
ELSE CASE WHEN COUNT(A.ID) = COUNT(TCU.DATADEVOLUCAO) THEN
	'Devolvido Total'
ELSE
	'Devolvido Parcialmente'
END END AS STATUS,
COUNT(A.ID) AS USUARIO, COUNT(TCU.DATADEVOLUCAO) AS DEVOLVIDOS
FROM TERMOCELULAR A
INNER JOIN TERMOCELULARUSUARIO TCU ON A.ID = TCU.TERMOCELULARID
GROUP BY A.ID
)

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETTERMOCELULARDEVOLVIDO')
	DROP PROCEDURE GETTERMOCELULARDEVOLVIDO

GO

CREATE PROCEDURE GETTERMOCELULARDEVOLVIDO
	@APARELHOID			INT,
	@LINHAID			INT
AS
	SELECT * 
	FROM TERMOCELULAR T
	LEFT JOIN DBO.FNTERMOSTATUS() B ON B.TERMOID = T.ID
	LEFT JOIN TERMOCELULARUSUARIO TCU ON TCU.TERMOCELULARID = T.ID
	LEFT JOIN USUARIO U ON U.ID = TCU.USUARIOID
	--LEFT JOIN LINHA L ON L.ID = T.LINHAID
	--LEFT JOIN APARELHO A ON A.ID = T.APARELHOID
	WHERE T.APARELHOID = @APARELHOID AND
	LINHAID = @LINHAID

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'DELETEDETALHEFATURA')
	DROP PROCEDURE DELETEDETALHEFATURA

GO

CREATE PROCEDURE DELETEDETALHEFATURA
	@REFERENCIA	VARCHAR(50)
AS
	DELETE DETALHEFATURA
	WHERE REFERENCIA = @REFERENCIA

GO

IF EXISTS (SELECT * fROM SYS.objects WHERE type = 'P' AND name = 'GETREFERENCIADETALHEFATURA')
	DROP PROCEDURE GETREFERENCIADETALHEFATURA

GO

CREATE PROCEDURE GETREFERENCIADETALHEFATURA
AS
SELECT DISTINCT REFERENCIA
FROM DETALHEFATURA
ORDER BY REFERENCIA






/*

SELECT * FROM DETALHEFATURA

truncate table TERMOCELULARUSUARIO
delete TERMOCELULAR
selecT * from TERMOCELULAR
selecT * from TERMOCELULARUSUARIO


DBCC CHECKIDENT('[TERMOCELULAR]', RESEED, 0)
*/





	--select * from CELULARES
/*

select * from computadores
select * From OCS
GETCOMPUTADORES

select distinct status from COMPUTADORES

SELECT A.name, C.ATIVONOVO, A.id, C.OCSID
FROM OCS A
LEFT JOIN COMPUTADORES C ON C.ATIVONOVO = A.name

select * From usuario


insert Usuario





SELECT B.ID, C.NOME, A.NUMNF, B.QUANTIDADE
FROM NOTAFISCAL A
INNER JOIN LICENCAS B ON A.ID = B.NOTAFISCALID
INNER JOIN SOFTWARE C ON C.ID = B.SOFTWAREID
ORDER BY NUMNF



SELECT C.ATIVONOVO, C.ATIVOANTIGO, C.USUARIO, C.DEPARTAMENTO, C.STATUS, NF.NUMNF, NF.FORNECEDOR, NF.EMPRESA, S.NOME SOFTWARE, NF.LINK, L.QUANTIDADE
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID




--QUANTIDADE DE LICEN�AS UTILIZADAS
SELECT NF.NUMNF, S.NOME, L.QUANTIDADE AS QTDEDISPONIVEL, CONVERT(DECIMAL(18,2), COUNT(*)) AS QTDEUTILIZADA
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID 
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
GROUP BY NF.NUMNF, S.NOME, L.QUANTIDADE











SELECT *
FROM NOTAFISCAL NF
INNER JOIN LICENCAS L ON NF.ID = L.NOTAFISCALID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID


select * From LICENCAS
where id in (201, 202)


SELECT * fROM COMPUTADORESLICENCAS
WHERE LICENCAID = 221



UPDATE LICENCAS
SET STATUS = 'A'

















SELECT C.ATIVONOVO, C.ATIVOANTIGO, C.USUARIO, C.DEPARTAMENTO, C.STATUS, NF.NUMNF, NF.FORNECEDOR, NF.EMPRESA, S.NOME , L.CHAVE, NF.LINK, L.QUANTIDADE, CL.LICENCAID, CL.COMPUTADORESID, L.STATUS STATUSLICENCA, OCS.*
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID
LEFT OUTER JOIN
(
	SELECT * FROM OPENQUERY(MYSQLNEWOCS,'SELECT id, name, ipaddr, osname, userid, winprodid, winprodkey FROM hardware where OSNAME LIKE ''%Win%'' order by id') 
) AS OCS ON OCS.ID = C.OCSID
ORDER BY C.ATIVONOVO

*/