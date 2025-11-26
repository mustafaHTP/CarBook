# CarBook

CarBook is a comprehensive car rental and blogging platform that allows users to rent cars, view detailed car information, leave reviews, and engage with blogs by browsing and commenting. The platform also includes an admin panel for managing car listings, moderating reviews, and overseeing blog interactions.

## Architecture & Design Patterns

* Onion Architecture
* CQRS (Command Query Responsibility Segregation)
* Mediator Pattern
* Repository Pattern
* Result Pattern

## Technologies Used

* SignalR - Real-time updates and notifications
* Gemini API - Car recommendations
* EF Core - Database management
* Fluent Validation - Ensuring data integrity

## 🔧 Features

### For Users

Users can rent cars, explore vehicle details, leave reviews, and interact with blog content through browsing and commenting.

### For Admins

Admins have control over car listings, review moderation, and blog management, ensuring a seamless experience for all users.

## Running Project

In this project, dotnet user-secrets is used. So you need to set couple of things:

1. ***[Necessary]*** Connection string
1. ***[Necessary]*** Applying migrations to database
1. ***[Optional]*** Gemini Api key (For car recommendation)

### 1. Setup connection string

1. Go to project *root* folder

2. Change directory to *web api* project

```bash
    cd CarBook.WebApi
```

3. Set connection string

```bash
    dotnet user-secrets set "ConnectionString" "YOUR_CONNECTION_STRING"
```

### 2. Applying migrations

 1. Go to project *root* folder

 2. Apply migrations

```bash
    dotnet ef database update --project .\CarBook.Persistence\ --startup-project .\CarBook.WebApi\
```

### 3. Setup Gemini Api Key

 1. Go to project *root* folder

 2. Change directory to *web app* project

```bash
    cd CarBook.WebApp
```

 3. Set gemini api key

```bash
    dotnet user-secrets set "SmartBookKey" "YOUR_API_KEY"
```

---

![ss_1](/docs/img/Screenshot_1.png)

![ss_2](/docs/img/Screenshot_2.png)

![ss_3](/docs/img/Screenshot_4.png)

![ss_4](/docs/img/Screenshot_7.png)

![ss_5](/docs/img/Screenshot_8.png)

![ss_6](/docs/img/Screenshot_9.png)

![ss_7](/docs/img/Screenshot_10.png)

![ss_8](/docs/img/Screenshot_11.png)

![ss_9](/docs/img/Screenshot_12.png)

![ss_10](/docs/img/Screenshot_13.png)

![ss_11](/docs/img/Screenshot_14.png)

![ss_12](/docs/img/Screenshot_15.png)

![ss_13](/docs/img/Screenshot_16.png)

![ss_14](/docs/img/Screenshot_17.png)
