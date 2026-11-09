namespace CuraFlow.Application.Common.Models;

public class PagenatedList<T>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public List<T> Values { get; set; }
}