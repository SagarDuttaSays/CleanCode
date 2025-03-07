

namespace TemplateEngine;

public class TestEngine
{
    public string name = "";
    private string company = "";

    public string EvaluateOneVariable()
    {
        return this.name;
    }

    public string EvaluateTwoVariable()
    {
        return this.name+" works in "+this.company;
    }

    public void setCompany(string company)
    {
        this.company = company;
    }

    public void setName(string name)
    {
        this.name = name;
    }
}
