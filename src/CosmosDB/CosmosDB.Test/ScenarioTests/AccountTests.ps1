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

function Test-AccountRelatedCmdlets
{
  $rgName = "CosmosDBResourceGroup"
  $location = "East US"
  $locationlist = "East US", "West US"
  $locationlist2 = "East US", "UK South", "UK West", "South India"
  $locationlist3 = "West US", "East US"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

  $cosmosDBAccountName = "cosmosdb67121200123"

  $cosmosDBExistingAccountName = "dbaccount27" 
  $existingResourceGroupName = "CosmosDBResourceGroup27"

  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -Location $location -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork  -EnableMultipleWriteLocations  -EnableAutomaticFailover -ApiKind "MongoDB"
    do 
    {
       $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBAccountName $cosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $cosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $cosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $cosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $ipRangeFilter $cosmosDBAccount.IpRangeFilter
  Assert-AreEqual $cosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $cosmosDBAccount.EnableMultipleWriteLocations 1
  Assert-AreEqual $cosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
      do 
    {
       $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $ipRangeFilter $updatedCosmosDBAccount.IpRangeFilter
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $updatedCosmosDBAccountLocation = Update-AzCosmosDBAccountRegion -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $locationlist2 -PassThru

  $IsAccountDeleted = Remove-AzCosmosDBAccount -Name $cosmosDBAccountName -ResourceGroupName $rgName -PassThru
  Assert-AreEqual $IsAccountDeleted true
}