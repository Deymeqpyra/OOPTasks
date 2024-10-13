using Lab9OOP;

namespace UnitTest;

public class UnitTestCalculator
{
    [Fact]
    public void should_return_three_from_add()
    {
        // arrange 
        var calc = new Calculator<int>();
        const int a = 1;
        const int b = 2;
        
        //act 
        var actualResult = calc.Add(a, b);
        
        // assert
        const int expectedResult = 3;
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void should_return_three_from_subtract()
    {
        var calc = new Calculator<int>();
        const int a = 6;
        const int b = 3;
        
        var actualResult = calc.Substract(a, b);
        
        const int expectedResult = 3;   
        Assert.Equal(expectedResult, actualResult);
    }
    [Fact]
    public void should_return_six_from_multiply()
    {
        var calc = new Calculator<int>();
        const int a = 3;
        const int b = 2;
        
        var actualResult = calc.Multiply(a, b);
        
        const int expectedResult = 6;   
        Assert.Equal(expectedResult, actualResult);
    }
    [Fact]
    public void should_return_three_from_devide()
    {
        var calc = new Calculator<double>();
        const double a = 6.0;
        const double b = 2.0;
        
        var actualResult = calc.Divide(a, b);
        
        const double expectedResult = 3.0;  
        Assert.Equal(expectedResult, actualResult);
    }
    [Fact]
    public void should_return_nine_from_pow()
    {
        var calc = new Calculator<double>();
        const double a = 3;
        const double b = 2;
        
        var actualResult = calc.Power(a, b);
        
        const double expectedResult = 9; 
        Assert.Equal(expectedResult, actualResult);
    }
}