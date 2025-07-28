namespace TourGuideFamily.Bll.Models;

public record MainModel
{
    public required GuideModel[] Guides { get; set; }
    public required TourInfoModel[] Tours { get; set; }
    public required PromoModel[] Promos { get; set; }
    public required ReviewModel[] Reviews { get; set; }
}