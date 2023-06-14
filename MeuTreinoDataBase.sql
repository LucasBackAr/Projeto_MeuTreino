Create database MeuTreino

-- Cria��o da tabela de Usu�rios
CREATE TABLE Usuarios (
    ID INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Senha VARCHAR(100) NOT NULL,
    DataNascimento DATE NOT NULL,
    Genero VARCHAR(50) NOT NULL,
    
);

-- Cria��o da tabela de Perfis
CREATE TABLE Perfis (
    ID INT PRIMARY KEY IDENTITY,
    UsuarioID INT FOREIGN KEY REFERENCES Usuarios(ID),
    NivelCondicionamento VARCHAR(50) NOT NULL,
    Objetivos VARCHAR(100) NOT NULL,
    RestricoesMedicas VARCHAR(MAX),
    
);

-- Cria��o da tabela de Exerc�cios
CREATE TABLE Exercicios (
    ID INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(100) NOT NULL,
    Descricao VARCHAR(MAX) NOT NULL,
    GrupoMuscular VARCHAR(50) NOT NULL,
    Instrucoes VARCHAR(MAX) NOT NULL,
    NivelDificuldade VARCHAR(50) NOT NULL,
    Equipamentos VARCHAR(MAX),
   
);

-- Cria��o da tabela de Planos de Treino
CREATE TABLE PlanosTreino (
    ID INT PRIMARY KEY IDENTITY,
    UsuarioID INT FOREIGN KEY REFERENCES Usuarios(ID),
    NomePlano VARCHAR(100) NOT NULL,
   
);

-- Cria��o da tabela de ExerciciosPlano
CREATE TABLE ExerciciosPlano (
    PlanoID INT FOREIGN KEY REFERENCES PlanosTreino(ID),
    ExercicioID INT FOREIGN KEY REFERENCES Exercicios(ID),
    Repeticoes INT NOT NULL,
    Series INT NOT NULL,    
);

-- Cria��o da tabela de Favoritos
CREATE TABLE Favoritos (
    UsuarioID INT FOREIGN KEY REFERENCES Usuarios(ID),
    ExercicioID INT FOREIGN KEY REFERENCES Exercicios(ID),
    
);

-- Cria��o da tabela de Progresso
CREATE TABLE Progresso (
    UsuarioID INT FOREIGN KEY REFERENCES Usuarios(ID),
    Peso DECIMAL(5,2),
    MedidasCorporais VARCHAR(MAX),    
);

-- Cria��o da tabela de Feedback
CREATE TABLE Feedback (
    UsuarioID INT FOREIGN KEY REFERENCES Usuarios(ID),
    Comentario VARCHAR(MAX),
    Avaliacao INT,   
);
