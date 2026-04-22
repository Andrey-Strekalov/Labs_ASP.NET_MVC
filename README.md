# 🛒 Labs ASP.NET MVC (Entity Framework Core)

Учебный ASP.NET MVC проект, представляющий собой упрощённый интернет-магазин с использованием Entity Framework Core, миграций и паттерна репозитория.

---

## 🎯 Цель проекта

Проект создан для освоения следующих технологий и подходов:

- подключение Entity Framework Core к ASP.NET MVC
- использование подхода Code-First
- работа с миграциями базы данных
- переход от InMemory-репозитория к работе с SQL Server
- реализация Repository Pattern

---

## 🚀 Возможности проекта

- Управление товарами (Product / Game)
- Добавление новых записей в базу данных
- Редактирование существующих записей
- Удаление записей
- Отображение списка товаров
- Автоматическое заполнение базы тестовыми данными (Seed)

---

## 🛠 Используемые технологии

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (LocalDB)
- C#
- Razor Views
- Dependency Injection

---

## 🏗 Архитектура проекта

- Controllers — обработка HTTP-запросов и взаимодействие с UI
- Models — модели данных (Product, Game)
- Views — пользовательский интерфейс (Razor)
- Data — контекст базы данных (AppDbContext)
- Repositories — слой доступа к данным

---

## 🗄 Работа с базой данных

- Entity Framework Core (Code-First)
- SQL Server LocalDB
- строка подключения в appsettings.json
- регистрация DbContext через DI

---

## 🔄 Миграции

- создание миграции для модели Game
- применение миграций к базе данных
- автоматическое создание таблиц

---

## 📦 Репозиторий данных

- EfProductRepository
- EfGameRepository
- регистрация через Scoped DI

---

## 🌱 Seed данные

- автоматическое заполнение базы при запуске
- тестовые записи для разработки

---

## ▶️ Запуск проекта

1. git clone https://github.com/Andrey-Strekalov/ASP.NET_Labs.git
2. cd ASP.NET_Labs
3. dotnet ef database update
4. dotnet run

---

## 💡 Особенности

- переход от InMemory к SQL
- Repository Pattern
- EF Core Code-First
- Dependency Injection
- разделение слоёв

---

## 📌 Статус

Проект завершён в рамках лабораторной работы

---

## 📈 Что демонстрирует

- Entity Framework Core
- миграции
- MVC архитектура
- работа с SQL Server
- DI и репозитории
