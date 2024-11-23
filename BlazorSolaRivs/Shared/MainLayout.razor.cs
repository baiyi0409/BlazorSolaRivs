using BlazorComponent;
using Masa.Blazor;
using System.Reflection.Emit;

namespace BlazorSolaRivs.Shared
{
    public partial class MainLayout
    {
        public string logo = "SolaRivs";

        /// <summary>
        /// 导航栏实体类
        /// </summary>
        private class NavItem
        {
            //标题名
            public string Name { get; set; }

            //路由地址
            public string? Url { get; set; }

            //图标
            public string? Icon { get; set; }

            //子列表
            public List<NavItem>? Children { get; set; }

            //子列表的路由地址
            public List<string>? Group => Children?.Select(x => x.Url)?.ToList();

            //是否开启精确匹配
            public bool Exact { get; set; }

            //自定义正则表达式
            public string? MatchPattern { get; set; }

            #region 多种使用方式

            public NavItem()
            {

            }

            //标题名 + 路由路径
            public NavItem(string name, string url)
            {
                Name = name;
                Url = url;
            }

            //标题名 + 路由路径 + 精确匹配
            public NavItem(string name, string url, bool exact) : this(name, url)
            {
                Exact = exact;
            }

            //标题名 + 路由路径 + 精确匹配
            public NavItem(string name, string url, string matchPattern) : this(name, url)
            {
                MatchPattern = matchPattern;
            }

            //标题名 + 路由路径 + 子列表
            public NavItem(string name, string icon, List<NavItem> children)
            {
                Name = name;
                Icon = icon;
                Children = children;
            }

            //标题名 + 子列表
            public NavItem(string name, List<NavItem> children)
            {
                Name = name;
                Children = children;
            }
            #endregion
        }

        private List<NavItem> _navItems = new();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                _navItems = new List<NavItem>()
                {
                    new NavItem()
                    { 
                        Name = "Dashboard",
                        Icon = "mdi-view-dashboard",
                        Url = "/"
                    },
                    new NavItem("Education", 
                    new List<NavItem>()
                    {
                        new NavItem("Courses", "/components/alerts"),
                        new NavItem("Sertificate", "/components/buttons")
                    }),
                    new NavItem("Resources",
                    new List<NavItem>()
                    {
                        new NavItem("Genetics 101", "/components/alerts"),
                        new NavItem("DNA synthesis", "/components/buttons"),
                        new NavItem("Events", "/components/buttons")
                    }),
                    new NavItem()
                    {
                        Name = "Settings",
                        Icon = "mdi-cog",
                        Url = "/components/buttons"
                    },
                };

                StateHasChanged();
            }
        }


        private object _option = new
        {
            Tooltip = new { },
            XAxis = new
            {
                Data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat","Sun" }
            },
            YAxis = new { },
            Series = new[]
            {
                new
                {
                    Name = "sales",
                    Type = "bar",
                    Data = new[] { 1.8, 2.6, 1.2, 3.5, 2.5, 1.6, 2.8 }
                }
            }
        };

        List<StringNumber> settings = new();
    }
}