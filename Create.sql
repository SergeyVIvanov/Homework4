DROP DATABASE IF EXISTS "SVI_Db4" (FORCE);
CREATE DATABASE "SVI_Db4";
\c "SVI_Db4";

--
-- customers
--
CREATE SEQUENCE customers_id_seq;

CREATE TABLE customers
(
    id                BIGINT        NOT NULL  DEFAULT NEXTVAL('customers_id_seq'),
    first_name        VARCHAR(255)  NOT NULL,
    last_name         VARCHAR(255)  NOT NULL,
  
    CONSTRAINT customers_pk PRIMARY KEY (id)
);
