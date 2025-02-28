namespace IPM.Application.UseCases.Project.RemoveUserInProjectUseCase;

public record RemoveUserInProjectRequest(Assignment[] Assignments);

public record Assignment(string UserId, int ProjectId );
