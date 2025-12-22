using System.ComponentModel.DataAnnotations;

namespace Net10.Mvc.IssueBoard.Models.ViewModels;

public class IssueEditViewModel
{
    public int Id { get; set; }

    [Display(Name = "記入者氏名")]
    public string AuthorName { get; set; } = null!;

    [Display(Name = "登録日時")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30, ErrorMessage = "カテゴリ名は30文字以内で入力してください")]
    [Display(Name = "カテゴリ名")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "課題タイトルは必須です")]
    [StringLength(100, ErrorMessage = "課題タイトルは100文字以内で入力してください")]
    [Display(Name = "課題タイトル")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "課題の文面は必須です")]
    [StringLength(2000, ErrorMessage = "課題の文面は2000文字以内で入力してください")]
    [Display(Name = "課題の文面")]
    public string Description { get; set; } = null!;

    [Display(Name = "現在の状況")]
    public IssueStatus Status { get; set; }

    [StringLength(2000, ErrorMessage = "解決の文面は2000文字以内で入力してください")]
    [Display(Name = "解決の文面")]
    public string? Resolution { get; set; }

    [StringLength(50, ErrorMessage = "解決担当者名は50文字以内で入力してください")]
    [Display(Name = "解決担当者名")]
    public string? ResolverName { get; set; }

    [Display(Name = "最終結果日時")]
    public DateTime? ResolvedAt { get; set; }
}
