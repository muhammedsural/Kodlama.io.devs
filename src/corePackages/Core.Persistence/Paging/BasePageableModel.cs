namespace Core.Persistence.Paging;

//Sayfalama yapısı için gereken bilgiler burada tutuluyor.
public class BasePageableModel
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}