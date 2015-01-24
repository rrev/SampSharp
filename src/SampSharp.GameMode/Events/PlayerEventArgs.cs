﻿// SampSharp
// Copyright 2015 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using SampSharp.GameMode.World;

namespace SampSharp.GameMode.Events
{
    /// <summary>
    ///     Provides data for the <see cref="BaseMode.VehicleDied" />, <see cref="BaseMode.PlayerPickUpPickup" />,
    ///     <see cref="BaseMode.VehicleDamageStatusUpdated" />, <see cref="BaseMode.PlayerStreamIn" />,
    ///     <see cref="BaseMode.PlayerStreamOut" />, <see cref="BaseMode.VehicleStreamIn" />,
    ///     <see cref="BaseMode.VehicleStreamOut" />, <see cref="GtaPlayer.StreamIn" />, <see cref="GtaPlayer.StreamOut" />,
    ///     <see cref="GtaVehicle.StreamIn" />, <see cref="GtaVehicle.StreamOut" /> or <see cref="Pickup.PickUp" /> event.
    /// </summary>
    public class PlayerEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerEventArgs" /> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public PlayerEventArgs(GtaPlayer player)
        {
            Player = player;
        }

        /// <summary>
        ///     Gets the player involved.
        /// </summary>
        public GtaPlayer Player { get; private set; }
    }
}