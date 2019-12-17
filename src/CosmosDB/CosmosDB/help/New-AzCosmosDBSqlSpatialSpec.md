---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/en-us/powershell/module/az.cosmosdb/new-azcosmosdbsqlspatialspec
schema: 2.0.0
---

# New-AzCosmosDBSqlSpatialSpec

## SYNOPSIS
Creates a new CosmosDB Sql SpatialSpec object.

## SYNTAX

```
New-AzCosmosDBSqlSpatialSpec [-SpatialType <String[]>] [-Path <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDBSqlSpatialSpec** cmdlet creates a new object of type PSSqlSpatialSpec.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzCosmosDBSqlSpatialSpec -SpatialType {spatialType} -Path {path}

SpatialType     Path
-----------     ----
{spatialType}   {path}

```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Path in JSON document to index.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpatialType
Array of strings with acceptable values: Point, LineString, Polygon, MultiPolygon.
Represent's paths spatial type.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlSpatialSpec

## NOTES

## RELATED LINKS
