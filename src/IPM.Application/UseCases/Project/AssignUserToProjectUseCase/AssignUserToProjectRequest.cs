namespace IPM.Application.UseCases.Project.AssignUserToProjectUseCase;

public record AssignUserToProjectRequest(Assignment[] Assignments);

public record Assignment(string UserId, int ProjectId, bool Owner);
