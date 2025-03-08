﻿namespace CarBook.Application.Features.ServiceFeatures.Results
{
    public class GetServicesQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
    }
}
