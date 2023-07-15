# CDNet - Content Delivery Network Application

CDNet is a Content Delivery Network (CDN) application built using DotNet. It is designed to efficiently distribute content across multiple servers, providing faster and more reliable delivery to end-users.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [API Specification](#api-specification)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Getting Started

To get started with CDNet, follow the instructions below.

### Prerequisites

Before using CDNet, ensure that the following dependencies are installed on your system:

- .NET version 7

### Installation

Follow these steps to install CDNet:

1. Clone the repository: `git clone https://github.com/Str1XHyper/CDNet.git`
2. Change to the project directory: `cd cdnet`

## Usage

To use CDNet, follow the guidelines below.

1. Make sure that in `CodeByT.CDNet.Controller/appsettings.json`, you change the DefaultConnection string so that it points to your database
2. Run CDNet using

```shell
$ dotnet watch
```

## API Specification

The CDNet API provides the following endpoints:

### `/image?id="id"`

This endpoint retrieves an image with the specified `id`.

- Method: GET
- Parameters:
  - `id` (string): The identifier of the image to retrieve.
- Response:
  - Success (200 OK): Returns the requested image.
  - Not Found (404 Not Found): If the image with the specified `id` does not exist.

### `/image/upload`

This endpoint allows uploading an image to CDNet.

- Method: POST
- Parameters:
  - `file` (binary): The image file to be uploaded.
- Response:
  - Success (201 Created): Returns the uploaded image URL.
  - Bad Request (400 Bad Request): If the request is invalid or the file upload fails.

Please ensure you provide the necessary authentication or authorization mechanisms for accessing the API endpoints.
**note** at the moment no authentication is required

## Contributing

We welcome contributions from the community to improve CDNet. If you'd like to contribute, please follow these steps:

1. Fork the repository on GitHub.
2. Create a new branch with a descriptive name: `git checkout -b feature/your-feature-name`.
3. Make your desired changes.
4. Test your changes thoroughly.
5. Commit your changes: `git commit -am 'Add some feature'`.
6. Push to the branch: `git push origin feature/your-feature-name`.
7. Create a new pull request.

Please ensure that your code adheres to the coding standards and includes appropriate documentation.

## License

CDNet is released under the [MIT License](LICENSE). You are free to use, modify, and distribute this software.

## Contact

If you have any questions, feedback, or suggestions regarding CDNet, please feel free to contact us:

- Email: [tijn.vanveghel@codebyt.nl]
- GitHub: [str1xhyper]

We appreciate your interest in CDNet and look forward to hearing from you!
