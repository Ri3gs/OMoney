﻿namespace OMoney.Web.Api.Models
{
    public class UpdateCatItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}