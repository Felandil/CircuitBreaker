// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeocodeApiRequest.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Example
{
  /// <summary>
  /// The geocode api request.
  /// </summary>
  public class GeocodeApiRequest
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the postcode.
    /// </summary>
    public string Postcode { get; set; }

    /// <summary>
    /// Gets or sets the town.
    /// </summary>
    public string Town { get; set; }

    #endregion
  }
}