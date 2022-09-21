﻿namespace Directory.Identity.Application.Commons.Models.IdentityConfiguration;

public class TokenSettings
{
    public TokenAuthenticationSettings TokenAuthenticationSettings { get; set; }
    public int TokenExpiryDefaultMinute { get; set; }
}