using Application.Frontend;
namespace Application.WebSite
{
    public partial class Default : BrowserInitializer
    {
        protected Default()
        {
            Init += InitPages;
        }
    }
}