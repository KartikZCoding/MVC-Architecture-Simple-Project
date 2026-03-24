# 📘 The Complete MVC Guide — From Zero to Expert

> **Audience:** Beginners who want to understand everything about MVC — what it is, why it exists, how it works, and how professionals use it in real-world enterprise projects.

---

## Table of Contents

1. [What is MVC?](#1-what-is-mvc)
2. [Where Did MVC Come From? (History)](#2-where-did-mvc-come-from-history)
3. [What Did We Use Before MVC?](#3-what-did-we-use-before-mvc)
4. [Why Do We Need MVC?](#4-why-do-we-need-mvc)
5. [How MVC Works — The Flow](#5-how-mvc-works--the-flow)
6. [MVC vs Other Patterns](#6-mvc-vs-other-patterns)
7. [ASP.NET Core MVC — Complete File Structure Explained](#7-aspnet-core-mvc--complete-file-structure-explained)
8. [Enterprise & Industrial Usage Patterns](#8-enterprise--industrial-usage-patterns)
9. [Interview Q&A — Everything You Should Know](#9-interview-qa--everything-you-should-know)
10. [Glossary of Terms](#10-glossary-of-terms)

---

# 1. What is MVC?

## Definition

**MVC** stands for **Model-View-Controller**. It is a **software design pattern** (a proven solution to a common problem) that divides an application into **three interconnected components**:

| Component | Responsibility | Real-World Analogy |
|-----------|---------------|-------------------|
| **Model** | Manages the **data** and **business logic** | The **kitchen** in a restaurant — it prepares the food (data) |
| **View** | Displays the **UI** (what the user sees) | The **plate/table** — it presents the food to the customer |
| **Controller** | Handles **user input** and coordinates between Model & View | The **waiter** — takes the order, tells the kitchen, brings the food back |

## Simple Example

Imagine you open a website and type `www.example.com/students`:

```
1. YOU (Browser) → Send request to → CONTROLLER ("Hey, I want to see students")
2. CONTROLLER → Asks the → MODEL ("Give me all student data from the database")
3. MODEL → Fetches data → Returns it to CONTROLLER
4. CONTROLLER → Sends data to → VIEW ("Here's the data, make it look nice in HTML")
5. VIEW → Renders HTML → Sends response back to YOUR BROWSER
```

```
┌──────────┐    Request     ┌──────────────┐    Gets Data    ┌─────────┐
│          │ ─────────────► │              │ ──────────────► │         │
│  USER /  │                │  CONTROLLER  │                 │  MODEL  │
│  BROWSER │ ◄───────────── │   (Waiter)   │ ◄────────────── │(Kitchen)│
│          │   HTML Page    │              │   Returns Data  │         │
└──────────┘                └──────┬───────┘                 └─────────┘
                                   │
                              Sends Data to
                                   │
                                   ▼
                            ┌──────────────┐
                            │     VIEW     │
                            │   (Plate)    │
                            │ Renders HTML │
                            └──────────────┘
```

---

# 2. Where Did MVC Come From? (History)

| Year | Event |
|------|-------|
| **1979** | **Trygve Reenskaug**, a Norwegian computer scientist, invented MVC while working at **Xerox PARC** (Palo Alto Research Center). He was working on the **Smalltalk-79** programming language. |
| **1988** | MVC was formally described in the **Journal of Object-Oriented Programming**. |
| **1990s** | MVC became popular in **desktop GUI applications** (Java Swing, etc.). |
| **2000s** | MVC exploded in **web development** — Ruby on Rails (2004), Django (2005), Spring MVC (2002). |
| **2009** | **ASP.NET MVC 1.0** released by Microsoft as an alternative to Web Forms. |
| **2016** | **ASP.NET Core MVC** released — the modern, cross-platform version we use today. |
| **Present** | MVC is the most widely used architectural pattern for web applications worldwide. |

### Why Was It Invented?

Before MVC, code was **messy**. The same file would contain:
- Database queries (data)
- HTML/UI code (presentation)
- Business logic (rules)

This made code **hard to read, hard to test, and hard to maintain**. MVC was invented to **separate concerns** — each part of the code has ONE job.

---

# 3. What Did We Use Before MVC?

Before MVC, developers used several approaches. All of them had significant problems:

## 3.1 Spaghetti Code (No Pattern)

```
// EVERYTHING in one file — data + logic + UI
<%
    string connectionString = "Server=...";
    SqlConnection conn = new SqlConnection(connectionString);
    conn.Open();
    SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
    SqlDataReader reader = cmd.ExecuteReader();
%>
<html>
<body>
    <table>
    <% while(reader.Read()) { %>
        <tr><td><%= reader["Name"] %></td></tr>
    <% } %>
    </table>
</body>
</html>
```

**Problems:** Impossible to maintain, cannot reuse code, cannot test, security risks everywhere.

## 3.2 ASP.NET Web Forms (2002–2009)

Microsoft's first attempt at making web development "easy" by making it work like Windows Forms.

| Feature | Web Forms Approach | Problem |
|---------|-------------------|---------|
| Page Model | `.aspx` page + `.aspx.cs` code-behind | Tight coupling between UI and logic |
| State | ViewState (hidden field storing page state) | Made pages extremely heavy/slow |
| Controls | Server controls like `<asp:GridView>` | Generated ugly, uncontrollable HTML |
| URL | `Page.aspx?id=5` | Ugly URLs, no routing control |
| Testing | Nearly impossible to unit test | Code-behind tied to page lifecycle |
| HTML Control | Very limited | Framework generated HTML for you |

## 3.3 Classic ASP (1996–2002)

```asp
<%
    Set conn = Server.CreateObject("ADODB.Connection")
    conn.Open "Provider=SQLOLEDB;Data Source=...;"
    Set rs = conn.Execute("SELECT * FROM Students")
    Do While Not rs.EOF
        Response.Write("<tr><td>" & rs("Name") & "</td></tr>")
        rs.MoveNext
    Loop
%>
```

**Problems:** No separation of concerns, VBScript-based, no object-oriented programming, no structure.

## 3.4 CGI Scripts (1993–2000)

The very first way to make dynamic web pages. Each request spawned a new process.

**Problems:** Extremely slow, one process per request, no scalability.

## Evolution Timeline

```
CGI Scripts (1993)
    ↓
Classic ASP / PHP (1996)
    ↓
ASP.NET Web Forms / JSP (2002)
    ↓
ASP.NET MVC / Rails / Django (2009)    ← MVC Era Begins
    ↓
ASP.NET Core MVC (2016)                ← Modern Era (What we use today)
```

---

# 4. Why Do We Need MVC?

## The Core Problem MVC Solves: Separation of Concerns (SoC)

Without MVC, your code becomes a **tangled mess** where changing one thing breaks everything else.

## Benefits of MVC

| Benefit | Explanation | Example |
|---------|-------------|---------|
| **Separation of Concerns** | Each component has ONE job | Model = data, View = UI, Controller = logic |
| **Testability** | You can test each part independently | Test business logic without loading a web page |
| **Maintainability** | Changes in one part don't break others | Change the UI without touching database code |
| **Reusability** | Models can be reused across views | Same `Student` model used in List, Details, Edit views |
| **Team Collaboration** | Different developers can work on different parts | Frontend dev works on Views, Backend dev works on Models |
| **Clean URLs** | Built-in routing system | `/students/edit/5` instead of `StudentEdit.aspx?id=5` |
| **Full HTML Control** | You write the HTML yourself | No auto-generated bloated HTML |
| **SEO Friendly** | Clean URLs and controllable HTML | Search engines can index your pages properly |
| **Scalability** | Structured code scales better | Enterprise apps with hundreds of features stay organized |

## What Happens Without MVC?

```
❌ Without MVC:
- Change the database? → Break the UI.
- Change the UI? → Break the business logic.
- Want to test? → Have to load the entire application.
- New developer joins? → Takes weeks to understand the code.
- Bug in one page? → Might affect 10 other pages.

✅ With MVC:
- Change the database? → Only update the Model.
- Change the UI? → Only update the View.
- Want to test? → Test each component separately.
- New developer joins? → Clear structure makes onboarding fast.
- Bug in one page? → Isolated, easy to find and fix.
```

---

# 5. How MVC Works — The Flow

## Complete Request-Response Lifecycle in ASP.NET Core MVC

```
STEP-BY-STEP FLOW:

Browser sends: GET /students/details/5
         │
         ▼
┌─────────────────────────────────────────────────────────┐
│                 ASP.NET Core Pipeline                    │
│                                                          │
│  1. Kestrel Web Server receives the HTTP request         │
│  2. Middleware Pipeline processes (auth, logging, etc.)   │
│  3. Routing Engine matches URL to Controller/Action       │
│          /students/details/5                              │
│          ↓          ↓       ↓                             │
│      Controller   Action   Parameter                     │
│      Students    Details     5                            │
└──────────────────────┬──────────────────────────────────┘
                       │
                       ▼
┌──────────────────────────────────────┐
│         StudentsController           │
│                                      │
│  public IActionResult Details(int id)│
│  {                                   │
│    var student = _service.GetById(id)│ ──► Service Layer ──► Repository ──► Database
│    return View(student);             │ ◄── Returns Student object
│  }                                   │
└──────────────┬───────────────────────┘
               │
               ▼  Passes Model to View
┌──────────────────────────────────────┐
│      Views/Students/Details.cshtml   │
│                                      │
│  @model Student                      │
│  <h1>@Model.Name</h1>               │
│  <p>@Model.Email</p>                │
│                                      │
│  Razor Engine renders this to HTML   │
└──────────────┬───────────────────────┘
               │
               ▼
┌──────────────────────────────────────┐
│    HTML Response sent to Browser     │
│                                      │
│  <h1>John Doe</h1>                   │
│  <p>john@example.com</p>             │
└──────────────────────────────────────┘
```

---

# 6. MVC vs Other Patterns

| Pattern | Full Form | Key Difference | Used In |
|---------|-----------|---------------|---------|
| **MVC** | Model-View-Controller | Controller handles input | ASP.NET Core, Rails, Django, Spring |
| **MVP** | Model-View-Presenter | Presenter updates View directly | WinForms, Android (older) |
| **MVVM** | Model-View-ViewModel | Two-way data binding | WPF, Angular, Vue.js, Xamarin |
| **MVI** | Model-View-Intent | Unidirectional data flow | Kotlin/Android (modern) |
| **VIPER** | View-Interactor-Presenter-Entity-Router | Highly modular | iOS (Swift) |

### MVC vs MVVM (Most Common Comparison)

```
MVC:
  User Action → Controller → Model → Controller → View
  (Controller decides which View to show)

MVVM:
  User Action → View → ViewModel ↔ Model
  (View and ViewModel are bound via data binding — changes auto-reflect)
```

| Aspect | MVC | MVVM |
|--------|-----|------|
| **Data Binding** | Manual (Controller passes data to View) | Automatic (Two-way binding) |
| **View Logic** | Minimal — logic is in Controller | ViewModel contains View logic |
| **Best For** | Web applications | Desktop/Mobile apps (WPF, Angular) |
| **Testing** | Test Controllers | Test ViewModels |
| **Complexity** | Simpler to learn | More powerful but complex |

---

# 7. ASP.NET Core MVC — Complete File Structure Explained

Below is **every file and folder** you'll find in an ASP.NET Core MVC project, with detailed explanations.

## 7.1 Top-Level File Structure Overview

```
SimpleMVCApp/                        ← Solution Folder
├── SimpleMVCApp.slnx                ← Solution File
├── .gitignore                       ← Git Ignore Rules
├── .git/                            ← Git Repository Data
├── .github/                         ← GitHub Configuration
│
└── SimpleMVCApp/                    ← Project Folder
    ├── SimpleMVCApp.csproj          ← Project Configuration
    ├── Program.cs                   ← Application Entry Point
    ├── appsettings.json             ← Configuration Settings
    ├── appsettings.Development.json ← Dev-specific Settings
    │
    ├── Controllers/                 ← Request Handlers
    ├── Models/                      ← Data/Entity Classes
    ├── Views/                       ← UI Templates (Razor)
    ├── DTOs/                        ← Data Transfer Objects
    ├── Service/                     ← Business Logic Layer
    ├── Repository/                  ← Data Access Layer
    ├── Data/                        ← Database Context
    ├── Mapping/                     ← AutoMapper Profiles
    ├── Migrations/                  ← Database Migrations
    ├── Properties/                  ← Launch Settings
    ├── wwwroot/                     ← Static Files (CSS, JS, Images)
    ├── bin/                         ← Compiled Output
    └── obj/                         ← Build Intermediate Files
```

---

## 7.2 Solution-Level Files

### 📄 `SimpleMVCApp.slnx` — Solution File

| Aspect | Detail |
|--------|--------|
| **What is it?** | A **Solution file** that groups one or more projects together. It's the top-level file Visual Studio uses to open your projects. |
| **Why do we need it?** | In real-world apps, you might have multiple projects (Web, API, Library, Tests). The solution file ties them all together. |
| **What if we remove it?** | Visual Studio won't be able to open the project as a solution. You'd need to open the `.csproj` directly, losing multi-project support. |
| **File extension** | `.slnx` is the new XML-based solution format. Older projects use `.sln` (text-based). |

### 📄 `.gitignore`

| Aspect | Detail |
|--------|--------|
| **What is it?** | Tells Git which files/folders to **ignore** and NOT track. |
| **Why do we need it?** | Prevents committing `bin/`, `obj/`, `.vs/`, `appsettings.Development.json` (secrets), and other build artifacts. |
| **What if we remove it?** | Git will track everything, including compiled binaries and sensitive config files. Repository becomes bloated and insecure. |

---

## 7.3 Project Configuration Files

### 📄 `SimpleMVCApp.csproj` — Project File

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
    <!-- Other NuGet packages -->
  </ItemGroup>
</Project>
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | The **project configuration file**. Defines the target framework (.NET version), NuGet packages (dependencies), build settings, etc. |
| **Why do we need it?** | Without it, .NET doesn't know how to build your project — what framework to target, what packages to restore. |
| **What if we remove it?** | **Project will not build.** The `dotnet` CLI and Visual Studio cannot function without this file. |
| **Key elements** | `TargetFramework` (e.g., net9.0), `PackageReference` (NuGet packages), `Sdk` (type of project — Web, Console, etc.) |

### 📄 `Program.cs` — Application Entry Point (THE MOST IMPORTANT FILE)

```csharp
var builder = WebApplication.CreateBuilder(args);

// 1. REGISTER SERVICES (Dependency Injection Container)
builder.Services.AddControllersWithViews();    // Register MVC services
builder.Services.AddDbContext<AppDbContext>(); // Register database
builder.Services.AddScoped<IStudentService, StudentService>(); // Register custom services
builder.Services.AddAutoMapper(typeof(Program)); // Register AutoMapper

var app = builder.Build();

// 2. CONFIGURE MIDDLEWARE PIPELINE (order matters!)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();  // Redirect HTTP → HTTPS
app.UseStaticFiles();       // Serve files from wwwroot/
app.UseRouting();            // Enable routing
app.UseAuthorization();      // Enable authorization

// 3. DEFINE ROUTES
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Start the application
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | The **application entry point** — where the app starts. It configures services, middleware, and routing. |
| **Why do we need it?** | It's the **bootstrap** file. Without it, the application doesn't know what services exist, how to handle requests, or what URL patterns to use. |
| **What if we remove it?** | **Application will not start at all.** This is the foundation of everything. |
| **Key sections** | 1) Service Registration (DI), 2) Middleware Pipeline, 3) Route Configuration |

### 📄 `appsettings.json` — Application Configuration

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SimpleMVCDB;Trusted_Connection=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | The **configuration file** — stores connection strings, API keys, logging settings, app-specific settings. |
| **Why do we need it?** | So we don't hardcode settings in our code. We can change database connections, logging levels, etc. without recompiling. |
| **What if we remove it?** | App may fail to start if it depends on configuration values (like connection strings). |

### 📄 `appsettings.Development.json` — Development-Only Settings

| Aspect | Detail |
|--------|--------|
| **What is it?** | **Overrides** `appsettings.json` when running in **Development** environment. |
| **Why do we need it?** | Use a local database in development, production database in production — without changing code. |
| **What if we remove it?** | App will use `appsettings.json` values for all environments. Less flexibility. |

---

## 7.4 The Three Core MVC Folders

### 📁 `Controllers/` — The Brain / The Waiter

Controllers **receive HTTP requests**, **process them**, and **return responses**.

#### Example Controller:

```csharp
public class StudentsController : Controller
{
    private readonly IStudentService _service;

    // Constructor Injection — gets service from DI container
    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    // GET: /students
    public IActionResult Index()
    {
        var students = _service.GetAll();  // Ask service for data
        return View(students);             // Pass data to View
    }

    // GET: /students/details/5
    public IActionResult Details(int id)
    {
        var student = _service.GetById(id);
        if (student == null)
            return NotFound();             // Return 404
        return View(student);
    }

    // GET: /students/create
    public IActionResult Create()
    {
        return View();                     // Show empty form
    }

    // POST: /students/create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(StudentCreateDTO dto)
    {
        if (!ModelState.IsValid)
            return View(dto);              // Return form with errors

        _service.Add(dto);
        return RedirectToAction(nameof(Index)); // Redirect to list
    }
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | Classes that handle incoming HTTP requests and return responses. |
| **Why do we need it?** | Without controllers, there's no way to handle user requests. The app wouldn't respond to any URL. |
| **What if we remove it?** | **No routes will work.** Every URL will return 404. The app is useless. |
| **Naming Convention** | Must end with `Controller` suffix (e.g., `StudentsController`). |
| **Base Class** | Inherits from `Controller` (for MVC with Views) or `ControllerBase` (for API only). |
| **Action Methods** | Public methods that correspond to URL endpoints. |
| **Return Types** | `IActionResult` — can return View, JSON, Redirect, File, StatusCode, etc. |

#### Key Attributes:

| Attribute | Purpose |
|-----------|---------|
| `[HttpGet]` | Only responds to GET requests |
| `[HttpPost]` | Only responds to POST requests |
| `[HttpPut]` | Only responds to PUT requests |
| `[HttpDelete]` | Only responds to DELETE requests |
| `[ValidateAntiForgeryToken]` | Prevents CSRF attacks |
| `[Authorize]` | Requires user to be logged in |
| `[AllowAnonymous]` | Allows unauthenticated access |
| `[Route("custom/path")]` | Custom URL routing |

---

### 📁 `Models/` — The Data / The Kitchen

Models represent the **data structure** and **database tables**.

#### Example Model:

```csharp
public class Student
{
    public int Id { get; set; }                // Primary Key

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Range(1, 150)]
    public int Age { get; set; }

    public DateTime EnrollmentDate { get; set; }

    // Navigation Property — Relationship
    public ICollection<Course> Courses { get; set; }
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | C# classes that represent the shape of your data. Each Model typically maps to a **database table**. |
| **Why do we need it?** | Without models, there's no structured way to represent data. You'd be working with raw strings and dictionaries — error-prone and unmaintainable. |
| **What if we remove it?** | Entity Framework won't know what tables to create. No database mapping. No data validation. |
| **Also called** | Entities, Domain Objects, Data Models |

#### Data Annotations (Validation):

| Annotation | Purpose | Example |
|------------|---------|---------|
| `[Required]` | Field cannot be null/empty | `[Required] public string Name` |
| `[StringLength(100)]` | Max string length | Limits to 100 characters |
| `[Range(1, 150)]` | Numeric range | Age between 1 and 150 |
| `[EmailAddress]` | Must be valid email | Auto-validates email format |
| `[Phone]` | Must be valid phone | Auto-validates phone format |
| `[Key]` | Primary key | Used when not following convention |
| `[ForeignKey]` | Foreign key | Links to another table |
| `[Table("TableName")]` | Custom table name | Override default naming |
| `[Column("ColumnName")]` | Custom column name | Override default naming |

---

### 📁 `Views/` — The UI / The Plate

Views are **Razor templates** (`.cshtml`) that generate HTML. They combine C# code with HTML.

#### Folder Structure:

```
Views/
├── Shared/                      ← Shared across ALL controllers
│   ├── _Layout.cshtml           ← Master page template
│   ├── _ValidationScriptsPartial.cshtml  ← Validation jQuery scripts
│   └── Error.cshtml             ← Error page
│
├── Home/                        ← Views for HomeController
│   ├── Index.cshtml             ← Home page
│   └── Privacy.cshtml           ← Privacy page
│
├── Students/                    ← Views for StudentsController
│   ├── Index.cshtml             ← List all students
│   ├── Details.cshtml           ← View one student
│   ├── Create.cshtml            ← Create form
│   ├── Edit.cshtml              ← Edit form
│   └── Delete.cshtml            ← Delete confirmation
│
├── _ViewImports.cshtml          ← Global using statements for views
└── _ViewStart.cshtml            ← Default layout for all views
```

#### Example View (`Views/Students/Index.cshtml`):

```html
@model IEnumerable<Student>

@{
    ViewData["Title"] = "Students";
}

<h1>Students</h1>

<a asp-action="Create" class="btn btn-primary">Add New Student</a>

<table class="table">
    <thead>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Actions</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var student in Model)
        {
            <tr>
                <td>@student.Name</td>
                <td>@student.Email</td>
                <td>
                    <a asp-action="Edit" asp-route-id="@student.Id">Edit</a>
                    <a asp-action="Details" asp-route-id="@student.Id">Details</a>
                    <a asp-action="Delete" asp-route-id="@student.Id">Delete</a>
                </td>
            </tr>
        }
    </tbody>
</table>
```

| File | What | Why | If Removed |
|------|------|-----|------------|
| **`_Layout.cshtml`** | Master page — header, footer, navigation, common CSS/JS. Contains `@RenderBody()` where child views are inserted. | Avoid repeating the same HTML (nav, footer) on every page. | Every page loses its navigation, CSS, JavaScript. Pages look broken. |
| **`_ViewImports.cshtml`** | Global `@using` and `@addTagHelper` statements. | Avoids writing `@using SimpleMVCApp.Models` on every single view. | You'd have to add `@using` on every view manually. Tag helpers (`asp-action`, `asp-for`) stop working. |
| **`_ViewStart.cshtml`** | Sets the default layout: `@{ Layout = "_Layout"; }` | Every view automatically uses `_Layout.cshtml` without specifying it. | Every view would need `@{ Layout = "_Layout"; }` manually, or would render without any layout. |
| **`Error.cshtml`** | Error display page. | Shows friendly error messages to users instead of raw exceptions. | Users see ugly developer error pages or blank screens. |
| **View per Action** | Each controller action has a matching view (by convention). | Convention over configuration — no need to specify which view to use. | Controller returns `View()` but can't find the `.cshtml` file → 500 error. |

#### Razor Syntax Quick Reference:

| Syntax | Purpose | Example |
|--------|---------|---------|
| `@` | Output C# expression | `@Model.Name` |
| `@{ }` | C# code block | `@{ var x = 5; }` |
| `@if` | Conditional | `@if (Model.Count > 0) { }` |
| `@foreach` | Loop | `@foreach (var s in Model) { }` |
| `@model` | Declare model type | `@model Student` |
| `@Html.DisplayFor()` | Display formatted value | `@Html.DisplayFor(m => m.Name)` |
| `@Html.EditorFor()` | Input field for property | `@Html.EditorFor(m => m.Name)` |
| `asp-action` | Tag helper for action URL | `<a asp-action="Edit">` |
| `asp-controller` | Tag helper for controller | `<a asp-controller="Students">` |
| `asp-for` | Bind input to model property | `<input asp-for="Name" />` |
| `asp-validation-for` | Validation message | `<span asp-validation-for="Name">` |

---

## 7.5 Additional Layers (Enterprise Architecture)

These folders are **not part of the basic MVC pattern** but are added in real-world projects for better architecture.

### 📁 `DTOs/` — Data Transfer Objects

```csharp
// What the user sends to CREATE a student
public class StudentCreateDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public int Age { get; set; }
}

// What we send back to DISPLAY a student
public class StudentReadDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string FullInfo => $"{Name} ({Email})";
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | Special classes that define **what data goes in/out** — separate from the database model. |
| **Why do we need it?** | 1) **Security:** Don't expose all database columns (e.g., password hash). 2) **Flexibility:** Input shape differs from output shape. 3) **Validation:** Different rules for Create vs Update. |
| **What if we remove it?** | You'd pass your Model (entity) directly — exposing sensitive fields, mixing validation rules, creating tight coupling between UI and database. |
| **Types** | `CreateDTO` (for creating), `UpdateDTO` (for updating), `ReadDTO` (for reading/display) |

### 📁 `Service/` — Business Logic Layer

```csharp
// Interface (contract)
public interface IStudentService
{
    IEnumerable<StudentReadDTO> GetAll();
    StudentReadDTO GetById(int id);
    void Add(StudentCreateDTO dto);
    void Update(int id, StudentUpdateDTO dto);
    void Delete(int id);
}

// Implementation
public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<StudentReadDTO> GetAll()
    {
        var students = _repository.GetAll();
        return _mapper.Map<IEnumerable<StudentReadDTO>>(students);
    }

    public void Add(StudentCreateDTO dto)
    {
        // Business Logic Example: Check if email already exists
        if (_repository.EmailExists(dto.Email))
            throw new Exception("Email already registered!");

        var student = _mapper.Map<Student>(dto);
        student.EnrollmentDate = DateTime.Now; // Business rule
        _repository.Add(student);
        _repository.Save();
    }
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | Contains **business logic** — the rules and workflows of your application. |
| **Why do we need it?** | Keeps Controllers thin. Business rules are centralized, reusable, and testable. |
| **What if we remove it?** | Business logic moves to Controllers — they become fat, hard to test, and code gets duplicated across controllers. |
| **Pattern** | Always create an **Interface** (`IStudentService`) and an **Implementation** (`StudentService`) for dependency injection. |

### 📁 `Repository/` — Data Access Layer

```csharp
// Interface
public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
    Student GetById(int id);
    void Add(Student student);
    void Update(Student student);
    void Delete(Student student);
    bool EmailExists(string email);
    void Save();
}

// Implementation
public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Student> GetAll()
        => _context.Students.ToList();

    public Student GetById(int id)
        => _context.Students.Find(id);

    public void Add(Student student)
        => _context.Students.Add(student);

    public void Save()
        => _context.SaveChanges();
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | Handles **all database operations** (CRUD). It's the ONLY place that talks to the database. |
| **Why do we need it?** | Abstracts database access. If you switch from SQL Server to PostgreSQL, only the repository changes — not the service or controller. |
| **What if we remove it?** | Database code scattered everywhere. Changing the database means changing every file. Impossible to unit test. |
| **Principle** | Repository isolates the data access layer. Service talks to Repository, NEVER directly to DbContext. |

### 📁 `Data/` — Database Context

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }      // → Students table
    public DbSet<Course> Courses { get; set; }         // → Courses table

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API configurations
        modelBuilder.Entity<Student>()
            .HasIndex(s => s.Email)
            .IsUnique();                               // Unique email constraint
    }
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | The **bridge between your code and the database**. It's an Entity Framework Core class that represents a session with the database. |
| **Why do we need it?** | Without it, Entity Framework can't create tables, run queries, or track changes. |
| **What if we remove it?** | No database access at all. No tables, no queries, no data. |
| **`DbSet<T>`** | Each `DbSet<T>` represents a **table** in the database. |
| **`OnModelCreating`** | Configure relationships, constraints, seed data using Fluent API. |

### 📁 `Mapping/` — AutoMapper Profiles

```csharp
public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentReadDTO>();       // Model → ReadDTO
        CreateMap<StudentCreateDTO, Student>();     // CreateDTO → Model
        CreateMap<StudentUpdateDTO, Student>();     // UpdateDTO → Model
    }
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | Defines how to **convert** one object type to another (Model ↔ DTO). |
| **Why do we need it?** | Without AutoMapper, you'd manually write `dto.Name = student.Name; dto.Email = student.Email;` for every property, every time. Tedious and error-prone. |
| **What if we remove it?** | You'd have to write manual mapping code everywhere. More code, more bugs, more maintenance. |

### 📁 `Migrations/` — Database Version Control

```
Migrations/
├── 20240101120000_InitialCreate.cs          ← First migration
├── 20240115080000_AddAgeColumn.cs           ← Added Age column
├── 20240201100000_AddCourseTable.cs         ← Added Course table
└── AppDbContextModelSnapshot.cs             ← Current state of the model
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | **Git for your database.** Each migration is a version of your database schema. |
| **Why do we need it?** | Track database changes over time. Multiple developers stay in sync. Roll back changes if something goes wrong. |
| **What if we remove it?** | You'd have to manually write SQL scripts to change the database. No version history, no rollback capability. |
| **Commands** | `dotnet ef migrations add MigrationName` (create), `dotnet ef database update` (apply) |

### 📁 `Properties/` — Launch Settings

```json
// Properties/launchSettings.json
{
  "profiles": {
    "SimpleMVCApp": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | Defines **how the app launches** during development — URLs, ports, environment, browser settings. |
| **Why do we need it?** | Developers can configure their local environment without affecting others. |
| **What if we remove it?** | App will use default settings. You won't be able to configure ports or environment easily during development. |

### 📁 `wwwroot/` — Static Files

```
wwwroot/
├── css/
│   └── site.css              ← Your custom styles
├── js/
│   └── site.js               ← Your custom JavaScript
├── lib/
│   ├── bootstrap/            ← Bootstrap CSS framework
│   ├── jquery/               ← jQuery library
│   └── jquery-validation/    ← Client-side validation
├── images/                   ← Image assets
└── favicon.ico               ← Browser tab icon
```

| Aspect | Detail |
|--------|--------|
| **What is it?** | The **web root** — the ONLY folder accessible directly from the browser. Static files (CSS, JS, images) live here. |
| **Why do we need it?** | Browsers need CSS/JS/images. These must be served as static files, not processed by MVC. |
| **What if we remove it?** | No CSS = ugly unstyled pages. No JS = no client-side interactivity. No images = broken image links. |
| **Security** | Files outside `wwwroot/` cannot be accessed by the browser. Your C# source code is safe. |

### 📁 `bin/` and `obj/` — Build Output

| Folder | Detail |
|--------|--------|
| **`bin/`** | Contains the **compiled output** (DLLs) — the actual runnable application. |
| **`obj/`** | Contains **intermediate build files** used during compilation. |
| **Can you delete them?** | Yes! They are auto-generated. Deleting them and rebuilding is a common troubleshooting step. |
| **Should you commit them?** | **Never.** They should be in `.gitignore`. |

---

## 7.6 Complete Architecture Diagram

```
┌─────────────────────────────────────────────────────────────────────────┐
│                            BROWSER (Client)                             │
│                    User clicks, types, submits forms                     │
└───────────────────────────────────┬─────────────────────────────────────┘
                                    │ HTTP Request
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                          PROGRAM.CS (Entry Point)                        │
│              Middleware Pipeline: Auth → Routing → Static Files           │
└───────────────────────────────────┬─────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                         CONTROLLER (Thin Layer)                          │
│                                                                          │
│   • Receives HTTP request                                                │
│   • Validates ModelState                                                 │
│   • Calls Service layer                                                  │
│   • Returns View / Redirect / JSON                                       │
└──────────────────────┬──────────────────────────┬───────────────────────┘
                       │                          │
                DTO goes down              Result comes up
                       │                          │
                       ▼                          │
┌──────────────────────────────────┐              │
│       SERVICE (Business Logic)    │              │
│                                   │              │
│   • Applies business rules        │              │
│   • Validates business logic      │              │
│   • Transforms DTOs ↔ Models      │              │
│   • Uses AutoMapper (Mapping/)    │              │
└──────────────┬───────────────────┘              │
               │                                   │
               ▼                                   │
┌──────────────────────────────────┐              │
│    REPOSITORY (Data Access)       │              │
│                                   │              │
│   • CRUD operations               │              │
│   • LINQ queries                  │              │
│   • Only layer touching DbContext │              │
└──────────────┬───────────────────┘              │
               │                                   │
               ▼                                   │
┌──────────────────────────────────┐              │
│    DATA (AppDbContext)            │              │
│                                   │              │
│   • DbSet<T> = Tables            │              │
│   • OnModelCreating = Config      │              │
│   • Migrations = DB versioning    │              │
└──────────────┬───────────────────┘              │
               │                                   │
               ▼                                   │
┌──────────────────────────────────┐              │
│       DATABASE (SQL Server)       │              │
└──────────────────────────────────┘              │
                                                   │
                                                   ▼
                                    ┌──────────────────────────────┐
                                    │       VIEW (.cshtml)          │
                                    │                               │
                                    │   • Receives Model/DTO        │
                                    │   • Renders HTML using Razor  │
                                    │   • Uses _Layout.cshtml       │
                                    │   • Static files from wwwroot │
                                    └──────────────────────────────┘
```

---

# 8. Enterprise & Industrial Usage Patterns

MVC is used extensively in enterprise and industrial applications. Here are the different ways companies use it:

## 8.1 Standard MVC (Small to Medium Apps)

```
Controller → Model → View
```

- Direct database access from controller
- Suitable for: small business websites, portfolios, blogs
- Team size: 1–3 developers

## 8.2 Layered/N-Tier Architecture (Most Common Enterprise Pattern)

```
Controller → Service → Repository → Database
                ↕
             Mapping (AutoMapper)
                ↕
              DTOs
```

This is what **your project uses**. It's the most popular enterprise pattern.

| Layer | Responsibility | Benefit |
|-------|---------------|---------|
| Controller | HTTP handling only | Thin, easy to test |
| Service | Business logic | Centralized rules |
| Repository | Data access | Swappable data source |
| DTO | Data transfer | Security, flexibility |
| Mapping | Object conversion | Less manual code |

- Suitable for: ERP systems, HRMS, CRM, e-commerce
- Team size: 3–15 developers

## 8.3 Clean Architecture (Uncle Bob's Pattern)

```
                    ┌──────────────────────────┐
                    │    External (UI, DB)      │
                    │  ┌────────────────────┐   │
                    │  │   Interface Adapters│   │
                    │  │  ┌──────────────┐  │   │
                    │  │  │  Use Cases    │  │   │
                    │  │  │  ┌────────┐  │  │   │
                    │  │  │  │Entities│  │  │   │
                    │  │  │  └────────┘  │  │   │
                    │  │  └──────────────┘  │   │
                    │  └────────────────────┘   │
                    └──────────────────────────┘
```

**Projects structure:**
```
Solution/
├── Domain/              ← Entities, Interfaces (ZERO dependencies)
├── Application/         ← Use Cases, DTOs, Service Interfaces
├── Infrastructure/      ← Database, External APIs, File System
└── WebUI/               ← MVC Controllers, Views
```

- Dependencies point **inward** — UI depends on Application, Application depends on Domain
- Domain has **zero** external dependencies
- Suitable for: large enterprise apps, banking, healthcare
- Team size: 10–50+ developers

## 8.4 Microservices with MVC

```
                    ┌─ User Service (MVC API) ──► User DB
                    │
API Gateway ────────┼─ Order Service (MVC API) ──► Order DB
                    │
                    └─ Payment Service (MVC API) ──► Payment DB
```

- Each service is a separate MVC application
- Each has its own database
- Communicate via HTTP/gRPC/Message Queues
- Suitable for: Netflix, Amazon, Uber-scale applications
- Team size: 50+ developers (each team owns a service)

## 8.5 MVC + Web API (Hybrid)

```
Same Project:
├── Controllers/
│   ├── HomeController.cs          ← Returns Views (MVC)
│   └── Api/
│       └── StudentsApiController.cs  ← Returns JSON (API)
```

- One app serves both **web pages** (Views) and **JSON API** (for mobile apps, SPAs)
- Suitable for: apps that need both a website and mobile app
- Very common in modern development

## 8.6 MVC + SPA Frontend (Modern Approach)

```
┌──────────────────────┐         ┌──────────────────────┐
│   Frontend (SPA)      │  JSON   │   Backend (MVC API)   │
│   React / Angular     │ ◄─────► │   ASP.NET Core MVC    │
│   Vue.js / Blazor     │  HTTP   │   Returns JSON only   │
└──────────────────────┘         └──────────────────────┘
```

- MVC backend serves only as an API (no Views)
- Frontend is a separate application (React, Angular, Vue)
- Suitable for: modern web apps, dashboards, social media platforms

## 8.7 CQRS + MVC (Advanced Enterprise)

```
                    ┌─── Query Handler ──► Read DB (optimized for reading)
Controller ─────────┤
                    └─── Command Handler ──► Write DB (optimized for writing)
```

**CQRS = Command Query Responsibility Segregation**

- Separates READ operations from WRITE operations
- Each uses its own optimized database/model
- Suitable for: high-traffic systems, event sourcing, financial systems

## Enterprise Pattern Comparison

| Pattern | Complexity | Team Size | App Scale | Example |
|---------|-----------|-----------|-----------|---------|
| Standard MVC | ⭐ | 1–3 | Small | Personal blog |
| N-Tier/Layered | ⭐⭐ | 3–15 | Medium | HRMS, ERP |
| Clean Architecture | ⭐⭐⭐ | 10–50 | Large | Banking system |
| Microservices | ⭐⭐⭐⭐ | 50+ | Massive | Netflix, Amazon |
| MVC + SPA | ⭐⭐⭐ | 5–30 | Medium-Large | Modern web apps |
| CQRS | ⭐⭐⭐⭐⭐ | 20+ | Large-Massive | Stock trading |

---

# 9. Interview Q&A — Everything You Should Know

## Basic Questions

### Q1: What is MVC?
**A:** MVC (Model-View-Controller) is a software design pattern that separates an application into three components: **Model** (data/business logic), **View** (UI/presentation), and **Controller** (handles input, coordinates between Model and View). This separation of concerns makes code organized, testable, and maintainable.

### Q2: Why do we use MVC instead of Web Forms?
**A:** MVC provides:
- Full control over HTML output
- Better testability (unit testing controllers)
- Clean URL routing (SEO-friendly)
- Separation of concerns
- No heavy ViewState
- Following modern web standards

### Q3: What is Razor?
**A:** Razor is a **markup syntax** used in ASP.NET Core MVC Views (`.cshtml` files) that lets you embed C# code within HTML using the `@` symbol. It's compiled at runtime into HTML and sent to the browser. The browser never sees C# code.

### Q4: What is the difference between `ViewData`, `ViewBag`, and `TempData`?

| Feature | ViewData | ViewBag | TempData |
|---------|----------|---------|----------|
| **Type** | `ViewDataDictionary` | `dynamic` wrapper over ViewData | `TempDataDictionary` |
| **Casting** | Requires casting | No casting needed | Requires casting |
| **Lifespan** | Current request only | Current request only | Current + next request |
| **Use Case** | Pass small data to View | Same as ViewData (syntactic sugar) | Pass data between two requests (e.g., redirect) |
| **Example** | `ViewData["Name"] = "John"` | `ViewBag.Name = "John"` | `TempData["Message"] = "Saved!"` |

### Q5: What is the difference between `return View()` and `return RedirectToAction()`?
**A:**
- `return View()` — Renders a `.cshtml` View and returns HTML. Same request.
- `return RedirectToAction("Index")` — Sends a **302 redirect** to the browser, which makes a **new request** to the specified action. Two requests total. Follows the **PRG (Post-Redirect-Get)** pattern to prevent double form submission.

### Q6: What is Model Binding?
**A:** Model Binding automatically maps **HTTP request data** (form fields, query strings, route values, JSON body) to C# method parameters or model objects. When a user submits a form, MVC automatically creates a C# object from the form data.

```csharp
// MVC automatically creates a 'student' object from form data
[HttpPost]
public IActionResult Create(Student student)  // ← Model Binding happens here
```

### Q7: What are Tag Helpers?
**A:** Tag Helpers are **server-side attributes** that make HTML elements smart. They look like normal HTML attributes but are processed on the server.

```html
<!-- Without Tag Helpers (old way) -->
@Html.ActionLink("Edit", "Edit", new { id = Model.Id })

<!-- With Tag Helpers (modern way) -->
<a asp-action="Edit" asp-route-id="@Model.Id">Edit</a>
```

## Intermediate Questions

### Q8: What is the MVC Request Pipeline?
**A:**
1. Browser sends HTTP request
2. Kestrel web server receives it
3. Middleware pipeline processes it (authentication, logging, etc.)
4. Routing engine maps URL to Controller/Action
5. Model Binding converts request data to C# objects
6. Action Filters run (if any)
7. Action method executes
8. Result (View/JSON/Redirect) is generated
9. Response sent back to browser

### Q9: What are Action Filters?
**A:** Action Filters are **attributes** that run code **before or after** an action method executes. They're used for cross-cutting concerns.

| Filter Type | When It Runs | Example Use |
|-------------|-------------|-------------|
| `Authorization` | Before everything | Check user permissions |
| `Resource` | Before model binding | Caching |
| `Action` | Before/after action | Logging, validation |
| `Exception` | When exception occurs | Global error handling |
| `Result` | Before/after result execution | Modify the response |

### Q10: What is Dependency Injection (DI)?
**A:** DI is a technique where objects receive their dependencies **from outside** rather than creating them internally. ASP.NET Core has a built-in DI container.

```csharp
// In Program.cs — Register services
builder.Services.AddScoped<IStudentService, StudentService>();

// In Controller — Receive service automatically
public class StudentsController : Controller
{
    private readonly IStudentService _service;

    public StudentsController(IStudentService service) // ← DI injects this
    {
        _service = service;
    }
}
```

**Service Lifetimes:**

| Lifetime | Behavior | Use For |
|----------|----------|---------|
| `AddScoped` | One instance per HTTP request | Database contexts, services |
| `AddTransient` | New instance every time it's requested | Lightweight, stateless services |
| `AddSingleton` | One instance for the entire application lifetime | Configuration, caching |

### Q11: What is Areas in MVC?
**A:** Areas are a way to organize a large MVC application into smaller functional groups, each with its own Controllers, Views, and Models.

```
Areas/
├── Admin/
│   ├── Controllers/
│   ├── Views/
│   └── Models/
├── Customer/
│   ├── Controllers/
│   ├── Views/
│   └── Models/
```

### Q12: What is the Repository Pattern and why is it used?
**A:** Repository Pattern **abstracts database access** into a separate layer. Benefits:
1. **Single Responsibility** — Only repository touches the database
2. **Testability** — Mock the repository in unit tests
3. **Swappability** — Change SQL Server to PostgreSQL by changing only the repository
4. **Reusability** — Same repository used by multiple services

## Advanced Questions

### Q13: What is the difference between `IActionResult` and `ActionResult<T>`?
**A:**
- `IActionResult` — Can return **any** result type (View, JSON, Redirect, File, etc.)
- `ActionResult<T>` — Returns either the specific type `T` or an `IActionResult`. Provides **type safety** and better Swagger documentation for APIs.

### Q14: How does Routing work in ASP.NET Core MVC?
**A:** Two types:

**Convention-based Routing** (defined in `Program.cs`):
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// /students/edit/5 → StudentsController.Edit(5)
```

**Attribute Routing** (defined on controllers/actions):
```csharp
[Route("api/[controller]")]
public class StudentsController : Controller
{
    [HttpGet("{id}")]  // GET api/students/5
    public IActionResult GetById(int id) { ... }
}
```

### Q15: What are Partial Views?
**A:** Reusable View components that can be embedded in other Views. Like a "sub-view."

```html
<!-- In a parent view -->
<partial name="_StudentCard" model="student" />
```

### Q16: What are View Components?
**A:** Like Partial Views but with **their own controller-like logic**. They have a `class` + a `view`. Used for complex reusable UI like navigation menus, shopping carts, sidebar widgets.

```csharp
public class ShoppingCartViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var items = GetCartItems();
        return View(items);
    }
}
```
```html
<!-- In a view -->
@await Component.InvokeAsync("ShoppingCart")
```

### Q17: What is Middleware?
**A:** Middleware are **components that form a pipeline** — each request passes through them in order. Each middleware can process the request, pass it to the next one, or short-circuit the pipeline.

```
Request  →  [Logging] → [Authentication] → [Authorization] → [Routing] → [Controller]
Response ←  [Logging] ← [Authentication] ← [Authorization] ← [Routing] ← [Controller]
```

### Q18: What is Anti-Forgery Token?
**A:** A security mechanism to prevent **CSRF (Cross-Site Request Forgery)** attacks. It generates a unique token for each form. When the form is submitted, the server validates the token to ensure the request came from your own site, not a malicious site.

```html
<form asp-action="Create" method="post">
    @Html.AntiForgeryToken()   <!-- Automatically added by Tag Helpers -->
</form>
```
```csharp
[HttpPost]
[ValidateAntiForgeryToken]  // ← Validates the token
public IActionResult Create(Student student) { ... }
```

### Q19: Can MVC and Web API exist in the same project?
**A:** Yes! In ASP.NET Core, MVC and Web API are **unified**. The same controller can return Views (for browsers) and JSON (for API consumers). Use `[ApiController]` attribute to mark API-only controllers.

### Q20: What is the difference between `AddMvc()`, `AddControllers()`, and `AddControllersWithViews()`?

| Method | What It Registers | Use For |
|--------|-------------------|---------|
| `AddControllers()` | Controllers only (no View support) | Web API only |
| `AddControllersWithViews()` | Controllers + Razor Views | MVC with Views |
| `AddRazorPages()` | Razor Pages | Page-based apps |
| `AddMvc()` | Everything (Controllers + Views + Razor Pages) | Full-featured apps |

---

# 10. Glossary of Terms

| Term | Definition |
|------|-----------|
| **MVC** | Model-View-Controller — a design pattern for separating concerns |
| **Razor** | A C#/HTML templating engine for generating dynamic web pages |
| **DbContext** | Entity Framework class that represents a session with the database |
| **Entity** | A C# class that maps to a database table (a Model) |
| **DTO** | Data Transfer Object — a class used to transfer data between layers |
| **DI** | Dependency Injection — providing dependencies from outside a class |
| **IoC** | Inversion of Control — the principle behind DI |
| **ORM** | Object-Relational Mapping — maps objects to database tables (e.g., EF Core) |
| **EF Core** | Entity Framework Core — Microsoft's ORM for .NET |
| **LINQ** | Language Integrated Query — C# syntax for querying data |
| **Middleware** | Pipeline components that process HTTP requests/responses |
| **Routing** | The system that maps URLs to controller actions |
| **Model Binding** | Automatic mapping of HTTP data to C# objects |
| **Tag Helpers** | Server-side attributes that enhance HTML elements |
| **ViewData** | Dictionary for passing data from Controller to View |
| **ViewBag** | Dynamic wrapper around ViewData |
| **TempData** | Data that survives one redirect (uses session/cookies) |
| **Partial View** | A reusable sub-view embedded in other views |
| **View Component** | A reusable UI component with its own logic |
| **Action Filter** | Code that runs before/after controller actions |
| **CSRF** | Cross-Site Request Forgery — a security attack MVC prevents |
| **CORS** | Cross-Origin Resource Sharing — controls API access from other domains |
| **Kestrel** | ASP.NET Core's built-in cross-platform web server |
| **NuGet** | .NET's package manager (like npm for JavaScript) |
| **Scaffold** | Auto-generate CRUD code from a model |
| **Migration** | Version-controlled database schema change |
| **Seed Data** | Initial data inserted into the database during migration |
| **PRG Pattern** | Post-Redirect-Get — prevents double form submission |
| **SoC** | Separation of Concerns — each component has one responsibility |
| **N-Tier** | Multi-layered architecture (Presentation → Business → Data) |
| **Clean Architecture** | Architecture where domain is at the center with no dependencies |
| **CQRS** | Command Query Responsibility Segregation — separate read/write models |

---

> **🎯 Summary:** MVC is a **design pattern** that separates data (Model), UI (View), and input handling (Controller). It was invented in 1979 and became the standard for web development. ASP.NET Core MVC is Microsoft's modern implementation. In enterprise, it's used with additional layers (Service, Repository, DTO) for scalability and maintainability. Master the concepts above, and you'll be ready for any MVC-related question.
