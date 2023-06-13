# GeometryLib
Библиотека для расчета площадей фигур
## Юнит-тесты
Собраны в проекте `Geometry.UnitTests`, разделены на классы по типу фигуры
## Легкость добавления новых фигур
Реализована при помощи струкртуры файлов проекта и реализованнного абстрактного класса `Figure`, являющегося гарантом наличия свойства `Figure.Area` для новых фигур наследников.
(Пример приведен в `TestFixture` — `CustomFigureTests`)
## Вычисление площади фигуры без знания типа фигуры в compile-time
Реализуется так же посредством использования абстракного класса `Figure`
Все наследуемые от него фигуры гарантированно иметь свойство хранящее площадь:
```
public class Square : Figure
{
  ...
  public override double Area { get; }
  ...
}
...
var square = new Square(2);
return square.Area; 
```
## Проверка на то, является ли треугольник прямоугольным
Добалвлена в класс `Triangle`: проверяется методом `CheckIsRight()` 

# SQL-запрос
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
```
--Генерация схемы БД.

CREATE TABLE Products (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Name nvarchar(50) NOT NULL,
  CategoryId int NULL,
  Price money NOT NULL
);
INSERT INTO Products (Name, CategoryId, Price)
VALUES
(N'Ноутбук', 1, 50000),
(N'Мышь', 2, 500),
(N'Клавиатура', 2, 1000),
(N'Монитор', 3, 15000),
(N'Колонки', 3, 3000),
(N'Телефон', NULL, 20000);
CREATE TABLE Categories (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Name nvarchar(50) NOT NULL
);
INSERT INTO Categories (Name)
VALUES
(N'Компьютеры'),
(N'Аксессуары'),
(N'Периферия');

--Запрос выбирающий все пары продукт-категория.

SELECT p.Name AS ProductName, COALESCE(c.Name, N'Без категории') AS CategoryName
FROM Products p
LEFT JOIN Categories c ON p.CategoryId = c.Id
ORDER BY ProductName, CategoryName;
