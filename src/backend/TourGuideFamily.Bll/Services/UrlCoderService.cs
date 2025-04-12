using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.Domain.Interfaces;

namespace TourGuideFamily.Bll.Services;

public class UrlCoderService : IUrlCoderService
{
    readonly ITourRepository _tourRepository;
    private static readonly Dictionary<char, string> TransliterationMap = new()
    {
        { 'а', "a" }, { 'б', "b" }, { 'в', "v" }, { 'г', "g" }, { 'д', "d" },
        { 'е', "e" }, { 'ё', "yo" }, { 'ж', "zh" }, { 'з', "z" }, { 'и', "i" },
        { 'й', "y" }, { 'к', "k" }, { 'л', "l" }, { 'м', "m" }, { 'н', "n" },
        { 'о', "o" }, { 'п', "p" }, { 'р', "r" }, { 'с', "s" }, { 'т', "t" },
        { 'у', "u" }, { 'ф', "f" }, { 'х', "h" }, { 'ц', "c" }, { 'ч', "ch" },
        { 'ш', "sh" }, { 'щ', "sch" }, { 'э', "e" }, { 'ю', "yu" }, { 'я', "ya" },

        // Дополнительные символы
        { 'ъ', "" }, { 'ы', "y" }, { 'ь', "" }
    };

    public UrlCoderService(ITourRepository tourRepository)
    {
        _tourRepository = tourRepository;
    }

    public async Task<string> EncodeToSlugAsync(string input, CancellationToken token)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
        var normalizedString = input.ToLowerInvariant().Normalize(NormalizationForm.FormD);

        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory == UnicodeCategory.NonSpacingMark)
                continue;

            if (char.IsLetterOrDigit(c) || c == ' ')
            {
                if (TransliterationMap.ContainsKey(c))
                {
                    stringBuilder.Append(TransliterationMap[c]);
                }
                else if (char.IsWhiteSpace(c))
                {
                    stringBuilder.Append('-');
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
        }
        var slug = stringBuilder.ToString().Trim('-');
        var uniqueSlug = await EnsureUniqueSlug(slug, token);
        return uniqueSlug;
    }

    private async Task<string> EnsureUniqueSlug(string slug, CancellationToken token)
    {
        int suffix = 0;
        string uniqueSlug = slug;
        while (await IsSlugExists(uniqueSlug, token))
        {
            suffix++;
            uniqueSlug = $"{slug}-{suffix}";
        }

        return uniqueSlug;
    }

    /// <summary>
    /// Проверяет, существует ли slug в базе данных
    /// </summary>
    private async Task<bool> IsSlugExists(string slug, CancellationToken token)
    {
        var count = await _tourRepository.GetCountBySlug(slug, token);
        return count > 0;
    }
}