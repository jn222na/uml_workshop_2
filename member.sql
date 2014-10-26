-- phpMyAdmin SQL Dump
-- version 4.1.4
-- http://www.phpmyadmin.net
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 26 okt 2014 kl 22:16
-- Serverversion: 5.6.15-log
-- PHP-version: 5.5.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Databas: `member`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `boats`
--

CREATE TABLE IF NOT EXISTS `boats` (
  `boatId` int(11) NOT NULL AUTO_INCREMENT,
  `noBoats` varchar(20) NOT NULL,
  `boatType` varchar(20) NOT NULL,
  `boatLength` varchar(20) NOT NULL,
  PRIMARY KEY (`boatId`),
  KEY `noBoats` (`noBoats`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=52 ;

--
-- Dumpning av Data i tabell `boats`
--

INSERT INTO `boats` (`boatId`, `noBoats`, `boatType`, `boatLength`) VALUES
(50, '3', 'motor', '1200'),
(51, '1', 'morot', '1500');

-- --------------------------------------------------------

--
-- Tabellstruktur `medlem`
--

CREATE TABLE IF NOT EXISTS `medlem` (
  `nameId` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(15) NOT NULL,
  `lastname` varchar(15) NOT NULL,
  `socialNumber` varchar(10) NOT NULL,
  PRIMARY KEY (`nameId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=52 ;

--
-- Dumpning av Data i tabell `medlem`
--

INSERT INTO `medlem` (`nameId`, `firstname`, `lastname`, `socialNumber`) VALUES
(50, 'joakim', 'nilsson', '000000000'),
(51, 'tjosan', 'trosan', '000000000');

--
-- Restriktioner för dumpade tabeller
--

--
-- Restriktioner för tabell `boats`
--
ALTER TABLE `boats`
  ADD CONSTRAINT `boats_ibfk_1` FOREIGN KEY (`boatId`) REFERENCES `medlem` (`nameId`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
