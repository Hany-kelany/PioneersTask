# Pioneer Solutions - Employee Management System
![Alt text](images/home page.png)
[Video Link](https://drive.google.com/file/d/1q-LH0joPDhhEvz9K_snEk6NXsB9Jv6Kl/view?usp=sharing)
![Pioneer Solutions](https://img.shields.io/badge/Pioneer-Solutions-3498db?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3.0-purple?style=for-the-badge&logo=bootstrap)
![ASP.NET](https://img.shields.io/badge/ASP.NET-Core-blue?style=for-the-badge&logo=.net)

A modern, responsive employee management system built with ASP.NET Core and Bootstrap 5, featuring a clean and intuitive user interface designed for efficient workforce management.

## 🚀 Features


### Employee Management
- **Add New Employees** - Streamlined employee onboarding process
- **Employee list** - Complete listing of all employees
- **Custom Properties** - Flexible employee data customization

### Technical Features
- **Bootstrap 5.3.0** - Modern CSS framework for responsive design
- **Font Awesome 6.4.0** - Comprehensive icon library
- **ASP.NET Core MVC** - Robust server-side framework
- **Responsive Design** - Mobile-friendly hamburger menu
- **Active State Management** - Dynamic navigation highlighting

## 🛠️ Installation

### Prerequisites
- .NET 6.0 or higher
- Visual Studio 2022 or VS Code
- SQL Server (LocalDB or Full)

### Setup Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/pioneer-solutions.git
   cd pioneer-solutions
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Update Database Connection**
   ```json
   // appsettings.json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PioneerSolutions;Trusted_Connection=true"
     }
   }
   ```

4. **Run Database Migrations**
   ```bash
   dotnet ef database update
   ```

5. **Launch Application**
   ```bash
   dotnet run
   ```

6. **Access Application**
   Open your browser and navigate to `https://localhost:5001`

## 📁 Project Structure

```
PioneerSolutions/
├── Controllers/
│   ├── HomeController.cs
│   ├── EmployeeController.cs
│   └── CustomPropertyController.cs
├── Models/
│   ├── Employee.cs
│   ├── CustomProperty.cs
│   └── ViewModels/
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _NavBar.cshtml
│   ├── Home/
│   └── Employee/
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── Images/
│       └── Pioneerlogo.png
├── Data/
│   └── ApplicationDbContext.cs
└── README.md
```

### Custom Properties
Configure employee custom fields through the Custom Properties management interface.

## 📱 Responsive Design

The application is fully responsive with breakpoints:
- **Desktop**: >= 992px - Full horizontal navigation
- **Tablet**: 768px - 991px - Collapsible navigation
- **Mobile**: < 768px - Hamburger menu

## 🚀 Deployment

### Development
```bash
dotnet run --environment Development


## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines
- Follow C# coding conventions
- Use meaningful commit messages
- Add unit tests for new features
- Update documentation as needed

## 📝 Changelog

### Version 1.0.0 (Current)
- Initial release
- Modern navigation design
- Employee management features
- Responsive design implementation
- Custom properties system

- **Frontend Development** - Modern UI/UX with Bootstrap 5
- **Backend Development** - ASP.NET Core MVC architecture
- **Database Design** - SQL Server with Entity Framework

## 📞 Support

For support and questions:
- **Email**: support@pioneersolutions.com
- **Documentation**: [Wiki](https://github.com/your-username/pioneer-solutions/wiki)
- **Issues**: [GitHub Issues](https://github.com/your-username/pioneer-solutions/issues)

## 🙏 Acknowledgments

- [Bootstrap](https://getbootstrap.com/) for the responsive framework
- [Font Awesome](https://fontawesome.com/) for the icon library
- [ASP.NET Core](https://dotnet.microsoft.com/) for the robust backend framework

---

<div align="center">

**Pioneer Solutions**

[![Made with ❤️](https://img.shields.io/badge/Made%20with-❤️-red?style=for-the-badge)](https://github.com/your-username/pioneer-solutions)

</div>
