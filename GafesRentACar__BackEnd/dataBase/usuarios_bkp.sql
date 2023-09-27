-- Table: public.usuarios

-- DROP TABLE IF EXISTS public.usuarios;

CREATE TABLE IF NOT EXISTS public.usuarios
(
    id bigint NOT NULL DEFAULT nextval('usuarios_id_seq'::regclass),
    email_acesso character varying(200) COLLATE pg_catalog."default" NOT NULL,
    senha character varying(100) COLLATE pg_catalog."default" NOT NULL,
    ativo boolean NOT NULL,
    nome_completo character varying(300) COLLATE pg_catalog."default",
    cpf character varying(11) COLLATE pg_catalog."default",
    CONSTRAINT usuarios_pkey PRIMARY KEY (id),
    CONSTRAINT un_email_acesso UNIQUE (email_acesso)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.usuarios
    OWNER to postgres;

-- Table: public.reservas

-- DROP TABLE IF EXISTS public.reservas;

CREATE TABLE IF NOT EXISTS public.reservas
(
    id bigint NOT NULL DEFAULT nextval('reservas_id_seq'::regclass),
    id_carro character varying(100) COLLATE pg_catalog."default" NOT NULL,
    id_usuario bigint,
    ativa boolean,
    CONSTRAINT reservas_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.reservas
    OWNER to postgres;