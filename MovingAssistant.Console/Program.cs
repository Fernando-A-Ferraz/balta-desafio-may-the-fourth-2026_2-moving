using MovingAssistant.Console.Services;

Console.Title = "Moving Assistant - May The Fourth 2026";

ExibirCabecalho();

var movingService = new MovingAssistantService();

if (!movingService.HasBoxes())
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("📦 Quantas caixas deseja cadastrar? ");
    Console.ResetColor();

    var quantityInput = Console.ReadLine();

    if (!int.TryParse(quantityInput, out var totalBoxes) || totalBoxes <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Quantidade inválida.");
        Console.ResetColor();
        return;
    }

    for (int i = 1; i <= totalBoxes; i++)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"📦 Caixa {i}");
        Console.ResetColor();

        Console.Write("Itens (separados por vírgula): ");
        var itemsInput = Console.ReadLine() ?? string.Empty;

        movingService.AddBox(i, itemsInput);
    }

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("✅ Caixas cadastradas com sucesso!");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("✅ Caixas carregadas do arquivo boxes.json.");
    Console.ResetColor();
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("✅ Caixas cadastradas com sucesso!");
Console.ResetColor();

while (true)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("🔎 Pergunte onde está um item (ou digite 'sair'): ");
    Console.ResetColor();

    var question = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(question))
        continue;

    if (question.Equals("sair", StringComparison.OrdinalIgnoreCase))
        break;

    var result = movingService.FindItem(question);

    Console.WriteLine();
    Console.WriteLine(result);
}

Console.WriteLine();
Console.WriteLine("👋 Encerrando aplicação...");

static void ExibirCabecalho()
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("======================================");
    Console.WriteLine(" 🌌 MAY THE FOURTH 2026");
    Console.WriteLine("    MOVING ASSISTANT");
    Console.WriteLine("======================================");

    Console.ResetColor();
    Console.WriteLine();
}