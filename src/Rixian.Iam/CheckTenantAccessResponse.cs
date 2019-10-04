// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Response object when checking tenant access.
    /// </summary>
    public class CheckTenantAccessResponse
    {
        /// <summary>
        /// Gets or sets the subject IDs that have valid access to the tenant.
        /// </summary>
        [JsonProperty("values", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<string> SubjectIds { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
