using System;

// Main program class that handles the shipping quote calculation application
class Program
{
    // Entry point of the application
    static void Main(string[] args)
    {
        // Create an instance of ShippingCalculator
        var calculator = new ShippingCalculator();
        
        // Start the quote calculation process
        calculator.CalculateShippingQuote();
    }
}

// Class responsible for handling shipping calculations and user interactions
class ShippingCalculator
{
    // Constants for validation limits
    private const int MaxWeight = 50;
    private const int MaxTotalDimensions = 50;
    
    // Method to handle the main flow of shipping quote calculation
    public void CalculateShippingQuote()
    {
        // Display welcome message
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
        
        // Get and validate package weight
        double weight = GetPackageWeight();
        if (weight > MaxWeight)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }
        
        // Get package dimensions
        double width = GetDimension("width");
        double height = GetDimension("height");
        double length = GetDimension("length");
        
        // Validate total dimensions
        if (width + height + length > MaxTotalDimensions)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }
        
        // Calculate and display shipping quote
        double quote = CalculateQuote(weight, width, height, length);
        DisplayQuote(quote);
    }
    
    // Method to get package weight from user
    private double GetPackageWeight()
    {
        Console.WriteLine("Please enter the package weight:");
        return Convert.ToDouble(Console.ReadLine());
    }
    
    // Method to get package dimensions from user
    private double GetDimension(string dimensionName)
    {
        Console.WriteLine($"Please enter the package {dimensionName}:");
        return Convert.ToDouble(Console.ReadLine());
    }
    
    // Method to calculate shipping quote based on package parameters
    private double CalculateQuote(double weight, double width, double height, double length)
    {
        return (width * height * length * weight) / 100;
    }
    
    // Method to display the final quote to user
    private void DisplayQuote(double quote)
    {
        Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
        Console.WriteLine("Thank you!");
    }
}