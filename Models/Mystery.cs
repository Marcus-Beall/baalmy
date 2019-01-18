namespace baalmy.Models
{
  public class MysterySecret
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int MysteryId { get; set; }
    public int SecretId { get; set; }
  }
  public class Mystery
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }

  }
}