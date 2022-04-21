namespace Masa.BuildingBlocks.BasicAbility.Pm.Model;

public class ProjectModel
{
    public int Id { get; set; }

    public string Identity { get; set; } = "";

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public int LabelId { get; set; }

    public string LabelName { get; set; } = "";

    public Guid Modifier { get; set; }

    public DateTime ModificationTime { get; set; }
}
