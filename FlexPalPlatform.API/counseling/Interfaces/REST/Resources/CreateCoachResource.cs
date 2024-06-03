namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;
using System.ComponentModel.DataAnnotations;

public record CreateCoachResource(
    [Required, MaxLength(100)] string FirstName, 
    [Required, MaxLength(100)] string LastName, 
    [Required, EmailAddress] string Email, 
    [Required, Phone] string Phone, 
    [Required] string Knowledge);
