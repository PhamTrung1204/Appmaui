using MauiApp2.Pages;

namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Đăng ký các route cho các trang
            Routing.RegisterRoute("HomePage", typeof(HomePage));
            Routing.RegisterRoute("FollowQuestionsPage", typeof(FollowQuestionsPage));
            Routing.RegisterRoute("MyQuestionsPage", typeof(MyQuestionsPage));
            Routing.RegisterRoute("ActiveMembersPage", typeof(ActiveMembersPage));
        }
    }
}
