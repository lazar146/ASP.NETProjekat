﻿namespace ProjASP
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string HfConnectionString { get; set; }
        public JwtSettings Jwt { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
