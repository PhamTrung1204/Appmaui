using System.Collections.ObjectModel;

namespace MauiApp2.Pages;

public partial class ActiveMembersPage : ContentPage
{
    public ObservableCollection<Member> Members { get; set; }

    public ActiveMembersPage()
    {
        InitializeComponent();

        // Dữ liệu mẫu
        Members = new ObservableCollection<Member>
            {
                new Member { Name = "Nguyễn Văn A", Role = "Admin" },
                new Member { Name = "Trần Thị B", Role = "Moderator" },
                new Member { Name = "Lê Văn C", Role = "Contributor" },
                new Member { Name = "Phạm Minh D", Role = "Active User" },
            };

        MembersListView.ItemsSource = Members;
    }

    private void OnSearchClicked(object sender, EventArgs e)
    {
        string keyword = SearchEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(keyword))
        {
            MembersListView.ItemsSource = new ObservableCollection<Member>(
                Members.Where(m => m.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            );
        }
        else
        {
            MembersListView.ItemsSource = Members; // Khôi phục danh sách ban đầu nếu không nhập từ khóa
        }
    }

    private async void OnMessageClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Member member)
        {
            await DisplayAlert("Nhắn tin", $"Bạn muốn nhắn tin cho {member.Name}.", "OK");
        }
    }

    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Member member)
        {
            await DisplayAlert("Chi tiết", $"Tên: {member.Name}\nVai trò: {member.Role}", "Đóng");
        }
    }

    public class Member
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}