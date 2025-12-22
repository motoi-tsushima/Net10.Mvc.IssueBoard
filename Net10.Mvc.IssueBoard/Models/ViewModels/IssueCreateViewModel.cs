using System.ComponentModel.DataAnnotations;

namespace Net10.Mvc.IssueBoard.Models.ViewModels;

public class IssueCreateViewModel
{
    [Required(ErrorMessage = "記入者氏名は必須です")]
    [StringLength(50, ErrorMessage = "記入者氏名は50文字以内で入力してください")]
    [Display(Name = "記入者氏名")]
    public string AuthorName { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "カテゴリ名は30文字以内で入力してください")]
    [Display(Name = "カテゴリ名")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "課題タイトルは必須です")]
    [StringLength(100, ErrorMessage = "課題タイトルは100文字以内で入力してください")]
    [Display(Name = "課題タイトル")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "課題の文面は必須です")]
    [StringLength(2000, ErrorMessage = "課題の文面は2000文字以内で入力してください")]
    [Display(Name = "課題の文面")]
    public string Description { get; set; } = string.Empty;
}
