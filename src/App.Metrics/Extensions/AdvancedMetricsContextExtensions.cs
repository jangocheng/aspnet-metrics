﻿// Copyright (c) Allan hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using App.Metrics.Data;
using App.Metrics.Sampling;

// ReSharper disable CheckNamespace
namespace App.Metrics.Core
// ReSharper restore CheckNamespace
{
    public static class AdvancedMetricsContextExtensions
    {
        public static ICounterMetric BuildCounter(this IAdvancedMetricsContext context, CounterOptions options)
        {
            return new CounterMetric();
        }

        public static IMetricValueProvider<double> BuildGauge(this IAdvancedMetricsContext context, GaugeOptions options, Func<double> valueProvider)
        {
            return new FunctionGauge(valueProvider);
        }

        public static IHistogramMetric BuildHistogram(this IAdvancedMetricsContext context, HistogramOptions options)
        {
            return new HistogramMetric(options.SamplingType);
        }

        public static IHistogramMetric BuildHistogram(this IAdvancedMetricsContext context, HistogramOptions options, IReservoir reservoir)
        {
            return new HistogramMetric(reservoir);
        }

        public static IMeterMetric BuildMeter(this IAdvancedMetricsContext context, MeterOptions options)
        {
            return new MeterMetric(context.Clock);
        }

        public static ITimerMetric BuildTimer(this IAdvancedMetricsContext context, TimerOptions options)
        {
            return new TimerMetric(options.SamplingType, context.Clock);
        }

        public static ITimerMetric BuildTimer(this IAdvancedMetricsContext context, TimerOptions options, IHistogramMetric histogram)
        {
            return new TimerMetric(histogram, context.Clock);
        }

        public static ITimerMetric BuildTimer(this IAdvancedMetricsContext context, TimerOptions options, IReservoir reservoir)
        {
            return new TimerMetric(reservoir, context.Clock);
        }
    }
}