﻿namespace CoreProject.API.CQRS.Results.ServiceResult
{
    public class GetServiceByIdQueryResult
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
