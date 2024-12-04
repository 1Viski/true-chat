using System.ComponentModel.DataAnnotations;

namespace TrueChat.BlazorApp.Client.Models;

public class FormMessage
{
    [Required]
    public string? Nickname { get; set; }
    
    [Required]
    public string? Text { get; set; }
}