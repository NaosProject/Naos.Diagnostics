﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceCounterDescription.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using static System.FormattableString;

    /// <summary>
    /// Model that holds descrption of a Perfomance Counter.
    /// </summary>
    public class PerformanceCounterDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceCounterDescription"/> class.
        /// </summary>
        /// <param name="categoryName">Category name.</param>
        /// <param name="counterName">Counter name.</param>
        /// <param name="instanceName">Instance name.</param>
        public PerformanceCounterDescription(string categoryName, string counterName, string instanceName = null)
        {
            this.CategoryName = categoryName;
            this.CounterName = counterName;
            this.InstanceName = instanceName;
        }

        /// <summary>
        /// Gets the category name.
        /// </summary>
        public string CategoryName { get; private set; }

        /// <summary>
        /// Gets the counter name.
        /// </summary>
        public string CounterName { get; private set; }

        /// <summary>
        /// Gets the instance name.
        /// </summary>
        public string InstanceName { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var result = Invariant($"{nameof(PerformanceCounterDescription)} - {nameof(this.CategoryName)}: {this.CategoryName}; {nameof(this.CounterName)}: {this.CounterName}; {nameof(this.InstanceName)}: {this.InstanceName ?? "<null>"}.");
            return result;
        }
    }

    /// <summary>
    /// Model of a sampled performance counter.
    /// </summary>
    public class PerformanceCounterSample
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceCounterSample"/> class.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="value">The sampled value.</param>
        public PerformanceCounterSample(PerformanceCounterDescription description, float value)
        {
            this.Description = description;
            this.Value = value;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public PerformanceCounterDescription Description { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public float Value { get; private set; }
    }
}