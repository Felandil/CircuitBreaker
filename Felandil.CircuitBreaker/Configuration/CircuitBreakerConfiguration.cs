// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerConfiguration.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Configuration
{
  using System;
  using System.Configuration;

  /// <summary>
  /// The circuit breaker configuration.
  /// </summary>
  internal static class CircuitBreakerConfiguration
  {
    #region Public Properties

    /// <summary>
    /// Gets the default failure threshold.
    /// </summary>
    public static int DefaultFailureThreshold
    {
      get
      {
        return GetCommand("Default").FailureThreshold;
      }
    }

    /// <summary>
    /// Gets the default open time.
    /// </summary>
    public static TimeSpan DefaultOpenTime
    {
      get
      {
        return GetCommand("Default").OpenTime;
      }
    }

    /// <summary>
    /// Gets the default success threshold.
    /// </summary>
    public static int DefaultSuccessThreshold
    {
      get
      {
        return GetCommand("Default").SuccessThreshold;
      }
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The failure threshold by command.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public static int FailureThresholdByCommand(string commandName)
    {
      if (string.IsNullOrEmpty(commandName))
      {
        return DefaultFailureThreshold;
      }

      var config = GetCommand(commandName);
      return config == null ? DefaultFailureThreshold : config.FailureThreshold;
    }

    /// <summary>
    /// The failure threshold by command.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public static TimeSpan OpenTimeByCommand(string commandName)
    {
      if (string.IsNullOrEmpty(commandName))
      {
        return DefaultOpenTime;
      }

      var config = GetCommand(commandName);
      return config == null ? DefaultOpenTime : config.OpenTime;
    }

    /// <summary>
    /// The failure threshold by command.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public static int SuccessThresholdByCommand(string commandName)
    {
      if (string.IsNullOrEmpty(commandName))
      {
        return DefaultSuccessThreshold;
      }

      var config = GetCommand(commandName);
      return config == null ? DefaultSuccessThreshold : config.SuccessThreshold;
    }

    #endregion

    #region Methods

    /// <summary>
    /// The get section.
    /// </summary>
    /// <param name="commandName">
    /// The command Name.
    /// </param>
    /// <returns>
    /// The <see cref="CircuitBreakerConfigurationSection"/>.
    /// </returns>
    private static CircuitBreakerConfigurationElement GetCommand(string commandName)
    {
      return ((CircuitBreakerConfigurationSection)ConfigurationManager.GetSection("FelandilCircuitBreaker")).Commands.GetCommandByName(commandName);
    }

    #endregion
  }
}