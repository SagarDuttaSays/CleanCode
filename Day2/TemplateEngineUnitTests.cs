namespace TemplateEngine.Tests;

public class TemplateEngineUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Sanjeev")]
    [TestCase("Anjana")]
    [TestCase("Raghu")]
    public void ShouldEvaluateOneVariable(string name)
    {
        //Arrange
        TestEngine testEngine = new TestEngine();
        testEngine.setName(name);

        //Act
        string result = testEngine.EvaluateOneVariable();

        //Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [TestCase("Suhail", "Siemens Healthineers")]
    [TestCase("Rahul", "Siemens EDA")]
    [TestCase("Rajani", "Siemens Gamesha")]
    public void ShouldEvaluateTwoVariable(params string[] values)
    {
        //Arrange
        TestEngine testEngine = new TestEngine();
        testEngine.setName(values[0]);
        testEngine.setCompany(values[1]);

        //Act
        string result = testEngine.EvaluateTwoVariable();

        //Assert
        string expectedResult = values[0] + " works in " + values[1];
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
