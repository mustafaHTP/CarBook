﻿namespace CarBook.Application.Dtos.ServiceDtos
{
    public class GetServiceByIdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
