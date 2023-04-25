using Volo.Abp.Application.Dtos;

namespace EvArkadasim.Dtos.HomePages
{
    public class GetHomePageRequestDto : PagedAndSortedResultRequestDto
    {
        public int OrganizationId { get; set; }
        public int CityId { get; set; }
        public int TownId { get; set; }

    }
}
