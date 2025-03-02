# FirmaXml/FirmaXml/README.md

# FirmaXml

FirmaXml is a microservice that provides an endpoint for signing XML documents using ECDSA (Elliptic Curve Digital Signature Algorithm). This project is designed to facilitate secure XML signing in applications.

## Features

- Exposes an API endpoint for signing XML documents.
- Utilizes ECDSA for secure digital signatures.
- Supports signing requests with custom XML content.

## Project Structure

- **Controllers**
  - `SignController.cs`: Contains the API controller for signing XML documents.
  
- **Models**
  - `SignRequest.cs`: Defines the request model for signing XML, including properties for XML content and metadata.
  
- **Services**
  - `XmlSignerService.cs`: Implements the logic for signing XML documents.
  
- **ECDsa256SignatureDescription.cs**: Provides ECDSA signing capabilities.
  
- **Program.cs**: Entry point of the application.
  
- **Startup.cs**: Configures services and middleware for the application.

## Setup Instructions

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```
   cd FirmaXml
   ```

3. Restore the dependencies:
   ```
   dotnet restore
   ```

4. Run the application:
   ```
   dotnet run
   ```

## Usage

To sign an XML document, send a POST request to the `/api/sign` endpoint with a JSON body containing the XML content and any necessary metadata.

### Example Request

```json
{
  "xmlContent": "<your-xml-content-here>",
  "metadata": {
    "key": "value"
  }
}
```

### Example Response

The response will contain the signed XML document.

## License

This project is licensed under the MIT License. See the LICENSE file for details.