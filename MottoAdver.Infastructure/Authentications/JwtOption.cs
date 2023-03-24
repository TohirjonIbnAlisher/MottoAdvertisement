﻿namespace MottoAdver.Infastructure.Authentications;

internal class JwtOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public int ExpirationInMinutes { get; set; }
}
