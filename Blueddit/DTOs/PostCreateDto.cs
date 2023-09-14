namespace Blueddit.DTOs
{
   public record struct PostCreateDto(string Title, string Content, string Author, string Type);
}
