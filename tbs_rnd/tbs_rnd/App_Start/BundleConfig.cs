using System.Web;
using System.Web.Optimization;

namespace tbs_rnd
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-1.*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
				"~/Scripts/jquery-ui*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.unobtrusive*",
				"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new StyleBundle("~/bootstrap/css").Include(
					"~/Content/bootstrap.css",
					"~/Content/bootstrap-responsive.css"
				));

			bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
				"~/Scripts/bootstrap.js"
				));
		}
	}
}