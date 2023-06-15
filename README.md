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
--Таблица продуктов с непустыми именами
CREATE TABLE Products (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Name nvarchar(max) NOT NULL,
);
INSERT INTO Products (Name)
VALUES
(N'Ноутбук'),
(N'Мышь'),
(N'Монитор'),
(N'Колонки'),
(N'Фольга алюминиевая 2.5мм');
--Таблица категорий с непустыми именами
CREATE TABLE Categories (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Name nvarchar(max) NOT NULL
);
INSERT INTO Categories (Name)
VALUES
(N'Компьютеры'),
(N'Аксессуары'),
(N'Периферия');
--Таблица связей продуктов и категорий
CREATE TABLE ProductCategories (
  Id int IDENTITY(1,1) PRIMARY KEY,
  ProductId int NOT NULL,
  CategoryId int NULL,
  FOREIGN KEY (ProductId) REFERENCES Products(Id),
  FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
INSERT INTO ProductCategories (ProductId, CategoryId)
VALUES 
(1, 1),
(2, 3), 
(3, 3),
(4, 3),
(4, 2),
(5, Null);
```
```
--Запрос выбирающий все пары продукт-категория.
SELECT p.Name as N'Имя продукта', COALESCE(c.Name, N'Без категории') as N'Имя категории'
FROM Products p
LEFT JOIN ProductCategories pc ON p.Id = pc.ProductId
LEFT JOIN Categories c ON pc.CategoryId = c.Id;
```
![Вывод запроса](https://github.com/arturmarkovv/GeometryLib/assets/34218775/38983305-be14-4f08-ae06-d456298aa6ca)
