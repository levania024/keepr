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

CREATE TABLE vaults (
    id int PRIMARY key AUTO_INCREMENT NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    img TEXT NOT NULL,
    isPrivate BOOLEAN NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    Foreign Key (creatorId) REFERENCES accounts (id) on delete CASCADE
);

CREATE Table vaultKeeps (
    id int PRIMARY key AUTO_INCREMENT NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    keepId INT NOT NULL,
    vaultId int not NULL,
    creatorId VARCHAR(255) NOT NULL,
    Foreign Key (keepId) REFERENCES keeps (id) on delete CASCADE,
    Foreign Key (vaultId) REFERENCES vaults (id) on delete CASCADE,
    Foreign Key (creatorId) REFERENCES accounts (id) on delete CASCADE
);

ALTER Table vaults MODIFY isPrivate BOOLEAN DEFAULT false;

INSERT INTO
vaultKeeps ( vaultId, keepId)
VALUES ( @vaultId, @keepId, );

SELECT 
vaults.*,
vaultKeeps.*,
accounts.*
FROM vaults
JOIN vaultKeeps ON vaultKeeps.vaultId = vaults.id
JOIN accounts ON vaults.creatorId = accounts.id;

UPDATE keeps SET views = views + 1 WHERE keeps.id = @keepId;

SELECT *
FROM vaults
    JOIN accounts on accounts.id = vaults.creatorId
WHERE
    vaults.id = @vaultId

UPDATE vaults SET(
    name = @name,
    description = @isPrivate
)
WHERE
    id = @keepId
LIMIT 1

DELETE FROM vaultKeeps WHERE id = @vaultkeepId LIMIT 1

SELECT accounts.* FROM accounts WHERE accounts.id = id