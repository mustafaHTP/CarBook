﻿namespace CarBook.WebApp.Areas.Admin.Models.FooterAddressModels
{
    public class UpdateFooterAddressViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
