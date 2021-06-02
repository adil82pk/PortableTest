namespace ServiceLayer.Helper
{
    using ServiceLayer.Models;
    using System.Web;

    public static class ParameterHelper
    {
        public static string ParseQueryParameters(FilterDTO filterDTO)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            if (filterDTO != null)
            {
                //  query.Add("&page", filterDTO.Page?.ToString());
                //  query.Add("pageSize", filterDTO.PageSize.ToString());
                if (!string.IsNullOrWhiteSpace(filterDTO.Search))
                {
                    query.Add("&q", filterDTO.Search);
                }
            }
            return query.ToString();
        }
    }
}
