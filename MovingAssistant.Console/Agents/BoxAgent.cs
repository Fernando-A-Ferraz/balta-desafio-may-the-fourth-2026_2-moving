using MovingAssistant.Console.Models;

namespace MovingAssistant.Console.Agents;

public class BoxAgent
{
    public MovingBox CreateBox(int number, string itemsInput)
    {
        var items = itemsInput
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(item => new BoxItem
            {
                Name = item.Trim().ToLower()
            })
            .ToList();

        return new MovingBox
        {
            Number = number,
            Items = items
        };
    }
}