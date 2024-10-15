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
        const int expectedResult = 3;
        
        //act 
        var actualResult = calc.Add(a, b);
        
        // assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void should_return_three_from_subtract()
    {
        var calc = new Calculator<int>();
        const int a = 6;
        const int b = 3;
        const int expectedResult = 3;   
        
        var actualResult = calc.Subtract(a, b);
        
        Assert.Equal(expectedResult, actualResult);
    }
    [Fact]
    public void should_return_six_from_multiply()
    {
        var calc = new Calculator<int>();
        const int a = 3;
        const int b = 2;
        const int expectedResult = 6;   
        
        var actualResult = calc.Multiply(a, b);
        
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact] 
    public void should_handle_double()
    {
        var calc = new Calculator<double>();
        const double a = 3.2;
        const double b = 2.3;
        const double expectedResult = 5.5;   
        
        var actualResult = calc.Add(a, b);
        
        Assert.Equal(expectedResult, actualResult, 2);
    }
    [Fact]
    public void should_return_three_from_divide()
    {
        var calc = new Calculator<double>();
        const double a = 6.0;
        const double b = 2.0;
        const double expectedResult = 3.0;  
        
        var actualResult = calc.Divide(a, b);
        
        Assert.Equal(expectedResult, actualResult);
    }
    [Fact]
    public void should_return_error_by_divide_zero()
    {
        var calc = new Calculator<double>();
        const double a = 6.0;
        const double b = 0;
        const string expectedExceptionMessage = "Division by zero is not allowed."; 
        
        Action act = () => calc.Divide(a, b);
        
        DivideByZeroException exception = Assert.Throws<DivideByZeroException>(act);
        
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
    [Fact]
    public void should_return_handle_int_divide()
    {
        var calc = new Calculator<int>();
        const int a = 5;
        const int b = 2;
        const int expectedResult = 2;  
        
        var actualResult = calc.Divide(a, b);
        
        Assert.Equal(expectedResult, actualResult);
    }
    [Fact]
    public void should_return_double_from_pow()
    {
        var calc = new Calculator<double>();
        const double a = 3.1;
        const double b = 2;
        const double expectedResult = 9.61; 

        var actualResult = calc.Power(a, b);
        
        Assert.Equal(expectedResult, actualResult, 2);
    }
    [Fact]
    public void should_return_float_from_add()
    {
        var calc = new Calculator<float>();
        const float a = 3f;
        const float b = 2f;
        const float expectedResult = 5f; 

        var actualResult = calc.Add(a, b);
        
        Assert.Equal(expectedResult, actualResult);
    }
}