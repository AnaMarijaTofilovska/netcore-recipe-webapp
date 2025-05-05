# Recipe Finder Web App – .NET Core & API Integration

Welcome to the **Recipe Finder Web App**, a modern .NET Core-based web application that helps users discover and explore delicious recipes through seamless integration with a third-party food API.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Usage](#usage)
- [Technologies Used](#technologies-used)
- [External API](#external-api)
- [Contributing](#contributing)
- [License](#license)

## Introduction

**Recipe Finder** is a web application built with ASP.NET Core that allows users to browse a variety of recipes, view ingredients and instructions, and manage their favorite dishes. The app dynamically pulls content using a third-party recipe API, including recipe titles, images, and cooking instructions.

## Features

- 🔎 **Recipe Search** – Discover recipes from a wide selection of categories.
- 📸 **Dynamic Content** – Recipes, images, and instructions are loaded via an external food API.
- ⭐ **Favorites System** – Save and manage your favorite dishes.
- 🧾 **Detailed View** – See ingredients, preparation steps, and images for each recipe.
- 🎨 **Clean UI** – Built with a responsive and user-friendly interface.

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)

### Installation

1. Clone the repository:
 
   git clone https://github.com/AnaMarijaTofilovska/netcore-recipe-webapp.git


2. Open the solution in **Visual Studio 2022**.

3. Set up your database using **SQL Server Management Studio**.

4. Configure the external API key (see below).

5. Build and run the project using IIS Express or Kestrel.

### Usage

1. Register or log in to your account.
2. Browse or search for recipes by keyword or ingredient.
3. View recipe details including ingredients, steps, and images.
4. Save favorite recipes for quick access later.

## Technologies Used

* **C#** / **.NET 7.0**
* **ASP.NET MVC**
* **Entity Framework Core**
* **HTML**, **CSS**, **JavaScript**
* **jQuery**
* **SQL Server**

## External API

This project uses a third-party food and recipe API to fetch recipe data, images, and nutritional details.

> ⚠️ **Note**: This project uses a public food recipe API to fetch recipes and images. An API key is required, which you can obtain by signing up on a free recipe API provider (e.g., Spoonacular, Edamam, etc.). Once you have a key, place it in the `appsettings.json` file as shown below:

"RecipeApi": {
  "BaseUrl": "https://api.example.com",
  "ApiKey": "your-api-key-here"
}

## Contributing

Contributions are welcome! 🎉

1. Fork the repository
2. Create a feature branch

   git checkout -b feature/your-feature

3. Commit your changes
   
   git commit -m "Add your feature"

5. Push to your branch

   git push origin feature/your-feature
  
6. Open a pull request 🚀

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.


