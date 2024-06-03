namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record UpdateCoachKnowledgeCommand(int CoachId, string NewKnowledge);