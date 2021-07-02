TestProjectSmartway
Запросы:

Добавить сотрудника (используется DepartmentId из таблицы department): Home/Add { "Name": "Сергей", "Surname": "Сергеев", "Phone": "895663464", "CompanyId": 2, "Passport": { "type": "P", "number": "456464564" }, "DepartmentId": 18 }

Редактировать: Home/Edit { "Id" : 4, "Name": "Сергей", "Passport": { "type": "P", "number": "456464564" }, "DepartmentId": 18 }

Удалить: Home/Delete { "id" : 4}

Список сотрудников по компании: Home/ByCompany { "id" : 2 }

Список сотрудников по отделу: Home/ByDepartment { "id" : 2 }

DepartmentId Name Phone 15 Отдел продаж 899999999 16 Отдел продаж 899999999 17 Отдел распродаж 899999999 18 Отдел кадров 899999999 19 Отдел скидок 899999999 20 Отдел разработки 899999999 21 Отдел аналитики 899999999
