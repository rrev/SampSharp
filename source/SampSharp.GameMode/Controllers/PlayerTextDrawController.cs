﻿// SampSharp
// Copyright (C) 2014 Tim Potze
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org>

using SampSharp.GameMode.Display;

namespace SampSharp.GameMode.Controllers
{
    /// <summary>
    ///     A controller processing all player-textdraw actions.
    /// </summary>
    public class PlayerTextDrawController : IEventListener, ITypeProvider
    {
        /// <summary>
        ///     Registers the events this PlayerTextDrawController wants to listen to.
        /// </summary>
        /// <param name="gameMode">The running GameMode.</param>
        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerClickPlayerTextDraw += (sender, args) => PlayerTextDraw.Find(args.Player, args.TextDrawId).OnClick(args);
        }

        /// <summary>
        ///     Registers types this PlayerTextDrawController requires the system to use.
        /// </summary>
        public void RegisterTypes()
        {
            PlayerTextDraw.Register<PlayerTextDraw>();
        }
    }
}