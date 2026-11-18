using Microsoft.EntityFrameworkCore;

namespace PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// ModelBuilder extensions to apply snake_case and plural table naming conventions.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            if (!entity.IsOwned())
            {
                var tableName = entity.GetTableName();
                if (!string.IsNullOrEmpty(tableName))
                {
                    entity.SetTableName(tableName.ToPlural().ToSnakeCase());
                }
            }

            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName();
                if (!string.IsNullOrEmpty(columnName))
                {
                    property.SetColumnName(columnName.ToSnakeCase());
                }
            }

            if (entity.IsOwned()) continue;

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName))
                {
                    key.SetName(keyName.ToSnakeCase());
                }
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var foreignKeyName = foreignKey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyName))
                {
                    foreignKey.SetConstraintName(foreignKeyName.ToSnakeCase());
                }
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexDatabaseName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexDatabaseName))
                {
                    index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
                }
            }
        }
    }
}