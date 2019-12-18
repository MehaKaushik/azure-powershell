﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlDatabaseThroughput", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSThroughputSettingsGetResults))]
    public class GetAzCosmosDBSqlDatabaseThroughput : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccount InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
           if(ParameterSetName.Equals(ObjectParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                AccountName = resourceIdentifier.ParentResource;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            ThroughputSettingsGetResults throughputSettingsGetResults = CosmosDBManagementClient.SqlResources.GetSqlDatabaseThroughputWithHttpMessagesAsync(ResourceGroupName, AccountName, Name).GetAwaiter().GetResult().Body;
            WriteObject(new PSThroughputSettingsGetResults(throughputSettingsGetResults));
            
            return;
        }
    }
}
