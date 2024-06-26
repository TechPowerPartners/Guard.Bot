﻿using System.Text.Json.Serialization;

namespace Api.Contracts.Vacancies;
public record CreateVacancyRequest
{
    /// <summary>Короткое название.</summary>
    public string Title { get; init; }

    /// <summary>Полное описание.</summary>
    public string Description { get; init; }
    [JsonIgnore]
    /// <summary>Идентификатор руководителя. </summary>
    public Guid LeaderId { get; init; }

    /// <summary>Ключевые слова.</summary>
    public ICollection<string> Keywords { get; init; }

    /// <summary>День закрытие вакансии.</summary>
    public DateTime ClosingDate { get; init; }
}
