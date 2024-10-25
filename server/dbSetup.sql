CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

ALTER Table accounts add coverImg TEXT NOT NULL

CREATE Table keeps (
    id int PRIMARY key AUTO_INCREMENT NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    img TEXT NOT NULL,
    views int NOT NULL DEFAULT 0,
    creatorId VARCHAR(255) NOT NULL,
    Foreign Key (creatorId) REFERENCES accounts (id) on delete CASCADE
);

CREATE TABLE vaults(
   id int PRIMARY key AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  description TEXT NOT NULL,
  img TEXT NOT NULL,
  isPrivate BOOLEAN NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (creatorId) REFERENCES  accounts (id) on delete CASCADE
);


INSERT INTO
    keeps (
        name,
        description,
        img,
        creatorId
    )
VALUES (
        @name,
        @description,
        @creatorId
    )

SELECT accounts.* keeps.*,
FROM keeps
    JOIN accounts on keeps.`creatorId` = accounts.id

UPDATE keeps SET views = views + 1 WHERE keeps.id = @keepId;

SELECT *
FROM keeps
    JOIN accounts on accounts.id = keeps.`creatorId`
WHERE
    keepId = @keepId

UPDATE keeps SET(
    name = @name,
    description = @description
)
WHERE
    id = @keepId
LIMIT 1

DELETE FROM keeps WHERE id = @keepId LIMIT 1