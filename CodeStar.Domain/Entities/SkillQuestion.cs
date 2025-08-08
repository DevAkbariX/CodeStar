using CodeStar.Domain.Entities;

public class SkillQuestion
{
    public long Id { get; set; }
    public long SkillSparkId { get; set; }           
    public long? ParentQuestionId { get; set; }      
    public string Content { get; set; }             
    public long UserId { get; set; }                  
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool isvalid { get;set; }


    // Navigation properties
    #region Rel
    public SkillSpark SkillSpark { get; set; }
    public SkillQuestion ParentQuestion { get; set; }
    public ICollection<SkillQuestion> Replies { get; set; }
    public User User { get; set; }
    #endregion
}
