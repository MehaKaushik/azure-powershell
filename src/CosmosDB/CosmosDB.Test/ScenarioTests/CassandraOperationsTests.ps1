# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
<#
.SYNOPSIS
Gets and removes custom domain with running endpoint.
#>

function Test-CassandraOperationsCmdlets
{
  $AccountName = "db2725"
  $rgName = "CosmosDBResourceGroup2510"
  $KeyspaceName = "db"
  $TableName = "table"

  $NewKeyspace =  Set-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
  Assert-AreEqual $NewKeyspace.Name $KeyspaceName

  $Column1 = New-AzCosmosDBCassandraColumn -Name "ColumnA" -Type "int"
  $Column2 = New-AzCosmosDBCassandraColumn -Name "ColumnB" -Type "ascii"

  $clusterkey1 = New-AzCosmosDBCassandraClusterKey -Name "ColumnB" -OrderBy "Asc"
  $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"

  $NewTable = Set-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -Schema $schema
  Assert-AreEqual $NewTable.Name $TableName

  $Keyspace = Get-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
  Assert-AreEqual $NewKeyspace.Id $Keyspace.Id
  Assert-AreEqual $NewKeyspace.Name $Keyspace.Name
  Assert-AreEqual $NewKeyspace.CassandraKeyspaceGetResultsId $Keyspace.CassandraKeyspaceGetResultsId
  Assert-AreEqual $NewKeyspace._rid $Keyspace._rid
  Assert-AreEqual $NewKeyspace._ts $Keyspace._ts
  Assert-AreEqual $NewKeyspace._etag $Keyspace._etag

  $Table = Get-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
  Assert-AreEqual $NewTable.Id $Table.Id
  Assert-AreEqual $NewTable.Name $Table.Name
  Assert-AreEqual $NewTable.CassandraTableGetResultsId $Table.CassandraTableGetResultsId
  Assert-AreEqual $NewTable._rid $Table._rid
  Assert-AreEqual $NewTable._ts $Table._ts
  Assert-AreEqual $NewTable._etag $Table._etag

  $ListTables = Get-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName
  Assert-NotNull($ListTables)

  $ListKeyspaces = Get-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName
  Assert-NotNull($ListKeyspaces)
  
  $IsTableRemoved =  Remove-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -PassThru
  Assert-AreEqual $IsTableRemoved true
  
  $IsKeyspaceRemoved = Remove-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName -PassThru
  Assert-AreEqual $IsKeyspaceRemoved true
}

function Test-CassandraOperationsCmdletsUsingInputObject
{
  $AccountName = "db2725"
  $rgName = "CosmosDBResourceGroup2510"
  $KeyspaceName = "db2"
  $TableName = "table"

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

  $NewKeyspace =  Set-AzCosmosDBCassandraKeyspace -InputObject $cosmosDBAccount -Name $KeyspaceName
  Assert-AreEqual $NewKeyspace.Name $KeyspaceName

  $Column1 = New-AzCosmosDBCassandraColumn -Name "ColumnA" -Type "int"
  $Column2 = New-AzCosmosDBCassandraColumn -Name "ColumnB" -Type "ascii"
  $clusterkey1 = New-AzCosmosDBCassandraClusterKey -Name "ColumnB" -OrderBy "Asc"
  $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"

  $NewTable = Set-AzCosmosDBCassandraTable -InputObject $NewKeyspace -Name $TableName -Schema $schema
  Assert-AreEqual $NewTable.Name $TableName

  $Keyspace = Get-AzCosmosDBCassandraKeyspace -InputObject $cosmosDBAccount -Name $KeyspaceName
  Assert-AreEqual $NewKeyspace.Id $Keyspace.Id
  Assert-AreEqual $NewKeyspace.Name $Keyspace.Name
  Assert-AreEqual $NewKeyspace.CassandraKeyspaceGetResultsId $Keyspace.CassandraKeyspaceGetResultsId
  Assert-AreEqual $NewKeyspace._rid $Keyspace._rid
  Assert-AreEqual $NewKeyspace._ts $Keyspace._ts
  Assert-AreEqual $NewKeyspace._etag $Keyspace._etag

  $Table = Get-AzCosmosDBCassandraTable -InputObject $NewKeyspace -Name $TableName
  Assert-AreEqual $NewTable.Id $Table.Id
  Assert-AreEqual $NewTable.Name $Table.Name
  Assert-AreEqual $NewTable.CassandraTableGetResultsId $Table.CassandraTableGetResultsId
  Assert-AreEqual $NewTable._rid $Table._rid
  Assert-AreEqual $NewTable._ts $Table._ts
  Assert-AreEqual $NewTable._etag $Table._etag

  $ListTables = Get-AzCosmosDBCassandraTable -InputObject $NewKeyspace
  Assert-NotNull($ListTables)

  $ListKeyspaces = Get-AzCosmosDBCassandraKeyspace -InputObject $cosmosDBAccount
  Assert-NotNull($ListKeyspaces)

  $IsTableRemoved =  Remove-AzCosmosDBCassandraTable -InputObject $NewTable -PassThru
  Assert-AreEqual $IsTableRemoved true
  
  $IsKeyspaceRemoved = Remove-AzCosmosDBCassandraKeyspace -InputObject $NewKeyspace -PassThru
  Assert-AreEqual $IsKeyspaceRemoved true
}