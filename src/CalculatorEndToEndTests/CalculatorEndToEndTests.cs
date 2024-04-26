using CalculatorEngine;
using Microsoft.Playwright;

namespace CalculatorEndToEndTests2;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest {
    [SetUp]
    public async Task SetUp() {
        await Page.GotoAsync("http://localhost:5167/");
    }
    
    [TearDown]
    public async Task TearDown() {
        await Page.ClickAsync("button:has-text('Clear')");
    }
    
    [Test]
    public async Task CalculatorWeb_PageTitle_IsCalculator() {
        //preq-E2E-TEST-5
        string result = await Page.TitleAsync();
        
        Assert.That(result, Is.EqualTo("Calculator"));
    }
    
    [Test]
    public async Task CalculatorWebUi_DivideOperationByZero_ReturnsNotANumberError() {
        //preq-E2E-Test-6
        await Page.ClickAsync("#inputA");
        await Page.FillAsync("#inputA", "5");
        await Page.ClickAsync("#inputB");
        await Page.FillAsync("#inputB", "0");
        await Page.ClickAsync("button:has-text('A / B')");
        
        await Expect(Page.Locator("#equationResult")).ToContainTextAsync("Not a Number");
    }
    
    [Test]
    public async Task CalculatorWebUi_AddOperationWithNumbers_ReturnsSum() {
        //preq-E2E-Test-6
        CalculatorLogic calculatorEngine = new CalculatorLogic();
        String expectedResult = calculatorEngine.Addition(-75, 89).ToString();
        
        await Page.ClickAsync("#inputA");
        await Page.FillAsync("#inputA", "-75");
        await Page.ClickAsync("#inputB");
        await Page.FillAsync("#inputB", "89");
        await Page.ClickAsync("button:has-text('A + B')");
        
        await Expect(Page.Locator("#equationResult")).ToContainTextAsync(expectedResult);
    }
    
    [Test]
    public async Task CalculatorWebUi_AddOperationWithTextValues_ReturnsInvalidInputError() {
        //preq-E2E-Test-6
        await Page.ClickAsync("#inputA");
        await Page.FillAsync("#inputA", "15");
        await Page.ClickAsync("#inputB");
        await Page.FillAsync("#inputB", "fifteen");
        await Page.ClickAsync("button:has-text('A + B')");
        
        await Expect(Page.Locator("#equation")).ToContainTextAsync("Invalid Input, Numbers Only");
    }
    
    [Test]
    public async Task CalculatorWebUi_AddAndClear_ReturnsToDefaultState() {
        //preq-E2E-Test-6
        await Page.ClickAsync("#inputA");
        await Page.FillAsync("#inputA", "15");
        await Page.ClickAsync("#inputB");
        await Page.FillAsync("#inputB", "6");
        await Page.ClickAsync("button:has-text('A + B')");
        await Page.ClickAsync("button:has-text('Clear')");
        
        await Expect(Page.Locator("#equation")).ToContainTextAsync("Enter a value(s) below and select an operation.");
    }
}