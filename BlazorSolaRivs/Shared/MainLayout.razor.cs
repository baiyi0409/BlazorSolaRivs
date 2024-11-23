using BlazorComponent;
using Masa.Blazor;
using System.Reflection.Emit;

namespace BlazorSolaRivs.Shared
{
    public partial class MainLayout
    {
        public string logo = "SolaRivs";

        /// <summary>
        /// ������ʵ����
        /// </summary>
        private class NavItem
        {
            //������
            public string Name { get; set; }

            //·�ɵ�ַ
            public string? Url { get; set; }

            //ͼ��
            public string? Icon { get; set; }

            //���б�
            public List<NavItem>? Children { get; set; }

            //���б��·�ɵ�ַ
            public List<string>? Group => Children?.Select(x => x.Url)?.ToList();

            //�Ƿ�����ȷƥ��
            public bool Exact { get; set; }

            //�Զ���������ʽ
            public string? MatchPattern { get; set; }

            #region ����ʹ�÷�ʽ

            public NavItem()
            {

            }

            //������ + ·��·��
            public NavItem(string name, string url)
            {
                Name = name;
                Url = url;
            }

            //������ + ·��·�� + ��ȷƥ��
            public NavItem(string name, string url, bool exact) : this(name, url)
            {
                Exact = exact;
            }

            //������ + ·��·�� + ��ȷƥ��
            public NavItem(string name, string url, string matchPattern) : this(name, url)
            {
                MatchPattern = matchPattern;
            }

            //������ + ·��·�� + ���б�
            public NavItem(string name, string icon, List<NavItem> children)
            {
                Name = name;
                Icon = icon;
                Children = children;
            }

            //������ + ���б�
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