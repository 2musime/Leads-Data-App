namespace LeadsAPI.Models;

public partial class LeadsInput
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Industry { get; set; }

    public string? Region { get; set; }
}
