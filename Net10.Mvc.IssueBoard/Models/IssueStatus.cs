using System.ComponentModel.DataAnnotations;

namespace Net10.Mvc.IssueBoard.Models;

public enum IssueStatus
{
    [Display(Name = "未着手")]
    NotStarted = 0,

    [Display(Name = "着手中")]
    InProgress = 1,

    [Display(Name = "解決失敗")]
    ResolutionFailed = 2,

    [Display(Name = "課題確認不能")]
    CannotConfirm = 3,

    [Display(Name = "解決済み")]
    Resolved = 4
}
