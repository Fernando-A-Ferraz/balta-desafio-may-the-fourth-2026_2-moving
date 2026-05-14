using System.Text.Json;
using MovingAssistant.Console.Agents;
using MovingAssistant.Console.Models;

namespace MovingAssistant.Console.Services;

public class MovingAssistantService
{
    private readonly BoxAgent _boxAgent = new();
    private readonly QuestionAgent _questionAgent = new();
    private readonly ItemSearchAgent _itemSearchAgent = new();

    private readonly string _filePath = "Data/boxes.json";
    private readonly List<MovingBox> _boxes;

    public MovingAssistantService()
    {
        _boxes = LoadBoxes();
    }

    public bool HasBoxes()
    {
        return _boxes.Any();
    }

    public void AddBox(int boxNumber, string itemsInput)
    {
        var box = _boxAgent.CreateBox(boxNumber, itemsInput);
        _boxes.Add(box);

        SaveBoxes();
    }

    public string FindItem(string question)
    {
        var itemName = _questionAgent.ExtractItemName(question);

        var box = _itemSearchAgent.FindBox(_boxes, itemName);

        return box is not null
            ? $"📦 O item '{itemName}' está na caixa {box.Number}."
            : $"❌ Não encontrei '{itemName}' nas caixas cadastradas.";
    }

    private List<MovingBox> LoadBoxes()
    {
        if (!File.Exists(_filePath))
            return [];

        var json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
            return [];

        return JsonSerializer.Deserialize<List<MovingBox>>(json) ?? [];
    }

    private void SaveBoxes()
    {
        Directory.CreateDirectory("Data");

        var json = JsonSerializer.Serialize(
            _boxes,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(_filePath, json);
    }
}