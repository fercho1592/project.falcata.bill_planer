namespace Falcata.BillPlanner.Domain;

public struct TagStruct
{
    public int TagId { get; init; }
    public string Tag { get; init; }

    private TagStruct(int tagId, string tag)
    {
        TagId = tagId;
        Tag = tag;
    }
    
    public TagStruct(int tagId)
    {
        TagId = tagId;
        Tag = string.Empty;
    }
    
    public static TagStruct FoodAndBasics = new TagStruct(1, "Food and basics"); 
    public static TagStruct CarExpenses = new TagStruct(2, "Car expenses"); 
}

