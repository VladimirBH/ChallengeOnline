namespace Backend.DTO;

public record DaySubmissionCreateDto(int ParticipationId, int ChallengeDayId, int StatusId, string Summary);