namespace Scheduler.Menu;

public class Question
{
    private readonly string _errorMessage;

    private Question(string errorMessage)
    {
        this._errorMessage = errorMessage;
    }

    public Question() : this("Por favor, ingresa una respuesta válida.")
    {
    }

    public string Ask(string question, Func<string, bool> validator)
    {
        string answer;

        Console.Write(question);
        answer = Console.ReadLine() ?? "";

        while (!validator(answer))
        {
            Console.Write($"{_errorMessage}\n{question}");
            answer = Console.ReadLine() ?? "";
        }

        return answer;
    }

    public string Ask(string question)
    {
        return Ask(question, s => !string.IsNullOrWhiteSpace(s));
    }

    public int AskInt(string question, Func<int, bool> validator)
    {
        return int.Parse(
            Ask(question, s => int.TryParse(s, out var result) && validator(result))
        );
    }

    public int AskInt(string question)
    {
        return AskInt(question, i => true);
    }

    public float AskFloat(string question, Func<float, bool> validator)
    {
        return float.Parse(
            Ask(question, s => float.TryParse(s, out var result) && validator(result))
        );
    }

    public float AskFloat(string question)
    {
        return AskFloat(question, f => true);
    }

    public double AskDouble(string question, Func<double, bool> validator)
    {
        return double.Parse(
            Ask(question, s => double.TryParse(s, out var result) && validator(result))
        );
    }

    public double AskDouble(string question)
    {
        return AskDouble(question, d => true);
    }

    public bool AskBoolean(string question, Func<bool, bool> validator)
    {
        return bool.Parse(
            Ask(question, s => bool.TryParse(s, out var result) && validator(result))
        );
    }

    public bool AskBoolean(string question)
    {
        return AskBoolean(question, b => true);
    }
}