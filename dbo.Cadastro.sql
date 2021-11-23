CREATE TABLE [dbo].[Pessoa] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [nome]     VARCHAR (256) NOT NULL,
    [cpf]      BIGINT        NOT NULL,
    [endereco] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([endereco]) REFERENCES [dbo].[Endereco] ([Id])
);


/*INSERT INTO Pessoa (nome, cpf) VALUES ('Joao', 123123123); 
INSERT INTO Pessoa (endereco) SELECT (Id) FROM Endereco;
INSERT INTO Pessoa_Telefone(id_pessoa, id_telefone) SELECT (Id) FROM Pessoa SELECT (Id) FROM Telefone;
INSERT INTO Endereco (logradouro, numero, cep, bairro, cidade, estado) VALUES ('Rua teste', 2, 123123, 'Bairro teste', 'cidade teste', 'estado teste');
INSERT INTO Telefone (numero, ddd, tipo) VALUES (12312312, 19);
INSERT INTO Telefone (tipo) SELECT (id) FROM Tipo_Telefone;
INSERT INTO Tipo_Telefone(id, tipo) VALUES (122, 'celular');
