-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: doevida
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agendamento` (
  `idAgendamento` int NOT NULL AUTO_INCREMENT,
  `data` date NOT NULL,
  `tipo` enum('REMOTO','PRESENCIAL') NOT NULL,
  `status` enum('AGENDADO','CANCELADO','ATENDIDO') NOT NULL DEFAULT 'AGENDADO',
  `horarioAgendamento` time NOT NULL,
  `descricao` varchar(500) DEFAULT NULL,
  `idPessoa` int NOT NULL,
  `idOrganizacao` int NOT NULL,
  PRIMARY KEY (`idAgendamento`),
  KEY `fk_Agendamento_Pessoa_idx` (`idPessoa`),
  KEY `fk_Agendamento_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_Agendamento_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`),
  CONSTRAINT `fk_Agendamento_Pessoa` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendamento`
--

LOCK TABLES `agendamento` WRITE;
/*!40000 ALTER TABLE `agendamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `agendamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1','DOADOR','DOADOR',NULL),('2','SERVIDOR','SERVIDOR',NULL),('3','MOTORISTA','MOTORISTA',NULL),('4','ADMINISTRADOR','ADMINISTRADOR',NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(767) NOT NULL,
  `RoleId` varchar(767) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('772f2b77-0a88-4476-8781-f68235ebdd6c','idylicaro.se@gmail.com','IDYLICARO.SE@GMAIL.COM','idylicaro.se@gmail.com','IDYLICARO.SE@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEGfcCjGW+xEho2u8z1mjEZ7KNrFi5GTAfLOjQb32WTSrW3NJJS9c7TaZWS7YUEM4WA==','AVQM3ZHRYXCNHDWJLI2SKAKXDXZ44C2C','e10d7ecc-174f-4e46-8691-a0ec63835aac',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(767) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comentario`
--

DROP TABLE IF EXISTS `comentario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comentario` (
  `idComentario` int NOT NULL AUTO_INCREMENT,
  `texto` varchar(200) DEFAULT NULL,
  `data` datetime DEFAULT NULL,
  `idSolicitacao` int NOT NULL,
  `idPessoa` int NOT NULL,
  PRIMARY KEY (`idComentario`),
  KEY `fk_Comentario_Solicitacao1_idx` (`idSolicitacao`),
  KEY `fk_Comentario_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_Comentario_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`),
  CONSTRAINT `fk_Comentario_Solicitacao1` FOREIGN KEY (`idSolicitacao`) REFERENCES `solicitacao` (`idSolicitacao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comentario`
--

LOCK TABLES `comentario` WRITE;
/*!40000 ALTER TABLE `comentario` DISABLE KEYS */;
/*!40000 ALTER TABLE `comentario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item` (
  `idItem` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `tipo` varchar(45) NOT NULL,
  `idOrganizacao` int NOT NULL,
  `quantidade` int NOT NULL,
  `status` enum('DISPONIVEL','INDISPONIVEL') DEFAULT NULL,
  PRIMARY KEY (`idItem`),
  KEY `fk_Item_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_Item_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` VALUES (1,'Pote','Recipiente',253,10,'DISPONIVEL'),(2,'Pote1','Recipiente',253,10,'DISPONIVEL'),(3,'Pote2','Recipiente',253,10,'DISPONIVEL'),(4,'Pote3','Recipiente',253,10,'DISPONIVEL'),(5,'Pote4','Recipiente',253,10,'DISPONIVEL'),(6,'Pote5','Recipiente',253,10,'DISPONIVEL'),(7,'Pote6','Recipiente',253,10,'DISPONIVEL'),(8,'Pote7','Recipiente',253,10,'DISPONIVEL'),(9,'Pote8','Recipiente',253,10,'DISPONIVEL'),(10,'Pote9','Recipiente',253,10,'DISPONIVEL'),(11,'Pote10','Recipiente',253,10,'DISPONIVEL');
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizacao`
--

DROP TABLE IF EXISTS `organizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizacao` (
  `idOrganizacao` int NOT NULL AUTO_INCREMENT,
  `nomeOrganizacao` varchar(45) NOT NULL,
  `cep` varchar(45) NOT NULL,
  `uf` varchar(45) NOT NULL,
  `cidade` varchar(45) NOT NULL,
  `bairro` varchar(45) NOT NULL,
  `logradouro` varchar(45) NOT NULL,
  `complemento` varchar(45) DEFAULT NULL,
  `numeroEndereco` varchar(45) NOT NULL,
  `latitude` varchar(45) NOT NULL,
  `longitude` varchar(45) NOT NULL,
  `cnpj` varchar(15) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=264 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizacao`
--

LOCK TABLES `organizacao` WRITE;
/*!40000 ALTER TABLE `organizacao` DISABLE KEYS */;
INSERT INTO `organizacao` VALUES (252,'UFS ITAAA','49500-000','SE','Itabaiana','Centro','Avenida','Organização','102','100','200','12534548544',NULL),(253,'UFS ITA BR','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854425',NULL),(254,'UFS ITA BR2','49500-000','SE','Itabaiana','Centro','Avenida','Organização','104','100','200','1253454854426',NULL),(255,'UFS ITA BR3','49500-000','SE','Itabaiana','Centro','Avenida','Organização','105','100','200','1253454854427',NULL),(256,'UFS ITA BR4','49500-000','SE','Itabaiana','Centro','Avenida','Organização','106','100','200','1253454854428',NULL),(257,'UFS ITA BR5','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854429',NULL),(258,'UFS ITA BR6','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854415',NULL),(259,'UFS ITA BR7','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854435',NULL),(260,'UFS ITA BR8','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854445',NULL),(261,'UFS ITA BR9','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854455',NULL),(262,'UFS ITA BR10','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854465',NULL),(263,'UFS ITA BR11','49500-000','SE','Itabaiana','Centro','Avenida','Organização','103','100','200','1253454854475',NULL);
/*!40000 ALTER TABLE `organizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `idPessoa` int NOT NULL AUTO_INCREMENT,
  `email` varchar(100) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `cpf` varchar(11) NOT NULL,
  `dataNascimento` date NOT NULL,
  `status` enum('ATIVO','INATIVO') NOT NULL DEFAULT 'ATIVO',
  `tipo` enum('SERVIDOR','DOADOR','MOTORISTA') NOT NULL,
  `latitude` varchar(45) DEFAULT NULL,
  `longitude` varchar(45) DEFAULT NULL,
  `cep` varchar(9) NOT NULL,
  `logradouro` varchar(100) NOT NULL,
  `numeroEndereco` varchar(45) NOT NULL,
  `bairro` varchar(45) NOT NULL,
  `complemento` varchar(100) DEFAULT NULL,
  `uf` varchar(2) NOT NULL,
  `cidade` varchar(45) NOT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `idUser` varchar(767) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`idPessoa`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  UNIQUE KEY `idUser_UNIQUE` (`idUser`),
  KEY `fk_pessoa_apsnetusers_idx` (`idUser`),
  CONSTRAINT `fk_pessoa_aspnetuser` FOREIGN KEY (`idUser`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (10,'idylicaro.se@gmail.com','Idyl Icaro dos Santos','07504975567','2000-12-22','ATIVO','DOADOR',NULL,NULL,'49500329','Rua Francisco Bragança','1034','São Cristóvão','Casa','SE','Itabaiana','(79) 99963-2212','772f2b77-0a88-4476-8781-f68235ebdd6c');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoaorganizacao`
--

DROP TABLE IF EXISTS `pessoaorganizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoaorganizacao` (
  `idPessoaOrganizacao` int NOT NULL AUTO_INCREMENT,
  `idPessoa` int DEFAULT NULL,
  `idOrganizacao` int DEFAULT NULL,
  PRIMARY KEY (`idPessoaOrganizacao`),
  KEY `fk_idPessoa_idx` (`idPessoa`),
  KEY `fk_organizacao_idx` (`idOrganizacao`),
  CONSTRAINT `fk_idPessoa` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`),
  CONSTRAINT `fk_organizacao` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoaorganizacao`
--

LOCK TABLES `pessoaorganizacao` WRITE;
/*!40000 ALTER TABLE `pessoaorganizacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `pessoaorganizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitacao`
--

DROP TABLE IF EXISTS `solicitacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitacao` (
  `idSolicitacao` int NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT NULL,
  `status` enum('PROBLEMA NA ENTREGA','SOLICITADO','RECUSADO','APROVADO') NOT NULL,
  `idPessoa` int NOT NULL,
  `idOrganizacao` int NOT NULL,
  `quantidade` int NOT NULL,
  PRIMARY KEY (`idSolicitacao`),
  KEY `fk_Solicitacao_Pessoa1_idx` (`idPessoa`),
  KEY `fk_Solicitacao_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_Solicitacao_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`),
  CONSTRAINT `fk_Solicitacao_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitacao`
--

LOCK TABLES `solicitacao` WRITE;
/*!40000 ALTER TABLE `solicitacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitacaoitem`
--

DROP TABLE IF EXISTS `solicitacaoitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitacaoitem` (
  `idSolicitacaoItem` int NOT NULL,
  `idSolicitacao` int NOT NULL,
  `idItem` int NOT NULL,
  PRIMARY KEY (`idItem`,`idSolicitacao`),
  KEY `fk_SolicitacaoItem_Solicitacao1_idx` (`idSolicitacao`),
  KEY `fk_SolicitacaoItem_Item1_idx` (`idItem`),
  CONSTRAINT `fk_SolicitacaoItem_Item1` FOREIGN KEY (`idItem`) REFERENCES `item` (`idItem`),
  CONSTRAINT `fk_SolicitacaoItem_Solicitacao1` FOREIGN KEY (`idSolicitacao`) REFERENCES `solicitacao` (`idSolicitacao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitacaoitem`
--

LOCK TABLES `solicitacaoitem` WRITE;
/*!40000 ALTER TABLE `solicitacaoitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitacaoitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vagashorarios`
--

DROP TABLE IF EXISTS `vagashorarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vagashorarios` (
  `idVagasHorarios` int NOT NULL AUTO_INCREMENT,
  `diaSemana` enum('SEGUNDA-FEIRA','TERÇA-FEIRA','QUARTA-FEIRA','QUINTA-FEIRA','SEXTA-FEIRA','SABADO','DOMINGO') DEFAULT NULL,
  `horaInicio` time DEFAULT NULL,
  `horaFinal` time DEFAULT NULL,
  `numeroVagas` int DEFAULT NULL,
  `idOrganizacao` int NOT NULL,
  PRIMARY KEY (`idVagasHorarios`),
  KEY `fk_VagasHorarios_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_VagasHorarios_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vagashorarios`
--

LOCK TABLES `vagashorarios` WRITE;
/*!40000 ALTER TABLE `vagashorarios` DISABLE KEYS */;
INSERT INTO `vagashorarios` VALUES (1,'SEGUNDA-FEIRA','12:00:00','15:00:00',10,253),(2,'SEGUNDA-FEIRA','12:00:00','15:00:00',10,253),(3,'SEGUNDA-FEIRA','12:00:00','15:00:00',1,253),(4,'SEGUNDA-FEIRA','12:00:00','15:00:00',1,253),(5,'SEGUNDA-FEIRA','12:00:00','15:00:00',1,253),(6,'SEGUNDA-FEIRA','12:00:00','15:00:00',1,253),(7,'SEGUNDA-FEIRA','12:00:00','15:00:00',1,253),(8,'SEGUNDA-FEIRA','12:00:00','15:00:00',1,253),(9,'SEGUNDA-FEIRA','12:00:00','15:00:00',1,253),(10,'SEGUNDA-FEIRA','12:00:00','15:00:00',12,253),(11,'SEGUNDA-FEIRA','12:00:00','15:00:00',12,253);
/*!40000 ALTER TABLE `vagashorarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-11  9:57:22
