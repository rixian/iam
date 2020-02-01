// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Response object when checking tenant access.
    /// </summary>
    public class AclCheckResponse
    {
        /// <summary>
        /// Gets the subject IDs that have valid access to the tenant.
        /// </summary>
        [JsonProperty("subjectIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<string> SubjectIds { get; } = new List<string>();
    }
}
