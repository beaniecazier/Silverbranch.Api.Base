using Gay.Silverbranch.API.BLL.Options.V1;
using Gay.Silverbranch.API.Models.Enum;
using Gay.Silverbranch.API.Utilities.Contract.Requests;
using Microsoft.Data.SqlClient;

namespace Gay.Silverbranch.API.Utilities.Backend.Mapping.V1;

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