# 🛍️ ModernShop - Complete E-Commerce Platform with Clean Architecture

A comprehensive .NET 10 e-commerce platform featuring both **modern web UI** and **RESTful API** built with Clean Architecture, CQRS, and modern UI/UX design. Includes product management, shopping cart, order processing, and advanced order tracking system.

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Project Structure](#project-structure)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Getting Started](#getting-started)
- [Web Application](#web-application)
- [Blazor Server Application](#blazor-server-application)
- [API Endpoints](#api-endpoints)
- [End-to-End Application Flow](#end-to-end-application-flow)
- [Database Schema](#database-schema)
- [Testing](#testing)
- [Development](#development)

## 🎯 Project Overview

This project demonstrates a complete e-commerce platform implementing:
- **🛒 Modern Web UI** - Attractive MVC web application with Bootstrap 5
- **📡 RESTful API** - Complete Web API with Swagger documentation
- **📦 Product Catalog** - Categories and products management
- **🛍️ Shopping Cart** - Session-based cart with inventory validation
- **📋 Order Management** - Complete order lifecycle with visual tracking
- **🏗️ Clean Architecture** - Proper separation of concerns
- **🔄 CQRS Pattern** - Commands and queries separation
- **🎯 Domain-Driven Design** - Rich domain models with business rules

## 📁 Project Structure

```
AICleanArchitectureDemo/
├── AICleanArchitectureDemo.sln
├── README.md
│
├── AICleanArchitectureDemo.Domain/           # Domain Layer
│   ├── Entities/
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── CartItem.cs
│   │   ├── Order.cs
│   │   └── OrderItem.cs
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   ├── IProductRepository.cs
│   │   ├── ICategoryRepository.cs
│   │   ├── ICartRepository.cs
│   │   └── IOrderRepository.cs
│   └── ValueObjects/
│       └── EmailAddress.cs
│
├── AICleanArchitectureDemo.Application/      # Application Layer
│   ├── DTOs/
│   │   ├── ProductDto.cs
│   │   ├── CategoryDto.cs
│   │   ├── CartItemDto.cs
│   │   └── OrderDto.cs
│   ├── Features/
│   │   ├── Products/
│   │   │   ├── Commands/
│   │   │   │   ├── CreateProductCommand.cs
│   │   │   │   └── CreateProductCommandHandler.cs
│   │   │   └── Queries/
│   │   │       ├── GetProductsQuery.cs
│   │   │       └── GetProductsQueryHandler.cs
│   │   ├── Categories/
│   │   ├── Cart/
│   │   ├── Orders/
│   │   └── Users/
│   └── DependencyInjection.cs
│
├── AICleanArchitectureDemo.Infrastructure/    # Infrastructure Layer
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Repositories/
│   │   ├── ProductRepository.cs
│   │   ├── CategoryRepository.cs
│   │   ├── CartRepository.cs
│   │   └── OrderRepository.cs
│   ├── Migrations/
│   └── DependencyInjection.cs
│
├── AICleanArchitectureDemo.WebApi/           # API Presentation Layer
│   ├── Controllers/
│   │   ├── ProductsController.cs
│   │   ├── CategoriesController.cs
│   │   ├── CartController.cs
│   │   └── OrdersController.cs
│   ├── Program.cs
│   └── appsettings.json
│
└── AICleanArchitectureDemo.WebMvc/           # MVC Web Application
    ├── Controllers/
    │   ├── HomeController.cs
    │   ├── ProductsController.cs
    │   ├── CartController.cs
    │   └── OrdersController.cs
    ├── Models/
    │   ├── HomeViewModel.cs
    │   ├── ProductsViewModel.cs
    │   ├── CartViewModel.cs
    │   └── ErrorViewModel.cs
    ├── Views/
    │   ├── Shared/_Layout.cshtml
    │   ├── Home/Index.cshtml
    │   ├── Products/
    │   │   ├── Index.cshtml
    │   │   └── Details.cshtml
    │   ├── Cart/Index.cshtml
    │   └── Orders/
    │       ├── Index.cshtml
    │       └── Details.cshtml
    ├── Program.cs
    └── appsettings.json

└── AICleanArchitectureDemo.WebBlazor/        # Blazor Server Application
    ├── Pages/
    │   ├── Index.razor                        # Home page with navigation
    │   ├── Products.razor                     # Product browsing and cart
    │   ├── Cart.razor                         # Shopping cart management
    │   ├── Orders.razor                       # Order history and tracking
    │   └── _Host.cshtml                       # Host page configuration
    ├── Services/
    │   └── CartStateService.cs                # Cart state management
    ├── Shared/
    │   └── MainLayout.razor                   # Main layout with navigation
    ├── wwwroot/
    │   ├── css/site.css                       # Custom styles
    │   └── favicon.png
    ├── Program.cs
    └── appsettings.json
```

## ✨ Features

### 🖥️ Modern Web Application (MVC)
- **Responsive Design** - Bootstrap 5 with mobile-first approach
- **Interactive UI** - Hover effects, smooth transitions, modern cards
- **Product Catalog** - Browse products by category with filtering
- **Shopping Cart** - Session-based cart with real-time updates
- **Order Tracking** - Visual progress tracking with step indicators
- **Order History** - Complete order management and details

### 📡 RESTful API
- **Swagger Documentation** - Interactive API docs at `/swagger`
- **CQRS Implementation** - Separate commands and queries
- **Validation** - FluentValidation for all requests
- **Error Handling** - Comprehensive exception management
- **Session Cart** - Anonymous shopping cart support
- **Order Processing** - Complete order lifecycle management

### 🏪 E-Commerce Features
- **Product Management** - Categories and products with stock tracking
- **Inventory Control** - Stock validation and automatic updates
- **Order Processing** - From cart to delivery with status tracking
- **Business Rules** - Domain logic for stock management and pricing
- **Session Management** - Persistent shopping sessions
- **Data Integrity** - Foreign key constraints and validation

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

## 🌐 Web Application

The modern MVC web application provides an attractive, user-friendly interface for the complete shopping experience.

### Features

#### 🏠 Home Page
- **Hero Section**: Eye-catching gradient background with call-to-action
- **Category Showcase**: Interactive category cards with hover effects
- **Featured Products**: Grid layout with modern product cards
- **Responsive Design**: Optimized for all device sizes

#### 📦 Products Page
- **Product Catalog**: Grid view with product cards
- **Category Filtering**: Dynamic filter buttons
- **Product Details**: Individual product pages with specifications
- **Add to Cart**: One-click cart addition

#### 🛒 Shopping Cart
- **Cart Summary**: Detailed cart items with pricing
- **Order Summary**: Subtotal, shipping, and total calculations
- **Checkout Process**: Seamless order placement
- **Session Management**: Persistent cart across browser sessions

#### 📋 Order Management
- **Order History**: Complete list of user orders
- **Order Tracking**: Visual progress indicators showing order status
- **Order Details**: Comprehensive order information
- **Status Updates**: Real-time order status tracking

### UI/UX Highlights

- **Modern Design**: Bootstrap 5 with custom CSS variables
- **Interactive Elements**: Hover effects, smooth transitions
- **Icons**: Font Awesome icons throughout the interface
- **Color Scheme**: Professional blue primary with semantic colors
- **Typography**: Clean, readable fonts
- **Accessibility**: Proper ARIA labels and semantic HTML

### Accessing the Web Application

1. **Run the MVC Application**
   ```bash
   dotnet run --project AICleanArchitectureDemo.WebMvc
   ```

2. **Access URLs**
   - Web Application: `http://localhost:5181`
   - Home Page: `http://localhost:5181/`
   - Products: `http://localhost:5181/Products`
   - Cart: `http://localhost:5181/Cart`
   - Orders: `http://localhost:5181/Orders`

## ⚛️ Blazor Server Application

The modern Blazor Server web application provides an interactive, real-time shopping experience with server-side rendering and SignalR connectivity.

### Features

#### 🏠 Home Page
- **Welcome Dashboard**: Clean navigation cards with call-to-action
- **Quick Access**: Direct links to Products, Cart, and Orders
- **Modern UI**: Bootstrap 5 with custom styling and Font Awesome icons
- **Responsive Design**: Optimized for all device sizes

#### 📦 Products Page
- **Product Catalog**: Interactive grid view with product cards
- **Category Filtering**: Dynamic filter buttons with real-time updates
- **Add to Cart**: One-click cart addition with immediate feedback
- **Session Management**: Persistent cart state across page navigation

#### 🛒 Shopping Cart
- **Real-time Updates**: Cart contents update instantly
- **Quantity Management**: Increase/decrease item quantities
- **Price Calculations**: Automatic subtotal and total calculations
- **Checkout Process**: Seamless order placement with email capture
- **Item Removal**: Remove individual items from cart

#### 📋 Order Management
- **Order History**: Complete list of all orders
- **Order Details**: Detailed view of order items and information
- **Status Tracking**: Visual order status indicators
- **Navigation**: Easy back-and-forth between order list and details

### Technical Highlights

#### 🔄 Interactive Server Mode
- **SignalR Integration**: Real-time communication between client and server
- **Server-Side Rendering**: Initial page loads with full HTML
- **Interactive Components**: Dynamic updates without full page refreshes
- **Session Persistence**: Cart state maintained across SignalR connections

#### 🏗️ Architecture Integration
- **Clean Architecture**: Uses same Domain, Application, and Infrastructure layers
- **MediatR CQRS**: Same command/query pattern as MVC and API
- **Dependency Injection**: Full integration with existing DI container
- **Database Sharing**: Same SQL Server database as other applications

#### 📊 Session Management
- **HttpContext Access**: Session management during initial prerender phase
- **SignalR Compatibility**: Cart state persistence across server interactions
- **Fallback Logic**: Robust session handling for edge cases
- **State Synchronization**: Real-time cart updates across components

### UI/UX Highlights

- **Interactive Design**: Hover effects, smooth transitions, modern cards
- **Real-time Feedback**: Loading states, success indicators, error handling
- **Responsive Layout**: Bootstrap 5 grid system with custom breakpoints
- **Icon Integration**: Font Awesome icons throughout the interface
- **Color Scheme**: Professional blue primary with semantic color usage
- **Accessibility**: Proper ARIA labels and keyboard navigation support

### Accessing the Blazor Server Application

1. **Run the Blazor Application**
   ```bash
   dotnet run --project AICleanArchitectureDemo.WebBlazor
   ```

2. **Access URLs**
   - Blazor Application: `http://localhost:5031` (or next available port)
   - Home Page: `http://localhost:5031/`
   - Products: `http://localhost:5031/products`
   - Cart: `http://localhost:5031/cart`
   - Orders: `http://localhost:5031/orders`
   - Order Details: `http://localhost:5031/orders/{id}`

### Key Differences from MVC Application

#### ⚡ Performance & Interactivity
- **Real-time Updates**: Cart changes reflect immediately without page refresh
- **SignalR Connection**: Persistent connection enables instant UI updates
- **Component-Based**: Razor components with encapsulated logic
- **Client-Server Sync**: Automatic state synchronization

#### 🔧 Technical Architecture
- **Server-Side Rendering**: Initial HTML generation on server
- **Interactive Mode**: Subsequent interactions via SignalR
- **Scoped Services**: Per-user service instances with state management
- **Circuit Management**: Connection lifecycle handling

#### 🎨 User Experience
- **Instant Feedback**: Button clicks provide immediate visual response
- **Seamless Navigation**: Page transitions without full reloads
- **Live Updates**: Cart counters and totals update in real-time
- **Error Resilience**: Graceful error handling with user feedback

### Session Handling in Blazor Server

Blazor Server has unique session management requirements:

```csharp
// During prerender (HttpContext available)
protected override async Task OnInitializedAsync()
{
    var sessionId = GetOrCreateSessionId(); // HttpContext.Session available
    CartState.SetSessionId(sessionId);
    await LoadData();
}

// During interactive operations (HttpContext null)
private async Task AddToCart(int productId)
{
    var sessionId = CartState.SessionId ?? GetOrCreateSessionId();
    // Proceed with cart operation
}
```

### Business Logic Integration

The Blazor application integrates with the same business logic as MVC:

- **Same CQRS Commands**: `AddToCartCommand`, `CreateOrderCommand`
- **Same Validation**: FluentValidation rules applied
- **Same Business Rules**: Stock validation, price calculations
- **Same Data Access**: EF Core repositories and transactions

### Development Advantages

- **Code Sharing**: Reuses 100% of Domain, Application, and Infrastructure layers
- **Consistent API**: Same endpoints and data contracts
- **Unified Business Logic**: Single source of truth for all applications
- **Testing Compatibility**: Same unit tests work across all presentation layers

## 🔄 End-to-End Application Flow

### Complete User Journey

```
┌─────────────────┐
│   User Visits   │ ← Customer opens website
│   Website       │
└─────────────────┘
        │
        ▼
┌─────────────────┐    1. VIEW Home Page
│   Browse Home   │    ├── Hero section
│   Page (MVC)    │    ├── Category cards
│                 │    └── Featured products
└─────────────────┘
        │
        ▼
┌─────────────────┐    2. EXPLORE Products
│   Browse        │    ├── View all products
│   Products      │    ├── Filter by category
│   (MVC)         │    └── View product details
└─────────────────┘
        │
        ▼
┌─────────────────┐    3. ADD to Cart
│   Add Items     │    ├── Click "Add to Cart"
│   to Cart       │    ├── Session management
│   (MVC)         │    └── Real-time updates
└─────────────────┘
        │
        ▼
┌─────────────────┐    4. REVIEW Cart
│   View Cart     │    ├── Cart items display
│   (MVC)         │    ├── Price calculations
│                 │    └── Order summary
└─────────────────┘
        │
        ▼
┌─────────────────┐    5. PLACE Order
│   Checkout      │    ├── Click "Checkout"
│   (MVC)         │    ├── Order creation
│                 │    └── Stock validation
└─────────────────┘
        │
        ▼
┌─────────────────┐    6. TRACK Order
│   Order         │    ├── Order confirmation
│   Tracking      │    ├── Visual progress
│   (MVC)         │    └── Status updates
└─────────────────┘
```

### Technical Flow Behind the Scenes

When a user adds a product to cart:

1. **MVC Controller** receives the POST request
2. **MediatR** dispatches `AddToCartCommand`
3. **Command Handler** validates product availability
4. **Repository** adds item to database cart
5. **Response** updates UI with success message

When placing an order:

1. **MVC Controller** receives checkout request
2. **MediatR** dispatches `CreateOrderCommand`
3. **Command Handler** validates cart contents
4. **Business Logic** checks stock availability
5. **Transaction** creates order and updates inventory
6. **Response** redirects to order tracking page

### Order Status Tracking

The order tracking system shows 4 main stages:

1. **Order Placed** ✅ (Always completed for existing orders)
2. **Processing** 🔄 (Current status for new orders)
3. **Shipped** 📦 (When order is shipped)
4. **Delivered** ✅ (When order reaches customer)

### API Integration

The MVC application consumes the same API endpoints:

- `GET /api/products` → Populates product catalog
- `POST /api/cart/{sessionId}` → Adds items to cart
- `GET /api/cart/{sessionId}` → Displays cart contents
- `POST /api/orders` → Creates new orders
- `GET /api/orders` → Shows order history

### Session Management

- **Anonymous Sessions**: Cart persists via ASP.NET Core sessions
- **Session ID**: Generated on first cart interaction
- **Cross-Request Persistence**: Cart maintained across page visits
- **Order Completion**: Session cleared after successful checkout

### Business Rules Applied

- **Stock Validation**: Prevents overselling
- **Price Locking**: Order items use price at time of order
- **Inventory Updates**: Automatic stock reduction on order
- **Order Status**: Progressive status updates
- **Data Integrity**: All operations within transactions

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
