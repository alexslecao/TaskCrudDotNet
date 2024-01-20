USE [master]
GO

/****** Object:  Database [AXS]    Script Date: 19/01/2024 15:57:19 ******/
CREATE DATABASE [AXS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AXS', FILENAME = N'D:\teste\TaskCrudDotNet\database\db\AXS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AXS_log', FILENAME = N'D:\teste\TaskCrudDotNet\database\db\AXS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AXS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AXS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AXS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AXS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AXS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AXS] SET ARITHABORT OFF 
GO

ALTER DATABASE [AXS] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AXS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AXS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AXS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AXS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AXS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AXS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AXS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AXS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AXS] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AXS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AXS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AXS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AXS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AXS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AXS] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AXS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AXS] SET RECOVERY FULL 
GO

ALTER DATABASE [AXS] SET  MULTI_USER 
GO

ALTER DATABASE [AXS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AXS] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AXS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [AXS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [AXS] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [AXS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [AXS] SET QUERY_STORE = OFF
GO

ALTER DATABASE [AXS] SET  READ_WRITE 
GO


