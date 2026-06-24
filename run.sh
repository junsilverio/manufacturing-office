#!/bin/bash

echo "=================================="
echo "Manufacturing Office - Quick Start"
echo "=================================="
echo ""

# Navigate to the Web project directory
cd "$(dirname "$0")/src/ManufacturingOffice.Web" || exit

echo "Building the application..."
dotnet build --configuration Release

if [ $? -eq 0 ]; then
    echo ""
    echo "✅ Build successful!"
    echo ""
    echo "Starting the application..."
    echo "The app will be available at:"
    echo "  - https://localhost:5001"
    echo "  - http://localhost:5000"
    echo ""
    echo "Press Ctrl+C to stop the application"
    echo ""
    dotnet run --no-build --configuration Release
else
    echo ""
    echo "❌ Build failed. Please check the errors above."
    exit 1
fi
