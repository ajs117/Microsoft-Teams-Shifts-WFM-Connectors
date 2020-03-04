﻿// <copyright file="ITimeOffMappingEntityProvider.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Shifts.Integration.BusinessLogic.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Teams.Shifts.Integration.BusinessLogic.Models;

    /// <summary>
    /// This interface defines all of the necessary methods that are required for mapping time off between Kronos and Shifts.
    /// </summary>
    public interface ITimeOffMappingEntityProvider
    {
        /// <summary>
        /// Get all the time off entities.
        /// </summary>
        /// <param name="processKronosUsersInBatchList">Users in batch.</param>
        /// <param name="monthPartitionKey">Month Partition.</param>
        /// <returns>Mapped time off entities based on month partition and batched users.</returns>
        Task<List<TimeOffMappingEntity>> GetAllTimeOffMappingEntitiesAsync(
          IEnumerable<UserDetailsModel> processKronosUsersInBatchList,
          string monthPartitionKey);
    }
}
