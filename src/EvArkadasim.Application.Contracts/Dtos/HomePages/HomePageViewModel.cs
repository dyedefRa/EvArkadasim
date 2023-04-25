using System;

namespace EvArkadasim.Dtos.HomePages
{
    public class HomePageViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        //HERE Burası ConceptfileUrl olmalı.
        //CompanyOrganizationConcept 1 file eklenebilir.
        public string CompanyFileUrl { get; set; }
        public string ConceptTitle { get; set; }
        public string ConceptDescription { get; set; }
        public string CityTitle { get; set; }
        public string TownTitle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
