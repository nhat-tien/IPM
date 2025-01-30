namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Position: BaseEntity
{
    public int PositionId { get; set; }
    public string? PositionName { get; set; }

    public Domain.Position MapTo()
    {
        return new Domain.Position()
        {
            PositionId = this.PositionId,
            PositionName = this.PositionName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static Position MapFrom(Domain.Position model)
    {
        return new Position()
        {
            PositionId = model.PositionId,
            PositionName = model.PositionName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
