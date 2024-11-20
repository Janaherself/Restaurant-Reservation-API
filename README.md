# 🍽 Restaurant Reservation API

<p>Welcome to the amazing <strong>Restaurant Reservation API</strong>! a robust and scalable solution for managing restaurant reservations, employee data, and orders. This API provides a seamless way to perform CRUD operations, access specialized endpoints for unique business needs, and ensure secure and efficient handling of restaurant operations.</p>

<br>

## 🚀 Features
### Core Functionalities

<ul>
  <li><strong>CRUD Operations</strong>: Manage entities like customers, employees, reservations, restaurants, orders, and menu items.</li>
  <li><strong>Specialized Endpoints</strong>:
    <ul>
      <li><code>GET /api/employees/managers</code>: List all managers.</li>
      <li><code>GET /api/reservations/customer/{customerId}</code>: Retrieve reservations by a specific customer ID.</li>
      <li><code>GET /api/reservations/{reservationId}/orders</code>: List orders and menu items for a reservation.</li>
      <li><code>GET /api/reservations/{reservationId}/menu-items</code>: List ordered menu items for a reservation.</li>
      <li><code>GET /api/employees/{employeeId}/average-order-amount</code>: Calculate the average order amount handled by an employee.</li>
    </ul>
  </li>
</ul>

<br>

### Additional Features
<ul>
  <li><strong>User Input Validation</strong>: Ensures only valid data is processed, with meaningful error messages for invalid inputs.</li>
  <li><strong>JWT Authorization</strong>: Secure API access with JSON Web Tokens (JWT) for role-based and authenticated operations.</li>
  <li><strong>Swagger Documentation</strong>: Interactive and user-friendly API documentation for easy onboarding and integration.</li>
</ul>

<br>

## 🛠️ Technologies Used
<ul>
  <li><strong>Backend Framework</strong>: ASP.NET Core 8</li>
  <li><strong>Database</strong>: SQL Server (with Entity Framework Core for ORM)</li>
  <li><strong>Authentication</strong>: JWT-based security</li>
  <li><strong>Documentation</strong>: Swagger/OpenAPI</li>
  <li><strong>Error Handling</strong>: Centralized and user-friendly error messages</li>
  <li><strong>Validation</strong>: FluentValidation for robust input checks</li>
  <li><strong>Object Mappings</strong>: AutoMapper for mapping DTO objects to database entities</li>
</ul>

<br>

## 🔒 Authentication & Authorization
<p>This API uses <strong>JWT Authorization</strong> to secure endpoints and ensure data privacy. Users must authenticate to access most endpoints.</p>

### How it Works
<ol>
  <li>Obtain a JWT token by logging in with valid credentials.</li>
  <li>Use the token in the <code>Authorization</code> header to access protected endpoints.</li>
  <li>Tokens include role-based claims to limit access where necessary.</li>
</ol>

<br>

## 👩‍💻 Contributors
<ul>
  <li><strong><a href="https://github.com/janaherself">Jana</a></strong></li>
</ul>
<p>Join me! and feel free to submit issues and pull requests for improvements and bug fixes.</p>

<br>

## 📜 License
<p>This project is licensed under the <strong>JIT License</strong>. -AKA Janas Institute of Technology!</p>
