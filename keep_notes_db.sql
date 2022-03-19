CREATE DATABASE keep_notes;
USE keep_notes;
CREATE TABLE cities(
id INT(11) PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(30) NOT NULL
);
CREATE TABLE age_groups
(
id INT(11) PRIMARY KEY AUTO_INCREMENT,
age ENUM('7-12','13-18','19-30','31-50','51-70','70+') 
);
CREATE TABLE users(
id INT(11) PRIMARY KEY AUTO_INCREMENT,
username VARCHAR(25) NOT NULL UNIQUE ,
password VARCHAR(100) NOT NULL ,
city_id INT(11) NOT NULL,
CONSTRAINT FK_city_user FOREIGN KEY (city_id)
    REFERENCES cities(id),
    age_group_id INT(11) ,
    CONSTRAINT FK_age_group_user FOREIGN KEY (age_group_id)
    REFERENCES age_groups(id)    
);

CREATE TABLE notes
(
Id INT(111) PRIMARY KEY,    
title VARCHAR(33),
creation_date DATETIME DEFAULT NOW(),
latest_change DATETIME NOT NULL,
note TEXT NOT NULL,
private BOOLEAN DEFAULT FALSE,
password VARCHAR(100) DEFAULT NULL,
keywords ENUM ('Cooking','Studying','Articles','Books','Other') DEFAULT 'Other',
color VARCHAR(10) DEFAULT "#FFFFFF",
user_id int(11) ,
  CONSTRAINT FK_user_note FOREIGN KEY (user_id)
    REFERENCES users(id)
);

INSERT INTO age_groups(age)
VALUES ('7-12'),('13-18'),('19-30'),('31-50'),('51-70'),('70+');

ALTER TABLE `cities` AUTO_INCREMENT=0;
ALTER TABLE `users` AUTO_INCREMENT=0;
ALTER TABLE `users` MODIFY COLUMN `username` VARCHAR(50);

