SQl para las preguntas de la tabla TASK
- Crear la tabla Tasks
CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    IsCompleted BIT NOT NULL DEFAULT 0
);

-- Insertar 3 tareas de ejemplo
INSERT INTO Tasks (Title, IsCompleted) VALUES
('Lavar la ropa', 0),
('Tender la ropa', 0),
('Recoger la ropa', 1);
