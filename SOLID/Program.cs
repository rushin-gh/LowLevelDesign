internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

/*
    Principle           Key Idea	                                Example Fix
    SRP	        One class, one responsibility	            Separate policy, database, and notification logic
    OCP	        Extend without modifying	                Use polymorphism instead of if-else
    LSP	        Subtypes must be replaceable	            Use interfaces for optional behaviors
    ISP	        No unnecessary methods in interfaces	    Create small, focused interfaces
    DIP	        Depend on abstractions, not concretions	    Use interfaces and dependency injection 
*/