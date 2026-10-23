-- Используем базу данных
USE Orders;

-- Создание таблицы Product
CREATE TABLE IF NOT EXISTS Orders (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CreationDate DATE NOT NULL,
    IsDelivered BOOL NOT NULL
);

-- Начальные данные
INSERT INTO Orders (Name, Price, CreationDate, IsDelivered) VALUES
('Пироги', 101.20, '2026-09-15', FALSE),
('Шишки', 100.80, '2026-10-15', TRUE),
('Столы', 121.50, '2026-08-25', TRUE),
('Шашки', 312.30, '2026-07-05', FALSE),
('Мышки', 81.10, '2026-06-15', TRUE);
