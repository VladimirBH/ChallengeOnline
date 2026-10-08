namespace Backend.DTO;

public record ChallengeCreateDto(string Title, string Description, int CreatorId, int DifficultyId);
