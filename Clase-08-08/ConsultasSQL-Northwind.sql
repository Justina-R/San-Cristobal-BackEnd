-- EJERCICIOS DE CONSULTAS: NORTHWIND
USE Northwind;

/*Ejercicio 1:
Mostrar los clientes ordenados alfabéticamente por el nombre de la compañía.*/
SELECT * FROM Customers c
ORDER BY c.CompanyName; 

/*Ejercicio 2:
Mostrar todos los clientes que su nombre empieza con “s”.*/
SELECT * FROM Customers c
WHERE c.ContactName LIKE 's%';

/*Ejercicio 3:
Encontrar todos los productos cuyo precio unitario sea mayor de 50.*/
SELECT * FROM Products p
WHERE p.UnitPrice > 50;

/*Ejercicio 4:
Obtener cuántos productos “Discontinued” hay.*/
SELECT * FROM Products p
WHERE p.Discontinued = 1;

/*Ejercicio 5:
Obtener el producto de mayor valor unitario.*/
SELECT TOP 1 * FROM Products
ORDER BY UnitPrice DESC;

/*Ejercicio 6:
Obtener el producto de mayor valor unitario y el nombre del producto: (subquery).*/
SELECT * FROM Products p
WHERE p.UnitPrice = ( SELECT MAX(p2.UnitPrice) FROM Products p2 );

/*Ejercicio 7:
Obtener una lista de todos los productos con su respectivo nombre de categoría. INNER JOIN.*/
SELECT p.ProductName, c.CategoryName FROM Products p
INNER JOIN Categories c ON c.CategoryID = p.CategoryID;

/*Ejercicio 8:
Obtener todos los clientes junto con los detalles de los pedidos que han realizado. Si un cliente no ha realizado ningún pedido,
aún debe aparecer en el resultado con los detalles del pedido como NULL. LEFT JOIN*/
SELECT c.CustomerID, c.CompanyName, c.ContactName, od.* FROM Customers c 
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID;

/*Ejercicio 9:
Encontrar el número total de órdenes realizadas por cada cliente.*/
SELECT c.CustomerID, c.CompanyName, COUNT(o.OrderID) AS CantOrdenes
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CompanyName;

/*Ejercicio 10:
Encontrar los proveedores que han suministrado más de 3 productos. Primero, agrupamos los productos por proveedor
y contamos el número de productos suministrados por cada proveedor. Luego, usamos HAVING para filtrar solo
aquellos proveedores que han suministrado más de 3 productos.*/
SELECT s.SupplierID, s.CompanyName, COUNT(*) AS CantProductos FROM Suppliers s
INNER JOIN Products p ON s.SupplierID =p.SupplierID
GROUP BY s.SupplierID, s.CompanyName
HAVING COUNT(*) > 3;

/*Ejercicio 11:
Realizar un procedimiento almacenado que devuelva los clientes (Customers) según el país (Country).*/
-- Creación del procedimiento
GO
CREATE PROCEDURE ClientesPorPais
         @Country NVARCHAR(15)
 AS
    BEGIN
    SELECT CustomerID, CompanyName, ContactName, Country
    FROM Customers c
    WHERE c.Country = @Country;
END;

-- Ejemplo de ejecución del procedimiento
GO

EXEC ClientesPorPais 'Germany';
