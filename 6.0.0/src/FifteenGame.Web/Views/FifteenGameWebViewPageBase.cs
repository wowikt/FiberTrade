using Abp.Web.Mvc.Views;

namespace FifteenGame.Web.Views
{
    public abstract class FifteenGameWebViewPageBase : FifteenGameWebViewPageBase<dynamic>
    {

    }

    public abstract class FifteenGameWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected FifteenGameWebViewPageBase()
        {
            LocalizationSourceName = FifteenGameConsts.LocalizationSourceName;
        }
    }
}