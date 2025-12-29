# 🛒 AICleanArchitectureDemo - Online Shopping API

A comprehensive .NET 10 Web API for online shopping built with Clean Architecture, CQRS, and Entity Framework Core. Features product management, shopping cart, and order processing with proper domain-driven design.

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Application Workflow](#application-workflow)
- [Database Schema](#database-schema)
- [Testing](#testing)

## 🎯 Project Overview

This project demonstrates a complete e-commerce API implementing:
- **Product Catalog** - Categories and products management
- **Shopping Cart** - Session-based cart with inventory validation
- **Order Management** - Complete order lifecycle with status tracking
- **Clean Architecture** - Proper separation of concerns
- **CQRS Pattern** - Commands and queries separation
- **Domain-Driven Design** - Rich domain models with business rules

## 🏗️ Architecture

### Clean Architecture Layers

```
┌─────────────────────────────────────┐
│         Presentation Layer          │
│       (ASP.NET Core Web API)        │
│    Controllers, DTOs, Middleware    │
├─────────────────────────────────────┤
│         Application Layer           │
│    CQRS, Commands, Queries, DTOs    │
├─────────────────────────────────────┤
│         Domain Layer                │
│   Entities, Value Objects, Rules    │
├─────────────────────────────────────┤
│         Infrastructure Layer        │
│   EF Core, Repositories, External   │
└─────────────────────────────────────┘
```

### Key Architectural Patterns

- **CQRS** - Commands for writes, Queries for reads
- **Repository Pattern** - Data access abstraction
- **Dependency Injection** - IoC container for loose coupling
- **Domain-Driven Design** - Rich domain models with business logic

## 🛠️ Technologies Used

- **.NET 10** - Runtime framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core** - ORM with SQL Server
- **MediatR** - CQRS implementation
- **FluentValidation** - Request validation
- **SQL Server LocalDB** - Database
- **Swagger/OpenAPI** - API documentation

## 🚀 Getting Started

### Prerequisites

- .NET 10 SDK
- SQL Server LocalDB (comes with Visual Studio)
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd AICleanArchitectureDemo
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Run database migrations**
   ```bash
   dotnet ef database update --project AICleanArchitectureDemo.Infrastructure --startup-project AICleanArchitectureDemo.WebApi
   ```

4. **Run the application**
   ```bash
   dotnet run --project AICleanArchitectureDemo.WebApi
   ```

5. **Access the API**
   - API: `http://localhost:5223`
   - Swagger UI: `http://localhost:5223/swagger`

### Database Seeding

The application automatically seeds sample data on startup:
- 3 Categories (Electronics, Clothing, Books)
- 4 Products across different categories

## 📡 API Endpoints

### Categories Management

#### `GET /api/categories`
Get all categories.

**Response:**
```json
[
  {
    "id": 1,
    "name": "Electronics",
    "description": "Electronic devices and gadgets"
  }
]
```

#### `POST /api/categories`
Create a new category.

**Request:**
```json
{
  "name": "Books",
  "description": "Books and publications"
}
```

**Response:**
```json
1
```

### Products Management

#### `GET /api/products`
Get all products with category information.

**Response:**
```json
[
  {
    "id": 1,
    "name": "Laptop",
    "description": "High-performance laptop",
    "price": 999.99,
    "categoryId": 1,
    "categoryName": "Electronics",
    "stockQuantity": 50,
    "imageUrl": "laptop.jpg"
  }
]
```

#### `GET /api/products/{id}`
Get product by ID.

**Response:**
```json
{
  "id": 1,
  "name": "Laptop",
  "description": "High-performance laptop",
  "price": 999.99,
  "categoryId": 1,
  "categoryName": "Electronics",
  "stockQuantity": 50,
  "imageUrl": "laptop.jpg"
}
```

#### `POST /api/products`
Create a new product.

**Request:**
```json
{
  "name": "Gaming Mouse",
  "description": "High-precision gaming mouse",
  "price": 79.99,
  "categoryId": 1,
  "stockQuantity": 25,
  "imageUrl": "mouse.jpg"
}
```

**Response:**
```json
5
```

### Shopping Cart

#### `GET /api/cart/{sessionId}`
Get cart items for a session.

**Response:**
```json
[
  {
    "id": 1,
    "productId": 1,
    "productName": "Laptop",
    "productPrice": 999.99,
    "quantity": 1,
    "totalPrice": 999.99
  }
]
```

#### `POST /api/cart/{sessionId}`
Add item to cart.

**Request:**
```json
{
  "productId": 1,
  "quantity": 2
}
```

**Response:**
```json
2
```

### Orders Management

#### `POST /api/orders`
Create order from cart.

**Request:**
```json
{
  "sessionId": "user-session-123",
  "customerEmail": "customer@example.com"
}
```

**Response:**
```json
1
```

#### `GET /api/orders`
Get all orders.

**Response:**
```json
[
  {
    "id": 1,
    "customerEmail": "customer@example.com",
    "orderDate": "2025-12-29T10:30:00Z",
    "status": "Pending",
    "totalAmount": 999.99,
    "items": [
      {
        "productId": 1,
        "productName": "Laptop",
        "quantity": 1,
        "priceAtTime": 999.99,
        "totalPrice": 999.99
      }
    ]
  }
]
```

#### `GET /api/orders/{id}`
Get order by ID.

**Response:**
```json
{
  "id": 1,
  "customerEmail": "customer@example.com",
  "orderDate": "2025-12-29T10:30:00Z",
  "status": "Pending",
  "totalAmount": 999.99,
  "items": [
    {
      "productId": 1,
      "productName": "Laptop",
      "quantity": 1,
      "priceAtTime": 999.99,
      "totalPrice": 999.99
    }
  ]
}
```

## 🔄 Application Workflow

### Complete Shopping Flow

1. **Setup Categories**
   ```
   POST /api/categories → Create "Electronics" category
   ```

2. **Add Products**
   ```
   POST /api/products → Create products with categoryId
   ```

3. **Browse Products**
   ```
   GET /api/products → View all products
   GET /api/categories → View categories
   ```

4. **Shopping Cart Operations**
   ```
   POST /api/cart/session123 → Add laptop (quantity: 1)
   POST /api/cart/session123 → Add mouse (quantity: 2)
   GET /api/cart/session123 → View cart (2 items, total: $1159.97)
   ```

5. **Place Order**
   ```
   POST /api/orders → Create order from cart
   ├── Validate stock availability
   ├── Create order record
   ├── Create order items
   ├── Update product stock
   └── Clear shopping cart
   ```

6. **Order Management**
   ```
   GET /api/orders → View all orders
   GET /api/orders/1 → View specific order
   ```

### Business Rules Enforced

- **Stock Validation**: Cannot add to cart if insufficient stock
- **Order Processing**: Reduces inventory when order is placed
- **Session Management**: Cart items are tied to user sessions
- **Data Integrity**: Foreign key constraints ensure valid relationships

## 🔀 Clean Architecture Request Flow

### How a Request Flows Through Layers

When a client makes an API request (e.g., `POST /api/products`), here's how it flows through the Clean Architecture layers:

```
┌─────────────────┐
│   HTTP Request  │ ← Client sends POST /api/products
│   (JSON Data)   │
└─────────────────┘
        │
        ▼
┌─────────────────┐    1. CONTROLLER receives request
│ PRESENTATION    │    2. Maps JSON to Command
│   (Web API)     │    3. Calls MediatR.Send()
└─────────────────┘
        │
        ▼
┌─────────────────┐    4. APPLICATION validates request
│ APPLICATION     │    5. Executes business logic
│   (CQRS)        │    6. Calls repository interface
└─────────────────┘
        │
        ▼
┌─────────────────┐    7. INFRASTRUCTURE implements
│ INFRASTRUCTURE  │    8. Executes EF Core queries
│   (EF Core)     │    9. Updates database
└─────────────────┘
        │
        ▼
┌─────────────────┐
│   SQL Database  │ ← Data persisted
└─────────────────┘
        │
        ▼
┌─────────────────┐
│   HTTP Response │ ← JSON response sent to client
│   (Status 200)  │
└─────────────────┘
```

### Detailed Code Flow Example

Let's trace through `POST /api/products` request:

#### 1. **Presentation Layer** (Web API Controller)
```csharp
// ProductsController.cs
[HttpPost]
public async Task<IActionResult> Create(CreateProductCommand command)
{
    var result = await _mediator.Send(command); // ← Dependency Injection
    return CreatedAtAction(nameof(GetById), new { id = result }, result);
}
```

#### 2. **Application Layer** (CQRS Command Handler)
```csharp
// CreateProductCommandHandler.cs
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IRepository<Product> _productRepository; // ← Interface, not concrete

    public CreateProductCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository; // ← Injected by DI container
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken token)
    {
        var product = new Product { /* map from request */ };
        await _productRepository.AddAsync(product); // ← Calls repository interface
        return product.Id;
    }
}
```

#### 3. **Infrastructure Layer** (Repository Implementation)
```csharp
// ProductRepository.cs
public class ProductRepository : IRepository<Product>
{
    private readonly AppDbContext _context; // ← Injected EF Core context

    public ProductRepository(AppDbContext context)
    {
        _context = context; // ← DI container provides concrete implementation
    }

    public async Task AddAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync(); // ← EF Core saves to database
    }
}
```

#### 4. **Domain Layer** (Business Entities)
```csharp
// Product.cs (Domain Entity)
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Domain business rules
    public void UpdateStock(int quantity)
    {
        if (StockQuantity + quantity < 0)
            throw new InvalidOperationException("Insufficient stock");

        StockQuantity += quantity;
        UpdatedAt = DateTime.UtcNow;
    }
}
```

### Dependency Injection Container Setup

```csharp
// Program.cs - DI Container Configuration
var builder = WebApplication.CreateBuilder(args);

// Register Application Layer
builder.Services.AddApplication(); // ← Registers MediatR, Validators

// Register Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration); // ← Registers DbContext, Repositories

var app = builder.Build();
```

### CQRS Pattern in Action

**Command Flow** (for writes):
```
Controller → Command → Validator → Handler → Repository → Database
```

**Query Flow** (for reads):
```
Controller → Query → Handler → Repository → Database → DTO → Response
```

### Layer Communication Rules

- **Presentation** can only depend on **Application**
- **Application** can only depend on **Domain**
- **Infrastructure** can depend on **Application** and **Domain**
- **Domain** has no dependencies (pure business logic)

### Benefits of This Architecture

1. **Testability**: Each layer can be unit tested independently
2. **Maintainability**: Changes in one layer don't affect others
3. **Flexibility**: Can swap implementations (EF Core → Dapper, SQL → NoSQL)
4. **Separation of Concerns**: Business logic separated from infrastructure
5. **Dependency Inversion**: High-level modules don't depend on low-level modules

### Real-World Request Example

When you call `POST /api/products` with product data:

1. **ASP.NET Core** routes to `ProductsController.Create()`
2. **Controller** creates `CreateProductCommand` from JSON
3. **MediatR** finds and calls `CreateProductCommandHandler`
4. **Handler** validates request using `FluentValidation`
5. **Handler** creates `Product` domain entity
6. **Handler** calls `IProductRepository.AddAsync()`
7. **Repository** (EF Core implementation) saves to SQL Server
8. **Response** flows back: `HTTP 201 Created` with product ID

This flow ensures clean separation while maintaining all architectural benefits!

## 🗄️ Database Schema

```
Categories
├── Id (PK)
├── Name
└── Description

Products
├── Id (PK)
├── Name
├── Description
├── Price
├── CategoryId (FK → Categories.Id)
├── StockQuantity
├── ImageUrl
├── CreatedAt
└── UpdatedAt

CartItems
├── Id (PK)
├── SessionId
├── ProductId (FK → Products.Id)
├── Quantity
└── AddedAt

Orders
├── Id (PK)
├── CustomerEmail
├── OrderDate
├── Status (enum)
└── TotalAmount

OrderItems
├── Id (PK)
├── OrderId (FK → Orders.Id)
├── ProductId (FK → Products.Id)
├── Quantity
└── PriceAtTime
```

## 🧪 Testing

### Manual Testing with Swagger

1. Start the application: `dotnet run --project AICleanArchitectureDemo.WebApi`
2. Open `http://localhost:5223/swagger`
3. Test endpoints in logical order:
   - Categories → Products → Cart → Orders

### Sample Test Flow

```bash
# 1. Create a category
curl -X POST "http://localhost:5223/api/categories" \
  -H "Content-Type: application/json" \
  -d '{"name":"Test Category","description":"Test"}'

# 2. Create a product
curl -X POST "http://localhost:5223/api/products" \
  -H "Content-Type: application/json" \
  -d '{"name":"Test Product","description":"Test","price":99.99,"categoryId":1,"stockQuantity":10}'

# 3. Add to cart
curl -X POST "http://localhost:5223/api/cart/test-session" \
  -H "Content-Type: application/json" \
  -d '{"productId":1,"quantity":2}'

# 4. View cart
curl -X GET "http://localhost:5223/api/cart/test-session"

# 5. Place order
curl -X POST "http://localhost:5223/api/orders" \
  -H "Content-Type: application/json" \
  -d '{"sessionId":"test-session","customerEmail":"test@example.com"}'

# 6. View orders
curl -X GET "http://localhost:5223/api/orders"
```

## 📚 Key Features

- ✅ **Clean Architecture** - Proper separation of concerns
- ✅ **CQRS Implementation** - Commands and queries
- ✅ **Domain-Driven Design** - Rich domain models
- ✅ **Entity Framework Core** - Code-First migrations
- ✅ **Validation** - FluentValidation for requests
- ✅ **Dependency Injection** - Microsoft.Extensions.DI
- ✅ **Swagger Documentation** - Interactive API docs
- ✅ **Error Handling** - Comprehensive exception handling
- ✅ **Business Rules** - Stock management, order validation
- ✅ **Session Cart** - Anonymous shopping cart
- ✅ **Order Tracking** - Status management system

## 🔧 Development Notes

- **Database**: Uses SQL Server LocalDB for development
- **Migrations**: Run `dotnet ef database update` to apply changes
- **Seed Data**: Automatically seeded on application start
- **Validation**: All commands are validated using FluentValidation
- **MediatR**: CQRS pattern implemented with MediatR library
- **Repository Pattern**: Data access abstracted through repositories

## 📄 License

This project is for educational purposes demonstrating Clean Architecture and CQRS patterns in .NET.
