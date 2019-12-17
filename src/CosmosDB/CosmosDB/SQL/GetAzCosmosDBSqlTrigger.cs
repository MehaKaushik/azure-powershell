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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlTrigger"), OutputType(typeof(PSSqlTriggerGetResults))]
    public class GetAzCosmosDBSqlTrigger : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ContainerNameHelpMessage)]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TriggerNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            
            if(!string.IsNullOrEmpty(Name))
            {
                SqlTriggerGetResults sqlTriggerGetResults = CosmosDBManagementClient.SqlResources.GetSqlTriggerWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlTriggerGetResults(sqlTriggerGetResults));
            }
            else
            {
                IEnumerable<SqlTriggerGetResults> sqlTriggers = CosmosDBManagementClient.SqlResources.ListSqlTriggersWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName).GetAwaiter().GetResult().Body;
                
                foreach(SqlTriggerGetResults sqlTrigger in sqlTriggers)
                    WriteObject(new PSSqlTriggerGetResults(sqlTrigger));
            }

            return;
        }
    }
}
