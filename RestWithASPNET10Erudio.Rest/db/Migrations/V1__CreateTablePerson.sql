CREATE TABLE person
(
    id         BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(80) NOT NULL,
    last_name  VARCHAR(80) NOT NULL,
    address    VARCHAR(80) NOT NULL,
    gender     VARCHAR(80) NOT NULL
);

