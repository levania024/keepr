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

DROP Table `keeps`

ALTER Table vaults MODIFY isPrivate BOOLEAN NOT NULL DEFAULT false;

INSERT INTO
    vaultKeeps (vaultId, keepId, creatorId)
VALUES (@VaultId, @KeepId, @creatorId);

SELECT keeps.*, Count(vaultKeeps.keepId) AS kept, accounts.*
FROM
    keeps
    JOIN accounts ON keeps.creatorId = accounts.id
    LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
WHERE
    vaultKeeps.id = LAST_INSERT_ID();

GROUP BY keeps.id

SELECT vaultKeeps.*, accounts.*
FROM vaultKeeps
    JOIN accounts ON vaultKeeps.creatorId = accounts.id
WHERE
    vaultKeeps.id = LAST_INSERT_ID()

SELECT vaultKeeps.*, Count(vaultKeeps.keepId) AS kept, accounts.*
FROM vaultKeeps
    JOIN accounts ON vaultKeeps.creatorId = accounts.id
WHERE
    vaultKeeps.id = LAST_INSERT_ID()
Group By
    vaultKeeps.id

UPDATE keeps SET kept = kept + 1 WHERE keeps.id = @keepId;

SELECT keeps.*, vaultKeeps.*, accounts.*
FROM
    vaultKeeps
    Join keeps ON keeps.id = vaultKeeps.keepId
    Join accounts ON keeps.creatorId = accounts.id;

SELECT keeps.*, COUNT(vaultKeeps.keepId) AS kept, accounts.*
FROM
    keeps
    JOIN accounts on accounts.id = keeps.creatorId
    LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
WHERE
    keeps.id = @keepId
GROUP BY
    keeps.id;