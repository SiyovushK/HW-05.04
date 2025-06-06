Отлично! Тогда я оставлю **указания, какие поля требуют ограничений**, но **реализацию ограничений пусть пишут ученики сами** — и через **Data Annotations**, и через **Fluent API**. Вот обновлённое задание:

---

# 🏛 Задание по созданию API для библиотеки

## 🎯 Цель:
Разработать API для управления библиотекой (книги, авторы и жанры) с использованием:
- Entity Framework Core
- PostgreSQL
- Data Annotations
- Fluent API
- Swagger
- `appsettings.json` для строки подключения

---

## 🧱 Структура проекта:
1. **Domain** — модели данных
2. **Infrastructure** — EF Core, конфигурации, миграции
3. **WebAPI** — контроллеры, конфигурация, Swagger

---

## 1. **Domain** — Модели:

### 📘 Book
| Поле         | Тип      | Что нужно реализовать                                       |
|--------------|-----------|-------------------------------------------------------------|
| `Id`         | `int`     | Первичный ключ                                              |
| `Title`      | `string`  | Обязательное, максимальная длина                           |
| `Year`       | `int`     | Указать допустимый диапазон годов (например, 1450–2100)     |
| `ISBN`       | `string`  | Обязательное, длина 10–13 символов, должно быть уникальным |
| `Pages`      | `int`     | Диапазон допустимых значений страниц                       |
| `Description`| `string`  | Ограничить максимальную длину                              |
| `AuthorId`   | `int`     | Внешний ключ                                                |
| `GenreId`    | `int`     | Внешний ключ                                                |
| `Author`     | `Author`  | Навигационное свойство                                      |
| `Genre`      | `Genre`   | Навигационное свойство                                      |

---

### 👤 Author
| Поле         | Тип      | Что нужно реализовать                                       |
|--------------|-----------|-------------------------------------------------------------|
| `Id`         | `int`     | Первичный ключ                                              |
| `Name`       | `string`  | Обязательное, максимальная длина                           |
| `BirthYear`  | `int`     | Диапазон годов рождения                                     |
| `Country`    | `string`  | Максимальная длина                                          |
| `Biography`  | `string`  | Ограничить по длине                                         |
| `Books`      | `List<Book>` | Навигационное свойство                                   |

---

### 🎭 Genre
| Поле         | Тип      | Что нужно реализовать                                       |
|--------------|-----------|-------------------------------------------------------------|
| `Id`         | `int`     | Первичный ключ                                              |
| `Name`       | `string`  | Обязательное, максимальная длина, уникальность              |
| `Description`| `string`  | Ограничить длину                                            |
| `IsFiction`  | `bool`    | Логическое поле                                              |
| `Popularity` | `int`     | Ограничить значение от 0 до 100                             |
| `Books`      | `List<Book>` | Навигационное свойство                                   |

---

### ✅ Требования к моделям:
- Добавить **ограничения с помощью Data Annotations** (`[Required]`, `[StringLength]`, `[Range]`, и т.д.)
- Повторно указать **те же ограничения с помощью Fluent API** в `OnModelCreating`
- Настроить **связи между таблицами через Fluent API**

---

## 2. **Infrastructure**:
- Контекст `LibraryContext`, унаследованный от `DbContext`
- `DbSet<Book>`, `DbSet<Author>`, `DbSet<Genre>`
- Конфигурация всех ограничений и связей в `OnModelCreating`
- Добавьте миграции и примените их к базе данных

---

## 3. **WebAPI**:
- Контроллеры:
  - `BooksController`
  - `AuthorsController`
  - `GenresController`
- Методы:
  - `GET` - всё
  - `GET` - по id
  - `POST`
  - `PUT`
  - `DELETE`

---

## 4. **Swagger**:
- Установите `Swashbuckle.AspNetCore`
- Включите Swagger-документацию в `Program.cs`
---

## 5. **`appsettings.json` и строка подключения**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=librarydb;Username=myuser;Password=mypassword"
  }
}
```

- Используйте `builder.Services.AddDbContext<T>(options => ...)` для подключения

---