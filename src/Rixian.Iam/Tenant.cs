// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    /// <summary>
    /// Entity representation of a tenant.
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Gets or sets the tenant ID.
        /// </summary>
        [JsonProperty("tenantId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the tenant name.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }
    }
}
