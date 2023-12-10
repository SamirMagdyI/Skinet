# Skinet

Skinet is a comprehensive full-stack web application that demonstrates a modern e-commerce platform. Utilizing Angular for the frontend and ASP.NET Core for the backend, this project showcases a range of features and design patterns that are essential for today's web development standards.

## Features:
- **Product Catalog**: Users can browse through a variety of products with detailed descriptions and images.
- **Advanced Search**: Users can quickly find products with a dynamic search feature.
- **Pagination**: Products are displayed across multiple pages to improve user experience and performance.
- **Sorting**: Users can sort products based on different criteria such as price or name.
- **Filtering**: A robust filtering system allows users to narrow down their search to find exactly what they're looking for.
- **Shopping Cart**: A fully functional shopping cart is included to manage selected products before purchase.
- **Order Management**: Users can review their orders and track the status of each purchase.
- **Error Handling**

  
##preview
![image](https://github.com/SamirMagdyI/Skinet/assets/139062701/a8249971-b32a-4614-a430-73857b9c4ab7)

## Future Enhancements:
- **Stripe Payment Integration**: To evolve into a full-fledged e-commerce application, Stripe integration will be added for secure online payments.
- **Complete Unit Testing**: Ensuring the reliability of the application through comprehensive unit tests.
- **Admin Panel**: An admin panel for managing products, users, orders, etc., will be implemented for better control and maintenance of the application.

## Technologies & Design Patterns:
- **Angular**: The interactive frontend is built using Angular, providing a seamless user experience.
- **ASP.NET Core**: The backend API is developed with ASP.NET Core, offering robustness and scalability.
- **Entity Framework Core**: As the ORM for data persistence, it facilitates database operations.
- **Specification Pattern**: This pattern is used to encapsulate the logic for selecting entities from a database in a reusable way.
- **Generic Repository Pattern**: Abstracts the data layer, improving maintainability, scalability, and testability of the application.
- **Lazy Loading Pattern in Angular**: Improves performance on the client side by loading JavaScript components asynchronously as they are needed.
- **Multi-Layer Architecture**: The application is structured into multiple layers (API, Client, Core, Infrastructure) to separate concerns and enhance modularity.

## Project Structure:
- **API**: Contains the ASP.NET Core Web API project - the backend.
- **Client**: Contains the Angular project - the frontend.
- **Core**: Holds the core business logic and entities.
- **Infrastructure**: Implements the data access layer, repository, and specification patterns.

## Getting Started:
To set up the project locally, ensure that Node.js, .NET 5 SDK, and Angular CLI are installed.

1. Clone the repository:
   ```
   git clone https://github.com/SamirMagdyI/Skinet.git
   ```

2. Navigate to the project directory:
   ```
   cd Skinet
   ```

3. Install npm dependencies:
   ```
   npm install
   ```

4. Start the Angular frontend:
   ```
   ng serve
   ```

5. In a separate terminal, start the .NET Core backend:
   ```
   cd API
   dotnet run
   ```

6. Access the application at `http://localhost:4200/`.

## License:
This project is licensed under the MIT License.
