USE PrestamosDB;
GO

DROP TABLE IF EXISTS Pagos;
GO

CREATE TABLE Pagos (
    PagoId INT IDENTITY(1,1) PRIMARY KEY,
    PrestamoId INT NOT NULL,
    NumeroCuota INT NOT NULL,
    FechaPago DATETIME NOT NULL,
    MontoAnterior DECIMAL(18,2) NOT NULL,
    InteresPagado DECIMAL(18,2) NOT NULL,
    CapitalPagado DECIMAL(18,2) NOT NULL,
    Cuota DECIMAL(18,2) NOT NULL,
    Mora DECIMAL(18,2) NOT NULL DEFAULT 0,
    NuevoMontoDeuda DECIMAL(18,2) NOT NULL,
    MesesRestantes INT NOT NULL,
    TotalInteresesAcumulados DECIMAL(18,2) NOT NULL,
    TasaPrestamo DECIMAL(10,2) NOT NULL,
    FuePagado BIT NOT NULL,

    CONSTRAINT FK_Pagos_Prestamos
    FOREIGN KEY (PrestamoId)
    REFERENCES Prestamos(PrestamoId)
);
GO

SELECT * FROM Prestamos;



CREATE DATABASE PrestamosDB;
GO

USE PrestamosDB;
GO

CREATE TABLE Clientes (
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto VARCHAR(150) NOT NULL,
    Correo VARCHAR(120),
    Telefono VARCHAR(30),
    Direccion VARCHAR(200),
    Garantia VARCHAR(150) NOT NULL,
    Sueldo DECIMAL(18,2) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE FondoEmpresa (
    FondoEmpresaId INT IDENTITY(1,1) PRIMARY KEY,
    MontoDisponible DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE Prestamos (
    PrestamoId INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    MontoPrestado DECIMAL(18,2) NOT NULL,
    TasaInteresAnual DECIMAL(10,4) NOT NULL,
    Meses INT NOT NULL,
    InteresGenerado DECIMAL(18,2) NOT NULL,
    MontoTotal DECIMAL(18,2) NOT NULL,
    CuotaMensual DECIMAL(18,2) NOT NULL,
    SaldoPendiente DECIMAL(18,2) NOT NULL,
    FechaPrestamo DATETIME NOT NULL DEFAULT GETDATE(),
    Estado VARCHAR(30) NOT NULL DEFAULT 'ACTIVO',
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId)
);
GO

CREATE TABLE Pagos (
    PagoId INT IDENTITY(1,1) PRIMARY KEY,
    PrestamoId INT NOT NULL,
    NumeroCuota INT NOT NULL,
    FechaPago DATETIME NULL,
    MontoAnterior DECIMAL(18,2) NOT NULL,
    InteresPagado DECIMAL(18,2) NOT NULL,
    CapitalPagado DECIMAL(18,2) NOT NULL,
    Cuota DECIMAL(18,2) NOT NULL,
    Mora DECIMAL(18,2) NOT NULL DEFAULT 0,
    NuevoMontoDeuda DECIMAL(18,2) NOT NULL,
    MesesRestantes INT NOT NULL,
    TotalInteresesAcumulados DECIMAL(18,2) NOT NULL,
    TasaPrestamo DECIMAL(10,4) NOT NULL,
    FuePagado BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (PrestamoId) REFERENCES Prestamos(PrestamoId)
);
GO

INSERT INTO FondoEmpresa (MontoDisponible)
VALUES (10000000.00);
GO

INSERT INTO Clientes (NombreCompleto, Correo, Telefono, Direccion, Garantia, SueldoMensual)
VALUES
('Juan Pérez', 'juan@gmail.com', '809-111-1111', 'Santo Domingo', 'Motor', 25000),
('Ana Rodríguez', 'ana@gmail.com', '809-222-2222', 'Santo Domingo Oeste', 'Televisor', 30000),
('Luis Gómez', 'luis@gmail.com', '809-333-3333', 'Herrera', 'Nevera', 28000),
('Carlos Díaz', 'carlos@gmail.com', '809-444-4444', 'Los Alcarrizos', 'Laptop', 22000),
('Marta López', 'marta@gmail.com', '809-555-5555', 'Villa Mella', 'Solar', 40000),
('Pedro Sánchez', 'pedro@gmail.com', '809-666-6666', 'San Cristóbal', 'Carro', 45000);

INSERT INTO Prestamos (
    ClienteId,
    Capital,
    PlazoMeses,
    TasaAnual,
    Cuota,
    FechaInicio,
    Estado,
    SaldoPendiente
)
VALUES (
    4,
    100000,
    12,
    10,
    9000,
    GETDATE(),
    'ACTIVO',
    100000
);

