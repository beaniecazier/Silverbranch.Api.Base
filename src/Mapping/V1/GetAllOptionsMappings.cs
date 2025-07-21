using Microsoft.Data.SqlClient;

using Gay.Silverbranch.Api.Bll.Options.V1;
using Gay.Silverbranch.Api.Models.Enum.V1;
using Gay.Silverbranch.Api.Utilities.Contract.Requests.V1;

namespace Gay.Silverbranch.Api.Utilities.Backend.Mapping.V1;

public static class GetAllOptionsMappings
{
    public static GetAllModelsOptions MapToOptions(
        this GetAllModelsRequest request)
    {
        return new GetAllModelsOptions()
        {
            NameSearchTerm = request.NameSearchTerm,
            NotesSearchTerm = request.NotesSearchTerm,
            AfterDate = request.AfterDate,
            BeforeDate = request.BeforeDate,
            AllowHidden = request.AllowHidden,
            AllowDeleted = request.AllowDeleted,
            // GreaterThanOrEqualToId = request.GreaterThanOrEqualToId,
            // LessThanOrEqualToId = request.LessThanOrEqualToId,
            SpecificIds = request.SpecificIds,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            SortBy = request.SortBy?.Trim('+', '-') ?? "CommonIdentity",
            SortDirection = request.SortBy is not null && request.SortBy.StartsWith('-') ?
                SortOrder.Descending :
                SortOrder.Ascending,
        };
    }

    public static GetAllModelsOptions WithUser(
        this GetAllModelsOptions options,
        string username,
        eModelOwnershipScope ownshipType)
    {
        options.Username = username;
        options.ModelOwnershipScope = ownshipType;
        return options;
    }
}