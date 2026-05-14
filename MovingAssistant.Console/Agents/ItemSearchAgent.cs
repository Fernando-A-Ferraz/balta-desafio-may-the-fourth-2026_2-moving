using MovingAssistant.Console.Models;

namespace MovingAssistant.Console.Agents;

public class ItemSearchAgent
{
    public MovingBox? FindBox(List<MovingBox> boxes, string itemName)
    {
        return boxes.FirstOrDefault(box =>
            box.Items.Any(item =>
                item.Name.Contains(itemName) ||
                itemName.Contains(item.Name)));
    }
}