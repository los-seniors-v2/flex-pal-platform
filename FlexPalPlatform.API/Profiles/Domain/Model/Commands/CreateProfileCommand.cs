﻿namespace FlexPalPlatform.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Email,string Phone, string Role);