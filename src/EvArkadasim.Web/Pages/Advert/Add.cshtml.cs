using EvArkadasim.Abstract;
using EvArkadasim.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EvArkadasim.Web.Pages.Advert
{
    public class AddModel : EvArkadasimPageModel
    {
        [BindProperty]
        public CreateAdvertViewModel AdvertViewModel { get; set; }
        public List<SelectListItem> AdverTypes { get; set; }
        public List<SelectListItem> AllowGenderTypes { get; set; }

        private readonly ILookupAppService _lookupAppService;
        private readonly IFileAppService _fileAppService;

        public AddModel(
            ILookupAppService lookupAppService,
            IFileAppService fileAppService
            )
        {
            _lookupAppService = lookupAppService;
            _fileAppService = fileAppService;
        }

        public void OnGet()
        {
            AdvertViewModel = new CreateAdvertViewModel();
            AdverTypes = _lookupAppService.GetAdvertTypeLookup();
            AllowGenderTypes = _lookupAppService.GetAllowGenderTypeLookup();
        }


        public class CreateAdvertViewModel
        {
            //[HiddenInput]
            //public int Id { get; set; }
            [Required]
            public string Title { get; set; }
            [TextArea(Rows = 2)]
            public string Description { get; set; }
            public string ExtraDescription { get; set; }
            public string Address { get; set; }
            [Required]
            [SelectItems(nameof(AdverTypes))]
            public AdvertType AdvertType { get; set; } //Setlicez.
            //public AdvertRankType AdvertRankType { get; set; } = AdvertRankType.Default;
            //public AdvertProcessStatus AdvertProcessStatus { get; set; } = AdvertProcessStatus.Waiting;
            [Required]
            [SelectItems(nameof(AdverTypes))]
            public AllowGenderType AllowGenderType { get; set; }
            //public bool IsPersonNeedHome { get; set; }//Set etcez.
            public bool IsHomeHaveFurniture { get; set; }
            public int ImpressionsNumber { get; set; }
            //public DateTime CreatedDate { get; set; }
            //public DateTime LastUpdateDate { get; set; }
            //public DateTime AdvertValidDate { get; set; }
            //public Status Status { get; set; }








            //[Phone]
            //public string Phone { get; set; }
            //[EmailAddress]
            //public string Email { get; set; }
            //[TextArea(Rows = 2)]
            //[MaxLength(1000)] //DEne
            //public string ShortAddress { get; set; }
            //[TextArea(Rows = 3)]
            //[MaxLength(1000)] //DENE
            //public string LongAddress { get; set; }
            //[MaxLength(300)]
            //public string LatLong { get; set; }
            //[TextArea(Rows = 3)]
            //[MaxLength(1000)] //DENE
            //public string About { get; set; }
            //[Required]
            //[SelectItems(nameof(Cities))]
            //[DisplayName("City")]
            //public int CityId { get; set; }
            //[Required]
            //public int DisrictId { get; set; }
            //[DisabledInput]
            //public string CompanyValidDate { get; set; }
            //[DisabledInput]
            //public string CreatedDate { get; set; }

            //public List<IFormFile> ImportFiles { get; set; }
            //public List<FileViewModel> ExistFiles { get; set; }
            //[HiddenInput]
            //public string RemovedFileIds { get; set; }
        }
    }
}
