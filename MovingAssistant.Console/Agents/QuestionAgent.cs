namespace MovingAssistant.Console.Agents;

public class QuestionAgent
{
    public string ExtractItemName(string question)
    {
        var normalizedQuestion = question
            .ToLower()
            .Trim();

        var expressionsToRemove = new[]
        {
            "onde está",
            "onde esta",
            "em qual caixa está",
            "em qual caixa esta",
            "cadê",
            "cade"
        };

        foreach (var expression in expressionsToRemove)
        {
            normalizedQuestion = normalizedQuestion
                .Replace(expression, "");
        }

        return normalizedQuestion
            .Replace("?", "")
            .Trim();
    }
}