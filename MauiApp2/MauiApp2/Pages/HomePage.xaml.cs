using System.Collections.ObjectModel;

namespace MauiApp2.Pages;

public partial class HomePage : ContentPage
{
    public ObservableCollection<Comment> Comments { get; set; }
    public string DefaultUserName { get; set; } = "Người dùng mặc định";

    public HomePage()
	{
		InitializeComponent();
        Comments = new ObservableCollection<Comment>
            {
            new Comment { UserName = "Nguyễn Thị Dung", CreatedAt = DateTime.Now.AddMinutes(-12), Content = "Alo, mình muốn input tự động hóa..." },
            new Comment { UserName = "Đỗ Thị Minh Khám", CreatedAt = DateTime.Now.AddMinutes(-35), Content = "Làm thế nào để xuất hóa đơn cho khách..." }
            };
        BindingContext = this;
    }
    private void OnPostButtonClicked(object sender, EventArgs e)
    {
        string content = postEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(content))
        {
            Comments.Insert(0, new Comment {
                UserName = DefaultUserName,
                CreatedAt = DateTime.Now,
                Content = content
            });
            postEntry.Text = ""; // Xóa nội dung Entry sau khi đăng
        }
    }
    public class Comment
    {
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; } 
        public string TimeAgo => GetTimeAgo();
        private string GetTimeAgo()
        {
            var timeSpan = DateTime.Now - CreatedAt;
            if (timeSpan.TotalSeconds < 60)
            {
                return $"{(int)timeSpan.TotalSeconds} giây trước";
            }
            if (timeSpan.TotalMinutes < 60)
            {
                return $"{(int)timeSpan.TotalMinutes} phút trước";
            }
            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} giờ trước";
            if (timeSpan.TotalDays < 30)
                return $"{(int)timeSpan.TotalDays} ngày trước";
            if (timeSpan.TotalDays < 365)
                return $"{(int)(timeSpan.TotalDays / 30)} tháng trước";

            return $"{(int)(timeSpan.TotalDays / 365)} năm trước";
        }
    }
}