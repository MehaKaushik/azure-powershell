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

namespace Microsoft.Azure.Commands.DataShare.Share
{
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using System.Management.Automation;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;

    /// <summary>
    /// Defines the New-DataShare cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShare", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.FieldsParameterSet), OutputType(typeof(PSDataShare))]
    public class NewAzDataShare : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "The resource group name of the azure data share account")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage =  "Azure data share account name")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of the azure data share.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "Azure data share name")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string Name { get; set; }

        /// <summary>
        /// Share kind of data share
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "Share kind of azure data share")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("CopyBased")]
        public string ShareKind { get; set; }

        /// <summary>
        /// Description of the azure data share.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet,
            HelpMessage = "Description of azure data share")]
        public string Description { get; set; }

        /// <summary>
        /// Terms of use of azure data share.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.FieldsParameterSet, 
            HelpMessage = "Terms of use for azure data share")]
        public string TermsOfUse { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                string.Format(Resources.ResourceCreateConfirmation, this.Name),
                this.Name,
                this.NewShare);
        }

        private void NewShare()
        {
            if (this.ShouldProcess(this.Name, "Create"))
            {
                Share dataShare = this.DataShareManagementClient.Shares.Create(
                    this.ResourceGroupName,
                    this.AccountName,
                    this.Name,
                    new Share()
                    {
                        ShareKind = this.ShareKind,
                        Description = this.Description,
                        Terms = this.TermsOfUse
                    });

                this.WriteObject(dataShare.ToPsObject());
            }
        }
    }
}
