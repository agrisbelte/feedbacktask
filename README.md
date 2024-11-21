# Feedback Submission Task

## Authentication
- The app uses cookie-based local user authentication with a custom database provider and ASP.NET identity tables.
- Authentication setup is provided by the default Blazor template in Visual Studio.

## Database
- The app uses a local SQL Server database but can be deployed on Azure.
- A code-first approach with entities and migrations is used for table creation.
- In order to create tables run `update-database` in the Package Manager Console.

## Architecture
- The app is built in a single project for simplicity, but it follows a layered architecture using folders:
  - **Data**: Contains repositories, DbContext, and entities.
  - **Services**: Handles business logic and includes server-side validation for the feedback entity.
  - **Core**: Stores global models and constants shared across layers.
  - **Mappers and Validators**: These are separate folders and will eventually move into the Core project.
- The `FeedbackPage` inherits a custom `AuthenticatedComponentBase`, which provides access to the signed-in user's profile.
- All service and repository methods return `OperationResult<T>` for consistent error management.

## App Functionality
- The home page and side menu link to the Feedback Page, which requires user authentication.
- When submitting feedback, the app pre-fills the signed-in username in the "Customer Name" field.
- Feedback can be added via:
  - A blue "Add Feedback" button at the top.
  - A green "Add Feedback" button in the data grid.
- These were implemented separately because I started with a custom `AddFeedback` component and later integrated Radzen's data grid functionality.
- The `AddFeedback` component:
  - Uses `FeedbackModel` with Data Annotations for validation.
  - Uses Mapster to map the model to the entity.
- The data grid uses Radzen validation.
- FluentValidation is implemented in the business layer for advanced validation rules.

## Code Quality
- This is a proof-of-concept and not production-ready.
- Styling is minimal, focusing only on achieving the required functionality.
