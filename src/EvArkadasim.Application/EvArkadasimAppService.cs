using System;
using System.Collections.Generic;
using System.Text;
using EvArkadasim.Localization;
using Volo.Abp.Application.Services;

namespace EvArkadasim
{
    /* Inherit your application services from this class.
     */
    public abstract class EvArkadasimAppService : ApplicationService
    {
        protected EvArkadasimAppService()
        {
            LocalizationResource = typeof(EvArkadasimResource);
        }
    }
}
