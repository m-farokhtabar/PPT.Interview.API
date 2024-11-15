namespace PPT.Interview.API.StartupConfig
{
    public static class CorsAllowAnyApplicationExtension
    {
        /// <summary>
        /// Allow cross-origin requests to access services through the browser from any site.
        /// </summary>
        /// <param name="App"></param>
        public static void UseCorsAllowAny(this IApplicationBuilder App)
        {
            App.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}
